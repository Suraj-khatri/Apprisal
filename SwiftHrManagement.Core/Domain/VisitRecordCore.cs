using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class VisitRecordCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String employeeId;

        public String EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
       
        private DateTime dateFrom;

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }

        private DateTime dateTo;

        public DateTime DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
        }

        private String visitType;

        public String VisitType
        {
            get { return visitType; }
            set { visitType = value; }
        }

        private String country;

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        private String city;

        public String City
        {
            get { return city; }
            set { city = value; }
        }
        
        private String place;

        public String Place
        {
            get { return place; }
            set { place = value; }
        }

        private String reason;

        public String Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}
