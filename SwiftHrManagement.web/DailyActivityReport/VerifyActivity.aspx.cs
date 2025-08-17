using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.DailyActivityReport
{
    public partial class VerifyActivity : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 10082) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDDl();
            }
        }

        private void PopulateDDl()
        {
            _clsDao.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDepartment.Items.Clear();
            if (ddlBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + ddlBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }  
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployee.Items.Clear();
            if (ddlBranch.Text != "" && ddlDepartment.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlEmployee, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + ddlBranch.Text + " AND DEPARTMENT_ID=" + ddlDepartment.Text + " and employee_id<>'1000'", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Text == "" || txtToDate.Text == "")
            {
                lblMsg.Text = "Enter Valid Date";
            }
            else
                Response.Redirect("ActivityReport.aspx?empid="+ ddlEmployee.Text + "&fromDate="+ txtFromDate.Text +"&toDate=" + txtToDate.Text);
        }

    }
}
