using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class DarRpt : BasePage
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowReport();
        }
        #region
        //made by bibhut
        public string ShowrptExcel(string from, string to, string emp_id)
        {
            return "EXEC [ProcSupervisorSummaryRpt] @FLAG='D',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" +
                   filterstring(to) + ","
                   + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" +
                   filterstring(emp_id);
        }
        #endregion
        private void ShowReport()
        {
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();

            lblToDate.Text = to;
            lblFromDate.Text = from;
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;


            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [ProcSupervisorSummaryRpt] @FLAG='D',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id) + "");

            int sn = 0;
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th align=\"left\">SN</th>");
            for (int i = 0; i < cols; i++)
            {
                if (i >= 0 && i < 10)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th align=\"left\"> View </th>");
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"center\">" + (++sn) + "</td>");
                for (int i = 0; i < 10; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\"><a target='_blank' href='/doc/DailyActivity/" + dr["FileId"].ToString() + "." + dr["Ext"].ToString() + "'> View File</a></td>");
                str.Append("</tr>");
            }

            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
