using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Project.TaskDetail;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project.Task
{
    public partial class NotAssigned : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        TaskDAO _taskDao = null;
        public NotAssigned()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._taskDao = new TaskDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            this.GdvTaskList.DataSource = _taskDao.FindNotAssignedTask();
            this.GdvTaskList.DataBind();
        }
        protected void ImgAddCompInfo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Project/Task/Manage.aspx");
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
           // this.GdvTaskList.DataSource = this._taskDao.FindByDates(this.TxtStartDate.Text, this.TxtEndDate.Text);
            //GdvTaskList.DataBind();
        }

        protected void ImgShowFilter_Click(object sender, ImageClickEventArgs e)
        {

            pnlSearch.Visible = true;
            ImgHideFilter.Visible = true;
            ImgShowFilter.Visible = false;
        }

        protected void ImgHideFilter_Click(object sender, ImageClickEventArgs e)
        {
            pnlSearch.Visible = false;
            ImgHideFilter.Visible = false;
            ImgShowFilter.Visible = true;
        }

        protected void BtnShowMyTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/TaskList/List.aspx");
        }
    }
}
