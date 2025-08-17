using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob
{
    public partial class ManageComment : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCommentList();
        }
        private long GetProcessId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateCommentList()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL1\" cellpadding=\"5\" cellspacing=\"5\">");
            DataTable dt = _clsDao.getTable("Exec [ProcManageComment] @flag='a',@ProcessId=" + filterstring(GetProcessId().ToString()) + "");
           
            int cols = dt.Columns.Count;
            int rows = dt.Rows.Count;
            if (rows == 0)
            {
                str.Append("<th><div align=\"left\">No Comments Yet!</div></th>");
            }
            else
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");

                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 2)
                        {
                            str.Append("<td align=\"LEFT\" width=\"500px\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"LEFT\" nowrap=\"nowrap\">" + row[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }                
            }
            str.Append("</table>");
            CommentList.InnerHtml = str.ToString();
        }

        protected void BtnPost_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec [ProcManageComment] @flag='i',@ProcessId=" + filterstring(GetProcessId().ToString()) + ",@comment=" + filterstring(txtComment.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            Response.Redirect("ManageComment.aspx?Id="+GetProcessId()+"");
        }

    }
}
