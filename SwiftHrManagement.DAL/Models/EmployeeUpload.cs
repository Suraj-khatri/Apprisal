using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.DAL.Models
{
    public class EmployeeUpload
    {
        public string Emp_Code { get; set; }
        public string Salution { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string MERITAL_STATUS { get; set; }
        public string BRANCH_NAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string POSITION { get; set; }
        public string PhoneNumber { get; set; }
        public string DATE_OF_APPIONTMENT { get; set; }
        public string DATE_OF_JOINING { get; set; }
        public string EMPLOYEE_STATUS { get; set; }
        public string EMPLOYEE_TYPE { get; set; }
        public string LASTTRANSFER { get; set; }
        public string LASTPROMOTED { get; set; }
        public string OFFICE_EMAIL { get; set; }
    }
}