using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class UpdateTaskCore : BaseDomain
    {
        private long uPDT_TASK_ID;

        public long UPDT_TASK_ID
        {
            get { return uPDT_TASK_ID; }
            set { uPDT_TASK_ID = value; }
        }
        private String posted_By;

        public String Posted_By
        {
            get { return posted_By; }
            set { posted_By = value; }
        }
        private String active_Task;

        public String Active_Task
        {
            get { return active_Task; }
            set { active_Task = value; }
        }
        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        private String is_Complete;

        public String Is_Complete
        {
            get { return is_Complete; }
            set { is_Complete = value; }
        }
        private String complete_PCT;

        public String Complete_PCT
        {
            get { return complete_PCT; }
            set { complete_PCT = value; }
        }
    }
}
