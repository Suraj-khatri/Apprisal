using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingParticipants
{
    public partial class Manage : BasePage
    {
        TrainingListDAO _TListdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        EmployeeDAO _empdao = null;
        TrainingParticipantsDAO _TrnPartdao = null;
        TrainingParticipantsCore _TPcore = null;
        TrainingProgramDAO _trainProgramDao = null;
        TrainingProgramCore _trainProgramCore = null;
        clsDAO CLsDAo = null;

        public Manage()
        {
            CLsDAo = new clsDAO();
            _TListdao = new TrainingListDAO();
            _roleMenuDao = new RoleMenuDAOInv();
            _TPcore = new TrainingParticipantsCore();
            _TrnPartdao = new TrainingParticipantsDAO();
            _empdao = new EmployeeDAO();
            this._trainProgramCore = new TrainingProgramCore();
            this._trainProgramDao = new TrainingProgramDAO();
        }

        private long GetJobTrainigParticipantId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetProgramId()
        {
            return (Request.QueryString["ProgramId"] != null ? long.Parse(Request.QueryString["ProgramId"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 42) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                getProgramInfo();
                CLsDAo.CreateDynamicDDl(DdlReqWithBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
                if (GetJobTrainigParticipantId() > 0)
                {
                    PouplateDdlList();
                    populateTrainingParticipants();                   
                    Btn_Update.Visible = true;
                    Btn_Save.Visible = false;
                    ChkApprove.Enabled = true;
                    Btn_Delete.Visible = true;
                }
                else
                {
                    ChkApprove.Enabled = false;
                    Btn_Update.Visible = false;
                    Btn_Delete.Visible = false;
                }
            }
        }
        private void PouplateDdlList()
        {
            CLsDAo.CreateDynamicDDl(DdlReqByDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
        
            this.populateDdl1();
        }
        private void populateTrainingParticipants()
        {
            DataTable dt = new DataTable();
           
            dt = CLsDAo.getDataset("SELECT TP.ID,TL.TRAINING_NAME,TM.TRAINING_PROGRAM_TITLE,TP.STAFF_ID,E.BRANCH_ID,E.DEPARTMENT_ID,TP.IS_APPROVED FROM"
              + " TrainingParticipants TP WITH(NOLOCK) INNER JOIN TrainingProgram TM WITH(NOLOCK) ON TP.TRAINING_PROGRAM_ID=TM.ID INNER JOIN TrainingList TL"
              + " WITH(NOLOCK) ON TL.ID=TM.TRAINING_ID INNER JOIN Employee E WITH(NOLOCK) ON E.EMPLOYEE_ID=TP.STAFF_ID WHERE TP.ID='" + GetJobTrainigParticipantId() + "'").Tables[0];
     
            foreach (DataRow dr in dt.Rows)
            {
                this.TxtTrainProgramTitle.Text = dr["TRAINING_PROGRAM_TITLE"].ToString();
                this.DdlStaffName.Text = dr["STAFF_ID"].ToString();
                this.DdlReqByDept.Text = dr["DEPARTMENT_ID"].ToString();
                this.DdlReqWithBranch.Text = dr["BRANCH_ID"].ToString();
                this.TxtTrainingCategoryTitle.Text = dr["TRAINING_NAME"].ToString();

                if (bool.Parse(dr["IS_APPROVED"].ToString()) == true)
                    ChkApprove.Checked = true;
                else
                    ChkApprove.Checked = false;
            }
        }

        private void prepareTrainingParticipants()
        {
            TrainingParticipantsCore _TPcore = new TrainingParticipantsCore();
            long Id = this.GetJobTrainigParticipantId();
            if (Id > 0)
            {
                _TPcore.Id = Id;
            }
            _TPcore.TrainingProgramId = GetProgramId().ToString();
            _TPcore.StaffId = DdlStaffName.Text;

            if (ChkApprove.Checked == true)
            {
                _TPcore.IsApproved = true;
            }
            else
            {
                _TPcore.IsApproved = false;
            }
            this._TPcore = _TPcore;
        }
        private void populateDdl1()
        {
            this.populateDblStaff();
        }
        private void populateDblStaff()
        {
            EmployeeDAO _empDao = new EmployeeDAO();
            List<Employee> _emplist = _empDao.FindFullName();
            if (_emplist != null && _emplist.Count > 0)
            {
                Employee empCore = new Employee();
                empCore.EmpName = "Select";
                _emplist.Insert(0, empCore);
                this.DdlStaffName.DataSource = _emplist;
                this.DdlStaffName.DataTextField = "EmpName";
                this.DdlStaffName.DataValueField = "Id";
                this.DdlStaffName.DataBind();
                this.DdlStaffName.SelectedIndex = 0;
            }
        }
        private void manageTrainingParticipantsPlan()
        {
            long id = this.GetJobTrainigParticipantId();
            this.prepareTrainingParticipants();
            if (id > 0)
            {
                this._TPcore.ModifyBy = this.ReadSession().UserId;
                this._TrnPartdao.Update(this._TPcore);
            }
            else
            {
                this._TPcore.CreatedBy = this.ReadSession().UserId;
                this._TrnPartdao.Save(this._TPcore);
            }
        }
        private void getProgramInfo()
        {
            this._trainProgramCore = this._trainProgramDao.FindByTrainProgramId(GetProgramId());
            this.TxtTrainProgramTitle.Text = this._trainProgramCore.TrainingProgramTitle;
            this.TxtTrainingCategoryTitle.Text = this._trainProgramCore.TrainingId;
        }
        
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                bool isApproved;
                if (ChkApprove.Checked == true)
                {
                    isApproved = true;
                }
                else
                {
                    isApproved = false;
                }
                string exist = CLsDAo.GetSingleresult("SELECT ID FROM TrainingParticipants WHERE TRAINING_PROGRAM_ID="+filterstring(GetProgramId().ToString())+" AND STAFF_ID="+filterstring(DdlStaffName.Text)+"");
                if (exist != "")
                {
                    LblMsg.Text = "Already Added this employee as a participant! Please add another employee!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    CLsDAo.runSQL(" INSERT INTO TrainingParticipants(TRAINING_PROGRAM_ID,STAFF_ID,IS_APPROVED)VALUES(" + filterstring(GetProgramId().ToString()) + ","
                                    + " " + filterstring(DdlStaffName.Text) + ",'" + isApproved + "')");

                    Response.Redirect("List.aspx?ID=" + GetProgramId() + "");
                }

            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                this._TrnPartdao.DeleteParticipantByID(GetJobTrainigParticipantId());
                Response.Redirect("List.aspx?ID=" + GetProgramId() + "");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DdlReqByDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlReqByDept.Text != "" && DdlReqWithBranch.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlStaffName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE DEPARTMENT_ID=" + this.DdlReqByDept.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void DdlReqWithBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlReqWithBranch.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlReqByDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlReqWithBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckParticipantCapacity() == true)
                {
                    bool isApproved;
                    if (ChkApprove.Checked == true)
                    {
                        isApproved = true;
                    }
                    else
                    {
                        isApproved = false;
                    }
                    CLsDAo.runSQL("UPDATE TrainingParticipants SET STAFF_ID ="+filterstring(DdlStaffName.Text)+",IS_APPROVED ="+filterstring(isApproved.ToString())+" where ID="+filterstring(GetJobTrainigParticipantId().ToString())+"");
                    Response.Redirect("List.aspx?ID=" + GetProgramId() + "");
                }
                else
                {
                    return;
                }
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private bool CheckParticipantCapacity()
        {
            if (ChkApprove.Checked == true)
            {
                _trainProgramCore = _trainProgramDao.FindMaxCapacity(GetProgramId());
                hdnMaxCap.Value = _trainProgramCore.MaximumCapacity;
                _trainProgramCore = _trainProgramDao.FindUsedCapacity(GetProgramId());
                hdnUsedCap.Value = _trainProgramCore.UsedCapacity;
                if (int.Parse(hdnMaxCap.Value) > int.Parse(hdnUsedCap.Value))
                {
                    ChkApprove.Checked = true;
                    return true;
                }
                else
                {
                    ChkApprove.Checked = false;
                    LblMsg.Text = "No. of Participants will not be greater than Maximum Capacity of Program!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?ID=" + GetProgramId() + "");
        }
    }
}


