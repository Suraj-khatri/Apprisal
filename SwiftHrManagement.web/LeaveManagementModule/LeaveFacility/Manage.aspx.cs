using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveFacility
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        private string leaveType = "";
        private string jobType = "";
        private string value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
      
            if(!IsPostBack)
            {
                PopulateDdl();
                FillGrid();
            }

        }

        public void PopulateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlBranch, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPosition.Items.Clear();
            if(ddlBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlPosition, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=4", "ROWID", "DETAIL_TITLE", "", "Select");
            }
        }

        protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployee.Items.Clear();
            if(ddlBranch.Text != "" && ddlPosition.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlEmployee, "select EMPLOYEE_ID,EMP_CODE+'|'+FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME [EmpName] from Employee where BRANCH_ID=" + filterstring(ddlBranch.Text) + " and POSITION_ID=" + filterstring(ddlPosition.Text), "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        string CreateDDL(string id)
        {
            var html = new StringBuilder();
            html.Append("<select id=\"job_type_" + id + "\" name =\"jobType_" + id + "\" class=\"FltCMBDesign\" style=\"width:130px\">");
            html.AppendLine("<option value=\"\">Select</option>");
            html.AppendLine("<option value=\"in\">Increment By</option>");
            html.AppendLine("<option value=\"de\">Decrement By</option>");
            html.AppendLine("</select>");
            return html.ToString();
        }

        private void FillGrid()
        {
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"2\" cellspacing=\"2\" align=\"center\">");
            DataTable dt = new DataTable();
            var sql = "select ID,NAME_OF_LEAVE,NO_OF_DAYS_DEFAULT from LeaveTypes";
            dt = _clsDao.getTable(sql);

            str.Append("<tr>");
            str.Append("<th align=\"left\">Leave Type</th>");
            str.AppendLine("<th align=\"left\">Job Type</th>");
            str.AppendLine("<th align=\"left\">No. Of Days</th>");
            str.AppendLine("<th align=\"left\"></th>");
            //str.AppendLine("<th align=\"left\"></th>");
            str.Append("</tr>");

            foreach(DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.AppendLine("<td align=\"left\">" + dr["NAME_OF_LEAVE"].ToString() + "</td>");
                str.AppendLine("<td align=\"left\"><div style=\"margin-left:none\">" + CreateDDL(dr["ID"].ToString()) + "</div></td>");
                str.AppendLine("<td align=\"left\"><div style=\"margin-left:none\"><input type=\"text\" id=\"text_" + dr["ID"].ToString() + "\" name=\"days_" + dr["ID"].ToString() + "\" class=\"inputTextBoxLP1\" onblur=\"checknumber(this.value);\" style=\"width:100px\"></div></td>");
                str.AppendLine("<td align=\"left\"><a OnClick=\"UpdateTable('" + dr["ID"].ToString() + "')\" class=\"clickImage\">Apply</a></td>");
                //str.AppendLine("<td align=\"left\"><a href=\"/LeaveManagementModule/LeaveAssignment/Manage.aspx\" class=\"clickImage\">Add New</a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptLeaveType.InnerHtml = str.ToString();
        }

        protected string AutoSelect(string str1)
        {
            if (str1.ToLower() != null)
                return "selected=\"selected\"";

            return "";
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            jobType = (Request.Form["jobType_" + hdnLeaveID.Value + ""] ?? "").ToString();
            value = (Request.Form["days_" + hdnLeaveID.Value + ""] ?? "").ToString();
            var sql = "Exec [proc_GlobalLeaveUpdate] @branch=" + filterstring(ddlBranch.Text) + ",@position=" +
                      filterstring(ddlPosition.Text) + ",@empId=" + filterstring(ddlEmployee.Text) +
                      ",@leaveType=" + hdnLeaveID.Value + ",@value=" + filterstring(value) + ",@jobType=" +
                      filterstring(jobType) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString());
           DataTable dt = _clsDao.getTable(sql);

           DataRow dr = null;
           if (dt == null || dt.Rows.Count < 0)
               return;
           dr = dt.Rows[0];

           if (dr["error_code"].ToString() == "0")
           {
               divMsg.InnerText = dr["msg"].ToString();
               divMsg.Attributes.Add("class", "warning");
           }
           else
           {
               divMsg.InnerText = dr["msg"].ToString();
               divMsg.Attributes.Add("class", "success");

           }

        }
    }
}