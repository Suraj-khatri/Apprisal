using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.DailyActivityReport
{
    public partial class ActivityReport : BasePage
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            string from = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string to = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            string branch = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string dept = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();

            StringBuilder str = new StringBuilder("<table width=\"700px\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            lblFrom.Text = from;
            lblTo.Text = to;

            DataTable dt = _clsDao.getTable("Exec [proc_activityDailyDetail] @flag='sr',@empId=" + filterstring(empid) + ",@fromDate=" + filterstring(from) + ",@toDate=" + filterstring(to));

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                if (i > 0 && i < 5)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th align=\"left\">View Detail</th>");
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0 && i < 5)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><a href=\"/DailyActivityReport/ActivityDetailReport.aspx?flag=s&activityId=" + dr["activityId"].ToString() + "&status=" + dr["status"].ToString() + "\">Detail</a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
