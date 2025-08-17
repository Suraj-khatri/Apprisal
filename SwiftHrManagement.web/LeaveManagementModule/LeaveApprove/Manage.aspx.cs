using System;
using System.Data;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveApprove;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveApprove
{
    public partial class Manage : BasePage
    {
        LeaveApproveDao _leaveApproveDao = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public Manage()
        {
            _leaveApproveDao = new LeaveApproveDao();
            _clsDao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 32) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                PopulateData();
            }
        }
        private void RedirectToList()
        {
            Response.Redirect("List.aspx");
        }

        private void CheckSuccess(DataTable dt)
        {

            DataRow dr;

            dr = dt.Rows[0];
            if (dr == null)
            {
                LblMsg.Text = "FAILED";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (dr["SUCCESS"].ToString() == "0")
            {
                LblMsg.Text = dr["REMARKS"].ToString();
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                RedirectToList();
            }

        }

        private long GetLeaveRequestID()
        {
            return (string.IsNullOrEmpty(Request.QueryString["ID"]) ? 0 : long.Parse(Request.QueryString["ID"]));
        }

        private void PopulateData()
        {
            DataSet ds = _leaveApproveDao.SelectById(GetLeaveRequestID().ToString());
            if (ds == null)
                return;
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            LblRequestedBy.Text = dr["REQUESTED_FULLNAME"].ToString();

            _clsDao.CreateDynamicDDl(DdlLeaveName, "EXEC proc_GetLeaveData @jobflag = 'CE', @emp_ID=" + filterstring(dr["REQUESTED_BY"].ToString()), "LEAVE_ID", "LEAVE_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlRecommendedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[recomd] from SuperVisroAssignment where SUPERVISOR_TYPE in ('i','s') and EMP = " + filterstring(dr["REQUESTED_BY"].ToString()) + " and record_status='y'", "SUPERVISOR", "recomd", "", "Select");
            _clsDao.CreateDynamicDDl(DdlApprovedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[approve] from SuperVisroAssignment where SUPERVISOR_TYPE in ('s','i') and EMP = " + filterstring(dr["REQUESTED_BY"].ToString()) + " and record_status='y'", "SUPERVISOR", "approve", "", "Select");

            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();

            TxtRemainingDays.Text = dr["REMAINING_DAYS"].ToString();
            TxtLeaveStatus.Text = dr["LEAVE_STATUS"].ToString();
            TxtFromDate.Text = dr["FROM_DATE"].ToString();
            TxtToDate.Text = dr["TO_DATE"].ToString();
            TxtrequestDays.Text = dr["REQUESTED_DAYS"].ToString();
            DdlrequestedHours.Text = dr["REQUESTED_HRS_STATUS"].ToString();
            DdlLFA.Text = dr["IS_LFA"].ToString();
            TxtSubstitutedDate.Text = dr["SUBSTITUTED_FROM"].ToString();
            if (dr["APPLY_LFA"].ToString() == "0")
            {
                PnlIsLFA.Visible = false;
            }
            else
            {
                PnlIsLFA.Visible = true;
            }
            PnlSubtitutedate.Visible =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;
            lblSubstitutedBy.Text = dr["substituted_withName"].ToString();
            TxtLeavePurpose.Text = dr["LEAVE_PURPOSE"].ToString();
            DdlRecommendedBy.Text = dr["REQUESTED_WITH"].ToString();
            DdlApprovedBy.Text = dr["APPROVED_BY"].ToString();
            txtApprovedFrom.Text = dr["APPROVED_FROM"].ToString();
            txtApprovedTo.Text = dr["APPROVED_TO"].ToString();
            txtApprovedDays.Text = dr["APPROVED_DAYS"].ToString();
            DdlApprovedHalfday.Text = dr["REQUESTED_HRS_STATUS"].ToString();
            txtRecRemarks.Text = dr["RECOMMEND_REMARKS"].ToString();
            txtAppRemarks.Text = dr["REMARKS"].ToString();


            //File Show Hide as per Leave Type and days
            if (dr["LEAVE_TYPE_ID"].ToString() == "3" && ParseDouble(dr["REQUESTED_DAYS"].ToString()) >= 7)
            {
                PnlFileUpload.Visible = true;
                OnPopulate();
            }
            else
            {
                PnlFileUpload.Visible = false;
            }

            DisableFieldsByStatus(dr["LEAVE_STATUS"].ToString(), dr["REQUESTED_HRS_STATUS"].ToString());

        }

        private void DisableFieldsByStatus(string status, string halfday)
        {
            DdlLeaveName.Enabled = false;
            TxtRemainingDays.Enabled = false;
            TxtLeaveStatus.Enabled = false;
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            TxtrequestDays.Enabled = false;
            DdlrequestedHours.Enabled = false;
            DdlLFA.Enabled = false;
            TxtSubstitutedDate.Enabled = false;
            TxtLeavePurpose.Enabled = false;
            DdlRecommendedBy.Enabled = false;
            DdlApprovedBy.Enabled = false;
            txtApprovedDays.Enabled = false;

            if (status == "Pending")
            {
                txtApprovedFrom.Enabled = false;
                txtApprovedTo.Enabled = false;
                txtRecRemarks.Enabled = true;
                LblRecRemarks.Visible = true;
                txtAppRemarks.Visible = false;
                LblAppRemarks.Visible = false;
                BtnSave.Visible = true;
                BtnApprove.Visible = false;
            }
            else if (status == "Recommended")
            {
                txtApprovedFrom.Enabled = true;
                txtApprovedTo.Enabled = true;
                txtRecRemarks.Enabled = false;
                txtAppRemarks.Enabled = true;
                LblRecRemarks.Visible = true;
                LblAppRemarks.Visible = true;
                BtnSave.Visible = false;
                BtnApprove.Visible = true;
            }
            else
            {
                txtApprovedFrom.Enabled = false;
                txtApprovedTo.Enabled = false;
                txtRecRemarks.Enabled = false;
                txtAppRemarks.Enabled = false;
                LblRecRemarks.Visible = true;
                LblAppRemarks.Visible = true;
                BtnSave.Visible = false;
                BtnApprove.Visible = false;
            }

            if (halfday != "0")
            {
                txtApprovedFrom.Enabled = false;
                txtApprovedTo.Enabled = false;
            }

        }

        public void ManageApproveLeave()
        {
            var dt = _leaveApproveDao.Update(TxtLeaveStatus.Text, txtApprovedFrom.Text, txtApprovedTo.Text, DdlApprovedHalfday.Text.Equals("0") ? txtApprovedDays.Text : "0.5"
                                                , DdlApprovedHalfday.Text, DdlLFA.Text, TxtSubstitutedDate.Text, getEmpIdfromInfo(lblSubstitutedBy.Text), txtRecRemarks.Text
                                                , txtAppRemarks.Text, ReadSession().Emp_Id.ToString(), GetLeaveRequestID().ToString());

            CheckSuccess(dt);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ManageApproveLeave();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            RedirectToList();
        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            var dt = _leaveApproveDao.Reject(ReadSession().Emp_Id.ToString(), GetLeaveRequestID().ToString(), TxtLeaveStatus.Text, txtApprovedDays.Text, txtRecRemarks.Text, txtAppRemarks.Text);
            CheckSuccess(dt);
        }

        protected void TxtSubstitutedBy_TextChanged(object sender, EventArgs e)
        {
            lblSubstitutedBy.Text = GetEmpInfoForLabel(TxtSubstitutedBy.Text, lblSubstitutedBy.Text);
            TxtSubstitutedBy.Text = "";
        }

        private void onDateChange()
        {
            var dt = _leaveApproveDao.CalculateDays(txtApprovedFrom.Text, txtApprovedTo.Text, GetLeaveRequestID().ToString());

            var dr = dt.Rows[0];

            txtApprovedDays.Text = dr["APPDAYS"].ToString();
            LblMsg.Text = dr["REMARKS"].ToString();
        }

        protected void txtApprovedFrom_TextChanged(object sender, EventArgs e)
        {
            onDateChange();
        }

        protected void txtApprovedTo_TextChanged(object sender, EventArgs e)
        {
            onDateChange();
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

        protected void TxtToDate_TextChanged(object sender, EventArgs e)
        {

        }
        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getTable("Exec [procLeaveFileUpload] @flag='s1',@id=" + filterstring(GetLeaveRequestID().ToString()) + "");


            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
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
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }
    }
}
