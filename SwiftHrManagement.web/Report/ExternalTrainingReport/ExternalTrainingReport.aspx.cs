using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.ExternalTrainingReport
{
    public partial class ExternalTrainingReport : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ExternalTrainingReport()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 46) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                DateTime fromdate = DateTime.Now;
                TxtFrmDate.Text = fromdate.ToString("MM/dd/yyyy");
                TxtToDate.Text = fromdate.ToString("MM/dd/yyyy");

            }

            
        }
        private void PopulateDropDownList()
        {
            _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            _clsdao.CreateDynamicDDl(DdlTrainingProgram, "select external_traingin_id,Program_Name from externalTrainingInfo", "external_traingin_id", "Program_Name", "", "Select");
           
        }  

        protected void BtnViewRpt_Click(object sender, EventArgs e)
        {
            string ReportType = DdlReportType.Text;
            if (ReportType == "s")
            {
                Response.Redirect("ExternalTrainingSummaryReport.aspx?From=" + TxtFrmDate.Text + "&To=" + TxtToDate.Text);
            }
            else
            {
                Response.Redirect("ExternalTrainingDetailReport.aspx?From=" + TxtFrmDate.Text + "&To=" + TxtToDate.Text);
            }

        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDeptName.Items.Clear();
            if (DdlBranchName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }  
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlBranchName.Text != "" && DdlDeptName.Text != "")
            {
                _clsdao.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranchName.Text + " AND DEPARTMENT_ID=" + DdlDeptName.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void Btn_ShowReport_Click(object sender, EventArgs e)
        {
            if (DdlEmpName.Text == "")
            {
                LblMsg.Text = " Employe is Required !";
                return;
            }
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                LblMsg.Text = " Form Date and To Date is Required! ";
                return;
            }
            Response.Redirect("ExternalTrainingEmployeeWise.aspx?From=" + txtFrom.Text + "&To=" + txtTo.Text + "&Branch=" + DdlBranchName.Text + "&Depart=" + DdlDeptName.Text + "&Emp=" + DdlEmpName.Text + "&Train=" + DdlTrainingProgram.Text); 
        }

        protected void BtnTraing_Click(object sender, EventArgs e)
        {
            if (DdlTrainingProgram.Text == "")
            {
                LblMsg.Text = " Training Program is Required! ";
                return;
            }
            Response.Redirect("ExternalTrainingWiseReport.aspx?From=" + txtFrom.Text + "&To=" + txtTo.Text + "&Branch=" + DdlBranchName.Text + "&Depart=" + DdlDeptName.Text + "&Emp=" + DdlEmpName.Text + "&Train=" + DdlTrainingProgram.Text); 
        }
    }
}
