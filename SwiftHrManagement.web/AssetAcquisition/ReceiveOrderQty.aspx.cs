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
    public partial class ReceiveOrderQty : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ReceiveOrderQty()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 63) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateAssetInfo();
            }
            rate.Attributes.Add("onblur", "CalculateTotal();");
            qty.Attributes.Add("onblur", "CalculateTotal();");
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private long GetOrderMsgId()
        {
            return (Request.QueryString["OrderMsgId"] != null ? long.Parse(Request.QueryString["OrderMsgId"].ToString()) : 0);
        }
        private void populateAssetInfo()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select t.id,a.porduct_code+'-'+a.ASSET_CODE  AS 'asset_type',qty,rate as rate,amount as amount from asset_temp_order t"
				+" inner join ASSET_PRODUCT a on t.asset_id=a.id where t.id='"+GetId()+"'" 
                +" and session_id="+filterstring(ReadSession().Sessionid)+"").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblAssetType.Text = dr["asset_type"].ToString();
                lblQty.Text = dr["qty"].ToString();
                qty.Text=dr["qty"].ToString();
                rate.Text=dr["rate"].ToString();
                amount.Text=dr["amount"].ToString();
                rate.Enabled = false;
                amount.Enabled = false;
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(lblQty.Text) >= Double.Parse(qty.Text))
                {
                    if (Double.Parse(qty.Text) > 0)
                    {
                        _clsdao.runSQL("UPDATE asset_temp_order SET qty=" + filterstring(qty.Text) + ",rate=" + filterstring(rate.Text) + ",amount=" + filterstring(amount.Text) + " WHERE id='" + GetId() + "' AND session_id=" + filterstring(ReadSession().Sessionid) + "");
                        LblMsg.Text = "Update Completed Sucessfully!";
                        LblMsg.ForeColor = System.Drawing.Color.Green;
                        return;
                    }
                    else
                    {
                        LblMsg.Text = "Qty can't be equal and less than zero!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    LblMsg.Text = "Received quantity can not be greater than ordered quantity!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        //protected void BtnCancel_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ReceivePurchaseOrder.aspx?Id="+GetOrderMsgId()+"");
        //}
        //protected void qty_TextChanged(object sender, EventArgs e)
        //{
        //    amount.Text = (Double.Parse(qty.Text) * Double.Parse(rate.Text)).ToString();
        //}
    }
}
