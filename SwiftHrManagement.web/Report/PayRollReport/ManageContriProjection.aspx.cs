using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class ManageContriProjection : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageContriProjection()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetFlag() == "IPR")
                {
                    txtEmpId.Text = CLsDAo.GetSingleresult("select dbo.GetEmployeeInfoById(" + filterstring(ReadSession().Emp_Id.ToString()) + ")");
                    txtEmpId.Enabled = false;
                }

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 96) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 71) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
            }
        }

        private void PopulateDropdownList()
        {
            //CLsDAo.CreateDynamicDDl(DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");

            DdlYear.SelectedValue = CLsDAo.GetSingleresult("SELECT FISCAL_YEAR_NEPALI FROM FiscalYear WHERE FLAG='1'");
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string[] a = txtEmpId.Text.Split('|');
            string empId = a[1];
            Response.Redirect("ContriProjectionReport.aspx?year=" + DdlYear.Text + "&empid=" + empId + "&amt1="+txtAmount1.Text+"&amt2="+txtAmount2.Text+"&amt3="+txtAmount3.Text+"");
        }

        public string GetFlag()
        {
            return (Request.QueryString["FLAG"] == null ? "" : Request.QueryString["FLAG"].ToString());
        }
    }
}
