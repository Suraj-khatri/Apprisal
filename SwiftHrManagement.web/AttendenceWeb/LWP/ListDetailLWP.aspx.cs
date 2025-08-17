using System;
using System.Data;
using System.Text;


namespace SwiftHrManagement.web.AttendenceWeb.LWP
{
    public partial class ListDetailLWP : BasePage
    {
        private ClsDAOInv _clsDaoInv = null;
        public ListDetailLWP()
        {
            this._clsDaoInv = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rptAbsent();
        }
        private string getFromDate()
        {
            return Request.QueryString["fromdate"] == null ? "" : Request.QueryString["fromdate"].ToString();
        }
        private string getToDate()
        {
            return Request.QueryString["todate"] == null ? "" : Request.QueryString["todate"].ToString();
        }
        private string getEmpId()
        {
            return Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();  
        }

        private void rptAbsent()
        {

            lblFromDate.Text = getFromDate();
            lblToDate.Text = getToDate();

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDaoInv.getDataset("EXEC [ProcAbsence2UnpaidLeave] @flag='d', @fromdate=" + filterstring(getFromDate()) + ","
                                + " @TODATE=" + filterstring(getToDate()) + ",@emp_id="+filterstring(getEmpId().ToString())+"").Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }

            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {

                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan='" + cols + 1 + "' align=\"center\">No Record Found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDivAbsent.InnerHtml = str.ToString();
        }
    }
}