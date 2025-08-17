using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingManagement.TrainingProgram
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        TrainingProgramDAO _tProgramDao = null;
        TrainingProgramCore _tProgramCore = null;
        TrainingListDAO _tListDao = null;
        public Manage()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _tProgramDao = new TrainingProgramDAO();
            _tProgramCore = new TrainingProgramCore();
            _tListDao = new TrainingListDAO();
        }
      
        private long GetTProgramID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 42) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.populateDdlList();
                
                if (this.GetTProgramID() > 0)
                {
                    populateTrainingProgram();
                    TxtPStartDate.Enabled = false;
                    TxtPEndDate.Enabled = false;
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                    TxtAEndDate.Enabled = false;
                    TxtAStartDate.Enabled = false;                 
                }
            }
        }
        private void populateTrainingProgram()
        {
            this._tProgramCore = this._tProgramDao.FindById(GetTProgramID());
            this.TxtTProgramTitle.Text = this._tProgramCore.TrainingProgramTitle;
            this.TxtPStartDate.Text = this._tProgramCore.PlannedStartDate;
            this.TxtPEndDate.Text = this._tProgramCore.PlannedEndDate;            
            this.DdlTrainingList.SelectedValue = this._tProgramCore.TrainingId;
            this.TxtAStartDate.Text = this._tProgramCore.ActualStartDate;
            this.TxtAEndDate.Text = this._tProgramCore.ActualEndDate;
            this.TxtMaxiCapacity.Text = this._tProgramCore.MaximumCapacity;
            this.TxtVenue.Text = this._tProgramCore.Venue;
            this.TxtCity.Text = this._tProgramCore.City;
            this.TxtCountry.Text = this._tProgramCore.Country;
            this.TxtNoOfDays.Text = this._tProgramCore.NumberOfDays;
            this.TxtTotHours.Text = this._tProgramCore.TotalHours;
            this.TxtHoursDay.Text = this._tProgramCore.HoursEachDay;
            this.TxtDetailContent.Text = this._tProgramCore.DetailedCourseContents;

            if (_tProgramCore.IsActive == true)
                ChkActive.Checked = true;
            else
                ChkActive.Checked = false;

        }
        private void populateDdlList()
        {
            TrainingListDAO _tListDao = new TrainingListDAO();
            List<TrainingListCore> _Programlist = _tListDao.FindTrainingProgram();            
            if (_Programlist != null && _Programlist.Count > 0)
            {
                TrainingListCore empCore = new TrainingListCore();
                empCore.TrainingName = "Select";
                _Programlist.Insert(0, empCore);
                this.DdlTrainingList.DataSource = _Programlist;
                this.DdlTrainingList.DataTextField = "TrainingName";
                this.DdlTrainingList.DataValueField = "Id";
                this.DdlTrainingList.DataBind();
                this.DdlTrainingList.SelectedIndex = 0;
            }
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.manageTrainingProgram();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void manageTrainingProgram()
        {
            long id = this.GetTProgramID();
            this.prepareTrainingProgram();
            if (id > 0)
            {
                this._tProgramCore.ModifyBy = this.ReadSession().UserId;
                this._tProgramDao.Update(this._tProgramCore);      
            }
            else
            {
                this._tProgramCore.CreatedBy = this.ReadSession().UserId;
                this._tProgramDao.Save(this._tProgramCore);          
            }
        }
        private void prepareTrainingProgram()
        {
            TrainingProgramCore _trainingProgramCore = new TrainingProgramCore();
            long Id = this.GetTProgramID();
            if (Id > 0)
            {
                _trainingProgramCore.Id = Id;
                _trainingProgramCore.ActualStartDate = TxtAStartDate.Text;
                _trainingProgramCore.ActualEndDate = TxtAEndDate.Text;
            }
            else
            {
                _trainingProgramCore.ActualStartDate = TxtPStartDate.Text;
                _trainingProgramCore.ActualEndDate = TxtPEndDate.Text;
            }            
            _trainingProgramCore.TrainingId = DdlTrainingList.Text;
            _trainingProgramCore.TrainingProgramTitle = TxtTProgramTitle.Text;
            _trainingProgramCore.PlannedStartDate = TxtPStartDate.Text;
            _trainingProgramCore.PlannedEndDate = TxtPEndDate.Text;
           
            _trainingProgramCore.MaximumCapacity = TxtMaxiCapacity.Text;
            _trainingProgramCore.Venue = TxtVenue.Text;
            _trainingProgramCore.City = TxtCity.Text;
            _trainingProgramCore.Country = TxtCountry.Text;
            _trainingProgramCore.NumberOfDays = TxtNoOfDays.Text;
            _trainingProgramCore.TotalHours = TxtTotHours.Text;
            _trainingProgramCore.HoursEachDay = TxtHoursDay.Text;
            _trainingProgramCore.DetailedCourseContents = TxtDetailContent.Text;

            if (ChkActive.Checked == true)
            {
                _trainingProgramCore.IsActive = true;
            }
            else
            {
                _trainingProgramCore.IsActive = false;
            }

            this._tProgramCore = _trainingProgramCore;


        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this._tProgramDao.DeleteById(this.GetTProgramID());
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
