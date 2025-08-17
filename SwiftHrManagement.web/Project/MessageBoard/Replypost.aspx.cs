using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Project.MessageBoard
{
    public partial class Replypost : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        public Replypost()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
            {
                Response.Redirect("/Error.aspx");
            }
        }
    }
}
