using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.DutyRooster
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                populateDropDownList();
                //if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 220) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}
                if (GetId() > 0)
                {
                    OnPopulate();
                }
                else
                {
                    btnDelete.Visible = false;
                }
                
            }
            btnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void populateDropDownList()
        {
            StaticPage.SetTimeDDL(ref ddlHourIn, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlMinuteIn, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlHourOut, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlMinuteOut, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlLHourOut,"" ,"Hour", true);
            StaticPage.SetTimeDDL(ref ddlLMinuteOut, "", "Minute", false);

            StaticPage.SetTimeDDL(ref ddlLhourIn, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlLMinuteIn, "", "Minute", false);

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
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = _clsDao.GetSingleresult("Exec [proc_dutyRooster] @flag=" + filterstring(flag) + ","
                    + " @id=" + filterstring(GetId().ToString()) + ",@OFFICE_LOGOUT_TIME=" + filterstring(logoutTime) + ","
                    + " @EMP_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@START_DATE=" + filterstring(txtStartDate.Text) + ","
                    + " @END_DATE=" + filterstring(txtEndDate.Text) + ",@OFFICE_LOGIN_TIME=" + filterstring(loginTime) + ","
                    + " @LUNCH_LOGOUT_TIME=" + filterstring(LunchLogoutTime) + ",@LUNCH_LOGIN_TIME=" + filterstring(LunchLoginTime) + ","
                    + " @H1=" + filterstring(chkSunday.Checked.ToString()) + ",@H2=" + filterstring(chkMonday.Checked.ToString()) + ","
                    + " @H3=" + filterstring(chkTuesday.Checked.ToString()) + ",@H4=" + filterstring(chkWednesday.Checked.ToString()) + ","
                    + " @H5=" + filterstring(chkThursday.Checked.ToString()) + ",@H6=" + filterstring(chkfriday.Checked.ToString()) + ","
                    + " @H7=" + filterstring(chkSaturday.Checked.ToString()) + ",@USER=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                    + " @SESSION_ID="+filterstring(ReadSession().Sessionid)+"");

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

        private void TotalCalculatedHour()
        {
            if (ddlHourIn.Text != "" && ddlHourOut.Text != "" && ddlMinuteIn.Text != "" && ddlMinuteOut.Text != "" && ddlLhourIn.Text != "" && ddlLHourOut.Text != "" && ddlLMinuteIn.Text != "" && ddlLMinuteOut.Text != "")
            {
                string loginTime = ddlHourIn.Text + ':' + ddlMinuteIn.Text + ':' + "00";
                string logoutTime = ddlHourOut.Text + ':' + ddlMinuteOut.Text + ':' + "00";
                string LunchLogoutTime = ddlLHourOut.Text + ':' + ddlLMinuteOut.Text + ':' + "00";
                string LunchLoginTime = ddlLhourIn.Text + ':' + ddlMinuteIn.Text + ':' + "00";
            }
        }

        protected void ddlHourIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlMinuteIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlLMinuteOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlLHourOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlHourOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlMinuteOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlLhourIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlLMinuteIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void OnPopulate()
        {

        }

    }
}