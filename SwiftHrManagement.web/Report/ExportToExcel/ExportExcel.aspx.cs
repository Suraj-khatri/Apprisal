using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.ExportToExcel
{
    public partial class ExportExcel : BasePage
    {
        clsDAO _clsdao=new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder("<table border=\"1\" class=\"TBL\">");
            DataTable dt = _clsdao.getTable(this.ReadSession().RptQuery);

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
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