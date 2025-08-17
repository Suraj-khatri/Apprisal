using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.AssetMaintenance;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.web.DAL.AssetMaintenance;

namespace SwiftHrManagement.web.AssetManagement.AssetMaintainenceStatus
{
    public partial class Manage : BasePage
    {
        ClsDAOInv _clsdao = null;
        AssetMaintenanceDao _amDao = null;
        AssetMaintenance assetMntnce = null;
        
        public Manage()
        {
            _clsdao = new ClsDAOInv();
            _amDao = new AssetMaintenanceDao();
            assetMntnce = new AssetMaintenance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textbox.Visible = false;
                PopulateDDl();
                ddlBranchName.Enabled = false;
                ddlDepartReq.Enabled = false;
                ddlReqUser.Enabled = false;
                txtVendorAuto.Enabled = false;
                if (GetRowId() > 0)
                {
                    PopulateAssetMaintainence();
                    string status = GetStatus();
                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        if (status.ToUpper() == "FWDTV" || status.ToUpper() == "RECVD" || status.ToUpper() == "FWDTBNCH" || status.ToUpper() == "FWDTVO")
                        {
                            DisableAll();

                            ActualReceivedDate.Visible = true;
                            ButtonTextManage(status);
                        }
                    }
                    else
                    {
                        if (HdnStatus.Value != "REQ" )
                        {
                            DisableAll();
                        }
                    }

                }
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void ButtonTextManage(string status)
        {
            switch (status)
            {
                case "RECVD":
                    Btn_Save.Text = "Forward Back";
                    break;

                case "FWDTBNCH":
                    Btn_Save.Text = "Acknowledge";
                    break;

                case "FWDTVO":
                    Btn_Save.Text = "Acknowledge";
                    break;
                    
            }
        }

        private void PopulateAssetMaintainence()
        {
            string vendor = "";
            var id = GetRowId();
           
            AssetMaintenanceDao _asmtDao = new AssetMaintenanceDao();
            DataSet ds = _asmtDao.getAssetDetails(id);

            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            TxtAssetNumber.Text = dt1.Rows[0][("Asset_id")].ToString();
            //TxtAssetName = dt1.Rows[0][("Asset_id")].ToString();
            TxtBookValue.Text = dt1.Rows[0]["book_value"].ToString();
            txtPurchaseValue.Text = dt1.Rows[0]["purchase_value"].ToString();
            txtAssetNarration.Text = dt1.Rows[0]["AssetNarration"].ToString();

            ddlBranchName.Text = dt.Rows[0]["RequestingBranch"].ToString();
            populateDepartment(dt.Rows[0]["RequestingBranch"].ToString());
            ddlDepartReq.Text = dt.Rows[0]["RequestingDepartment"].ToString();
            populateDdluser();
            ddlReqUser.Text = dt.Rows[0]["RequestingUser"].ToString();

            ddlForwardedTo.Text = dt.Rows[0]["ForwardedToBranch"].ToString();
            populateDepartmentForward(dt.Rows[0]["ForwardedToBranch"].ToString());
            ddlDept.Text = dt.Rows[0]["ForwardedToDepartment"].ToString();
            string ftd = dt.Rows[0]["ForwardedToDepartment"].ToString();
            populateDdluserForward(string.IsNullOrWhiteSpace(ftd) ? "0" : ftd);
            ddlUser.Text = dt.Rows[0]["ForwardedToUser"].ToString();

            ddlVendorType.Text = dt.Rows[0]["VendorType"].ToString();
            if (dt.Rows[0]["VendorType"].ToString() == "New")
            {
                textbox.Visible = true;
                autocomplete.Visible = false;
                txtVendor.Text = dt.Rows[0]["Vendor_Name"].ToString();
            }
            else
            {
                textbox.Visible = false;
                autocomplete.Visible = true;
                txtVendorAuto.Text = dt.Rows[0]["Vendor_Name"].ToString();
                hdnVendorId.Value = dt.Rows[0]["VendorId"].ToString();
            }
           
            TxtRepairAmt.Text = dt.Rows[0]["RepairCost"].ToString();
            TxtReturnDate.Text = dt.Rows[0]["ApproxReturnDate"].ToString();
            TxtNarrationVendor.Text = dt.Rows[0]["Narration"].ToString();
            TxtActualRecvDate.Text = dt.Rows[0]["ReceivedDate"].ToString();
            HdnStatus.Value = dt.Rows[0]["ProcessStatus"].ToString();
        }

        private void DisableAll()
        {
            TxtAssetNumber.Enabled = false;
            TxtBookValue.Enabled = false;
            txtPurchaseValue.Enabled = false;
            txtAssetNarration.Enabled = false;
            ddlBranchName.Enabled = false;
            ddlDepartReq.Enabled = false;
            ddlReqUser.Enabled = false;
            ddlForwardedTo.Enabled = false;
            ddlDept.Enabled = false;
            ddlUser.Enabled = false;
            ddlVendorType.Enabled = false;
            txtVendor.Enabled = false;
            TxtReturnDate.Enabled = false;
            //TxtRepairAmt.Enabled = string.IsNullOrWhiteSpace(TxtRepairAmt.Text);
            TxtNarrationVendor.Enabled = false;
        }

        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            
        }
        private long GetRowId()
        {
            return (Request.QueryString["RowId"] != null ? long.Parse(Request.QueryString["RowId"].ToString()) : 0);
        }

        private string GetStatus()
        {
            return Request.QueryString["statusFor"] ?? "";
        }
        private void ManageAssetMaintenance()
        {
            long Id = this.GetRowId();
            this.prepareDetails();
            var result = _amDao.ManageAssetMaintenance(this.assetMntnce);
            if (result.ErrorCode == "0")
            {
                if (!string.IsNullOrWhiteSpace(GetStatus()))
                {
                    Response.Redirect("ListApprove.aspx");
                }
                else
                {
                    Response.Redirect("List.aspx");
                    
                }
            }
            else
            {
                LblMsg.Text = result.Msg;
                LblMsg.ForeColor = Color.Red;
            }
        }
        private void prepareDetails()
        {
            long Id = this.GetRowId();
            AssetMaintenance _amtnc = new AssetMaintenance();

            _amtnc.User = ReadSession().UserName ?? "";
            _amtnc.RowId = Id;
            _amtnc.AssetId = string.IsNullOrWhiteSpace(HdnAssetnumber.Value) ? 0 : Convert.ToInt64(HdnAssetnumber.Value);
            _amtnc.RequestingBranch = string.IsNullOrWhiteSpace(ddlBranchName.SelectedValue) ? 0 : Convert.ToInt64(ddlBranchName.SelectedValue);

            _amtnc.RequestingDepartment = string.IsNullOrWhiteSpace(ddlDepartReq.SelectedValue) ? 0 : Convert.ToInt64(ddlDepartReq.SelectedValue);
            _amtnc.RequestingUser = string.IsNullOrWhiteSpace(ddlReqUser.SelectedValue) ? 0 : Convert.ToInt64(ddlReqUser.SelectedValue);
            _amtnc.ForwardedToBranch = string.IsNullOrWhiteSpace(ddlForwardedTo.SelectedValue) ? 0 : Convert.ToInt64(ddlForwardedTo.SelectedValue);
            _amtnc.ForwardedToDepartment = string.IsNullOrWhiteSpace(ddlDept.SelectedValue) ? 0 : Convert.ToInt64(ddlDept.SelectedValue);
            _amtnc.ForwardedToUser = string.IsNullOrWhiteSpace(ddlUser.SelectedValue) ? 0 : Convert.ToInt64(ddlUser.SelectedValue);

            _amtnc.Vendor = string.IsNullOrWhiteSpace(txtVendorAuto.Text) ? 0 : Convert.ToInt64(hdnVendorId.Value);
               

            _amtnc.NewVendorName =  txtVendor.Text.Trim() ?? "";
            _amtnc.EstmDate = TxtReturnDate.Text ?? "";
            _amtnc.RepairAmount = string.IsNullOrWhiteSpace(TxtRepairAmt.Text) ? 0 : Convert.ToDouble(TxtRepairAmt.Text); 
            _amtnc.Narration = TxtNarrationVendor.Text ?? "";
            _amtnc.ReceivedDate = TxtActualRecvDate.Text ?? "";


            _amtnc.ProcessStatus = GetProcessStatus();
            

            this.assetMntnce = _amtnc;
        }

        private string GetProcessStatus()
        {
            string processStatus = "";
            if (GetRowId() > 0)
            {
                if (!string.IsNullOrWhiteSpace(TxtActualRecvDate.Text) && (GetStatus() == "FWDTV" ))
                {
                    processStatus = "RECVD";//RECEIVED
                }
                else if ( GetStatus() == "RECVD")
                {
                    processStatus = "FWDTBNCH";//FORWARD TO BRANCH
                }
                else if (GetStatus() == "REQ" || HdnStatus.Value=="REQ")
                {
                    processStatus = "FWDTV";//FORWARD TO VENDOR
                }
                else if (GetStatus() == "FWDTBNCH" || GetStatus() == "FWDTVO")
                {
                    processStatus = "ACK";//ACKNOWLEDGE
                }
                else
                {
                    processStatus = "0";
                }
            }
            else
            {
                var vendor = !String.IsNullOrWhiteSpace(txtVendorAuto.Text) ? hdnVendorId.Value : txtVendor.Text;

                if (!String.IsNullOrWhiteSpace(ddlUser.SelectedValue) && !String.IsNullOrWhiteSpace(vendor))
                {
                    processStatus = "FWDTV";//FORWARD TO VENDOR
                }
                else if (String.IsNullOrWhiteSpace(ddlUser.SelectedValue) && !String.IsNullOrWhiteSpace(vendor))
                {
                    processStatus = "FWDTVO";//FORWARD TO VENDOR ONLY
                }
                else if (!String.IsNullOrWhiteSpace(ddlUser.SelectedValue) && String.IsNullOrWhiteSpace(vendor))
                {
                    processStatus = "REQ";//REQUEST
                }
                else
                {
                    LblMsg.Text = "Please select forwarded to group and/or vendor information";
                    LblMsg.ForeColor = Color.Red;
                }
            }
           
            return processStatus;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            if (!validationGroups())
            {
                return;
            }
       
            if (string.IsNullOrWhiteSpace(GetProcessStatus()))
            {
                return;
            }   
            ManageAssetMaintenance();
        }

        private bool validationGroups()
        {
            if (Btn_Save.Text == "Acknowledge" || (GetStatus() == "FWDTV"))
            {
                if (string.IsNullOrWhiteSpace(TxtActualRecvDate.Text))
                {
                    LblMsg.Text = "Actual Received On is required!";
                    LblMsg.ForeColor = Color.Red;
                    return false;
                }

                if (string.IsNullOrWhiteSpace(TxtRepairAmt.Text))
                {
                    LblMsg.Text = "Repair Cost is required!";
                    LblMsg.ForeColor = Color.Red;
                    return false;
                }
            }
            if (GetRowId() > 0 && GetStatus()!="REQ")
            {
                return true;
            }

            if (ddlVendorType.SelectedValue == "New")
            {
                if (string.IsNullOrWhiteSpace(txtVendor.Text))
                {
                    LblMsg.Text = "Text is required in Vendor name field. You cannot enter space/blank only!";
                    LblMsg.ForeColor = Color.Red;
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtVendorAuto.Text) || !string.IsNullOrWhiteSpace(txtVendor.Text))
            {
                if (string.IsNullOrWhiteSpace(TxtReturnDate.Text))
                {
                    LblMsg.Text = "Estimated Return Date is required";
                    LblMsg.ForeColor = Color.Red;
                    return false;
                }
                if (string.IsNullOrWhiteSpace(TxtNarrationVendor.Text))
                {
                    LblMsg.Text = "Narration is required";
                    LblMsg.ForeColor = Color.Red;
                    return false;
                }
               
            }
                  
            return true;
        }
        
        private void getbookvalue()
        {
            var asset = string.IsNullOrWhiteSpace(HdnAssetnumber.Value) ? "0" : HdnAssetnumber.Value;
            DataTable dt = _clsdao.getTable("exec [ProcPopulateAssetDetails] @assetid=" + asset + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtBookValue.Text = dr["book_value"].ToString();
                //txtAccDep.Text = dr["acc_dep"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                TxtBookValue.Text = dr["book_value"].ToString();
                txtAssetNarration.Text = dr["narration"].ToString();
            }
        }

        protected void TxtAssetNumber_OnTextChanged(object sender, EventArgs e)
        {
            getbookvalue();
        }
        private void PopulateDdlBranch()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "Select";
                branchlist.Insert(0, DefaultBrn);
                ddlBranchName.DataSource = branchlist;
                ddlBranchName.DataTextField = "Name";
                ddlBranchName.DataValueField = "Id";
                ddlBranchName.DataBind();

                this.ddlBranchName.Text = ReadSession().Branch_Id.ToString();

               
            }
            populateDepartment("");
        }
        private void PopulateDdlBranchForward()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "Select";
                branchlist.Insert(0, DefaultBrn);

                ddlForwardedTo.DataSource = branchlist;
                ddlForwardedTo.DataTextField = "Name";
                ddlForwardedTo.DataValueField = "Id";
                ddlForwardedTo.DataBind();
                ddlForwardedTo.SelectedIndex = 0;
            }
        }

        private void PopulateDDl()
        {
            PopulateDdlBranch();
            populateDdluser();
            PopulateDdlBranchForward();
            
        }

        private void populateDepartment(string branch)
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID((string.IsNullOrWhiteSpace(branch) ? long.Parse(ddlBranchName.Text) : long.Parse(branch)));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                ddlDepartReq.DataSource = deptlist;
                ddlDepartReq.DataTextField = "Deptname";
                ddlDepartReq.DataValueField = "Id";
                ddlDepartReq.DataBind();
                if (GetRowId() == 0 )
                {
                    ddlDepartReq.SelectedValue = ReadSession().Department;
                }
                
            }
        }
        private void populateDepartmentForward(string ForwardedTo)
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID((string.IsNullOrWhiteSpace(ForwardedTo) ? long.Parse(ddlForwardedTo.Text) : long.Parse(ForwardedTo)));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);


                ddlDept.DataSource = deptlist;
                ddlDept.DataTextField = "Deptname";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
                ddlDept.SelectedIndex = 0;

            }
            
        }

        private void populateDdluser()
        {
            EmployeeDAO _empDao = new EmployeeDAO();
            List<Employee> _emplist = _empDao.FindFullNameByIds(long.Parse(ddlBranchName.Text), long.Parse(ddlDepartReq.Text));
            if (_emplist != null && _emplist.Count > 0)
            {
                Employee empCore = new Employee();
                empCore.EmpName = "Select";
                _emplist.Insert(0, empCore);
                this.ddlReqUser.DataSource = _emplist;
                this.ddlReqUser.DataTextField = "EmpName";
                this.ddlReqUser.DataValueField = "Id";
                this.ddlReqUser.DataBind();
                if (GetRowId() > 0)
                {
                    this.ddlReqUser.SelectedIndex = 0;
                }
                else
                { 
                    this.ddlReqUser.Text = ReadSession().Emp_Id.ToString();
                }

            }
        }
        private void populateDdluserForward(string userForwardTo)
        {
            EmployeeDAO _empDao = new EmployeeDAO();

            List<Employee> _emplist = _empDao.FindFullNameByIds(long.Parse(ddlForwardedTo.Text), long.Parse(string.IsNullOrWhiteSpace(userForwardTo) ? ddlDept.Text : userForwardTo));
            if (_emplist != null && _emplist.Count > 0)
            {
                Employee empCore = new Employee();
                empCore.EmpName = "Select";
                _emplist.Insert(0, empCore);

                this.ddlUser.DataSource = _emplist;
                this.ddlUser.DataTextField = "EmpName";
                this.ddlUser.DataValueField = "Id";
                this.ddlUser.DataBind();
                ddlUser.SelectedIndex = 0;
            }
        }

        protected void ddlForwardedTo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlForwardedTo.SelectedValue == "0")
            {
                ddlDept.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDept.SelectedIndex = 0;

                ddlUser.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlUser.SelectedIndex = 0;
            }
            else
            {
                populateDepartmentForward("");                       
            }
            
        }

        protected void ddlDept_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDept.SelectedValue == "0")
            {
                ddlUser.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlUser.SelectedIndex = 0;
            }
            else
            {
                populateDdluserForward(null);
                
            }
        }

        protected void txtVendor_TextChanged(object sender, EventArgs e)
        {
            //if (txtVendor.Text != "")
            //{
            //    if (txtVendor.Text.Contains("|"))
            //    {
            //        string[] a = txtVendor.Text.Split('|');
            //        string vendor_code = a[1];
            //        hdnVendorId.Value = vendor_code;
            //        //txtProduct_AutoCompleteExtender.ContextKey = hdnVendorId.Value + '|' +
            //        //                                             ReadSession().Branch_Id.ToString();
            //        txtVendor.Focus();
            //    }
            //    else
            //    {
            //        LblMsg.Text = "Please Choose Vendor Properly!";
            //        LblMsg.ForeColor = System.Drawing.Color.Red;
            //        return;
            //    }
            //}
        }

        protected void ddlVendorType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVendorType.SelectedValue.ToString() == "New")
            {
                autocomplete.Visible = false;
                textbox.Visible = true;
                txtVendor.Enabled = true;
                txtVendor.Text = "";

            }
            else if (ddlVendorType.SelectedValue.ToString() == "Existing")
            {
                autocomplete.Visible = true;
                textbox.Visible = false;
                txtVendorAuto.Enabled = true;
                txtVendorAuto.Text = "";
            }
            else
            {
                txtVendorAuto.Text = "";
                txtVendor.Text = "";
                txtVendorAuto.Enabled = false;
                txtVendor.Enabled = false;
            }
           
        }
      
    }
}