using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class ListReOrderLevel : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;

        public ListReOrderLevel()
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
            PrintReport();
        }
        private void PrintReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'r', " + filterstring(GetBranchID().ToString()) + "," + filterstring(GetProductID().ToString())+",'null','null'");

            _CompanyCore = _company.FindCompany();
 
            divCompany.InnerText = _CompanyCore.Name;
            getBranchName();
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy"); 
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                if (i<4)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else 
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    if (i<4)
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
