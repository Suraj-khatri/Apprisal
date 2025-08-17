using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Inventory
{
    public partial class SearchInventoryExpenses : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public SearchInventoryExpenses()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            AutoCompleteExtender1.ContextKey = ReadSession().Branch_Id.ToString();
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 147) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (ReadSession().UserType == "A")
                {
                    _clsdao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All Branches");
                    _clsdao.CreateDynamicDDl(DdlBranchName3, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All Branches");
                }
                else
                {
                    _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All Branches");
                    _clsdao.CreateDynamicDDl(DdlBranchName3, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All Branches");
                }
               
            }            
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID='" + DdlBranchName.Text + "' order by DEPARTMENT_NAME", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All Departments");
            }
        }
    }
}
