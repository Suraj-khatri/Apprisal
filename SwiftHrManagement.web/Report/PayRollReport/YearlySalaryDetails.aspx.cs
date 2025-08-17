using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.Payrole;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class YearlySalaryDetails : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        payroleDAO _payroll = null;
        clsDAO _clsDao = null;
        public YearlySalaryDetails()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _payroll = new payroleDAO();
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                loadReport();
            }
        }
        private void loadReport()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branch = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            _CompanyCore = _company.FindCompany();
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;
            Lblyear.Text = year;
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");

            DataTable dt = _payroll.Executepayroll("exec [procPayRollReport] 'a'," + filterstring(year) + ","+filterstring(month)+"," + filterstring(branch) + "").Tables[0];
                      
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i<3)
                    {
                        str.Append("<td align=\"left\" width=\"150px\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        if (dr[i].ToString() == "")
                        {
                            str.Append("<td class=\"text-right\" width=\"70px\">0.00</td>");
                        }
                        else
                        {
                            str.Append("<td class=\"text-right\" width=\"70px\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        }
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }       
}

