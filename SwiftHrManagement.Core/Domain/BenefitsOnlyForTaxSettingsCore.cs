using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class BenefitsOnlyForTaxSettingsCore : BaseDomain
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

        private String benefitForTaxId;

        public String BenefitForTaxId
        {
            get { return benefitForTaxId; }
            set { benefitForTaxId = value; }
        }

        private Double amount;

        public Double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
