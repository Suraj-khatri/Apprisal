using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ChooseTrainingType : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void selfTraining_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/ListTrainingItems.aspx?Id=" + GetEmpId() + "");
        }

        protected void bankTraining_Click(object sender, EventArgs e)
        {
            TrainingRptDao _trainingByEmp = new TrainingRptDao();
            ReadSession().RptQuery = _trainingByEmp.FindTrainingRptByEmployeeOrDept(GetEmpId().ToString(), "");
            Response.Redirect("/TrainingModule/NORMAL/List.aspx?emp_id="+GetEmpId()+"");
            
        }
    }
}
