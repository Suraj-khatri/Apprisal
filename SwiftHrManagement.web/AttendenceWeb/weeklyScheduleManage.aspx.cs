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
    public partial class weeklyScheduleManage : BasePage
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
                    populateSch();
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
            _clsDao.CreateDynamicDDl(ddlSchName, "EXEC ProcStaticDataView @flag='s',@type_id='83'", "ROWID", "DETAIL_TITLE", "", "SELECT");
        }
        private void populateSch()
        {
            DataTable dt = _clsDao.getTable("exec [procManageAttWeeklySchedule] @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                ddlSchName.SelectedValue = dr["name"].ToString();
                txtDesc.Text = dr["description"].ToString();
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
            string flag = "";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = _clsDao.GetSingleresult("Exec [procManageAttWeeklySchedule] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetId().ToString()) + ","
                        + " @name=" + filterstring(ddlSchName.Text) + ",@desc=" + filterstring(txtDesc.Text) + ","
                        + " @status=" + filterstring(ddlIsActive.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("weeklyScheduleList.aspx");
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
            string msg = _clsDao.GetSingleresult("Exec [procManageAttWeeklySchedule] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("weeklyScheduleList.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}