using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Contribution_Projection_Report
{
    public partial class ManageContributionProjection : BasePage
    {
        clsDAO CLsDAo = null;
        LoanAndadvence _ContributionProjection = null;
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        public ManageContributionProjection()
        {
            this.CLsDAo = new clsDAO();
            this._ContributionProjection = new LoanAndadvence();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 71) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        protected void BtnShowReport_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _ContributionProjection.FindContributionProjectionReport(DdlFiscalYear.Text, DdlMonth.Text, DdlBranchType.Text,DdlDepartment.Text,DdlEmployee.Text).ToString();
            Response.Redirect("ContributionProjectionReport.aspx?fiscalyear=" + DdlFiscalYear.Text + "&month=" + DdlMonth.Text + "&branchid=" + DdlBranchType.Text+"&DeptId="+DdlDepartment.Text+"&EmpId="+DdlEmployee.Text );

        }

        private void populateDdl()
        {

           
            CLsDAo.setDDL(ref DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartment.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchType.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            } 

        }

        protected void DdlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmployee.Items.Clear();
            if (DdlBranchType.Text != "" && DdlDepartment.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmployee, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchType.Text + " AND DEPARTMENT_ID=" + DdlDepartment.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "Select");
            }

        }
    }
}
