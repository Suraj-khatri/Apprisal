using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;


namespace SwiftHrManagement.web.Inventory
{
    public partial class disposalRpt : BasePage
    {
        private readonly CompanyDAO _company = new CompanyDAO();
        private CompanyCore _companyCore = new CompanyCore();
        private readonly ClsDAOInv _clsdao = new ClsDAOInv();
        private string GetFromDate()
        {
            return (Request.QueryString["fromDate"] != null ? (Request.QueryString["fromDate"]) : "");
        }
        private string GetTodate()
        {
            return (Request.QueryString["toDate"] != null ? (Request.QueryString["toDate"]) : "");
        }
        private string GetProductId()
        {
            return (Request.QueryString["productId"] != null ? (Request.QueryString["productId"]) : "");
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
            PrintReport();
        }
        private void PrintReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [proc_stockDisposalRpt] @flag='a',@fromDate=" + filterstring(GetFromDate()) + ",@toDate=" + filterstring(GetTodate()) + ",@productId =" + filterstring(GetProductId()) + "");

            _companyCore = _company.FindCompany();

            this.divCompany.InnerText = _companyCore.Name;
            lblprintdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblfromdate.Text = GetFromDate();
            lbltodate.Text = GetTodate();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            double qty = 0.00, amount = 0.00;
            str.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 4)
                        str.Append("<td align=\"right\">" +ShowDecimal(row[i].ToString()) + "</td>");
                    else if(i == 2)
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    else
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }
                str.Append("</tr>");
                qty = qty + double.Parse(row["Qty"].ToString());
                amount = amount + double.Parse(row["Amount"].ToString());
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"2\" align=\"center\"><b>Total</b></td>");
            str.Append("<td align=\"center\"><b>" + qty.ToString() + "</b></td>");
            str.Append("<td align=\"center\"></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(amount.ToString()) + "</b></td>");
            str.Append("<td></td>");
            str.Append("<td></td>");
            str.Append("<td></td>");
            str.Append("<td></td>");
            str.Append("<td></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
