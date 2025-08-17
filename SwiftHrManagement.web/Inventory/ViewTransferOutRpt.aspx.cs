using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class ViewTransferOutRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public ViewTransferOutRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsdao = new ClsDAOInv();
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
            getReport();
        }
        private string GetFromDate()
        {
            return (Request.QueryString["fromDate"] != null ? (Request.QueryString["fromDate"]) : "");
        }
        private string GetToDate()
        {
            return (Request.QueryString["toDate"] != null ? (Request.QueryString["toDate"]) : "");
        }
        private void getReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand @flag='z',@from=" + filterstring(GetFromDate().ToString()) + ",@to=" + filterstring(GetToDate().ToString()) + "");

            _CompanyCore = _company.FindCompany();

            this.divCompany.InnerText = _CompanyCore.Name;

            from_date.Text = GetFromDate().ToString();
            to_date.Text = GetToDate().ToString();
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            double tot_amount = 0.00;
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
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                tot_amount = tot_amount + double.Parse(row[3].ToString());
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"center\"><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(tot_amount.ToString()) + "</b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
