using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class PumoriExcelList : BasePage
    { 
        clsDAO _clsdao = null;

        public PumoriExcelList()
        {
            this._clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();
        }
        void LoadHTML()
        {
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branchID = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string deptID = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

           
            StringBuilder str = new StringBuilder("<table border='1'>");


            DataTable dt = _clsdao.getTable("Exec [procSalarysheetupload_trail] 'a'," + filterstring(year) + ","
            + " " + filterstring(month) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                if (i == 0)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
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
