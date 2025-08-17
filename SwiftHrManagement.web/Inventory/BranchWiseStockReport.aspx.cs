using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class BranchWiseStockReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public BranchWiseStockReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsdao = new ClsDAOInv();
        }
        private string GetBranchID()
        {
            return (Request.QueryString["branch_id"] != null ? (Request.QueryString["branch_id"]) : "");
        }
        private string GetFromDate()
        {
            return (Request.QueryString["from_date"] != null ? (Request.QueryString["from_date"]) : "");
        }
        private string GetTodate()
        {
            return (Request.QueryString["to_date"] != null ? (Request.QueryString["to_date"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID()!="")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblbranchname.Text = dr["BRANCH_NAME"].ToString();
                }
            }
            else
            {
                lblbranchname.Text = "All Branches";
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
            DataTable dt = _clsdao.getTable("Exec [procStockSummaryRptBranchWise] @flag='a',@branchid=" + filterstring(GetBranchID()) + ",@startdate=" + filterstring(GetFromDate()) + ",@enddate=" + filterstring(GetTodate()) + "");

            _CompanyCore = _company.FindCompany(); 

            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintdate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            lblfromdate.Text = GetFromDate();
            lbltodate.Text = GetTodate();
            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("</tr>");
            double[] sum = new double[cols];

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 2 && i < cols )
                    {
                        double currVal;
                        double.TryParse(row[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    if (i > 2)
                    {
                        str.Append("<td align=\"right\">" +ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"3\" align=\"center\"><b>Total</b></td>");
            for (int i = 3; i < cols; i++)
            {
                str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
