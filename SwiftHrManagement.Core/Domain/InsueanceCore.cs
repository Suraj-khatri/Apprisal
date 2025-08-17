using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class InsueanceCore : BaseDomain
    {
        private long insurance_Id;

        public long Insurance_Id
        {
            get { return insurance_Id; }
            set { insurance_Id = value; }
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String employee_Id;

        public String Employee_Id
        {
            get { return employee_Id; }
            set { employee_Id = value; }
        }
        private String insurer;

        public String Insurer
        {
            get { return insurer; }
            set { insurer = value; }
        }
        
        private Double insured_Amount;

        public Double Insured_Amount
        {
            get { return insured_Amount; }
            set { insured_Amount = value; }
        }
        private String insured_Date;

        public String Insured_Date
        {
            get { return insured_Date; }
            set { insured_Date = value; }
        }
        private String expiry_Date;

        public String Expiry_Date
        {
            get { return expiry_Date; }
            set { expiry_Date = value; }
        }
        private String emp_Name;

        public String Emp_Name
        {
            get { return emp_Name; }
            set { emp_Name = value; }
        }
        private String premiumPayer;

        public String PremiumPayer
        {
            get { return premiumPayer; }
            set { premiumPayer = value; }
        }

        private string insurancePolicy;

        public string InsurancePolicy
        {
            get { return insurancePolicy; }
            set { insurancePolicy = value; }
        }

        private string annualPremiumAmt;

        public string AnnualPremiumAmt
        {
            get { return annualPremiumAmt; }
            set { annualPremiumAmt = value; }
        }
        private string pay_frequency;

        public string Pay_Frequency
        {
            get { return pay_frequency; }
            set { pay_frequency = value; }
        }
        private string salary_deduction;

        public string Salary_Deduction
        {
            get { return salary_deduction; }
            set { salary_deduction = value; }
        }
        private string insurance_For;

        public string Insurance_For
        {
            get { return insurance_For; }
            set { insurance_For = value; }
        }

    }
}
