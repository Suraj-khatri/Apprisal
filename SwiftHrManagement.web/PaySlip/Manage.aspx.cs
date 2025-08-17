using System;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.PaySlip
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsDao = null;
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployee.ReadOnly = false;
            if (Request.QueryString["flag"] != "hr")
            {
                GetUser();
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["flag"] != "hr")
                {
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 255) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                }
                else 
                {
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 270) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                }

              
                PopulateDropdownList();
            }
        }
        protected  void GetUser()
        {
            txtEmployee.ReadOnly = true;
            //txtEmployee.Text = _clsDao.GetSingleresult("exec proc_GetLeaveData @jobflag = 'SE',@searchEmpBy=" + ReadSession().Emp_Id);
            txtEmployee.Text = _clsDao.GetSingleresult(@" SELECT  FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME + ' -'
                    + EMP_CODE + ' (' + b.BRANCH_NAME + ') ' + '|'
                    + CONVERT(VARCHAR, EMPLOYEE_ID) AS EmployeeName
            FROM    Employee e WITH ( NOLOCK )
                    INNER JOIN Branches b ON e.BRANCH_ID = b.BRANCH_ID
            WHERE   e.EMPLOYEE_ID=" + filterstring(ReadSession().Emp_Id.ToString()));
        }

      

        protected void PopulateDropdownList()
        {
            _clsDao.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            DdlYear.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            _clsDao.CreateDynamicDDl(DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "Select");
        }

        protected void BtnSalary_Click(object sender, EventArgs e)
        {
            var a = txtEmployee.Text.Split('|');
            string empId = a[1];
            Response.Redirect("PaySlip.aspx?year=" + DdlYear.Text + "&month=" + DdlMonth.Text + "&empId="+empId);
        }
    }
}