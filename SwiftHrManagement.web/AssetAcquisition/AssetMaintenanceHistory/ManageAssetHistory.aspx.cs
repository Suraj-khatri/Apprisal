using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.AssetAcquisition.AssetMaintenanceHistory
{
    public partial class ManageAssetHistory : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        public ManageAssetHistory()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 203) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateForwardedTo();
                if (ReadSession().UserType == "A")
                {
                    AutoCompleteExtender3.ContextKey = "null";
                }
                else
                {
                    AutoCompleteExtender3.ContextKey = ReadSession().Branch_Id.ToString();
                }
                if (GetHistoryid() > 0)
                {
                    populateMainenanceHistory();
                }
                else
                {
                    btnDelete.Visible = false;
                }
                
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }
        private long GetHistoryid()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void populateForwardedTo()
        {
            if (ReadSession().Branch_Id == 1)
            {
                _clsdao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
            else
            {
                _clsdao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
        }
        private void populateMainenanceHistory()
        {
            DataTable dt = _clsdao.getTable("EXEC [Proc_ASSET_MAINTENANCE_HISTORY] @flag='s',@id=" +  filterstring(GetHistoryid().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtAssetNumber.Text = dr["asset_number"].ToString();
                HdnAssetnumber.Value = dr["id"].ToString();
                TxtBookValue.Text = dr["book_value"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["asset_narration"].ToString();
                txtAccDep.Text = dr["acc_dep"].ToString();
                TxtExpenseAmount.Text = dr["expense_amt"].ToString();
                TxtMaintainedDate.Text = dr["maint_date"].ToString();
                TxtNextMaintainedDate.Text = dr["next_maintenance_date"].ToString();
                TxtpaymentLedger.Text = dr["payment_ledger"].ToString();
                txtmaintainedby.Text = dr["maint_by"].ToString();
                TxtNarration.Text = dr["narration"].ToString();
                ddlForwardedTo.SelectedValue = dr["forwarded_to"].ToString();
                txtRejectionReason.Text = dr["rejection_reason"].ToString();
            }            
        }
        private void getbookvalue()
        {
            DataTable dt = _clsdao.getTable("exec [ProcPopulateAssetDetails] @assetid=" + HdnAssetnumber.Value + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtBookValue.Text = dr["book_value"].ToString();
                txtAccDep.Text = dr["acc_dep"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                TxtBookValue.Text = dr["book_value"].ToString();
                txtAssetNarration.Text = dr["narration"].ToString();
            }
        }
        private void ManageHistory()
        {
            long id = GetHistoryid();
            string strflag = "";
            if (id > 0)
                strflag = "u";
            else
                strflag = "i";

            _clsdao.runSQL("exec Proc_ASSET_MAINTENANCE_HISTORY @flag=" + filterstring(strflag) + ",@id="+filterstring(GetHistoryid().ToString())+","
                            + " @assetid=" + filterstring(HdnAssetnumber.Value) + ",@maint_date=" + filterstring(TxtMaintainedDate.Text) + ","
                            + " @maintby=" + filterstring(Hdnempid.Value) + ",@next_maintenance_date=" + filterstring(TxtNextMaintainedDate.Text) + ","
                            + " @expense_amt=" + filterstring(TxtExpenseAmount.Text) + ",@payment_ledger=" + filterstring(HdnLedger.Value) + ","
                            + " @narration=" + filterstring(TxtNarration.Text) + ",@user=" +filterstring(ReadSession().Emp_Id.ToString()) + ","
                            + " @forwarded_to="+filterstring(ddlForwardedTo.Text)+"");
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ManageHistory();
                Response.Redirect("ListAssetHistory.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            getbookvalue();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("exec Proc_ASSET_MAINTENANCE_HISTORY @flag='d',@id=" + filterstring(GetHistoryid().ToString()) + "");
                Response.Redirect("ListAssetHistory.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
