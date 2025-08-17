using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
namespace SwiftHrManagement.web.Inventory.ItemVersion2
{
    public partial class MainMenu : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public MainMenu()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 105) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
    }
}
