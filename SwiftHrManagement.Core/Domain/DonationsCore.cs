using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class DonationsCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String employeeId;

        public String EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private Double donationAmount;

        public Double DonationAmount
        {
            get { return donationAmount; }
            set { donationAmount = value; }
        }

        private string donationDate;

        public string DonationDate
        {
            get { return donationDate; }
            set { donationDate = value; }
        }

        private string sdonationDate;

        public string sDonationDate
        {
            get { return sdonationDate; }
            set { sdonationDate = value; }
        }

        private String detailedDescription;

        public String DetailedDescription
        {
            get { return detailedDescription; }
            set { detailedDescription = value; }
        }

        private string governmentApprovedDeduction;

        public string GovernmentApprovedDeduction
        {
            get { return governmentApprovedDeduction; }
            set { governmentApprovedDeduction = value; }
        }
        //private bool isTaxFree;

        //public bool IsTaxFree
        //{
        //    get { return isTaxFree; }
        //    set { isTaxFree = value; }
        //}


    }
}
