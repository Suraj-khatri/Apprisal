using System;
using System.Web.UI;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class Manage : Page
    {
        clsDAO CLsDAo = null;

        public Manage()
        {
            this.CLsDAo = new clsDAO();
        }
         
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
            }
        }
        private void populateDdl()
        {
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlMonth, "select Name,Month_Number from MonthList", "Month_Number", "Name", "", "(Only for Deposits)");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");

            CLsDAo.CreateDynamicDDl(DdlFY_ID, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            //CLsDAo.CreateDynamicDDl(Ddl_Month, "select Name,Month_Number from MonthList", "Month_Number", "Name", "", "All");
            CLsDAo.CreateDynamicDDl(Ddl_Branch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(Ddl_Head, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where type_id in (36,38,41)", "ROWID", "DETAIL_TITLE", "", "All");
        }

    
        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartment.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartment, "Exec ProcStaticDataView 's','7'", "ROWID", "DETAIL_TITLE", "", "select");
            } 
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/HeadWise/ManageReprot.aspx?FY=" + DdlFiscalYear.Text + "&branchId=" + DdlBranchType.Text + "&deptId=" + DdlDepartment.Text + "&rptType=" + ddlReport.Text + "");

        }

        protected void BtnDeposit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/HeadWise/Deposits.aspx?FY=" + DdlFiscalYear.Text + "&branchId=" + DdlBranchType.Text + "&deptId=" + DdlDepartment.Text + "&rptType=" + ddlReport.Text + "&month="+DdlMonth.Text+"");
        }

        protected void BtnSearch_Report_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/PayRollReport/HeadWise/ManageReprot.aspx?flag=h&FY=" + DdlFY_ID.Text + "&branchId=" + Ddl_Branch.Text + "&deptId=" + Ddl_Department.Text + "&rptType=" + Ddl_Head.Text + "");
        }

        protected void Ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddl_Department.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(Ddl_Department, "Exec ProcStaticDataView 's','7'", "ROWID", "DETAIL_TITLE", "", "select");
            } 
        }
    }
}
