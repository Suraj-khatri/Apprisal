using System;
using System.Collections.Generic;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class ManageAttendanceReport : BasePage
    {
        AttendanceReports _attendance = null;
        clsDAO _clsDao = new clsDAO();
        public ManageAttendanceReport()
        {
            this._attendance = new AttendanceReports();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateDdlBranchName1();
                this.PopulateDdlBranchName2();
                this.PopulateDdlBranchName3();
                displaydefaultdate();
            }
        }
        private void PopulateDdlBranchName3()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "All";
                branchlist.Insert(0, DefaultBrn);
                this.ddlBranchRpt.DataSource = branchlist;
                this.ddlBranchRpt.DataTextField = "Name";
                this.ddlBranchRpt.DataValueField = "Id";
                this.ddlBranchRpt.DataBind();
                this.ddlBranchRpt.SelectedIndex = 0;
            }
        }
        private void displaydefaultdate()
        {
            DateTime fromdate = DateTime.Now;
            
            txtfromDate.Text = fromdate.ToString("MM/dd/yyyy");
            txttoDate.Text = fromdate.ToString("MM/dd/yyyy");
            this.FromDate.Text = fromdate.ToString("MM/dd/yyyy");
            this.ToDate.Text = fromdate.ToString("MM/dd/yyyy");
            this.Report_Date.Text = fromdate.ToString("MM/dd/yyyy");
            this.ReportDate_To.Text = fromdate.ToString("MM/dd/yyyy");

        }

        private void PopulateDdlBranchName1()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "All";
                branchlist.Insert(0, DefaultBrn);
                this.DdlBranchName1.DataSource = branchlist;
                this.DdlBranchName1.DataTextField = "Name";
                this.DdlBranchName1.DataValueField = "Id";
                this.DdlBranchName1.DataBind();
                this.DdlBranchName1.SelectedIndex = 0;
            }
        }
        private void PopulateDdlBranchName2()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "All";
                branchlist.Insert(0, DefaultBrn);
                this.DdlBranchName2.DataSource = branchlist;
                this.DdlBranchName2.DataTextField = "Name";
                this.DdlBranchName2.DataValueField = "Id";
                this.DdlBranchName2.DataBind();
                this.DdlBranchName2.SelectedIndex = 0;
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string[] a = txtEmpId.Text.Split('|');
            string empname = a[1];            

            this.ReadSession().RptQuery = _attendance.EmpSearch(txtfromDate.Text, txttoDate.Text, empname).ToString();
            Response.Redirect("EmployeeWiseReport.aspx?EmpName=" + empname + "&from=" + txtfromDate.Text + "&to=" + txttoDate.Text + "");
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _attendance.DateWiseSearch(FromDate.Text, ToDate.Text, DdlBranchName1.Text, DdlDeptName1.Text);
            Response.Redirect("DateWiseReport.aspx?from="+ FromDate.Text +"&to="+ ToDate.Text +"");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ReportType = DdlReportType.Text;
            if (ReportType == "Summary Report")
            {

                this.ReadSession().RptQuery = _attendance.DailyReport("s", Report_Date.Text,ReportDate_To.Text, DdlBranchName2.Text, DdlDeptName2.Text,DdlEmloyeeName.Text).ToString();
                Response.Redirect("DateWiseReport.aspx?from=" + Report_Date.Text + "&type=s");
            }
            else
            {
                this.ReadSession().RptQuery = _attendance.DailyReport("i", Report_Date.Text, ReportDate_To.Text, DdlBranchName2.Text, DdlDeptName2.Text, DdlEmloyeeName.Text).ToString();
                Response.Redirect("DateWiseReport.aspx?from=" + Report_Date.Text + " &to=" + ReportDate_To.Text + " &type=d");
            }
        }
        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.populateDepartment();   
        }
        protected void DdlBranchName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DdlDepartmentName1();
        }
        private void DdlDepartmentName1()
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID(long.Parse(DdlBranchName1.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "All";
                deptlist.Insert(0, deprtcore);
                this.DdlDeptName1.DataSource = deptlist;
                this.DdlDeptName1.DataTextField = "Deptname";
                this.DdlDeptName1.DataValueField = "Id";
                this.DdlDeptName1.DataBind();
                this.DdlDeptName1.SelectedIndex = 0;
            }
        }
        protected void DdlBranchName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.populateDdlDepartment2();
        }
        private void populateDdlDepartment2()
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID(long.Parse(DdlBranchName2.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "All";
                deptlist.Insert(0, deprtcore);
                this.DdlDeptName2.DataSource = deptlist;
                this.DdlDeptName2.DataTextField = "Deptname";
                this.DdlDeptName2.DataValueField = "Id";
                this.DdlDeptName2.DataBind();
                this.DdlDeptName2.SelectedIndex = 0;
            }
        }
        protected void DdlDeptName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlBranchName2.Text!="" && DdlDeptName2.Text!="")
            {
            _clsDao.CreateDynamicDDl(DdlEmloyeeName, "SELECT EMPLOYEE_ID,FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME+' |'+EMP_CODE  AS EMP_NAME FROM Employee"
                                        + " WHERE BRANCH_ID="+filterstring(DdlBranchName2.Text)+" AND DEPARTMENT_ID="+filterstring(DdlDeptName2.Text)+" "
                                        +" AND EMPLOYEE_ID<>1000", "EMPLOYEE_ID", "EMP_NAME", "", "ALL");
            }
        }

        protected void BtnSearchRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _attendance.AttendanceTimeWiseRpt(DdlRptNature.Text, from_date.Text, to_date.Text, ddlBranchRpt.Text, ddlDeptRpt.Text);
            Response.Redirect("AttendanceTimeWiseRpt.aspx?from=" + from_date.Text + "&to=" + to_date.Text + "&rptNature=" + DdlRptNature.Text + "");
        }

        protected void ddlBranchRpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID(long.Parse(ddlBranchRpt.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "All";
                deptlist.Insert(0, deprtcore);
                this.ddlDeptRpt.DataSource = deptlist;
                this.ddlDeptRpt.DataTextField = "Deptname";
                this.ddlDeptRpt.DataValueField = "Id";
                this.ddlDeptRpt.DataBind();
                this.ddlDeptRpt.SelectedIndex = 0;
            }
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            string ReportType = DdlReportType.Text;
            if (ReportType == "Summary Report")
            {

                this.ReadSession().RptQuery = _attendance.DailyReport("s", Report_Date.Text, ReportDate_To.Text, DdlBranchName2.Text, DdlDeptName2.Text, DdlEmloyeeName.Text).ToString();
                
            }
            else
            {
                this.ReadSession().RptQuery = _attendance.DailyReport("i", Report_Date.Text, ReportDate_To.Text, DdlBranchName2.Text, DdlDeptName2.Text, DdlEmloyeeName.Text).ToString();
                
            }
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _attendance.AttendanceTimeWiseRpt(DdlRptNature.Text, from_date.Text, to_date.Text, ddlBranchRpt.Text, ddlDeptRpt.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

    }
}