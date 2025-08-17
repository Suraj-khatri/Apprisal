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

namespace SwiftHrManagement.web.Report.AppraisalSummary
{
    public partial class ViewAppraisalReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalReportDao _arDao = new AppraisalReportDao();
        public ViewAppraisalReport()
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
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 101) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                loadReport();
            }
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string branch_id = Request.QueryString["branch_id"] == null ? "" : Request.QueryString["branch_id"].ToString();
            string from_date = Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
            string department_id = Request.QueryString["department_id"] == null ? "" : Request.QueryString["department_id"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            From_Date.Text = from_date;
            To_Date.Text = to_date;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = new DataTable();
            //if (emp_id == "")
            //{
            dt = _arDao.GetBranchReport(branch_id, department_id, emp_id, from_date, to_date);
            //}
            //else
            //{
            //    dt = _arDao.GetEmployeeReport(branch_id,emp_id,from_date,to_date);
            //}

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                if (i >= 1 && i < 7)
                {
                    str.Append("<th align=\"left\" rowspan=\"2\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            //str.Append("<th align=\"center\" colspan=\"4\"> Rating </th>");
            str.Append("<th align=\"left\" colspan=\"3\">Appraisal</th>"); //
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 1; i < cols; i++)
            {
                if (i >= 7 && i <= 12)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th>Detail</th>");
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
                    else if(i>=7 && i<=12)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><a href=\"ViewAppraisal.aspx?appraisalId=" + dr["ID"].ToString() + "&employeeId=" + dr["Employee Id"].ToString() + "\">View</a></td>");
                str.Append("</tr>");

            }
            str.Append("</table></div>");
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

