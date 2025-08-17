using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveAssignment;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveAssignment
{
    public partial class Manage : BasePage
    {
        LeaveAssignmentDAO _leaveAssignDao = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public Manage()
        {
            _leaveAssignDao = new LeaveAssignmentDAO();
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 30) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetAssignedLeaveId() > 0)
                {
                    PopulateData();
                    BtnDelete.Visible = true;
                    if (IsPersonal() == 'Y')
                    {
                        BtnAssignNext.Visible = false;
                        BtnSave.Visible = false;
                        BtnDelete.Visible = false;
                    }
                    else
                        BtnAssignNext.Visible = true;
                }
                else
                {
                    disableElements("LFA");
                    disableElements("NextYearDays");
                    BtnDelete.Visible = false;
                    BtnAssignNext.Visible = false;
                }
            }
            //lblEmpName.Text = Request.Form("hdnEmpName").Tostring();
        }

        private void disableElements(string job)
        {
            if (job == "P")//populate
            {
                txtEmployee.Enabled = false;

                DdlLeaveName.Enabled = false;
            }

            if (job == "LFA")
            {
                if (DdlApplyLFA.Text == "0")
                {
                    LFA.Visible = false;
                }
                else
                {
                    LFA.Visible = true;
                }

            }
            if (job == "NextYearDays")
            {
                if (chkNxtYrValue.Checked == true)
                {
                    NextYearDays.Visible = false;
                }
                else
                {
                    NextYearDays.Visible = true;
                }
            }

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.MasterPageFile = (GetEmployeeId() == 0 ? "~/SwiftHRManager.Master" : "~/ProjectMaster.Master");
        }

        private long GetEmployeeId()
        {
            return (Request.QueryString["EmpID"] != null ? long.Parse(Request.QueryString["EmpID"].ToString()) : 0);
        }

        private char IsPersonal()
        {
            if (GetEmployeeId() > 0)
                return 'Y';
            else
                return 'N';
        }

        private void RedirectToList()
        {
            //Response.Redirect("List.aspx");
            if (GetEmployeeId() > 0)
                Response.Redirect("List.aspx?Id=" + GetEmployeeId());
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        private void PopulateData()
        {
            var ds = _leaveAssignDao.SelectAssignedLeaveById(GetAssignedLeaveId().ToString(), IsPersonal());
            if (ds == null)
                RedirectToList();

            var dtAssignedLeave = ds.Tables[0];
            var dr = dtAssignedLeave.Rows[0];
            if (dr == null)
                return;

            lblEmpName.Text = dr["EMPLOYEE_ID"].ToString();
            //generateEmployeeName(txtEmployee.Text);
            generateLeaveTypeList();
            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();
            lblDefultDays.Text = dr["DEFAULTDAYS"].ToString();
            lblLfadays.Text = dr["DEFAULTLFA"].ToString();
            TxtDefaultDays.Text = dr["ASSIGNEDDAYS"].ToString();
            DdlApplyLFA.Text = ParseBoolen(dr["ApplyLFA"].ToString()) ? "1" : "0";
            TxtNoofLfadays.Text = dr["ASSIGNEDLFA"].ToString();
            TxtLastYrLeave.Text = dr["LASTYRLEAVE"].ToString();
            txtNextYearDays.Text = dr["NxtYrDays"].ToString();
            TxtFromDate.Text = dr["FromDate"].ToString();
            TxtToDate.Text = dr["ToDate"].ToString();
            txtMaxDaysReq.Text = dr["max_req_days"].ToString();
            txtMinDaysReq.Text = dr["min_req_days"].ToString();

            string abc = dr["NxtYrDefault"].ToString();
            if (abc == "True")
            {
                chkNxtYrValue.Checked = true;
            }
            else
            {
                chkNxtYrValue.Checked = false;
            }

            DdlIsActive.Text = ParseBoolen(dr["IS_ACTIVE"].ToString()) ? "1" : "0";
            DdlCashable.Text = ParseBoolen(dr["IS_CASHABLE"].ToString()) ? "1" : "0";

            DdlUnlimited.Text = ParseBoolen(dr["IS_UNLIMITED"].ToString()) ? "1" : "0";
            DdlHoliday.Text = ParseBoolen(dr["IS_HOLIDAY"].ToString()) ? "1" : "0";
            DdlSaturday.Text = ParseBoolen(dr["IS_SATURDAY"].ToString()) ? "1" : "0";
            DdlHalfDay.Text = ParseBoolen(dr["IS_HALFDAY"].ToString()) ? "1" : "0";

            DdlSubstitute.Text = ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? "1" : "0";
            DdlRelieving.Text = ParseBoolen(dr["RELIEVING"].ToString()) ? "1" : "0";

            disableElements("P");
            disableElements("LFA");
            disableElements("NextYearDays");
            disableLeaveTypeFields();
            generateAssignedLeaveDetail(ds.Tables[1]);
        }

        public void generateAssignedLeaveDetail(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            if (dt == null)
            {

                var ds = _leaveAssignDao.SelectAssignedLeaveByEmpId(getEmpIdfromInfo(lblEmpName.Text), IsPersonal());

                if (ds == null)
                {
                    str.Append("&nbsp;");
                    rptDiv.InnerHtml = str.ToString();
                    return;
                }


                dt = ds.Tables[0];
            }


            int ColumnsCount = dt.Columns.Count;

            str.Append("<label>Assigned Leave Details:</label>");

            str.Append("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
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
                    if (i == 7)
                    {
                        str.Append("<td class=\"text-center\">" + dr[i] + "</td>");
                    }
                    else
                        str.Append("<td>" + dr[i] + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();

        }

        private long GetAssignedLeaveId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        
        private void generateLeaveTypeList()
        {
            _clsDao.CreateDynamicDDl(DdlLeaveName, "EXEC proc_LeaveAssignment @flag = 'p',@Employee_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@leaveType=" + filterstring(GetAssignedLeaveId().ToString()), "ID", "NAME_OF_LEAVE", "", "SELECT");

        }

        private void getDefaultValues()
        {
            DataRow dr = _leaveAssignDao.GetDefaultValueOfLeave(DdlLeaveName.Text, filterstring(getEmpIdfromInfo(lblEmpName.Text))).Rows[0];

            lblDefultDays.Text = dr["DEFAULTDAYS"].ToString();
            lblLfadays.Text = dr["DEFAULTLFA"].ToString();
            TxtDefaultDays.Text = dr["DEFAULTDAYS"].ToString();
            TxtNoofLfadays.Text = dr["DEFAULTLFA"].ToString();
            TxtLastYrLeave.Text = "";
            DdlApplyLFA.Text = ParseBoolen(dr["IS_LFA"].ToString()) ? "1" : "0";
            LFA.Visible = ParseBoolen(dr["IS_LFA"].ToString()) ? true : false;
            DdlCashable.Text =ParseBoolen(dr["IS_CASHABLE"].ToString()) ? "1" : "0";
            DdlHalfDay.Text =ParseBoolen(dr["IS_HALFDAY"].ToString()) ? "1" : "0";
            DdlSaturday.Text =ParseBoolen(dr["IS_SATURDAY"].ToString()) ? "1" : "0";
            DdlHoliday.Text =ParseBoolen(dr["IS_HOLIDAY"].ToString()) ? "1" : "0";
            DdlUnlimited.Text =ParseBoolen(dr["IS_UNLIMITED"].ToString()) ? "1" : "0";
            DdlSubstitute.Text =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? "1" : "0";
            DdlRelieving.Text =ParseBoolen(dr["RELIEVING"].ToString()) ? "1" : "0";
            TxtFromDate.Text = dr["Fromdate"].ToString();
            TxtToDate.Text = dr["Todate"].ToString();
            txtMaxDaysReq.Text = dr["max_req_days"].ToString();
            txtMinDaysReq.Text = dr["min_req_days"].ToString();

        }

        private void disableLeaveTypeFields()
        {
            if (string.IsNullOrEmpty(DdlLeaveName.Text))
            {
                resetValues();
                return;
            }

            DataRow dr = _leaveAssignDao.GetDefaultValueOfLeave(DdlLeaveName.Text, filterstring(getEmpIdfromInfo(lblEmpName.Text))).Rows[0];
            /*//Previous 
            DdlApplyLFA.Enabled =ParseBoolen(dr["IS_LFA"].ToString()) ? true : false;

            DdlCashable.Enabled =ParseBoolen(dr["IS_CASHABLE"].ToString()) ? true : false;
            DdlHalfDay.Enabled =ParseBoolen(dr["IS_HALFDAY"].ToString()) ? true : false;
            DdlSaturday.Enabled =ParseBoolen(dr["IS_SATURDAY"].ToString()) ? true : false;
            DdlHoliday.Enabled =ParseBoolen(dr["IS_HOLIDAY"].ToString()) ? true : false;
            DdlUnlimited.Enabled =ParseBoolen(dr["IS_UNLIMITED"].ToString()) ? true : false;
            DdlSubstitute.Enabled =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? true : false;
            DdlRelieving.Enabled =ParseBoolen(dr["RELIEVING"].ToString()) ? false : true;
            */

            //Always disabled with values set while creating leavetype
            DdlUnlimited.Enabled = false;
            DdlSubstitute.Enabled = false;

            //for unlimited or substituted leave
            if (Convert.ToBoolean(dr["IS_UNLIMITED"].ToString()) ||ParseBoolen(dr["IS_SUBSTITUTED"].ToString()))
            {
                DdlApplyLFA.Enabled = false;

                DdlCashable.Enabled = false;
                DdlHalfDay.Enabled = false;
                DdlSaturday.Enabled = false;
                DdlHoliday.Enabled = false;

                DdlRelieving.Enabled = false;
            }
            else
            {
                DdlApplyLFA.Enabled =ParseBoolen(dr["IS_LFA"].ToString()) ? true : false;

                DdlCashable.Enabled =ParseBoolen(dr["IS_CASHABLE"].ToString()) ? true : false;
                DdlHalfDay.Enabled =ParseBoolen(dr["IS_HALFDAY"].ToString()) ? true : false;
                DdlSaturday.Enabled = true;
                DdlHoliday.Enabled = true;
                DdlRelieving.Enabled = true;
            }

            Days.Visible =ParseBoolen(dr["IS_UNLIMITED"].ToString()) ? false : true;
        }

        private void resetValues()
        {
            lblDefultDays.Text = "";
            lblLfadays.Text = "";
            TxtDefaultDays.Text = "";
            TxtNoofLfadays.Text = "";
            TxtLastYrLeave.Text = "";

            DdlCashable.Text = "0";
            DdlHalfDay.Text = "0";
            DdlSaturday.Text = "0";
            DdlHoliday.Text = "0";
            DdlUnlimited.Text = "0";
            DdlSubstitute.Text = "0";
            DdlRelieving.Text = "0";
        }

        private void saveData()
        {
            var dt = _leaveAssignDao.Save(getEmpIdfromInfo(lblEmpName.Text), DdlLeaveName.Text, TxtDefaultDays.Text, DdlIsActive.Text
                          , DdlSaturday.Text, DdlHoliday.Text, DdlApplyLFA.Text
                          , DdlCashable.Text, DdlUnlimited.Text, DdlHalfDay.Text, DdlSubstitute.Text, DdlRelieving.Text
                          , TxtLastYrLeave.Text, TxtNoofLfadays.Text
                          , ReadSession().Emp_Id.ToString(), GetAssignedLeaveId().ToString(), txtNextYearDays.Text, getChkBoxValue().ToString()
                          ,TxtFromDate.Text,TxtToDate.Text,txtMinDaysReq.Text,txtMaxDaysReq.Text);

            CheckSuccess(dt);
        }

        private string getChkBoxValue()
        {
            string value = "";
            if (chkNxtYrValue.Checked == true)
            {
                value = "1";
            }
            else
            {
                value = "0";
            }

            return value;
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

                if (GetAssignedLeaveId() > 0)
                {
                    LblMsg.Text = dr["REMARKS"].ToString();
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    PopulateData();
                }
                else
                {
                    ResetAll();
                    resetValues();
                    LblMsg.Text = dr["REMARKS"].ToString();
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    /*
                    var ds = _leaveAssignDao.SelectAssignedLeaveByEmpId(getEmpIdfromInfo(lblEmpName.Text));
                    
                    if (ds == null)
                        return;
                    
                    dt = ds.Tables[0];
                    */
                    generateAssignedLeaveDetail(null);
                    //RedirectToList();
                }

            }

        }

        private void ResetAll()
        {
            LblMsg.Text = "";
            DdlLeaveName.ClearSelection();
            DdlIsActive.ClearSelection();
            TxtDefaultDays.Text = "";
            TxtLastYrLeave.Text = "";
            DdlApplyLFA.ClearSelection();
            DdlCashable.ClearSelection();
            DdlHalfDay.ClearSelection();
            DdlSaturday.ClearSelection();
            DdlHoliday.ClearSelection();
            DdlUnlimited.ClearSelection();
            DdlSubstitute.ClearSelection();
            DdlRelieving.ClearSelection();

            txtEmployee.Text = "";
            generateLeaveTypeList();
            DdlLeaveName.Focus();
        }

        protected void DdlLeaveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetAssignedLeaveId() == 0)
            {
                if (string.IsNullOrEmpty(DdlLeaveName.Text))
                    resetValues();
                else
                    getDefaultValues();

                disableLeaveTypeFields();
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        protected void DdlApplyLFA_SelectedIndexChanged(object sender, EventArgs e)
        {
            disableElements("LFA");
        }

        protected void TxtDefaultDays_TextChanged(object sender, EventArgs e)
        {
            string lfaCheck = _clsDao.GetSingleresult("SELECT ID FROM LeaveRequest WHERE IS_LFA='1' AND REQUESTED_BY=1249 and leave_status='Approved'");

            if (DdlApplyLFA.Text == "1" && lfaCheck != "")
            {
                double defaultDays = double.Parse(TxtDefaultDays.Text);
                double workingDays = double.Parse(_clsDao.GetSingleresult("select dbo.FNAGetCurrentYrWorkDaysForEmployee(" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ")"));

                if (defaultDays < 20)
                {
                    TxtNoofLfadays.Text = Math.Ceiling((defaultDays / 2)).ToString();
                }
                else
                {
                    TxtNoofLfadays.Text = "10";
                }
            }
        }

        protected void chkNxtYrValue_CheckedChanged(object sender, EventArgs e)
        {
            disableElements("NextYearDays");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            RedirectToList();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var dt = _leaveAssignDao.DeleteById(GetAssignedLeaveId().ToString());
            CheckSuccess(dt);
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            //generateEmployeeName(txtEmployee.Text);
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            generateLeaveTypeList();
            DdlLeaveName.Focus();
            if (!string.IsNullOrEmpty(lblEmpName.Text))
                generateAssignedLeaveDetail(null);
            ResetAll();
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

        protected void BtnAssignNext_Click(object sender, EventArgs e)
        {
            ResetAll();
            //txtEmployee.Enabled = true;
            Response.Redirect("/LeaveManagementModule/LeaveAssignment/Manage.aspx?MASTERPAGE=0&EmpID=0&personal=0");

        }
    }
}
