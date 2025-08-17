using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class EmpExtensionreport : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        string currPage = "";
        public EmpExtensionreport()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 105) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            currPage = getCurrPage();
            Getextensionlist();
        }
        private void Getextensionlist()
        {
            lblHeading.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            string id = "";
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];

            StringBuilder _strext = new StringBuilder("<table border =\"0\" class= \"TBL\" cellpadding=\"5\" cellspacing =\"5\" align =\"left\">");
            DataTable dt = _clsdao.getTable("select FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME 'Employee Name', EXTENSION_NUMBER 'Extension No.'from Employee "
            + " where EMPLOYEE_ID = " + filterstring(id) + "");
            int cols = dt.Columns.Count;

            _strext.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                _strext.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            _strext.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                _strext.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    _strext.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                }
                _strext.Append("</tr>");
            }
            _strext.Append("</table>");
            rptDiv.InnerHtml = _strext.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }
}
