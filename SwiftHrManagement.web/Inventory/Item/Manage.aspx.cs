using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Item
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public Manage()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 105) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateDdl();
                if (GetId() > 0)
                {
                    populateitem();
                    _clsdao.CreateDynamicDDl(DdlItems, "SELECT item_name,id FROM IN_ITEM WHERE id =(SELECT parent_id FROM IN_ITEM WHERE id=" + GetId() + ")", "id", "item_name", "", "");
                }
                else
                {
                    _clsdao.CreateDynamicDDl(DdlItems, "SELECT id,item_name FROM IN_ITEM WHERE id=" + GetGrpId() + "", "id", "item_name", "", "");
                }
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private long GetGrpId()
        {
            return (Request.QueryString["grpid"] != null ? long.Parse(Request.QueryString["grpid"].ToString()) : 0);
        }

        private void manageitem()
        {
            string strflagflag = "";
            long id = GetId();
            if (id == 0)
                strflagflag = "i";
            else
                strflagflag = "u";

            string SQL = "exec [proc_In_Itemsetup] '" + strflagflag + "','" + id + "','" + ReadSession().Emp_Id.ToString() + "','" + TxtNewItems.Text + "',"
            + " '" + TxtDecs.Text + "','" + DdlItems.Text + "'";

            string Msg = _clsdao.GetSingleresult(SQL);

            LblMsg.Text = Msg;
            LblMsg.ForeColor = System.Drawing.Color.Green;
        }

        private void populateitem()
        {
            DataTable dt = _clsdao.getTable("exec proc_In_Itemsetup 't',@ID='" + GetId() + "'");
            bool isproduct;
            foreach (DataRow dr in dt.Rows)
            {
                DdlItems.Text = dr["parent_id"].ToString();
                TxtNewItems.Text = dr["item_name"].ToString();
                TxtDecs.Text = dr["item_desc"].ToString();
                isproduct = bool.Parse(dr["is_product"].ToString());
                DdlItems.Enabled = false;
            }
        }
        private void populateDdl()
        {
            string GRPId = "";
            GRPId = Convert.ToString(GetGrpId());

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                manageitem();
            }
            catch
            {
                LblMsg.Text="Error In Operation!";
                LblMsg.ForeColor=System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='group',@ID=" + GetId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
            if (msg.Contains("SUCCESS"))
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Green;
                TxtNewItems.Text = "";
                TxtDecs.Text = "";
            }
            else
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
