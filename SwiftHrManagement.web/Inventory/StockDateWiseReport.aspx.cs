using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class StockDateWiseReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public StockDateWiseReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
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
            //else
            //{
                getReport();
            //}
        }
        private string GetProductID()
        {
            return (Request.QueryString["Product"] != null ? (Request.QueryString["Product"]) : "");
        }
        private string GetBranchID()
        {
            return (Request.QueryString["Branch"] != null ? (Request.QueryString["Branch"]) : "");
        }
        private string GetFromDate()
        {
            return (Request.QueryString["From"] != null ? (Request.QueryString["From"]) : "");
        }
        private string GetToDate()
        {
            return (Request.QueryString["To"] != null ? (Request.QueryString["To"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID() != "")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblBranchName.Text = dr["BRANCH_NAME"].ToString();
                }
            }
            else
            {
                lblBranchName.Text = "All Branches";
            }
        }
        private void getReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHandSummaryRpt 'a'," + filterstring(GetFromDate()) + "," + filterstring(GetToDate()) + "," + filterstring(GetBranchID().ToString()) + "," + filterstring(GetProductID().ToString()) + "");

            _CompanyCore = _company.FindCompany();

            this.divCompany.InnerText = _CompanyCore.Name;

            from_date.Text = GetFromDate().ToString();
            to_date.Text = GetToDate().ToString();

            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th colspan=\"3\"><div align=\"center\">PRODUCT DESCRIPTION</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">OPENING STOCK</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">PURCHASED</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">TRANSFERED IN</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">CONSUMED</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">TRANSFERED OUT</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">DISPOSED</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">CLOSING STOCK</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">STOCK IN TRANSIT</div></th>");
            str.Append("</tr>");
            str.Append("<tr>");

            //for (int i = 0; i < cols; i++)
            //{
            //    str.Append("<th><div align=\"LEFT\">" + dt.Columns[i].ColumnName + "</div></th>");                
            //}
            str.Append("<th><div align=\"left\">PROD CODE</div></th>");
            str.Append("<th><div align=\"left\">PRODUCT NAME</div></th>");
            str.Append("<th><div align=\"left\">PACKAGE UNIT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>"); 
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");
            str.Append("<th><div align=\"left\">QTY</div></th>");
            str.Append("<th><div align=\"left\">RATE</div></th>");
            str.Append("<th><div align=\"left\">AMOUNT</div></th>");

            str.Append("</tr>");
            double[] sum = new double[cols];
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 2 && i < cols)
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }

                    if (i ==3 || i == 6 || i == 9 || i ==12 || i==15 || i==18||i==21 || i==24)
                    {
                        str.Append("<td><div align=\"center\">" + row[i].ToString() + "</div></td>");
                    }
                    else if ( i==4 || i==5 || i==7 || i==8 || i==10 || i==11 || i==13 || i==14 || i==16 || i==17 || i==19 || i==20 || i==22||i==23 || i==25 ||i==26)
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(row[i].ToString()) + "</div></td>");
                    }
                    else
                    {
                        str.Append("<td><div align=\"left\">" + row[i].ToString() + "</div></td>");
                    }

                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"3\" align=\"center\"><b>Total</b></td>");
            for (int i = 3; i < cols; i++)
            {
                if (i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i==24)
                {
                    str.Append("<td align=\"center\"><b>" + sum[i].ToString() + "</b></td>");
                }
                else if (i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26)
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
                else
                {
                    str.Append("<td align=\"right\"><b></b></td>");
                }
            }
            str.Append("</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
