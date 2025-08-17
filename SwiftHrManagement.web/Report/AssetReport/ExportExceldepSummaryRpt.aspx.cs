using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using System.Text;

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class ExportExceldepSummaryRpt : BasePage
    {
        ClsDAOInv _clsdao = null;
        string sql = "";

        public ExportExceldepSummaryRpt()
        {
            _clsdao = new ClsDAOInv();
        }       
        protected void Page_Load(object sender, EventArgs e)
        {
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string month = Request.QueryString["month"] == "" ? "null" : Request.QueryString["month"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            double OB = 0.00, THIS=0.00,ADD = 0.00, OUT = 0.00, IN = 0.00, SOLD = 0.00, CLOSE = 0.00;

            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procDepreciationMonthlyRpt  'a'," + filterstring(FY) + "," + filterstring(month) + "," + filterstring(branch) + "");

            int cols = dt.Columns.Count;
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 0 || i==1)
                        {
                            str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {                            
                            str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str.Append("</tr>");
                    OB = OB + double.Parse(row[2].ToString());
                    ADD = ADD + double.Parse(row[3].ToString());
                    THIS = THIS + double.Parse(row[4].ToString());
                    IN = IN + double.Parse(row[5].ToString());
                    OUT = OUT + double.Parse(row[6].ToString());                   
                    SOLD = SOLD + double.Parse(row[7].ToString());
                    CLOSE = CLOSE + double.Parse(row[8].ToString());
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(OB.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(ADD.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(THIS.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(IN.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(OUT.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(SOLD.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(CLOSE.ToString()) + "</b></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();


            StringBuilder str1 = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt1 = _clsdao.getTable("Exec procDepreciationMonthlyRpt  'b'," + filterstring(FY) + "," + filterstring(month) + "," + filterstring(branch) + "");
            double OB1 = 0.00, ADD1 = 0.00, THIS1=0.00,OUT1 = 0.00, IN1 = 0.00, SOLD1 = 0.00, CLOSE1 = 0.00;
            int cols1 = dt1.Columns.Count;
            {
                str1.Append("<tr>");
                for (int i = 0; i < cols1; i++)
                {
                    str1.Append("<th><div align=\"left\">" + dt1.Columns[i].ColumnName + "</div></th>");
                }
                str1.Append("</tr>");

                foreach (DataRow row1 in dt1.Rows)
                {
                    str1.Append("<tr>");
                    for (int i = 0; i < cols1; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str1.Append("<td align=\"left\">" + row1[i].ToString() + "</td>");
                        }
                        else
                        {
                            str1.Append("<td align=\"right\">" + ShowDecimal(row1[i].ToString()) + "</td>");
                        }
                    }
                    str1.Append("</tr>");
                    OB1 = OB1 + double.Parse(row1[2].ToString());
                    ADD1 = ADD1 + double.Parse(row1[3].ToString());
                    THIS1 = THIS1 + double.Parse(row1[4].ToString());
                    IN1 = IN1 + double.Parse(row1[5].ToString());
                    OUT1 = OUT1 + double.Parse(row1[6].ToString());
                    SOLD1 = SOLD1 + double.Parse(row1[7].ToString());
                    CLOSE1 = CLOSE1 + double.Parse(row1[8].ToString());
                }
                str1.Append("<tr>");
                str1.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(OB1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(ADD1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(THIS1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(IN1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(OUT1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(SOLD1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(CLOSE1.ToString()) + "</b></td>");
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rpt1.InnerHtml = str1.ToString();
        }
    }
}
