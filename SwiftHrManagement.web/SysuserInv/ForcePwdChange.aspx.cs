using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.SysuserInv
{
    public partial class ForcePwdChange : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        SystemUser sysuser = null;
        UserDAO usrDao = null;
        public ForcePwdChange()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this.sysuser = new SystemUser();
            this.usrDao = new UserDAO();          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 3) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            
        }
        private void manageCharagePassword()
        {
            long Id = this.ReadSession().AdminId;
            //this.prepareChangePassword();
            string UserPassword;
            this.sysuser = this.usrDao.FindUserPassword(Id);
            UserPassword = this.sysuser.UserPassword;
            if (UserPassword == TxtOldPass.Text)
            {                
                //this.usrDao.ChangePassword(TxtNewPass.Text,Id);
                var msg = usrDao.GetSingleresult(" exec proc_passwordPolicy @flag='c' ,@username=" + usrDao.filterstring(ReadSession().UserName)
                    + ",@password=" + usrDao.filterstring(UserPassword) + ",@newPwd =" + usrDao.filterstring(TxtNewPass.Text));

                if (msg == "success")
                {
                    ResetChangePassword();
                    LblMsg.Text = "Sucess, Your Password has been changed!!!";
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else {
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                LblMsg.Text = "Your old password do not match! Please Try Again!!!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.manageCharagePassword();
                Response.Redirect("~/Main.aspx?q=HR");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void ResetChangePassword()
        {
            TxtNewPass.Text = "";
            TxtOldPass.Text = "";
            TxtConfirmPass.Text = "";

        }
    }
}
