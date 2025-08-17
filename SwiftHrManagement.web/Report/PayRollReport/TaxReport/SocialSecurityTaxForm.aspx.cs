using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport.TaxReport
{
    public partial class SocialSecurityTaxForm : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public SocialSecurityTaxForm()
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
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "");
            DdlFiscalYear.SelectedValue = CLsDAo.GetSingleresult("SELECT FISCAL_YEAR_NEPALI FROM FiscalYear WHERE FLAG =1");

            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches ORDER BY BRANCH_SHORT_NAME", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            CLsDAo.setDDL(ref DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "");
            DdlYear.SelectedValue = CLsDAo.GetSingleresult("SELECT FISCAL_YEAR_NEPALI FROM FiscalYear WHERE FLAG =1");
            CLsDAo.CreateDynamicDDl(DdlReportType, "SELECT 'SALARY' AS VALUE,'SALARY' AS TEXT UNION ALL SELECT 'TDS','TDS' UNION ALL"
                    +" SELECT 'PF','PF' UNION ALL SELECT DETAIL_TITLE,DETAIL_TITLE FROM StaticDataDetail"
                    + " WHERE ROWID IN (SELECT DISTINCT LOAN_TYPE FROM Loan)", "VALUE", "TEXT", "", "SELECT");
        }

        protected void BtnShowReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("SocialSecurityTaxReport.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "");
        }

        protected void BtnSearchSummaryRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayrollSummaryRpt.aspx?report_type=" + DdlReportType.Text + "&fiscal=" + DdlFiscalYear.Text + "&branch=" + DdlBranchName.Text + "");
        }
    }
}
