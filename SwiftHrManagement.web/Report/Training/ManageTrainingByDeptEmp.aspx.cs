using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.ReportEnging.TrainingProgram;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Training
{
    public partial class ManageTrainingByDeptEmp : BasePage
    {

        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ManageTrainingByDeptEmp()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 82) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        private void populateDdluser()
        {
            EmployeeDAO _empDao = new EmployeeDAO();
            List<Employee> _employeeList = _empDao.FindFullName();
            if (_employeeList != null && _employeeList.Count > 0)
            {
                Employee _empCore = new Employee();
                _empCore.EmpName = "Select";
                _employeeList.Insert(0, _empCore);
                this.DdlEmpDept.DataSource = _employeeList;
                this.DdlEmpDept.DataTextField = "EmpName";
                this.DdlEmpDept.DataValueField = "Id";
                this.DdlEmpDept.DataBind();
            }
        }
        private void populateDepartment()
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID((ReadSession().Branch_Id));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                this.DdlEmpDept.DataSource = deptlist;
                this.DdlEmpDept.DataTextField = "Deptname";
                this.DdlEmpDept.DataValueField = "Id";
                this.DdlEmpDept.DataBind();
                this.DdlEmpDept.SelectedIndex = 0;
            }
        }
        protected void RdbEmpDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RdbEmpDept.SelectedValue == "Department Wise")
            {
                populateDepartment();
                //HddnDept.Value = DdlEmpDept.Text;
            }
            else if (RdbEmpDept.SelectedValue == "Employee Wise")
            {
                populateDdluser();
                //HddnEmp.Value  = DdlEmpDept.Text;
            }
        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            TrainingProgByEmpOrEmployees _trainingByEmp = new TrainingProgByEmpOrEmployees();
            ReadSession().RptQuery = _trainingByEmp.FindTrainingRptByEmployeeOrDept(HddnEmp.Value, HddnDept.Value);
            Response.Redirect("TrainingByDeptEmp.aspx");
        }

        protected void DdlEmpDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            HddnDept.Value = null;
            HddnEmp.Value = null;
            if (RdbEmpDept.SelectedValue == "Department Wise")
            {                
                HddnDept.Value = DdlEmpDept.Text;
            }
            else if (RdbEmpDept.SelectedValue == "Employee Wise")
            {             
                HddnEmp.Value = DdlEmpDept.Text;
            }

        }
    }
}
