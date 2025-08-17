using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class IndividualTaxReport : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              if (_roleMenuDao.hasAccess(ReadSession().AdminId, 77) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }

        private void PopulateDropdownList()
        {
            _clsDao.CreateDynamicDDl(DdlMonthName, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            _clsDao.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");

            DdlYear.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpTaxDetail.aspx?year=" + DdlYear.Text + "&month="+ DdlMonthName.Text + "&empid="+ ReadSession().Emp_Id);      
        }

        
    }
}
