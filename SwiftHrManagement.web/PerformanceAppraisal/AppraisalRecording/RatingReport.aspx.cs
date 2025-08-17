using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalRecording
{
    public partial class RatingReport : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public RatingReport()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 90) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }

        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(fiscalYear, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            fiscalYear.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            CLsDAo.CreateDynamicDDl(ddlRating,"EXEC proc_gradeIncrement @flag='AR'", "DETAIL_TITLE", "DETAIL_TITLE", "", "Select");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = "Exec [ProcRecordAppraisalRating] @flag='s',@fy_id="+filterstring(fiscalYear.Text)+",@rating="+filterstring(ddlRating.Text)+",@branch="+filterstring(DdlBranchName.Text)+",@dept="+filterstring(DdlDeptName.Text);
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }
    }
}