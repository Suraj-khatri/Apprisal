using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Payrole_management.GradeIncrement
{
    public partial class Manage : BasePage
    {
        clsDAO Clsdao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        private string emp_ids = "";
        public Manage()
        {
            Clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 256) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
            }
            emp_ids = Request.Form["ctl00$MainPlaceHolder$Ddlassigned"];
        }

        private void PopulateDdl()
        {
            Clsdao.CreateDynamicDDl(fiscalYear, "exec proc_gradeIncrement @flag='FY'", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            fiscalYear.SelectedValue = Clsdao.GetSingleresult("exec proc_gradeIncrement @flag='DFY'");
            Clsdao.CreateDynamicDDl(branch, "EXEC proc_gradeIncrement @flag='branch'", "BRANCH_ID", "Branch_name", "", "Select");
            Clsdao.CreateDynamicDDl(appraisalRating, "EXEC proc_gradeIncrement @flag='AR'", "ROWID", "DETAIL_TITLE", "", "Select");


            Clsdao.CreateDynamicDDl(salaryTitle, "EXEC proc_gradeIncrement @flag='salSet'", "salarySetMasterId", "Salary_Title", "", "Select");
        }
   
        private void PopulateAssigned()
        {
            string sql = "EXEC proc_gradeIncrement @flag='search',@fiscalYear=" + filterstring(fiscalYear.Text) + ","
            +"@appRating=" + filterstring(appraisalRating.Text) + ",@effectiveDate=" + filterstring(effectiveDate.Text) + ","
            +"@applyDate=" + filterstring(applyDate.Text) + ",@branchId=" + filterstring(branch.Text) + ","
            +"@deptId=" + filterstring(department.Text) + ",@postionId=" + filterstring(position.Text) + ","
            +"@salarySet=" + filterstring(salaryTitle.Text) + "";

            Clsdao.CreateDynamicDDl(DdlUnassigned, sql, "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "");
        }

       
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            Response.Redirect("Confirm.aspx?fiscalYear=" + fiscalYear.Text + "&appRate=" + appraisalRating.Text + "&effectiveFrom=" + effectiveDate.Text + "&applyOn=" + applyDate.Text + "&empIds=" + emp_ids + "");   
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void DdlUnassigned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Ddlassigned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateAssigned();
            //PopulateUnassigned();
        }

        protected void branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (branch.Text != "")
                Clsdao.CreateDynamicDDl(department, "EXEC proc_gradeIncrement @flag='dept',@branchId=" + filterstring(branch.Text) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            else
                department.Text = "";
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (department.Text != "" && branch.Text != "")
                Clsdao.CreateDynamicDDl(position, "EXEC proc_gradeIncrement @flag='post',@branchId=" + filterstring(branch.Text) + ",@deptId=" + filterstring(department.Text) + "", "position_id", "position_Name", "", "Select");
            else
                position.Text = "";
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "EXEC proc_gradeIncrement_test @flag='save',@fiscalYear=" + filterstring(fiscalYear.Text) + ","
                        + "@appRating=" + filterstring(appraisalRating.Text) + ",@effectiveDate=" + filterstring(effectiveDate.Text) + ","
                        + "@applyDate=" + filterstring(applyDate.Text) + ",@emp_ids='" + emp_ids + "',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        } 
    }
}