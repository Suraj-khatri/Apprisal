using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.InsuranceDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageInsurance : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        InsuranceDAO _insrDao = null;
        InsueanceCore _insrCore = null;

        public ManageInsurance()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._insrDao = new InsuranceDAO();
            this._insrCore = new InsueanceCore();
        }
        public long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetInsuranceId()
        {
            return (Request.QueryString["Insurance_Id"] != null ? long.Parse(Request.QueryString["Insurance_Id"].ToString()) : 0);
        }
        private void PopulateInsurance()
        {
            this._insrCore = this._insrDao.FindById(this.GetInsuranceId());
            this.TxtAmount.Text = ShowDecimal(_insrCore.Insured_Amount.ToString());
            this.TxtInsuredDate.Text = this._insrCore.Insured_Date;  
            this.TxtExpDate.Text = this._insrCore.Expiry_Date;
            this.DdlInsurer.SelectedValue = this._insrCore.Insurer;
            this.DdlInsuranceFor.SelectedValue = this._insrCore.Insurance_For.ToString();
            this.ddlPremiumPayer.SelectedValue = this._insrCore.PremiumPayer;
            this.TxtInsurancePolicyNumber.Text = this._insrCore.InsurancePolicy;
            this.hdnempid.Value = this._insrCore.Employee_Id;
            this.txtA_Premium_Amt.Text = ShowDecimal(this._insrCore.AnnualPremiumAmt);
            this.ddlPay_frequency.Text = this._insrCore.Pay_Frequency;
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            if (GetInsuranceId() == 0)
            {
                hdnempid.Value = GetEmpId().ToString();
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            }
            else
            {
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            }
            //LblEmpName.Text = _empcore.EmpName;
        }

        private void PopulateDdlPremiumPayer()
        {
            string selectValue = "";
            if (ddlPremiumPayer.SelectedItem != null)
                selectValue = ddlPremiumPayer.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref ddlPremiumPayer, "Exec ProcStaticDataView 's','22'", "DETAIL_TITLE", "DETAIL_TITLE", selectValue, "Select...");
            swift.setDDL(ref DdlInsurer, "Exec ProcStaticDataView 's','33'", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
            
        }
        private void PopulateDdlInsuranceFor()
        {
            string selectValue1 = "";
            if (DdlInsuranceFor.SelectedItem != null)
                selectValue1 = DdlInsuranceFor.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlInsuranceFor, "Exec ProcStaticDataView 's','104'", "ROWID", "DETAIL_TITLE", selectValue1, "Select...");
        }
        private void ManageIns()
        {
            long id = this.GetInsuranceId();
            this.prepareEmployeeInsurance();
            if (id > 0)
            {
                string oldValue = this._insrDao.CRUDLog(id.ToString());
                this._insrDao.Update(this._insrCore);
                string newValue = this._insrDao.CRUDLog(id.ToString());
                this._insrDao.LogJobHistoryReport("update", "INSURANCE", id.ToString(), oldValue, newValue, ReadSession().UserId);
                     
            }
            else
            {
                this._insrDao.Save(this._insrCore);
                string Rowid = this._insrCore.Id.ToString();
                string newValue = this._insrDao.CRUDLog(Rowid);
                this._insrDao.LogJobHistoryReport("Insert", "INSURANCE", Rowid, "", newValue, ReadSession().UserId);
            }
        }

        private void prepareEmployeeInsurance()
        {
            InsueanceCore _insCore = new InsueanceCore();
            long insId = this.GetInsuranceId();
            _insCore.Employee_Id = this.hdnempid.Value;
            _insCore.Id = long.Parse(insId.ToString());
            _insCore.Insured_Amount = Double.Parse(TxtAmount.Text);
            _insCore.Insured_Date = TxtInsuredDate.Text;
            _insCore.Insurer = DdlInsurer.Text;
            _insCore.Insurance_For = DdlInsuranceFor.Text;
            _insCore.Expiry_Date = TxtExpDate.Text;
            _insCore.PremiumPayer = ddlPremiumPayer.Text;
            _insCore.InsurancePolicy = TxtInsurancePolicyNumber.Text;
            _insCore.AnnualPremiumAmt = txtA_Premium_Amt.Text;
            _insCore.Pay_Frequency = ddlPay_frequency.Text;
            _insCore.Salary_Deduction = ddlsalaryDeduction.Text;
            _insCore.CreatedBy = ReadSession().Emp_Id.ToString();

            this._insrCore = _insCore;
        }
        private void ResetInsurance()
        {
            TxtAmount.Text = "";
            TxtExpDate.Text = "";
            TxtInsuredDate.Text = "";
            DdlInsurer.Text = "";
            DdlInsuranceFor.Text = "";
            TxtInsurancePolicyNumber.Text = "";
            ddlPremiumPayer.Enabled = false;
            txtA_Premium_Amt.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDdlPremiumPayer();
                PopulateDdlInsuranceFor();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetInsuranceId();

                if (Id > 0)
                {
                    PopulateInsurance();
                    BtnDelete.Visible = true;
                    if (ddlPremiumPayer.SelectedValue == "Employee")
                    {
                        showHide.Visible = true;
                    }
                }
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                //showHide.Visible = false;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageIns();
                LblMsg.Text = "Operation Completed Successfully";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("/Company/EmployeeWeb/ListInsurance.aspx?Id="+hdnempid.Value+"");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_insrDao.ifexists(GetInsuranceId()) == false)
                {
                    string oldValue = this._insrDao.CRUDLog(GetInsuranceId().ToString());
                    _insrDao.DeleteInsurance(GetInsuranceId(), this.ReadSession().UserId);
                    this._insrDao.LogJobHistoryReport("Delete", "INSURANCE", GetInsuranceId().ToString(), oldValue, "", ReadSession().UserId);
                    Response.Redirect("/Company/EmployeeWeb/ListInsurance.aspx?Id=" + hdnempid.Value + "");
                }
                else
                {
                    LblMsg.Text = "Premium exists, cannot be deleted";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }   
        }
        protected void TxtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPremiumPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPremiumPayer.Text == "Employee")
            {
                showHide.Visible = true;
            }
            else
            {
                showHide.Visible = false;
            }
        }

        protected void DdlInsuranceFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlInsuranceFor.Text != "1504")
            {
                ddlPay_frequency.Text = "A";
            }
            else
            {
                ddlPay_frequency.Text = "M";
            }
        }
    }
}
