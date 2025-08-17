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

namespace SwiftHrManagement.web.AssetManagement.ModifyAssetLocation
{
    public partial class ManageModAsset : BasePage
    {
         ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ManageModAsset()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private long GetReceiveId()
        {
            return (Request.QueryString["recid"] != null ? long.Parse(Request.QueryString["recid"].ToString()) : 0);
        }
        private long Getassetno()
        {
            return (Request.QueryString["assetno"] != null ? long.Parse(Request.QueryString["assetno"].ToString()) : 0);
        }
        private void GetAssetnumber()
        {
            if (GetReceiveId() > 0)
            {
                DataTable dt = _clsdao.getTable("select aor.asset_id, ap.porduct_code + ' ' + ap.ASSET_CODE + ' | '+ convert(varchar, ap.id) 'AssetType'  from "
                + " ASSET_PRODUCT ap inner join ASSET_ORDER_RECEIVED aor on ap.id = aor.asset_id and aor.id = " + filterstring(GetReceiveId().ToString()) + "");
                foreach (DataRow dr in dt.Rows)
                {
                    assettype.Text = dr["AssetType"].ToString();
                    hdnAssetId.Value = dr["asset_id"].ToString();
                    assettype.Enabled = false;
                    GetDepretiationValue();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ReadSession().UserType == "A")
                {
                    _clsdao.CreateDynamicDDl(branchname, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
                }
                else
                {
                    _clsdao.CreateDynamicDDl(branchname, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches where branch_id="+ReadSession().Branch_Id+"", "BRANCH_ID", "BRANCH_NAME","", "Select");

                }

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 286) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    populateAssetBooking();
                    disabledForm();
                }
                GetAssetnumber();                
                AutoCompleteExtender2.ContextKey = "";
            }
        }

        private void PopulateVendor()
        {
            _clsdao.CreateDynamicDDl(vendorName, "select id,CustomerName,* from Customer with (Nolock) where IsActive='Y'", "id", "CustomerName", "", "Select");
        }
        private void populateAssetBooking()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT a.branch_id,dept_id,a.product_id,a.vendorId,p.ASSET_CODE+'('+p.product_desc +')|'+CAST(p.id AS VARCHAR) as prductName,"
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
                PopulateVendor();
                vendorName.Text = dr["vendorId"].ToString();
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
        private void GetDepretiationValue()
        {
            if (!String.IsNullOrEmpty(hdnAssetId.Value))
            {
                TxtDepPct.Text = _clsdao.GetSingleresult("select DBO.FNAGetDepPrcnt(" + hdnAssetId.Value + ")");
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
                string isAmortised = "";
                string life_month = "";
                if (chkAmortised.Checked == true)
                {
                    isAmortised = "Y";
                    life_month = txtLifeInMonth.Text;
                }
                else
                {
                    isAmortised = "N";
                    life_month = txtLifeInMonth.Text;
                }
                if (GetId() > 0)
                {
                    var sql = "Exec prcManageInventoryMaster @flag='m',";
                    sql += "@dept_id=" + filterstring(deptname.Text);
                    sql +=",@asset_holder="+getEmpIdfromInfo(assetholder.Text);
                    sql += ",@ins_id=" + filterstring(hdnInsuredId.Value);
                    sql += ",@asset_status=" + filterstring(assetstatus.Text);
                    sql += ",@booked_date=" + filterstring(bookingdate.Text);
                    sql += ",@purchase_date=" + filterstring(txtPurchaseDate.Text);
                    sql += ",@warr_expiry=" + filterstring(warrexpirydate.Text);
                    sql += ",@next_maintenance_date=" + filterstring(nextmaindate.Text);
                    sql += ",@narration=" + filterstring(narration.Text);
                    sql += ",@asset_serial=" + filterstring(assetserial.Text);
                    sql += ",@depre_pct=" + filterstring(TxtDepPct.Text);
                    sql += ",@Vendor_id=" + filterstring(vendorName.Text);
                    sql += ",@user= null";
                    sql += ",@qty=" + filterstring(txtAssetQty.Text);
                    sql += ",@life_month=" + filterstring(txtLifeInMonth.Text);
                    sql += ",@row_id=" + GetId();

                    _clsdao.runSQL(sql);
                    Response.Redirect("ListModAsset.aspx");
                }
            }
            catch
            {
                lblmsg.Text = "Error In Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }            
        }
        //protected void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='ass_booked',@ID=" + GetId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
        //    if (msg.Contains("SUCCESS"))
        //    {
        //        Response.Redirect("ListAssetBooking.aspx");
        //    }
        //    else
        //    {
        //        lblmsg.Text = msg;
        //        lblmsg.Focus();
        //        return;
        //    }
        //    string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='ass_delete',@ID=" + GetId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
        //    if (msg.Contains("Success"))
        //    {
        //        Response.Redirect("/ModifyAssetLocation/ListModAsset.aspx");
        //    }
        //    else
        //    {
        //        lblmsg.Text = msg;
        //        lblmsg.Focus();
        //        return;
        //    }

        //}
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListModAsset.aspx");
        }
        private void disabledForm()
        {
            branchname.Enabled = false;
            txtAssetQty.Enabled = false;
            assettype.Enabled = false;
            depstartdate.Enabled = false;
            accdep.Enabled = false;
            purchasevalue.Enabled = false;
            vendorName.Enabled = false;
            bookingdate.Enabled = false;
            txtPurchaseDate.Enabled = false;
            assetstatus.Enabled = false;
            depstartdate.Enabled = false;
            billid.Enabled = false;
            insuranceid.Enabled = false;
            nextmaindate.Enabled = false;
            OldAssetCode.Enabled = false;
            OldAssetNo.Enabled = false;
            ModelNo.Enabled = false;
            Brand.Enabled = false;
            assetserial.Enabled = false;
            TxtDepPct.Enabled = false;
            warrexpirydate.Enabled = false;
            chkAmortised.Enabled = false;
            narration.Enabled = false;
        }


        protected void assettype_TextChanged(object sender, EventArgs e)
        {
            GetDepretiationValue();
        }

        protected void chkAmortised_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAmortised.Checked == true)
            {
                txtLifeInMonth.Text = "";
                txtLifeInMonth.Visible = true;
            }
            else
            {
                txtLifeInMonth.Text = "";
                txtLifeInMonth.Visible = false;

            }
        }
        protected void bookingdate_TextChanged(object sender, EventArgs e)
        {
            if (bookingdate.Text != "")
            {
                string DEP_DATE = _clsdao.GetSingleresult("select dbo.[GetDepStartDateNCC](" + filterstring(bookingdate.Text) + ")");
                DateTime dep_date = DateTime.Parse(DEP_DATE);
                depstartdate.Text = dep_date.ToString("MM/dd/yyyy");
            }            
        }
    }
}