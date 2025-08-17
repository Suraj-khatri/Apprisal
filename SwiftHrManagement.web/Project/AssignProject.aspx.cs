using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Project;
using SwiftHrManagement.DAL.User;
namespace SwiftHrManagement.web.Project
{
    public partial class AssignProject : BasePage
    {
        ProjectCore _prjcore = null;
        ProjectDAO _prjDao = null;
        public AssignProject()
        {
            _prjcore = new ProjectCore();
            _prjDao = new ProjectDAO();

        }
        private bool checkduplicate()
        {
            if (_prjDao.CheckIfExists(DdlEmployee.Text, GetProjectId()) == true)
                return true;
            else
                return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBranchName();              
                popullatePeoject();
                ListAssignedEmp(_prjDao.GetAssignedproject(GetProjectId()).Tables[0]);
            }
        }
        private void PopulateBranchName()
        {
            clsDAO CLsDAo = new clsDAO();
            CLsDAo.CreateDynamicDDl(ddlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "select");
        }
        private long GetProjectId()
        {
            return (Request.QueryString["Project_Id"] != null ? long.Parse(Request.QueryString["Project_Id"].ToString()) : 0);
        }

        private void popullatePeoject()
        {
            _prjcore = _prjDao.GetprojectById(GetProjectId());
            LblTitle.Text = _prjcore.Title;
            LblFromDate.Text = _prjcore.Start_date;
            LblToDate.Text = _prjcore.End_date;
            LblProjectManager.Text = _prjcore.Prj_manager;
            LblProjectOwner.Text = _prjcore.Owner;
            LblCategory.Text = _prjcore.Category;
        }
        private void ListAssignedEmp(DataTable dt)
        {
            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;
            if (dt.Rows.Count > 0)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                tr.CssClass = "taskGridHeader";
                if (dt.Rows.Count > 1)
                    td1.Text = "<input type='checkbox' name='chkAll' name='chkAll'  id='chkAll' onclick=\"checkAll(this);\">";
                else
                    td1.Text = "";
                td2.Text = "<strong> Assigned Employee</strong>";
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tblResult.Rows.Add(tr);
            }
            foreach (DataRow row in dt.Rows)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td1.Text = "<input type='checkbox' name='chkTran' id='chkTran' value='" + row["id"].ToString() + "'>";
                td2.Text = row["EMP_ID"].ToString();
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tblResult.Rows.Add(tr);
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkduplicate() == false)
                {
                    _prjDao.AssignProject(int.Parse(GetProjectId().ToString()), DdlEmployee.Text, this.ReadSession().UserId);
                }
                ListAssignedEmp(_prjDao.GetAssignedproject(GetProjectId()).Tables[0]);
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }           
        protected void DdlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            if (checkduplicate() == true)
            {
                lblmsg.Text = "Project has already been assigned";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            ListAssignedEmp(_prjDao.GetAssignedproject(GetProjectId()).Tables[0]);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string Ids = "";
                if (Request.Form["chkTran"] != null)
                {
                    Ids = Request.Form["chkTran"].ToString();
                }

                if (Ids == "")
                    return;
                _prjDao.DeleteAssignedEmp(Ids);
                lblmsg.Text = "Operation completed successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                ListAssignedEmp(_prjDao.GetAssignedproject(GetProjectId()).Tables[0]);
            }
            catch
            {
                lblmsg.Text = "Error in operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?Project_Id=" + this.GetProjectId() + "");
        }

        protected void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranchName.Text != "")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.ddlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }

        protected void DdlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranchName.Text != "" && DdlDeptName.Text!="")
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlEmployee, "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E inner join Admins A on A.Name=E.EMPLOYEE_ID WHERE BRANCH_ID=" + this.ddlBranchName.Text + " AND DEPARTMENT_ID=" + this.DdlDeptName.Text + "", "UserName", "EmpName", "", "Select");
            }
        }
    }
}
