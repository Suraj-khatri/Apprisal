using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Inventory
{
    public partial class InventoryExpensesDateWise : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public InventoryExpensesDateWise()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }
        private string GetFromDate()
        {
            return (Request.QueryString["fromDate"] != null ? (Request.QueryString["fromDate"]) : "");
        }
        private string GetToDate()
        {
            return (Request.QueryString["toDate"] != null ? (Request.QueryString["toDate"]) : "");
        }
        private string getBranchId()
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
            PrintReport();
            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
        }
        private void PrintReport()
        {
            double tot_amount = 0.00;
            double tot_qty = 0;
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'j'," + filterstring(getBranchId()) + ",null," + filterstring(GetFromDate()) + "," + filterstring(GetToDate()) + "");
            lblprintdate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            from_date.Text = GetFromDate();
            to_date.Text = GetToDate();
            if (getBranchId() != "")
            {
                branchname.Text = _clsdao.GetSingleresult("select BRANCH_NAME from Branches where BRANCH_ID=" + getBranchId() + "");
            }
            else
            {
                branchname.Text = "All Branches";
            }

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                if (i>1)
                {
                    str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                tot_amount = tot_amount + Double.Parse(row["AMOUNT"].ToString());
                tot_qty = tot_qty + Double.Parse(row["QTY"].ToString());
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    if (i ==0 || i==2 || i==3)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else if (i > 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"3\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + tot_qty.ToString() + " </b></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(tot_amount.ToString()) + "</b> </td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
