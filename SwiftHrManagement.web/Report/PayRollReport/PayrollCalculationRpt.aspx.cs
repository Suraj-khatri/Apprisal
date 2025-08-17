using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class PayrollCalculationRpt : BasePage
    {
        clsDAO _clsdao = null;
        public PayrollCalculationRpt()
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
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            //Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            //LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            //Lblmonth.Text = "Salary Sheet Details For Fiscal Year : "+year+", Month : "+_clsdao.GetSingleresult("select Name from MonthList where Month_Number=" + month + "");

            DataTable dt = _clsdao.getDataset("exec [procPayrollCalDetail] 'a'," + filterstring(year) + "," + filterstring(month) + "").Tables[0];

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
                    if (i > 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else if (i ==1)
                    {
                        str.Append("<td align=\"left\">'" + dr[i].ToString() + "</td>");
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
