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
    public partial class AddGroup : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblShiftName.Text = _clsDao.GetSingleresult(@"select sdd.DETAIL_TITLE from attendance_shift a 
                                                inner join StaticDataDetail sdd on sdd.ROWID=a.name	 where a.id="+GetShiftId()+"");
                populateDropDownList();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 220) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                viewShiftGroup();
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
        private long GetShiftId()
        {
            return (Request.QueryString["shift_id"] != null ? long.Parse(Request.QueryString["shift_id"].ToString()) : 0);
        }
        private void populateDropDownList()
        {
            _clsDao.CreateDynamicDDl(ddlGroupName, @"select a.id,sdd.DETAIL_TITLE name from attendance_group a 
                                                    inner join StaticDataDetail sdd on sdd.ROWID=a.name
                                                    where a.status='Active'", "id", "name", "", "SELECT");
        }
        private void populateShift()
        {
            DataTable dt = _clsDao.getTable("exec [procManageAttShiftGroup] @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                ddlGroupName.SelectedValue = dr["name"].ToString();
                lblShiftName.Text=dr["name"].ToString();
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
            string msg = _clsDao.GetSingleresult("Exec [procManageAttShiftGroup] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetId().ToString()) + ","
            + " @att_shift_id=" + filterstring(GetShiftId().ToString()) + ",@att_group_id=" + filterstring(ddlGroupName.Text) + ","
            + " @status=" + filterstring(ddlIsActive.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                viewShiftGroup();
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
            string msg = _clsDao.GetSingleresult("Exec [procManageAttShiftGroup] @flag='d',@id=" + filterstring(GetId().ToString()) + "");
            if (msg.Contains("Success"))
            {
                viewShiftGroup();
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void viewShiftGroup()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procManageAttShiftGroup] @flag='b',@shift_id="+filterstring(GetShiftId().ToString())+"");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
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
                    str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\" style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\"  /><i class=\"fa fa-times\" aria-hidden=\"true\"></a></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("delete from att_shift_group where id="+hdnId.Value+"");
                viewShiftGroup();
            }
            catch
            {
                lblMsg.Text = "Error In Insertion!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}