using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.BranchReport
{
    public partial class LeaveRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public LeaveRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
                if (flag == "d")
                {
                    loadDetailedRpt();
                }
                else
                {
                    loadReport();
                }
            }
        }

        private void loadDetailedRpt()
        {
            StaticPage sPage = new StaticPage();
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();


            lblFromDate.Text = from;
            lblToDate.Text = to;
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;


            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [ProcBranchSummaryRpt] @FLAG='LD',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        #region
        //done by bibhut
        public string LoadReportExcel(string from , string to,string emp_id)
        {
            
            return "EXEC [ProcBranchSummaryRpt] @FLAG='L',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id);
        }

        public  string  loadDetailedRptExcel(string from , string to,string emp_id)
        {
            return "EXEC [ProcBranchSummaryRpt] @FLAG='LD',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id);

        }
        #endregion

        private void loadReport()
        {
            StaticPage sPage = new StaticPage();
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();


            lblFromDate.Text = from;
            lblToDate.Text = to;
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;


            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [ProcBranchSummaryRpt] @FLAG='L',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 3)
                    {
                        str.Append("<td><div align=\"center\">" + dr[i].ToString() + "</div></td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}