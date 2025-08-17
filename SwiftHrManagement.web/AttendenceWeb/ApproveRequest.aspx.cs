using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.AttendenceDao;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;
using System.Data;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class ApproveRequest : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDdl();
                populateAttendance();
                disabledFields();
            }
        }

        private void disabledFields()
        {
            txtEmpId.Enabled = false;
            ddlApprovedBy.Enabled = false;
            txtLoginDate.Enabled = false;
            ddlhourin.Enabled = false;
            ddlminutein.Enabled = false;
            txtLogoutDate.Enabled = false;
            ddlhourout.Enabled = false;
            ddlminuteout.Enabled = false;
            txtRemarks.Enabled = false;
        }

        private void PopulateDdl()
        {
            StaticPage.SetTimeDDL(ref ddlhourin, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlminutein, "", "Minute", false);
            StaticPage.SetTimeDDL(ref ddlhourout, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlminuteout, "", "Minute", false);
        }
        private void populateAttendance()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset(@"Exec procManageAttendanceRequest @flag='c',@id=" + filterstring(GetId().ToString()) + "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                _clsDao.CreateDynamicDDl(ddlApprovedBy,
                    "EXEC [procGetSupervisor] @FLAG='a', @EMP_ID=" + filterstring(dr["emp_id"].ToString()) + "", "EMP_ID", "SUPERVISOR", "", "SELECT");
                txtEmpId.Text = dr["EMP_NAME"].ToString();
                txtLoginDate.Text = dr["FROM_DATE"].ToString();
                txtLogoutDate.Text = dr["TO_DATE"].ToString();
                ddlhourin.Text = dr["FROM_HOUR"].ToString();
                ddlminutein.Text = dr["FROM_MINUTE"].ToString();
                ddlApprovedBy.SelectedValue = dr["approved_by"].ToString();
                ddlhourout.Text = dr["TO_HOUR"].ToString();
                ddlminuteout.Text = dr["TO_MINUTE"].ToString();
                txtRemarks.Text = dr["remarks"].ToString();
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                OnApprove();
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                OnReject();
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnApprove()
        {
            lblmsg.Text = "";
            
            string reqInTime = txtLoginDate.Text + ' ' + ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
            string reqOutTime = txtLogoutDate.Text + ' ' + ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";

            if (DateTime.Parse(reqInTime) > DateTime.Parse(reqOutTime))
            {
                lblmsg.Text = "Invalid Time, Time Out must be greater than Time In!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                string logoutdate;
                string logindate = (((txtLoginDate.Text) + " " + (ddlhourin.Text) + ":" + (ddlminutein.Text)).ToString());
                if (ddlhourout.Text != "" && ddlminuteout.Text != "")
                {
                    logoutdate = (((txtLogoutDate.Text) + " " + (ddlhourout.Text) + ":" + (ddlminuteout.Text)).ToString());
                }
                else
                {
                    logoutdate = "";
                }

                _clsDao.GetSingleresult("Exec procManageAttendanceRequest @flag='d',@loginDateTime=" + filterstring(logindate) + ","
                + " @logoutDateTime=" + filterstring(logoutdate) + ",@id="+filterstring(GetId().ToString())+"");
                Response.Redirect("ApproveList.aspx");
            }              
        }

        private void OnReject()
        {
            _clsDao.GetSingleresult("Exec procManageAttendanceRequest @flag='e',@id="+filterstring(GetId().ToString())+"");
            Response.Redirect("ApproveList.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveList.aspx");
        }
    }
}