using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport.empDetails
{
    public partial class ExcelList : BasePage
    {

        clsDAO _clsdao = null;

        public ExcelList()
        {
            this._clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();
        }
        private string GetBranchID()
        {
            return (Request.QueryString["branch"] != "" ? (Request.QueryString["branch"].ToString()) : "");
        }
        private string GetDeptID()
        {
            return (Request.QueryString["dept"] != "" ? (Request.QueryString["dept"].ToString()) : "");
        }
        private string GetEmpID()
        {
            return (Request.QueryString["emp"] != "" ? (Request.QueryString["emp"].ToString()) : "");
        }
        void LoadHTML()
        {
            StringBuilder str = new StringBuilder("<table border='1'>");


            DataTable dt = _clsdao.getTable("Exec ProcGetEmpDetails 's',"+filterstring(GetBranchID().ToString())+","
            +" "+filterstring(GetDeptID().ToString())+","+filterstring(GetDeptID().ToString())+"");

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
            str.Append("<th> Amount</th>");

            str.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }

                str.Append("<td> </td>");
                str.Append("</tr>");
            }

           
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

          

        }
    }
}
