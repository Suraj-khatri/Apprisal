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
    public partial class BackDateLogin : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        EmployeeDAO _employeedao = null;
        AttendenceDao _attendencedao = null;
        AttendenceCore _attendence = null;
        BasePage _basepage = null;
        clsDAO _clsDao = null;

        public BackDateLogin()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._attendence = new AttendenceCore();
            this._attendencedao = new AttendenceDao();
            this._employeedao = new EmployeeDAO();
            this._basepage = new BasePage();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 20) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
                if (GetId() > 0)
                {
                    populateAttendance();
                    BtnDelete.Visible = true;
                }
                else
                {
                    txtLoginDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                    txtLogoutDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                    BtnDelete.Visible = false;
                }
            }
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
            dt = _clsDao.getDataset(@"SELECT  id,rtrim(ltrim(DBO.GetEmployeeFullNameOfId(emp_id))) AS EMP_NAME,
                           CONVERT(VARCHAR,login_time,101) FROM_DATE,DATEPART(HH,login_time) FROM_HOUR ,DATEPART(MI,login_time) FROM_MINUTE,
                             CONVERT(VARCHAR,logout_time,101) TO_DATE,DATEPART(HH,logout_time) TO_HOUR,
                             DATEPART(MI,logout_time) TO_MINUTE,remarks "
                            + " FROM atttendance WHERE id=" + GetId() + "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                txtEmpId.Text = dr["EMP_NAME"].ToString();
                txtLoginDate.Text = dr["FROM_DATE"].ToString();
                txtLogoutDate.Text = dr["TO_DATE"].ToString();
                ddlhourin.Text = dr["FROM_HOUR"].ToString();
                ddlminutein.Text = dr["FROM_MINUTE"].ToString();

                ddlhourout.Text = dr["TO_HOUR"].ToString();
                ddlminuteout.Text = dr["TO_MINUTE"].ToString();

                txtRemarks.Text = dr["remarks"].ToString();
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private bool checkTime()
        {
            string reqInTime = txtLoginDate.Text + ' ' + ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
            string reqOutTime = txtLogoutDate.Text + ' ' + ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";

            if (DateTime.Parse(reqInTime) > DateTime.Parse(reqOutTime))
            {
                lblmsg.Text = "Invalid Time, Time Out must be greater than Time In !";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
                return true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                if (ddlhourout.Text != "")
                {
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
                        this.manageBackDateLogin();
                        Response.Redirect("List.aspx");
                    }
                }
                else
                {
                    this.manageBackDateLogin();
                    Response.Redirect("List.aspx");
                }
            }
            catch
            {
                lblmsg.Text = "Error in insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        private void manageBackDateLogin()
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
            if (GetId() > 0)
            {
                _clsDao.runSQL("UPDATE atttendance SET login_time =" + filterstring(logindate) + ",logout_time = " + filterstring(logoutdate) + ",att_date=" + filterstring(logindate) + ",remarks=" + filterstring(txtRemarks.Text) + ""
                + " WHERE id = " + filterstring(GetId().ToString()) + "");
            }
            else
            {
                string[] a = txtEmpId.Text.Split('|');
                string empId = a[1];
                _clsDao.runSQL("INSERT INTO atttendance(emp_id,login_time,logout_time,remarks,att_date) VALUES(" + filterstring(empId) + "," + filterstring(logindate) + "," + filterstring(logoutdate) + "," + filterstring(txtRemarks.Text) + "," + filterstring(logindate) + ")");
            }
        }
        protected void ddlhourout_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string oldValue = this._attendencedao.CRUDLog(GetId().ToString());
            this._attendencedao.LogJobHistoryReport("Delete", "atttendance", GetId().ToString(), oldValue, "", ReadSession().UserId);
            _clsDao.runSQL("DELETE FROM atttendance WHERE id=" + GetId() + "");
            Response.Redirect("List.aspx");
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
