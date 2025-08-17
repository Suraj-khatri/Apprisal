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
    public partial class AddEmployee : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblGroupName.Text = _clsDao.GetSingleresult(@"select sdd.DETAIL_TITLE from attendance_group a 
                                                inner join StaticDataDetail sdd on sdd.ROWID=a.name	 where a.id=" + GetGroupId() + "");
                
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 220) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                
                if (GetId() > 0)
                {
                    btnDelete.Visible = true;
                    populateGroupEmployee();
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
            btnBack.Attributes.Add("onclick", "history.back();return false");
        }
        public string GetURL()
        {
            return "EmployeeList.aspx?group_id=" + GetGroupId() + "";
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        public long GetGroupId()
        {
            return (Request.QueryString["group_id"] != null ? long.Parse(Request.QueryString["group_id"].ToString()) : 0);
        }

        private void populateGroupEmployee()
        {
            DataTable dt = _clsDao.getTable("exec [procManageAttendanceGroupDetails] @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                hdnEmpId.Value = dr["emp_id"].ToString();
                lblGroupName.Text = dr["group_name"].ToString();
                txtEmployeeName.Text = dr["emp_name"].ToString();
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
            string[] e = txtEmployeeName.Text.Split('|');
            hdnEmpId.Value = e[1];

            string flag = "";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = _clsDao.GetSingleresult("Exec [procManageAttendanceGroupDetails] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetId().ToString()) + ","
            + " @att_group_id=" + filterstring(GetGroupId().ToString()) + ",@emp_id=" + filterstring(hdnEmpId.Value) + ","
            + " @status=" + filterstring(ddlIsActive.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("EmployeeList.aspx?group_id=" + GetGroupId() + "");
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
            string msg = _clsDao.GetSingleresult("Exec [procManageAttendanceGroupDetails] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("EmployeeList.aspx?group_id="+GetGroupId()+"");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}