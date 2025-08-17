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

namespace SwiftSalesManagement.Inventory.Item
{
    public partial class BranchProdSetup : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public BranchProdSetup()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                populateDdlbranch();
                if (GetRowId() > 0)
                    populatebranch();
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");

            Product.Text = Getproduct().ToString();
        }

        private string Getproduct()
        {
            return (Request.QueryString["product"] != null ? Request.QueryString["product"].ToString() : "0");
        }
        private long GetProdutId()
        {
            return (Request.QueryString["productId"] != null ? long.Parse(Request.QueryString["productId"]) : 0);
        }
        private long GetRowId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"]) : 0);
        }

        private void populateAllBranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        private void populateDdlbranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches where BRANCH_ID not in (select BRANCH_ID from IN_BRANCH where PRODUCT_ID=" + filterstring(GetProdutId().ToString()) + ")", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }
        
        private void populatebranch()
        {
            populateAllBranch();
            DataTable dt = _clsdao.getTable("exec [proc_in_branch] 's'," + GetRowId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                Product.Text = dr["item_name"].ToString();
                DdlBranch.Text = dr["branch_id"].ToString();
                TxtSalesAcNo.Text = dr["sales_ac"].ToString();
                TxtInventoryAcNo.Text = dr["inventory_ac"].ToString();
                TxtPurchaseAcNo.Text = dr["purchase_ac"].ToString();
                TxtCommisionAcNo.Text = dr["comm_ac"].ToString();
                TxtReorderLevel.Text = dr["REORDER_LEVEL"].ToString();
                DdlIsActive.Text = dr["IS_ACTIVE"].ToString();
                txtReorderQty.Text = dr["REORDER_QTY"].ToString();
                txtMaxHoldingQty.Text = dr["MAX_HOLDING_QTY"].ToString();
                DdlBranch.Enabled = false;

            }
        }
        private void managebranchproduct()
        {
            long productid = GetProdutId(); 
            long rowid = GetRowId();
            string strflag = "";
            if (rowid > 0)
                strflag = "u";
            else
                strflag = "i";
            _clsdao.runSQL("exec proc_in_branch @flag=" + filterstring(strflag) + ",@id=" + filterstring(rowid.ToString()) + ","
            + " @user=" + filterstring(ReadSession().UserId) + ",@sales_ac=" + filterstring(TxtSalesAcNo.Text) + ","
            + " @purchase_ac=" + filterstring(TxtPurchaseAcNo.Text) + ",@inventory_ac=" + filterstring(TxtInventoryAcNo.Text) + ","
            + " @comm_ac=" + filterstring(TxtCommisionAcNo.Text) + ",@branchid=" + filterstring(DdlBranch.Text) + ","
            + " @productid=" + filterstring(productid.ToString()) + ",@reorderlever=" + filterstring(TxtReorderLevel.Text) + ","
            + " @isactive=" + filterstring(DdlIsActive.Text) + ",@REORDER_QTY="+filterstring(txtReorderQty.Text)+","
            + " @MAX_HOLDING_QTY="+filterstring(txtMaxHoldingQty.Text)+"");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managebranchproduct();
                Response.Redirect("EditProductList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
