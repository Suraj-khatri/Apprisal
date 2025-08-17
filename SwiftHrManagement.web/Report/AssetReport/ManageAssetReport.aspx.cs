using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class ManageAssetReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = new ClsDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 150) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                _clsdao.CreateDynamicDDl(branchName, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
                _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                _clsdao.CreateDynamicDDl(DdlBranchName2, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                _clsdao.CreateDynamicDDl(ddlBranchName_D, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                _clsdao.CreateDynamicDDl(bName, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                
                _clsdao.CreateDynamicDDl(ddlFY, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
                ddlFY.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
                _clsdao.CreateDynamicDDl(ddlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "ALL");
                _clsdao.CreateDynamicDDl(DdlAssetGroupName, "select id,item_name from ASSET_ITEM where id in(select distinct(parent_id) from ASSET_ITEM where is_product='1')", "id", "item_name", "", "All");
                _clsdao.CreateDynamicDDl(ddlGroupName_D, "select id,item_name from ASSET_ITEM where id in(select distinct(parent_id) from ASSET_ITEM where is_product='1')", "id", "item_name", "", "All");
                _clsdao.CreateDynamicDDl(aGroup, "select id,item_name from ASSET_ITEM where id in(select distinct(parent_id) from ASSET_ITEM where is_product='1')", "id", "item_name", "", "All");
                txtFromDate_D.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtToDate_D.Text = DateTime.Now.ToString("MM/dd/yyyy");
				//_clsdao.CreateDynamicDDl(oldNewAssetNo, "SELECT asset_number FROM  ASSET_INVENTORY with(NOLOCK)", "asset_number", "asset_number", "", "Select");
             }

            string[] data = new string[5];
            data[0] = DdlBranchName.SelectedValue.ToString();
            data[1] = DdlDeptName.SelectedValue.ToString();
            data[2] = DdlAssetGroupName.SelectedValue.ToString();
            data[3] = DdlAssetType.SelectedValue.ToString();            
            data[4] = brandName.Text;

            string passVal = data[0] + ',' + data[1] + ',' + data[2] + ',' + data[3] + ',' + data[4];
            AutoCompleteExtender1.ContextKey = passVal;
        }

        protected void ddlGroupName_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsdao.CreateDynamicDDl(ddlAssetName_D, "select id,porduct_code from ASSET_PRODUCT where item_id in(select id from ASSET_ITEM where parent_id='" + ddlGroupName_D.Text + "')", "id", "porduct_code", "", "All");

        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlDeptName, "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM Departments WHERE BRANCH_ID='" + DdlBranchName.Text + "' ORDER BY DEPARTMENT_NAME", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }

        protected void DdlAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DdlAssetType.Text != "")
            //{
            //    _clsdao.CreateDynamicDDl(DdlAssetNumber, "SELECT asset_number FROM  ASSET_INVENTORY where product_id='" + DdlAssetType.Text + "'and branch_id=" +filterstring( DdlBranchName.Text) + " order by asset_number", "asset_number", "asset_number", "", "Select");
            //}
        }

        protected void DdlAssetGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAssetGroupName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlAssetType, "select id,porduct_code from ASSET_PRODUCT where item_id in(select id from ASSET_ITEM where parent_id='" + DdlAssetGroupName.Text + "')", "id", "porduct_code", "", "All");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            var assetNOType ="n";
            var assetNo = oldNewNo.Text.Split('|')[0];
            var url = "individualAssetDetailRpt.aspx?assetNOType=" + assetNOType +"&assetNo=" + assetNo;
            Response.Redirect(url);
        }

        //protected void ddlAssetNoType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(ddlAssetNoType.Text=="o")
        //    {
        //        _clsdao.CreateDynamicDDl(oldNewAssetNo, "SELECT old_asset_no FROM  ASSET_INVENTORY with(NOLOCK)", "old_asset_no", "old_asset_no", "", "Select");            
        //    }
        //    else
        //    {
        //        _clsdao.CreateDynamicDDl(oldNewAssetNo, "SELECT asset_number FROM  ASSET_INVENTORY with(NOLOCK)", "asset_number", "asset_number", "", "Select");            
              
        //    }
        //}
    }
}
