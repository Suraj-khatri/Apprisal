using System;
using SwiftHrManagement.DAL.Payrole;


namespace SwiftHrManagement.web.Payrole_management
{
    public partial class Manage : BasePage
    {
        payroleDAO _payroll = null;
        clsDAO _clsdao = null;
        public Manage()
        {
            _payroll = new payroleDAO();
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateddl();
            }
        }
        private void populateddl()
        {
            _clsdao.setDDL(ref ddlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "");
            _clsdao.CreateDynamicDDl(DdlFY, "SELECT FISCAL_YEAR_NEPALI from FiscalYear where FLAG=1", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "");
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procTaxCalculation @flag='l',@fiscalYear=" + filterstring(DdlFY.SelectedItem.Value) + ""
                +" ,@runMonth=" + filterstring(ddlMonth.SelectedItem.Value.ToString()) + ",@branchid=" + filterstring(DdlBranch.Text) + ""
                + ",@emp_id="+filterstring(ddlEmployee.Text)+",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            lblMes.Text = msg;
            lblMes.ForeColor = System.Drawing.Color.Red;
        }

        protected void DdlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsdao.CreateDynamicDDl(ddlEmployee, "select EMPLOYEE_ID, FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME 'Employee' from Employee where EMPLOYEE_ID <> 1000 and BRANCH_ID = " + filterstring(DdlBranch.Text) + "", "EMPLOYEE_ID", "Employee", "", "Select");
        }
    }
}
