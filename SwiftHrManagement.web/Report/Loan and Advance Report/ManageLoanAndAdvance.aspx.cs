using System;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Loan_and_Advance_Report
{
    public partial class ManageLoanAndAdvance : BasePage
    {

        LoanAndadvence _LoanAdvanceSummary = null;
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        //String Flag = "a";
        public ManageLoanAndAdvance()
        {
            CLsDAo = new clsDAO();
            this._LoanAdvanceSummary = new LoanAndadvence();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                PopulateDropDownList();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 73) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }            

        }

        private void PopulateDropDownList()
        {
            
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlLoanType, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=46", "ROWID", "DETAIL_TITLE", "", "All");
            CLsDAo.CreateDynamicDDl(DdlAdvanceType, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=35", "ROWID", "DETAIL_TITLE", "", "All");
        
        }

     

        protected void BtnViewDetails_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _LoanAdvanceSummary.FindLoandetailsReport("d", DdlLoanType.Text, DdlBranchName.Text, DdlDeptName.Text, DdlEmpName.Text, txtFrom.Text, txtTo.Text).ToString();
            Response.Redirect("LoanSummery.aspx?flag='d'&from=" + txtFrom.Text + "&to=" + txtTo.Text + "&loantype=" + DdlLoanType.Text + "&branchid=" + DdlBranchName.Text + "&deptId=" + DdlDeptName.Text + "&empId=" + DdlEmpName.Text);
        
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            } 
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchName.Text + " AND DEPARTMENT_ID=" + DdlDeptName.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }





        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartmentType.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartmentType, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchType.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            } 
        }

        protected void DdlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DdlEmployeeType.Items.Clear();
            if (DdlBranchType.Text != "" && DdlDepartmentType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmployeeType, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchType.Text + " AND DEPARTMENT_ID=" + DdlDepartmentType.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void BtnSummery_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _LoanAdvanceSummary.FindLoansummaryReport("l", DdlLoanType.Text, DdlBranchName.Text, DdlDeptName.Text, DdlEmpName.Text, txtFrom.Text, txtTo.Text).ToString();
            Response.Redirect("LoanSummery.aspx?from=" + txtFrom.Text + "&to=" + txtTo.Text + "&loantype=" + DdlLoanType.Text + "&branchid=" + DdlBranchName.Text + "&deptId=" + DdlDeptName.Text + "&empId=" + DdlEmpName.Text);
        }

        protected void BtnAdvanceSummery_Click(object sender, EventArgs e)
        {

            this.ReadSession().RptQuery = _LoanAdvanceSummary.FindAdvancesummaryReport("a", DdlAdvanceType.Text, DdlBranchType.Text, DdlDepartmentType.Text, DdlEmployeeType.Text, txtFormDate.Text, txtTodate.Text).ToString();
            Response.Redirect("AdvanceSummery.aspx?from=" + txtFormDate.Text + "&to=" + txtTodate.Text + "&advancetype=" + DdlAdvanceType.Text + "&branchid=" + DdlBranchType.Text + "&deptId=" + DdlDepartmentType.Text + "&empId=" + DdlEmployeeType.Text);
        }

        protected void Btn_view_details_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _LoanAdvanceSummary.FindAdvanceDetailsReport("b", DdlAdvanceType.Text, DdlBranchType.Text, DdlDepartmentType.Text, DdlEmployeeType.Text, txtFormDate.Text, txtTodate.Text).ToString();
            Response.Redirect("AdvanceSummery.aspx?flag='d'&from=" + txtFormDate.Text + "&to=" + txtTodate.Text + "&advancetype=" + DdlAdvanceType.Text + "&branchid=" + DdlBranchType.Text + "&deptId=" + DdlDepartmentType.Text + "&empId=" + DdlEmployeeType.Text);
        }

      
    }
}
