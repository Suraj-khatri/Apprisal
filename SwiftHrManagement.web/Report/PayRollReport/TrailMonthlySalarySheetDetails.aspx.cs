using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class TrailMonthlySalarySheetDetails : BasePage
    {
         clsDAO _clsdao = null;
        public TrailMonthlySalarySheetDetails()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branchID = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            Lblmonth.Text = _clsdao.GetSingleresult("select Name from MonthList where Month_Number="+month+""); ;

            DataTable dt = _clsdao.getDataset("exec [ProcMonthlyPayrollReportTrial_Dyanamic] 'a'," + filterstring(year) + "," + filterstring(month) + ","
                            + "" + filterstring(branchID) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed branchlist\" align=\"center\" >");

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
                    if (i<=5)
                    {
                        str.Append("<td class=\"text-left\">" + dr[i].ToString() + "</td>");
                    }

                    else if (i >5)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"6\" align=\"left\"><b>Total</b></td>");
            for (int i = 6; i <= cols - 1; i++)
            {
                str.Append("<td class=\"text-right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("<td align=\"left\"></td>");
            str.Append("</tr>");
            
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
