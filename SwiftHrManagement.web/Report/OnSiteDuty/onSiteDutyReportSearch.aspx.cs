using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.OnSiteDuty
{
    public partial class onSiteDutyReportSearch : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO CLsDAo = null;
        public onSiteDutyReportSearch()
        {
            CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 47) == false)
                {
                    Response.Redirect("/Error.aspx");

                }
                PopulateDropdownList();
            }
                        
        }

        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlFromBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        } 

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            searchRecords();
        }

        private void searchRecords()
        {
            Response.Redirect("onSiteDutyReport.aspx?empId=" + ddlEmpName.Text + "&datefrom=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString()
                + "&branch=" + DdlFromBranch.Text.ToString() + "&dept=" + DdlFromDept.Text.ToString());
        }

        protected void DdlFromBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlFromDept.Items.Clear();
            ddlEmpName.Items.Clear();
            if (DdlFromBranch.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlFromDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlFromBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }

        protected void DdlFromDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmpName.Items.Clear();
            if (DdlFromBranch.Text != "" && DdlFromDept.Text!="")
            {
                CLsDAo.CreateDynamicDDl(ddlEmpName, "SELECT EMPLOYEE_ID,FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME NAME"
                        + " FROM Employee WHERE BRANCH_ID=" + filterstring(DdlFromBranch.Text) + " and DEPARTMENT_ID=" + filterstring(DdlFromDept.Text) + "", "EMPLOYEE_ID", "NAME", "", "All");
            }
        }
    }
}
