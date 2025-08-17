using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveSummaryRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO CLsDAo = null;
        DynamicRpt _rpt = null;
        public LeaveSummaryRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._rpt = new DynamicRpt();
            this.CLsDAo = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {           
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            
            string leave_year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            lblYear.Text = leave_year;
            DataSet ds = CLsDAo.getDataset("EXEC [procLeaveHistoryRpt] @year=" + filterstring(leave_year) + ",@emp_id=" + filterstring(emp_id) + "");
            rptDiv.InnerHtml = MakeLeaveReport(ref ds);
        }
        private string MakeLeaveReport(ref DataSet ds)
        {
            var dtHead = ds.Tables[0];
            var dtDetail = ds.Tables[1];

            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            str.Append("<tr>");

            str.Append("<th align=\"left\" rowspan = \"2\">Employee Id</th>");
            str.Append("<th align=\"left\" rowspan = \"2\">Name</th>");

            foreach (DataRow dr in dtHead.Rows)
            {
                var columnName = dr["NAME_OF_LEAVE"];
                str.Append("<th align=\"center\" colspan = \"3\">" + columnName + "</th>");
            }
            str.Append("</tr>");


            str.Append("<tr>");
            foreach (DataRow dr in dtHead.Rows)
            {
                str.Append("<th>Earned</th>");
                str.Append("<th>Used</th>");
                str.Append("<th>Balance</th>");
            }
            str.Append("</tr>");


            var cols = dtDetail.Columns.Count;

            foreach (DataRow dr in dtDetail.Rows)
            {
                str.Append("<tr>");
                for (var i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            return str.ToString();

        }
    }
}
