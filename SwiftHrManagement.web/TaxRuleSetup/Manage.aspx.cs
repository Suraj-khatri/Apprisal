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
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.TaxRuleSetup;

namespace SwiftHrManagement.web.TaxRuleSetup.BasicTaxRate
{
    public partial class Manage : BasePage
    {
        TaxRuleCore _taxRuleCore = null;
        TaxRuleSetupDAO _taxRuleDao = null;
        clsDAO _clsDao = null;
        public Manage()
        {
            _taxRuleCore = new TaxRuleCore();
            _taxRuleDao = new TaxRuleSetupDAO();
            _clsDao = new clsDAO();
            
        }

        private long GetTaxRuleID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PopulateFiscalYearList()
        {
            _clsDao.CreateDynamicDDl(CmbFiscalYear, "SELECT FISCAL_YEAR_NEPALI,* FROM FISCALYEAR WHERE FISCAL_YEAR_NEPALI NOT IN ( SELECT FY_ID FROM TAXRULESETUP)", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsDao.CreateDynamicDDl(CmbCopyFrom, "select FY_ID FROM TAXRULESETUP", "FY_ID", "FY_ID", "", "Select");
        }

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                PopulateDDLs();
                PopulateFiscalYearList();
                long id = GetTaxRuleID();

                if (id > 0)
                {
                    GetTaxRuleSetupDetails();
                }
            }
        }

      
        private void GetTaxRuleSetupDetails()
        {
            long id = GetTaxRuleID();
            _taxRuleCore = _taxRuleDao.GetTaxRuleSetupDetailList(id);
            CmbFiscalYear.Items.Add(_taxRuleCore.FyID);
            CmbFiscalYear.Text = _taxRuleCore.FyID;
            CmbCopyFrom.Enabled = false;
            PopulateControls(_taxRuleCore);           
        }

        private void PopulateControls(TaxRuleCore _taxRuleCore)
        {            
            TxtMarriedAmount1.Text = _taxRuleCore.MarriedAmount1.ToString();
            TxtMarriedTaxRate1.Text = _taxRuleCore.MarriedTaxRate1.ToString();
            TxtMarriedAmount2.Text = _taxRuleCore.MarriedAmount2.ToString();
            TxtMarriedTaxRate2.Text = _taxRuleCore.MarriedTaxRate2.ToString();
            TxtMarriedAmount3.Text = _taxRuleCore.MarriedAmount3.ToString();
            TxtMarriedTaxRate3.Text = _taxRuleCore.MarriedTaxRate3.ToString();
            TxtUnMarriedAmount1.Text = _taxRuleCore.UnMarriedAmount1.ToString();
            TxtUnMarriedTaxRate1.Text = _taxRuleCore.UnMarriedTaxRate1.ToString();
            TxtUnMarriedAmount2.Text = _taxRuleCore.UnMarriedAmount2.ToString();
            TxtUnMarriedTaxRate2.Text = _taxRuleCore.UnMarriedTaxRate2.ToString();
            TxtUnMarriedAmount3.Text = _taxRuleCore.UnMarriedAmount3.ToString();
            TxtUnMarriedTaxRate3.Text = _taxRuleCore.UnMarriedTaxRate3.ToString();
            TxtNonResidentialTaxRate.Text = _taxRuleCore.NonResidentialTaxRate.ToString();
            TxtNonResidentialTaxRateOf.Text = _taxRuleCore.NonResidentialTaxRateOf;
            TxtVehicleRate.Text = _taxRuleCore.VehicleRate.ToString();            
            CmbVehicleRateOf.Text = GetBenefitPecentageOf(_taxRuleCore.VehicleRateOf);
            TxtHouseRate.Text = _taxRuleCore.HouseRate.ToString();            
            CmbHouseRateOf.Text = GetBenefitPecentageOf(_taxRuleCore.HouseRateOf);
            TxtDiscountRate.Text = _taxRuleCore.DiscountRate.ToString();
            TxtDiscountRateOf.Text = _taxRuleCore.DiscountRateOf;
            TxtPensionRate.Text = _taxRuleCore.PensionRate.ToString();
            TxtPensionRateOf.Text = _taxRuleCore.PensionRateOf;
            TxtPensionCompAmount.Text = _taxRuleCore.PensionCompAmount.ToString();
            CmbPensionHigherLower.Text = CheckHigherLower(_taxRuleCore.PensionHigherLower); 
            EnableCheckBox(ChkPensionHolder, _taxRuleCore.PensionCompareFlg);
            TxtDisableRate.Text = _taxRuleCore.DisableRate.ToString();
            TxtDisableRateOf.Text = _taxRuleCore.DisableRateOf;
            TxtDisableCompAmount.Text = _taxRuleCore.DisableCompAmount.ToString();
            CmbDisableHigherLover.Text = CheckHigherLower(_taxRuleCore.DisableHigherLover); 
            EnableCheckBox(ChkDisable, _taxRuleCore.DisableCompareFlg); 
            TxtDonationRate.Text = _taxRuleCore.DonationRate.ToString();
            TxtDonationRateOf.Text = _taxRuleCore.DonationRateOf;
            TxtDonationCompAmount.Text = _taxRuleCore.DonationCompAmount.ToString();
            CmbDonationHigherLower.Text = CheckHigherLower(_taxRuleCore.DonationHigherLower);
            EnableCheckBox(ChkDonation, _taxRuleCore.DonationCompareFlg);
            TxtInsuranceRate.Text = _taxRuleCore.InsuranceRate.ToString();
            TxtInsuranceRateOf.Text = _taxRuleCore.InsuranceRateOf;
            TxtInsuranceCompAmount.Text = _taxRuleCore.InsuranceCompAmount.ToString();
            CmbInsuranceHigherLower.Text = CheckHigherLower(_taxRuleCore.InsuranceHigherLower);
            EnableCheckBox(ChkInsurance, _taxRuleCore.InsuranceCompareFlg);
            TxtFraction.Text = _taxRuleCore.Fraction;
            TxtFractionOf.Text = _taxRuleCore.FractionOf;
            TxtContributionCompAmount.Text = _taxRuleCore.ContributionCompAmount.ToString();
            CmbContributionHigherLower.Text = CheckHigherLower(_taxRuleCore.ContributionHigherLower);
            EnableCheckBox(ChkContribution, _taxRuleCore.ContributionActualCompFlg);
            TxtAdditionalTaxAmount.Text = _taxRuleCore.TxtAdditionalTaxAmount.ToString();
            TaxableAmountGreaterThan.Text = _taxRuleCore.TaxableAmountGreaterThan.ToString();
            TaxableAmountGreaterThanOf.Text = _taxRuleCore.TaxableAmountGreaterThanOf.ToString();
            Remotelocation.Text = _taxRuleCore.RemoteLocation.ToString();
            GroupB.Text = ShowDecimal(_taxRuleCore.GroupB.ToString());
            GroupC.Text = ShowDecimal(_taxRuleCore.GroupC.ToString());
            GroupD.Text = ShowDecimal(_taxRuleCore.GroupD.ToString());
            GroupE.Text = ShowDecimal(_taxRuleCore.GroupE.ToString());
            medical_tax_pcnt.Text = ShowDecimal(_taxRuleCore.MedicalTaxPcnt.ToString());
            medical_tax_limit.Text = ShowDecimal(_taxRuleCore.MedicalTaxLimit.ToString());


        }
       
        private string GetBenefitPecentageOf(string strBenifits)
        {
            string strReturn = "";
            if (strBenifits == "36")
            {
                strReturn = "Basic";
            }
            else if (strBenifits == "36,37")
            {
                strReturn = "Basic & Grade";
            }
            else if (strBenifits == "36,37,38")
            {
                strReturn = "Gross";
            }

            return strReturn;
        }
        
        private string CheckHigherLower(string strCheck)
        {
            if (strCheck == "H")
                return "Higher";
            else
                return "Lower";
        }
      
        private void EnableCheckBox(CheckBox ckb, string checkStr)
        {
            if (checkStr.ToUpper() == "Y")
                ckb.Checked = true;
            else
                ckb.Checked = false;
        }

        private void PopulateDDLs()
        {            
            CmbVehicleRateOf.Items.Add("Select");
            CmbVehicleRateOf.Items.Add("Basic");
            CmbVehicleRateOf.Items.Add("Basic & Grade");
            CmbVehicleRateOf.Items.Add("Gross");

            CmbHouseRateOf.Items.Add("Select");
            CmbHouseRateOf.Items.Add("Basic");
            CmbHouseRateOf.Items.Add("Basic & Grade");
            CmbHouseRateOf.Items.Add("Gross");

            CmbPensionHigherLower.Items.Add("Higher");
            CmbPensionHigherLower.Items.Add("Lower");
            CmbDisableHigherLover.Items.Add("Higher");
            CmbDisableHigherLover.Items.Add("Lower");
            CmbDonationHigherLower.Items.Add("Higher");
            CmbDonationHigherLower.Items.Add("Lower");
            CmbInsuranceHigherLower.Items.Add("Higher");
            CmbInsuranceHigherLower.Items.Add("Lower");

            CmbContributionHigherLower.Items.Add("Higher");
            CmbContributionHigherLower.Items.Add("Lower");

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PrepareTaxRuleList();
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void PrepareTaxRuleList()
        {

            try
            {
                
                _taxRuleCore.FyID = CmbFiscalYear.Text;
                _taxRuleCore.MarriedAmount1 = Convert.ToDouble(TxtMarriedAmount1.Text);
                _taxRuleCore.MarriedTaxRate1 = float.Parse(TxtMarriedTaxRate1.Text);
                _taxRuleCore.UnMarriedAmount1 = Convert.ToDouble(TxtUnMarriedAmount1.Text);
                _taxRuleCore.UnMarriedTaxRate1 = Convert.ToDouble(TxtUnMarriedTaxRate1.Text);
                _taxRuleCore.MarriedAmount2 = Convert.ToDouble(TxtMarriedAmount2.Text);
                _taxRuleCore.MarriedTaxRate2 = Convert.ToDouble(TxtMarriedTaxRate2.Text);
                _taxRuleCore.UnMarriedAmount2 = Convert.ToDouble(TxtUnMarriedAmount2.Text);
                _taxRuleCore.UnMarriedTaxRate2 = Convert.ToDouble(TxtUnMarriedTaxRate2.Text);
                _taxRuleCore.MarriedAmount3 = TxtMarriedAmount3.Text;
                _taxRuleCore.MarriedTaxRate3 = Convert.ToDouble(TxtMarriedTaxRate3.Text);
                _taxRuleCore.UnMarriedAmount3 = TxtUnMarriedAmount3.Text;
                _taxRuleCore.UnMarriedTaxRate3 = Convert.ToDouble(TxtUnMarriedTaxRate3.Text);
                _taxRuleCore.NonResidentialTaxRate = Convert.ToDouble(TxtNonResidentialTaxRate.Text);
                _taxRuleCore.NonResidentialTaxRateOf = TxtNonResidentialTaxRateOf.Text;
                _taxRuleCore.VehicleRate = Convert.ToDouble(TxtVehicleRate.Text);               
                _taxRuleCore.VehicleRateOf = SelectBenefitPecentageOf(CmbVehicleRateOf);
                _taxRuleCore.HouseRate = Convert.ToDouble(TxtHouseRate.Text);               
                _taxRuleCore.HouseRateOf = SelectBenefitPecentageOf(CmbHouseRateOf);
                _taxRuleCore.DiscountRate = Convert.ToDouble(TxtDiscountRate.Text);
                _taxRuleCore.DiscountRateOf = TxtDiscountRateOf.Text;
                _taxRuleCore.PensionRate = Convert.ToDouble(TxtPensionRate.Text);
                _taxRuleCore.PensionRateOf = TxtPensionRateOf.Text;
                _taxRuleCore.PensionCompAmount = Convert.ToDouble(TxtPensionCompAmount.Text);                
                _taxRuleCore.PensionHigherLower = GetHigherLowerFlag(CmbPensionHigherLower);
                _taxRuleCore.TxtAdditionalTaxAmount = Convert.ToDouble(TxtAdditionalTaxAmount.Text);
                _taxRuleCore.TaxableAmountGreaterThan = Convert.ToDouble(TaxableAmountGreaterThan.Text);
                _taxRuleCore.TaxableAmountGreaterThanOf = TaxableAmountGreaterThanOf.Text;
                _taxRuleCore.RemoteLocation = Remotelocation.Text;
                _taxRuleCore.GroupB = GroupB.Text;
                _taxRuleCore.GroupC = GroupC.Text;
                _taxRuleCore.GroupD = GroupD.Text;
                _taxRuleCore.GroupE = GroupE.Text;
                _taxRuleCore.MedicalTaxPcnt = medical_tax_pcnt.Text;
                _taxRuleCore.MedicalTaxLimit = medical_tax_limit.Text;

                if (ChkPensionHolder.Checked == true)
                {
                    _taxRuleCore.PensionCompareFlg = "Y";
                }
                else
                {
                    _taxRuleCore.PensionCompareFlg = "N";
                }

                _taxRuleCore.DisableRate = Convert.ToDouble(TxtDisableRate.Text);
                _taxRuleCore.DisableRateOf = TxtDisableRateOf.Text;
                _taxRuleCore.DisableCompAmount = Convert.ToDouble(TxtDisableCompAmount.Text);                
                _taxRuleCore.DisableHigherLover = GetHigherLowerFlag(CmbDisableHigherLover);

                if (ChkDisable.Checked == true)
                {
                    _taxRuleCore.DisableCompareFlg = "Y";
                }
                else
                {
                    _taxRuleCore.DisableCompareFlg = "N";
                }
                _taxRuleCore.DonationRate = Convert.ToDouble(TxtDonationRate.Text);
                _taxRuleCore.DonationRateOf = TxtDonationRateOf.Text;
                _taxRuleCore.DonationCompAmount = Convert.ToDouble(TxtDonationCompAmount.Text);                
                _taxRuleCore.DonationHigherLower = GetHigherLowerFlag(CmbDonationHigherLower);
                if (ChkDonation.Checked == true)
                {
                    _taxRuleCore.DonationCompareFlg = "Y";
                }
                else
                {
                    _taxRuleCore.DonationCompareFlg = "N";
                }

                _taxRuleCore.InsuranceRate = Convert.ToDouble(TxtInsuranceRate.Text);
                _taxRuleCore.InsuranceRateOf = TxtInsuranceRateOf.Text;
                _taxRuleCore.InsuranceCompAmount = Convert.ToDouble(TxtInsuranceCompAmount.Text);
                //_taxRuleCore.InsuranceHigherLower = CmbInsuranceHigherLower.Text;
                _taxRuleCore.InsuranceHigherLower = GetHigherLowerFlag(CmbInsuranceHigherLower);


                if (ChkInsurance.Checked == true)
                {
                    _taxRuleCore.InsuranceCompareFlg = "Y";
                }
                else
                {
                    _taxRuleCore.InsuranceCompareFlg = "N";
                }

                _taxRuleCore.Fraction = TxtFraction.Text;
                _taxRuleCore.FractionOf = TxtFractionOf.Text;
                _taxRuleCore.ContributionCompAmount = Convert.ToDouble(TxtContributionCompAmount.Text);                
                _taxRuleCore.ContributionHigherLower = GetHigherLowerFlag(CmbContributionHigherLower);

                if (ChkContribution.Checked == true)
                {
                    _taxRuleCore.ContributionActualCompFlg = "Y";
                }
                else
                {
                    _taxRuleCore.ContributionActualCompFlg = "N";
                }
                long id = GetTaxRuleID();                                      
               
                if (id > 0)
                {
                    _taxRuleCore.TaxRuleID = Convert.ToInt16(id);                    
                    _taxRuleCore.ModifiedEmpID = ReadSession().Emp_Id;
                    _taxRuleDao.Update(_taxRuleCore);
                }
                else
                {
                    _taxRuleCore.TaxRuleID = Convert.ToInt16(id);                    
                    _taxRuleCore.CreatedEmpID = ReadSession().Emp_Id;
                    _taxRuleDao.Save(_taxRuleCore);
                }
            }
            catch
            {
            }
        }

        private string SelectBenefitPecentageOf(DropDownList ddl)
        {
            string strReturn = "";

            if (ddl.Text == "Basic")
            {
                strReturn = "36";
            }
            else if (ddl.Text == "Basic & Grade")
            {
                strReturn = "36,37";
            }
            else if (ddl.Text == "Gross")
            {
                strReturn = "36,37,38";
            }

            return strReturn;
        }

        private string GetHigherLowerFlag(DropDownList ddl)
        {
            if (ddl.Text == "Higher")
                return "H";
            else
                return "L";
        }

        protected void CmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void CmbCopyFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _taxRuleCore = _taxRuleDao.GetTaxRuleSetupDetailListByFyID(CmbCopyFrom.Text);                
                PopulateControls(_taxRuleCore);
            }
            catch
            {
            }
        }
               
    }
}
