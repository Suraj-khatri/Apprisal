using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class InventoryStockExpenses : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public InventoryStockExpenses()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsdao = new ClsDAOInv();
        }
        private string GetProductID()
        {
            return (Request.QueryString["Product"] != null ? (Request.QueryString["Product"]) : "");
        }
        private string GetBranchID()
        {
            return (Request.QueryString["Branch"] != null ? (Request.QueryString["Branch"]) : "");
        }
        private string GetDeptID()
        {
            return (Request.QueryString["Dept"] != null ? (Request.QueryString["Dept"]) : "");
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
            if (!IsPostBack)
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
                ReportHeader();

                if (GetProductID() == "")
                {
                    ShowBranchWiseRpt();
                }
                else
                {
                    ShowProductWiseRpt();
                }
            }
        }
        private void ReportHeader()
        {
            this._CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblFromDate.Text = GetFromDate();
            lblToDate.Text = GetToDate();
        }
        private void ShowProductWiseRpt()
        {
            double tot_amount = 0.00;
            double tot_qty = 0;
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("exec procStockDepartWiseRpt @flag='b',@branch_id=" + filterstring(GetBranchID()) + ","
            + " @dept_id=" + filterstring(GetDeptID()) + ",@from_date=" + filterstring(GetFromDate()) + ","
            + " @to_date=" + filterstring(GetToDate()) + ",@product_id=" + filterstring(GetProductID()) + "");
            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(row["Amount"].ToString());
                tot_qty = tot_qty + Double.Parse(row["QTY"].ToString());

                for (int i = 0; i < cols; i++)
                {
                    if (i == 6 || i == 7)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else if (i == 0 || i == 3 || i == 5)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }

                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"5\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + tot_qty.ToString() + " </b></td>");

            str.Append("<td>&nbsp;</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(tot_amount.ToString()) + "</b> </td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }

        private void ShowBranchWiseRpt()
        {

            var ds = _clsdao.getDataset("exec procStockDepartWiseRpt @flag='a',@branch_id=" + filterstring(GetBranchID()) + ","
            + " @dept_id=" + filterstring(GetDeptID()) + ",@from_date=" + filterstring(GetFromDate()) + ","
            + " @to_date=" + filterstring(GetToDate()) + ",@product_id=" + filterstring(GetProductID()) + "");

            var dtHead = ds.Tables[0];
            var dt = ds.Tables[1];

            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"2\" cellspacing=\"2\" align=\"center\">");
            str.Append("<tr>");
            str.AppendLine("<th>S.N.</th>");
            for (int i = 2; i < cols; i++)
            {
                str.AppendLine("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.AppendLine("</tr>");

            double[] total = new double[7];

            foreach (DataRow dr in dtHead.Rows)
            {
                str.AppendLine(PrintRegionBody(ref dt, dr[0].ToString(),dr[1].ToString(), ref total));
            }

            str.Append("<tr>");
            str.Append("<td colspan = '3'><center><b>Grand Total</b></center></td>");

            for (int i = 4; i < 7; i++)
            {
                if (i == 6)
                {
                    str.Append("<td align = 'right'><b>" + ShowDecimal(total[i]) + "</b></td>");
                }
                else if (i == 4)
                {
                    str.Append("<td align = 'center'><b>" + total[i] + "</b></td>");
                }
                else
                    str.Append("<td align = 'right'>&nbsp;</td>");
            }

            str.Append("</tr>");

            rpt.InnerHtml = str.ToString();
        }

        private string PrintRegionBody(ref DataTable dt, string regionName,string branchId, ref Double[] total)
        {
            double[] subTotal = new double[7];
            DataRow[] rows = dt.Select("HEAD='" + regionName + "'");
            var html = new StringBuilder();


            html.Append("<tr>");
            html.Append("<td colspan='5'><b><a href='#' onclick=\"OpenInNewWindow('deptWiseExp.aspx?branchId=" + branchId + "&fromDate=" + GetFromDate() + "&toDate=" + GetToDate() + "&branchName=" + regionName + "')\">" + regionName + "</a></b></td>");
            html.Append("</tr>");
            int bag_sno = 0;
            foreach (DataRow dr in rows)
            {
                for (int i = 4; i < 7; i++)
                {
                    var data = ParseDouble(dr[i].ToString());
                    subTotal[i] += data;
                    total[i] += data;
                }
                html.Append("<tr>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\" nowrap='nowrap'>" + (++bag_sno).ToString() + "</td>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + (ParseDouble(dr["Prod Code"].ToString())) + "</td>");
                html.Append("<td align=\"left\" style=\"border=\"0\";\" nowrap='nowrap'>" + dr["Product Name"].ToString() + "</td>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + (ParseDouble(dr["QTY"].ToString())) + "</td>");
                html.Append("<td align=\"right\" style=\"border=\"0\";\">" + (ParseDouble(dr["RATE"].ToString())) + "</td>");
                html.Append("<td align=\"right\" style=\"border=\"0\";\">" + ShowDecimal(dr["AMOUNT"].ToString()) + "</td>");
                html.Append("</tr>");
            }

            html.Append("<tr>");
            html.Append("<td colspan = '3'><center><b>Sub Total</b></center></td>");

            for (int i = 4; i < 7; i++)
            {
                if (i == 6)
                {
                    html.Append("<td align = 'right'><b>" + ShowDecimal(subTotal[i]) + "</b></td>");
                }
                else if (i == 4)
                {
                    html.Append("<td align = 'center'><b>" + subTotal[i] + "</b></td>");
                }
                else
                    html.Append("<td align = 'right'>&nbsp;</td>");
            }

            html.Append("</tr>");
            return html.ToString();
        }
    }
}
