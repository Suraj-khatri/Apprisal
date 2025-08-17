using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core;
using SwiftHrManagement.DAL.Role;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.TrainingModule.Schedule
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsDao = new clsDAO();
        public Manage()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 217) == false)
                {
                    Response.Redirect("/Error.aspx");

                }
                lblProgramName.Text = _clsDao.GetSingleresult("select programName from training where id=" + GetTrainingId() + "");
                OnDisplay();
            }
        }
        private long GetTrainingId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string msg = _clsDao.GetSingleresult("Exec procManageTrainingSchedule @flag='a',@trainingId=" + filterstring(GetTrainingId().ToString()) + ","
                                    + " @schDate=" + filterstring(txtDate.Text) + ",@fromTime="+filterstring(txtFromTime.Text)+","
                                    + " @toTime=" + filterstring(txtToTime.Text) + ",@topic="+filterstring(txtTopic.Text)+","
                                    + " @trainer=" + filterstring(txtTrainer.Text) + ",@user="+ filterstring(ReadSession().Emp_Id.ToString())+"");

            if (msg.Contains("Success"))
            {
                OnDisplay();
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnDisplay()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procManageTrainingSchedule] @flag='b',@trainingId=" + filterstring(GetTrainingId().ToString()) + "");
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
                        if (i == 2 || i == 3 || i ==4)
                        {
                            str.Append("<td align=\"left\" nowrap='nowrap'>" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
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
                string msg = _clsDao.GetSingleresult("Exec [procManageTrainingSchedule] @flag='c',@id=" + filterstring(hdnId.Value) + ","
                +" @user="+filterstring(ReadSession().Emp_Id.ToString())+"");

                if (msg.Contains("Success"))
                {
                    OnDisplay();
                }
                else
                {
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TrainingModule/HR/List.aspx");
        }
    }
}
