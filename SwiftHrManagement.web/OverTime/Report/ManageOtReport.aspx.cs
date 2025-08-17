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

namespace SwiftHrManagement.web.OverTime.Report
{
    public partial class ManageOtReport : BasePage// System.Web.UI.Page
    {
        clsDAO CLsDAo = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 PopulateDropDownList();
            }

        }

        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            
        }

        protected void Btn_ShowReport_Click(object sender, EventArgs e)
        {            
            Response.Redirect("ViewReport.aspx?BranchId=" + DdlBranchName.Text + "&DeptId=" + DdlDeptName.Text + ""
            +"&empId="+DdlEmpName.Text+"&FromDate="+txtFrom.Text+"&ToDate="+txtTo.Text+"");
        }

        protected void Btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            //var sql = "Exec procOtReport @flag='s',@branchId=" + filterstring(DdlBranchName.Text) + ",@deptId=" + filterstring(DdlDeptName.Text) + ","
            //+ "@emp_id=" + filterstring(DdlEmpName.Text) + ",@from_date=" + filterstring(txtFrom.Text) + ",@to_date=" + filterstring(txtTo.Text);
            //this.ReadSession().RptQuery = sql;
            //Response.Redirect("../../Report/CompanyDynamicReport.aspx");

         
        }  

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }  
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchName.Text + " AND DEPARTMENT_ID=" + DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void BtnSummaryRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("OT_SummaryRpt.aspx?from_date=" + txtFromDate.Text + "&to_date=" + txtToDate.Text + "");
        }

            
    }
}
