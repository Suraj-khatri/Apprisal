using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class YearlySalarySheetDetails : BasePage
    {
        clsDAO _clsdao = null;
        public YearlySalarySheetDetails()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
          

            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branchID = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string deptID = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
            //string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            Lblmonth.Text = "Salary Sheet Details For Fiscal Year : " + year + "";

            DataTable dt = _clsdao.getDataset("exec [ProcyearlyPayrollReport_Dyanamic] @flag='a',@branch=" + filterstring(branchID) + ",@dept=" + filterstring(deptID) + ","
                            + "@emp=" + filterstring(empid) + ",@year='" + year + "'").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            double[] sum = new double[cols];

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
                    if (i > 1 && i < cols - 1)
                    {
                        double currVal;
                        double.TryParse(dr[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    if (i <= 1 || i == cols - 1)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i > 1)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }                   
                }
                str.Append("</tr>");
                
            }
            str.Append("<tr>");

            str.Append("<td colspan = \"2\" class=\"text-right\"><b>Total</b></td>");
            for (int i = 2; i < cols-1; i++)
            {
                str.Append("<td class=\"text-right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("</tr>");

            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}