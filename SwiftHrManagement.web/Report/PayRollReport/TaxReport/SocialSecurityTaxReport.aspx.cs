using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.TaxReport
{
    public partial class SocialSecurityTaxReport : BasePage
    {
        string currPage = "";
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO CLsDAo = null;

        public SocialSecurityTaxReport()
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
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            
            populateTdsreport();
            lblYear.Text = year;

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-responsive table-bordered table-striped table-condensed text-center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            DataTable dt = CLsDAo.getTable("Exec [procTDSEmployeeWiseReport] @flag='t',@year=" + filterstring(year) + ",@month=" + filterstring(month) + "");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            double _stax = 0.00;
            double _slarytax = 0.00;
            double _totaltax = 0.00;
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
                    if (i == 0 || i == 1 || i==2)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i > 2)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");

                    }
                }
                _stax = _stax + double.Parse(dr[3].ToString());
                _slarytax = _slarytax + double.Parse(dr[4].ToString());
                _totaltax = _totaltax + double.Parse(dr[5].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>" +
                "<td colspan='3' class=\"text-right\"><b>TOTAL:</b></td>" +
                "<td class=\"text-right\"><b>" + ShowDecimal(_stax.ToString()) + "</b></td>" +
                 "<td class=\"text-right\"><b>" + ShowDecimal(_slarytax.ToString()) + "</b></td>" +
                 "<td class=\"text-right\"><b>" + ShowDecimal(_totaltax.ToString()) + "</b></td>" +
                "</tr>");
            
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void populateTdsreport()
        {
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            if (month == "")
            {
                month = "0";

            }
            lblMonthName.Text = CLsDAo.GetSingleresult("select Name from MonthList where Month_Number=" + month + "");

            if (month == "0")
                lblMonthName.Text = "ALL";
        }
    }
}
