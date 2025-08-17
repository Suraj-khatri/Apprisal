using System;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ManageMonthEndReport : BasePage
    {
        ClsDAOInv _clsdao = new ClsDAOInv();       
        protected void Page_Load(object sender, EventArgs e)
        {
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            if (!Page.IsPostBack)
            {
                PopulateDdl();
            }
        }

        private void PopulateDdl()
        {
            if (ReadSession().UserType == "A")
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(BRANCH_NAME, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All");
                _clsdao.CreateDynamicDDl(BRANCH_NAME1, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            }
            else
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(BRANCH_NAME, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "All");
                _clsdao.CreateDynamicDDl(BRANCH_NAME1, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            }
            _clsdao.CreateDynamicDDl(FY_Year, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            FY_Year.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }
    }
}