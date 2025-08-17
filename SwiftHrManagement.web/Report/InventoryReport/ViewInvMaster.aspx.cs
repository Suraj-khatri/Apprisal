using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ViewInvMaster : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public ViewInvMaster()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
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
            loadReport();
        }
        private void loadReport()
        {
            string branchId = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string productId = Request.QueryString["productId"] == null ? "" : Request.QueryString["productId"].ToString();

            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");  

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;

            LblBranchName.Text = _clsdao.GetSingleresult("select dbo.GetBranchName(" + branchId + ")");
            DataTable dt = _clsdao.getTable("Exec [procStockInHand] @flag='br',@Branch=" + filterstring(branchId) + ",@product=" + filterstring(productId) + "");

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                if (i < 4)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    if (i < 4)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
