using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class DeductionRuleCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        /*All applicable deduction rates during tax calculation process */
        
        // references dbo.Fiscalyear.year
        private long yearId;

        public long YearId
        {
            get { return yearId; }
            set { yearId = value; }
        }
        //allowed insurance deduction rate
        private double insuranceDeductionRate;

        public double InsuranceDeductionRate
        {
            get { return insuranceDeductionRate; }
            set { insuranceDeductionRate = value; }
        }
        //allowed insurance deductionlimit
        private double insuranceDeductionLimit;

        public double InsuranceDeductionLimit
        {
            get { return insuranceDeductionLimit; }
            set { insuranceDeductionLimit = value; }
        }
        //allowed insurance donation rate
        private double donationDeductionRate;

        public double DonationDeductionRate
        {
            get { return donationDeductionRate; }
            set { donationDeductionRate = value; }
        }
        //allowed insurance donation limit
        private double donationDeductionLimit;

        public double DonationDeductionLimit
        {
            get { return donationDeductionLimit; }
            set { donationDeductionLimit = value; }
        }
        //allowed special tax benefit for women in adjusted income
        private double provisionForWomenRate;

        public double ProvisionForWomenRate
        {
            get { return provisionForWomenRate; }
            set { provisionForWomenRate = value; }
        }

    }
}
