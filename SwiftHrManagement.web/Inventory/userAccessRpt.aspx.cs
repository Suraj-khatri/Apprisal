using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class userAccessRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;

        public userAccessRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetUserType()
        {
            return (Request.QueryString["userType"] != null ? (Request.QueryString["userType"]) : "");
        }
        private string GetUserName()
        {
            return (Request.QueryString["userName"] != null ? (Request.QueryString["userName"]) : "");
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
            DataTable dt = _clsdao.getTable("Exec proc_datewiseMonthlyReport @flag='D',@userName=" + filterstring(GetUserName()) + ",@userType=" + filterstring(GetUserType()) + "");

            _CompanyCore = _company.FindCompany();
 
            divCompany.InnerText = _CompanyCore.Name;

            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy"); 
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }


    }
}
