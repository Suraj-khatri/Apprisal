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
    public partial class ExportExcelAssetGroupWiseRpt : BasePage
    {
        ClsDAOInv _clsdao = null;
        string sql = "";

        public ExportExcelAssetGroupWiseRpt()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string group = Request.QueryString["Assetgroup"].ToString() == "" ? "null" : Request.QueryString["Assetgroup"].ToString();
            string type = Request.QueryString["type"].ToString() == "" ? "null" : Request.QueryString["type"].ToString();
            string branch = Request.QueryString["branch"].ToString() == "" ? "null" : Request.QueryString["branch"].ToString();

            double p_value = 0.00, acc_dep = 0.00, booked_value = 0.00;
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec ProcAssetGroupWiseReport  'a'," + filterstring(group) + "," + filterstring(type) + "," + filterstring(branch) + "");

            int cols = dt.Columns.Count;
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
                    if (i == 4 || i == 5 || i == 6)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 2 || i == 3)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                p_value = p_value + double.Parse(row[4].ToString());
                acc_dep = acc_dep + double.Parse(row[5].ToString());
                booked_value = booked_value + double.Parse(row[6].ToString());
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"2\" align=\"center\"><b>Total</b></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(p_value.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(booked_value.ToString()) + "</b></td>");
            str.Append("<td colspan=\"7\" align=\"center\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }
    }
}
