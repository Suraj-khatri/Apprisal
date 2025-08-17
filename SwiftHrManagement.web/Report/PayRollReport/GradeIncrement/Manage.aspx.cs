using System;

namespace SwiftHrManagement.web.Report.PayRollReport.GradeIncrement
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = null;

        public Manage()
        {
            this._clsDao = new clsDAO();
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
            _clsDao.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            DdlFiscalYear.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/GradeIncrement/Report.aspx?FY=" + DdlFiscalYear.Text + "");
        
        }
    }
}