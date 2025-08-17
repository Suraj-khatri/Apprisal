using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.AttendenceWeb.LWP
{
    public partial class ListLWPIndividual : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsDaoInv = null;
        public ListLWPIndividual()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsDaoInv = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 266) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            init();
        }

        private void init()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDaoInv.getDataset("EXEC [ProcAbsence2UnpaidLeave] @flag='i', @emp_id=" + filterstring(ReadSession().Emp_Id.ToString()) + "").Tables[0];

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
                str.Append("<td colspan='" + cols + "' align=\"center\">No Record Found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }
    }
}