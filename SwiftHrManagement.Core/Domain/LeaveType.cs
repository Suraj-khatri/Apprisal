using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class LeaveType : BaseDomain
    {
        private long id;
    

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String name_Of_Leave;

        public String Name_Of_Leave
        {
            get { return name_Of_Leave; }
            set { name_Of_Leave = value; }
        }
        private String leave_Details;

        public String Leave_Details
        {
            get { return leave_Details; }
            set { leave_Details = value; }
        }
        private long no_Of_Days_Default;

        public long No_Of_Days_Default
        {
            get { return no_Of_Days_Default; }
            set { no_Of_Days_Default = value; }
        }
        private String from_Date;

        public String From_Date
        {
            get { return from_Date; }
            set { from_Date = value; }
        }
        private String to_Date;

        public String To_Date
        {
            get { return to_Date; }
            set { to_Date = value; }
        }
        private String occurance;

        public String Occurance
        {
            get { return occurance; }
            set { occurance = value; }
        }
        private long max_Accumulation;

        public long Max_Accumulation
        {
            get { return max_Accumulation; }
            set { max_Accumulation = value; }
        }
        private String nature;

        public String Nature
        {
            get { return nature; }
            set { nature = value; }
        }
        private String isActive;

        public String IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        private string cashable;

        public string Cashable
        {
            get { return cashable; }
            set { cashable = value; }
        }
        private string unlimited;

        public string Unlimited
        {
            get { return unlimited; }
            set { unlimited = value; }
        }
        private String hourly;

        public String Hourly
        {
            get { return hourly; }
            set { hourly = value; }
        }
        private String workingHour;

        public String WorkingHour
        {
            get { return workingHour; }
            set { workingHour = value; }
        }
        private string lFADays;

        public string LFADays
        {
            get { return lFADays; }
            set { lFADays = value; }
        }
        private long defaultdays;

        public long Defaultdays
        {
            get { return defaultdays; }
            set { defaultdays = value; }
        }

        public string IsSubstituted
        {
            get { return isSubstituted; }
            set { isSubstituted = value; }
        }

        private string isSubstituted;
        
    }
}
