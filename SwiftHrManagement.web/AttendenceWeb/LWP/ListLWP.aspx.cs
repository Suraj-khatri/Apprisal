using System;
using System.Data;
using System.Text;


namespace SwiftHrManagement.web.AttendenceWeb.LWP
{
    public partial class ListLWP : BasePage
    {
        private ClsDAOInv _clsDaoInv = null;
        public ListLWP()
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
            return Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
        }
        private void rptAbsent()
        {

            lblFromDate.Text = getFromDate();
            lblToDate.Text = getToDate();
            Lblcompany.Text = _clsDaoInv.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsDaoInv.GetSingleresult("select COMP_ADDRESS from Company");

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDaoInv.getDataset("EXEC [ProcAbsence2UnpaidLeave] @flag='a', @fromdate=" + filterstring(getFromDate()) + ","
                                + " @TODATE=" + filterstring(getToDate()) + ",@emp_id=" + filterstring(getEmpId().ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">View</th>");
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
                    str.Append("<td class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"ListDetailLWP.aspx?emp_id='" + dr["employee id"].ToString() + "'&fromdate='" + lblFromDate.Text + "'&todate='" + lblToDate.Text + "'\"><i class=\"fa fa-eye\"></i></a></td>");
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan='5' align=\"center\">No Record Found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDivAbsent.InnerHtml = str.ToString();
        }
    }
}