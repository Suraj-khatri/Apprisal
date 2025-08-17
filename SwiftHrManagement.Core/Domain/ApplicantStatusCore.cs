using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ApplicantStatusCore : BaseDomain
    {
        private long appstat_ID;

        public long Appstat_ID
        {
            get { return appstat_ID; }
            set { appstat_ID = value; }
        }
        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private String action;

        public String Action
        {
            get { return action; }
            set { action = value; }
        }
        private String scheduled_Date;

        public String Scheduled_Date
        {
            get { return scheduled_Date; }
            set { scheduled_Date = value; }
        }
    }
}
