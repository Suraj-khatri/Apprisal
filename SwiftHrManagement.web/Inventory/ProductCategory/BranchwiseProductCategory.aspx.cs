using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Inventory.ProductCategory
{
    public partial class BranchwiseProductCategory : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public BranchwiseProductCategory()
        {
            _clsdao = new ClsDAOInv();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 108) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateddl();           
            }
        }
        public void populateddl()
        {
            _clsdao.CreateDynamicDDl(DdlGroup, "select id,item_name from IN_ITEM where id in(select distinct(parent_id) from IN_ITEM where is_product='1')", "id", "item_name", "", "All");
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID,BRANCH_NAME from Branches where 1=1", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            managebranchwiseproduct();
        }
        private void managebranchwiseproduct()
        {           
            string msg=_clsdao.GetSingleresult("Exec ProcBrachAssignment 'a'," + filterstring(DdlBranch.Text) + ","+filterstring(DdlGroup.Text)+","
            + " " + filterstring(TxtInventoryAcNo.Text) + "," + filterstring(TxtPurchaseAcNo.Text) + "," + filterstring(DdlIsActive.Text) + ","
            +" "+filterstring(ReadSession().UserId)+"");
            LblMsg.Text = msg;
            LblMsg.ForeColor = System.Drawing.Color.Red;
            //resetForm();
            //showBranchAssign();
        }
        private void resetForm()
        {
            DdlBranch.Text = "";
            DdlGroup.Text = "";
            TxtPurchaseAcNo.Text = "";
            TxtPurchaseAc.Text = "";
            TxtInventoryAc.Text = "";
            TxtInventoryAcNo.Text = "";
            DdlIsActive.Text = "";
        }
        private void showBranchAssign()
        {

        }
    }
}
