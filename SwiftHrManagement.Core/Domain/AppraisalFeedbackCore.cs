using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AppraisalFeedbackCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long appraisalid;

        public long AppraisalId
        {
            get { return appraisalid; }
            set { appraisalid = value; }
        }

        private string feedbackDetails;

        public string FeedbackDetails
        {
            get { return feedbackDetails; }
            set { feedbackDetails = value; }
        }
        
    }
}
