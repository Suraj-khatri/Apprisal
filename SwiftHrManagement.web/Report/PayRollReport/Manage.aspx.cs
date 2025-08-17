using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
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
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 90) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }
        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlMonthName, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlYear1, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(yearGL, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(ddlVoucherYr, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(monthGL, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(ddlVoucherMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");

            DdlYear.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            DdlYear1.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            ddlVoucherYr.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            yearGL.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");

            CLsDAo.CreateDynamicDDl(calFYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            calFYear.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            CLsDAo.CreateDynamicDDl(calMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
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
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?year=" + DdlYear1.Text + "&month=" + DdlMonthName.Text + "");            
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("YearlySalaryDetails.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void BtnSalary_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthlySalarySheetDetails.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void BtnSalaryTrail_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrailMonthlySalarySheetDetails.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void ExpertToExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExcelList_Trial.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void Export_Live_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExcelList_Live.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void calSearchRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayrollCalculationRpt.aspx?year=" + calFYear.Text + "&month=" + calMonth.Text + "");
        }

        protected void calSearchRptTrail_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayrollCalculationRptTrial.aspx?year=" + calFYear.Text + "&month=" + calMonth.Text + "");
        }

        protected void btnUploadGL_Click(object sender, EventArgs e)
        {
            Response.Redirect("rptForUploadGL.aspx?year=" + yearGL.Text + "&month=" + monthGL.Text + "");
        }

        protected void Tax_Report_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpTaxDetail.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&branch=" + DdlBranchName.SelectedValue + "&dept=" + DdlDeptName.SelectedValue + "&empid=" + DdlEmpName.SelectedValue + "");
        }

        protected void btnUploadGLTrail_Click(object sender, EventArgs e)
        {
            Response.Redirect("rptForUploadGL_trial.aspx?&year=" + yearGL.Text + "&month=" + monthGL.Text + "");
        }

        protected void ButtonSearchTrial_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListTrialrun.aspx?year=" + DdlYear1.Text + "&month=" + DdlMonthName.Text + "");    
        }

        protected void btnVoucherLive_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherUploadRpt.aspx?year=" + ddlVoucherYr.Text + "&month=" + ddlVoucherMonth.Text + "&branch=" + DdlBranch.Text + "");
        }

        protected void btnVoucherTrial_Click(object sender, EventArgs e)
        {
            if (DdlBranch.Text == "All")
            {
                Response.Redirect("VoucherUpload_Trial.aspx?year=" + ddlVoucherYr.Text + "&month=" + ddlVoucherMonth.Text + "&branch=" + null + "");
            }
            else
            {
                Response.Redirect("VoucherUpload_Trial.aspx?year=" + ddlVoucherYr.Text + "&month=" + ddlVoucherMonth.Text + "&branch=" + DdlBranch.Text + "");
            }
        }
    }
}
