using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class BenefitsCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String benefitName;

        public String BenefitName
        {
            get { return benefitName; }
            set { benefitName = value; }
        }

        private String occurrence;

        public String Occurrence
        {
            get { return occurrence; }
            set { occurrence = value; }
        }

        private String details;

        public String Details
        {
            get { return details; }
            set { details = value; }
        }

        private String glCode;

        public String GlCode
        {
            get { return glCode; }
            set { glCode = value; }
        }

        private string benefitGroup;

        public string BenefitGroup
        {
            get { return benefitGroup; }
            set { benefitGroup = value; }
        }
     
    }
}
