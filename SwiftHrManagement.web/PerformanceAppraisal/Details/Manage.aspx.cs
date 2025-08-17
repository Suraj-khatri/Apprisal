using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.PerformanceAppraisal.Detail;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.Details
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalDetailCore _appraisalCore = null;
        AppraisalDetailDao _appraisalDao = null;
        clsDAO CLSDao = null;
        public Manage()
        {
            CLSDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            _appraisalCore = new AppraisalDetailCore();
            _appraisalDao = new AppraisalDetailDao();
        }

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    if (GetEmpId() == 0) //check the user weather user is logged in or not
        //    {
        //        this.Page.MasterPageFile = "~/SwiftHRManager.Master";
        //    }
        //    else
        //    {
        //        this.Page.MasterPageFile = "~/ProjectMaster.Master";

        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            var trainingIds = (Request.Form["trainingIds"] ?? "");
            SalaryDetail.Visible = false;

            if (!IsPostBack)
            {
                //if (_roleMenuDao.hasAccess(ReadSession().AdminId, 27) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 25) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}

                txtSelfDays.Text = "5";
                txtSupDays.Text = "5";
                txtRevDays.Text = "5";

                if (this.GetAppraisalId() > 0)
                {
                    BtnDelete.Visible = true;
                    populateAppraisal();
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }

            if (GetFlag().ToLower() == "i")
            {
                BtnBack.Visible = false;
                BtnDelete.Visible = false;
                BtnSave.Visible = false;
                TxtTrainingRecord.Enabled = false;
                TxtTransferRecord.Enabled = false;
                TxtPromotionRecord.Enabled = false;
                TxtNotesonfile.Enabled = false;
                TxtTodate.Enabled = false;
                //DdlPositionAtAppointment.Enabled = false;
                TxtPrbPrdFromDate.Enabled = false;
                TxtDateOfAppoinment.Enabled = false;
                TxtEffectiveDate.Enabled = false;
                //txtChiew.Enabled = false;
                txtSup.Enabled = false;
                txtEmp.Enabled = false;
                DdlBranchName.Enabled = false;
                DdlCurrentPosition.Enabled = false;
                DdlPositionAtAppointment.Enabled = false;
                TxtPrbPrdToDate.Enabled = false;
                DdlDeptName.Enabled = false;
                TxtFromDate.Enabled = false;
            }
        }

        protected long GetAppraisalId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected long Getmasterpage()
        {
            return (Request.QueryString["masterpage"] != null ? long.Parse(Request.QueryString["masterpage"].ToString()) : 0);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Getmasterpage() == 0)
            {
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
            }
            else
            {
                this.Page.MasterPageFile = "~/ProjectMaster.Master";
            }
        }

        private void getPopulateDataByEmpID()
        {
            CLSDao.CreateDynamicDDl(DdlCurrentPosition, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", "DETAIL_TITLE", "");
            CLSDao.CreateDynamicDDl(DdlPermanentPosition, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", "DETAIL_TITLE", "");
            CLSDao.CreateDynamicDDl(DdlPositionAtAppointment, " Exec procManageAppraisal 'AP',@EmpId= '" + hdnEmpId.Value + "'", "POSITION_ID", "POSITION", "POSITION", "Select");
            //CLSDao.CreateDynamicDDl(DdlPositionAtAppointment, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", "DETAIL_TITLE", "");
            DataSet ds = CLSDao.getDataset("Exec procManageAppraisal 's',@EmpId=" + filterstring(hdnEmpId.Value) + "");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                TxtDateOfAppoinment.Text = dr["APPOINTMENT_DATE"].ToString();
                //TxtPrbPrdFromDate.Text   = dr["ProbationPeriodFrom"].ToString();
                //TxtPrbPrdToDate.Text     = dr["ProbationPeriodTo"].ToString();
                TxtEffectiveDate.Text = dr["permanent_date"].ToString();
                TxtAcademicQualification.Text = dr["DEGREE"].ToString();
            }

            DataTable dt1 = ds.Tables[1];
            var str1 = new StringBuilder();

            foreach (DataRow dr in dt1.Rows)
            {
                str1.AppendLine("- " + dr["Description"].ToString() + "");
            }
            TxtPromotionRecord.Text = str1.ToString();

            DataTable dt2 = ds.Tables[2];
            var str = new StringBuilder();
            foreach (DataRow dr in dt2.Rows)
            {
                str.AppendLine("- " + dr["TRAINING_PROGRAM_TITLE"].ToString() + "");
            }
            TxtTrainingRecord.Text = str.ToString();

            DataTable dt3 = ds.Tables[3];
            var str2 = new StringBuilder();
            foreach (DataRow dr in dt3.Rows)
            {
                str2.AppendLine("- " + dr["TransferDetail"].ToString() + "");
            }
            TxtTransferRecord.Text = str2.ToString();

            DataTable dt4 = ds.Tables[4];
            foreach (DataRow dr in dt4.Rows)
            {
                lblBasicSalary.Text = dr["Basic_sal"].ToString();
                lblGrade.Text = dr["Grade"].ToString();
                lblTotalBasicSalary.Text = dr["total_basic"].ToString();
                lblOtherAllowance.Text = dr["gen_all"].ToString();
                lblGrossSalary.Text = dr["gross"].ToString();
            }
        }

        private void populateAppraisal()
        {

            DataTable dt = CLSDao.getDataset("Exec procManageAppraisal 'a',@rowId=" + filterstring(GetAppraisalId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {               

                hdnEmpId.Value = dr["EMPLOYEE_ID"].ToString();
                CLSDao.setDDL(ref DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", dr["BRANCH_ID"].ToString(), "Select");
                LoadDepartment(dr["BRANCH_ID"].ToString(), dr["DEPARTMENT_ID"].ToString());
                //CLSDao.setDDL(ref DdlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + filterstring(dr["BRANCH_ID"].ToString()) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", dr["DEPARTMENT_ID"].ToString(), "Select");
                //CLSDao.CreateDynamicDDl(DdlEmp, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee", "EMPLOYEE_ID", "EmpName", dr["EMPLOYEE_ID"].ToString(), "Select");
                CLSDao.CreateDynamicDDl(DdlCurrentPosition, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", dr["POSITION_ID"].ToString(), "");
                CLSDao.CreateDynamicDDl(DdlPermanentPosition, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", dr["Permanent_Position"].ToString(), "");
                //CLSDao.CreateDynamicDDl(DdlPositionAtAppointment, "select  e.POSITION_ID, s.DETAIL_TITLE from Employee e inner join (select * from  StaticDataDetail where TYPE_ID=4) s on s.ROWID = e.POSITION_ID WHERE e.EMPLOYEE_ID = '" + hdnEmpId.Value + "'", "POSITION_ID", "DETAIL_TITLE", dr["Appointment_Position"].ToString(), "");
                CLSDao.CreateDynamicDDl(DdlPositionAtAppointment, "Exec procManageAppraisal 'AP',@EmpId= '" + hdnEmpId.Value + "'", "POSITION_ID", "POSITION", dr["Appointment_Position"].ToString(), "");

                TxtFromDate.Text = dr["FROM_DATE"].ToString();
                TxtTodate.Text = dr["TO_DATE"].ToString();
                TxtDateOfAppoinment.Text = dr["Appointment_Date"].ToString();
                TxtPrbPrdFromDate.Text = dr["Probation_Period_From"].ToString();
                TxtPrbPrdToDate.Text = dr["Probation_Period_To"].ToString();
                TxtEffectiveDate.Text = dr["Effective_Date"].ToString();
                TxtAcademicQualification.Text = dr["Academic_Qualification"].ToString();

                lblBasicSalary.Text = dr["Basic_Salary"].ToString();
                lblGrade.Text = dr["Grade"].ToString();
                lblGrossSalary.Text = dr["grossSalary"].ToString();
                lblOtherAllowance.Text = dr["Other_Allowance"].ToString();
                lblTotalBasicSalary.Text = dr["total_basic"].ToString();

                TxtTransferRecord.Text = dr["Transfer_Record"].ToString();
                TxtTrainingRecord.Text = dr["Training_Record"].ToString();
                TxtPromotionRecord.Text = dr["Promotion_Record"].ToString();
                TxtNotesonfile.Text = dr["Notes_on_file"].ToString();
                txtEmp.Text = dr["self_name"].ToString();
                txtSup.Text = dr["supervisor_name"].ToString();
                //txtChiew.Text = dr["chief"].ToString();
                txtReviewer.Text = dr["reviewer_name"].ToString();
                txtSelfDays.Text = dr["self_deadline"].ToString();
                txtSupDays.Text = dr["appraisal_deadline"].ToString();
                txtRevDays.Text = dr["reviewer_deadline"].ToString();

                txtEmp.Enabled = false;
                txtReviewer.Enabled = true;
                txtSup.Enabled = true;
                //txtChiew.Enabled = false;

            }


        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetAppraisalId() > 0)
                {
                    string[] arraySupervisorId = txtSup.Text.Split('|');
                    string[] arrayReviewer = txtReviewer.Text.Split('|');

                    string supervisorId = arraySupervisorId[1];
                    string reviewerId = arrayReviewer[1];

                    CLSDao.runSQL("Exec procManageAppraisal @flag='u',@empId=" + filterstring(hdnEmpId.Value) + ",@rowId='" + GetAppraisalId() + "',"
                            + " @fromDate=" + filterstring(TxtFromDate.Text) + ",@toDate=" + filterstring(TxtTodate.Text) + ",@Appointment_Date=" + filterstring(TxtDateOfAppoinment.Text) + ",@Academic=" + filterstring(TxtAcademicQualification.Text) + ","
                            + " @Appointment_Position=" + filterstring(DdlPositionAtAppointment.Text) + ",@Probation_Period_From=" + filterstring(TxtPrbPrdFromDate.Text) + ",@Probation_Period_To =" + filterstring(TxtPrbPrdToDate.Text) + ","
                            + " @Permanent_Position =" + filterstring(DdlPermanentPosition.Text) + ",@Effective_Date =" + filterstring(TxtEffectiveDate.Text) + ",@Basic_Salary  ='" + lblBasicSalary.Text + "',"
                            + " @Grade =" + filterstring(lblGrade.Text) + ",@Other_Allowance=" + filterstring(lblOtherAllowance.Text) + ",@Transfer_Record=" + filterstring(TxtTransferRecord.Text) + ","
                            + " @Training_Record =" + filterstring(TxtTrainingRecord.Text) + ",@Promotion_Record=" + filterstring(TxtPromotionRecord.Text) + ",@Notes_on_file =" + filterstring(TxtNotesonfile.Text) + ","
                            + " @user='" + ReadSession().Emp_Id + "',@supervisor_id=" + filterstring(supervisorId) + ",@reviewer_id=" + filterstring(reviewerId) + ","
                            + " @selfDays =" + filterstring(txtSelfDays.Text) + ",@supDays=" + filterstring(txtSupDays.Text) + ",@revDays=" + filterstring(txtRevDays.Text) + ",@branchId=" + filterstring(DdlBranchName.Text) + ",@deptId=" + filterstring(DdlDeptName.Text));

                }
                else
                {
                    CLSDao.runSQL("Exec procManageAppraisal @flag='i',@empId=" + filterstring(hdnEmpId.Value) + ",@rowId='" + GetAppraisalId() + "',"
                            + " @fromDate=" + filterstring(TxtFromDate.Text) + ",@toDate=" + filterstring(TxtTodate.Text) + ",@Appointment_Date=" + filterstring(TxtDateOfAppoinment.Text) + ",@Academic=" + filterstring(TxtAcademicQualification.Text) + ","
                            + " @Appointment_Position=" + filterstring(DdlPositionAtAppointment.Text) + ",@Probation_Period_From=" + filterstring(TxtPrbPrdFromDate.Text) + ",@Probation_Period_To =" + filterstring(TxtPrbPrdToDate.Text) + ","
                            + " @Permanent_Position =" + filterstring(DdlPermanentPosition.Text) + ",@Effective_Date =" + filterstring(TxtEffectiveDate.Text) + ",@Basic_Salary  ='" + lblBasicSalary.Text + "',"
                            + " @Grade =" + filterstring(lblGrade.Text) + ",@Other_Allowance=" + filterstring(lblOtherAllowance.Text) + ",@Transfer_Record=" + filterstring(TxtTransferRecord.Text) + ","
                            + " @Training_Record =" + filterstring(TxtTrainingRecord.Text) + ",@Promotion_Record=" + filterstring(TxtPromotionRecord.Text) + ",@Notes_on_file =" + filterstring(TxtNotesonfile.Text) + ","
                            + " @user='" + ReadSession().Emp_Id + "',@supervisor_id=" + filterstring(hdnSupId.Value) + ",@reviewer_id=" + filterstring(hdnReviewerId.Value) + ",@chief_id=" + filterstring(hdnChiefId.Value) + ","
                            + "  @selfDays =" + filterstring(txtSelfDays.Text) + ",@supDays=" + filterstring(txtSupDays.Text) + ",@revDays=" + filterstring(txtRevDays.Text) + ",@branchId=" + filterstring(DdlBranchName.Text) + ",@deptId=" + filterstring(DdlDeptName.Text));
                }
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                clsDAO _clsDao = new clsDAO();
                string msg = _clsDao.GetSingleresult("Exec [procManageAppraisal] @flag='d',@rowId=" + filterstring(GetAppraisalId().ToString()) + "");
                if (msg.Contains("Already"))
                {
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?&masterpage=" + Getmasterpage() + " ");
        }

        private bool CheckForEmployee()
        {

            string empId = hdnEmpId.Value;
            if (empId.Length == 0)
            {
                LblMsg.Text = "Please Select Employee";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else return true;
        }
        protected void txtEmp_TextChanged(object sender, EventArgs e)
        {
            LblMsg.Text = "";
            string empId = hdnEmpId.Value;
            if (CheckForEmployee() == false)
                return;

            DataTable dt = CLSDao.getTable("select BRANCH_ID,DEPARTMENT_ID from Employee where EMPLOYEE_ID=" + filterstring(hdnEmpId.Value));
            if (dt == null || dt.Rows.Count <= 0)
                return;

            DataRow dr = dt.Rows[0];

            CLSDao.setDDL(ref DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", dr["BRANCH_ID"].ToString(), "Select");
            //CLSDao.setDDL(ref DdlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + filterstring(dr["BRANCH_ID"].ToString()) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", dr["DEPARTMENT_ID"].ToString(), "Select");
           LoadDepartment(dr["BRANCH_ID"].ToString(), dr["DEPARTMENT_ID"].ToString());
            //DdlBranchName.Enabled = false;
            //DdlDeptName.Enabled = false;         
            getPopulateDataByEmpID();
        }


        public void LoadDepartment(string branchId, string departMent)
        {
            CLSDao.setDDL(ref DdlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + filterstring(branchId) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", departMent, "Select");
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartment(DdlBranchName.Text, "");
        }
    }
}
