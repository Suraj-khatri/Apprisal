using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.AssetAcquisition
{
    public partial class ModifyAssetInfo : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ModifyAssetInfo()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 64) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateAssetInfo();
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateAssetInfo()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select t.id,t.requistion_message_id,a.porduct_code+'-'+a.ASSET_CODE  AS asset_type,t.qty as Qty from ASSET_REQUISITION t inner join "
            +" ASSET_PRODUCT a on t.asset_id=cast(a.id as varchar) WHERE t.id='"+GetId()+"'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblAssetType.Text = dr["asset_type"].ToString();
                lblQty.Text = dr["Qty"].ToString();
                hdnMessageId.Value = dr["requistion_message_id"].ToString();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("UPDATE ASSET_REQUISITION SET approved_qty=" + filterstring(TxtAppQuantity.Text) + " WHERE id='" + GetId() + "'");
                Response.Redirect("ManageApprove.aspx?Id="+hdnMessageId.Value+"");
            }
            catch
            {
                LblMsg.Text = "Error In Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApprove.aspx?Id=" + hdnMessageId.Value + "");
        }
    }
}
