using System;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class Manage : BasePage
    {
        LeaveRpt _lvrpt=new LeaveRpt();
        AttendanceRpt _atrpt=new AttendanceRpt();
        DarRpt _drpt=new DarRpt();
        TrainingRpt _trrpt=new TrainingRpt();
        AppraisalRpt _aprpt=new AppraisalRpt();
        PayrollRpt _prpt=new PayrollRpt();
        clsDAO _clsDao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                populateDdlEmpName();
                BtnPAppraisalRpt.Visible = false;
            }
        }

        private void populateDdlEmpName()
        {
            _clsDao.CreateDynamicDDl(ddlEmployeeName, "EXEC [ProcGetSupervisorEmployee] @FLAG='a',@SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "All");
            _clsDao.CreateDynamicDDl(DdlEmpName, "EXEC [ProcGetSupervisorEmployee] @FLAG='a',@SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "All");
            _clsDao.CreateDynamicDDl(ddlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsDao.CreateDynamicDDl(ddlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
        }

    #region
        //edited by bibhut
        protected void BtnLeaveRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _lvrpt.loadReportExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
           // Response.Redirect("LeaveRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnAttendanceRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _atrpt.LoadAttRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("AttendanceRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnDarRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _drpt.ShowrptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("DarRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnTrainingRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _trrpt.LoadTrainRpt(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("TrainingRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnPAppraisalRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _aprpt.loadAprRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            //Response.Redirect("AppraisalRpt.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void BtnPayrollRpt_Click(object sender, EventArgs e)
        {
            //this.ReadSession().RptQuery = _aprpt.loadAprRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);

            //Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            Response.Redirect("PayrollRpt.aspx?FY=" + ddlFiscalYear.Text + "&month=" + ddlMonth.Text + "&emp_id=" + DdlEmpName.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TrainingManagement/TrainingNeedAssessment/TNAReport.aspx?flag=t&from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

        protected void btnLeaveDetail_Click(object sender, EventArgs e)
        {
             this.ReadSession().RptQuery = _lvrpt.loadDetailRptExcel(txtFromDate.Text, txtToDate.Text, ddlEmployeeName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
           // Response.Redirect("LeaveRpt.aspx?flag=d&from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&emp_id=" + ddlEmployeeName.Text);
        }

    #endregion

        protected void BtnSupRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _prpt.LoadPayrollRptExcel(ddlFiscalYear.Text, ddlMonth.Text, DdlEmpName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }
    }
}
