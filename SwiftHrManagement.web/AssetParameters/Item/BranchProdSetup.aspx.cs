using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.AssetParameters.Item
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
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 126) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
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
        private string Getflag()
        {
            return (Request.QueryString["flag"] != null ?Request.QueryString["flag"] : "");
        }


        private void populateAllBranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        private void populateDdlbranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches where BRANCH_ID not in (select BRANCH_ID from ASSET_BRANCH where PRODUCT_ID=" + filterstring(GetProdutId().ToString()) + ")", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }


        private void populatebranch()
        {
            populateAllBranch();
            DataTable dt = _clsdao.getTable("exec [proc_ASSET_branch] 's'," + filterstring(GetRowId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                Product.Text = dr["item_name"].ToString();          
                DdlBranch.Text = dr["branch_id"].ToString();
                TxtAssetAcNo.Text = dr["ASSET_AC"].ToString();
                TxtDepExpAcNo.Text = dr["DEPRECIATION_EXP_AC"].ToString();
                TxtAccuDepAcNo.Text = dr["ACCUMULATED_DEP_AC"].ToString();
                TxtWriteOffAcNo.Text = dr["WRITE_OFF_EXP_AC"].ToString();
                TxtSalesPLAcNo.Text = dr["SALES_PROFIT_LOSS_AC"].ToString();
                TxtMaintainExpAcNo.Text = dr["MAINTAINANCE_EXP_AC"].ToString();
                DdlIsActive.Text = dr["IS_ACTIVE"].ToString();
            }
        }
        private string managebranchproduct()
        {
            long productId = GetProdutId();
            long rowid = GetRowId();
            string strflag = "";
            string saved = "";

            if (rowid > 0)
                strflag = "u";
            else
                strflag = "i";

            string sql = "exec proc_ASSET_branch '" + strflag + "'," + rowid + ",'" + ReadSession().Emp_Id.ToString() + "','" + TxtAssetAcNo.Text + "','" + TxtDepExpAcNo.Text + "',"
                        + "'" + TxtAccuDepAcNo.Text + "','" + TxtWriteOffAcNo.Text + "','" + TxtSalesPLAcNo.Text + "','" + TxtMaintainExpAcNo.Text + "',"
                        + "'" + DdlBranch.SelectedValue + "'," + productId + ",'" + 1 + "','" + DdlIsActive.Text + "'";
            
       

            return saved = _clsdao.GetSingleresult(sql);
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = managebranchproduct();
                if (Getflag() == "a")
                {
                    Response.Redirect("/AssetParameters/BranchAssignGroup/List.aspx");
                    return;
                }
                if (msg.Contains("Success"))
                {
                    Response.Redirect("EditBranchProduct.aspx?product=" + Product.Text + "&productId=" + GetProdutId() + "");
                }

             

                else
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('" + msg + "')</script>");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditBranchProduct.aspx?product=" + Product.Text + "&productId=" + GetProdutId() + "");
        }
    }
}
