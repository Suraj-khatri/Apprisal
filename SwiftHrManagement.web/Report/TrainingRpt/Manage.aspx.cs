using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.TrainingRpt
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displaydefaultdate();
                _clsDao.CreateDynamicDDl(ddlTrainingType, "Exec ProcStaticDataView 's','81'", "ROWID", "DETAIL_TITLE", "", "All");
                _clsDao.CreateDynamicDDl(ddlCategory, "SELECT ID, TRAINING_NAME FROM TrainingList", "ID", "TRAINING_NAME", "", "All");

                //_clsDao.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches	ORDER BY BRANCH_SHORT_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                //_clsDao.CreateDynamicDDl(ddlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "All");
                //_clsDao.CreateDynamicDDl(ddlFunctionalTitle, "Exec ProcStaticDataView 's','59'", "ROWID", "DETAIL_TITLE", "", "All");

                //_clsDao.CreateDynamicDDl(ddlQuestion, "Exec ProcStaticDataView 's','82'", "VALUE", "DETAIL_TITLE", "", "All");
                //_clsDao.CreateDynamicDDl(ddlPosition1, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "All");
                //_clsDao.CreateDynamicDDl(ddlFunTitle1, "Exec ProcStaticDataView 's','59'", "ROWID", "DETAIL_TITLE", "", "All");

                PopulateDdl();

            }
        }
        private void displaydefaultdate()
        {
            DateTime fromdate = DateTime.Now;

            this.txtFrmDate.Text = fromdate.ToString("MM/dd/yyyy");
            this.txtToDate.Text = fromdate.ToString("MM/dd/yyyy");
            this.fromDate1.Text = fromdate.ToString("MM/dd/yyyy");
            this.toDate1.Text = fromdate.ToString("MM/dd/yyyy");
            this.fromDate2.Text = fromdate.ToString("MM/dd/yyyy");
            this.toDate2.Text = fromdate.ToString("MM/dd/yyyy");
            //this.fromDate3.Text = fromdate.ToString("MM/dd/yyyy");
            //this.toDate3.Text = fromdate.ToString("MM/dd/yyyy");

            //this.txtFromDate4.Text = fromdate.ToString("MM/dd/yyyy");
            //this.txtToDate4.Text = fromdate.ToString("MM/dd/yyyy");
        }

        protected void PopulateDdl()
        {
            string access = _clsDao.GetSingleresult("select isnull(branch_level_access,'ONE') branch_level_access  from Admins where Name=" + filterstring(ReadSession().Emp_Id.ToString()));
            if (access.ToUpper() == "ALL")
            {
                _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");

            }
            else if (access.ToUpper() == "ONE")
            {
                _clsDao.setDDL(ref DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", ReadSession().Branch_Id.ToString(), "Select");
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("DateWiseRpt.aspx?startDate=" + txtFrmDate.Text + "&endDate="
                + txtToDate.Text + "&trainingType=" + ddlTrainingType.Text + "&category="+ddlCategory.Text+"&status="+ddlStatus.Text+"");
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetailedRpt.aspx?startDate=" + txtFrmDate.Text + "&endDate="
                + txtToDate.Text + "&trainingType=" + ddlTrainingType.Text + "");
        }


        protected void btnPSummary_Click(object sender, EventArgs e)
        {
            

            Response.Redirect("DateWiseParticipantRpt.aspx?startDate=" + txtPFromDate.Text + "&endDate="
                + txtPToDate.Text + "&branchId ="+DdlBranchName.Text +"&departmentId="+DdlDeptName.Text+"&employeeId=" + ddlEmpName.Text + "");
        }

        protected void btnExportSummary_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "EXEC [ProcRptTraining] @FLAG='a',@startDate=" + filterstring(txtFrmDate.Text) + ",@endDate=" +
            filterstring(txtToDate.Text) + ",@trainingType=" + filterstring(ddlTrainingType.Text) + ",@category=" + filterstring(ddlCategory.Text) + ","
            + " @status=" + filterstring(ddlStatus.Text) + "";

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
    
        }


        protected void btnPExport_Click(object sender, EventArgs e)
        {


            ReadSession().RptQuery = "EXEC [ProcRptTraining] @FLAG='p',@startDate=" + filterstring(txtPFromDate.Text) + ",@endDate=" +
        filterstring(txtPToDate.Text) + ",@branch_id=" + filterstring(DdlBranchName.Text) + ",@depart_id=" + filterstring(DdlDeptName.Text) + ",@emp_id=" + filterstring(ddlEmpName.Text) + "";

            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
    
        }
        protected void btnResourcePerson_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourcePersonWise.aspx?startDate=" + fromDate1.Text + "&endDate="
              + toDate1.Text + "&trainer=" + txtTrainer.Text + "");
        }

        protected void btnResourcePersonExport_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "EXEC [ProcRptTraining] @FLAG='c',@startDate=" + filterstring(fromDate1.Text) + ",@endDate=" + filterstring(toDate1.Text) + ",@trainer=" + filterstring(txtTrainer.Text) + "";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void rdbRptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbRptType.Text == "c")
            {
                rptCostWise.Visible = true;
                rptResourcePersonWise.Visible = false;
            }
            else 
            {
                rptCostWise.Visible = false;
                rptResourcePersonWise.Visible = true;
            }
        }

        protected void btnCostWise_Click(object sender, EventArgs e)
        {
            Response.Redirect("CostWise.aspx?startDate=" + fromDate2.Text + "&endDate="
                    + toDate2.Text + "&costFrom=" + txtRangeFrom.Text + "&costTo="+txtRangeTo.Text+"");
        }

        protected void btnCostWiseExport_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "EXEC [ProcRptTraining] @flag='d',@startDate=" + filterstring(fromDate2.Text) + ",@endDate=" +
            filterstring(toDate2.Text) + ",@costFrom=" + filterstring(txtRangeFrom.Text) + ",@costTo=" + filterstring(txtRangeTo.Text) + "";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {

                _clsDao.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }
        
        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {

                _clsDao.CreateDynamicDDl(ddlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + this.DdlBranchName.Text + " AND DEPARTMENT_ID=" + this.DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }


        //protected void btnSearchTNA_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("TNAReport.aspx?startDate=" + fromDate3.Text + "&endDate="
        //    + toDate3.Text + "&branch=" + ddlBranch.Text + "&dept=" + ddlDept.Text + "&emp="+ddlEmployee.Text+""
        //    +" &position="+filterstring(ddlPosition.Text)+"&funTitle="+filterstring(ddlFunctionalTitle.Text)+"");
        //}

        //protected void btnExportTna_Click(object sender, EventArgs e)
        //{
        //    ReadSession().RptQuery = "EXEC [procRptTNA] @flag='a',@startDate=" + filterstring(fromDate3.Text) + ",@endDate=" +
        //           filterstring(toDate3.Text) + ",@branch=" + filterstring(ddlBranch.Text) + ",@dept=" + filterstring(ddlDept.Text) + ","
        //           + " @emp=" + filterstring(ddlEmployee.Text) + ",@position="+filterstring(ddlPosition.Text)+","
        //           + " @funTitle="+filterstring(ddlFunctionalTitle.Text)+"";

        //    Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        //}

//        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlBranch.Text != "")
//            {
//                _clsDao.CreateDynamicDDl(ddlDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments WHERE BRANCH_ID=" + ddlBranch.Text + " ORDER BY DEPARTMENT_NAME", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
//            }
//            else
//            {
//                ddlDept.Text = "";
//            }
//        }

//        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlBranch.Text != "" && ddlDept.Text != "")
//            {
//                _clsDao.CreateDynamicDDl(ddlEmployee, "SELECT EMPLOYEE_ID,dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID) EMP_NAME"
//+ " FROM Employee WHERE EMP_STATUS=458	AND BRANCH_ID=" + ddlBranch.Text + " AND DEPARTMENT_ID=" + ddlDept.Text + "", "EMPLOYEE_ID", "EMP_NAME", "", "All");
//            }
//            else
//            {
//                ddlEmployee.Text = "";
//            }
//        }

        //protected void txtEmpName_TextChanged(object sender, EventArgs e)
        //{
        //    lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
        //    txtEmpName.Text = "";
        //}

        //protected void btnRptQuest_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("TNAReportQuestion.aspx?startDate=" + txtFromDate4.Text + "&endDate="
        //   + txtToDate4.Text + "&emp=" + getEmpIdfromInfo(lblEmpName.Text) + "&questionId=" + filterstring(ddlQuestion.Text) + ""
        //   + " &position=" + filterstring(ddlPosition1.Text) + "&funTitle=" + filterstring(ddlFunTitle1.Text) + "&question="+ddlQuestion.SelectedItem.Text+"");
        //    getEmpIdfromInfo(lblEmpName.Text)
        //}

        //protected void btnExportRptQuest_Click(object sender, EventArgs e)
        //{
        //    ReadSession().RptQuery = "EXEC [procRptTNAQuestion] @startDate=" + filterstring(txtFromDate4.Text) + ",@endDate=" +
        //            filterstring(txtToDate4.Text) + ",@question=" + filterstring(ddlQuestion.Text) + ","
        //            + " @emp=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@funTitle=" + filterstring(ddlFunTitle1.Text) + "";
        //    Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        //}
    }
}