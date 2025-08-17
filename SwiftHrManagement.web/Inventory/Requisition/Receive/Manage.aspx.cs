using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Requisition.Receive
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public Manage()
        {
            _clsdao = new ClsDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private long GetMsgId()
        {
            return (Request.QueryString["msg_id"] != null ? long.Parse(Request.QueryString["msg_id"].ToString()) : 0);
        }
        private long GetReqId()
        {
            return (Request.QueryString["req_id"] != null ? long.Parse(Request.QueryString["req_id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 123) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    PopulateReqQuantity();
                }               
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }
       
        private void PopulateReqQuantity()
        {
            DataTable dt = _clsdao.getTable("SELECT id.dispatched_qty, id.received_qty,remain,ip.porduct_code FROM IN_DISPATCH id INNER JOIN IN_PRODUCT ip ON ip.id=id.product_id"
                                            + " WHERE id.id=" + GetId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtDeliveredquantity.Text = dr["dispatched_qty"].ToString();
                Product.Text = dr["porduct_code"].ToString();
                TxtRecQuantity.Text = dr["received_qty"].ToString();
                txtRemainToReceive.Text = dr["remain"].ToString();
            }
        }
        private void managerequisition()
        {
            _clsdao.runSQL("UPDATE IN_DISPATCH SET remain=" + filterstring(txtRemainToReceive.Text) + " WHERE id=" + GetId() + "");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managerequisition();
                Response.Redirect("List.aspx?id=" + GetMsgId() + "&req_id="+GetReqId()+"");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
