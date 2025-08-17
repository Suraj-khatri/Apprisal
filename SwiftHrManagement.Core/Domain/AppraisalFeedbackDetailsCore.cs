using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AppraisalFeedbackDetailsCore
    {
        public int Id { get; set; }
        public int AppraisalId { get; set; }
        public string EmployeeName { get; set; }
        public string AppraisalTitle { get; set; }
        public string FeedbackDetails { get; set; }
        public string FeedbackDate { get; set; }
        public string CreatedBy { get; set; }      
    }
}
