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
using SwiftHrManagement.DAL.LeaveManagementModule;


namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveSummary : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        LeaveSummaryReport _leaveSummary = null;
        string currPage = "";
        String Flag = "a";
        String Branch_Id = "";
        String Dept_Id = "";   
        DynamicRpt _rpt = null;
        clsDAO _clsDao = null;
        public LeaveSummary()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
            this._leaveSummary = new LeaveSummaryReport();
            _clsDao = new clsDAO();
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
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string branch = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string dept = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string empID = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
           
            string AsDate = Request.QueryString["AsDate"] == null ? "" : Request.QueryString["AsDate"].ToString();
            string flg = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            string sql;
            if (flg == "")
            {
                Report_History.Visible = true;
                Report_Summary.Visible = false;
                this.From_Date.Text = from;
                this.To_Date.Text = to;
                sql = "EXEC ProcLeaveSummaryReport " + filterstring(Flag) + "," + filterstring(branch) + "," +
                      filterstring(dept) + "," + filterstring(empID) + "," + filterstring(from) + "," + filterstring(to) +
                      "";
            }
            else
            {
                Report_Summary.Visible = true;
                Report_History.Visible = false;
                this.From_Date.Text = from;
                this.To_Date.Text = to;
                //this.AsDate.Text = AsDate;
                sql = "EXEC ProcLeaveSummaryReport @flag='i',@datefrom=" + filterstring(from)
                      + ",@dateto=" + filterstring(to);
            }

            Flag = "a";
            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            //DataTable dt = _leaveSummary.FindLeavesummaryReport(this.ReadSession().RptQuery).Tables[0];
            DataTable dt = _clsDao.getDataset(sql).Tables[0];

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

