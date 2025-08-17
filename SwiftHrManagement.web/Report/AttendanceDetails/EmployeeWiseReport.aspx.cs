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
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class EmployeeWiseReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        AttendanceReports _attendance = null;
        clsDAO _clsdao = null;
        string currPage = "";  
        DynamicRpt _rpt = null;
        public EmployeeWiseReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
            this._attendance = new AttendanceReports();

            this._clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            currPage = getCurrPage();          
            loadReport();            
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string empName = Request.QueryString["EmpName"] == null ? "" : Request.QueryString["EmpName"].ToString();
            if (empName == "")
                return;
            lblEmployeeName.Text = _clsdao.GetSingleresult("select FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME 'Empname'  from "
            + " Employee where EMPLOYEE_ID <> '1000' and EMPLOYEE_ID  = " + filterstring(empName) + "");
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            DateFrom.Text = from;
            DateTo.Text = to;
           // Flag = "a";
            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-8 col-md-offset-2\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _attendance.EmpSearch(this.ReadSession().RptQuery).Tables[0];

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {                
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }

            str.Append("</tr>");


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

