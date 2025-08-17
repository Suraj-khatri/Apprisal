using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class ContributionCore : BaseDomain
    {
        private long contributionId;

        public long ContributionId
        {
            get { return contributionId; }
            set { contributionId = value; }
        }
        private string value_employee;

        public string Value_employee
        {
            get { return value_employee; }
            set { value_employee = value; }
        }
        private string flag_employee;

        public string Flag_employee
        {
            get { return flag_employee; }
            set { flag_employee = value; }
        }
       private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string employeeID;

        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        
       private string contributionCode;

        public string ContributionCode
        {
            get { return contributionCode; }
            set { contributionCode = value; }
        }
        
       private string contributedTo;

        public string ContributedTo
        {
            get { return contributedTo; }
            set { contributedTo = value; }
        }
        private string value_employer;

        public string Value_employer
        {
            get { return value_employer; }
            set { value_employer = value; }
        }

// FOR EMPLOYEE //

       private Double contributionRateEmployee;

        public Double ContributionRateEmployee
        {
            get { return contributionRateEmployee; }
            set { contributionRateEmployee = value; }
        }
        private string contributionBasisEmployee;

        public string ContributionBasisEmployee
        {
            get { return contributionBasisEmployee; }
            set { contributionBasisEmployee = value; }
        }

        private Double contributionAmountEmployee;

        public Double ContributionAmountEmployee
        {
            get { return contributionAmountEmployee; }
            set { contributionAmountEmployee = value; }
        }

        private String contributionFromDateEmployee;

        public String ContributionFromDateEmployee
        {
            get { return contributionFromDateEmployee; }
            set { contributionFromDateEmployee = value; }
        }

        private int contributionFrequencyEmployee;

        public int ContributionFrequencyEmployee
        {
            get { return contributionFrequencyEmployee; }
            set { contributionFrequencyEmployee = value; }
        }
       
//FOR EMPLOYER //
       
       private Double contributionRateEmployer;

        public Double ContributionRateEmployer
        {
            get { return contributionRateEmployer; }
            set { contributionRateEmployer = value; }
        }
        private string contributionBasisEmployer;

        public string ContributionBasisEmployer
        {
            get { return contributionBasisEmployer; }
            set { contributionBasisEmployer = value; }
        }

        private Double contributionAmountEmployer;

        public Double ContributionAmountEmployer
        {
            get { return contributionAmountEmployer; }
            set { contributionAmountEmployer = value; }
        }

        private String contributionFromDateEmployer;

        public String ContributionFromDateEmployer
        {
            get { return contributionFromDateEmployer; }
            set { contributionFromDateEmployer = value; }
        }

        private int contributionFrequencyEmployer;

        public int ContributionFrequencyEmployer
        {
            get { return contributionFrequencyEmployer; }
            set { contributionFrequencyEmployer = value; }
        }
        private string contb_basis_emplr;

        public string Contb_basis_emplr
        {
            get { return contb_basis_emplr; }
            set { contb_basis_emplr = value; }
        }
        private string contbemplr_amt_pct;

        public string Contbemplr_amt_pct
        {
            get { return contbemplr_amt_pct; }
            set { contbemplr_amt_pct = value; }
        }
        private string flag_employer;

        public string Flag_employer
        {
            get { return flag_employer; }
            set { flag_employer = value; }
        }
    }
}