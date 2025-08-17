using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment
{
    public partial class AssignSuperVisorIndividual : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                PopulateData();
                txtSuperVisor.Enabled = false;
                DdlSuperVisorType.Enabled = false;

            }
            
        }
        private long GetSuperId()
        {
            string aa = Request.QueryString["SuperId"];
            if (aa != "")
                return (Request.QueryString["SuperId"] != null ? long.Parse(Request.QueryString["SuperId"]) : 0);
            return 0;

        }
    
        private long GetEmpId()
        {
           return (Request.QueryString["Emp_Id"] != null ? long.Parse(Request.QueryString["Emp_Id"]) : 0);
        
        }
        private long GetDeptId()
        {
            return (Request.QueryString["DeptId"] != null ? long.Parse(Request.QueryString["DeptId"]) : 0);

        }
        private long GetBranchId()
        {
            return (Request.QueryString["BranchId"] != null ? long.Parse(Request.QueryString["BranchId"]) : 0);

        }
                   

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OperationData();
           
        }

        private void PopulateData()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT dbo.GetEmployeeFullNameOfId(EMP)[empName],SUPERVISOR_TYPE,CAST(dbo.GetEmployeeFullNameOfId(sa.SUPERVISOR) AS VARCHAR(20)) + '-'  +EMP_CODE + ' ('+cast(dbo.GetBranchName(sa.BRANCH) as varchar(35)) +') ' +  '|' + CONVERT(VARCHAR, sa.SUPERVISOR) [SUPERVISOR]"
                + " FROM SuperVisroAssignment sa  inner join Employee e ON e.EMPLOYEE_ID = sa.SUPERVISOR WHERE SV_ASSIGN_ID="+GetSuperId()+" AND record_status = 'y'";

            dt = _clsDao.getDataset(sql).Tables[0];

            DataRow dr = null;
            if (dt.Rows.Count == 0)
                return;
            if (dt.Rows.Count > 0)
            {

                dr = dt.Rows[0];
            }

            lblEmpName.Text = dr["empName"].ToString();
            txtSuperVisor.Text = dr["SUPERVISOR"].ToString();
            DdlSuperVisorType.Text = dr["SUPERVISOR_TYPE"].ToString();



        }

        private void OperationData()
        {
            bool Status;
            if (ChkActive.Checked == true)
            {

                 Status = true;
            }
            else
            {
                Status = false;

            }
            string[] a = txtSuperVisor.Text.Split('|');
            string superId = a[1];
           string msg =  _clsDao.GetSingleresult("Exec [proc_SuperVisroAssignment] @flag='u',@SV_ASSIGN_ID = "+filterstring(GetSuperId().ToString())+",@SUPERVISOR=" + filterstring(superId) + ""
                            +",@SUPERVISOR_TYPE=" + filterstring(DdlSuperVisorType.Text) + ",@USER="+filterstring(ReadSession().Emp_Id.ToString())+""
            + ",@BRANCH=" + filterstring(GetBranchId().ToString()) + ",@DEPT=" + filterstring(GetDeptId().ToString()) + ",@EMP=" + filterstring(GetEmpId().ToString()) + ",@ChkStatus="+filterstring(Status.ToString())+"");
           lblmsg.Text = msg;
           lblmsg.ForeColor = System.Drawing.Color.Green;

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/SuperVisorAssignment/ManageSearch.aspx?flag=r");
        }
   
    }
}
