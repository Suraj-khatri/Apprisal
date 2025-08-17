using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.ExternalTransferPlan
{
    public partial class ExtManage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 51) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();

                if (this.GetId() > 0 && IsExecuted() == "")
                {
                    BtnDelete.Visible = true;
                    OnPopulate();
                }
                else if (this.GetId() > 0 && IsExecuted() == "Y")
                {
                    Btn_Save.Visible = false;
                    BtnDelete.Visible = false;
                    btnAdd.Visible = false;
                    txtEmployeeName.Enabled = false;
                    DdlFromBranch.Enabled = false;
                    DdlFromDept.Enabled = false;
                    txtRecommendBy.Enabled = false;
                    txtRecommendDate.Enabled = false;
                    txtEffectiveDate.Enabled = false;
                    txtReportedDate.Enabled = false;
                    txtTransferDesc.Enabled = false;
                    ddlSupervisorType.Enabled = false;
                    ddlCurrentSupervisor.Enabled = false;
                    txtSuperVisorName.Enabled = false;
                    OnPopulate();
                    supAdd.Visible = false;
                    supDis.Visible = true;
                    OnPopulateSuperVisor();
                }
                else
                {
                    BtnDelete.Visible = false;
                    btnReject.Visible = false;
                }
                BtnBack.Attributes.Add("onclick", "history.back();return false");
                txtEffectiveDate.Attributes.Add("OnBlur","checkDateFormat(this);");
                txtReportedDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                DdlFromBranch.Focus();
                DisplaySupervisor();
            }
        }      
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private string IsExecuted()
        {
            return (_clsDao.GetSingleresult("select F_EXECUTED from ExternalTransferPlan where ID=" + GetId() + ""));
        }
        private void PopulateDropdownList()
        {
            _clsDao.CreateDynamicDDl(DdlFromBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlToBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlFromDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlFromSubDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlToSubDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            
        }

        private void OnPopulate()
        {
            _clsDao.CreateDynamicDDl(DdlFromDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlToDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlFromSubDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlToSubDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");

            DataTable dt = _clsDao.getTable("Exec proc_ManageTransferRequest @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                lblEmpName.Text = dr["EMPLOYEE_NAME"].ToString();
                hddEmpId.Value = dr["STAFF_ID"].ToString();
                DdlFromBranch.SelectedValue = dr["FROM_BRANCH"].ToString();
                DdlFromDept.SelectedValue = dr["FROM_DEPARTMENT"].ToString();
                DdlToBranch.SelectedValue = dr["WHICH_BRANCH"].ToString();
                DdlToDept.SelectedValue = dr["WHICH_DEPARTMENT"].ToString();
                DdlFromSubDept.SelectedValue = dr["FROM_SUBDEPARTMENT"].ToString();
                DdlToSubDept.SelectedValue = dr["WHICH_SUBDEPARTMENT"].ToString();
                txtEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
                txtReportedDate.Text = dr["ACTUAL_REPORT_DATE"].ToString();
                txtTransferDesc.Text = dr["TRANSFER_DESCRIPTION"].ToString();
                lblRecommendBy.Text = dr["RECOMMEND_BY"].ToString();
                txtRecommendDate.Text = dr["RECOMMEND_DATE"].ToString();
            } 
        }

        private long getEmpId()
        {
            string emp_id = _clsDao.GetSingleresult("select STAFF_ID from ExternalTransferPlan where ID=" + filterstring(GetId  ().ToString()));
            long empid = long.Parse(emp_id);
            return empid;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "error in operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string flag = "";
            if (GetId() > 0)
                flag = "APPROVE";
            else
                flag = "INSERT";


            string msg = _clsDao.GetSingleresult("Exec proc_ManageTransferRequest @flag=" + filterstring(flag) + ","
                        + " @id=" + filterstring(GetId().ToString()) + ","
                        + " @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@from_branch=" + filterstring(DdlFromBranch.Text) + ","
                        + " @from_dept=" + filterstring(DdlFromDept.Text) + ",@to_branch=" + filterstring(DdlToBranch.Text) + ","
                        + " @to_dept=" + filterstring(DdlToDept.Text) + ",@effective_date=" + filterstring(txtEffectiveDate.Text) + ","
                        + " @to_subdept=" + filterstring(DdlToSubDept.SelectedValue) + ",@from_subdept=" + filterstring(DdlFromSubDept.SelectedValue) + ","
                        + " @actual_report_date=" + filterstring(txtReportedDate.Text) + ",@desc=" + filterstring(txtTransferDesc.Text) + ","
                        + " @recommend_by=" + filterstring(getEmpIdfromInfo(lblRecommendBy.Text)) + ",@recommend_date="+filterstring(txtRecommendDate.Text)+","
                        + " @session_id="+filterstring(ReadSession().Sessionid)+",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("EList.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "Exec proc_ManageTransferRequest @flag='DEL',@id=" + filterstring(GetId().ToString()) + ",@user=" + filterstring(ReadSession().UserId) + "";
                string msg = _clsDao.GetSingleresult(sql);

                if (msg.Contains("SUCCESS"))
                {
                    Response.Redirect("EList.aspx");
                }
                else
                {
                    lblmsg.Text = msg;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
             }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EList.aspx");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string msg;
            lblSupervisorAssign.Text = "";
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));

            if ( empId == "null")
                {
                    lblSupervisorAssign.Text = "Please Choose Employee Name!";
                    lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            string[] arrayNewSupervisor = txtSuperVisorName.Text.Split('|');
            string newSupervisor = arrayNewSupervisor[1];
            string sql;

            sql = "exec [proc_ManageTransferRequest] @flag='SUP_ADD',@New_Supervisor_type=" + filterstring(ddlSupervisorType.Text) + ","
                                    + " @New_Supervisor=" + filterstring(newSupervisor) +",@emp_id=" + filterstring(empId) + ","
                                    + " @Current_Supervisor="+filterstring(ddlCurrentSupervisor.Text)+","
                                    + " @session_id=" + filterstring(ReadSession().Sessionid) + "";
            


              
            msg =    _clsDao.GetSingleresult(sql);
            if (!msg.Contains("SUCCESS"))
            {
                lblSupervisorAssign.Text = msg;
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                DisplaySupervisor();
                txtSuperVisorName.Text = "";
                ddlSupervisorType.Focus();
            }
            
        }
        private void DisplaySupervisor()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = null;

            dt = _clsDao.getDataset("exec [proc_ManageTransferRequest] @flag='SUP_VIEW',@session_id=" + filterstring(ReadSession().Sessionid) + ","
                     + " @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "").Tables[0];
                      
            if(dt==null || dt.Rows.Count == 0)
            {
                rpt.InnerText = "Please Assign Supervisor!";            
                return;
            }
            int cols = dt.Columns.Count;
            int count = 1;
            str.Append("<tr>");
            str.Append("<th>S.N.</th>");
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
               
                str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\"  OnClick=\"OnDelete('" + dr["RowId"] + "') \"  href=\"#\" ><i class=\"fa fa-times\" aria-hidden=\"true\"></a></td>");
                str.Append("</tr>");

            }

            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }

        private void OnPopulateSuperVisor()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = null;

            dt = _clsDao.getDataset("exec [proc_ManageTransferRequest] @flag='DIS_SUP',@id="+filterstring(GetId().ToString())+"").Tables[0];

            if (dt == null || dt.Rows.Count == 0)
            {
                rpt.InnerText = "Please Assign Supervisor!";
                return;
            }
            int cols = dt.Columns.Count;
            int count = 1;
            str.Append("<tr>");
            str.Append("<th>S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {

                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                }

                str.Append("</tr>");

            }

            str.Append("</table>");
            str.Append("</div>");
            rptDIs.InnerHtml = str.ToString();
        }
        protected void btnSupervisorDelete_Click(object sender, EventArgs e)
        {
            var sql = "DELETE transfer_supervisor WHERE RowId = "+hdnSupervisorId.Value+"";
            _clsDao.runSQL(sql);
            DisplaySupervisor();
        }

      

        public  void SetOldSupervisor()
        {
            lblSupervisorAssign.Text = "";
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));

            if (empId == "null")
            {
                lblSupervisorAssign.Text = "Please Choose Employee Name!";
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
                return;
            }
            var sql =@"select dbo.GetEmployeeFullNameOfId(supervisor) empName,SUPERVISOR from SuperVisroAssignment  
                        where EMP = "+filterstring(empId)+" and SUPERVISOR_TYPE = "+filterstring(ddlSupervisorType.Text)+" and record_status = 'y'";
            _clsDao.CreateDynamicDDl(ddlCurrentSupervisor, sql, "SUPERVISOR", "empName", "", "");
            
        }


        protected void ddlSupervisorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOldSupervisor();
        }


        protected void txtRecommendBy_TextChanged(object sender, EventArgs e)
        {
            lblRecommendBy.Text = GetEmpInfoForLabel(txtRecommendBy.Text, lblRecommendBy.Text);
            txtRecommendBy.Text = "";
        }

        protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployeeName.Text, lblEmpName.Text);
            txtEmployeeName.Text = "";

            DdlFromBranch.SelectedValue = _clsDao.GetSingleresult("SELECT BRANCH_ID from Employee where EMPLOYEE_ID="+filterstring(getEmpIdfromInfo(lblEmpName.Text))+"");
            DdlFromDept.SelectedValue = _clsDao.GetSingleresult("SELECT DEPARTMENT_ID from Employee where EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "");
            string subDept = _clsDao.GetSingleresult("SELECT SUB_DEPARTMENT from Employee where EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "");
            if (string.IsNullOrEmpty(subDept))
                DdlFromSubDept.Enabled = false;
            DdlFromSubDept.SelectedValue = subDept;
            DdlFromBranch.Enabled = false;
            DdlFromSubDept.Enabled = false;
            DdlFromDept.Enabled = false;
            DisplaySupervisor();
            SetOldSupervisor();
        }

        protected void DdlToBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlToDept.Items.Clear();
            if (DdlToBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(DdlToDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlToBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }
            
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("update ExternalTransferPlan set status='Rejected',MODIFIED_BY="+filterstring(ReadSession().Emp_Id.ToString())+","
                         +" MODIFIED_DATE="+filterstring(DateTime.Now.ToString())+" where ID=" + GetId() + "");
            Response.Redirect("EList.aspx");
        }
    }
}
