using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class ManageEmpRecordHistory : BasePage
    {        
        public ManageEmpRecordHistory()
        {            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            populateDdlEmp();
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
        protected void BtnViewRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeHistory.aspx?EmpId=" + long.Parse(DdlEmpName.SelectedValue));
        }
    }
}
