using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class PastExperiencesCore : BaseDomain
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
        private String organization;

        public String Organization
        {
            get { return organization; }
            set { organization = value; }
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

        private String position;

        public String Position
        {
            get { return position; }
            set { position = value; }
        }

        private String contractType;

        public String ContractType
        {
            get { return contractType; }
            set { contractType = value; }
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

        private String location;

        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        private String phoneNumber;

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private String emailAddress;

        public String EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private String contactPerson;

        public String ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }

        private String mobileContactPerson;

        public String MobileContactPerson
        {
            get { return mobileContactPerson; }
            set { mobileContactPerson = value; }
        }
        
     }
}
