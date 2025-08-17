using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class InventoryExpensesDetailRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public InventoryExpensesDetailRpt()
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
                ShowDetailRpt();
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
        private void ShowDetailRpt()
        {
            double reqQty = 0.00;
            double appQty = 0.00;
            double disQty = 0.00;
            double ackQty = 0.00;

            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec proc_InventoryReqHistory @flag='a',@branchId=" + filterstring(GetBranchID()) + ","
            + " @deptId=" + filterstring(GetDeptID()) + ",@fromDate=" + filterstring(GetFromDate()) + ","
            + " @toDate=" + filterstring(GetToDate()) + ",@productId=" + filterstring(GetProductID()) + ",@fromBranch = " + filterstring(ReadSession().Branch_Id.ToString()) + "");
            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                reqQty = reqQty + Double.Parse(row["Req. Qty"].ToString());
                appQty = appQty + Double.Parse(row["App. Qty"].ToString());
                disQty = disQty + Double.Parse(row["Dis. Qty"].ToString());
                ackQty = ackQty + Double.Parse(row["Ack. Qty"].ToString());

                for (int i = 0; i < cols; i++)
                {
                    if (i > 5 && i < 10)
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    else
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"6\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + reqQty.ToString() + " </b></td>");
            str.Append("<td align=\"center\"><b> " + appQty.ToString() + " </b></td>");
            str.Append("<td align=\"center\"><b> " + disQty.ToString() + " </b></td>");
            str.Append("<td align=\"center\"><b> " + ackQty.ToString() + " </b></td>");
            str.Append("<td></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
