using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class ExcelList_Trial : BasePage
    {
        clsDAO _clsdao = null;

        public ExcelList_Trial()
        {
            this._clsdao = new clsDAO();
            
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();
           
        }
        void LoadHTML()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branchID = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

          DataTable dt = _clsdao.getDataset("exec [ProcMonthlyPayrollReportTrial_Dyanamic] 'a'," + filterstring(year) + "," + filterstring(month) + ","
                            + "" + filterstring(branchID) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {  
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");            
            }
            str.Append("</tr>");

            double[] sum = new double[cols];

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 5 && i <= cols - 1)
                    {
                        double currVal;
                        double.TryParse(dr[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    if ((i<2) || (i>2 && i<5))
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if ((i == 5) || (i==2))
                    {
                        str.Append("<td align=\"left\">'" + dr[i].ToString() + "</td>");
                    }

                    else if (i >5)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"6\" align=\"left\"><b>Total</b></td>");
            for (int i = 6; i <= cols - 1; i++)
            {
                str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString() ) + "</b></td>");
            }
            str.Append("<td align=\"left\"></td>");
            str.Append("</tr>");
            
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}

