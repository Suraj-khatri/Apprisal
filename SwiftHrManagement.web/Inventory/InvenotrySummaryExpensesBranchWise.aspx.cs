using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class InvenotrySummaryExpensesBranchWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public InvenotrySummaryExpensesBranchWise()
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
        private string GetBranchID()
        {
            return (Request.QueryString["branch"] != null ? (Request.QueryString["branch"]) : "");
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
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'x', " + filterstring(GetBranchID().ToString()) + ",null," + filterstring(GetFromDate().ToString()) + "," + filterstring(GetToDate().ToString()) + "");

            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;     
       
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblBranchName.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + filterstring(GetBranchID()) + ")");

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
                    if (i >1)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                tot_amount = tot_amount + double.Parse(row[2].ToString());
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"2\" align=\"center\"><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(tot_amount.ToString()) + "</b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
