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

namespace SwiftHrManagement.web.Report.Contribution_Report
{
    public partial class ManageContributionReport : BasePage
    {
        clsDAO CLsDAo = null;
        LoanAndadvence _ContributionReport = null;
        public ManageContributionReport()
        {
            this.CLsDAo = new clsDAO();
            this._ContributionReport = new LoanAndadvence();
          
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


            CLsDAo.setDDL(ref DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

        protected void btnsummery_Click(object sender, EventArgs e)
        {

            this.ReadSession().RptQuery = _ContributionReport.FindContributionSummeryReport("s", DdlFiscalYear.Text, DdlMonth.Text, DdlBranchType.Text,DdlDepartment.Text,DdlEmployee.Text).ToString();
            Response.Redirect("ContributionSummery.aspx?fiscalyear=" + DdlFiscalYear.Text + "&month=" + DdlMonth.Text + "&branchid=" + DdlBranchType.Text + "&deptId=" + DdlDepartment.Text + "&empId=" + DdlEmployee.Text);


        }


        protected void BtnViewDetails_Click(object sender, EventArgs e)
        {


            //if (DdlMonth.Text == "")
            //{
            //    Lblmonth.Text = "Required!";
            //    return;

            //}
            if (DdlEmployee.Text == "")
            {
               lblemp.Text = "Required!";
                return;

            }
            this.ReadSession().RptQuery = _ContributionReport.FindContributionDetailsReport("d", DdlFiscalYear.Text, DdlMonth.Text, DdlBranchType.Text,DdlDepartment.Text,DdlEmployee.Text).ToString();
            Response.Redirect("ContributionSummery.aspx?flag='a'&fiscalyear=" + DdlFiscalYear.Text + "&month=" + DdlMonth.Text + "&branchid=" + DdlBranchType.Text+"&deptId="+DdlDepartment.Text+"&empId="+DdlEmployee.Text );


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
