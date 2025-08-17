using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.Report.AppraisalSummary
{
    public partial class ManageAppraisalFinalReport : BasePage
    {
       clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        PerformanceAppraisalDAO _performanceAppDao = null;

        public ManageAppraisalFinalReport()
        {
            CLsDAo = new clsDAO();
            _performanceAppDao = new PerformanceAppraisalDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 101) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
                SetYearStartEndDate();
            }
        }

        protected void PopulateDdl()
        {
            string access = CLsDAo.GetSingleresult("select isnull(branch_level_access,'ONE') branch_level_access  from Admins where Name=" + filterstring(ReadSession().Emp_Id.ToString()));
            if(access.ToUpper() == "ALL")
            {
                CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
               
            }
            else if (access.ToUpper() == "ONE")
            {
                CLsDAo.setDDL(ref DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", ReadSession().Branch_Id.ToString(), "Select");
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppraisalFinalReport.aspx?branch_id=" + DdlBranchName.Text + "&department_id=" + DdlDeptName.Text + "&emp_id=" + ddlEmpName.Text + "&from_date=" + txtFromDate.Text + "&to_date=" + txtToDate.Text + "");
        }

        protected void btnStatusSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppraisalStatusReport.aspx?branch_id=" + DdlBranchName.Text + "&department_id=" + DdlDeptName.Text + "&emp_id=" + ddlEmpName.Text + "&from_date=" + txtFromDate.Text + "&to_date=" + txtToDate.Text + "");
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {

                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
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

                CLsDAo.CreateDynamicDDl(ddlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + this.DdlBranchName.Text + " AND DEPARTMENT_ID=" + this.DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

      
    }
}