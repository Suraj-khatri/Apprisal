using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class paymentWisePurchaseReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public paymentWisePurchaseReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetFromDate()
        {
            return (Request.QueryString["from_date"] != null ? (Request.QueryString["from_date"]) : "");
        }
        private string GetToDate()
        {
            return (Request.QueryString["to_date"] != null ? (Request.QueryString["to_date"]) : "");
        }
        private string GetBranchId()
        {
            return (Request.QueryString["branch_id"] != null ? (Request.QueryString["branch_id"]) : "");
        }
        private string GetVendorId()
        {
            return (Request.QueryString["vendor_id"] != null ? (Request.QueryString["vendor_id"]) : "");
        }
        private string GetPaymentStatus()
        {
            return (Request.QueryString["status"] != null ? (Request.QueryString["status"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchId() != "")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchId() + "'").Tables[0];

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
        private void getVendorName()
        {
            if (GetVendorId() != "")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("SELECT CustomerName FROM Customer where ID='" + GetVendorId() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblVendorName.Text = dr["CustomerName"].ToString();
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
            PrintReport();
        }
        private void PrintReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec [procRptPaymentWisePurchase] @flag='a',@from_date=" + filterstring(GetFromDate()) + ",@to_date="+filterstring(GetToDate())+","
            + " @branch_id=" + filterstring(GetBranchId()) + ",@vendor_id=" + filterstring(GetVendorId()) + ",@status="+filterstring(GetPaymentStatus())+"");

            _CompanyCore = _company.FindCompany();
 
            divCompany.InnerText = _CompanyCore.Name;
            getBranchName();
            getVendorName();
            lblFromDate.Text = GetFromDate();
            lblTodate.Text = GetToDate();
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy"); 
            int cols = dt.Columns.Count;
            double totAmt = 0.00, totVat = 0.00;
            str.Append("<tr>");
            
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("<th align=\"left\"></th>");  
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    if (i==2||i==8||i==10)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 4 || i == 5)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><a href='../Voucher/purchase_invoice.aspx?bill_id="+row["bill_id"]+"'>View Invoice</a></td>");
                str.Append("</tr>");
                totAmt = totAmt + double.Parse(row["Bill Amount"].ToString());
                totVat = totVat + double.Parse(row["Vat Amount"].ToString());
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan='3'><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>"+ShowDecimal(totVat.ToString())+"</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(totAmt.ToString()) + "</b></td>");
            str.Append("<td align=\"center\" colspan='5'><b></b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
