using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveRequest;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveRequest
{
    public partial class Manage : BasePage
    {
        LeaveRequestDao _leaveRequestDao = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public Manage()
        {
            _leaveRequestDao = new LeaveRequestDao();
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 31) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetLeaveRequestId() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateData();
                }
                else
                {
                    BtnDelete.Visible = false;
                }

            }
        }

        private long GetLeaveRequestId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void LeaveTypesCondition()
        {
            var ds = _leaveRequestDao.SelectLeaveTypesCondition(getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text);
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

        private void GetDateDiffrence()
        {
            if (!(TxtFromDate.Text == TxtToDate.Text && DdlrequestedHalfDay.Text != "0"))
            {
                var dr = _leaveRequestDao.SelectRequestedDays(getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text, TxtFromDate.Text, TxtToDate.Text);
                if (dr == null)
                    return;
                TxtrequestDays.Text = dr["REQDAYS"].ToString();
                string isLfa = dr["IS_LFA"].ToString();
                string lfaTaken = dr["lfa_taken"].ToString();
                if (long.Parse(TxtrequestDays.Text) >= 15 && DdlLeaveName.Text == "1" && isLfa == "True")
                {
                    if(lfaTaken=="True")
                    {
                        DdlLFA.SelectedValue = "0";
                        PnlIsLFA.Visible = false; 
                    }
                    else
                    {
                        DdlLFA.SelectedValue = "1";
                        PnlIsLFA.Visible = true; 
                    }
                  
                }
                else
                {
                    DdlLFA.SelectedValue = "0";
                }
                if (long.Parse(TxtrequestDays.Text) >= 4 && DdlLeaveName.Text == "3")
                {
                    PnlFileUpload.Visible = true;
                }
                else
                {
                    PnlFileUpload.Visible = false;
                }
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
        

        #endregion

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

        private void ResetField()
        {
            TxtRemainingDays.Text = "";
            TxtFromDate.Text = "";
            TxtToDate.Text = "";
            TxtrequestDays.Text = "";
            LblMsg.Text = "";
            ResetHalfday();
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

        private void saveData()
        {
            var dt = _leaveRequestDao.Save(GetLeaveRequestId().ToString(), getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text,
                                            TxtFromDate.Text, TxtToDate.Text, TxtrequestDays.Text, DdlrequestedHalfDay.Text, TxtLeaveStatus.Text,
                                            TxtDescription.Text, DdlRecommendedBy.Text, DdlApprovedBy.Text,
                                            TxtRemainingDays.Text, DdlLFA.Text, getEmpIdfromInfo(lblSubstEmpName.Text), TxtSubstitutedDate.Text,
                                            ReadSession().UserId.ToString(),null,ReadSession().Sessionid
                                           );

            ErrorMessage(dt);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void PopulateData()
        {
            var ds = _leaveRequestDao.SelectById(GetLeaveRequestId().ToString());
            if (ds == null)
                RedirectToList();

            var dtRequestedLeave = ds.Tables[0];
            var dr = dtRequestedLeave.Rows[0];
            if (dr == null)
                return;

            lblEmpName.Text = dr["REQUESTED_BY"].ToString();
            generateLeaveTypeList();
            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();

            TxtFromDate.Text = dr["FROM_DATE"].ToString();
            TxtToDate.Text = dr["TO_DATE"].ToString();
            TxtrequestDays.Text = dr["REQUESTED_DAYS"].ToString();
            DdlrequestedHalfDay.Text = dr["REQUESTED_HRS_STATUS"].ToString();

            TxtLeaveStatus.Text = dr["LEAVE_STATUS"].ToString();
            TxtDescription.Text = dr["LEAVE_PURPOSE"].ToString();

            PopulateRecommendApporvedDropdownlist();
            DdlRecommendedBy.Text = dr["REQUESTED_WITH"].ToString();
            DdlApprovedBy.Text = dr["APPROVED_BY"].ToString();
            TxtRemainingDays.Text = dr["REMAINING_DAYS"].ToString();
            TxtMaxReqDays.Text = dr["MAX_REQ_DAYS"].ToString();
            DdlLFA.Text = dr["IS_LFA"].ToString();
            if (dr["APPLY_LFA"].ToString() == "0")
            {
                PnlIsLFA.Visible = false;
            }
            else
            {
                PnlIsLFA.Visible = true;
            }
            PnlSubDate.Visible =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;

            //File Show Hide as per Leave Type and days
            if (dr["LEAVE_TYPE_ID"].ToString() == "3" && ParseDouble(dr["REQUESTED_DAYS"].ToString()) >= 4)
            {
                PnlFileUpload.Visible = true;
                OnPopulate();
            }
            else
            {
                PnlFileUpload.Visible = false;
            }

            lblSubstEmpName.Text = dr["substituted_with"].ToString();
            TxtSubstitutedDate.Text = dr["SUBSTITUTED_FROM"].ToString();

            TxtApprovedFrom.Text = dr["APPROVED_FROM"].ToString();
            TxtApprovedTo.Text = dr["APPROVED_TO"].ToString();
            TxtApprovedDays.Text = dr["APPROVED_DAYS"].ToString();

            if (TxtLeaveStatus.Text == "Approved")
            {
                PnlApprovedDetails.Visible = true;
                DisableApproveForm();
            }
            else if (TxtLeaveStatus.Text == "Recommended")
            {
                DisableRecommendForm();
            }
            else if (TxtLeaveStatus.Text == "Cancelled")
            {
                DisableApproveForm();
            }
            else
                DisableElementsAfterPopulate();


            if (ds.Tables[1].Rows.Count > 0)
                generateCallbackDetail(ds.Tables[1]);

        }

        public void generateCallbackDetail(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            int ColumnsCount = dt.Columns.Count;

            str.Append("<fieldset style=\"list-style:circle; list-style-type:circle;\">");
            str.Append("<legend class=\"subheading\">Call Back Leave Details:</legend>");

            str.Append("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            str.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                str.Append("<th>" + dc.ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < ColumnsCount; i++)
                {
                    str.Append("<td>" + dr[i] + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("</table>");
            str.Append("</fieldset>");
            rptDiv.InnerHtml = str.ToString();

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

        private void DisableRecommendForm()
        {
            BtnSave.Visible = true;
            BtnDelete.Visible = false;
            DdlLeaveName.Enabled = false;
            DdlrequestedHalfDay.Enabled = false;
            DdlRecommendedBy.Enabled = false;
            DdlApprovedBy.Enabled = true;
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            txtEmployee.Enabled = false;
            TxtSubstitutedBy.Enabled = false;
            TxtDescription.Enabled = false;
            DdlLFA.Enabled = false;
            TxtSubstitutedDate.Enabled = false;
            BtnBack.Visible = true;
        }

        private void DisableElementsAfterPopulate()
        {
            BtnSave.Visible = true;
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            TxtDescription.Enabled = true;
            txtEmployee.Enabled = false;
            DdlLeaveName.Enabled = false;
        }

        private void ErrorMessage(DataTable dt)
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

        private void DeleteData()
        {
            var dt = _leaveRequestDao.Delete(ReadSession().UserId.ToString(), GetLeaveRequestId().ToString());

            ErrorMessage(dt);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            RedirectToList();
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

        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getTable("Exec [procLeaveFileUpload] @flag='s1',@id=" + filterstring(GetLeaveRequestId().ToString()) + "");

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            int cols = dt.Columns.Count;

            if (dt.Columns.Count > 0)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">View</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><a target='_blank' href='/doc/LeaveDoc" + "/" + dr["id"] + "." + dr["File Type"].ToString() + "'> View </a></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
        }
    }
}
