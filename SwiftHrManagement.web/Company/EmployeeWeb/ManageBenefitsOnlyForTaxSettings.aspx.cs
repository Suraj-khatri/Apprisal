using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.BenefitsOnlyForTaxSettingsDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsOnlyForTaxDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageBenefitsOnlyForTaxSettings : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        BenefitsOnlyForTaxDAO _benefitsSettingDAO = null;
        BenefitsOnlyForTaxCore _benefitsCore = null;
        public ManageBenefitsOnlyForTaxSettings()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._benefitsCore = new BenefitsOnlyForTaxCore();
            this._benefitsSettingDAO = new BenefitsOnlyForTaxDAO();
        }

        private void populateDdlBenefits()
        {
            string selectValue = "";
            if (ddlBenefitName.SelectedItem != null)
                selectValue = ddlBenefitName.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref ddlBenefitName, "Exec ProcStaticDataView 's','42'", "ROWID", "DETAIL_TITLE", "selectValue", "Select");
            swift.CreateDynamicDDl(DDLFY, "SELECT FISCAL_YEAR_ENGLISH ,FISCAL_YEAR_NEPALI FROM FISCALYEAR", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetBenefitForTaxSettingsId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void PopulatePayable()
        {
            this._benefitsCore = this._benefitsSettingDAO.FindBenefitById((this.GetBenefitForTaxSettingsId()));
            this.ddlBenefitName.Text = this._benefitsCore.Int_ben_type;
            this.TxttaxableIntAmount.Text = this._benefitsCore.Taxable_int_amt.ToString();
            DDLFY.Text = _benefitsCore.Fis_year;
            TxtIntAmt.Text = _benefitsCore.Act_int_paid.ToString();
            TxtAppIntRate.Text = _benefitsCore.Applied_int_rate.ToString();
            TxtMarketIntRate.Text = _benefitsCore.Market_int_rate.ToString();
            TxtNaration.Text = _benefitsCore.Narration;
            this.hdnEmployeeId.Value = this._benefitsCore.Empid.ToString();
        }
        private void ManageBenefitSetting()
        {
            BenefitsOnlyForTaxCore _bCore = new BenefitsOnlyForTaxCore();
            long id = this.GetBenefitForTaxSettingsId();
            _bCore.Id = id;
            _bCore.Int_ben_type = this.ddlBenefitName.Text;
            _bCore.Fis_year = DDLFY.Text;
            _bCore.Act_int_paid = double.Parse(TxtIntAmt.Text);
            _bCore.Applied_int_rate = double.Parse(TxtAppIntRate.Text);
            _bCore.Market_int_rate = double.Parse(TxtMarketIntRate.Text);
            TxttaxableIntAmount.Text = calculateTaxableInt().ToString();
            _bCore.Taxable_int_amt = double.Parse(this.TxttaxableIntAmount.Text);
            _bCore.Empid = long.Parse(hdnEmployeeId.Value.ToString());        
            _bCore.Narration = TxtNaration.Text;
            _benefitsCore = _bCore;
            if (id > 0)
            {
                string oldValue = this._benefitsSettingDAO.CRUDLog(id.ToString());

                _benefitsCore.ModifyBy = ReadSession().UserId;
                _benefitsCore.ModifyDate = _benefitsCore.ModifyDate;
                this._benefitsSettingDAO.Update(this._benefitsCore);

                string newValue = this._benefitsSettingDAO.CRUDLog(id.ToString());
                this._benefitsSettingDAO.LogJobHistoryReport("update", "InterestBenefitsOnlyForTaxSetting", id.ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                _benefitsCore.CreatedBy = ReadSession().UserId;
                _benefitsCore.CreatedDate = _benefitsCore.CreatedDate;
                this._benefitsSettingDAO.Save(this._benefitsCore);

                string Rowid = this._benefitsCore.Id.ToString();
                string newValue = this._benefitsSettingDAO.CRUDLog(Rowid);
                this._benefitsSettingDAO.LogJobHistoryReport("Insert", "InterestBenefitsOnlyForTaxSetting", Rowid, "", newValue, ReadSession().UserId);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetBenefitForTaxSettingsId();
                populateDdlBenefits();
                if (Id > 0)
                {
                    BtnDelete.Visible = true;
                    PopulatePayable();
                }
                else
                {
                    BtnDelete.Visible = false;
                    hdnEmployeeId.Value = GetEmpId().ToString();
                }
                
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                getemployee();
            }
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnEmployeeId.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }
        private double calculateTaxableInt()
        {
            double _tempactualintAmt = (double.Parse(TxtIntAmt.Text) * (double.Parse(TxtAppIntRate.Text) / 100));
            double _tempactintpaid = (_tempactualintAmt * 100) / (double.Parse(TxtAppIntRate.Text));
            double _tempdiffRate = (double.Parse(TxtMarketIntRate.Text) - (double.Parse(TxtAppIntRate.Text))) / 100;
            double _tempappliedIntRate = _tempactintpaid * _tempdiffRate;     

            return Math.Round(_tempappliedIntRate);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (checkrate() == false)
            {

                try
                {
                    ManageBenefitSetting();
                    lblTransactionMessage.Text = "Operation Completed Successfully";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListBenefitsOnlyForTaxSettings.aspx?Id=" + hdnEmployeeId.Value + "");
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private bool checkrate()
        {
            if (int.Parse(TxtAppIntRate.Text) > int.Parse(TxtMarketIntRate.Text))
            {
                lblTransactionMessage.Text = "Applied int rate canot be greater than Market int rate";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._benefitsSettingDAO.CRUDLog(GetBenefitForTaxSettingsId().ToString());
                this._benefitsSettingDAO.LogJobHistoryReport("Delete", "InterestBenefitsOnlyForTaxSetting", GetBenefitForTaxSettingsId().ToString(), oldValue, "", ReadSession().UserId);

                _benefitsSettingDAO.deletebenifit(GetBenefitForTaxSettingsId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListBenefitsOnlyForTaxSettings.aspx?Id=" + hdnEmployeeId.Value + "");
            }
            catch
            {
                lblTransactionMessage.Text = "Error in operation";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void TxtMarketIntRate_TextChanged(object sender, EventArgs e)
        {
            checkrate();
            TxttaxableIntAmount.Text = calculateTaxableInt().ToString();
        }
    }
}