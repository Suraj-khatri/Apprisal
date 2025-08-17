using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class LoanCore : BaseDomain
    {
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
        private Double loanAmount;

        public Double LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; }
        }
        private string dateTaken;

        public string DateTaken
        {
            get { return dateTaken; }
            set { dateTaken = value; }
        }
        private Double remainingBalance;

        public Double RemainingBalance
        {
            get { return remainingBalance; }
            set { remainingBalance = value; }
        }
        
        private String loanType;

        public String LoanType
        {
            get { return loanType; }
            set { loanType = value; }
        }
        private int noOfInstallment;

        public int NoOfInstallment
        {
            get { return noOfInstallment; }
            set { noOfInstallment = value; }
        }
        private double interestRate;

        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        private string interestCompounded;

        public string InterestCompounded
        {
            get { return interestCompounded; }
            set { interestCompounded = value; }
        }
        private String repaymentFrequency;

        public String RepaymentFrequency
        {
            get { return repaymentFrequency; }
            set { repaymentFrequency = value; }
        }
        private Boolean isCleared;

        public Boolean IsCleared
        {
            get { return isCleared; }
            set { isCleared = value; }
        }
        private Double installmentAmount;

        public Double InstallmentAmount
        {
            get { return installmentAmount; }
            set { installmentAmount = value; }
        }
        private String ledgerCore;

        public String LedgerCode
        {
            get { return ledgerCore; }
            set { ledgerCore = value; }
        }
        private string remainingInstallment;

        public string RemainingInstallment
        {
            get { return remainingInstallment; }
            set { remainingInstallment = value; }
        }
        private string installmentStartDate;

        public string InstallmentStartDate
        {
            get { return installmentStartDate; }
            set { installmentStartDate = value; }
        }
        private string nextRunMonth;

        public string NextRunMonth
        {
            get { return nextRunMonth; }
            set { nextRunMonth = value; }
        }
        private string naration;

        public string Naration
        {
            get { return naration; }
            set { naration = value; }
        }
        private string appliedDate;

        public string AppliedDate
        {
            get { return appliedDate; }
            set { appliedDate = value; }
        }
        private double appliedAmt;

        public double AppliedAmt
        {
            get { return appliedAmt; }
            set { appliedAmt = value; }
        }
        private string interestType;

        public string InterestType
        {
            get { return interestType; }
            set { interestType = value; }
        }
    }
}
