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
using System.Text;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveHistory : BasePage
    {
        clsDAO CLsDAo = null;
        LeaveSummaryReport _leaveSummary = null;
        public LeaveHistory()
        {
            CLsDAo = new clsDAO();
            _leaveSummary = new LeaveSummaryReport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
            }    
        }

        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "select nplYear from Fiscal_Month where DefaultYr = 'N' order by cast(nplYear as int) desc", "nplYear", "nplYear", "", "");
            AdjustDates();
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
            if (!IsDateValid())
            {
                return;
            }

            //this.ReadSession().RptQuery = _leaveSummary.FindLeaveRecordType(DdlBranchType.Text, DdlDepartmentType.Text, DdlEmployeeType.Text, txtReqDateFrom.Text, txtReqDateTo.Text).ToString();
            Response.Redirect("LeaveRecordType.aspx?from=" +
                txtReqDateFrom.Text + "&to=" + txtReqDateTo.Text +
                "&branchId=" + DdlBranchType.Text + "&departmentId=" +
                DdlDepartmentType.Text + "&empid=" +
                DdlEmployeeType.Text + "");
        }

        protected void BtnDetailReport_Click(object sender, EventArgs e)
        {
            if (!IsDateValid())
            {
                return;
            }
            if (DdlEmployeeType.Text == "")
            {
                LblMsg.Text = " Employe is Required ";
                return;
            }
            //this.ReadSession().RptQuery = _leaveSummary.FindLeavesummaryReport2(DdlEmployeeType.Text, txtReqDateFrom.Text, txtReqDateTo.Text).ToString();

            Response.Redirect("LeaveSummary.aspx?from=" +
                txtReqDateFrom.Text + "&to=" + txtReqDateTo.Text +
                "&branchId=" + DdlBranchType.Text + "&departmentId=" +
                DdlDepartmentType.Text + "&empid=" +
                DdlEmployeeType.Text + "");
        }

        protected void BtnIndividualReport_Click(object sender, EventArgs e)
        {
            if (!IsDateValid())
            {
                return;
            }
            if (DdlEmployeeType.Text == "")
            {
                LblMsg.Text = " Employe is Required ";
                return;
            }
            /*
            Response.Redirect("LeaveIndividualReportType.aspx?from=" +
               txtReqDateFrom.Text + "&to=" + txtReqDateTo.Text +
               "&branchId=" + DdlBranchType.Text + "&departmentId=" +
               DdlDepartmentType.Text + "&empid=" +
               DdlEmployeeType.Text + "");
            */
            Response.Redirect("LeaveIndividualReport.aspx?flag=h&year=" + DdlYear.Text +
               "&empid=" + DdlEmployeeType.Text + "");
        }

        protected void DdlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustDates();
            
        }

        private void AdjustDates()
        {
            //string[] result = CLsDAo.GetSingleresult("exec procFindfirstNlastdayofYear @flag='f',@fyear=" + filterstring(DdlYear.Text)).Split('|');
            //txtReqDateFrom.Text = result[0];
            //txtReqDateTo.Text = result[1];
        }

        protected void txtReqDateFrom_TextChanged(object sender, EventArgs e)
        {
            
            if (!IsDateValid())
            {
                txtReqDateFrom.Focus();
                return;
            }
           
        }

        private bool IsDateValid()
        {
            LblMsg.Text = "";
            string result = CLsDAo.GetSingleresult("exec procFindfirstNlastdayofYear @flag='c',@fyear=" + filterstring(DdlYear.Text) + ",@fromdate=" + filterstring(txtReqDateFrom.Text) + ",@todate=" + filterstring(txtReqDateTo.Text));
            if (result=="1")
            {
                return true; 
            }
            else
            {
                LblMsg.Text = "Date Out of Range!";
                return false;
            }
        }

        protected void txtReqDateTo_TextChanged(object sender, EventArgs e)
        {
            if (!IsDateValid())
            {
                txtReqDateTo.Focus();
                return;
            }
        }

        protected void BtnLeaveStatus_Click(object sender, EventArgs e)
        {
            if (DdlYear.Text == "")
            {
                lblyear.Text = "Required!";
                return;
            }
            Response.Redirect("/Report/Leave/LeaveStatusReport.aspx?flag=l&branchId=" + DdlBranchType.Text + "&departmentId=" + DdlDepartmentType.Text + "&empid=" + DdlEmployeeType.Text + "&bsdate=" + DdlYear.Text + "");
        }
    }
}
