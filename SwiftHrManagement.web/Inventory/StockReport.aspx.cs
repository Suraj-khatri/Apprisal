using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class StockReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public StockReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetProductID()
        {
            return (Request.QueryString["Product"] != null ? (Request.QueryString["Product"]) : "");
        }
        private string GetBranchID()
        {
            return (Request.QueryString["Branch"] != null ? (Request.QueryString["Branch"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID()!="")
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
            if (GetBranchID() != "")
            {
                getBranchWiseReport();
            }
            else
            {
                getAllBranchReport();
            }
        }
        private void getBranchWiseReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [procStockInHandBranchWise] 'a', " + filterstring(GetBranchID().ToString()) + "," + filterstring(GetProductID().ToString()) + "");

            _CompanyCore = _company.FindCompany(); 

            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  

            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th colspan=\"3\"><div align=\"center\">PRODUCT DESCRIPTION</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">TOTAL PURCHASED REMAIN</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">TRANSFERED IN REMAIN</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">STOCK IN HAND</div></th>");
            str.Append("</tr>");
            str.Append("<tr>");
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

                    if (i == 4 || i == 5 || i == 7 || i == 8 || i == 10 || i == 11)
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(row[i].ToString()) + "</div></td>");
                    }
                    else if (i == 3 || i == 6 || i == 9)
                    {
                        str.Append("<td><div align=\"center\">" + row[i].ToString() + "</div></td>");
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
                if (i == 3 || i == 6 || i == 9)
                {
                    str.Append("<td align=\"center\"><b>" + sum[i].ToString() + "</b></td>");
                }
                else if (i == 5 || i == 8 || i == 11)
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
            rpt.InnerHtml = str.ToString();
        }
        private void getAllBranchReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [procStockInHandBranchWise] 'a', " + filterstring(GetBranchID().ToString()) + "," + filterstring(GetProductID().ToString()) + "");

            _CompanyCore = _company.FindCompany();

            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th colspan=\"4\"><div align=\"center\">PRODUCT DESCRIPTION</div></th>");
            str.Append("<th colspan=\"3\"><div align=\"center\">TOTAL STOCK IN HAND</div></th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th><div align=\"left\">PROD CODE</div></th>");
            str.Append("<th><div align=\"left\">BRANCH NAME</div></th>");
            str.Append("<th><div align=\"left\">PRODUCT NAME</div></th>");
            str.Append("<th><div align=\"left\">PACKAGE UNIT</div></th>");
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

                    if (i == 5 || i == 6)
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(row[i].ToString()) + "</div></td>");
                    }
                    else if (i == 4)
                    {
                        str.Append("<td><div align=\"center\">" + row[i].ToString() + "</div></td>");
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
            for (int i = 4; i < cols; i++)
            {
                if (i == 4)
                {
                    str.Append("<td align=\"center\"><b>" + sum[i].ToString() + "</b></td>");
                }
                else if (i==6)
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
            rpt.InnerHtml = str.ToString();
        }
    }
}
