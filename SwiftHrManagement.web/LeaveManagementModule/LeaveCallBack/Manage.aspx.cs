using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveCallBack;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveCallBack
{
    public partial class Manage : BasePage
    {
        LeaveCallBackDao _leaveCallBackDao = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public Manage()
        {
            _leaveCallBackDao = new LeaveCallBackDao();
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 35) == false)
            {
                Response.Redirect("/Error.aspx");
            }

            if (!IsPostBack)
            {
                generateLeaveTypeList();
                PopulateData();

            }
            DisableFields();
        }
        private void DisableFields()
        {
            DdlLeaveName.Enabled = false;
            txtApprovedFrom.Enabled = false;
            txtApprovedTo.Enabled = false;
            txtApprovedDays.Enabled = false;
            txtCallBackDays.Enabled = false;
        }

        private void generateLeaveTypeList()
        {
            _clsDao.CreateDynamicDDl(DdlLeaveName, "EXEC proc_GetLeaveData @jobflag = 'PL'", "ID", "NAME_OF_LEAVE", "", "SELECT");

        }
        private void RedirectToList()
        {
            Response.Redirect("List.aspx?Id=" + GetRequestId().ToString());
        }

        private long GetRequestId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PopulateData()
        {
            var dr = _leaveCallBackDao.SelectById(GetRequestId().ToString());

            if (dr == null)
                return;

            lblEmployeeName.Text = dr["REQUESTED_BY"].ToString();
            DdlLeaveName.Text = dr["LEAVE_TYPE_ID"].ToString();
            txtApprovedFrom.Text = dr["APPROVED_FROM"].ToString();
            txtApprovedTo.Text = dr["APPROVED_TO"].ToString();
            txtApprovedDays.Text = dr["APPROVED_DAYS"].ToString();
            txtCallBackFrom.Text = dr["CALLBACK_FROM"].ToString();
            txtCallBackTo.Text = dr["CALLBACK_TO"].ToString();
            txtCallBackDays.Text = dr["CALL_BACK_DAYS"].ToString();



        }

        private void CheckSuccess(DataRow dr)
        {

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
                LblMsg.Text = dr["REMARKS"].ToString();
                LblMsg.ForeColor = System.Drawing.Color.Green;
            }

        }

        private void Calculatedays()
        {
            if (string.IsNullOrEmpty(txtCallBackFrom.Text) || string.IsNullOrEmpty(txtCallBackTo.Text))
            {
                txtCallBackDays.Text = "0";
                return;
            }

            var dr = _leaveCallBackDao.CalculateDays(GetRequestId().ToString(), txtCallBackFrom.Text, txtCallBackTo.Text);
            if (dr == null)
            {
                txtCallBackDays.Text = "0";
                return;
            }


            txtCallBackDays.Text = dr["CALLBACKDAYS"].ToString();

            if (dr["REMARKS"].ToString() != "")
            {
                LblMsg.Text = dr["REMARKS"].ToString();
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LblMsg.Text = dr["REMARKS"].ToString();
                LblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            RedirectToList();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var dr = _leaveCallBackDao.Save(GetRequestId().ToString(), txtCallBackFrom.Text, txtCallBackTo.Text, txtCallBackDays.Text, ReadSession().Emp_Id.ToString());

            if (dr == null)
                return;

            CheckSuccess(dr);

        }

        protected void txtCallBackFrom_TextChanged(object sender, EventArgs e)
        {
            Calculatedays();
        }

        protected void txtCallBackTo_TextChanged(object sender, EventArgs e)
        {
            Calculatedays();
        }
    }
}
