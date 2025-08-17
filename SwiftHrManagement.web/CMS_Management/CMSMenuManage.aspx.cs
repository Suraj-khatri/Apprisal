using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.CMS_Management;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.CMS_Management
{
    public partial class CMSMenuManage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO clsdao = null;
        CMSDAO cmsdao = null;
        public CMSMenuManage()
        {
            this.cmsdao = new CMSDAO();
            this.clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();                  
        }
        private long GetMenuId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 99) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                clsdao.CreateDynamicDDl(DdlPageName, "select id,func_name from CMS_functions with (nolock)", "id", "func_name", "", "Select");
                clsdao.CreateDynamicDDl(DdlMainMenu, "select id, menu_name from CMS_Menu with (nolock)  where Linked_id is null or linked_id=''", "id", "menu_name", "", "Select");
                if (GetMenuId() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateMenuDetail();
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }
        private void PopulateMenuDetail()
        {
            DataSet ds = FindMenuDetail(GetMenuId());
            DataTable dt = new DataTable();
            DataTable cms = ds.Tables[0];
            DdlPageName.SelectedValue = cms.Rows[0]["func_id"].ToString();
            DdlMainMenu.SelectedValue = cms.Rows[0]["linked_id"].ToString();
            txtSubMenu.Text = cms.Rows[0]["menu_name"].ToString();
            txtMenuDesc.Text = cms.Rows[0]["menu_desc"].ToString();
            ddlDisplayFlag.SelectedValue = cms.Rows[0]["display_flag"].ToString();
        }
        public DataSet FindMenuDetail(long rowid)
        {
            return cmsdao.FindAllById(rowid);
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetMenuId() > 0)
                {
                    clsdao.runSQL("UPDATE CMS_Menu SET func_id=" + filterstring(DdlPageName.Text) + ",menu_name=" + filterstring(txtSubMenu.Text) + ","
                            +" linked_id=" + filterstring(DdlMainMenu.Text) + ",menu_desc=" + filterstring(txtMenuDesc.Text) + ","
                            +" modify_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ",modify_date=" + filterstring(clsdao.CreatedDate.ToString()) + ","
                            +" display_flag="+filterstring(ddlDisplayFlag.Text)+" WHERE id=" + GetMenuId() + "");
                }
                else
                {

                    clsdao.runSQL("INSERT INTO CMS_Menu(func_id,menu_name,menu_desc,linked_id,created_by,create_date,display_flag) VALUES(" + filterstring(DdlPageName.Text) + ","
                    +" " + filterstring(txtSubMenu.Text) + "," + filterstring(txtMenuDesc.Text) + "," + filterstring(DdlMainMenu.Text) + ","
                    +" " + filterstring(ReadSession().Emp_Id.ToString()) + "," + filterstring(clsdao.CreatedDate.ToString()) + ","+filterstring(ddlDisplayFlag.Text)+")");
                }
                Response.Redirect("CMSMenuList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmsdao.DeleteMenuById(this.GetMenuId(), ReadSession().Emp_Id.ToString());
                Response.Redirect("CMSMenuList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CMSMenuList.aspx");
        }

        protected void DdlPageName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
