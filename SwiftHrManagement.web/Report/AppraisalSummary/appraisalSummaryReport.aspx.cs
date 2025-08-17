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
    public partial class appraisalSummaryReport : BasePage
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        AppraisalReportDao _arDao = new AppraisalReportDao();
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
   
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
            //string employee = Request.QueryString["Employee Name"] == null ? "" : Request.QueryString["Employee Name"].ToString();
            string branch_id = Request.QueryString["branch_id"] == null ? "" : Request.QueryString["branch_id"].ToString();
            string from_date = Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
            string department_id = Request.QueryString["department_id"] == null ? "" : Request.QueryString["department_id"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            From_Date.Text = from_date;
            To_Date.Text = to_date;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = new DataTable();
           
            dt = _arDao.GetAppraisalSummaryReport(branch_id, department_id, emp_id, from_date, to_date);
            
            int a = 1;
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\" rowspan=\"2\">SN</th>");
            for (int i = 0; i < cols; i++)
            {
                if (i >= 0 && i < 12)
                {
                    str.Append("<th align=\"left\" rowspan=\"2\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
          
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 1; i < cols; i++)
            {
                if (i >= 12 && i <= 20)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + a + "</td>");
                for (int i = 0; i < cols; i++)
                {                    
                    if (i >= 0 && i < 12)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i>=12 && i<=20)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                }
                //str.Append("<td align=\"left\"><a href=\"ViewAppraisal. aspx?appraisalId=" + dr["ID"].ToString() + "&employeeId=" + dr["Employee Id"].ToString() + "\">View</a></td>");
                str.Append("</tr>");
                a = a + 1;
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
