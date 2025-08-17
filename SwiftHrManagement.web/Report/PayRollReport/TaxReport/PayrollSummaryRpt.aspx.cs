using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.TaxReport
{
    public partial class PayrollSummaryRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO CLsDAo = null;

        public PayrollSummaryRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            CLsDAo = new clsDAO();
         }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
           
        }
        private void loadReport()
        {
            string rpt_type = Request.QueryString["report_type"] == null ? "" : Request.QueryString["report_type"].ToString();
            string fiscal_year = Request.QueryString["fiscal"] == null ? "" : Request.QueryString["fiscal"].ToString();
            string branch = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            lblYearName.Text = fiscal_year;
            lblReportType.Text = rpt_type;
            lblBranchName.Text=CLsDAo.GetSingleresult("SELECT dbo.GetBranchName("+filterstring(branch)+")");

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-responsive table-bordered table-striped table-condensed\" align=\"center\">");

            DataTable dt = CLsDAo.getTable("EXEC ProcPayrollSummaryRpt @RPT_TYPE=" + filterstring(rpt_type) + ",@YEAR=" + filterstring(fiscal_year) + ",@BRANCH="+filterstring(branch)+"");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            double[] sum = new double[cols];
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 2 && i < cols)
                    {
                        double currVal;
                        double.TryParse(dr[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    if (i <3)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i >= 3)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>");

                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"3\" align=\"left\"><b>Total</b></td>");
            for (int i = 3; i < cols ; i++)
            {
                str.Append("<td class=\"text-right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
