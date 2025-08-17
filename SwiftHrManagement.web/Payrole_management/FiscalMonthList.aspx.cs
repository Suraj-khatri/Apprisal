using System;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Payrole.FiscalMonthSetup;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class FiscalMonthList : BasePage
    {
        FiscalMonthDAO _fiscalmonth = null;

        public FiscalMonthList()
        {
            _fiscalmonth = new FiscalMonthDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListMonth(this.ReadSession().Current_Fiscal_Year);
                /*string fiscalYear = "2009";
                [proc_Fiscal_Month] 'a','2009'
                GvMonthList.DataSource = dt;
                GvMonthList.DataBind();
                D:\Dev_Work\Fresh HR as on Feb 09\SwiftHrManagement.web\Payrole_management\EditFiscalMonth.aspx*/
            }
        }
        private void ListMonth(string fy)
        {
            this.GvMonthList.DataSource = _fiscalmonth.FindFiscalsetup(fy);
            GvMonthList.DataBind();
        }

        protected void GvMonthList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string fy = DdlfiscalYear.SelectedItem.Text;

            if (e.Row.RowType!=DataControlRowType.Header)
                e.Row.Cells[6].Text = "<a href=\"EditFiscalMonth.aspx?month_number=" + e.Row.Cells[0].Text + "&fy=" + DdlfiscalYear.SelectedItem.Text + "\">Edit</a>";  
        }

        protected void DdlfiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListMonth(DdlfiscalYear.Text);
        }    
    }
}
