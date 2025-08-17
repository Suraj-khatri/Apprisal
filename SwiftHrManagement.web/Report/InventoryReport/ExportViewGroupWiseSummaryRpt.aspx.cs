using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ExportViewGroupWiseSummaryRpt : BasePage
    {
        ClsDAOInv _clsdao = null;
        public ExportViewGroupWiseSummaryRpt()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string from_date = Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
            string branchid = Request.QueryString["branch_id"] == null ? "" : Request.QueryString["branch_id"].ToString();
            string ProductGroup = Request.QueryString["group_id"] == null ? "" : Request.QueryString["group_id"].ToString();
            string ProductName = Request.QueryString["product_id"] == null ? "" : Request.QueryString["product_id"].ToString();
            
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            
            DataTable dt = _clsdao.getTable("Exec [procStockInHandGroupWise] @flag='s',@BRANCH_ID=" + filterstring(branchid) + ""
            + ",@GROUP_ID=" + filterstring(ProductGroup) + ",@PRODUCT_ID=" + filterstring(ProductName) + ",@FROM_DATE=" + filterstring(from_date) + ""
            + " ,@TO_DATE=" + filterstring(to_date) + "");

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
                for (int i = 0; i < cols; i++)
                {
                    if (i > 2 && i < cols)
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }

                    if (i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                    {
                        str.Append("<td><div align=\"center\">" + row[i].ToString() + "</div></td>");
                    }
                    else if (i == 4 || i == 5 || i == 7 || i == 8 || i == 10 || i == 11 || i == 13 || i == 14 || i == 16 || i == 17 || i == 19 || i == 20 || i == 22 || i == 23)
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
                if (i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                {
                    str.Append("<td align=\"center\"><b>" + sum[i].ToString() + "</b></td>");
                }
                else if (i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23)
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
                else
                {
                    str.Append("<td align=\"right\"><b></b></td>");
                }
            }
            str.Append("</tr>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
