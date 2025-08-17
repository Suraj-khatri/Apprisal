using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.InternalTransferPlanDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.InternalTransferPlan
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        InternalTransferPlanDAO _internalTransferDao = null;
        InternalTransferPlanCore _internalTransferCore = null;     
        clsDAO CLsDAo = null;
        public Manage()
        {
            CLsDAo = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _internalTransferCore = new InternalTransferPlanCore();
            _internalTransferDao = new InternalTransferPlanDAO();
     
        }
        private long GetITPlanId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 52) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();

                if (this.GetITPlanId() > 0)
                {
                    BtnDelete.Visible = true;
                    populateInternalTransferDetails();
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                DdlFromDept.Focus();
                txtEffectiveDate.Attributes.Add("onblur", "checkDateFormat(this);");
                txtReportDate.Attributes.Add("onblur", "checkDateFormat(this);");
            }
        }
        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlFromDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments Where BRANCH_ID="+ReadSession().Branch_Id+"", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            CLsDAo.CreateDynamicDDl(DdlToDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments Where BRANCH_ID=" + ReadSession().Branch_Id + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            CLsDAo.CreateDynamicDDl(DdlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "Select");
        }
        private void populateInternalTransferDetails()
        {
            CLsDAo.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee", "EMPLOYEE_ID", "EmpName", "", "Select");

            this._internalTransferCore = this._internalTransferDao.FindById(GetITPlanId());

            this.DdlEmpName.SelectedValue = this._internalTransferCore.StaffId;
            this.DdlFromDept.SelectedValue = this._internalTransferCore.FromDept;
            txtEffectiveDate.Text = _internalTransferCore.EffectiveDate;
            txtReportDate.Text = _internalTransferCore.ReportedDate;
            this.DdlToDept.SelectedValue = this._internalTransferCore.WhichDepartment;
            this.DdlEmpName.SelectedValue = this._internalTransferCore.StaffId;
            this.DdlPosition.SelectedValue = this._internalTransferCore.WhichPosition;
            this.txtTransferDesc.Text = this._internalTransferCore.TransferDesc;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetITPlanId() > 0)
                {
                    CLsDAo.runSQL("exec procManageInternalMovement 'u'," + filterstring(DdlEmpName.Text) + "," + filterstring(ReadSession().Branch_Id.ToString()) + "," + filterstring(DdlFromDept.Text) + ","
                    + " " + filterstring(ReadSession().Branch_Id.ToString()) + "," + filterstring(DdlToDept.Text) + "," + filterstring(DdlPosition.Text) + "," + filterstring(txtEffectiveDate.Text) + "," + filterstring(txtReportDate.Text) + "," + filterstring(txtTransferDesc.Text) + ","
                    + " " + filterstring(ReadSession().UserId) + "," + GetITPlanId() + "");
                }
                else
                {
                    CLsDAo.runSQL("exec procManageInternalMovement 'i'," + filterstring(DdlEmpName.Text) + "," + filterstring(ReadSession().Branch_Id.ToString()) + "," + filterstring(DdlFromDept.Text) + ","
                    + " " + filterstring(ReadSession().Branch_Id.ToString()) + "," + filterstring(DdlToDept.Text) + "," + filterstring(DdlPosition.Text) + "," + filterstring(txtEffectiveDate.Text) + "," + filterstring(txtReportDate.Text) + "," + filterstring(txtTransferDesc.Text) + ","
                    + " " + filterstring(ReadSession().UserId) + "");
                }
                Response.Redirect("InternalList.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void DdlFromDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmpName.Items.Clear();
            if (DdlFromDept.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + ReadSession().Branch_Id+ " AND DEPARTMENT_ID=" + DdlFromDept.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("exec procExecuteSQLString 'd' , 'Delete from ExternalTransferPlan' , ' and  ID='" + filterstring(GetITPlanId().ToString()) + "'', " + filterstring(ReadSession().UserId) + "");
                Response.Redirect("InternalList.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }        
    }
}
