using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport.GradeIncrement
{
    public partial class Report : BasePage
    {
        clsDAO _clsdao = null;
        public Report()
        {
            this._clsdao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();    
        }

        public void LoadHTML()
        {
            string year = Request.QueryString["FY"] == null ? "" : Request.QueryString["FY"].ToString();

            DataTable dt = _clsdao.getDataset("exec [proc_AppliedGradeReport] " + filterstring(year) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 8)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }

            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}