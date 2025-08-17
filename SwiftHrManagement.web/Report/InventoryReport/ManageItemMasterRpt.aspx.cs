using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ManageItemMasterRpt : BasePage
    {
        ClsDAOInv _clsdao = new ClsDAOInv();

        protected void Page_Load(object sender, EventArgs e)
        {
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            if (!Page.IsPostBack)
            {
                if (ReadSession().UserType == "A")
                {
                    _clsdao.CreateDynamicDDl(branchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                    _clsdao.CreateDynamicDDl(fromBranch, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                    _clsdao.CreateDynamicDDl(toBranch, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                }
                else
                {
                    _clsdao.CreateDynamicDDl(branchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                    _clsdao.CreateDynamicDDl(fromBranch, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                    _clsdao.CreateDynamicDDl(toBranch, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                }

            }      
            txtFromDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtToDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        //protected void Btn_Search_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ViewInvMaster.aspx?branchId=" + branchName.Text + "&productId=" + hdnProductId.Value);
        //}
    }
}