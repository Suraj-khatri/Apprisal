using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.Leave.Leave_Incashment
{
    public partial class ExportToExcel : BasePage
    {
        clsDAO _clsdao = null;
        public ExportToExcel()
        {
            this._clsdao = new clsDAO();            
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();           
        }
        void LoadHTML()
        {
            string year = Request.QueryString["bsDate"] == null ? "" : Request.QueryString["bsDate"].ToString();

            DataTable dt = _clsdao.getDataset("exec [procLeaveYearEndReport] " + filterstring(year) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            double[] sum = new double[cols];

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    //if ((i == 5) || (i == 3))
                    //{
                    //    double currVal;
                    //    double.TryParse(dr[i].ToString(), out currVal);
                    //    sum[i] += currVal;
                    //}
                    
                        
                    //if ((i == 5) || (i == 3))
                    //{
                    //    str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    //}
                    //else 
                    //{
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    //}
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            //str.Append("<td colspan = \"3\" align=\"left\"><b>Total</b></td>");
            //for (int i = 3; i <= cols - 1; i++)
            //{
            //    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            //}
            //str.Append("</tr>");

            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}