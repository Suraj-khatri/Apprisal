using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class InsurancePremiumCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String insuranceId;

        public String InsuranceId
        {
            get { return insuranceId; }
            set { insuranceId = value; }
        }

        private string paymentDate;

        public string PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        private Double paymentAmount;

        public Double PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }

        private string receiptNumber;

        public string ReceiptNumber
        {
            get { return receiptNumber; }
            set { receiptNumber = value; }
        }
        private string insurancePolicy;

        public string InsurancePolicy
        {
            get { return insurancePolicy; }
            set { insurancePolicy = value; }
        }
        private string unpaidAmount;

        public string UnpaidAmount
        {
            get { return unpaidAmount; }
            set { unpaidAmount = value; }
        }
    }
}