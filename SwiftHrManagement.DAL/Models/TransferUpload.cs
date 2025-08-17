using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.Models
{
    public class TransferUpload
    {
        public string EMP_Code { get; set; }
        public string EFFECTIVE_DATE { get; set; }
        public string ACTUAL_REPORT_DATE { get; set; }
        public string FROM_DEPARTMENT { get; set; }
        public string FROM_BRANCH { get; set; }
        public string FROM_POSITION { get; set; }
        public string TO_BRANCH { get; set; }
        public string TO_DEPARTMENT { get; set; }
        public string TO_POSITION { get; set; }     
        public string TRANSFER_DESCRIPTION { get; set; }
        public string REPORTING_SUPERVISOR { get; set; }      
        public string IsPosted { get; set; }
        public string Error { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string BatchId { get; set; }
    }
}
