using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class userWiseRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;

        private string branchId = "";
        private string deptName = "";
        private string deptId = "";
        private string productId = "";
        private string fromDate = "";
        private string toDate = "";
        private string branchName = "";

        public userWiseRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsdao = new ClsDAOInv();
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
                ShowBranchWiseRpt();
            }
        }
        private void ShowBranchWiseRpt()
        {
            branchId = ReadQueryString("branchId", "").ToLower();
            deptName = ReadQueryString("deptName", "").ToLower();
            deptId = ReadQueryString("deptId", "").ToLower();
            productId = ReadQueryString("productId", "").ToLower();
            fromDate = ReadQueryString("fromDate", "").ToLower();
            toDate = ReadQueryString("toDate", "").ToLower();
            branchName = ReadQueryString("branchName", "").ToLower();

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblFromDate.Text = fromDate;
            lblToDate.Text = toDate;
            lblBranchName.Text = branchName;
            lblDeptName.Text = deptName;


            var ds = _clsdao.getDataset("exec procStockDepartWiseRpt @flag='D',@branch_id=" + filterstring(branchId) + ","
            + " @dept_id=" + filterstring(deptId) + ",@from_date=" + filterstring(fromDate) + ","
            + " @to_date=" + filterstring(toDate) + ",@product_id=" + filterstring(productId) + "");

            var dtHead = ds.Tables[0];
            var dt = ds.Tables[1];

            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"2\" cellspacing=\"2\" align=\"center\">");
            str.Append("<tr>");
            str.AppendLine("<th>S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.AppendLine("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.AppendLine("</tr>");

            double[] total = new double[9];

            foreach (DataRow dr in dtHead.Rows)
            {
                str.AppendLine(PrintRegionBody(ref dt, dr[0].ToString(), ref total));
            }

            str.Append("<tr>");
            str.Append("<td colspan = '5'><center><b>Grand Total</b></center></td>");

            for (int i = 5; i < 9; i++)
            {
                if ( i == 8)
                    str.Append("<td align = 'right'><b>" + ShowDecimal(total[i]) + "</b></td>");
                else if(i == 5 || i == 6)
                    str.Append("<td align = 'center'><b>" + total[i] + "</b></td>");
                else
                    str.Append("<td align = 'right'>&nbsp;</td>");
            }
            str.Append("</tr>");
            rpt.InnerHtml = str.ToString();
        }

        private string PrintRegionBody(ref DataTable dt, string regionName, ref Double[] total)
        {
            double[] subTotal = new double[9];
            DataRow[] rows = dt.Select("HEAD='" + regionName + "'");

            var html = new StringBuilder();
            html.Append("<tr>");
            html.Append("<td colspan='5'><b>" + regionName + "</b></td>");
            html.Append("</tr>");
            int bag_sno = 0;
            foreach (DataRow dr in rows)
            {
                for (int i = 5; i < 9; i++)
                {
                    var data = ParseDouble(dr[i].ToString());
                    subTotal[i] += data;
                    total[i] += data;
                }
                html.Append("<tr>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\" nowrap='nowrap'>" + (++bag_sno) + "</td>");

                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + dr["Requested Date"].ToString() + "</td>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + dr["Dispatched Date"].ToString() + "</td>");

                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + dr["Prod Code"].ToString() + "</td>");
                html.Append("<td align=\"left\" style=\"border=\"0\";\" nowrap='nowrap'>" + dr["Product Name"] + "</td>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + (ParseDouble(dr["Requested QTY"].ToString())) + "</td>");
                html.Append("<td align=\"center\" style=\"border=\"0\";\">" + (ParseDouble(dr["QTY"].ToString())) + "</td>");
                html.Append("<td align=\"right\" style=\"border=\"0\";\">" + ShowDecimal(ParseDouble(dr["RATE"].ToString())) + "</td>");
                html.Append("<td align=\"right\" style=\"border=\"0\";\">" + ShowDecimal(dr["AMOUNT"].ToString()) + "</td>");
                html.Append("</tr>");
            }

            html.Append("<tr>");
            html.Append("<td colspan = '5'><center><b>Sub Total</b></center></td>");

            for (int i = 5; i < 9; i++)
            {
                if (i == 8)
                    html.Append("<td align = 'right'><b>" + ShowDecimal(subTotal[i]) + "</b></td>");
                else if (i == 5 || i == 6)
                    html.Append("<td align = 'center'><b>" + subTotal[i] + "</b></td>");
                else
                    html.Append("<td align = 'right'>&nbsp;</td>");
            }

            html.Append("</tr>");
            return html.ToString();
        }

    }
}
