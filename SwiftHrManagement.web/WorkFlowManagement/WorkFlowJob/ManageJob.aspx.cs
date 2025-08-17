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
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.WorkFlowManagement;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob
{
    public partial class ManageJob : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        WFJobCore _jobCore = null;
        WFJobDAO _jobDAO = null;
        clsDAO CLsDAo = null;
        public ManageJob()
        {
            _jobCore = new WFJobCore();
            _jobDAO = new WFJobDAO();
            CLsDAo=new clsDAO();
        }

        private long GetJobId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private string GetFlag()
        {
            return (Request.QueryString["Flag"] != null ? Request.QueryString["Flag"].ToString() : "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 83) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                }
                long id = GetJobId();
                string flag = GetFlag();
                if (flag.Trim() == "P")
                {
                    Btn_Back.Visible = false;
                    Btn_Delete.Visible = false;
                    Btn_Update.Visible = false;
                    TxtCustomerCode.Enabled = false;
                    DdlJobCategory.Enabled = false;
                    DdlStaffName.Enabled = false;
                    TxtJobDescription.Enabled = false;

                }
                else
                {
                    Btn_Back.Visible = true;
                }
                if (id > 0)
                {
                    CLsDAo.CreateDynamicDDl(DdlJobCategory, "SELECT WF_CATEGORYID, WF_CATNAME FROM WF_CATEGORY", "WF_CATEGORYID", "WF_CATNAME", "", "Select");
                    PopulateJobList();
                    TxtCustomerCode.Enabled = false;
                    DdlJobCategory.Enabled = false;
                    DdlStaffName.Enabled = false;
                    txtJobCode.Enabled = false;
                    DdlDeptName.Enabled = false;
                    Btn_Save.Visible = false;
                }
                else
                {
                    Btn_Update.Visible = false;
                    Btn_Delete.Visible = false;
                }
            }
            Btn_Back.Attributes.Add("onclick", "history.back();return false");
        }

        private void PopulateJobList()
        {

            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("SELECT W.WF_JOBID,C.CUSTOMERCODE+'-'+C.CUSTOMERNAME+'|'+cast(C.ID as varchar) as CUSTOMERCODE,WC.WF_DeptName,"
	                +" W.WF_CATID,W.JOB_CODE,W.WF_JOB_DESCRIPTION FROM WF_JOB W INNER JOIN WF_CUSTOMER C ON C.ID=W.CustomerCode inner join WF_Category " 
	                +" WC ON WC.WF_CategoryID=W.WF_CatID"
                    + " WHERE WF_JOBID = '" + GetJobId() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtCustomerCode.Text = dr["CUSTOMERCODE"].ToString();
                DdlDeptName.SelectedValue = dr["WF_DeptName"].ToString();
                DdlJobCategory.SelectedValue = dr["WF_CATID"].ToString();
                txtJobCode.Text = dr["JOB_CODE"].ToString();
                TxtJobDescription.Text = dr["WF_JOB_DESCRIPTION"].ToString();
            }
        }
        protected void DdlJobCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlJobCategory.Text != "" && DdlDeptName.Text!="")
            {
                CLsDAo.CreateDynamicDDl(DdlStaffName, "SELECT M.EMPLOYEE_ID,E.EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPNAME FROM WF_MEMBER M INNER JOIN EMPLOYEE E  ON E.EMPLOYEE_ID = M.EMPLOYEE_ID WHERE M.WF_CATEGORYID =" + this.DdlJobCategory.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }            
        }
        private void populateEmployeeByCatID(long id)
        {
            CLsDAo.CreateDynamicDDl(DdlStaffName, "SELECT M.EMPLOYEE_ID,E.EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPNAME FROM WF_MEMBER M INNER JOIN EMPLOYEE E  ON E.EMPLOYEE_ID = M.EMPLOYEE_ID WHERE M.WF_CATEGORYID =" + id + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            DdlStaffName.SelectedIndex = 1;
        }

        private void populateCatByCatID(long id)
        {
            CLsDAo.CreateDynamicDDl(DdlJobCategory, "SELECT WF_CATEGORYID, WF_CATNAME FROM WF_CATEGORY", "WF_CATEGORYID", "WF_CATNAME", "", "Select");
            DdlJobCategory.SelectedIndex = 1;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {                
                prepareJobList();
                Response.Redirect("JobList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        public Boolean CheckDublicateEntry()
        {
            Boolean IfExists = CLsDAo.CheckStatement("select * from WF_Job WHERE Job_Code="+filterstring(txtJobCode.Text)+"");
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void prepareJobList()
        {
             //string jCode = _jobDAO.getJobCode();
             //_jobCore.JobCode = jCode;            
            string[] ss = TxtCustomerCode.Text.Split('|');
            _jobCore.CustCode = ss[1];

            _jobCore.JobCode = txtJobCode.Text;
            _jobCore.JobCatID = long.Parse(DdlJobCategory.SelectedValue);
            _jobCore.CreatedDate = _jobCore.CreatedDate;
            _jobCore.JobDescription = TxtJobDescription.Text;
            _jobCore.JobCreator = ReadSession().Emp_Id;
            if (GetJobId() > 0)
            {
                _jobCore.JobID = GetJobId();
                _jobDAO.Update(_jobCore);
            }
            else
            {
                if (CheckDublicateEntry() == true)
                {
                    LblMsg.Text = "Job Code already existed!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    _jobCore.CreatedEmpID = long.Parse(DdlStaffName.SelectedValue);
                    _jobDAO.Save(_jobCore);
                }
            } 
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            try
            {
                prepareJobList();
                Response.Redirect("JobList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                _jobCore.JobID = GetJobId();
                _jobDAO.Delete(_jobCore);
                Response.Redirect("JobList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlDeptName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlJobCategory, "SELECT WF_CATEGORYID, WF_CATNAME FROM WF_CATEGORY where WF_DeptName=" + filterstring(DdlDeptName.Text) + "", "WF_CATEGORYID", "WF_CATNAME", "", "Select");
            }
        }
    }
}
