using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.Leave.Leave_Incashment
{
    public partial class Manage : System.Web.UI.Page
    {
        clsDAO CLsDAo = null;

        public Manage()
        {
            CLsDAo = new clsDAO();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDDL();
            }
        }

        private void SetDDL()
        {
            CLsDAo.CreateDynamicDDl(ddlYear, "select nplYear from Fiscal_Month where DefaultYr is not null", "nplYear", "nplYear", "", "");
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/Leave/LeaveIncashment/ExportToExcel.aspx?bsDate=" + ddlYear.Text + "");
        }
    }
}