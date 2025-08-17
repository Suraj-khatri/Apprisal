using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveRecord;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveRequest;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveRecord
{
    public partial class Manage : BasePage
    {
        LeaveRecordDao _leaveRecordDao = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            _leaveRecordDao = new LeaveRecordDao();
            _clsDao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 33) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetLeaveRecordId() > 0)
                {
                    PopulateData();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                if(GetIsMasterPageLessFlag()=="Y")
                {
                    forTada();

                }
            }

        }
        private long GetLeaveRecordId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void LeaveTypesCondition()
        {
            if(GetIsMasterPageLessFlag()=="Y")
            {
                var ds = _leaveRecordDao.SelectLeaveTypesCondition(GetEMPID().ToString(), DdlLeaveName.Text);
                if (ds == null)
                {
                    ResetField();
                    return;
                }

                var dt = ds.Tables[0];
                var dr = dt.Rows[0];
                if (dr == null)
                    return;

                TxtRemainingDays.Text = dr["REMAINLEAVE"].ToString();
                TxtMaxReqDays.Text = dr["Max_req_days"].ToString();
                TxtFromDate.Text = Request.QueryString["from"].ToString() != null
                                      ? (Request.QueryString["from"].ToString())
                                      : "";
                TxtToDate.Text = Request.QueryString["to"].ToString() != null ? (Request.QueryString["to"].ToString()) : "";

                TimeSpan t = DateTime.Parse(TxtToDate.Text) - DateTime.Parse(TxtFromDate.Text);
                this.TxtrequestDays.Text = t.Days.ToString();
                int remaainingdays = int.Parse(this.TxtrequestDays.Text) + 1;
                this.TxtrequestDays.Text = remaainingdays.ToString();


                dt = ds.Tables[1];
                dr = dt.Rows[0];
                if (dr == null)
                    return;

                if (dr["IS_LFA"].ToString() == "0")
                {
                    PnlIsLFA.Visible = false;
                }
                else
                {
                    PnlIsLFA.Visible = true;
                }
                PnlIsLFA.Visible = ParseBoolen(dr["IS_LFA"].ToString()) ? true : false;
                PnlSubDate.Visible = ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;
                DdlrequestedHalfDay.Enabled = ParseBoolen(dr["IS_HALFDAY"].ToString()) ? true : false;
            }
            else
            {
                var ds = _leaveRecordDao.SelectLeaveTypesCondition(getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text);
                if (ds == null)
                {
                    ResetField();
                    return;
                }

                var dt = ds.Tables[0];
                var dr = dt.Rows[0];
                if (dr == null)
                    return;

                TxtRemainingDays.Text = dr["REMAINLEAVE"].ToString();
                TxtMaxReqDays.Text = dr["Max_req_days"].ToString();

                dt = ds.Tables[1];
                dr = dt.Rows[0];
                if (dr == null)
                    return;

                PnlIsLFA.Visible = ParseBoolen(dr["IS_LFA"].ToString()) ? true : false;
                PnlSubDate.Visible = ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;
                DdlrequestedHalfDay.Enabled = ParseBoolen(dr["IS_HALFDAY"].ToString()) ? true : false;
            }
            

        }

        private void GetDateDiffrence()
        {
            if (!(TxtFromDate.Text == TxtToDate.Text && DdlrequestedHalfDay.Text != "0"))
            {
                var dr = _leaveRecordDao.SelectRequestedDays(getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text, TxtFromDate.Text, TxtToDate.Text);
                if (dr == null)
                    return;
                TxtrequestDays.Text = dr["REQDAYS"].ToString();
                LblMsg.Text = dr["REMARKS"].ToString();
                DdlrequestedHalfDay.Enabled =ParseBoolen(dr["HALFDAY"].ToString()) ? true : false;
                ResetHalfday();
            }
        }

        private void GetRequestedDays()
        {
            if (TxtFromDate.Text != "" && TxtToDate.Text != "")
            {
                GetDateDiffrence();
            }
        }

        #region Populate

        private void generateLeaveTypeList()
        {
            _clsDao.CreateDynamicDDl(DdlLeaveName, "EXEC proc_GetLeaveData @jobflag = 'CE', @emp_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)), "LEAVE_ID", "LEAVE_NAME", "", "SELECT");

        }
        private void generateRecommendBy()
        {
            _clsDao.CreateDynamicDDl(DdlRecommendedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[recomd] from SuperVisroAssignment where EMP = '" + getEmpIdfromInfo(lblEmpName.Text) + "' and record_status='y'", "SUPERVISOR", "recomd", "", "Select");
        }
        private void generateApprovedBY()
        {
            _clsDao.CreateDynamicDDl(DdlApprovedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[approve] from SuperVisroAssignment where EMP = '" + getEmpIdfromInfo(lblEmpName.Text) + "' and record_status='y'", "SUPERVISOR", "approve", "", "Select");
        }

        private void PopulateRecommendApporvedDropdownlist()
        {
            generateRecommendBy();
            generateApprovedBY();
        }
        /* no need --
                private void generateEmployeeName(string emp)
                {
                    string empID;
                    if (!string.IsNullOrEmpty(txtEmployee.Text))
                    {
                        empID = GetEmployeeId(emp);
                        if (empID != "0")
                        {
                            var dt = _clsDao.getDataset("EXEC proc_GetLeaveData @jobflag = 'SE',@searchEmpBy = " + filterstring(empID)).Tables[0];
                            if (dt.Rows.Count == 0)
                            {
                                hdnEmpName.Value = "";
                                lblEmpName.Text = "Select..";
                                return;
                            }
                            var dr = dt.Rows[0];
                            hdnEmpName.Value = empID;
                            lblEmpName.Text = dr["EMPLOYEE_NAME"].ToString();
                            txtEmployee.Text = "";
                            generateLeaveTypeList();
                            ResetField();
                        }
                    }
                    else
                    {
                        hdnEmpName.Value = "";
                        lblEmpName.Text = "Select..";
                    }

                }

                private string GetEmployeeId(string employee)
                {
                    if (employee.Length < 0 || employee.IndexOf('|') == -1)
                    {
                        return "0";
                    }

                    string[] a = employee.Split('|');
                    string empId = a[1];
                    return empId;
                }

                private void generateSubstituteEmployeeName(string emp)
                {
                    string empID;
                    if (!string.IsNullOrEmpty(TxtSubstitutedBy.Text))
                    {
                        empID = GetEmployeeId(emp);
                        if (empID != "0")
                        {
                            var dt = _clsDao.getDataset("EXEC proc_GetLeaveData @jobflag = 'SE',@searchEmpBy = " + filterstring(empID)).Tables[0];
                            if (dt.Rows.Count == 0)
                            {
                                hdnSubEmpName.Value = "";
                                lblSubstEmpName.Text = "Select..";
                                return;
                            }
                            var dr = dt.Rows[0];
                            hdnSubEmpName.Value = empID;
                            lblSubstEmpName.Text = dr["EMPLOYEE_NAME"].ToString();
                            TxtSubstitutedBy.Text = "";
                        }
                    }
                    else
                    {
                        hdnSubEmpName.Value = "";
                        lblSubstEmpName.Text = "Select..";
                    }

                }

        */
        #endregion

        private void ResetField()
        {
            TxtRemainingDays.Text = "";
            TxtFromDate.Text = "";
            TxtToDate.Text = "";
            TxtrequestDays.Text = "";
            LblMsg.Text = "";
            ResetHalfday();
        }
        private void DisableApproveForm()
        {
            BtnSave.Visible = false;
            BtnDelete.Visible = false;
            DdlLeaveName.Enabled = false;
            DdlrequestedHalfDay.Enabled = false;
            DdlRecommendedBy.Enabled = false;
            DdlApprovedBy.Enabled = false;
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            txtEmployee.Enabled = false;
            TxtSubstitutedBy.Enabled = false;
            TxtDescription.Enabled = false;
            DdlLFA.Enabled = false;
            TxtSubstitutedDate.Enabled = false;
            BtnBack.Visible = true;
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            /*generateEmployeeName(txtEmployee.Text);
            DdlLeaveName.Focus();
            */
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            generateLeaveTypeList();
            DdlLeaveName.Focus();
        }
        protected void TxtSubstitutedBy_TextChanged(object sender, EventArgs e)
        {
            //generateSubstituteEmployeeName(TxtSubstitutedBy.Text);
            lblSubstEmpName.Text = GetEmpInfoForLabel(TxtSubstitutedBy.Text, lblSubstEmpName.Text);
            TxtSubstitutedBy.Text = "";
        }

        protected void DdlLeaveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateRecommendApporvedDropdownlist();
            ResetField();
            if (DdlLeaveName.Text != "0")
            {
                LeaveTypesCondition();
            }
            else
            {
                TxtRemainingDays.Text = "";
                return;

            }
        }

        protected void TxtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (ParseInt(DdlLeaveName.Text) == 5 || ParseInt(DdlLeaveName.Text) == 6)
            {
                TxtToDate.Text = GetToDate();
            }
            GetRequestedDays();
        }

        private string GetToDate()
        {
            string To_date;
            return To_date = _clsDao.GetSingleresult("EXEC proc_GetLeaveData  @jobflag = 'GD',@fromDate=" + filterstring(TxtFromDate.Text) + ", @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + " , @leaveType = " + filterstring(DdlLeaveName.Text) + "");

        }

        protected void TxtToDate_TextChanged(object sender, EventArgs e)
        {
            DateTime fromdate = new DateTime();
            DateTime todate = new DateTime();
            fromdate = DateTime.Parse(TxtFromDate.Text);
            todate = DateTime.Parse(TxtToDate.Text);
            TimeSpan ts = todate - fromdate;
            if (ts.Days < 0)
            {
                LblDateMsg.Text = "Invalid Date";
                LblDateMsg.Visible = true;
                return;
            }
            else
            {
                LblDateMsg.Text = "";
                LblDateMsg.Visible = false;
                GetRequestedDays();

            }
        }

        protected void DdlrequestedHalfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustHalfDay();
        }

        private void AdjustHalfDay()
        {
            if (TxtFromDate.Text == TxtToDate.Text)
                TxtrequestDays.Text = (DdlrequestedHalfDay.Text != "0") ? "0.5" : "1";
            else
                ResetHalfday();

        }

        private void ResetHalfday()
        {
            DdlrequestedHalfDay.Text = "0";
        }

        private void RedirectToList()
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            RedirectToList();
        }

        private void saveData()
        {
            var dt = _leaveRecordDao.Save(GetLeaveRecordId().ToString(), getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text,
                                            TxtFromDate.Text, TxtToDate.Text, TxtrequestDays.Text, DdlrequestedHalfDay.Text,
                                            TxtDescription.Text, DdlRecommendedBy.Text, DdlApprovedBy.Text,
                                            TxtRemainingDays.Text, DdlLFA.Text, getEmpIdfromInfo(lblSubstEmpName.Text), TxtSubstitutedDate.Text, TxtApprovedRemarks.Text,
                                            ReadSession().UserId.ToString()
                                           );

            ErrorMessage(dt);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }


        private void PopulateData()
        {
            var ds = _leaveRecordDao.SelectById(GetLeaveRecordId().ToString());
            if (ds == null)
                RedirectToList();

            var dtRequestedLeave = ds.Tables[0];
            var dr = dtRequestedLeave.Rows[0];
            if (dr == null)
                return;

            lblEmpName.Text = dr["REQUESTED_BY"].ToString();
            //hdnEmpName.Value = GetEmployeeId(dr["REQUESTED_BY"].ToString());
            generateLeaveTypeList();
            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();

            TxtFromDate.Text = dr["APPROVED_FROM"].ToString();
            TxtToDate.Text = dr["APPROVED_TO"].ToString();
            TxtrequestDays.Text = dr["APPROVED_DAYS"].ToString();
            DdlrequestedHalfDay.Text = dr["REQUESTED_HRS_STATUS"].ToString();

            TxtLeaveStatus.Text = dr["LEAVE_STATUS"].ToString();
            TxtDescription.Text = dr["LEAVE_PURPOSE"].ToString();

            PopulateRecommendApporvedDropdownlist();
            DdlRecommendedBy.Text = dr["REQUESTED_WITH"].ToString();
            DdlApprovedBy.Text = dr["APPROVED_BY"].ToString();
            TxtRemainingDays.Text = dr["REMAINING_DAYS"].ToString();

            TxtApprovedRemarks.Text = dr["REMARKS"].ToString();

            DdlLFA.Text = dr["IS_LFA"].ToString();
            if (dr["APPLY_LFA"].ToString() == "0")
            {
                PnlIsLFA.Visible = false;
            }
            else
            {
                PnlIsLFA.Visible = true;
            }
            //PnlIsLFA.Visible =ParseBoolen(dr["APPLY_LFA"].ToString()) ? true : false;
            PnlSubDate.Visible =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;


            lblSubstEmpName.Text = dr["substituted_with"].ToString();
            //hdnSubEmpName.Value = GetEmployeeId(dr["substituted_with"].ToString());
            TxtSubstitutedDate.Text = dr["SUBSTITUTED_FROM"].ToString();

            DisableApproveForm();

        }
        //private void ErrorMessage(DataTable dt)
        //{

        //    DataRow dr;
        //    dr = dt.Rows[0];

        //    if (dr["SUCCESS"].ToString() == "0")
        //    {
        //        LblMsg.Text = dr["REMARKS"].ToString();
        //        LblMsg.ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //        Response.Redirect("List.aspx");
        //}
        private void ErrorMessage(DataTable dt)
        {
            if(GetIsMasterPageLessFlag()=="Y")
            {
                DataRow dr;
                dr = dt.Rows[0];

                if (dr["SUCCESS"].ToString() == "0")
                {
                    LblMsg.Text = dr["REMARKS"].ToString();
                    LblMsg.ForeColor = System.Drawing.Color.Red;

                    if (LblMsg.Text == "")
                    {
                        if (GetIsMasterPageLessFlag() == "Y")
                        {
                            CallBackJs1(Page, "close", "parent.parent.GB_hide();");
                        }
                    }
                }
                else
                    CallBackJs1(Page, "close", "parent.parent.GB_hide();");
            }
            else
            {
                    DataRow dr;
                    dr = dt.Rows[0];

                    if (dr["SUCCESS"].ToString() == "0")
                    {
                        LblMsg.Text = dr["REMARKS"].ToString();
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                        Response.Redirect("List.aspx");
                }
            

        }
           
        private void DeleteData()
        {
            var dt = _leaveRecordDao.Delete(ReadSession().UserId.ToString(), GetLeaveRecordId().ToString());

            ErrorMessage(dt);
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }


        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            MasterPageFile = GetIsMasterPageLessFlag() == "N" ? "~/SwiftHRManager.Master" : "~/ProjectMaster.Master";
        }
        protected string GetIsMasterPageLessFlag()
        {
            return ReadQueryString("isMasterPageLess", "N");
        }
        private long GetEMPID()
        {
            return ReadNumericDataFromQueryString("emp_id");
        }
        private void forTada()
        {
            lblEmpName.Text = _clsDao.GetSingleresult("EXEC proc_GetLeaveData @jobflag = 'SE',@searchEmpBy = " + filterstring(GetEMPID().ToString()));
            txtEmployee.Enabled = false;
            generateLeaveTypeList();
            DdlLeaveName.Focus();
        }
       
    }
}
