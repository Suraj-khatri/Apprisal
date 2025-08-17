using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report
{
    public partial class CompanyDynamicReport : BasePage
    {
        DynamicRpt _rpt = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        string sql = "";

        public CompanyDynamicReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._rpt = new DynamicRpt();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

                DataTable dt = _rpt.runSql(this.ReadSession().RptQuery);

                _CompanyCore = _company.FindCompany();

                this.lblHeading.Text = _CompanyCore.Name;
                this.lbldesc.Text = _CompanyCore.Address;

                int cols = dt.Columns.Count;
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                    str.Append("</tr>");
                }
                str.Append("</table></div>");
                rptDiv.InnerHtml = str.ToString();
        }
    }
}
