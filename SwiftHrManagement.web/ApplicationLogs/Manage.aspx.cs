using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.ApplicationLogs;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.ApplicationLogs
{
    public partial class Manage : BasePage
    {
        ApplicationLogsDao _apllicationLogsDao = new ApplicationLogsDao();
        
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public Manage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (GetLogId() > 0)
                {
                    PopulateOperation();
                }

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 54) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private long GetLogId()
        {
            return (Request.QueryString["log_Id"] != null ? long.Parse(Request.QueryString["log_Id"].ToString()) : 0);
        }

        private void PopulateOperation()
        {
            var dt = _apllicationLogsDao.PopulateAppLogById(GetLogId().ToString());
            if (dt == null || dt.Rows.Count < 1)
                return;

            var dr = dt.Rows[0];
            created_date.Text = dr["created_date"].ToString();
            table_name.Text = dr["table_name"].ToString();
            data_id.Text = dr["data_id"].ToString();
            created_by.Text = dr["created_by"].ToString();
            log_type.Text = dr["log_type"].ToString();
            if (dr["log_type"].ToString().ToLower() != "log in" && dr["log_type"].ToString().ToLower() != "log out")
            {
                changeDetails.Visible = true;
                PrintChanges(dr["table_name"].ToString(), dr["log_type"].ToString(), dr["old_data"].ToString(), dr["new_data"].ToString());
            }
            else
            {
                changeDetails.Visible = false;
            }
        }

        private void PrintChanges(string table_name, string logType, string oldData, string newData)
        {
            DataTable dt = null;
            if (table_name.ToLower() == "user functions" || table_name.ToLower() == "role functions")
            {
                dt = _apllicationLogsDao.GetAuditDataForFunction(oldData, newData);
            }
            else if (table_name.ToLower() == "user roles")
            {
                dt = _apllicationLogsDao.GetAuditDataForRule(oldData, newData);
            }
            else
            {
                dt = _apllicationLogsDao.GetHistoryChangedList(logType, oldData, newData);
            }

            if (dt.Rows.Count == 0)
            {
                rpt_grid.InnerHtml = "<center><b> No custodian is assigned.</b><center>";
                return;
            }
            var str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            str.Append("<tr>");
            str.Append("<th   align=\"left\">" + dt.Columns[0].ColumnName + "</th>");
            str.Append("<th align=\"left\">" + dt.Columns[1].ColumnName + "</th>");
            str.Append("<th  align=\"left\">" + dt.Columns[2].ColumnName + "</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + dr[0] + "</td>");
                if (dr[3].ToString() == "Y")
                {
                    if (logType.ToLower() == "insert")
                    {
                        str.Append("<td align=\"left\">" + dr[1] + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\"><div class=\"oldValue\">" + dr[1] + "</div></td>");
                    }

                    if (logType.ToLower() == "delete")
                    {
                        str.Append("<td align=\"left\">" + dr[2] + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\"><div class=\"newValue\">" + dr[2] + "</div></td>");
                    }

                }
                else
                {
                    str.Append("<td align=\"left\">" + dr[1] + "</td>");
                    str.Append("<td align=\"left\">" + dr[2] + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt_grid.InnerHtml = str.ToString();


        }
    

    }
}
