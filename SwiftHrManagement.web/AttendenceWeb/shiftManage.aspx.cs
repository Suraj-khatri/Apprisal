using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using System.Data;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class shiftManage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDropDownList();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 220) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
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
        private void populateDropDownList()
        {
            _clsDao.CreateDynamicDDl(ddlShiftName, "EXEC ProcStaticDataView @flag='s',@type_id='81'", "ROWID", "DETAIL_TITLE", "", "SELECT");
            _clsDao.CreateDynamicDDl(ddlWeeklySchedule, @"select a.id,sdd.DETAIL_TITLE as name from att_weekly_schedule a 
                                                    inner join StaticDataDetail sdd on sdd.ROWID=a.name where status='Active'", "id", "name", "", "SELECT");
        }
        private void populateShift()
        {
            DataTable dt = _clsDao.getTable("exec procManageAttendanceShift @flag='s',@id=" +filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                ddlShiftName.SelectedValue = dr["name"].ToString();
                txtDesc.Text = dr["description"].ToString();
                ddlIsActive.SelectedValue = dr["status"].ToString();
                ddlWeeklySchedule.SelectedValue = dr["att_ws_id"].ToString();
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
            string flag = "";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = _clsDao.GetSingleresult("Exec [procManageAttendanceShift] @flag=" + filterstring(flag) + ",@id="+filterstring(GetId().ToString())+","
            + " @name=" + filterstring(ddlShiftName.Text) + ",@desc=" + filterstring(txtDesc.Text) + ",@weeklySchId="+filterstring(ddlWeeklySchedule.Text)+","
            + " @status=" + filterstring(ddlIsActive.Text) + ",@user="+filterstring(ReadSession().Emp_Id.ToString())+"");

            if (msg.Contains("Success"))
            {
                Response.Redirect("shiftList.aspx");
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
            string msg = _clsDao.GetSingleresult("Exec [procManageAttendanceShift] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("shiftList.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}