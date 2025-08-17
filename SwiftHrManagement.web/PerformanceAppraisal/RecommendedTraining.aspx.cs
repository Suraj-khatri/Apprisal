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
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.PerformanceAppraisal
{
    public partial class RecommendedTraining : BasePage
    {
       
            CompanyDAO _company = null;
            CompanyCore _CompanyCore = null;
            clsDAO _clsDao = null;
            RoleMenuDAOInv _roleMenuDao = null;
            AppraisalReportDao _arDao = new AppraisalReportDao();
            TrainingRptDao _trDao = new TrainingRptDao();
            PerformanceAppraisalDAO _performanceAppDao = null;

            public RecommendedTraining()
           {
            _company = new CompanyDAO() ;
             _CompanyCore = new CompanyCore();
            _clsDao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
            _arDao = new AppraisalReportDao();
            _performanceAppDao = new PerformanceAppraisalDAO();
            _trDao = new TrainingRptDao();
           }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            PopulateDdl();
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

        protected void btnSummary_Click(object sender, EventArgs e)
        {
           Response.Redirect("RecommendedTrainingRpt.aspx?branch_id=" + DdlBranchName.Text + "&department_id=" + DdlDeptName.Text + "&emp_id=" + ddlEmpName.Text + "&from_date=" + txtFromDate.Text + "&to_date=" + txtToDate.Text + "");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _trDao.FindAppraisalTrainingReport(DdlBranchName.Text, DdlDeptName.Text, ddlEmpName.Text, txtFromDate.Text, txtToDate.Text).ToString();
            
            
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");

        }


        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {

                _clsDao.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }

        private void SetYearStartEndDate()
        {
            var dr = _performanceAppDao.getYearStartEndDate();
            if (dr == null)
                return;

            txtFromDate.Text = dr["en_year_start_date"].ToString();
            txtToDate.Text = dr["en_year_end_date"].ToString();

        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {

                _clsDao.CreateDynamicDDl(ddlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + this.DdlBranchName.Text + " AND DEPARTMENT_ID=" + this.DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

        
    }
}