using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class branch_group_summary_rpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public branch_group_summary_rpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetFromDate()
        {
            return (Request.QueryString["fromDate"] != null ? (Request.QueryString["fromDate"]) : "");
        }
        private string GetToDate()
        {
            return (Request.QueryString["toDate"] != null ? (Request.QueryString["toDate"]) : "");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string mode = ReadQueryString("mode", "").ToLower();
            if (mode == "download")
            {
                string format = "xls";
                string reportName = "STOCK";
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "inline; filename=" + reportName + "." + format);
                exportDiv.Visible = false;
            }
            Report();
        }

        private void Report()
        {
            double tot_amount = 0.00;
            StringBuilder str = new StringBuilder("<table class=\"TBL\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [ProcStockExpensesSummaryRpt] @flag='a',@from_date=" + filterstring(GetFromDate().ToString()) + ",@to_date=" + filterstring(GetToDate().ToString()) + "");

            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;     
       
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            lblBranchName.Text = "All Branches";
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            double[] sum = new double[cols];
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("<th><div align=\"left\">Total</div></th>"); 
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                double tot = 0.00;
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0 && i < cols)
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }     
                    if (i >0)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        tot = tot + double.Parse(row[i].ToString());
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"right\"><b>" + ShowDecimal(tot.ToString()) + "</b></td>");
                str.Append("</tr>");
                tot_amount = tot_amount + double.Parse(row[2].ToString());
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\"><b>Total</b></td>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("<td align=\"right\"><b></b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
