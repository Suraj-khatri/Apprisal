using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class DepartmentEventsCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long departmentId;

        public long DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private String time;

        public String Time
        {
            get { return time; }
            set { time = value; }
        }

        private String location;

        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        private String details;

        public String Details
        {
            get { return details; }
            set { details = value; }
        }
    }
}
