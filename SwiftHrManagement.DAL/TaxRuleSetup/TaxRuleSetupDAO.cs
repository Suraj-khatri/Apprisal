using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.TaxRuleSetup
{
    public class TaxRuleSetupDAO : BaseDAO
    {

        public TaxRuleCore GetTaxRuleSetupDetailList(double id)
        {
            string sSql = "SELECT [ID],[FY_ID],DBO.SHOWDECIMAL([MARRIED_SLAB1]) AS MARRIED_SLAB1,[MARRIED_RATE1],DBO.SHOWDECIMAL([MARRIED_SLAB2]) AS MARRIED_SLAB2,[MARRIED_RATE2],[MARRIED_SLAB3],[MARRIED_RATE3]"
                    + ",DBO.SHOWDECIMAL([UNMARRIED_SLAB1]) AS UNMARRIED_SLAB1,[UNMARRIED_RATE1],DBO.SHOWDECIMAL([UNMARRIED_SLAB2]) AS UNMARRIED_SLAB2,[UNMARRIED_RATE2],[UNMARRIED_SLAB3],[UNMARRIED_RATE3]"
                    + ",[NON_NEPALI_RATE],[NON_NEPALI_RATE_OF],[VHCL_FACILITY_RATE],[VHCL_FACILITY_OF],[HOUSE_FACILITY_RATE],[HOUSE_FACILITY_OF]"
                    + ",[WOMAN_DISC_RATE],[WOMAN_DISC_RATE_OF],[PENSION_DED_RATE],[PENSION_DED_RATE_OF],[PENSION_COMP_AMT],[PENSION_COMP_ACTUAL_FLG]"
                    + ",[PENSION_HIGH_LOW_FLG],[DISABLE_DED_RATE],[DISABLE_DED_RATE_OF],[DISABLE_COMP_AMT],[DISABLE_COMP_ACTUAL_FLG],[DISABLE_HIGH_LOW_FLG]"
                    + ",[DONATION_DED_RATE],[DONATION_DED_RATE_OF],[DONATION_COMP_AMT],[DONATION_COMP_ACTUAL_FLG],[DONATION_HIGH_LOW_FLG],[INSURANCE_DED_RATE]"
                    + ",[INSURANCE_DED_RATE_OF],[INSURANCE_COMP_AMT],[INSURANCE_COMP_ACTUAL_FLG],[INSURANCE_HIGH_LOW_FLG],[CONTRIBUTION_FRACTION]"
                    + ",[CONTRIBUTION_FRACTION_OF],[CONTRIBUTION_COMP_AMT],[CONTRIBUTION_COMP_ACTUAL_FLG],[CONTRIBUTION_HIGH_LOW_FLG],[AMT_FOR_ADD_TAX]"
                    + ",[ADD_TAX_RATE],[ADD_TAX_RATE_OF],rl_groupA,rl_groupB,rl_groupC,rl_groupD,rl_groupE,medical_tax_pcnt,medical_tax_limit"
                    + " FROM [TaxRuleSetup] WHERE ID = " + id + "";

            DataTable dt = SelectByQuery(sSql);

            TaxRuleCore _tCore = null;

            if (dt != null)
            {
                _tCore = (TaxRuleCore)this.MapObject(dt.Rows[0]);
            }
            return _tCore;

        }

        public TaxRuleCore GetTaxRuleSetupDetailListByFyID(string fyID)
        {
            string sSql = "SELECT [ID],[FY_ID],DBO.SHOWDECIMAL([MARRIED_SLAB1]) AS MARRIED_SLAB1,[MARRIED_RATE1],DBO.SHOWDECIMAL([MARRIED_SLAB2]) AS MARRIED_SLAB2,[MARRIED_RATE2],[MARRIED_SLAB3],[MARRIED_RATE3]"
                    + ",[UNMARRIED_SLAB1],[UNMARRIED_RATE1],[UNMARRIED_SLAB2],[UNMARRIED_RATE2],[UNMARRIED_SLAB3],[UNMARRIED_RATE3]"
                    + ",[NON_NEPALI_RATE],[NON_NEPALI_RATE_OF],[VHCL_FACILITY_RATE],[VHCL_FACILITY_OF],[HOUSE_FACILITY_RATE],[HOUSE_FACILITY_OF]"
                    + ",[WOMAN_DISC_RATE],[WOMAN_DISC_RATE_OF],[PENSION_DED_RATE],[PENSION_DED_RATE_OF],[PENSION_COMP_AMT],[PENSION_COMP_ACTUAL_FLG]"
                    + ",[PENSION_HIGH_LOW_FLG],[DISABLE_DED_RATE],[DISABLE_DED_RATE_OF],[DISABLE_COMP_AMT],[DISABLE_COMP_ACTUAL_FLG],[DISABLE_HIGH_LOW_FLG]"
                    + ",[DONATION_DED_RATE],[DONATION_DED_RATE_OF],[DONATION_COMP_AMT],[DONATION_COMP_ACTUAL_FLG],[DONATION_HIGH_LOW_FLG],[INSURANCE_DED_RATE]"
                    + ",[INSURANCE_DED_RATE_OF],[INSURANCE_COMP_AMT],[INSURANCE_COMP_ACTUAL_FLG],[INSURANCE_HIGH_LOW_FLG],[CONTRIBUTION_FRACTION]"
                    + ",[CONTRIBUTION_FRACTION_OF],[CONTRIBUTION_COMP_AMT],[CONTRIBUTION_COMP_ACTUAL_FLG],[CONTRIBUTION_HIGH_LOW_FLG],[AMT_FOR_ADD_TAX],[ADD_TAX_RATE],[ADD_TAX_RATE_OF],rl_groupA,rl_groupB,rl_groupC,rl_groupD,rl_groupE,medical_tax_pcnt,medical_tax_limit"
                    + " FROM [TaxRuleSetup] WHERE FY_ID = '" + fyID + "'";

            DataTable dt = SelectByQuery(sSql);

            TaxRuleCore _tCore = null;

            if (dt != null)
            {
                _tCore = (TaxRuleCore)this.MapObject(dt.Rows[0]);
            }
            return _tCore;

        }

        public override object MapObject(System.Data.DataRow dr)
        {
            TaxRuleCore tCore = new TaxRuleCore();
            tCore.TaxRuleID = int.Parse(dr["ID"].ToString());
            tCore.FyID = dr["FY_ID"].ToString();
            tCore.MarriedAmount1 = double.Parse(dr["MARRIED_SLAB1"].ToString());
            tCore.MarriedTaxRate1 = float.Parse(dr["MARRIED_RATE1"].ToString());
            tCore.MarriedAmount2 = double.Parse(dr["MARRIED_SLAB2"].ToString());
            tCore.MarriedTaxRate2 = double.Parse(dr["MARRIED_RATE2"].ToString());
            tCore.MarriedAmount3 = dr["MARRIED_SLAB3"].ToString();
            tCore.MarriedTaxRate3 = double.Parse(dr["MARRIED_RATE3"].ToString());
            tCore.UnMarriedAmount1 = double.Parse(dr["UNMARRIED_SLAB1"].ToString());
            tCore.UnMarriedTaxRate1 = double.Parse(dr["UNMARRIED_RATE1"].ToString());
            tCore.UnMarriedAmount2 = double.Parse(dr["UNMARRIED_SLAB2"].ToString());
            tCore.UnMarriedTaxRate2 = double.Parse(dr["UNMARRIED_RATE2"].ToString());
            tCore.UnMarriedAmount3 = dr["UNMARRIED_SLAB3"].ToString();
            tCore.UnMarriedTaxRate3 = double.Parse(dr["UNMARRIED_RATE3"].ToString());
            tCore.NonResidentialTaxRate = double.Parse(dr["NON_NEPALI_RATE"].ToString());
            tCore.NonResidentialTaxRateOf = dr["NON_NEPALI_RATE_OF"].ToString();
            tCore.VehicleRate = double.Parse(dr["VHCL_FACILITY_RATE"].ToString());
            tCore.VehicleRateOf = dr["VHCL_FACILITY_OF"].ToString();
            tCore.HouseRate = double.Parse(dr["HOUSE_FACILITY_RATE"].ToString());
            tCore.HouseRateOf = dr["HOUSE_FACILITY_OF"].ToString();
            tCore.DiscountRate = double.Parse(dr["WOMAN_DISC_RATE"].ToString());
            tCore.DiscountRateOf = dr["WOMAN_DISC_RATE_OF"].ToString();
            tCore.PensionRate = double.Parse(dr["PENSION_DED_RATE"].ToString());
            tCore.PensionRateOf = dr["PENSION_DED_RATE_OF"].ToString();
            tCore.PensionCompAmount = double.Parse(dr["PENSION_COMP_AMT"].ToString());
            tCore.PensionCompareFlg = dr["PENSION_COMP_ACTUAL_FLG"].ToString();
            tCore.PensionHigherLower = dr["PENSION_HIGH_LOW_FLG"].ToString();
            tCore.DisableRate = double.Parse(dr["DISABLE_DED_RATE"].ToString());
            tCore.DisableRateOf = dr["DISABLE_DED_RATE_OF"].ToString();
            tCore.DisableCompAmount = double.Parse(dr["DISABLE_COMP_AMT"].ToString());
            tCore.DisableCompareFlg = dr["DISABLE_COMP_ACTUAL_FLG"].ToString();
            tCore.DisableHigherLover = dr["DISABLE_HIGH_LOW_FLG"].ToString();
            tCore.DonationRate = double.Parse(dr["DONATION_DED_RATE"].ToString());
            tCore.DonationRateOf = dr["DONATION_DED_RATE_OF"].ToString();
            tCore.DonationCompAmount = double.Parse(dr["DONATION_COMP_AMT"].ToString());
            tCore.DonationCompareFlg = dr["DONATION_COMP_ACTUAL_FLG"].ToString();
            tCore.DonationHigherLower = dr["DONATION_HIGH_LOW_FLG"].ToString();
            tCore.InsuranceRate = double.Parse(dr["INSURANCE_DED_RATE"].ToString());
            tCore.InsuranceRateOf = dr["INSURANCE_DED_RATE_OF"].ToString();
            tCore.InsuranceCompAmount = double.Parse(dr["INSURANCE_COMP_AMT"].ToString());
            tCore.InsuranceCompareFlg = dr["INSURANCE_COMP_ACTUAL_FLG"].ToString();
            tCore.InsuranceHigherLower = dr["INSURANCE_HIGH_LOW_FLG"].ToString();
            tCore.Fraction = dr["CONTRIBUTION_FRACTION"].ToString();
            tCore.FractionOf = dr["CONTRIBUTION_FRACTION_OF"].ToString();
            tCore.ContributionCompAmount = double.Parse(dr["CONTRIBUTION_COMP_AMT"].ToString());
            tCore.ContributionActualCompFlg = dr["CONTRIBUTION_COMP_ACTUAL_FLG"].ToString();
            tCore.ContributionHigherLower = dr["CONTRIBUTION_HIGH_LOW_FLG"].ToString();
            tCore.TxtAdditionalTaxAmount = double.Parse(dr["AMT_FOR_ADD_TAX"].ToString());
            tCore.TaxableAmountGreaterThan = double.Parse(dr["ADD_TAX_RATE"].ToString());
            tCore.TaxableAmountGreaterThanOf = dr["ADD_TAX_RATE_OF"].ToString();
            tCore.RemoteLocation = dr["rl_groupA"].ToString();
            tCore.GroupB = dr["rl_groupB"].ToString();
            tCore.GroupC = dr["rl_groupC"].ToString();
            tCore.GroupD = dr["rl_groupD"].ToString();
            tCore.GroupE = dr["rl_groupE"].ToString();
            tCore.MedicalTaxPcnt = dr["Medical_Tax_pcnt"].ToString();
            tCore.MedicalTaxLimit = dr["Medical_Tax_limit"].ToString();
            return tCore;
        }



        public override void Save(object obj)
        {
            TaxRuleCore _tCore = (TaxRuleCore)obj;
            String sSql = ("exec procManageTaxRulesSetup '" + _tCore.TaxRuleID + "',"
            + "'" + _tCore.FyID + "','" + _tCore.MarriedAmount1 + "','" + _tCore.MarriedTaxRate1 + "',"
            + "'" + _tCore.UnMarriedAmount1 + "','" + _tCore.UnMarriedTaxRate1 + "','" + _tCore.MarriedAmount2 + "',"
            + "'" + _tCore.MarriedTaxRate2 + "',"
            + "'" + _tCore.UnMarriedAmount2 + "','" + _tCore.UnMarriedTaxRate2 + "','" + _tCore.MarriedAmount3 + "',"
            + "'" + _tCore.MarriedTaxRate3 + "','" + _tCore.UnMarriedAmount3 + "','" + _tCore.UnMarriedTaxRate3 + "',"
            + "'" + _tCore.NonResidentialTaxRate + "','" + _tCore.NonResidentialTaxRateOf + "',"
            + "'" + _tCore.VehicleRate + "','" + _tCore.VehicleRateOf + "','" + _tCore.HouseRate + "',"
            + "'" + _tCore.HouseRateOf + "','" + _tCore.DiscountRate + "','" + _tCore.DiscountRateOf + "',"
            + "'" + _tCore.PensionRate + "','" + _tCore.PensionRateOf + "','" + _tCore.PensionCompAmount + "',"
            + "'" + _tCore.PensionHigherLower + "','" + _tCore.PensionCompareFlg + "','" + _tCore.DisableRate + "',"
            + "'" + _tCore.DisableRateOf + "','" + _tCore.DonationCompAmount + "','" + _tCore.DonationHigherLower + "',"
            + "'" + _tCore.DonationCompareFlg + "','" + _tCore.DonationRate + "','" + _tCore.DonationRateOf + "',"
            + "'" + _tCore.DonationCompAmount + "','" + _tCore.DonationHigherLower + "','" + _tCore.DonationCompareFlg + "',"
            + "'" + _tCore.InsuranceRate + "','" + _tCore.InsuranceRateOf + "','" + _tCore.InsuranceCompAmount + "',"
            + "'" + _tCore.InsuranceHigherLower + "','" + _tCore.InsuranceCompareFlg + "','" + _tCore.Fraction + "',"
            + "'" + _tCore.FractionOf + "','" + _tCore.ContributionCompAmount + "','" + _tCore.ContributionHigherLower + "',"
            + "'" + _tCore.ContributionActualCompFlg + "','" + _tCore.CreatedEmpID + "','" + _tCore.CreatedDate 
            + "','" + _tCore.TxtAdditionalTaxAmount + "','" + _tCore.TaxableAmountGreaterThan + "','" + _tCore.TaxableAmountGreaterThanOf
            + "','" + _tCore.RemoteLocation + "','" + _tCore.GroupB + "','" + _tCore.GroupC + "','" + _tCore.GroupD
            + "','" + _tCore.GroupE
            + "','" + _tCore.MedicalTaxPcnt
            + "','" + _tCore.MedicalTaxLimit
            + "','" + "I" + "'".ToString());

            ExecuteUpdateProcedure(sSql);
        }

        public override void Update(object obj)
        {
            TaxRuleCore _tCore = (TaxRuleCore)obj;
            String sSql = ("exec procManageTaxRulesSetup '" + _tCore.TaxRuleID + "',"
            + "'" + _tCore.FyID + "','" + _tCore.MarriedAmount1 + "','" + _tCore.MarriedTaxRate1 + "',"
            + "'" + _tCore.UnMarriedAmount1 + "','" + _tCore.UnMarriedTaxRate1 + "','" + _tCore.MarriedAmount2 + "',"
            + "'" + _tCore.MarriedTaxRate2 + "',"
            + "'" + _tCore.UnMarriedAmount2 + "','" + _tCore.UnMarriedTaxRate2 + "','" + _tCore.MarriedAmount3 + "',"
            + "'" + _tCore.MarriedTaxRate3 + "','" + _tCore.UnMarriedAmount3 + "','" + _tCore.UnMarriedTaxRate3 + "',"
            + "'" + _tCore.NonResidentialTaxRate + "','" + _tCore.NonResidentialTaxRateOf + "',"
            + "'" + _tCore.VehicleRate + "','" + _tCore.VehicleRateOf + "','" + _tCore.HouseRate + "',"
            + "'" + _tCore.HouseRateOf + "','" + _tCore.DiscountRate + "','" + _tCore.DiscountRateOf + "',"
            + "'" + _tCore.PensionRate + "','" + _tCore.PensionRateOf + "','" + _tCore.PensionCompAmount + "',"
            + "'" + _tCore.PensionHigherLower + "','" + _tCore.PensionCompareFlg + "','" + _tCore.DisableRate + "',"
            + "'" + _tCore.DisableRateOf + "','" + _tCore.DisableCompAmount + "','" + _tCore.DisableHigherLover + "',"
            + "'" + _tCore.DisableCompareFlg + "','" + _tCore.DonationRate + "','" + _tCore.DonationRateOf + "',"
            + "'" + _tCore.DonationCompAmount + "','" + _tCore.DonationHigherLower + "','" + _tCore.DonationCompareFlg + "',"
            + "'" + _tCore.InsuranceRate + "','" + _tCore.InsuranceRateOf + "','" + _tCore.InsuranceCompAmount + "',"
            + "'" + _tCore.InsuranceHigherLower + "','" + _tCore.InsuranceCompareFlg + "','" + _tCore.Fraction + "',"
            + "'" + _tCore.FractionOf + "','" + _tCore.ContributionCompAmount + "','" + _tCore.ContributionHigherLower + "',"
            + "'" + _tCore.ContributionActualCompFlg + "','" + _tCore.ModifiedEmpID + "','" + _tCore.ModifyDate 
            + "','" + _tCore.TxtAdditionalTaxAmount + "','" + _tCore.TaxableAmountGreaterThan + "','" + _tCore.TaxableAmountGreaterThanOf
            + "','" + _tCore.RemoteLocation + "','" + _tCore.GroupB + "','" + _tCore.GroupC + "','" + _tCore.GroupD
            + "','" + _tCore.GroupE + "','" + _tCore.MedicalTaxPcnt
            + "','" + _tCore.MedicalTaxLimit
            + "','" + "U" + "'".ToString());

            ExecuteUpdateProcedure(sSql);
        }
    }
}
