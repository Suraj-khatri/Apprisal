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

namespace SwiftHrManagement.web.AssetManagement
{
    public partial class ApproveTransfer : BasePage
    {
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ApproveTransfer()
        {
            _clsDao = new ClsDAOInv();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 93) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDLLs();
                if (GetId() > 0)
                {
                    populateDropDownList();
                    populateTransfer();
                }                
            }
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
            DataTable dt = _clsDao.getTable("SELECT a.id,a.asset_number+' | '+CAST(a.id AS VARCHAR) AS asset_number,CONVERT(VARCHAR,transfer_date,101)"
		+" AS transfer_date,t.accumulated_dep,t.book_value,to_branch,to_dept,to_holder,t.narration,a.narration AS asset_narration,"
		+" a.purchase_value,b.BRANCH_NAME AS from_branch,c.DEPARTMENT_NAME	AS from_dept,"
		+" d.FIRST_NAME+' '+d.MIDDLE_NAME+' '+d.LAST_NAME AS from_holder "           
		+" FROM ASSET_TRANSFER_HISTORY t INNER JOIN ASSET_INVENTORY a ON t.asset_id=a.id INNER JOIN Branches b ON b.BRANCH_ID=t.from_branch"
		+" LEFT JOIN Departments c ON c.DEPARTMENT_ID=t.from_dept LEFT JOIN Employee d ON t.from_holder=d.EMPLOYEE_ID  WHERE t.id="+GetId()+"");
            foreach (DataRow dr in dt.Rows)
            {
                hdnAssetID.Value = dr["id"].ToString();
                TxtNaration.Text = dr["narration"].ToString();
                txtAccDep.Text = dr["accumulated_dep"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["asset_narration"].ToString();
                TxtAssetNumber.Text = dr["asset_number"].ToString();
                TxtTransferDate.Text = dr["transfer_date"].ToString();
                CmbBranchTo.SelectedValue = dr["to_branch"].ToString();
                CmbDepartmentTo.SelectedValue = dr["to_dept"].ToString();
                CmbHolderTo.SelectedValue = dr["to_holder"].ToString();
                //forwardedto.Text = dr["forwarded_to"].ToString();
                TxtBranchFrom.Text = dr["from_branch"].ToString();
                TxtDepartmentFrom.Text = dr["from_dept"].ToString();
                TxtHolderFrom.Text = dr["from_holder"].ToString();
                populateHolder();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("UPDATE ASSET_TRANSFER_HISTORY SET status='Cancelled',approved_date=GETDATE(),"
                +" forwarded_to="+filterstring(ReadSession().Emp_Id.ToString())+" where id=" + GetId() + "");
                Response.Redirect("ViewAssetTransferRequest.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Saving!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void InsertAssetTransfer()
        {
           LblMsg.Text = _clsDao.GetSingleresult("exec proc_Manage_assetTransferHistory '" + 0 + "','" + hdnAssetID.Value + "','" + TxtTransferDate.Text + "',"
                        + "'" + ReadSession().Emp_Id + "'," + filterstring(hdnAccuDep.Value) + "," + filterstring(TxtBookValue.Text) + ","
                        + "'" + hdnFromBranchID.Value + "','" + hdnFromDeptID.Value + "','" + hdnFromHolderID.Value + "','" + CmbBranchTo.SelectedValue + "',"
                        + "'" + CmbDepartmentTo.SelectedValue + "','" + CmbHolderTo.SelectedValue + "'," + filterstring(TxtNaration.Text) + ",'I'");
        }
        private void UpdateAssetTransfer()
        {
            LblMsg.Text = _clsDao.GetSingleresult("exec proc_Manage_assetTransferHistory "+filterstring(GetId().ToString())+"," +filterstring(hdnAssetID.Value) + "," +filterstring(TxtTransferDate.Text) + ","
                         + "'" + ReadSession().Emp_Id + "'," + filterstring(hdnAccuDep.Value) + "," + filterstring(TxtBookValue.Text) + ","
                         + "'" + hdnFromBranchID.Value + "','" + hdnFromDeptID.Value + "','" + hdnFromHolderID.Value + "','" + CmbBranchTo.Text + "',"
                         + "'" + CmbDepartmentTo.Text + "','" + CmbHolderTo.Text + "'," + filterstring(TxtNaration.Text) + ",'U'");
        }
       
        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = _clsDao.getTable("exec [proc_Get_AssetInventoriesDetails] " + filterstring(hdnAssetID.Value) + "");

            foreach (DataRow dr in dt.Rows)
            {
                TxtBranchFrom.Text = dr["BRANCH_NAME"].ToString();
                //TxtNaration.Text = dr["NARRATION"].ToString();
                TxtDepartmentFrom.Text = dr["DEPARTMENT_NAME"].ToString();
                TxtBookValue.Text = dr["book Value"].ToString();
                TxtHolderFrom.Text = dr["holder_name"].ToString();
                hdnFromBranchID.Value = dr["branch_id"].ToString();
                hdnFromDeptID.Value = dr["dept_id"].ToString();
                hdnFromHolderID.Value = dr["asset_holder"].ToString();
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

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec procManageApprovedAssetTransfer "+filterstring(GetId().ToString())+","+filterstring(ReadSession().Emp_Id.ToString())+"");
            Response.Redirect("ViewAssetTransferRequest.aspx");
        }
    }
}

