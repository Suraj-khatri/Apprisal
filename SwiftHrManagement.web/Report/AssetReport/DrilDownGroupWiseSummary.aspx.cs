using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class DrilDownGroupWiseSummary : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public DrilDownGroupWiseSummary()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();

            string check = _clsdao.GetSingleresult("EXEC [ProcDrilDownRpt] @FLAG='c',@BRANCH_ID=" + filterstring(branch) + ",@GROUP_ID=" + filterstring(group) + "");
            if (check == "1")
            {
                DataTable dt = _clsdao.getTable("EXEC [ProcDrilDownRpt] @FLAG='a',@BRANCH_ID=" + filterstring(branch) + ",@GROUP_ID=" + filterstring(group) + "");
                StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

                _CompanyCore = _company.FindCompany();
                divCompany.InnerText = _CompanyCore.Name;
                rptDes.Text = "Report Under Group: " + _clsdao.GetSingleresult("SELECT item_name FROM ASSET_ITEM WHERE id=" + group + "");
                BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
                lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                int cols = dt.Columns.Count;

                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                str.Append("</tr>");
                double[] sum = new double[cols];

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        if (i > 1 && i < cols)
                        {
                            double currVal;
                            double.TryParse(row[i].ToString(), out currVal);
                            sum[i] += currVal;
                        }
                        if (i == 1)
                        {
                            str.Append("<td align=\"left\"><a href=\"DrilDownGroupWiseSummary.aspx?branch=" + branch + "&group=" + row[0].ToString() + "\">" + row[i].ToString() + "</a></td>");
                        }
                        else
                        {
                            str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\"><b>Total</b></td>");
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
                str.Append("</tr>");
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
            else
            {
                Response.Redirect("DrilDownAssetSummaryRpt.aspx?branch=" + branch + "&group=" + group + "");
            }
        }
    }
}
