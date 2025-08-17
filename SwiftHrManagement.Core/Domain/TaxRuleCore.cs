using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TaxRuleCore : BaseDomain
    {

        private int taxRuleID;

        public int TaxRuleID
        {
            get { return taxRuleID; }
            set { taxRuleID = value; }
        }

        private string fyID;

        public string FyID
        {
            get { return fyID; }
            set { fyID = value; }
        }

        private double marriedAmount1;

        public double MarriedAmount1
        {
            get { return marriedAmount1; }
            set { marriedAmount1 = value; }
        }
        private float marriedTaxRate1;

        public float MarriedTaxRate1
        {
            get { return marriedTaxRate1; }
            set { marriedTaxRate1 = value; }
        }
        private double unMarriedAmount1;

        public double UnMarriedAmount1
        {
            get { return unMarriedAmount1; }
            set { unMarriedAmount1 = value; }
        }
        private double unMarriedTaxRate1;

        public double UnMarriedTaxRate1
        {
            get { return unMarriedTaxRate1; }
            set { unMarriedTaxRate1 = value; }
        }
        private double marriedAmount2;

        public double MarriedAmount2
        {
            get { return marriedAmount2; }
            set { marriedAmount2 = value; }
        }
        private double marriedTaxRate2;

        public double MarriedTaxRate2
        {
            get { return marriedTaxRate2; }
            set { marriedTaxRate2 = value; }
        }
        private double unMarriedAmount2;

        public double UnMarriedAmount2
        {
            get { return unMarriedAmount2; }
            set { unMarriedAmount2 = value; }
        }
        private double unMarriedTaxRate2;

        public double UnMarriedTaxRate2
        {
            get { return unMarriedTaxRate2; }
            set { unMarriedTaxRate2 = value; }
        }
        private string marriedAmount3;

        public string MarriedAmount3
        {
            get { return marriedAmount3; }
            set { marriedAmount3 = value; }
        }
        private double marriedTaxRate3;

        public double MarriedTaxRate3
        {
            get { return marriedTaxRate3; }
            set { marriedTaxRate3 = value; }
        }
        private string unMariedAmount3;

        public string UnMarriedAmount3
        {
            get { return unMariedAmount3; }
            set { unMariedAmount3 = value; }
        }
        private double unMarriedTaxRate3;

        public double UnMarriedTaxRate3
        {
            get { return unMarriedTaxRate3; }
            set { unMarriedTaxRate3 = value; }
        }
        private double nonResidentialTaxRate;

        public double NonResidentialTaxRate
        {
            get { return nonResidentialTaxRate; }
            set { nonResidentialTaxRate = value; }
        }
        private string nonResidentialTaxRateOf;

        public string NonResidentialTaxRateOf
        {
            get { return nonResidentialTaxRateOf; }
            set { nonResidentialTaxRateOf = value; }
        }
        private double vehicleRate;

        public double VehicleRate
        {
            get { return vehicleRate; }
            set { vehicleRate = value; }
        }
        private string vehicleRateOf;

        public string VehicleRateOf
        {
            get { return vehicleRateOf; }
            set { vehicleRateOf = value; }
        }
        private double houseRate;

        public double HouseRate
        {
            get { return houseRate; }
            set { houseRate = value; }
        }
        private string houseRateOf;

        public string HouseRateOf
        {
            get { return houseRateOf; }
            set { houseRateOf = value; }
        }
        private double discountRate;

        public double DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }
        private string discountRateOf;

        public string DiscountRateOf
        {
            get { return discountRateOf; }
            set { discountRateOf = value; }
        }
        private double pensionRate;

        public double PensionRate
        {
            get { return pensionRate; }
            set { pensionRate = value; }
        }
        private string pensionRateOf;

        public string PensionRateOf
        {
            get { return pensionRateOf; }
            set { pensionRateOf = value; }
        }
        private double pensionCompAmount;

        public double PensionCompAmount
        {
            get { return pensionCompAmount; }
            set { pensionCompAmount = value; }
        }
        private string pensionHigherLower;

        public string PensionHigherLower
        {
            get { return pensionHigherLower; }
            set { pensionHigherLower = value; }
        }
        private string pensionCompareFlg;

        public string PensionCompareFlg
        {
            get { return pensionCompareFlg; }
            set { pensionCompareFlg = value; }
        }
        private double disableRate;

        public double DisableRate
        {
            get { return disableRate; }
            set { disableRate = value; }
        }
        private string disableRateOf;

        public string DisableRateOf
        {
            get { return disableRateOf; }
            set { disableRateOf = value; }
        }
        private double disableCompAmount;

        public double DisableCompAmount
        {
            get { return disableCompAmount; }
            set { disableCompAmount = value; }
        }
        private string disableHigherLover;

        public string DisableHigherLover
        {
            get { return disableHigherLover; }
            set { disableHigherLover = value; }
        }
        private string disableCompareFlg;

        public string DisableCompareFlg
        {
            get { return disableCompareFlg; }
            set { disableCompareFlg = value; }
        }
        private double donationRate;

        public double DonationRate
        {
            get { return donationRate; }
            set { donationRate = value; }
        }
        private string donationRateOf;

        public string DonationRateOf
        {
            get { return donationRateOf; }
            set { donationRateOf = value; }
        }
        private double donationCompAmount;

        public double DonationCompAmount
        {
            get { return donationCompAmount; }
            set { donationCompAmount = value; }
        }
        private string donationHigherLower;

        public string DonationHigherLower
        {
            get { return donationHigherLower; }
            set { donationHigherLower = value; }
        }
        private string donationCompareFlg;

        public string DonationCompareFlg
        {
            get { return donationCompareFlg; }
            set { donationCompareFlg = value; }
        }
        private double insuranceRate;

        public double InsuranceRate
        {
            get { return insuranceRate; }
            set { insuranceRate = value; }
        }
        private string insuranceRateOf;

        public string InsuranceRateOf
        {
            get { return insuranceRateOf; }
            set { insuranceRateOf = value; }
        }
        private double insuranceCompAmount;

        public double InsuranceCompAmount
        {
            get { return insuranceCompAmount; }
            set { insuranceCompAmount = value; }
        }
        private string insuranceHigherLower;

        public string InsuranceHigherLower
        {
            get { return insuranceHigherLower; }
            set { insuranceHigherLower = value; }
        }
        private string insuranceCompareFlg;

        public string InsuranceCompareFlg
        {
            get { return insuranceCompareFlg; }
            set { insuranceCompareFlg = value; }
        }
        private string fraction;

        public string Fraction
        {
            get { return fraction; }
            set { fraction = value; }
        }
        private string fractionOf;

        public string FractionOf
        {
            get { return fractionOf; }
            set { fractionOf = value; }
        }
        private double contributionCompAmount;

        public double ContributionCompAmount
        {
            get { return contributionCompAmount; }
            set { contributionCompAmount = value; }
        }
        private string contributionHigherLower;

        public string ContributionHigherLower
        {
            get { return contributionHigherLower; }
            set { contributionHigherLower = value; }
        }
        private string contributionActualCompFlg;

        public string ContributionActualCompFlg
        {
            get { return contributionActualCompFlg; }
            set { contributionActualCompFlg = value; }
        }

        private long createdEmpID;

        public long CreatedEmpID
        {
            get { return createdEmpID; }
            set { createdEmpID = value; }
        }
        private long modifiedEmpID;

        public long ModifiedEmpID
        {
            get { return modifiedEmpID; }
            set { modifiedEmpID = value; }
        }

        private double txtAdditionalTaxAmount;

        public double TxtAdditionalTaxAmount
        {
            get { return txtAdditionalTaxAmount; }
            set { txtAdditionalTaxAmount = value; }
        }

        private double taxableAmountGreaterThan;

        public double TaxableAmountGreaterThan
        {
            get { return taxableAmountGreaterThan; }
            set { taxableAmountGreaterThan = value; }
        }

        private string taxableAmountGreaterThanOf;

        public string TaxableAmountGreaterThanOf
        {
            get { return taxableAmountGreaterThanOf; }
            set { taxableAmountGreaterThanOf = value; }
        }

        private string remoteLocation;

        public string RemoteLocation
        {
            get { return remoteLocation; }
            set { remoteLocation = value; }
        }
        private string groupB;

        public string GroupB
        {
            get { return groupB; }
            set { groupB = value; }
        }
        private string groupC;

        public string GroupC
        {
            get { return groupC; }
            set { groupC = value; }
        }
        private string groupD;

        public string GroupD
        {
            get { return groupD; }
            set { groupD = value; }
        }
        private string groupE;

        public string GroupE
        {
            get { return groupE; }
            set { groupE = value; }
        }
        private string medicalTaxPcnt;

        public string MedicalTaxPcnt
        {
            get { return medicalTaxPcnt; }
            set { medicalTaxPcnt = value; }
        }
        private string medicalTaxLimit;

        public string MedicalTaxLimit
        {
            get { return medicalTaxLimit; }
            set { medicalTaxLimit = value; }
        }
    }
}
