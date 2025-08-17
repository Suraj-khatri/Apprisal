using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Item
{
    public partial class ProductSetup : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public ProductSetup()
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
                string group_id = GetGroupId().ToString();

                LblProduct.Text = _clsdao.GetSingleresult("select item_name from IN_ITEM where id=" + GetGroupId() + "");

                if (GetProductId() > 0)
                {
                    populateproduct();
                }
            }
        }

        private long GetProductId()
        {
            return (Request.QueryString["product_id"] != null ? long.Parse(Request.QueryString["product_id"]) : 0);
        }
        private long GetItemId()
        {
            return (Request.QueryString["item_id"] != null ? long.Parse(Request.QueryString["item_id"]) : 0);
        }
        private long GetGroupId()
        {
            return (Request.QueryString["group_id"] != null ? long.Parse(Request.QueryString["group_id"]) : 0);
        }


        private void manageproduct()
        {
            int itemId = (Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"].ToString()) : 0);
            ParentID.Value = GetGroupId().ToString();
            string strflag;
            long rowid = GetProductId();

            if (rowid > 0)
                strflag = "u";
            else
                strflag = "i";

            string SQL = "exec Proc_In_ProductSetup '" + strflag + "'," + rowid + ",'" + ReadSession().UserId + "','" + TxtProductCode.Text + "','" + itemId + "',"
            + " '" + TxtProductDesc.Text + "','" + DdlTangible.Text + "','" + TxtPackageUnit.Text + "','" + DdlBatchCondtn.Text + "','" + DdlIsSerialed.Text + "','" + DdlIsActive.Text + "','" + TxtSalesTolPlus.Text + "','" + TxtSalesTolmin.Text + "',"
            + " '" + TxtPurTolPlus.Text + "','" + TxtPurTolmin.Text + "','" + TxtExtFld1.Text + "','" + TxtExtFld2.Text + "','" + TxtSingleUnit.Text + "',"
            + " '" + TxtUnitDiscount.Text + "','" + TxtBulkDiscount.Text + "','" + TxtConversionRate.Text + "','" + TxtPurchaseBasePrice.Text + "','" + TxtSalesBasePrice.Text + "',"
            + " '" + TxtModel.Text + "','" + TxtMake.Text + "', @parentid='" + ParentID.Value + "'";

            string Msg = _clsdao.GetSingleresult(SQL);
            LblMsg.Text = Msg;
            LblMsg.ForeColor = System.Drawing.Color.Green;
            LblMsg.Focus();
        }
        private void populateproduct()
        {
            string SQL = "exec Proc_In_ProductSetup 's',@id=" + GetProductId();
            DataTable dt = _clsdao.getTable(SQL);
            foreach (DataRow dr in dt.Rows)
            {
                lblProdCode.Text = GetProductId().ToString();
                rptCode.Visible = true;
                TxtProductCode.Text = dr["porduct_code"].ToString();
                TxtProductDesc.Text = dr["product_desc"].ToString();
                TxtPackageUnit.Text = dr["package_unit"].ToString();
                DdlIsActive.Text = dr["is_active"].ToString();
                DdlIsSerialed.Text = dr["serial_no"].ToString();
                DdlTangible.Text = dr["is_tangible"].ToString();
                DdlBatchCondtn.Text = dr["batch_condition"].ToString();

                TxtSalesTolmin.Text = dr["sales_tolerence_minus"].ToString();
                TxtSalesTolPlus.Text = dr["sales_tolerence_plus"].ToString();
                TxtPurTolmin.Text = dr["purchase_tolerence_minus"].ToString();
                TxtPurTolPlus.Text = dr["purchase_tolerence_plus"].ToString();
                TxtExtFld2.Text = dr["ext_fld2"].ToString();
                TxtExtFld1.Text = dr["ext_fld1"].ToString();
                TxtPurchaseBasePrice.Text = dr["purchase_base_price"].ToString();

                TxtSalesBasePrice.Text = dr["sales_base_price"].ToString();
                TxtConversionRate.Text = dr["conversion_rate"].ToString();
                TxtBulkDiscount.Text = dr["unit_discount"].ToString();
                TxtUnitDiscount.Text = dr["purchase_base_price"].ToString();
                TxtMake.Text = dr["make"].ToString();
                TxtSingleUnit.Text = dr["single_unit"].ToString();
                TxtModel.Text = dr["model"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                manageproduct();
                TxtProductCode.Text = "";
                TxtProductDesc.Text = "";
                TxtProductCode.Focus();
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='product',@ID=" + GetProductId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
            if (msg.Contains("SUCCESS"))
            {
                LblMsg.Text = msg;
                TxtPackageUnit.Text = "";
                TxtProductCode.Text = "";
                TxtProductDesc.Text = "";
            }
            else
            {
                LblMsg.Text = msg;
                return;
            }
        }
    }
}
