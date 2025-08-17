using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class PayableCore : BaseDomain
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

        private String benefitId;

        public String BenefitId
        {
            get { return benefitId; }
            set { benefitId = value; }
        }

        private Double amount;

        public Double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string BenefitType
        {
            get { return benefitType; }
            set { benefitType = value; }
        }

        private string benefitType;

        private string effectiveDate;
        public string EffectiveDate
        {
          get { return effectiveDate; }
          set { effectiveDate = value; }
        }

        private string appliedDate;

        public string AppliedDate
        {
            get { return appliedDate; }
            set { appliedDate = value; }
        }
        private string effectiveUpto;

        public string EffectiveUpto
        {
            get { return effectiveUpto; }
            set { effectiveUpto = value; }
        }
    }
}
