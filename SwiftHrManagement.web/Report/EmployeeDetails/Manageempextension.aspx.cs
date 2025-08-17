using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class Manageempextension : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();

        public Manageempextension()
        {
            _clsdao = new clsDAO();

            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatebranch();

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 69) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            
        }

        private void populatebranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");            
        }
        private void populatedept()
        {
            _clsdao.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID, DEPARTMENT_NAME from Departments where BRANCH_ID ='" + DdlBranch.Text + "'", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }
        protected void BtnViewRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeptwiseExtrpt.aspx?branchid=" + DdlBranch.Text + "&deptid=" + DdlDepartment.Text + "&branchname=" + DdlBranch.SelectedItem.Text + "&deptname="+ DdlDepartment.SelectedItem.Text +"");
        }

        protected void BtnViewRptEW_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpExtensionreport.aspx?id="+ Hdnempid.Value +"");
        }

        protected void DdlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            populatedept();
        }
    }
}
