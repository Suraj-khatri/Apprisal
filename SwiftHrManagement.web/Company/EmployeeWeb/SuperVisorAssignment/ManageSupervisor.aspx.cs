using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment
{
    public partial class ManageSupervisor : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        private string emp_ids = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDDl();
                if(GetMsg()=="")
                {
                    lblMsgDis.Text = "";
                    lblmsg.Text = "";
                }
                else
                {
                    lblMsgDis.Text = GetMsg();
                    lblMsgDis.ForeColor = System.Drawing.Color.Green;
                }
            }
            emp_ids = Request.Form["ctl00$MainPlaceHolder$DdlSecondList"];            
        }

        private string GetMsg()
        {
            return (Request.QueryString["msg"] != null ? Request.QueryString["msg"].ToString() : "");
        }
        private void setDDl()  
        {
            //            _clsdao.CreateDynamicDDl(lstFirst, @"SELECT a.EMPLOYEE_ID,cast(a.EMPLOYEE_ID as varchar(1000)) + ' | ' +  dbo.GetEmployeeFullNameOfId(a.Employee_Id) EMP_NAME 
//           FROM Employee a with (nolock) order by a.FIRST_NAME asc", "EMPLOYEE_ID", "EMP_NAME", "", "SELECT");

            _clsdao.CreateDynamicDDl(lstSecond, @"SELECT a.EMPLOYEE_ID,cast(a.EMPLOYEE_ID as varchar(1000)) + ' | ' +  dbo.GetEmployeeFullNameOfId(a.Employee_Id) EMP_NAME 
           FROM Employee a with (nolock) order by a.FIRST_NAME asc", "EMPLOYEE_ID", "EMP_NAME", "", "SELECT");

        }


        protected void lstFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlFirstList.Items.Clear();
            if (lstFirst.Text != "")
            {
                string sql = "exec [ProcGetSupervisorEmployee] @FLAG='b',@SUPERVISOR_ID=" + filterstring(lstFirst.Text) + ",@SUP_TYPE="+filterstring(ddlSupType1.Text)+"";
                _clsdao.CreateDynamicDDl(DdlFirstList, sql, "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "");
            }
        }
        
        private void OnMoveSupervisor()
        {
            string msg = _clsdao.GetSingleresult("Exec [procSupervisorMovement] @flag='m',@moveFrom=" + filterstring(lstFirst.Text) + ","
            + " @moveTo=" + filterstring(lstSecond.Text) + ",@emp_ids='" + (emp_ids) + "',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            + " @supType1="+filterstring(ddlSupType1.Text)+",@supType2="+filterstring(ddlSupType2.Text)+"");

            if (msg.Contains("SUCCESS"))
            {

                Response.Redirect("ManageSupervisor.aspx?msg=Supervisor is successfully updated!");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnMoveSupervisor_Click1(object sender, EventArgs e)
        {
            try
            {
                OnMoveSupervisor();
            }
            catch
            {
                lblmsg.Text = "Error in operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlSupType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSupType1.Text == "")
            {
                lstFirst.Items.Clear();
            }
            else
            {
                _clsdao.CreateDynamicDDl(lstFirst, @"SELECT DISTINCT SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR) SUPERVISOR_NAME 
                        FROM SuperVisroAssignment WHERE SUPERVISOR_TYPE=" + filterstring(ddlSupType1.Text) + " and record_status='y'", "SUPERVISOR", "SUPERVISOR_NAME", "", "SELECT");
            }
        }
    }
}