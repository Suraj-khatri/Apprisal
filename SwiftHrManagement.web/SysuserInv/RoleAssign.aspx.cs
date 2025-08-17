using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.SysuserInv
{
    public partial class RoleAssign : BasePage
    {
        UserDaoInv _userDao = null;
        SystemUser _userCore = null;
        RoleMenuDAOInv _roleMenuDao = null;
        RoleMenuCore _roleMenuCore = null;
        public RoleAssign()
        {
            this._userDao = new UserDaoInv();
            this._userCore = new SystemUser();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._roleMenuCore = new RoleMenuCore();
        }
        private string GetAdminId()
        {
            return Request.QueryString["Admin_Id"] != null ? Request.QueryString["Admin_Id"].ToString() : "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 1) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                string adminId = GetAdminId();
                string Id = StringEncryption.Decrypt(adminId);
                bool IsExist;
                IsExist = _roleMenuDao.CheckForValidUserRole(Id);
                PopulateDropDownList();
                if (IsExist == true)
                {
                    this._userCore = _userDao.FindUserRole(Id);
                    LblRole.Text = this._userCore.RoleName;
                    DdlRoleList.SelectedValue = this._userCore.RoleId;
                }
                else
                {
                    LblRole.Text = "";
                }
            }
 
        }
        private void PopulateDropDownList()
        {
            if (!IsPostBack)
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlRoleList, "Exec ProcStaticDataView 's','25'", "ROWID", "DETAIL_TITLE", "", "Select");
            }
        }
        private void ManageAssignRole()
        {
            string Id = StringEncryption.Decrypt(Convert.ToString(this.GetAdminId()));
            string role_id = DdlRoleList.Text;            
            this._userDao.InsertAssignRole(role_id, Id);            
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.ManageAssignRole();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
