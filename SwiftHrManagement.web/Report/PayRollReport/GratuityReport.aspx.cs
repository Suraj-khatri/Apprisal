using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class GratuityReport : BasePage
    {
        clsDAO _clsdao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            //Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            //LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            //Lblmonth.Text = "Gratuity Report For Fiscal Year : " + year + "";

            DataSet ds = _clsdao.getDataset("Exec Proc_GratuityCalculationReport @fy_id=" + filterstring(year) + ",@month=" + filterstring(month) + "");


            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");

            DataTable dt = dt = ds.Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i==3 || i==4)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i == 0 || i > 4)
                    {
                        if (i>= 8 && i<=11)
                        {
                            str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}