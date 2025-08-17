using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class WFCategoryCore : BaseDomain
    {
        private long wFCategoryID;

        public long WFCategoryID
        {
            get { return wFCategoryID; }
            set { wFCategoryID = value; }
        }

        private string wFCatName;

        public string WFCatName
        {
            get { return wFCatName; }
            set { wFCatName = value; }
        }
        private string wFCatDetails;

        public string WFCatDetails
        {
            get { return wFCatDetails; }
            set { wFCatDetails = value; }
        }
        private string wFDept;

        public string WFDept
        {
            get { return wFDept; }
            set { wFDept = value; }
        }
    }
}
