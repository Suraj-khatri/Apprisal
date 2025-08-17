using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ContributionMadeCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String contributionId;

        public String ContributionId
        {
            get { return contributionId; }
            set { contributionId = value; }
        }

        private String contributor;

        public String Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }

        private Double contributionAmount;

        public Double ContributionAmount
        {
            get { return contributionAmount; }
            set { contributionAmount = value; }
        }

        private DateTime contributionDate;

        public DateTime ContributionDate
        {
            get { return contributionDate; }
            set { contributionDate = value; }
        }

        private String receiptNumber;

        public String ReceiptNumber
        {
            get { return receiptNumber; }
            set { receiptNumber = value; }
        }
        private String contributionCode;

        public String ContributionCode
        {
            get { return contributionCode; }
            set { contributionCode = value; }
        }
    }
}