using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
namespace SwiftAssetManagement.AssetParameters.Item
{
    public partial class Manage : BasePage
    {
        ClsDAOInv _clsdao = null;
        public Manage()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateDdl();
                if (GetItemId() > 0)
                {
                    populateitem();
                    BtnDelete.Visible = true;
                }
                else
                {
                    if (GetGrpId() == 1)
                    {
                        TxtDeprPct.Visible = true;
                        LblDepreciation.Visible = true;
                    }
                    else
                    {
                        TxtDeprPct.Visible = false;
                        LblDepreciation.Visible = false;
                    }
                    BtnDelete.Visible = false;
                }

            }
            DdlItems.Enabled = false;
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetItemId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private long GetGrpId()
        {
            return (Request.QueryString["grpid"] != null ? long.Parse(Request.QueryString["grpid"].ToString()) : 0);
        }
        private void manageitem()
        {
            try
            {
                string strflagflag = "";
                long id = GetItemId();

                if (id == 0)
                    strflagflag = "i";
                else
                    strflagflag = "u";

                string SQL = "exec proc_ASSET_ITEMsetup '" + strflagflag + "','" + id + "','" + ReadSession().Emp_Id.ToString() + "','" + TxtNewItems.Text + "',"
                    + " '" + TxtDecs.Text + "','" + DdlItems.Text + "','" + TxtDeprPct.Text + "'";
                string Msg = _clsdao.GetSingleresult(SQL);
                LblMsg.Text = Msg;
                TxtNewItems.Text = "";
                TxtDeprPct.Text = "";
                TxtDecs.Text = "";
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void populateitem()
        {
            DataTable dt = _clsdao.getTable("exec proc_ASSET_ITEMsetup 't',@ID='" + GetItemId() + "'");
            bool isproduct;
            foreach (DataRow dr in dt.Rows)
            {
                DdlItems.Text = dr["parent_id"].ToString();
                TxtNewItems.Text = dr["item_name"].ToString();
                TxtDecs.Text = dr["item_desc"].ToString();
                isproduct = bool.Parse(dr["is_product"].ToString());
                DdlItems.Enabled = false;
                if (Convert.ToString(dr["parent_id"]) == "1".ToString())
                {
                    TxtDeprPct.Visible = true;
                    LblDepreciation.Visible = true;
                    TxtDeprPct.Text = dr["depre_pct"].ToString();
                }
                else
                {
                    TxtDeprPct.Visible = false;
                    LblDepreciation.Visible = false;
                }
            }
        }

        private void populateDdl()
        {
            string GRPId = "";
            GRPId = Convert.ToString(GetGrpId());
            _clsdao.CreateDynamicDDl(DdlItems, "select item_name, id from ASSET_ITEM", "id", "item_name", GRPId, "Select");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            manageitem();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _clsdao.runSQL("exec procExecuteSQLString 'd' , 'delete from ASSET_ITEM' , ' and id=''" + GetItemId() + "''', '" + ReadSession().Emp_Id.ToString() + "'");
            Response.Redirect("EditList.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
        }

        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='ass_group',@ID=" + GetItemId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
            if (msg.Contains("SUCCESS"))
            {
                TxtNewItems.Text = "";
                TxtDecs.Text = "";
                LblMsg.Text = msg;
                return;
            }
            else
            {
                LblMsg.Text = msg;
                return;
            }
        }
    }
}
