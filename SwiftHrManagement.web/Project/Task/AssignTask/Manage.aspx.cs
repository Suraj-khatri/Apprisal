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
using SwiftHrManagement.DAL.Project.TaskDetail.AssignTaskDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project.Task.AssignTask
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        TaskAssignCore _taskAssignCore = null;
        AssignTaskDAO _assigntaskDao = null; 
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._assigntaskDao = new AssignTaskDAO();
            this._taskAssignCore = new TaskAssignCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                getassignedtaskInfo();
                PopulateDdlBranch();        
                ListAssignedEmp(_assigntaskDao.GetAssignedTask(GetAssignTaskId()).Tables[0]);
            }
        }
        private void PopulateDdlBranch()
        {
            clsDAO CLsDAo = new clsDAO();
            CLsDAo.CreateDynamicDDl(ddlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }
        private bool checkduplicate()
        {
            if (_assigntaskDao.CheckIfExistsTask(ddlassignedto.Text, GetAssignTaskId())==true)
                return true;
            else
                return false;
        }
        private void getassignedtaskInfo()
        {
            _taskAssignCore = _assigntaskDao.GetTaskDetailById(this.GetAssignTaskId());
            LblTaskName.Text = _taskAssignCore.Title;
            LblStartdate.Text = _taskAssignCore.Start_date;
            LblEndDate.Text = _taskAssignCore.End_date;
            LblReportTo.Text = _taskAssignCore.Report_to;            
            LblCategory.Text = _taskAssignCore.Category;
        }
        private long GetAssignTaskId()
        {
            return (Request.QueryString["TASK_ID"] != null ? long.Parse(Request.QueryString["TASK_ID"].ToString()) : 0);
        }

        private void PrepareAssignedTask()
        {            
            TaskAssignCore _tskassignCore = new TaskAssignCore();

            this._assigntaskDao.AssignTask(ddlassignedto.Text, (GetAssignTaskId()),this.ReadSession().UserId);            
        }
        private void manageAssignedTask()
        {
            try
            {
                long Id = this.GetAssignTaskId();
                this.PrepareAssignedTask();
                lblmsg.Text = "Operation completed successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                lblmsg.Text = "Error in operation";               
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }   
        private void populateassignedtask()
        {         
                DataTable dt = null;
                dt = _assigntaskDao.AssignTask(GetAssignTaskId()).Tables[0];
                ListAssignedEmp(dt);
                lblmsg.Text = "";
        }
        private void ListAssignedEmp(DataTable dt)
        {
            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;
            if (dt.Rows.Count > 0)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                tr.CssClass = "taskGridHeader";
                if (dt.Rows.Count > 1)
                    td1.Text = "<input type='checkbox' name='chkAll' name='chkAll'  id='chkAll' onclick=\"checkAll(this);\">";
                else
                    td1.Text = "";
                td2.Text = "<strong>Assigned Employee</strong>";
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tblResult.Rows.Add(tr);
            }
            foreach (DataRow row in dt.Rows)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td1.Text = "<input type='checkbox' name='chkTran' id='chkTran' value='" + row["id"].ToString() + "'>";
                td2.Text = row["EMP_ID"].ToString();
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tblResult.Rows.Add(tr);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string Ids = "";
                if (Request.Form["chkTran"] != null)
                {
                    Ids = Request.Form["chkTran"].ToString();
                }

                if (Ids == "")
                    return;
                _assigntaskDao.DeleteById(Ids);
                lblmsg.Text = "Operation completed successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                this.populateassignedtask();
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_AssignTask_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean ifexist = _assigntaskDao.CheckIfExistsTask(ddlassignedto.Text, (GetAssignTaskId()));
                if (ifexist == true)
                {
                    lblmsg.Text = "Perticular task has already been assigned to this user";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                manageAssignedTask();
                ListAssignedEmp(_assigntaskDao.GetAssignedTask(GetAssignTaskId()).Tables[0]);
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }

        protected void ddlassignedto_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            if (checkduplicate() == true)
            {
                lblmsg.Text = "This task has been already assigned!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            ListAssignedEmp(_assigntaskDao.GetAssignedTask(GetAssignTaskId()).Tables[0]);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/Task/List.aspx"); 
        }

        protected void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranchName.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.ddlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(ddlassignedto, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID", "UserName", "EmpName", "", "Select");
            }
        }
    }
}
