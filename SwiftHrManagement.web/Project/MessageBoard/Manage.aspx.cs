using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Project.MessageBoard;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project.MessageBoard
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        MessageDao _messageBoardDao = null;
        MessageCore _messageCore = null;
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._messageBoardDao = new MessageDao();
            this._messageCore = new MessageCore();
        }
        private long GetSubId()
        {
            return (Request.QueryString["subid"] != null ? long.Parse(Request.QueryString["subid"].ToString()) : 0);
        }
        private long GetMsgId()
        {
            return (Request.QueryString["MsgId"] != null ? long.Parse(Request.QueryString["MsgId"].ToString()) : 0);
        }
        private void populateDdl()
        {
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlSubject, "Exec ProcStaticDataView 's','31'", "ROWID", "DETAIL_TITLE", "Nepal", "Select...");
        }
        private void prepareMessageBoard()
        {
            MessageCore _msgCore = new MessageCore();
        }
        private void ManageMessageBoard()
        {
            _messageCore.Subject = DdlSubject.Text;
            _messageCore.Msg_head = TxtMessageHead.Text;
            _messageCore.Forum = TxtDescription.Text;
            _messageCore.CreatedBy = this.ReadSession().UserId;
            _messageCore.Reply = this.GetMsgId().ToString();
            _messageBoardDao.Save(this._messageCore);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetSubId() > 0 && this.GetMsgId() > 0)
                {
                    DdlSubject.Text = this.GetSubId().ToString();
                    DdlSubject.Enabled = false;
                }
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ManageMessageBoard();
                Response.Redirect("ListForum.aspx?desc=" + this.GetSubId() + "");
            }
            catch
            {
                this.LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
