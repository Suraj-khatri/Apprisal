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
    public partial class DateWiseReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public DateWiseReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            showReport();
        }
        private void showReport()
        {
            string group_id = Request.QueryString["group_id"] == "" ? "null" : Request.QueryString["group_id"].ToString();
            string branch_id = Request.QueryString["branch_id"] == "" ? "null" : Request.QueryString["branch_id"].ToString();
            string type_id = Request.QueryString["type_id"] == "" ? "null" : Request.QueryString["type_id"].ToString();
            string from_date = Request.QueryString["from_date"] == "" ? "null" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == "" ? "null" : Request.QueryString["to_date"].ToString();

            double book_value = 0.00, acc_dep = 0.00, purchase_value = 0.00;

            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [ProcDateWiseRpt] @flag='a',@from_date=" + filterstring(from_date) + ","
                        + " @to_date=" + filterstring(to_date) + ",@group_id=" + filterstring(group_id) + ",@branch_id=" + filterstring(branch_id) + ","
                        + " @type_id="+filterstring(type_id)+"");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Date Wise Asset Report";
            lblBranchName.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch_id + ")");
            lblGroupName.Text = _clsdao.GetSingleresult("SELECT item_name FROM ASSET_ITEM WHERE id=" + group_id + "");
            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 6|| i==7|| i==8)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else if (i == 4|| i==5)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                book_value = book_value + double.Parse(row[8].ToString());
                acc_dep = acc_dep + double.Parse(row[7].ToString());
                purchase_value = purchase_value + double.Parse(row[6].ToString());

            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"6\"><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(purchase_value.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(book_value.ToString()) + "</b></td>");
            str.Append("<td align=\"center\" colspan=\"4\"><b></b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }
    }
}