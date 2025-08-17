using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Report.Leave.IdividualHistory
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
            SetDDL();
        }

        private void SetDDL()
        {
            CLsDAo.CreateDynamicDDl(DdlYear, "select nplYear from Fiscal_Month where DefaultYr = 'N' order by cast(nplYear as int) desc", "nplYear", "nplYear", "", "");
        }

        protected void BtnShowReportType_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/Leave/IdividualHistory/ManageReport.aspx?bsDate="+DdlYear.Text+"&fromDate="+txtReqDateFrom.Text+"&toDate="+txtReqDateTo.Text+"");
        }
    }
}
