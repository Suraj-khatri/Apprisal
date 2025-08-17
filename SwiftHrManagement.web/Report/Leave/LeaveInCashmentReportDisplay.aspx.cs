using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveInCashmentReportDisplay : BasePage
    {
        DynamicRpt _rpt = null;
        clsDAO _CLsDAo = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        LeaveSummaryReport _leaveSummary = null;

        private string GetBranchId()
        {
            return string.IsNullOrEmpty(Request.QueryString["branchId"]) ? "" : Request.QueryString["branchId"].ToString();
        }
        private string GetDeptId()
        {
            return string.IsNullOrEmpty(Request.QueryString["departmentId"]) ? "" : Request.QueryString["departmentId"].ToString();
        }
        private string GetEmpId()
        {
            return string.IsNullOrEmpty(Request.QueryString["empid"]) ? "" : Request.QueryString["empid"].ToString();
        }
        private string GetReptType()
        {
            return string.IsNullOrEmpty(Request.QueryString["reptType"]) ? "" : Request.QueryString["reptType"].ToString();
        }
        private string GetYear()
        {
            return string.IsNullOrEmpty(Request.QueryString["year"]) ? "" : Request.QueryString["year"].ToString();
        }

        public LeaveInCashmentReportDisplay()
        {
            this._rpt = new DynamicRpt();
            this._CLsDAo = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._leaveSummary = new LeaveSummaryReport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadHeading();
            loadReport();
        }

        private void loadHeading()
        {
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblSubDesc.Text = FillSubDesc(GetBranchId(), GetDeptId(), GetEmpId());
        }

        private string FillSubDesc(string branch, string dept, string emp)
        {
            string subdesc="";
            string sql = "SELECT 'BRANCH NAME' TITLE,BRANCH_NAME [DESC] FROM Branches WHERE BRANCH_ID=" + filterstring(branch)
                         + " UNION ALL"
                         + " SELECT 'DEPARTMENT NAME',DEPARTMENT_NAME FROM Departments WHERE DEPARTMENT_ID ="+filterstring(dept)
                         + " UNION ALL"
                         + " SELECT 'EMPLOYEE NAME',dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID)"
                         + "     FROM EMPLOYEE WHERE EMPLOYEE_ID = " + filterstring(emp);

            DataTable dt = _CLsDAo.getDataset(sql).Tables[0];
            int rows = dt.Rows.Count;

            
            if (rows == 0)
            {
                subdesc = "<br>Branch : All"
                          + "<br>Department : All"
                          + "<br>Employee : All";
            }
            else if (rows == 1)
            {
                subdesc = "<br>Branch : " + dt.Rows[0][1]
                          + "<br>Department : All"
                          + "<br>Employee : All";
            }
            else if (rows == 2)
            {
                subdesc = "<br>Branch : " + dt.Rows[0][1]
                          + "<br>Department : " + dt.Rows[1][1]
                          + "<br>Employee : All";
            }
            else if (rows == 3)
            {
                subdesc = "<br>Branch : " + dt.Rows[0][1]
                          + "<br>Department : " + dt.Rows[1][1]
                          + "<br>Employee : " + dt.Rows[2][1];
            }
            subdesc = subdesc + "<br>Year : " + GetYear();
            if (GetReptType()=="s")
                subdesc = "<br>Leave InCashment Summary Report<br>" + subdesc;
            else
                subdesc = "<br>Leave InCashment Detail Report<br>" + subdesc;

            return subdesc;
        }

        

        private void loadReport()
        {
            string sql;
            //sql = "Exec PROC_LEAVE_INCASHMENT @flag="+filterstring(GetReptType())
            //        + ",@bs_year=" + filterstring(GetYear())
            //        + ",@branchid =" + filterstring(GetBranchId())
            //        + ",@dept=" + filterstring(GetDeptId())
            //        + ",@emp_id=" + filterstring(GetEmpId());
            this.ReadSession().RptQuery = _leaveSummary.FindLeaveIncashmentReport(GetReptType(), GetBranchId(), GetDeptId(), GetEmpId(), GetYear()).ToString();
            sql = ReadSession().RptQuery;

            DataTable dt = _CLsDAo.getDataset(sql).Tables[0];

            StringBuilder str;
            str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
                str.Append("<tr>");
                    int cols = dt.Columns.Count;
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
    }
}
