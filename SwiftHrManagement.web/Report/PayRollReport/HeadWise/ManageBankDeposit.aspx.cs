using System;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class ManageBankDeposit : BasePage
    {
        clsDAO CLsDAo = null;

        public ManageBankDeposit()
        {
            this.CLsDAo = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
            }
        }

        private void populateDdl()
        {
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlMonth, "select Name,Month_Number from MonthList", "Month_Number", "Name", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlBank, "Exec ProcStaticDataView 's', '39'", "ROWID", "DETAIL_DESC", "", "All");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/HeadWise/BankDeposits.aspx?FY=" + DdlFiscalYear.Text + "&branchId=" + DdlBranchType.Text + "&Bank=" + DdlBank.Text + "&Month=" + DdlMonth.Text + "");
        }

    }
}