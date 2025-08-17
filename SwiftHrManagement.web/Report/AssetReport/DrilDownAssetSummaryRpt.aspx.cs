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
    public partial class DrilDownAssetSummaryRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public DrilDownAssetSummaryRpt()
        {
            _company = new CompanyDAO();
            _CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }       
        protected void Page_Load(object sender, EventArgs e)
        {
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _clsdao.getTable("EXEC [ProcDrilDownRpt] @FLAG='b',@BRANCH_ID=" + filterstring(branch) + ",@GROUP_ID=" + filterstring(group) + "");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Asset Detail Report";
            BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            group_name.Text = _clsdao.GetSingleresult("SELECT item_name FROM ASSET_ITEM WHERE id=" + group + "");
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");                 
            }
            str.Append("</tr>");
            double[] sum = new double[cols];
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 3 && i < cols-1)
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    if (i > 3 && i < cols-1)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else if(i==3)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"4\" align=\"center\"><b>Total</b></td>");
            for (int i = 4; i < cols-1; i++)
            {
                str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("<td align=\"left\"></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }
    }
}
