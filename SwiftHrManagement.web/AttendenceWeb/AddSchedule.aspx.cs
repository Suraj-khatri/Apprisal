using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class AddSchedule : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblWeeklyName.Text = _clsDao.GetSingleresult(@"select sdd.DETAIL_TITLE from att_weekly_schedule a inner join StaticDataDetail sdd on sdd.ROWID=a.name
                                                                where a.id=" + GetWSID() + "");
                populateDropDownList();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 220) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                ShowSchedules();
                if (GetId() > 0)
                {
                    btnDelete.Visible = true;
                    populateShift();
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
        private long GetWSID()
        {
            return (Request.QueryString["ws_id"] != null ? long.Parse(Request.QueryString["ws_id"].ToString()) : 0);
        }
        private void populateDropDownList()
        {
            StaticPage.SetTimeDDL(ref ddlHourIn, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlMinuteIn, "", "Minute", false);
            StaticPage.SetTimeDDL(ref ddlWorkingHour, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlWorkingMinute, "", "Minute", false);
            _clsDao.CreateDynamicDDl(ddlDayName, "EXEC ProcStaticDataView @flag='s',@type_id='84'", "DETAIL_TITLE", "DETAIL_TITLE", "", "SELECT");
        }
        private void populateShift()
        {
            DataTable dt = _clsDao.getTable("exec [procManageAttWeeklyScheduleDetails] @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                ddlDayName.SelectedValue = dr["day_name"].ToString();
                lblWeeklyName.Text = dr["ws_name"].ToString();
                ddlIsActive.SelectedValue = dr["status"].ToString();
            }
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
            string workingHour = ddlWorkingHour.Text + ':' + ddlWorkingMinute.Text + ':' + "00";  

            string flag = "";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = _clsDao.GetSingleresult("Exec [procManageAttWeeklyScheduleDetails] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetId().ToString()) + ","
            + " @att_ws_id=" + filterstring(GetWSID().ToString()) + ",@login_time=" + filterstring(loginTime) + ",@workingHour="+filterstring(workingHour)+","
            + " @status=" + filterstring(ddlIsActive.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@day_name=" + filterstring(ddlDayName.Text) + "");

            if (msg.Contains("Success"))
            {
                ShowSchedules();
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                lblMsg.Text = "Error In Insertion!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("Exec [procManageAttWeeklyScheduleDetails] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                ShowSchedules();
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ShowSchedules()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procManageAttWeeklyScheduleDetails] @flag='b',@att_ws_id=" + filterstring(GetWSID().ToString()) + "");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("delete from att_weekly_schedule_details where id=" + hdnId.Value + "");
                ShowSchedules();
            }
            catch
            {
                lblMsg.Text = "Error In Insertion!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void TotalCalculatedHour()
        {
            if (ddlHourIn.Text != "" && ddlWorkingHour.Text != "" && ddlMinuteIn.Text != "" && ddlWorkingMinute.Text != "")
            {
                string loginTime = ddlHourIn.Text + ':' + ddlMinuteIn.Text + ':' + "00";
                string workingHour = ddlWorkingHour.Text + ':' + ddlWorkingMinute.Text + ':' + "00";               
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

        protected void ddlWorkingHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlWorkingMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }
    }
}