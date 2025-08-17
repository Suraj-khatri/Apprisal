using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport.empDetails
{
    public partial class Manage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 93) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateBranchList();
            }
        }
        private void PopulateBranchList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }
        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchName.Text + " AND DEPARTMENT_ID=" + DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?branchId="+DdlBranchName.Text+"&deptId="+DdlDeptName.Text+"&empId="+DdlEmpName.Text+"");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExcelList.aspx?branch="+ DdlBranchName.Text + "&dept="+ DdlDeptName.Text + "&emp="+ DdlEmpName.Text + "");
        }
    }
}
