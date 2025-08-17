using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class ManageLeaveReport : BasePage
    {
        LeaveSummaryReport _leaveSummary = null;
        clsDAO CLsDAo = null;
        String Flag = "a";
        public ManageLeaveReport()
        {
            CLsDAo = new clsDAO();
            this._leaveSummary = new LeaveSummaryReport();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
                TxtFromDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                TxtToDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");

                txtReqDateFrom.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                ReqDateTo.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }            
        }

        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DDL_YEAR, "SELECT nplYear FROM Fiscal_Month", "nplYear", "nplYear", "", "SELECT");
            DDL_YEAR.SelectedValue = CLsDAo.GetSingleresult("SELECT nplYear FROM Fiscal_Month WHERE DefaultYr='Y'");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }  

        protected void BtnReport_Click(object sender, EventArgs e)
        {

            if (TxtFromDate.Text == "" || TxtToDate.Text == "")
            {
                Label1.Text = " Form Date and To Date is Required ";
                return;
            }
            Response.Redirect("LeaveSummary.aspx?flag='d'&from=" + TxtFromDate.Text + "&to=" + TxtToDate.Text + "");
        }


        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartmentType.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartmentType, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchType.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }  

        }

        protected void DdlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmployeeType.Items.Clear();
            if (DdlBranchType.Text != "" && DdlDepartmentType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmployeeType, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchType.Text + " AND DEPARTMENT_ID=" + DdlDepartmentType.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

        

        protected void BtnShowReportType_Click(object sender, EventArgs e)
        {

            Response.Redirect("LeaveRecordType.aspx?from=" + 
                txtReqDateFrom.Text + "&to=" + ReqDateTo.Text + 
                "&branchId="+DdlBranchType.Text+ "&departmentId=" + 
                DdlDepartmentType.Text + "&empid=" + 
                DdlEmployeeType.Text + "");

        }

        protected void BtnDetailReport_Click(object sender, EventArgs e)
        {
          
            if (DdlEmployeeType.Text=="")
            {
                LblMsg.Text = " Employe is Required ";
                return;
            }

            if (txtReqDateFrom.Text == "" || ReqDateTo.Text == "")
            {
                LblMsg.Text = " Form Date and To Date is Required ";
                return;
            }

            Response.Redirect("LeaveSummary.aspx?from=" +
                txtReqDateFrom.Text + "&to=" + ReqDateTo.Text +
                "&branchId=" + DdlBranchType.Text + "&departmentId=" +
                DdlDepartmentType.Text + "&empid=" +
                DdlEmployeeType.Text + "");

        }

        protected void DdlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnIndividualReport_Click(object sender, EventArgs e)
        {
            if (DdlEmployeeType.Text == "")
            {
                LblMsg.Text = " Employe is Required ";
                return;
            }

            Response.Redirect("LeaveIndividualReport.aspx?flag=c" +
               "&empid=" + DdlEmployeeType.Text + "");
        }

        protected void Btnrpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveDetailedDatewise.aspx?fromdate=" + TxtFromDate.Text + "&todate=" + TxtToDate.Text + "&empId=" + getEmpIdfromInfo(lblEmployee.Text) + "");
        }

        protected void BtnLeaveStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/Leave/LeaveStatusReport.aspx?branchId=" + DdlBranchType.Text + "&deptId=" + DdlDepartmentType.Text + "&EmpId=" + DdlEmployeeType.Text);
        }

        protected void BTN_VIEW_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveSummaryRpt.aspx?year=" + DDL_YEAR.Text + "&emp_id=" + getEmpIdfromInfo(lblEmpName.Text) + "");
        }
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }
        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }

        protected void btnLSumm_Click(object sender, EventArgs e)
        {
            Response.Redirect("TADAReportYearWise.aspx?year=" + DDL_YEAR.Text + "&emp_id=" + getEmpIdfromInfo(lblEmpName.Text) + "&flag=L");
        }

        protected void btnLDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveReportYearWise.aspx?year=" + DDL_YEAR.Text + "&emp_id=" + getEmpIdfromInfo(lblEmpName.Text) + "&flag=LD");
        }

        protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            lblEmployee.Text = GetEmpInfoForLabel(txtEmployeeName.Text, lblEmployee.Text);
            txtEmployeeName.Text = "";
        }

    }
}
