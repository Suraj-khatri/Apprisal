using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class yearlyReport : BasePage
    {
        clsDAO CLsDAo =new clsDAO();
        RoleMenuDAOInv _roleMenuDao =new RoleMenuDAOInv();
        //public yearlyReportManage()
        //{
        //    this.CLsDAo = new clsDAO();
        //    this._roleMenuDao = new RoleMenuDAO();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 282) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }

        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            //CLsDAo.CreateDynamicDDl(DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            DdlYear.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }

        protected void BtnSalary_Click(object sender, EventArgs e)
        {
            Response.Redirect("YearlySalarySheetDetails.aspx?year=" + DdlYear.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
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

        protected void BtnIndReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inv_consolidated_report.aspx?year=" + DdlYear.Text + "&empid=" + DdlEmpName.SelectedValue + "");
        }
    }
}
