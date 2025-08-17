using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.LeaveManagementModule.LeaveType;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveType
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = null;
        LeaveTypesDao _leaveTypesDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            _clsdao = new clsDAO();
            _leaveTypesDao = new LeaveTypesDao();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 29) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                PoupulateDdlLeaveName();
                if (GetLeaveTypeId() > 0)
                {
                    PopulateData();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");

        }


        private long GetLeaveTypeId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PoupulateDdlLeaveName()
        {
            string selectValue = "";
            if (DdlLeaveName.SelectedItem != null)
                selectValue = DdlLeaveName.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref DdlLeaveName, "Exec ProcStaticDataView 's','19'", "DETAIL_TITLE", "DETAIL_TITLE", selectValue, "Select");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageSaveData();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;

            }

        }
        private void ManageSaveData()
        {
            DataTable dt = new DataTable();

            dt = _leaveTypesDao.Update(GetLeaveTypeId().ToString(), DdlLeaveName.Text, TxtDescription.Text, TxtDefaultDays.Text,
                                        DdlOccurrence.Text, TxtMaxDays.Text,
                                        TxtMaxAccumulation.Text, DdlLfaDays.Text, TxtNoofLfadays.Text, DdlIsActive.Text, DdlCashable.Text,
                                        DdlUnlimited.Text, DdlHalfDay.Text, DdlSaturday.Text, DdlHoliday.Text,
                                        DdlSubstitute.Text, DdlRelieving.Text, ReadSession().UserId.ToString(),TxtMaxReqDays.Text,txtMinReqDays.Text
                                       );
            ErrorMessage(dt);

        }

        private void PopulateData()
        {
            var dr = _leaveTypesDao.SelectById(GetLeaveTypeId().ToString());

            if (dr == null)
                return;

            DdlLeaveName.Text = dr["NAME_OF_LEAVE"].ToString();
            DdlLeaveName.Enabled = false;
            TxtDescription.Text = dr["LEAVE_DETAILS"].ToString();
            TxtDefaultDays.Text = dr["NO_OF_DAYS_DEFAULT"].ToString();
            DdlOccurrence.Text = dr["OCCURRENCE"].ToString();
            TxtMaxDays.Text = dr["MAX_DAYS"].ToString();
            TxtMaxAccumulation.Text = dr["MAX_ACCUMULATION"].ToString();

            DdlLfaDays.Text =ParseBoolen(dr["IS_LFA"].ToString()) ? "1" : "0";
            TxtMaxReqDays.Text = dr["MAX_REQ_DAYS"].ToString();
            txtMinReqDays.Text = dr["MIN_REQ_DAYS"].ToString();

            if (Convert.ToBoolean(dr["IS_LFA"].ToString()))
            {
                PnlLfaDays.Visible = true;
                TxtNoofLfadays.Text = dr["LFADAYS"].ToString();
            }
            else
            {
                PnlLfaDays.Visible = false;
            }

            DdlIsActive.Text =ParseBoolen(dr["IS_ACTIVE"].ToString()) ? "1" : "0";
            DdlCashable.Text =ParseBoolen(dr["IS_CASHABLE"].ToString()) ? "1" : "0";

            DdlUnlimited.Text =ParseBoolen(dr["IS_UNLIMITED"].ToString()) ? "1" : "0";
            DdlHoliday.Text =ParseBoolen(dr["IS_HOLIDAY"].ToString()) ? "1" : "0";
            DdlSaturday.Text =ParseBoolen(dr["IS_SATURDAY"].ToString()) ? "1" : "0";
            DdlHalfDay.Text =ParseBoolen(dr["IS_HOURLY"].ToString()) ? "1" : "0";

            DdlSubstitute.Text =ParseBoolen(dr["IS_SUBSTITUTED"].ToString()) ? "1" : "0";
            DdlRelieving.Text =ParseBoolen(dr["RELIEVING"].ToString()) ? "1" : "0";




        }

        private void DeleteData()
        {
          
            var dr = _leaveTypesDao.Delete(GetLeaveTypeId().ToString());
              if (dr == null)
                return;
              if (dr["SUCCESS"].ToString() == "0")
              {
                  LblMsg.Text = dr["REMARKS"].ToString();
                  LblMsg.ForeColor = System.Drawing.Color.Red;
              }
              else
              {
                  LblMsg.Text = dr["REMARKS"].ToString();
                  LblMsg.ForeColor = System.Drawing.Color.Green;
                  Response.Redirect("/LeaveManagementModule/LeaveType/List.aspx");
              }
            

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;

            }
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void DdlLfaDays_SelectedIndexChanged(object sender, EventArgs e)
        {

            LfadaysVisible();
        }

        private void LfadaysVisible()
        {
            if (DdlLfaDays.Text == "1")
            {
                PnlLfaDays.Visible = true;
            }
            else
            {
                PnlLfaDays.Visible = false;
            }
        }

        protected void TxtDefaultDays_TextChanged(object sender, EventArgs e)
        {
            TxtMaxReqDays.Text = TxtDefaultDays.Text;
        }
    }
}
