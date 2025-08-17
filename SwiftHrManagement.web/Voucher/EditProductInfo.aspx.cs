using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.Voucher
{
    public partial class EditProductInfo : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public EditProductInfo()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 114) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateProductInfo();
            }
            unitprice.Attributes.Add("onblur", "CalculateTotal();");
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
        private void populateProductInfo()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT P.id,isnull(T.foc_qty,0) foc_qty,P.porduct_code as 'Product',T.qty as Qty, T.rate 'rate' ,T.amount FROM"
            +" Temp_Purchase T INNER JOIN IN_PRODUCT P ON P.id=T.product_code WHERE flag='p' and T.id='"+GetId()+"'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblProductCode.Text = dr["id"].ToString();
                txtProduct.Text = dr["Product"].ToString();
                txtProduct.Enabled = false;
                qty.Text = dr["Qty"].ToString();
                hdnQty.Value = dr["Qty"].ToString();
                unitprice.Text = dr["rate"].ToString();
                amount.Text = dr["amount"].ToString();
                txtFOC.Text = dr["foc_qty"].ToString();

                if (Convert.ToInt64(txtFOC.Text) > 0)                
                    txtFOC.Visible = true;
                
            }
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {      
            if (!String.IsNullOrEmpty(hdnQty.Value))
            {
                int iQty = Convert.ToInt32(hdnQty.Value);
                if (Convert.ToInt32(qty.Text) > iQty)
                {
                    if (Convert.ToInt32(qty.Text) > iQty + Convert.ToInt32(txtFOC.Text))
                    {
                        LblMsg.Text = "Qty is higher, FOC is not sufficient!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (Convert.ToInt32(qty.Text) != iQty + Convert.ToInt32(txtFOC.Text))
                    {
                        LblMsg.Text = "FOC Qty is not balanced!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                _clsdao.runSQL("update Temp_Purchase set Qty = " + filterstring(qty.Text) + ",rate=" + filterstring(unitprice.Text)+","
                    +" amount=" + filterstring(amount.Text) + ",foc_qty="+filterstring(txtFOC.Text)+" where session_id = " + filterstring(ReadSession().Sessionid) + ""
                    +" and Id =" + filterstring(GetId().ToString()) + "");

                LblMsg.Text = "Update Sucessfully Done!";
                LblMsg.ForeColor = System.Drawing.Color.Green;                
            }
        }
        private void resetFields()
        {
            txtProduct.Text = "";
            qty.Text = "";
            unitprice.Text = "";
            amount.Text = "";
        }

        protected void qty_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(qty.Text) > Convert.ToInt32(hdnQty.Value))
            {
                txtFOC.Visible = true;
            }
            else
            {
                txtFOC.Visible = false; 
            }
                           
        }
    }
}
