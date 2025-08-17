using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using System.Text;
using SwiftHrManagement.DAL.Project.UpdateTask;
using SwiftHrManagement.DAL.Project.TaskDetail;
using SwiftHrManagement.DAL.Project.TaskDetail.AssignTaskDAO;

namespace SwiftHrManagement.web.Project.TaskList
{
    public partial class Manage : BasePage
    {
        TaskCore _taskcore = null;
        TaskDAO _taskDao = null;
        UpdateTaskCore _updttskCore = null;
        UpdateTaskDao _updttskDao = null;
        public Manage()
        {

            this._taskcore = new TaskCore();
            this._taskDao = new TaskDAO();

            this._updttskCore = new UpdateTaskCore();
            this._updttskDao = new UpdateTaskDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                hdnfldtskid.Value = GetTaskid().ToString();
                if (this.GetUpdateTaskid() > 0)
                {
                    BtnDelete.Visible = true;
                    this.PopulateTaskUpdate();
                }
                else
                {
                    this.GetTaskTitle();
                    BtnDelete.Visible = false;
                }       
            }
        }
        private long GetTaskid()
        {
            return (Request.QueryString["TASK_ID"] != null ? long.Parse(Request.QueryString["TASK_ID"].ToString()) : 0);
        }
        private long GetUpdateTaskid()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void GetTaskTitle()
        {
            this._taskcore = this._taskDao.FindTaskTitle(GetTaskid().ToString());
            this.LblTaskTitle.Text = this._taskcore.Title;
            this.LblTaskTitle.Enabled = false;
        }
        private void prepareUpdateTasks()
        {
            bool Ischecked;
            UpdateTaskCore _updateTaskCore = new UpdateTaskCore();      
            long Id = this.GetUpdateTaskid();
            if (Id > 0)
            {
                _updateTaskCore.UPDT_TASK_ID = Id;
            }
            _updateTaskCore.Posted_By = this.ReadSession().UserId;
            if (Chkstatus.Checked == true)
            {
                Ischecked = true;
            }
            else
            {
                Ischecked = false;
            }
            _updateTaskCore.Is_Complete = Ischecked.ToString();
            _updateTaskCore.Description = this.TxtDescription.Text;
            _updateTaskCore.Complete_PCT = this.TxtPctcomplete.Text;
            _updateTaskCore.Active_Task = hdnfldtskid.Value;
            this._updttskCore = _updateTaskCore;
        }
        private void PopulateTaskUpdate()
        {
            long ID = this.GetUpdateTaskid();
            this._updttskCore = this._updttskDao.FindAllByUptID(GetUpdateTaskid().ToString());
            this.TxtDescription.Text = this._updttskCore.Description;
            this.TxtPctcomplete.Text = this._updttskCore.Complete_PCT;
            this.LblTaskTitle.Text = this._updttskCore.Active_Task;
            this.LblTaskTitle.Enabled = false;     
            if (this._updttskCore.Is_Complete == "Yes")
            {
                Chkstatus.Checked = true;
            }
            else
            {
                Chkstatus.Checked = false;
            }
        }
        private void DeleteRecord()
        {
            try
            {
                this._updttskDao.DeleteById(this.GetUpdateTaskid());
                Response.Redirect("List.aspx?TASK_ID=" + GetTaskid() + "");
            }
            catch
            {
                lblMsg.Text = "Error In Operation";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        private void ManageUpdateTask()
        {
            this.prepareUpdateTasks();
            if (this.GetUpdateTaskid() > 0)
            {
                this._updttskCore.ModifyBy = this.ReadSession().UserId;
                this._updttskDao.Update(this._updttskCore); 
            }
            else
            {
                this._updttskCore.CreatedBy = this.ReadSession().UserId;
                this._updttskDao.Save(this._updttskCore);              
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.checkStatus();
                this.ManageUpdateTask();
                Response.Redirect("List.aspx?TASK_ID="+ GetTaskid()+ "");
            }
            catch
            {
                this.lblMsg.Text = "Error In Operation";
                this.lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void resetControls()
        {
            TxtDescription.Text = "";
            TxtPctcomplete.Text = "0";
            //Chkstatus.Checked = false;
        }
        private void checkStatus()
        {
            if (TxtPctcomplete.Text == "100")
            {
                Chkstatus.Checked = true;
            }
            else
            {
                Chkstatus.Checked = false;
            }
        }
        protected void TxtPctcomplete_TextChanged(object sender, EventArgs e)
        {
            this.checkStatus();
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteRecord();
            this.resetControls();
        }
        protected void DdlActiveTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?TASK_ID=" + GetTaskid() + "");
        }
    }
}
