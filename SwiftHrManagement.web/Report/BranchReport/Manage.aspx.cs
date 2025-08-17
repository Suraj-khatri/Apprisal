using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.BranchReport
{
    public partial class Manage : BasePage
    {
         LeaveRpt _lrpt = new LeaveRpt(); 
        AttendanceRpt _arpt=new AttendanceRpt();
        private TrainingRpt _trpt = new TrainingRpt();
         PayrollRpt _prpt = new PayrollRpt();
        clsDAO _clsDao = null;
        private RoleMenuDAOInv _roleMenuDaoInv = null;
        public Manage()
        {
            this._clsDao = new clsDAO();
            this._roleMenuDaoInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDaoInv.hasAccess(ReadSession().AdminId, 38) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateDdlEmpName();
            }
        }

        private void populateDdlEmpName()
        {
            _clsDao.CreateDynamicDDl(ddlEmployeeName, "EXEC [ProcGetSupervisorEmployee] @FLAG='br',@SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "All");
            _clsDao.CreateDynamicDDl(DdlEmpName, "EXEC [ProcGetSupervisorEmployee] @FLAG='br',@SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "All");
            _clsDao.CreateDynamicDDl(ddlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsDao.CreateDynamicDDl(ddlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");

            ddlFiscalYear.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            ddlMonth.SelectedValue = _clsDao.GetSingleresult("Select SUBSTRING(nep_date,1,2) from tbl_calendar where cast(eng_date as date)=cast(GETDATE() as date)");
        }
        #region
        protected void BtnLeaveRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _lrpt.LoadReportExcel(txtFromDate.Text,txtToDate.Text,ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("LeaveRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void btnLeaveDetail_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _lrpt.loadDetailedRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("LeaveRpt.aspx?flag=d&from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnAttendanceRpt_Click(object sender, EventArgs e)
        {    this.ReadSession().RptQuery = _arpt.loadAttendanceRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);
        Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("AttendanceRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnTrainingRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _trpt.loadTrainingRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("TrainingRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnPayrollRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayrollRpt.aspx?FY=" + ddlFiscalYear.Text + "&month=" + ddlMonth.Text + "&emp_id=" + DdlEmpName.Text);
        }
        #endregion

        protected void BtnExExcel_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _prpt.LoadPayrollRptExcel(ddlFiscalYear.Text, ddlMonth.Text, DdlEmpName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }
    }
}