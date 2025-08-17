using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.TransferRpt
{
    public partial class Manage : BasePage
    {
        clsDAO CLsDAo = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CLsDAo.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("DateWise.aspx?startDate=" + txtFrmDate.Text + "&endDate=" + txtToDate.Text
                + "&transferType=" + ddlTransferType.Text + "&branch=" + ddlBranch.Text + "&department="
                + ddlDepartment.Text + "&employee=" + ddlEmployee.Text + "");
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.Text != "")
            {

                CLsDAo.CreateDynamicDDl(ddlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.ddlBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.Text != "" && ddlDepartment.Text != "")
            {

                CLsDAo.CreateDynamicDDl(ddlEmployee, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + this.ddlBranch.Text + " AND DEPARTMENT_ID=" + this.ddlDepartment.Text + "", "EMPLOYEE_ID", "EmpName", "", "All");
            }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}