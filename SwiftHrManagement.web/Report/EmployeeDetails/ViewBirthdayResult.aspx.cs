using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;


namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class ViewBirthdayResult : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public ViewBirthdayResult()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string from_date = Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();

            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-8 col-md-offset-2\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            lblHeading.Text = _company.FindCompany().ToString();

            DataTable dt = _clsdao.getTable("Exec procGetBirthdayList @FLAG='A',@FROM_DATE=" + filterstring(from_date) + ",@TO_DATE=" + filterstring(to_date) + "");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
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
                    if (i == 3)
                    {
                        str.Append("<td align=\"CENTER\">" + dr[i].ToString() + "</td>");
                    }
                    else 
                    {
                        str.Append("<td align=\"LEFT\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
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
