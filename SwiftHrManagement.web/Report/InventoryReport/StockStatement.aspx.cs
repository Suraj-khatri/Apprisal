using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class StockStatement : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public StockStatement()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string from_date = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string to_date = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string productId = Request.QueryString["productId"] == null ? "" : Request.QueryString["productId"].ToString();

            LblBranchName.Text = _clsdao.GetSingleresult("select branch_name as branch from branches where branch_id=" + branchid + "");


            lblProductName.Text = _clsdao.GetSingleresult("select PORDUCT_CODE from IN_PRODUCT where id=" + productId + "");

            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");

            DataTable dt = _clsdao.getTable("Exec [procStockStatement] @flag='a',@branchid=" + filterstring(branchid) + ""
            + ",@product_id=" + filterstring(productId) + ",@startdate=" + filterstring(from_date) + ",@enddate=" + filterstring(to_date) + "");
      

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th colspan=\"3\"><div align=\"center\">NARRATION</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">OPENING STOCK</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">PURCHASED</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">TRANSFERED IN</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">CONSUMED</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">TRANSFERED OUT</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">DISPOSED</div></th>");
            str.Append("<th colspan=\"2\"><div align=\"center\">CLOSING STOCK</div></th>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<th><div align=\"left\">S.N.</div></th>");
            str.Append("<th><div align=\"left\">DATE</div></th>");
            str.Append("<th><div align=\"left\">NARRATION</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");

            str.Append("</tr>");
            
            double totAmt = 0.00;
            int totQty = 0;
            double[] sum = new double[cols];
            foreach (DataRow row in dt.Rows)
            {
                totAmt = totAmt + double.Parse(row["Amount Opening"].ToString()) + double.Parse(row["Amount Purchase"].ToString()) + double.Parse(row["Amount Transfer In"].ToString()) -
                        double.Parse(row["Amount Consumed"].ToString()) - double.Parse(row["Amount Transfered Out"].ToString()) - double.Parse(row["Amount Disposed"].ToString());
                totQty = totQty + int.Parse(row["Qty Opening"].ToString()) + int.Parse(row["Qty Purchase"].ToString()) + int.Parse(row["Qty Transfer In"].ToString()) -
                        int.Parse(row["Qty Consumed"].ToString()) - int.Parse(row["Qty Transfer Out"].ToString()) - int.Parse(row["Qty Disposed"].ToString());

                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    if (i > 2 && i < cols)
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }

                    if (i==0||i==1||i == 3 || i == 5 || i == 7 || i == 9 || i == 11 || i == 13)
                    {
                        str.Append("<td><div align=\"center\">" + row[i].ToString() + "</div></td>");
                    }
                    else if (i == 4 || i == 6 || i == 8 || i == 10 || i == 12 || i == 14)
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(row[i].ToString()) + "</div></td>");
                    }
                    else 
                    {
                        str.Append("<td><div align=\"left\">" + (row[i].ToString()) + "</div></td>");
                    }
                }
                str.Append("<td><div align=\"center\">" + totQty.ToString() + "</div></td>");
                str.Append("<td><div align=\"right\">" + ShowDecimal(totAmt.ToString()) + "</div></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"3\" align=\"center\"><b>Total</b></td>");
            for (int i = 3; i < cols; i++)
            {
                if (i == 3 || i == 5|| i == 7 || i == 9 || i == 11 || i == 13 )
                {
                    str.Append("<td align=\"center\"><b>" + sum[i].ToString() + "</b></td>");
                }
                else if (i == 4 || i == 6|| i == 8 || i == 10|| i == 12 || i == 14 )
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
            }
            str.Append("<td align=\"right\"><b></b></td>");
            str.Append("<td align=\"right\"><b></b></td>");
            str.Append("</tr></table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
