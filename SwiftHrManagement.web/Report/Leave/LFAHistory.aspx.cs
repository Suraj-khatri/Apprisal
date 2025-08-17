using System;


namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LFAHistory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("LFAHistoryReport.aspx?fromdate="+txtFromDate.Text+"&todate="+txtToDate.Text+"&empid="+HiddenFieldEmpID.Value);
        }
    }
}
