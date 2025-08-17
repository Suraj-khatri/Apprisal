using System;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class DashainReport : BasePage
    {
        clsDAO CLsDAo = null;

        public DashainReport()
        {
            this.CLsDAo = new clsDAO();
        }

        protected void populateDdl()
        {
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/HeadWise/Report.aspx?FY=" + DdlFiscalYear.Text + "");
        }
    }
}