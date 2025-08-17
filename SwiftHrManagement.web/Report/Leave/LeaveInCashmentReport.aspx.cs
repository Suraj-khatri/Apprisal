using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveInCashmentReport : BasePage
    {
        clsDAO CLsDAo = null;
        LeaveSummaryReport _leaveSummary = null;
        private char _stop='N';
        public LeaveInCashmentReport()
        {
            CLsDAo = new clsDAO();
            _leaveSummary = new LeaveSummaryReport();
        }


        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "select nplYear from Fiscal_Month where DefaultYr = 'N' order by cast(nplYear as int) desc", "nplYear", "nplYear", "", "");
            
        }

        private void PopulateDdlDept()
        {
            DdlDepartmentType.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartmentType, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchType.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            } 
        }

        private void PopulateDdlEmployee()
        {
            DdlEmployeeType.Items.Clear();
            if (DdlBranchType.Text != "" && DdlDepartmentType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmployeeType, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchType.Text + " AND DEPARTMENT_ID=" + DdlDepartmentType.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "All");
                
            }
        }

        private void ShowSummaryReport()
        {
            if (CheckSummaryRequiredFields() == 'Y')
                return;
            this.ReadSession().RptQuery = _leaveSummary.FindLeaveIncashmentReport("s", DdlBranchType.Text, DdlDepartmentType.Text, DdlEmployeeType.Text, DdlYear.Text).ToString();
            Response.Redirect("LeaveInCashmentReportDisplay.aspx?branchId=" + DdlBranchType.Text
                                + "&departmentId=" + DdlDepartmentType.Text
                                + "&empid=" + DdlEmployeeType.Text
                                + "&year=" + DdlYear.Text
                                + "&reptType=s");
        }

        private void ShowDetailReport()
        {
            if (CheckDetailRequiredFields() == 'Y')
                return;
            this.ReadSession().RptQuery = _leaveSummary.FindLeaveIncashmentReport("d", DdlBranchType.Text, DdlDepartmentType.Text, DdlEmployeeType.Text, DdlYear.Text).ToString();
            Response.Redirect("LeaveInCashmentReportDisplay.aspx?branchId=" + DdlBranchType.Text
                                + "&departmentId=" + DdlDepartmentType.Text
                                + "&empid=" + DdlEmployeeType.Text
                                + "&year=" + DdlYear.Text
                                + "&reptType=d");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
            }
            _stop = 'N';
        }

        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDdlDept();
        }

        protected void DdlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDdlEmployee();
        }

        protected void BtnShowReportType_Click(object sender, EventArgs e)
        {
            
            ShowSummaryReport();
        }

        protected void BtnDetailReport_Click(object sender, EventArgs e)
        {
            ShowDetailReport();
        }

        private char CheckSummaryRequiredFields()
        {
            
            //if (String.IsNullOrEmpty(DdlBranchType.Text)) 
            //{
            //    lblBranch.Text = "Required";
            //    _stop = 'Y';
            //}
            lblBranch.Text = "";
            lblDept.Text = "";
            lblEmp.Text = "";
            lblYear.Text = "";
            if (String.IsNullOrEmpty(DdlYear.Text))
            {
                lblYear.Text = "Required";
                lblYear.ForeColor = System.Drawing.Color.Red;
                _stop = 'Y';
            }

            return _stop;


        }

        private char CheckDetailRequiredFields()
        {
            CheckSummaryRequiredFields();
            if (String.IsNullOrEmpty(DdlDepartmentType.Text))
            {
                lblDept.Text = "Required";
                lblDept.ForeColor = System.Drawing.Color.Red;
                _stop = 'Y';
            }

            if (String.IsNullOrEmpty(DdlEmployeeType.Text))
            {
                lblEmp.Text = "Required";
                lblEmp.ForeColor = System.Drawing.Color.Red;
                _stop = 'Y';
            }

            return _stop;
        }
    }
}
