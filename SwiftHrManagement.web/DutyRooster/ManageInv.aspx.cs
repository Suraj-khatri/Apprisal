using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.DutyRooster
{
    public partial class ManageInv : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public ManageInv()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                populateDropDownList();
                if (GetId() > 0)
                    this.populateRoster();
            }

        }

        private void populateDropDownList()
        {
            StaticPage.SetTimeDDL(ref ddlHourIn, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlMinuteIn, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlHourOut, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlMinuteOut, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlLHourOut, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlLMinuteOut, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlLhourIn, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlLMinuteIn, "", "Minute", false);

        }
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        
        private void populateRoster()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [proc_dutyRooster] @flag='S',@ID=" + filterstring(GetId().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
                    txtEmpName.Text = dr["Employee"].ToString();
                    lblDayName.Text = dr["DAY_NAME"].ToString();
                    string is_holiday = dr["IS_HOLIDAY"].ToString();
                    if (is_holiday == "Y")
                    {
                        chkSunday.Checked = true;
                    }
                    else
                    {
                        chkSunday.Checked = false;
                    }
                   
                    txtStartDate.Text = dr["START_DATE"].ToString();
                    txtEndDate.Text = dr["END_DATE"].ToString();
                    //Office In Time
                    
                    ddlHourIn.SelectedValue = dr["IN_TIME_OFFICE_HR"].ToString();
                    ddlMinuteIn.SelectedValue = dr["IN_TIME_OFFICE_MIN"].ToString();
                    //OUT_TIME_OFFICE
                    ddlHourOut.SelectedValue = dr["OUT_TIME_OFFICE_HR"].ToString();
                    ddlMinuteOut.SelectedValue = dr["OUT_TIME_OFFICE_MIN"].ToString();
                    //IN_TIME_LUNCH
                    ddlLHourOut.SelectedValue = dr["OUT_TIME_LUNCH_HR"].ToString();
                    ddlLMinuteOut.SelectedValue = dr["OUT_TIME_LUNCH_MIN"].ToString();
                    //
                    ddlLhourIn.SelectedValue = dr["IN_TIME_LUNCH_HR"].ToString();
                    ddlLMinuteIn.SelectedValue = dr["IN_TIME_LUNCH_MIN"].ToString();

        }

        protected void ddlHourIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMinuteIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlHourOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMinuteOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLHourOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLMinuteOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLhourIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLMinuteIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblMsg.Text = "Error In Insertion!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnSave()
        {
            string loginTime = ddlHourIn.Text + ':' + ddlMinuteIn.Text + ':' + "00";
            string logoutTime = ddlHourOut.Text + ':' + ddlMinuteOut.Text + ':' + "00";
            string LunchLogoutTime = ddlLHourOut.Text + ':' + ddlLMinuteOut.Text + ':' + "00";
            string LunchLoginTime = ddlLhourIn.Text + ':' + ddlMinuteIn.Text + ':' + "00";

            string flag = "";
            string chk = "";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            if (chkSunday.Checked == true)
            {
                 chk = "Y";
            }
            else
            {
                 chk = "N"; 
            }
            string msg = CLsDAo.GetSingleresult("Exec [proc_dutyRooster] @flag=" + filterstring(flag) + ","
                    + " @id=" + filterstring(GetId().ToString()) + ",@OFFICE_LOGOUT_TIME=" + filterstring(logoutTime) + ","
                    + " @START_DATE=" + filterstring(txtStartDate.Text) + ","
                    + " @END_DATE=" + filterstring(txtEndDate.Text) + ",@OFFICE_LOGIN_TIME=" + filterstring(loginTime) + ","
                    + " @LUNCH_LOGOUT_TIME=" + filterstring(LunchLogoutTime) + ",@LUNCH_LOGIN_TIME=" + filterstring(LunchLoginTime) + ","
                    + " @H1=" + filterstring(chk) + ",@USER=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                    + " @SESSION_ID=" + filterstring(ReadSession().Sessionid) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = CLsDAo.GetSingleresult("Exec [proc_dutyRooster] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

       

    }
}