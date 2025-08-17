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
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Training
{
    public partial class ManageUpcomingRunningTraining : BasePage
    {

        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ManageUpcomingRunningTraining()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTrainingProgramDdl();

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 83) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }            
        }

        protected void DdlProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateTrainingProgramDdl()
        {

            TrainingProgramDAO _tProgramDao = new TrainingProgramDAO();
            List<TrainingProgramCore> programList = _tProgramDao.FindTrainingProgramByBranch(this.ReadSession().Branch_Id);
            if (programList != null && programList.Count > 0)
            {
                TrainingProgramCore _trainingProgramCore = new TrainingProgramCore();
                _trainingProgramCore.TrainingProgramTitle = "Select";
                programList.Insert(0, _trainingProgramCore);
                this.DdlProgramName.DataSource = programList;
                this.DdlProgramName.DataTextField = "TrainingProgramTitle";
                this.DdlProgramName.DataValueField = "Id";
                this.DdlProgramName.DataBind();
                this.DdlProgramName.SelectedIndex = 0;
            }
        }  
        protected void RdbplannedRunning_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            String trainingType = "";
            if (RdbplannedRunning.SelectedValue == "Running")
            {
                trainingType = "Running";
            }
            else
            {
                trainingType = "Planned";
            }
            TrainingProgramUpComingOrPlanned _trainingprog = new TrainingProgramUpComingOrPlanned();
            ReadSession().RptQuery = _trainingprog.UpcomingorPlannedTraining(this.ReadSession().Branch_Id.ToString(), DdlProgramName.Text, trainingType);
            Response.Redirect("UpcomongOrPlannedTrainingrpt.aspx");            
        }
    }
}
