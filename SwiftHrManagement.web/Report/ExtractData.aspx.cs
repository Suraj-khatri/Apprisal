using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report
{
    public partial class ExtractData : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = new ClsDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 150) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}
                if (ReadSession().UserType == "A")
                {
                    _clsdao.CreateDynamicDDl(branch, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                    _clsdao.CreateDynamicDDl(branchDept, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                    _clsdao.CreateDynamicDDl(branchEmp, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                    _clsdao.CreateDynamicDDl(group, "SELECT id,item_name FROM ASSET_ITEM WHERE is_product=0", "id", "item_name", "", "All");
                }
                else
                {
                    _clsdao.CreateDynamicDDl(branch, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                    _clsdao.CreateDynamicDDl(branchDept, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                    _clsdao.CreateDynamicDDl(branchEmp, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                    _clsdao.CreateDynamicDDl(group, "SELECT id,item_name FROM ASSET_ITEM WHERE is_product=0", "id", "item_name", "", "Select");
                }

            }
        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "exec proc_extractData @flag='branch',@branchId="+filterstring(branch.Text)+"";
            Response.Redirect("ExportToExcel/ExportExcel.aspx");
        }

        protected void btnDept_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = " exec proc_extractData @flag='dept',@branchId=" + filterstring(branchDept.Text) + "";
            Response.Redirect("ExportToExcel/ExportExcel.aspx");
        }

        protected void btnAssetType_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "proc_extractData @flag='assetType',@groupId=" + filterstring(group.Text) + "";
            Response.Redirect("ExportToExcel/ExportExcel.aspx");
        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = " exec proc_extractData @flag='emp',@branchId=" + filterstring(branchEmp.Text) + "";
            Response.Redirect("ExportToExcel/ExportExcel.aspx");
        }
    }
}