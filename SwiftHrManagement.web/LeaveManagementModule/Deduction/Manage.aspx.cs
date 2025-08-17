using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.LeaveManagementModule.Deduction
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
                TxtFromDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                TxtToDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
        }

        protected void BtnViewRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?from_date=" + TxtFromDate.Text + "&to_date="+TxtToDate.Text+"");
        }
    }
}
