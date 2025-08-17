using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class AppraisalRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalReportDao _arDao = new AppraisalReportDao();
        public AppraisalRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (_roleMenuDao.hasAccess(ReadSession().AdminId, 101) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}
                loadReport();
            }
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        #region
        public string loadAprRptExcel(string from,string to,string emp_id)
        {
            return "EXEC [ProcSupervisorSummaryRpt] @FLAG='APP',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" +
                   filterstring(to) + ","
                   + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" +
                   filterstring(emp_id);
        }

        #endregion
        private void loadReport()
        {
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();


            From_Date.Text = from;
            To_Date.Text = to;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [ProcSupervisorSummaryRpt] @FLAG='APP',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id) + "");
            

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                if (i >= 1 && i < 7)
                {
                    str.Append("<th align=\"left\" rowspan=\"2\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th align=\"center\" colspan=\"4\"> Rating </th>");
            str.Append("<th align=\"left\" rowspan=\"2\">Appraisal</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 1; i < cols; i++)
            {
                if (i >= 7 && i <= 10)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    if (i >= 1 && i < 7)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i>=7 && i<=10)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><a href=\"../AppraisalSummary/ViewAppraisal.aspx?appraisalId=" + dr["ID"].ToString() + "&employeeId=" + dr["EMPLOYEE_ID"].ToString() + "\">View</a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
        }
    }

