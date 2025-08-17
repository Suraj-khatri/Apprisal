using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Project;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        ProjectDAO _prjdao = null;
        ProjectCore _prjcore = null;
        EmployeeDAO _empDao = null;
        UserDAO _usrDao = null;
        SystemUser _sysUser = null;
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._prjcore = new ProjectCore();
            this._prjdao = new ProjectDAO();
            this._empDao = new EmployeeDAO();
            this._usrDao = new UserDAO();
            this._sysUser = new SystemUser();
        }
        private bool ValidateProjectDetlEntry()
        {
            DateTime startdate = DateTime.Parse(txtstartDate.Text);
            DateTime enddate = DateTime.Parse(txtEndDate.Text);
            if (ddlProjectManager.SelectedIndex == -1 && ddlprojectOwner.SelectedIndex == -1)
            {
                return false;
            }
            if (startdate > enddate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void PopulateProject()
        {
            this._prjcore = this._prjdao.FindbyId(this.GetprojectId());
            this.txtProjectTitle.Text = this._prjcore.Title;         
            this.txtstartDate.Text = this._prjcore.Start_date;
            this.txtEndDate.Text = this._prjcore.End_date;
            this.TxtCategory.Text = this._prjcore.Category;
            this.ddlprojectOwner.SelectedValue = this._prjcore.Owner;
            this.ddlProjectManager.SelectedValue = this._prjcore.Prj_manager;
            this.ddlPriority.SelectedValue = this._prjcore.Priority;
            if (this._prjcore.Completed == "True")
            {
                ChkIsCompleted.Checked = true;
            }
            else
            {
                ChkIsCompleted.Checked = false;
            }
        }
        private long GetprojectId()
        {
            return (Request.QueryString["Project_Id"] != null ? long.Parse(Request.QueryString["Project_Id"].ToString()) : 0);
        }
        private void Prepareddl()
        {
            clsDAO CLsDAo = new clsDAO();
            CLsDAo.CreateDynamicDDl(DdlBranchForOwner, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlBranchForManager, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            CLsDAo.CreateDynamicDDl(ddlPriority, "Exec ProcStaticDataView 's','15'", "ROWID", "DETAIL_TITLE", "", "Select");     
        }   
        private void PrepareProjet()
        {
            ProjectCore _prjcore = new ProjectCore();
            long id = this.GetprojectId();
            if (id > 0)
            {
                _prjcore.Project_id = id;
            }
            _prjcore.Title = txtProjectTitle.Text;
            _prjcore.Start_date = this.txtstartDate.Text;
            _prjcore.End_date = this.txtEndDate.Text;
            _prjcore.Category = this.TxtCategory.Text;
            _prjcore.Owner = this.ddlprojectOwner.Text; 
            _prjcore.Prj_manager = this.ddlProjectManager.Text;
            _prjcore.Priority = this.ddlPriority.Text;
            if (ChkIsCompleted.Checked == true)
                _prjcore.Completed = "true";
            else
                _prjcore.Completed = "false";

            this._prjcore = _prjcore;
        }
        private void manageProject()
        {
            long id = this.GetprojectId();
            this.PrepareProjet();
            if (id > 0)
            {
                this._prjcore.ModifyBy = this.ReadSession().UserId;
                this._prjdao.Update(this._prjcore);
            }
            else
            {
                this._prjcore.CreatedBy = this.ReadSession().UserId;
                this._prjdao.Save(this._prjcore);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.Prepareddl();
                long Id= this.GetprojectId();
                if (Id > 0)
                {
                    clsDAO CLsDAo = new clsDAO();
                    CLsDAo.CreateDynamicDDl(ddlprojectOwner, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID", "UserName", "EmpName", "", "Select");
                    CLsDAo.CreateDynamicDDl(ddlProjectManager, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID", "UserName", "EmpName", "", "Select");   
                    this.BtnDelete.Visible = true;
                    this.PopulateProject();
                }
                else
                {                    
                    this.BtnDelete.Visible = false;
                }
            } 
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.manageProject();
                Response.Redirect("List.aspx");
             
            }
            catch
            {
                lblmsg.Text = "Error In Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _prjdao.DeleteProjectById(GetprojectId(), this.ReadSession().UserId.ToString());
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }            
        }
        protected void DdlBranchForOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchForOwner.Text!= "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlDeptForOwner, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchForOwner.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }
        protected void DdlBranchForManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchForManager.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlDeptForManager, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchForManager.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }
        protected void DdlDeptForOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchForOwner.Text != "" && DdlDeptForOwner.Text!="")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(ddlprojectOwner, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID WHERE BRANCH_ID=" + this.DdlBranchForOwner.Text + " AND DEPARTMENT_ID=" + this.DdlDeptForOwner.Text + "", "UserName", "EmpName", "", "Select");
            }
        }
        protected void DdlDeptForManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlDeptForManager.Text != "" && DdlDeptForManager.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(ddlProjectManager, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID WHERE BRANCH_ID=" + this.DdlBranchForManager.Text + " AND DEPARTMENT_ID=" + this.DdlDeptForManager.Text + "", "UserName", "EmpName", "", "Select");
            }
        }
    }
}
