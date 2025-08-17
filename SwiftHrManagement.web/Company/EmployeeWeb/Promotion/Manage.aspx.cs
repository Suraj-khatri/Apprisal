using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.EmployeePromotion;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.EmployeeWeb.Promotion
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        promotionDao _promoDao = null;
        PromotionCore _promoCore = null;
        clsDAO _clsDao = new clsDAO();
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._promoDao = new promotionDao();
            this._promoCore = new PromotionCore();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetStatic.SetMessageBox(Page);
            if (!IsPostBack)
            {

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 9) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                if (GetId() > 0)
                {
                    BtnSave.Visible = false;
                    string msg = _clsDao.GetSingleresult("SELECT ISNULL(UPDATE_FLAG,'N') FROM Promotion WHERE ROWID=" + GetId() + "");
                    if (msg == "Y")
                    {
                        BtnDelete.Visible = false;
                    }
                    else
                    {
                        BtnDelete.Visible = true;
                    }
                    PopulatePromotion();
                }
                else
                {
                    prepareddl();
                    BtnDelete.Visible = false;
                }
            }
            DisplaySupervisor();
            BtnCancel.Attributes.Add("onclick", "history.back();return false");

        }

        private void PopulatePromotion()
        {
            txtEmployee.Enabled = false;
            _clsDao.CreateDynamicDDl(DdlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "");
            _clsDao.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            _clsDao.CreateDynamicDDl(DdlSubDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            _clsDao.CreateDynamicDDl(DdlCurPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_DESC", "", "");
            _clsDao.CreateDynamicDDl(DdlpromPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_DESC", "", "");
            //CLsDAo.CreateDynamicDDl(DdlPromotionType, "Exec ProcStaticDataView 's','77'", "ROWID", "DETAIL_DESC", "", "Select");

            lblEmpName.Text = _promoDao.GetSingleresult("SELECT dbo.GetEmployeeInfoById(EMPLOYEE_ID) EMPLOYEE_NAME "
                            + ", EMPLOYEE_ID FROM Employee WHERE EMPLOYEE_ID =" + filterstring(getEmpId().ToString()));

            this._promoCore = this._promoDao.FindallById(GetId());
            DdlBranch.SelectedValue = this._promoCore.BranchName;
            DdlDepartment.SelectedValue = _promoCore.Deptname;
            if (!string.IsNullOrEmpty(_promoCore.SubDeptname))
            {
                subdept.Visible = true;
                DdlSubDepartment.SelectedValue = _promoCore.SubDeptname;
            }
            DdlCurPosition.SelectedValue = _promoCore.Oldposition;
            DdlpromPosition.SelectedValue = _promoCore.Position_id.ToString();
            TxtPromotionDate.Text = _promoCore.Promotion_date;
            txtApplyOn.Text = _promoCore.ApplyOn;
            DdlBranch.Enabled = false;
            DdlDepartment.Enabled = false;
            DdlCurPosition.Enabled = false;

        }

        private long getEmpId()
        {
            string emp_id = _clsDao.GetSingleresult("select Emp_id from Promotion where ROWID=" + filterstring(GetId().ToString()));
            long empid = long.Parse(emp_id);
            return empid;
        }

        private void prepareddl()
        {
            _clsDao.CreateDynamicDDl(DdlpromPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_DESC", "", "Select");
            _clsDao.CreateDynamicDDl(salarySet, "SELECT salarySetMasterId,dbo.GetDetailTitle(Salary_Title) salarySetMasterDetail FROM salarySetMaster ", "salarySetMasterId", "salarySetMasterDetail", "", "Select");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DbResult dbResult = _promoDao.Update(getEmpIdfromInfo(lblEmpName.Text), TxtPromotionDate.Text, DdlpromPosition.Text,
                    DdlCurPosition.Text, DdlBranch.Text, DdlDepartment.Text, ReadSession().Emp_Id.ToString(), GetId().ToString(),
                    txtApplyOn.Text, salarySet.Text, hdnGrade.Value, hdnBasic.Value, ReadSession().Sessionid);

            if (dbResult.ErrorCode != "0")
            {
                GetStatic.CallBackJs1(Page, "Error Message", "alert('" + dbResult.Msg + "');");
                return;
            }
            ManageMessage(dbResult);
        }

        private void ManageMessage(DbResult dbResult)
        {
            GetStatic.SetMessage(dbResult);
            if (dbResult.ErrorCode == "0")
                Response.Redirect("List.aspx");
        }

        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _promoDao.deleteposition(GetId(), ReadSession().UserId);
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            subdept.Visible = false;
            string[] employee = txtEmployee.Text.Split('|');
            string empId = employee[1];
            string subdepart = _clsDao.GetSingleresult("SELECT SUB_DEPARTMENT FROM dbo.Employee WHERE employee_id=" + empId + "");
            if (!string.IsNullOrEmpty(subdepart))
            {
                subdept.Visible = true;
                _clsDao.CreateDynamicDDl(DdlSubDepartment, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM dbo.Departments WHERE DEPARTMENT_ID = " + subdepart + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            }
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            _clsDao.CreateDynamicDDl(DdlBranch, "SELECT E.BRANCH_ID,BRANCH_NAME FROM Branches B INNER JOIN Employee E on B.BRANCH_ID=E.BRANCH_ID and E.EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "", "BRANCH_ID", "BRANCH_NAME", "", "");
            _clsDao.CreateDynamicDDl(DdlDepartment, "select E.DEPARTMENT_ID,DEPARTMENT_NAME from Departments D INNER JOIN Employee E on D.DEPARTMENT_ID=E.DEPARTMENT_ID and E.EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            _clsDao.CreateDynamicDDl(DdlCurPosition, "select E.POSITION_ID,sdd.DETAIL_DESC POSITION_NAME from Employee E inner join StaticDataDetail sdd on sdd.ROWID=E.POSITION_ID and E.EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "", "POSITION_ID", "POSITION_NAME", "", "");
            DdlBranch.Enabled = false;
            DdlDepartment.Enabled = false;
            DdlCurPosition.Enabled = false;
            DisplaySupervisor();
            Salary.Visible = true;
            SetCurrentSupervisor();
            OldSalaryDetail();
        }

        public void SetCurrentSupervisor()
        {
            lblSupervisorAssign.Text = "";
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));

            if (empId == "null")
            {
                lblSupervisorAssign.Text = "Please Choose Employee Name!";
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
                return;
            }
            var sql = @"select dbo.GetEmployeeFullNameOfId(supervisor) empName,SUPERVISOR from SuperVisroAssignment  
                        where EMP = " + filterstring(empId) + " and SUPERVISOR_TYPE = " + filterstring(ddlSupervisorType.Text) + " and record_status = 'y'";
            _clsDao.CreateDynamicDDl(ddlCurrentSupervisor, sql, "SUPERVISOR", "empName", "", "");

        }

        private void DisplaySupervisor()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = null;

            if (GetId() > 0)
            {
                dt = _clsDao.getDataset("exec [procEmployeePromotion] 'ss',@id=" + GetId() + "").Tables[0];
            }
            else
            {
                dt = _clsDao.getDataset("exec [procEmployeePromotion] 's',@session_id=" + filterstring(ReadSession().Sessionid) + ",@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "").Tables[0];
            }


            if (dt == null || dt.Rows.Count == 0)
            {
                rpt.InnerText = "Please Assign Supervisor!";
                return;
            }
            int cols = dt.Columns.Count;
            int count = 1;
            str.Append("<tr>");
            str.Append("<th>Sn</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th>Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {

                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                }

                str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\" onclick='OnDelete('" + dr["RowId"] + "') href=\"#\"><i class=\"fa fa-times\"></a> </td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }

        protected void ddlSupervisorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentSupervisor();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string msg;
            lblSupervisorAssign.Text = "";
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));

            if (empId == "null")
            {
                GetStatic.CallBackJs1(Page, "Error Message", "alert('Please Choose Employee Name!');");
                return;
            }

            string[] arrayNewSupervisor = txtSuperVisorName.Text.Split('|');
            string newSupervisor = arrayNewSupervisor[1];

            DbResult dbResult = _promoDao.UpdateSupervisor(getEmpIdfromInfo(lblEmpName.Text), ddlSupervisorType.Text, newSupervisor,
                    ddlSupervisorType.Text, ddlCurrentSupervisor.Text, GetId().ToString(), ReadSession().Sessionid, ReadSession().Emp_Id.ToString());

            if (dbResult.ErrorCode != "0")
            {
                GetStatic.CallBackJs1(Page, "Error Message", "alert('" + dbResult.Msg + "');");
                return;
            }

            GetStatic.SetMessage(dbResult);
            DisplaySupervisor();
            txtSuperVisorName.Text = "";
            ddlSupervisorType.Focus();
        }

        protected void btnSupervisorDelete_Click(object sender, EventArgs e)
        {
            DbResult dbResult = _promoDao.DeleteSupervisor(hdnSupervisorId.Value, ReadSession().Emp_Id.ToString());
            DisplaySupervisor();
        }

        protected void DdlPromotionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OldSalaryDetail()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("exec [procEmployeePromotion] @flag='OLD_SAL',@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "");

            int cols = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            oldSal.InnerHtml = str.ToString();
        }

        protected void salarySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (salarySet.Text != "")
                NewSalaryDetail();
            else
                newSal.InnerHtml = "";
        }

        private void NewSalaryDetail()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("EXEC [procEmployeePromotion] @flag='NEW_SAL',@salary_setID=" + filterstring(salarySet.Text) + ","
            + "@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "");

            int cols = dt.Columns.Count;
            foreach (DataRow dr in dt.Rows)
            {

                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (dr["HEAD"].ToString() == "Basic Salary")
                    {
                        if (i == 0)
                        {
                            str.Append("<td align=\"left\">" + dr[i] + "</td>");
                        }
                        if (i == 1)
                        {
                            str.Append("<td align=\"left\">" + dr[i] + "</td>");
                            hdnBasic.Value = dr[i].ToString();
                        }
                    }
                    else if (dr["HEAD"].ToString() == "Grade Year")
                    {
                        if (i == 0)
                        {
                            str.Append("<td align=\"left\">" + dr[i] + "</td>");
                        }
                        if (i == 1)
                        {
                            str.Append("<td align=\"left\">" + dr[i] + "</td>");
                            hdnGrade.Value = dr[i].ToString();
                        }
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i] + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            newSal.InnerHtml = str.ToString();
        }
    }
}
