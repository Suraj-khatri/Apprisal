using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.ExternalTransferPlanDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TemporaryTransferPlan
{
    public partial class ManageTemporaryTransfer : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ExternalTransferPlanCore _externalTransCore = null;
        ExternalTransferPlanDAO _externalTransDao = null;
        clsDAO CLsDAo = null;
        public ManageTemporaryTransfer()
        {
            CLsDAo = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _externalTransCore = new ExternalTransferPlanCore();
            _externalTransDao = new ExternalTransferPlanDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                PopulateDropdownList();

                if (this.GetTemporaryTransPlanId() > 0)
                {
                    BtnDelete.Visible = true;
                    populateTransferDtls1();
                    ShowHideCurrentSupervisor();
                    DisplaySupervisor();
                  
                    
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnBack.Attributes.Add("onclick", "history.back();return false");
              
                lblmsg.Text = "";
                lblSupervisorAssign.Text = "";
               
            }

        }
        private long getTransferType()
        {
            return (Request.QueryString["TransType"] != null ? long.Parse(Request.QueryString["TransType"].ToString()) : 0);
        }

        private long GetTemporaryTransPlanId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void PopulateDropdownList()
        {
           // CLsDAo.CreateDynamicDDl(DdlTransferType, "Exec ProcStaticDataView 's','78'", "ROWID", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlToBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            //CLsDAo.CreateDynamicDDl(DdlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void populateTransferDtls1()
        {
           
            CLsDAo.CreateDynamicDDl(DdlFromDept, "select E.DEPARTMENT_ID,DEPARTMENT_NAME from Departments D INNER JOIN Employee E on D.DEPARTMENT_ID=E.DEPARTMENT_ID and E.EMPLOYEE_ID=" + filterstring(getEmpId().ToString()) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            CLsDAo.CreateDynamicDDl(DdlFromBranch, "select E.BRANCH_ID,BRANCH_NAME FROM Branches D INNER JOIN Employee E on D.BRANCH_ID=E.BRANCH_ID and E.EMPLOYEE_ID=" + filterstring(getEmpId().ToString()) + "", "BRANCH_ID", "BRANCH_NAME", "", "");
            CLsDAo.CreateDynamicDDl(DdlToDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
            CLsDAo.CreateDynamicDDl(DdlToBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "");
            lblEmpName.Text = _externalTransDao.GetSingleresult("SELECT dbo.GetEmployeeInfoById(EMPLOYEE_ID) EMPLOYEE_NAME "
                            + ", EMPLOYEE_ID FROM Employee WHERE EMPLOYEE_ID =" + filterstring(getEmpId().ToString()));

            this._externalTransCore = this._externalTransDao.FindByTempId(GetTemporaryTransPlanId());
            DdlFromBranch.Text = _externalTransCore.FromWhichBranch;
            DdlFromDept.Text = _externalTransCore.FromWhichDepartment;
            DdlToBranch.Text = _externalTransCore.WhichBranch;
            DdlToDept.Text = _externalTransCore.WhichDepartment;
            txtEffectiveDate.Text = _externalTransCore.EffectiveDate;
            txtToDate.Text = _externalTransCore.Enddate;
            txtTransferDesc.Text = _externalTransCore.TransferDescription;
            DdlTransferType.Text = _externalTransCore.ServiceEvent;
        }

        private long getEmpId()
        {

             string emp_id= CLsDAo.GetSingleresult("select EMPLOYEE_ID from Temporary_Transfer where ID=" + filterstring(GetTemporaryTransPlanId().ToString()));
             long empid = long.Parse(emp_id);
                return empid ;
           
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                    string msg;
                    if (GetTemporaryTransPlanId() > 0)
                    {
                        msg = CLsDAo.GetSingleresult("exec procTemporaryManageEmployeeMovement 'u'," + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "," + filterstring(DdlFromBranch.Text) + "," + filterstring(DdlFromDept.Text) + ","
                          + " " + filterstring(DdlToBranch.Text) + "," + filterstring(DdlToDept.Text) + "," + filterstring(txtEffectiveDate.Text) + "," + filterstring(txtToDate.Text) + "," + filterstring(txtTransferDesc.Text) + ","
                          + " " + filterstring(ReadSession().Emp_Id.ToString()) + "," + GetTemporaryTransPlanId() + "," + filterstring(ReadSession().Sessionid) + "," + GetTemporaryTransPlanId() + ",@Transfer_Type=" + filterstring(DdlTransferType.Text) + "");
                    }
                    else
                    {
                        msg = CLsDAo.GetSingleresult("exec procTemporaryManageEmployeeMovement @flag='i',@empId=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@fromBranchId=" + filterstring(DdlFromBranch.Text) + ",@fromDeptId=" + filterstring(DdlFromDept.Text) + ","
                           + " @toBranchId=" + filterstring(DdlToBranch.Text) + ", @toDeptId=" + filterstring(DdlToDept.Text) + ",@effectiveDate=" + filterstring(txtEffectiveDate.Text) + ",@END_DATE=" + filterstring(txtToDate.Text) + ",@transferDesc=" + filterstring(txtTransferDesc.Text) + ","
                           + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@session_id=" + filterstring(ReadSession().Sessionid) + ",@Transfer_Type=" + filterstring(DdlTransferType.Text) + "");
                    }
                    if (msg == "")
                    {
                        Response.Redirect("TemporaryTransfer.aspx");
                    }
                    else
                    {
                        lblmsg.Text = msg;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        } 

        protected void DdlToBranch_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DdlToDept.Items.Clear();
            if (DdlToBranch.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlToDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlToBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemporaryTransfer.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            CLsDAo.runSQL("exec procTemporaryManageEmployeeMovement @flag='d',@rowid=" +GetTemporaryTransPlanId() + " ");
            Response.Redirect("TemporaryTransfer.aspx");
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
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            CLsDAo.CreateDynamicDDl(DdlFromBranch, "SELECT E.BRANCH_ID,BRANCH_NAME FROM Branches B INNER JOIN Employee E on B.BRANCH_ID=E.BRANCH_ID and E.EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "", "BRANCH_ID", "BRANCH_NAME","","");
            CLsDAo.CreateDynamicDDl(DdlFromDept, "select E.DEPARTMENT_ID,DEPARTMENT_NAME from Departments D INNER JOIN Employee E on D.DEPARTMENT_ID=E.DEPARTMENT_ID and E.EMPLOYEE_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME","","");
            DisplaySupervisor();
            SetCurrentSupervisor();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSupervisorAssign.Text = "";
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));

            if (empId == "null")
            {
                lblSupervisorAssign.Text = "Please Choose Employee Name!";
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string[] arrayNewSupervisor = txtSuperVisorName.Text.Split('|');
            string newSupervisor = arrayNewSupervisor[1];

            string sql;
            string msg;

            if (GetTemporaryTransPlanId() > 0)
            {
                sql = "exec [procTemporaryManageEmployeeMovement] @flag='au',@Transfer_Type="+filterstring(DdlTransferType.Text)+",@New_Supervisor_type=" +
                                                 filterstring(ddlSupervisorType.Text) + ",@New_Supervisor=" + filterstring(newSupervisor) +
                                                 ",@empId=" + empId + ",@Current_Supervisor_Type=" + filterstring(ddlSupervisorType.Text) + ",@Current_Supervisor=" + filterstring(ddlCurrentSupervisor.Text) + ",@Transfer_ID=" + filterstring(GetTemporaryTransPlanId().ToString()) + "";
            }
            else
            {
                sql = "exec [procTemporaryManageEmployeeMovement] @flag='a',@Transfer_Type="+filterstring(DdlTransferType.Text)+",@New_Supervisor_type=" +
                                  filterstring(ddlSupervisorType.Text) + ",@New_Supervisor=" + filterstring(newSupervisor) +
                                  ",@Current_Supervisor_Type=" + filterstring(ddlSupervisorType.Text) + ",@Current_Supervisor=" + filterstring(ddlCurrentSupervisor.Text) + ",@empId=" + empId + ",@session_id=" + filterstring(ReadSession().Sessionid) + ""; 
            }

           msg =  CLsDAo.GetSingleresult(sql);
            if(msg != "")
            {
                lblSupervisorAssign.Text = msg;
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
            }

            DisplaySupervisor();
            txtSuperVisorName.Text = "";
            ddlSupervisorType.Focus();



        }
        private void DisplaySupervisor()
        {
            string msg;
            string empId = filterstring(getEmpIdfromInfo(lblEmpName.Text));
            lblSupervisorAssign.Text = "";

            if (empId == "null")
            {
                lblSupervisorAssign.Text = "Please Choose Employee Name!";
                lblSupervisorAssign.ForeColor = System.Drawing.Color.Red;
                return;
            }

            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt;
            if(GetTemporaryTransPlanId() > 0)
            {
                dt = CLsDAo.getDataset("exec [procTemporaryManageEmployeeMovement] 'ss',@Transfer_ID=" + GetTemporaryTransPlanId() + ",@Transfer_Type="+filterstring(DdlTransferType.Text)+"").Tables[0];
            }
            else
            {
                dt = CLsDAo.getDataset("exec [procTemporaryManageEmployeeMovement] 's',@session_id=" + filterstring(ReadSession().Sessionid) + ",@empId=" + empId + ",@Transfer_Type=" + filterstring(DdlTransferType.Text) + "").Tables[0];
            }
            
            if (dt == null || dt.Rows.Count == 0)
            {
                rpt.InnerText = "Please Assign Supervisor!";
                //rpt.Attributes.Add();
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
                
                str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\" OnClick=\"OnDelete('" + dr["RowId"] + "') href=\"#\"><i class=\"fa fa-times\" aria-hidden=\"true\"></a></td>");
                str.Append("</tr>");

            }

            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }
        protected void btnSupervisorDelete_Click(object sender, EventArgs e)
        {
            var sql = "DELETE transfer_supervisor WHERE RowId = " + hdnSupervisorId.Value + "";
            CLsDAo.runSQL(sql);
            DisplaySupervisor();
        }

        protected void ddlSupervisorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentSupervisor();
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
            CLsDAo.CreateDynamicDDl(ddlCurrentSupervisor, sql, "SUPERVISOR", "empName", "", "");

        }

        protected void DdlOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHideCurrentSupervisor();

        }

        private void ShowHideCurrentSupervisor()
        {
            if (DdlTransferType.Text != "T")
            {
                showHide.Attributes.Add("class", "display");


            }
            else
            {
                showHide.Attributes.Add("class", "display1");
            }
        }
    }
}
