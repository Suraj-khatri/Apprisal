using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveRequest;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class LeaveExtension : BasePage
    {
        LeaveRequestDao _leaveRequestDao = new LeaveRequestDao();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        FileUploaderDao _fileuploader = new FileUploaderDao();
        clsDAO _clsdao = new clsDAO();
        string file_2_be_deleted = "";




        protected void Page_PreInit(object sender, EventArgs e)
        {
            MasterPageFile = GetIsMasterPageLessFlag() == "N" ? "~/SwiftHRManager.Master" : "~/ProjectMaster.Master";
        }
        protected string GetIsMasterPageLessFlag()
        {
            return ReadQueryString("isMasterPageLess", "N");
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 34) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                

                generateLeaveTypeList();
                if (GetLeaveRequestId() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateData();
                    //this.rfd3.Text = Request.QueryString["fromdate"].ToString();
                    //this.rfd4.Text = Request.QueryString["todate"].ToString();


                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnSave.Attributes.Add("onclick", "GetId();");
                // ccList.Visible = false;
            }
           
            lblEmpName.Text = _clsdao.GetSingleresult("EXEC proc_GetLeaveData @jobflag = 'SE',@searchEmpBy = " + filterstring(GetEMPID().ToString()));

        }

        private long GetEMPID()
        {
            return ReadNumericDataFromQueryString("emp_id");
        }

        private long GetLeaveRequestId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void LeaveTypesCondition()
        {
            var ds = _leaveRequestDao.SelectLeaveTypesCondition(GetEMPID().ToString(), DdlLeaveName.Text);
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

        private void GetDateDiffrence()
        {
            if (!(TxtFromDate.Text == TxtToDate.Text && DdlrequestedHalfDay.Text != "0"))
            {
                var dr = _leaveRequestDao.SelectRequestedDays(GetEMPID().ToString(), DdlLeaveName.Text, TxtFromDate.Text, TxtToDate.Text);
                if (dr == null)
                    return;
                TxtrequestDays.Text = dr["REQDAYS"].ToString();
                hdnReqDays.Value = dr["REQDAYS"].ToString();
                LblMsg.Text = dr["REMARKS"].ToString();
                LblMsg.ForeColor = System.Drawing.Color.Red;
                DdlrequestedHalfDay.Enabled = ParseBoolen(dr["HALFDAY"].ToString()) ? true : false;
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
            _clsdao.CreateDynamicDDl(DdlLeaveName, "EXEC proc_GetLeaveData @jobflag = 'CE', @emp_ID=" + filterstring(GetEMPID().ToString()), "LEAVE_ID", "LEAVE_NAME", "", "SELECT");

        }
        private void generateRecommendBy()
        {
            _clsdao.CreateDynamicDDl(DdlRecommendedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[recomd] from SuperVisroAssignment where EMP = '" + ReadSession().Emp_Id + "' and record_status='y'", "SUPERVISOR", "recomd", "", "Select");
        }
        private void generateApprovedBY()
        {
            _clsdao.CreateDynamicDDl(DdlApprovedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[approve] from SuperVisroAssignment where EMP = '" + ReadSession().Emp_Id + "' and record_status='y'", "SUPERVISOR", "approve", "", "Select");
        }

        private void PopulateRecommendApporvedDropdownlist()
        {
            generateRecommendBy();
            generateApprovedBY();
        }
        /* no need--
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
            return To_date = _clsdao.GetSingleresult("EXEC proc_GetLeaveData  @jobflag = 'GD',@fromDate=" + filterstring(TxtFromDate.Text) + ", @emp_id=" + filterstring(ReadSession().Emp_Id.ToString()) + " , @leaveType = " + filterstring(DdlLeaveName.Text) + "");

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
                ShowUploadFilePanel();
            }

        }

        private void ShowUploadFilePanel()
        {
            if (DdlLeaveName.Text == "3" && ParseDouble(hdnReqDays.Value) >= 4)
            {
                PnlFileUpload.Visible = true;
                OnPopulate();
            }
            else
            {
                PnlFileUpload.Visible = false;
            }
        }
        private void saveData()
        {
            //ReadSession().Emp_Id.ToString() changed to GetEMPID().ToString()
            var dt = _leaveRequestDao.Save(GetLeaveRequestId().ToString(), GetEMPID().ToString(), DdlLeaveName.Text,
                                            TxtFromDate.Text, TxtToDate.Text, TxtrequestDays.Text, DdlrequestedHalfDay.Text, TxtLeaveStatus.Text,
                                            TxtDescription.Text, DdlRecommendedBy.Text, DdlApprovedBy.Text,
                                            TxtRemainingDays.Text, DdlLFA.Text, getEmpIdfromInfo(lblSubstEmpName.Text), TxtSubstitutedDate.Text,
                                            ReadSession().UserId.ToString(), HiddenFieldEmpEmail.Value, ReadSession().Sessionid
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

            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();
            TxtFromDate.Text = dr["FROM_DATE"].ToString();
            TxtToDate.Text = dr["TO_DATE"].ToString();
            TxtrequestDays.Text = dr["REQUESTED_DAYS"].ToString();
            DdlrequestedHalfDay.Text = dr["REQUESTED_HRS_STATUS"].ToString();
            TxtLeaveStatus.Text = dr["LEAVE_STATUS"].ToString();

            hdnLeaveStatus.Value = dr["LEAVE_STATUS"].ToString();

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
            PnlSubDate.Visible = ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;
            lblSubstEmpName.Text = dr["substituted_with"].ToString();
            TxtSubstitutedDate.Text = dr["SUBSTITUTED_FROM"].ToString();
            TxtApprovedFrom.Text = dr["APPROVED_FROM"].ToString();
            TxtApprovedTo.Text = dr["APPROVED_TO"].ToString();
            TxtApprovedDays.Text = dr["APPROVED_DAYS"].ToString();
            DisableElementsAftrPopulate();

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

            //displaying approved/Cancelled/recommend details
            if (TxtLeaveStatus.Text == "Approved")
            {
                PnlApprovedDetails.Visible = true;
                DisableApproveForm();
            }
            else
            {
                if (TxtLeaveStatus.Text == "Recommended")
                    DisableRecommendForm();
                if (TxtLeaveStatus.Text == "Cancelled")
                    DisableApproveForm();
            }

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
            TxtSubstitutedBy.Enabled = false;
            TxtDescription.Enabled = false;
            DdlLFA.Enabled = false;
            TxtSubstitutedDate.Enabled = false;
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
            TxtSubstitutedBy.Enabled = false;
            TxtDescription.Enabled = false;
            DdlLFA.Enabled = false;
            TxtSubstitutedDate.Enabled = false;

        }

        private void DisableElementsAftrPopulate()
        {
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

                if (LblMsg.Text == "")
                {
                    if (GetIsMasterPageLessFlag() == "Y")
                    {
                        CallBackJs1(Page, "close", "parent.parent.GB_hide();");
                    }
                }
            }
            else
                //Response.Redirect("RequestList.aspx");
                CallBackJs1(Page, "close", "parent.parent.GB_hide();");
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

       
        public void GetLabel(string str)
        {
        }

        protected void TxtSubstitutedBy_TextChanged(object sender, EventArgs e)
        {
            //generateSubstituteEmployeeName(TxtSubstitutedBy.Text);
            lblSubstEmpName.Text = GetEmpInfoForLabel(TxtSubstitutedBy.Text, lblSubstEmpName.Text);
            TxtSubstitutedBy.Text = "";
        }

        private void DeleteData()
        {
            var dt = _leaveRequestDao.Delete(ReadSession().UserId.ToString(), GetLeaveRequestId().ToString());

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string type = "doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {
                case "xls":
                    break;
                case "xlsx":
                    break;
                case "doc":
                    break;
                case "docx":
                    break;
                case "jpg":
                    break;
                case "gif":
                    break;
                case "pdf":
                    break;
                case "txt":
                    break;
                default:
                    lblMessage.Text = "Error:Unable to upload,Invalid file type!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
            }
            string docPath = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileName.Text + "." + type, docPath);

            if (info.Substring(0, 5) == "error")
                return;
            string retValue = "";
            if (GetLeaveRequestId() > 0)
            {
                retValue = _clsdao.GetSingleresult("Exec [procLeaveFileUpload] @flag='u',@id=" + filterstring(GetLeaveRequestId().ToString()) + ","
                                   + " @fileDesc=" + filterstring(TxtFileName.Text) + ",@fileType=" + filterstring(type) + ","
                                   + " @user=" + filterstring(ReadSession().Emp_Id.ToString()));
            }
            else
            {
                retValue = _clsdao.GetSingleresult("Exec [procLeaveFileUpload] @flag='i',@session_id=" + filterstring(ReadSession().Sessionid) + ","
                                    + " @fileDesc=" + filterstring(TxtFileName.Text) + ",@fileType=" + filterstring(type) + ","
                                    + " @user=" + filterstring(ReadSession().Emp_Id.ToString()));
            }
            string location_2_move = docPath + "\\doc\\LeaveDoc".ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

            string strMessage = "File uploaded sucessfully!";

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = System.Drawing.Color.Green;

            OnPopulate();
        }
        public string uploadFile(string fileName, string docPath)
        {
            if (fileName == "")
            {
                return "error:Invalid filename!";
            }
            if (fileUpload.PostedFile.ContentLength == 0)
            {
                return "error:Invalid file content!";
            }
            try
            {
                if (fileUpload.PostedFile.ContentLength <= 2048000)
                {
                    string saved_file_name = docPath + "\\doc\\LeaveDoc\\" + fileName;
                    fileUpload.PostedFile.SaveAs(saved_file_name);
                    return saved_file_name;
                }
                else
                {
                    lblMessage.Text = "Error:Unable to upload,File size is too large!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit!";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied!";
            }
        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (hdnId.Value != "")
            {
                string docPath = ConfigurationSettings.AppSettings["root"];
                string location = docPath + "\\doc\\LeaveDoc\\".ToString();

                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("Exec [procLeaveFileUpload] @flag='d',@id='" + hdnId.Value + "'").Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row["FILENAME"].ToString()))
                        File.Delete(location + "\\" + row["FILENAME"].ToString());
                }
                OnPopulate();
            }
        }

        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            if (GetLeaveRequestId() > 0)
            {
                dt = _clsdao.getTable("Exec [procLeaveFileUpload] @flag='s1',@id=" + filterstring(GetLeaveRequestId().ToString()) + "");
            }
            else
            {
                dt = _clsdao.getTable("Exec [procLeaveFileUpload] @flag='s',@session_id=" + filterstring(ReadSession().Sessionid.ToString()) + "");
            }


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
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><a target='_blank' href='/doc/LeaveDoc" + "/" + dr["id"] + "." + dr["File Type"].ToString() + "'> View </a></td>");
                    if (hdnLeaveStatus.Value == "Approved")
                    {
                        str.Append("<td align=\"left\">N/A</td>");
                        btnAdd.Visible = false;
                    }
                    else
                    {
                        str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
        }

    }
}
