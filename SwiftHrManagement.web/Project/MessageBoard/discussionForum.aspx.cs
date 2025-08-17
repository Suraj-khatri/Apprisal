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
    public partial class discussionForum : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        MessageDao _messageDao = null;
        MessageCore _messageCore = null;
        public discussionForum()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._messageDao = new MessageDao();
            this._messageCore = new MessageCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
               if (_roleMenuDao.hasAccess(ReadSession().AdminId, 158) == false)
            {
                Response.Redirect("/Error.aspx");
            }        
            tblResult.InnerHtml= listFileInformation(_messageDao.Getforum().Tables[0]);          
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
        private string listFileInformation(DataTable dt)
        {
            StringBuilder html = new StringBuilder("<table cellpadding=\"0\" cellspacing=\"0\" class=\"ForumTable\">");
            html.Append("<tr><th width=\"596\" align=\"left\" Class=\"ForumHeaderStyle\">Discussion Forum</th><th width=\"150\" align=\"center\" Class=\"ForumHeaderStyle\">Threads</th></tr>");
            
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr><td class=\"ForumDataStyle\"><a href=\"ListForum.aspx?desc=" + row["MESSAGE_ID"].ToString() + "\"><b>" + row["DETAIL_TITLE"].ToString() + "</b></a><br><br>" + row["DETAIL_DESC"].ToString() + "</td><td align=\"center\" class=\"ForumDataStyle\">" + row["TOTAL"].ToString() + "</td></tr>");
            }
            html.Append("</table>");
            return html.ToString();
        }
        protected void GdvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

