using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Inventory
{
    public partial class SearchStockReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = new ClsDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {            
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            txtProductName_AutoCompleteExtender.ContextKey = ReadSession().Branch_Id.ToString();
            AutoCompleteExtender1.ContextKey = ReadSession().Branch_Id.ToString();
            AutoCompleteExtender2.ContextKey = ReadSession().Branch_Id.ToString();
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 146) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateDdl();
            }
        }
        private void populateDdl()
        {
            if (ReadSession().UserType == "A")
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All");
                _clsdao.CreateDynamicDDl(ddlBranch, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(branch, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchNameVen, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(ddlBranchName1, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All");
            }
            else
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "");
                _clsdao.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(branch, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchNameVen, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(ddlBranchName1, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            }                  

        }
        protected void BtnVendorWiseReport_Click(object sender, EventArgs e)
        {
            if (txtVendor.Text == "")
            {
                hdnVendorId.Value = "";
            }
            if (txtProductNameV.Text == "")
            {
                hdnProductId1.Value = "";
            }
            Response.Redirect("PurchaseVendorWise.aspx?Vendor=" + hdnVendorId.Value + "&Product=" + hdnProductId1.Value+"&branch="+DdlBranchNameVen.Text+"");
        }

        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "")
            {
                product.Value = "";
            }
            Response.Redirect("ExportStockDateWiseReport.aspx?From=" + txtFromDate.Text + "&To=" + txtToDate.Text + "&Branch=" + ddlBranch.Text + "&Product=" + product.Value);
        }
    }
}
