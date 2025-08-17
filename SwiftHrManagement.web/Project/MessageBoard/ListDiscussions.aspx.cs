using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Project.MessageBoard;

namespace SwiftHrManagement.web.Project.MessageBoard
{
    public partial class ListDiscussions : BasePage
    {
        MessageDao _messageDao = null;
        public ListDiscussions()
        {
            _messageDao = new MessageDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            listFileInformation(_messageDao.Getforum((GetForumid())).Tables[0]);
        }
        private long GetForumid()
        {
            return (Request.QueryString["desc"] != null ? long.Parse(Request.QueryString["desc"].ToString()) : 0);
        }
        private void listFileInformation(DataTable dt)
        {

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];
            div1.InnerHtml = row[3].ToString();
            div2.InnerHtml = row[1].ToString();
            div3.InnerHtml = "";
            div4.InnerHtml = row[2].ToString();
        }
    }
}
