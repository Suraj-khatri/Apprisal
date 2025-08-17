using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TrainingFeedbackCore:BaseDomain
    {
        private long id;
     
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string trainingProgramId;

        public string TrainingProgramId
        {
            get { return trainingProgramId; }
            set { trainingProgramId = value; }
        }
        private string feedback;

        public string Feedback
        {
            get { return feedback; }
            set { feedback = value; }
        }

        private string feedbackDate;

        public string FeedbackDate
        {
            get { return feedbackDate; }
            set { feedbackDate = value; }
        }
    }
}
