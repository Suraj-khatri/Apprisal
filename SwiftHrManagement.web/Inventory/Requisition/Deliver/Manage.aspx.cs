using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Requisition.Deliver
{
    public partial class Manage : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public Manage()
        {
            _clsdao = new ClsDAOInv();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        private long GetApprovelId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private long GetDeliveredlId()
        {
            return (Request.QueryString["appid"] != null ? long.Parse(Request.QueryString["appid"].ToString()) : 0);
        }
        private void managerequisition()
        {
            _clsdao.runSQL("exec [proc_Requisition] 'd',@quantity='" + TxtDeliveredQuantity.Text + "',@id=" + filterstring(GetApprovelId().ToString()) + "");
        }

        private void PopulateReqQuantity()
        {
            DataTable dt = _clsdao.getTable("select ir.Delivered_Quantity, ir.Approved_Quantity,ip.product_desc from IN_Requisition_DETAIL ir, IN_PRODUCT ip where ir.item = ip.id and ir.id = " + GetApprovelId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtDeliveredQuantity.Text = dr["Delivered_Quantity"].ToString();
                Product.Text = dr["product_desc"].ToString();
                TxtAppQuantity.Text = dr["Approved_Quantity"].ToString();

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDQty.Text = _clsdao.GetSingleresult("SELECT Delivered_Quantity-isnull(Received_Quantity,0) FROM IN_Requisition WHERE Requistion_message_id=" + GetDeliveredlId() + " "
                                                    + " AND item =(SELECT item FROM IN_Requisition_detail WHERE id=" + GetApprovelId() + ")");
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 121) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetApprovelId() > 0)
                    PopulateReqQuantity();
              
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managerequisition();
                Response.Redirect("/Inventory/Requisition/Deliver/List.aspx?id=" + GetDeliveredlId() + "");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
