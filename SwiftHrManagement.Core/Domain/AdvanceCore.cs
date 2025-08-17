using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AdvanceCore : BaseDomain
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
        private Double amount;

        public Double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private String date_Taken;

        public String Date_Taken
        {
            get { return date_Taken; }
            set { date_Taken = value; }
        }
        private String emp_Name;

        public String Emp_Name
        {
            get { return emp_Name; }
            set { emp_Name = value; }
        }
        private string advance_type;

        public string Advance_type
        {
            get { return advance_type; }
            set { advance_type = value; }
        }
        private double deduction_amt;

        public double Deduction_amt
        {
            get { return deduction_amt; }
            set { deduction_amt = value; }
        }
        private Boolean isfullypaid;

        public Boolean Isfullypaid
        {
            get { return isfullypaid; }
            set { isfullypaid = value; }
        }

        private string fullypaid;

        public string FullyPaid
        {
            get { return fullypaid; }
            set { fullypaid = value; }
        }

        private string  deduction_start_date;

        public string Deduction_start_date
        {
            get { return deduction_start_date; }
            set { deduction_start_date = value; }
        }
        private double remaining_bal;

        public double Remaining_bal
        {
            get { return remaining_bal; }
            set { remaining_bal = value; }
        }
        private string narration;

        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
        private string deductionFrequency;

        public string DeductionFrequency
        {
            get { return deductionFrequency; }
            set { deductionFrequency = value; }
        }
        private string nextRunMonth;

        public string NextRunMonth
        {
            get { return nextRunMonth; }
            set { nextRunMonth = value; }
        }
        private string ledgerCode;

        public string LedgerCode
        {
            get { return ledgerCode; }
            set { ledgerCode = value; }
        }

       
    }
}
