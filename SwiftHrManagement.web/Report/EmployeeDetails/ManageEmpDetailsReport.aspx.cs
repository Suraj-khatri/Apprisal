using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class ManageEmpDetailsReport : BasePage
    {
        
        clsDAO _clsDao = null;

        public ManageEmpDetailsReport()
        {
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdlEmp();
                OnPopulateDDL();
            }
        }
        private void populateDdlEmp()
        {
            if (!IsPostBack)
            {
                EmployeeDAO _empDao = new EmployeeDAO();
                List<Employee> _emplist = _empDao.FindFullName();
                this.DdlEmpName.DataSource = _emplist;
                this.DdlEmpName.DataTextField = "EmpName";
                this.DdlEmpName.DataValueField = "Id";
                this.DdlEmpName.DataBind();
                this.DdlEmpName.SelectedIndex = 0;
            }
        }

        private void OnPopulateDDL()
        {
            _clsDao.CreateDynamicDDl(ddlBranch, "select BRANCH_ID,BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }
        protected void BtnSearchBrthday_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBirthdayResult.aspx?from_date="+txtFromDate1.Text+"&to_date="+txtToDate1.Text+"");
        }

        protected void BtnViewEmpHisRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeHistory.aspx?EmpId=" + long.Parse(DdlEmpName.SelectedValue));
        }

        protected void btnSupRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpSupReport.aspx?branch_id=" + ddlBranch.Text + "&dept_id=" + ddlDept.Text + "&flag=a");
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.Text == "")
            {
                ddlBranch.Text = "";
            }
            else
            {
                _clsDao.CreateDynamicDDl(ddlDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + ddlBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = "Exec [procSuperVisorRpt] @FLAG='C',@BRANCH_ID=" + filterstring(ddlBranch.Text) + ",@DEPT_ID=" + filterstring(ddlDept.Text) + "";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void btnSuperRpt_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpSupReport.aspx?branch_id=" + ddlBranch.Text + "&dept_id=" + ddlDept.Text + "&flag=n");
        }

        protected void btnEmpSummaryRpt_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = "Exec [proc_employeeProfileWithEducation] @FLAG='A',@EMP_ID=NULL";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }
    }
}
