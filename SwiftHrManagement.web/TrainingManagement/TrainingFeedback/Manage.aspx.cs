using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingManagement.TrainingFeedback
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;       
        TrainingFeedbackCore _trainFBCore = null;
        TrainingFeedbackDAO _trainFBDao = null;
        TrainingProgramDAO _tProgramDao = null;
        public Manage()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _tProgramDao = new TrainingProgramDAO();
            _trainFBCore = new TrainingFeedbackCore();
            _trainFBDao = new TrainingFeedbackDAO();           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 36) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.PopulateTrainingProgramDdl();                           
            }
        }
        private void PopulateTrainingProgramDdl()
        {

            TrainingProgramDAO _tProgramDao = new TrainingProgramDAO();
            List<TrainingProgramCore> programList = _tProgramDao.FindTrainingProgram(this.ReadSession().Emp_Id);
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
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.manageTrainingFeedback();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void manageTrainingFeedback()
       {
           this.prepareTrainingFeedback();
           this._trainFBCore.CreatedBy = this.ReadSession().UserId;
           this._trainFBDao.Save(this._trainFBCore);         
        }
        private void prepareTrainingFeedback()
        {
            TrainingFeedbackCore _trainingFeedbackCore = new TrainingFeedbackCore();
            _trainingFeedbackCore.TrainingProgramId = DdlProgramName.Text;
            _trainingFeedbackCore.Feedback = TxtFeedback.Text;
            this._trainFBCore = _trainingFeedbackCore;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

    }
}
