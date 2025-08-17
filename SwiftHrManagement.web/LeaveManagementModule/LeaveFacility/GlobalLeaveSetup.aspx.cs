using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveFacility
{
    public partial class GlobalLeaveSetup : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 183) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                OnPopulateDdl();
                hdnEmpType.Value = GetEmpType().ToString();
                if (GetEmpType() > 0)
                {
                    OnShowDetails();
                }
            }
        }
        private long GetEmpType()
        {
            return (Request.QueryString["empType"] != null ? long.Parse(Request.QueryString["empType"]) : 0);
        }
        private void OnPopulateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlEmpType, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=10", "ROWID", "DETAIL_TITLE", "", "Select");
            _clsDao.CreateDynamicDDl(ddlLeaveType, "SELECT ID,NAME_OF_LEAVE FROM LeaveTypes  WHERE IS_ACTIVE=1", "ID", "NAME_OF_LEAVE", "", "Select");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Error in operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string msg = _clsDao.GetSingleresult("Exec [procGlobalLeaveSetup] @flag='i',@emp_type=" + filterstring(ddlEmpType.Text) + ","
                    + " @leave_type=" + filterstring(ddlLeaveType.Text) + ",@default_days=" + filterstring(txtDefaultDays.Text) + ","
                    + " @user="+filterstring(ReadSession().Emp_Id.ToString())+"");

            if (msg.Contains("Success"))
            {
                OnShowDetails();
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnShowDetails()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procGlobalLeaveSetup] @flag='s',@emp_type=" + filterstring(hdnEmpType.Value) + "");
            int cols = dt.Columns.Count;
          
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rptGlobal.InnerHtml = str.ToString();
            }
        }

        protected void ddlEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnEmpType.Value = ddlEmpType.Text;
            OnShowDetails();
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("update globalLeaveSetup set flag='d',modified_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                        + " modified_date=" + filterstring(System.DateTime.Now.ToString()) + " where id=" + hdnId.Value + "");

                OnShowDetails();
            }
            catch
            {
                lblmsg.Text = "Error In Deletion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlLeaveType.Text!="")
            {
                txtDefaultDays.Text = _clsDao.GetSingleresult("select NO_OF_DAYS_DEFAULT from LeaveTypes where ID="+ddlLeaveType.Text+"");
            }
        }
    }
}