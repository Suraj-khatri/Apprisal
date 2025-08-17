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
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.AssetManagement
{
    public partial class ManageTransfer : BasePage
    {
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageTransfer()
        {
            _clsDao = new ClsDAOInv();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 208) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDLLs();
                populateForwardedTo();
                if (GetId() > 0)
                {
                    populateDropDownList();
                    populateTransfer();                    
                }
                if (ReadSession().UserType == "A")
                {
                    AutoCompleteExtender1.ContextKey = "null";
                }
                else
                {
                    AutoCompleteExtender1.ContextKey = ReadSession().Branch_Id.ToString();
                }
            }
        }
        private void populateForwardedTo()
        {
            _clsDao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
           
        }

        private void populateDropDownList()
        {
            _clsDao.CreateDynamicDDl(CmbHolderTo, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+ FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EMPNAME FROM EMPLOYEE", "EMPLOYEE_ID", "EmpName", "", "Select");
            _clsDao.CreateDynamicDDl(CmbDepartmentTo, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateDLLs()
        {
            _clsDao.CreateDynamicDDl(CmbBranchTo, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }
        private void populateTransfer()
        {
            DataTable dt = _clsDao.getTable("SELECT a.id,a.asset_number+' | '+CAST(a.id AS VARCHAR) AS asset_number,CONVERT(VARCHAR,t.created_date,101) AS"
                + " transfer_date,book_value,to_branch,t.rejection_reason,to_dept,to_holder,t.narration,t.forwarded_to,isnull(a.narration,'')+' (Booked Date : '+ convert(varchar,a.booked_date ,107) + ')' AS assetNarration,a.purchase_value,a.acc_depriciation "
                +" FROM ASSET_TRANSFER_TEMP t WITH(NOLOCK) INNER JOIN ASSET_INVENTORY a WITH(NOLOCK) ON a.id=t.asset_id "
                +" WHERE t.id=" + GetId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                hdnAssetID.Value = dr["id"].ToString();
                TxtNaration.Text = dr["narration"].ToString();
                txtAssetNarration.Text = dr["assetNarration"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAccDep.Text = dr["acc_depriciation"].ToString();
                TxtAssetNumber.Text = dr["asset_number"].ToString();
                TxtTransferDate.Text = dr["transfer_date"].ToString();
                CmbBranchTo.SelectedValue = dr["to_branch"].ToString();
                CmbDepartmentTo.SelectedValue = dr["to_dept"].ToString();
                CmbHolderTo.SelectedValue = dr["to_holder"].ToString();
                ddlForwardedTo.SelectedValue = dr["forwarded_to"].ToString();
                txtRejectionReason.Text = dr["rejection_reason"].ToString();
                populateHolder();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetId() > 0)
                {
                    UpdateAssetTransfer();                   
                }
                else
                {
                    InsertAssetTransfer();
                    btnDelete.Visible = false;
                }
                Response.Redirect("ListTransfer.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Saving!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void InsertAssetTransfer()
        {
            LblMsg.Text = _clsDao.GetSingleresult("exec proc_Manage_assetTransferHistory '" + 0 + "'," + filterstring(hdnAssetID.Value) + "," + filterstring(TxtTransferDate.Text) + ","
                         + "" + filterstring(ReadSession().Emp_Id.ToString()) + "," + filterstring(hdnAccuDep.Value) + "," + filterstring(TxtBookValue.Text) + ","
                         + "" + filterstring(hdnFromBranchID.Value) + "," + filterstring(hdnFromDeptID.Value) + "," + filterstring(hdnFromHolderID.Value) + "," + filterstring(CmbBranchTo.SelectedValue) + ","
                         + "" + filterstring(CmbDepartmentTo.SelectedValue) + "," + filterstring(CmbHolderTo.SelectedValue) + "," + filterstring(TxtNaration.Text) + ",'I',"+filterstring(ddlForwardedTo.Text)+"");
        }
        private void UpdateAssetTransfer()
        {
            LblMsg.Text = _clsDao.GetSingleresult("exec proc_Manage_assetTransferHistory " + filterstring(GetId().ToString()) + "," + filterstring(hdnAssetID.Value) + "," + filterstring(TxtTransferDate.Text) + ","
                         + "" + filterstring(ReadSession().Emp_Id.ToString()) + "," + filterstring(hdnAccuDep.Value) + "," + filterstring(TxtBookValue.Text) + ","
                         + "" + filterstring(hdnFromBranchID.Value) + "," + filterstring(hdnFromDeptID.Value) + "," + filterstring(hdnFromHolderID.Value) + "," + filterstring(CmbBranchTo.Text) + ","
                         + "" + filterstring(CmbDepartmentTo.Text) + "," + filterstring(CmbHolderTo.Text) + "," + filterstring(TxtNaration.Text) + ",'U',"+filterstring(ddlForwardedTo.Text)+"");
        }
       
        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = _clsDao.getTable("exec [proc_Get_AssetInventoriesDetails] " + filterstring(hdnAssetID.Value) + "");

            foreach (DataRow dr in dt.Rows)
            {
                TxtBranchFrom.Text = dr["BRANCH_NAME"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["NARRATION"].ToString();
                TxtDepartmentFrom.Text = dr["DEPARTMENT_NAME"].ToString();
                TxtBookValue.Text = dr["book Value"].ToString();
                TxtHolderFrom.Text = dr["holder_name"].ToString();
                hdnFromBranchID.Value = dr["branch_id"].ToString();
                hdnFromDeptID.Value = dr["dept_id"].ToString();
                hdnFromHolderID.Value = dr["asset_holder"].ToString();
                txtAccDep.Text = dr["acc_depriciation"].ToString();
                hdnAccuDep.Value = dr["acc_depriciation"].ToString();
            }
        }

        protected void CmbDepartmentTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartmentTo.Text != "")
            {
                _clsDao.CreateDynamicDDl(CmbHolderTo, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+ FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EMPNAME FROM EMPLOYEE WHERE DEPARTMENT_ID =" + this.CmbDepartmentTo.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void CmbBranchTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsDao.CreateDynamicDDl(CmbDepartmentTo, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.CmbBranchTo.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
        }
        private void populateHolder()
        {
            DataTable dt = _clsDao.getTable("exec [proc_Get_AssetInventoriesDetails] " + filterstring(hdnAssetID.Value) + "");

            foreach (DataRow dr in dt.Rows)
            {
                TxtBranchFrom.Text = dr["BRANCH_NAME"].ToString();
                TxtDepartmentFrom.Text = dr["DEPARTMENT_NAME"].ToString();
                TxtBookValue.Text = dr["book Value"].ToString();
                TxtHolderFrom.Text = dr["holder_name"].ToString();
                hdnFromBranchID.Value = dr["branch_id"].ToString();
                hdnFromDeptID.Value = dr["dept_id"].ToString();
                hdnFromHolderID.Value = dr["asset_holder"].ToString();
                hdnAccuDep.Value = dr["acc_depriciation"].ToString();
            }
        }
        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            _clsDao.runSQL("DELETE FROM ASSET_TRANSFER_TEMP WHERE id=" + GetId() + "");
            Response.Redirect("ListTransfer.aspx");
        }
    }
}
