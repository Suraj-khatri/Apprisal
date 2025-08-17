using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.AssetParameters.BranchAssignGroup
{
    public partial class BranchAssignGroupWise :BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public BranchAssignGroupWise()
        {
            _clsdao = new ClsDAOInv();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 138) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateddl();
            }

        }
        public void populateddl()
        {
            _clsdao.CreateDynamicDDl(DdlGroup, "select id,item_name from ASSET_ITEM where id in(select distinct(parent_id) from ASSET_ITEM where is_product='1')", "id", "item_name", "", "Select");
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID,BRANCH_NAME from Branches where 1=1", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            managebranchwiseproduct();
        }
        private void managebranchwiseproduct()
        {
            string msg = _clsdao.GetSingleresult("Exec [ProcManageAssetBranchLinkage] "
                        + "  @FLAG='a'"
                        + " ,@BRANCH_ID=" + filterstring(DdlBranch.Text) + ""
                        + " ,@GROUP_ID=" + filterstring(DdlGroup.Text) + ""
                        + " ,@AEET_TYPE=" + filterstring(assetType.Text) + ""
                        + " ,@ASSET_AC=" + filterstring(TxtAssetAcNo.Text) + ""
                        + " ,@DEP_AC=" + filterstring(TxtDepExpAcNo.Text) + ""
                        + " ,@ACC_DEP_AC=" + filterstring(TxtWriteOffAcNo.Text) + ""
                        + " ,@WRITEOFF_AC=" + filterstring(TxtAccuDepAcNo.Text) + ""
                        + " ,@PROFIT_LOSS_AC=" + filterstring(TxtMaintainExpAcNo.Text) + ""
                        + " ,@MAINTENANCE_AC = " + filterstring(TxtSalesPLAcNo.Text) + ""
                        + " ,@IS_ACTIVE=" + filterstring(DdlIsActive.Text) + ""
                        + " ,@USER=" + filterstring(ReadSession().UserId) + "");
            
            LblMsg.Text = msg;
            LblMsg.ForeColor = System.Drawing.Color.Red;

        }

        protected void DdlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlGroup.Text != "")
                _clsdao.CreateDynamicDDl(assetType, "select id,porduct_code from ASSET_PRODUCT with(nolock) where item_id in(select id from ASSET_ITEM with(nolock) where parent_id='" + DdlGroup.Text + "')", "id", "porduct_code", "", "Select");
            else
                assetType.Text = "";
        }
 
    }
}
