using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Project.MessageBoard;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.Project.MessageBoard
{
    public partial class List : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        MessageDao _messageDao = null;
        MessageCore _messageCore = null;
        public List()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._messageDao = new MessageDao();
            this._messageCore = new MessageCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            //tblProjects.InnerHtml = listOfProjects(_messageDao.GetProjects(ReadSession().UserId).Tables[0]);
            //tblTask.InnerHtml = listOfTasks(_messageDao.GetTasks().Tables[0]);
        }
        protected void BtnAddProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/List.aspx");
        }
        protected void BtnShowTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/Task/NotAssigned.aspx");
        }
        protected void BtnShowMyTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Project/TaskList/List.aspx");
        }
        protected void ImgAddCompInfo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Manage.aspx");
        }

        //private string listOfProjects(DataTable dt)
        //{
        //    StringBuilder html = new StringBuilder("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
        //    html.Append("<tr><th class=\"heading\">Running Projects</th></tr>");
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        html.Append("<tr><td class=\"leftTD\"><a href=\"/Project/Task/List.aspx?Project_Id=" + row["PROJECT_ID"].ToString() + "\" target=\"MainFrame\">" + row["PROJECT_TITLE"].ToString() + "</a></td></tr>");
        //    }
        //    html.Append("</table>");
        //    return html.ToString();
        //}
        protected void GdvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
