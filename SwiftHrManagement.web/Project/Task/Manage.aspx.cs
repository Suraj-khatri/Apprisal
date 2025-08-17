using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Project.TaskDetail;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.DAL.Project;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project.Task
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        ProjectDAO _projDao = null;
        ProjectCore _projcore = null;
        TaskDAO _taskDao = null;
        TaskCore _taskCore = null;
        UserDAO _usrDao = null;
        SystemUser _sysUser = null;

        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._usrDao = new UserDAO();
            this._sysUser = new SystemUser();
            this._taskCore = new TaskCore();
            this._taskDao = new TaskDAO();
            this._projcore = new ProjectCore();
            this._projDao = new ProjectDAO();
        }

        private long GetProjectId()
        {
            return (Request.QueryString["Project_Id"] != null ? long.Parse(Request.QueryString["Project_Id"].ToString()) : 0);
        }
        private long GetTaskId()
        {
            return (Request.QueryString["TASK_ID"] != null ? long.Parse(Request.QueryString["TASK_ID"].ToString()) : 0);
        }
        private void prepareTask()
        {

            UserDAO _usrDao = new UserDAO();
            TaskCore _taskcore = new TaskCore();
            long Id = this.GetTaskId();
            if (Id > 0)
            {
                _taskcore.Task_id = Id;
                _taskCore.Is_Assigned = false;
            }
            _taskcore.Project_id = (this.ddlprojTittle.Text);
            hdnprjid.Value = ddlprojTittle.Text;
            _taskcore.Title = this.Txttitle.Text;
            _taskcore.Start_date = this.TxtstartDate.Text;
            _taskcore.End_date = this.TxtEndDate.Text;
            _taskcore.Report_to = this.ddlreportto.Text;
            _taskcore.Priority = this.ddlPriority.Text;
            _taskcore.Category = this.TxtCategory.Text;
            this._taskCore = _taskcore;
          
        }
        private void ManageTask()
        {
            long Id = this.GetTaskId();
            this.prepareTask();
            if (Id > 0)
            {
                this._taskCore.ModifyBy = this.ReadSession().UserId;
                this._taskDao.Update(this._taskCore);
            }
            else
            {
                this._taskCore.CreatedBy = this.ReadSession().UserId;
                this._taskDao.Save(this._taskCore);
            }
        }
        private void PopulateTask()
        {
            this._taskCore = this._taskDao.FindbyId(this.GetTaskId().ToString());       
            this.TxtstartDate.Text = _taskCore.Start_date;
            this.TxtEndDate.Text = _taskCore.End_date;
            this.Txttitle.Text = _taskCore.Title;
            this.ddlprojTittle.SelectedValue = _taskCore.Project_id;
            this.hdnprjid.Value = _taskCore.Project_id;
            this.ddlreportto.SelectedValue = _taskCore.Report_to;
            this.TxtCategory.Text = _taskCore.Category;
            this.ddlPriority.SelectedItem.Text = _taskCore.Priority;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropDownList();               
                long id = this.GetTaskId();
                if (id > 0)
                {
                    clsDAO CLsDAo = new clsDAO();
                    CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "select");
                    CLsDAo.CreateDynamicDDl(ddlreportto, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID", "UserName", "EmpName", "", "select");                  
                    this.BtnDelete.Visible = true;
                    this.PopulateTask();
                }
                else
                {
                    long Proj_id = this.GetProjectId();
                    this.BtnDelete.Visible = false;
                    if (Proj_id > 0)
                    {
                        this.hdnprjid.Value = this.GetProjectId().ToString();
                        //this._projcore = _projDao.FindProject(this.GetProjectId());
                        //ddlprojTittle.SelectedItem.Value = _projcore.Title;
                        this.ddlprojTittle.Enabled = false;
                    }
                }
            }
        }
        private void PopulateDropDownList()
        {
            clsDAO CLsDAo = new clsDAO();       
            CLsDAo.CreateDynamicDDl(ddlprojTittle, "select PROJECT_ID,PROJECT_TITLE from Projects", "PROJECT_ID", "PROJECT_TITLE", GetProjectId().ToString(), "select");                      
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "select");

         }
        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            try
            {
                this._projcore = this._projDao.CheckProjectStatus(long.Parse(ddlprojTittle.Text));
                if (_projcore.Completed == "True")
                {
                    lblmsg.Text = "Sorry,This Project is already Completed!!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    this.ManageTask();
                    Response.Redirect("/Project/Task/List.aspx?Project_Id=" + this.hdnprjid.Value + "");
                }
            }
            catch
            {
                lblmsg.Text = "Error In Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/Task/List.aspx?Project_Id=" + hdnprjid.Value + "");     
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _taskDao.DeletebyId(GetTaskId(), this.ReadSession().Emp_Id.ToString());
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                this.lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }
        }
        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(ddlreportto, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID where BRANCH_ID=" + this.DdlBranchName.Text + " and DEPARTMENT_ID=" + this.DdlDeptName.Text + "", "UserName", "EmpName", "", "select");
            }
        }
    }
}
