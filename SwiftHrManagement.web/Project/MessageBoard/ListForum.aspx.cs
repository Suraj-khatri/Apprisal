using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Project.MessageBoard;
using System.Text;

namespace SwiftHrManagement.web.Project.MessageBoard
{
    public partial class ListForum : System.Web.UI.Page
    {
        MessageDao _messageDao = null;
        public ListForum()
        {
            this._messageDao = new MessageDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            tblResult.InnerHtml = listFileInformation(_messageDao.Getforum(GetForumid()).Tables[0]);
        }
        private long GetForumid()
        {
            return (Request.QueryString["desc"] != null ? long.Parse(Request.QueryString["desc"].ToString()) : 0);
        }
        private String listFileInformation(DataTable dt)
        {
            StringBuilder html = new StringBuilder("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"ForumTable\">");

            html.Append("<tr><th Class=\"ForumHeaderStyle\"> Start Disscuss </th><th Class=\"ForumHeaderStyle\"><a href=\"Manage.aspx?MsgId=0" 
                    + "&subid= " + GetForumid().ToString()
                    + "\"> Post Your Message</a></th>");

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr><th class=\"HeaderPost\">" + row["MSG_HEAD"].ToString()
                    + "</th><th class=\"HeaderPost\"><a href=\"Manage.aspx?MsgId="
                    + row["MESSAGE_ID"].ToString() 
                    + "&subid= " + row["SUB_ID"].ToString() 
                    + "\">Reply</a></th></tr><tr><td class=\"leftTD\">" 
                    + row["CREATED_BY"].ToString() + "<br>"
                    + "<br>" + row["CREATED_DATE"].ToString() 
                    + "</td><td class=\"rightTD\"><b>" 
                    + row["MSG_HEAD"].ToString() 
                    + "</b><br><br>" + row["FORUM"].ToString() 
                    + "</td></tr>");
            }

            html.Append("</table>");
            return html.ToString();
        }
    }
}
