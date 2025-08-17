using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftHrManagement.web.AssetManagement
{
    public partial class ManageRevAssetBooking : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ManageRevAssetBooking()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _clsdao.CreateDynamicDDl(branchname, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 111) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    _clsdao.CreateDynamicDDl(deptname, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
                    populateAssetBooking();
                    disabledForm();
                }
                BtnDelete.Visible = false;
                AutoCompleteExtender2.ContextKey = "";
            }
        }
        private void populateAssetBooking()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("EXEC ProcManageRevAssetBooking 's'," + filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                branchname.Text = dr["branch_id"].ToString();
                deptname.Text = dr["dept_id"].ToString();
                txtAssetQty.Text = "1".ToString();
                assettype.Text = dr["prductName"].ToString();
                bookingdate.Text = dr["booked_date"].ToString();
                purchasevalue.Text = dr["purchase_value"].ToString();
                txtPurchaseDate.Text = dr["purchase_date"].ToString();
                hdnInsuredId.Value = dr["ins_id"].ToString();
                insuranceid.Text = dr["InsuranceName"].ToString();
                billid.Text = dr["BillName"].ToString();
                hdnBillId.Value = dr["bill_id"].ToString();
                assetstatus.Text = dr["asset_status"].ToString();
                warrexpirydate.Text = dr["warr_expiry"].ToString();
                assetserial.Text = dr["asset_serial"].ToString();
                nextmaindate.Text = dr["next_maintenance_date"].ToString();
                hdnHolderId.Value = dr["asset_holder"].ToString();
                assetholder.Text = dr["AssetHolderName"].ToString();
                narration.Text = dr["narration"].ToString();
            }
        }
        protected void branchname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (branchname.Text != "")
            {
                _clsdao.CreateDynamicDDl(deptname, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments WHERE BRANCH_ID=" + filterstring(branchname.Text) + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }

            AutoCompleteExtender2.ContextKey = branchname.SelectedValue;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetId() > 0)
                {
                    _clsdao.runSQL("Exec ProcManageRevAssetBooking 'u'," + filterstring(GetId().ToString()) + ",null," + filterstring(deptname.Text) + ",null,null," + filterstring(txtPurchaseDate.Text) + ","
                    + " null,"+filterstring(purchasevalue.Text)+"," + filterstring(hdnInsuredId.Value) + "," + filterstring(hdnBillId.Value) + ","
                    + " " + filterstring(assetstatus.Text) + "," + filterstring(warrexpirydate.Text) + "," + filterstring(hdnHolderId.Value) + "," + filterstring(nextmaindate.Text) + ","
                    + " " + filterstring(narration.Text) + "," + filterstring(assetserial.Text) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
                }
                else
                {
                    _clsdao.runSQL("Exec ProcManageRevAssetBooking 'i',null," + filterstring(branchname.Text) + "," + filterstring(deptname.Text) + "," + filterstring(hdnAssetId.Value) + "," + filterstring(bookingdate.Text) + "," + filterstring(txtPurchaseDate.Text) + "," + filterstring(txtAssetQty.Text) + ","
                    + " " + filterstring(purchasevalue.Text) + "," + filterstring(hdnInsuredId.Value) + ","
                    + " " + filterstring(hdnBillId.Value) + "," + filterstring(assetstatus.Text) + "," + filterstring(warrexpirydate.Text) + "," + filterstring(hdnHolderId.Value) + ","
                    + " " + filterstring(nextmaindate.Text) + "," + filterstring(narration.Text) + "," + filterstring(assetserial.Text) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
                }
                Response.Redirect("ListRevAssetBooking.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListRevAssetBooking.aspx");
        }
        private void disabledForm()
        {
            branchname.Enabled = false;
            txtAssetQty.Enabled = false;
            assettype.Enabled = false;
            purchasevalue.Enabled = false;
            bookingdate.Enabled = false;
        }
    }
}
