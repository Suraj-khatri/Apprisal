using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class ManageGratuityReport : BasePage
    {
        clsDAO CLsDAo = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 254) == false)
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

            CLsDAo.CreateDynamicDDl(DdlMonth, "select month_number,Name from monthlist", "month_number", "Name", "", "Select");
        }

        protected void BtnSalary_Click(object sender, EventArgs e)
        {
            Response.Redirect("GratuityReport.aspx?year=" + DdlYear.Text + "&month="+DdlMonth.Text+"");
        }
    }
}