using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class Manage_Inv_consolidated : BasePage
    {
        clsDAO CLsDAo = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 59) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }

        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            DdlYear.SelectedValue = CLsDAo.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }

        protected void BtnSalary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inv_consolidated_report.aspx?year=" + DdlYear.Text + "&empid=" + ReadSession().Emp_Id + "");
        }
    }
}
