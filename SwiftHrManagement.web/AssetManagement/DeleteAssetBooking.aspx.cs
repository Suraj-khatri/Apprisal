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
    public partial class DeleteAssetBooking : BasePage
    {
        ClsDAOInv _clsdao = new ClsDAOInv();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 280) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateBranch();
                populateAssetBooking();
            }
        }
        private void PopulateBranch()
        {
        _clsdao.CreateDynamicDDl(branchname, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
         }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateAssetBooking()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT a.branch_id,dept_id,a.product_id,p.ASSET_CODE+'('+p.product_desc +')|'+CAST(p.id AS VARCHAR) as prductName,"
                    + " convert(varchar,booked_date,101) as booked_date,asset_number,purchase_value,acc_depriciation,convert(varchar,depr_start_date,101) as depr_start_date,"
                    + " s.DETAIL_TITLE+'-'+CONVERT(VARCHAR,i.insured_date,107)+'|'+CAST(A.id AS VARCHAR) as InsuranceName,ins_id,convert(varchar,purchase_date,101) as purchase_date,"
                    + " cast(b.bill_no as varchar)+' - '+c.CustomerName+' ('+CONVERT(varchar,b.bill_date,107)+') |'+cast(a.id as varchar) as BillName,"
                    + " bill_id,e.FIRST_NAME + ' ' + e.MIDDLE_NAME + ' ' + e.LAST_NAME + ' -' +e.EMP_CODE + ' ('+b1.BRANCH_NAME +') ' +  '|' + convert(varchar, e.EMPLOYEE_ID) as AssetHolderName,"
                    + " asset_holder,asset_status,convert(varchar,warr_expiry,107) as warr_expiry,convert(varchar,next_maintenance_date,107) as next_maintenance_date,"
                    + " a.narration,a.asset_serial, a.depre_pct,is_amortised,life_in_month,old_asset_no,old_asset_code,model,Brand from ASSET_INVENTORY a left join ASSET_PRODUCT p on a.product_id=p.id left join ASSET_INSURENCE i on i.id=a.ins_id "
                    + " left join StaticDataDetail s on s.ROWID=i.insurer left join ASSET_BILL b on b.id=a.bill_id left join Customer c on c.ID=b.vendor_id left join "
                    + " Employee e on e.EMPLOYEE_ID=a.asset_holder left join Branches b1 on b1.BRANCH_ID=e.BRANCH_ID"
                    + " WHERE A.id=" + filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                branchname.Text = dr["branch_id"].ToString();
                _clsdao.CreateDynamicDDl(deptname, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments where Branch_id=" + branchname.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
                deptname.Text = dr["dept_id"].ToString();
                txtAssetQty.Text = "1".ToString();
                assettype.Text = dr["prductName"].ToString();
                bookingdate.Text = dr["booked_date"].ToString();
                purchasevalue.Text = dr["purchase_value"].ToString();
                accdep.Text = dr["acc_depriciation"].ToString();
                depstartdate.Text = dr["depr_start_date"].ToString();
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
                TxtDepPct.Text = dr["depre_pct"].ToString();
                if (dr["is_amortised"].ToString() == "Y")
                {
                    chkAmortised.Checked = true;
                    txtLifeInMonth.Visible = true;
                    txtLifeInMonth.Text = dr["life_in_month"].ToString();
                }
                OldAssetNo.Text = dr["old_asset_no"].ToString();
                OldAssetCode.Text = dr["old_asset_code"].ToString();
                ModelNo.Text = dr["model"].ToString();
                Brand.Text = dr["brand"].ToString();
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='ass_booked',@ID=" + GetId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("ListAssetDelete.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.Focus();
                return;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
           _clsdao.GetSingleresult("Update ASSET_INVENTORY set IsDeleteStatus='Rejected' where id=" + GetId() + "");
           Response.Redirect("ListAssetDelete.aspx");
       }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAssetDelete.aspx");
        }
    }
}