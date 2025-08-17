using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.TrainingModule.Schedule
{
    public partial class ViewSchedule : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProgramName.Text = _clsDao.GetSingleresult("select programName from training where id=" + GetTrainingId() + "");
            OnDisplay();
        }
        private long GetTrainingId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
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
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        if (i == 2 || i == 3 || i == 4)
                        {
                            str.Append("<td align=\"left\" nowrap='nowrap'>" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
        }
    }
}
