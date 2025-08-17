using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveDetailedDatewise : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            string fromdate = "";
            string todate = "";
            string empId = "";

            if (Request.QueryString["fromdate"] != null)
                fromdate = Request.QueryString["fromdate"];
            if (Request.QueryString["todate"] != null)
                todate = Request.QueryString["todate"];
            if (Request.QueryString["empId"] != null)
                empId = Request.QueryString["empId"];

            lblFromDate.Text = fromdate;
            lblTodate.Text = todate;

            this.lblHeading.Text = _clsDao.GetSingleresult("select COMP_NAME from Company"); ;
            this.lbldesc.Text = _clsDao.GetSingleresult("select COMP_ADDRESS from Company");

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("EXEC [ProcLeaveDetailedDatewise] @flag='i',@fromDate=" + filterstring(fromdate) + ","
            + " @ToDate=" + filterstring(todate) + ",@emp_id=" + filterstring(empId) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}