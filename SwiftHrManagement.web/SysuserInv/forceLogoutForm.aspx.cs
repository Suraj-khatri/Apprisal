using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.SysuserInv
{
    public partial class forceLogoutForm : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            userName.Text = _clsDao.GetSingleresult("select UserName from admins where adminId="+filterstring(GetAdminId().ToString())+"");
        }
        private long GetAdminId()
        {
            return (Request.QueryString["Admin_Id"] != null ? long.Parse(Request.QueryString["Admin_Id"].ToString()) : 0);
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("UPDATE Admins SET session='' where adminId=" + filterstring(GetAdminId().ToString()) + "");
            Response.Redirect("List.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

    }
}