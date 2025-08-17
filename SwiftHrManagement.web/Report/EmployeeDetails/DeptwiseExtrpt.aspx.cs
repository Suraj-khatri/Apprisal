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
    public partial class DeptwiseExtrpt : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        string currPage = "";
        public DeptwiseExtrpt()
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
            string branchid = "";
            string deptid = "";

            if (Request.QueryString["branchname"] != null)
                lblbranch.Text = Request.QueryString["branchname"];
            if (Request.QueryString["deptname"] != null)
                lbldept.Text = Request.QueryString["deptname"];

            if (Request.QueryString["branchid"] != null)
                branchid = Request.QueryString["branchid"];
            if (Request.QueryString["deptid"] != null)
                deptid = Request.QueryString["deptid"];
            
            StringBuilder _strext = new StringBuilder("<div class=\"table-responsive col-md-6 col-md-offset-3\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsdao.getTable("select FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME 'Employee Name', EXTENSION_NUMBER 'Extension No.'from Employee "
            + " where BRANCH_ID = "+ filterstring(branchid) +" and DEPARTMENT_ID = "+ filterstring(deptid) +"");
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
            _strext.Append("</table></div>");
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
