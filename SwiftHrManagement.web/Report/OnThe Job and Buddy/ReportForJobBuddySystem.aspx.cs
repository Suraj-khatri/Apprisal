using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.OnThe_Job_and_Buddy
{
    public partial class ReportForJobBuddySystem : BasePage
    {
         clsDAO _clsdao = null;
         RoleMenuDAOInv _roleMenuDao = null;
         public ReportForJobBuddySystem()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 39) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropDownList();
                DateTime fromdate = DateTime.Now;
                txtFrom.Text = fromdate.ToString("MM/dd/yyyy");
                txtTo.Text = fromdate.ToString("MM/dd/yyyy");

            }

        }
        private void PopulateDropDownList()
        {
            _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            //_clsdao.CreateDynamicDDl(DdlTrainingProgram, "select external_traingin_id,Program_Name from externalTrainingInfo", "external_traingin_id", "Program_Name", "", "Select");

        }  
        protected void Btn_ShowReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainingWiseReport.aspx?From=" + txtFrom.Text + "&To=" + txtTo.Text + "&Branch=" + DdlBranchName.Text + "&Depart=" + DdlDeptName.Text + "&Emp=" + DdlEmpName.Text + "&Train=" + DdlTrainingType.Text); 
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }  
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchName.Text + " AND DEPARTMENT_ID=" + DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }
    }
}
