using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using SwiftHrManagement.ReportEnging.EmployeeMovements;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.EmployeeMovements
{
    public partial class WorkHistory : BasePage
    {
        EmployeePastWorkHistory _pastWorkHistory = null;
        public WorkHistory()
        {
            this._pastWorkHistory = new EmployeePastWorkHistory();
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
          
            Response.Redirect("WorkHistoryReport.aspx?EmpId=" + Int16.Parse(DdlEmpName.SelectedValue));
        }
    }
}
