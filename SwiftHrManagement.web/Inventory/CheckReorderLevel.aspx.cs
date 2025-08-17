using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Inventory
{
    public partial class CheckReorderLevel : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public CheckReorderLevel()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
           
            //AutoCompleteExtender1.ContextKey = ReadSession().Branch_Id.ToString();
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 148) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                _clsdao.CreateDynamicDDl(vendorName, "SELECT ID,CustomerName FROM Customer WHERE IsActive='Y' ORDER  BY  CustomerName", "ID", "CustomerName", "", "All");
                _clsdao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(branchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                _clsdao.CreateDynamicDDl(DdlBranchName1, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All");
                _clsdao.CreateDynamicDDl(ddlVendorName, "SELECT ID,CustomerName FROM Customer WHERE IsActive='Y' ORDER  BY  CustomerName", "ID", "CustomerName", "", "All");
                _clsdao.CreateDynamicDDl(ddlproductGroup, "SELECT id,item_name FROM IN_ITEM WHERE id IN(SELECT DISTINCT(parent_id) FROM IN_ITEM WHERE is_product='1')", "id", "item_name", "", "All");
               
            }
                   
        }
        protected void ddlproductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlProductName.Items.Clear();
            if (ddlproductGroup.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlProductName, "select id,porduct_code from IN_PRODUCT where item_id in(select id from IN_ITEM where parent_id='" + ddlproductGroup.Text + "')", "id", "porduct_code", "", "All");

            }           
                       
        }
    }
}
