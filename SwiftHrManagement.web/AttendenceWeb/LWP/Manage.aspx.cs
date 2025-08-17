using System;

namespace SwiftHrManagement.web.AttendenceWeb.LWP
{
    public partial class Manage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListLWP.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtToDate.Text + "&empid=" + HiddenFieldEmpID.Value);
        }
    }
}