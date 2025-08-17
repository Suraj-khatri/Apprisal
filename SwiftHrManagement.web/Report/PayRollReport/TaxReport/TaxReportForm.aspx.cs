using System;
using System.Drawing;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport.TaxReport
{
    public partial class TaxReportForm : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public TaxReportForm()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                PopulateDropdownList();
            }
        }
        private void PopulateDropdownList()
        {
                CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
                CLsDAo.setDDL(ref DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
                CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
        
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

        protected void BtnViewSummery_Click(object sender, EventArgs e)
        {
            if (DdlEmpName.Text == "")
            {
                LblMassge.Text = "Employee Required!";
                LblMassge.ForeColor = Color.Red;
                return;
            }
            Response.Redirect("TDSTReportEmployeeWise.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.Text + "&dept=" + DdlDeptName.Text + "&empid=" + DdlEmpName.Text + "");
        }

        protected void BtnBranch_Click(object sender, EventArgs e)
        {
            Response.Redirect("TDSReportForBranchWise.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.Text + "&dept=" + DdlDeptName.Text + "&empid=" + DdlEmpName.Text + "");
        }
    }
}
