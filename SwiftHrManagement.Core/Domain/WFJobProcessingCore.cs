using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class WFJobProcessingCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long jobId;

        public long JobId
        {
            get { return jobId; }
            set { jobId = value; }
        }
        private long actionEmpId;

        public long ActionEmpId
        {
            get { return actionEmpId; }
            set { actionEmpId = value; }
        }
      
        private long forwartTo;

        public long ForwartTo
        {
            get { return forwartTo; }
            set { forwartTo = value; }
        }
        private string comments;

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private string jobStatus;

        public string JobStatus
        {
            get { return jobStatus; }
            set { jobStatus = value; }
        }

        private string actDate;

        public string ActDate
        {
            get { return actDate; }
            set { actDate = value; }
        }

        private string senderName;

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        private string jobMode;

        public string JobMode
        {
            get { return jobMode; }
            set { jobMode = value; }
        }

        private string strflag;

        public string strFlag
        {
            get { return strflag; }
            set { strflag = value; }
        }
    


    }
}
