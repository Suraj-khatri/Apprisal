using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class FamilyMembersCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long employeeId;

        public long EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private String middleName;

        public String MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private String gender;

        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private String relation;

        public String Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        private String maritalStatus;

        public String MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private String mobileNumber;

        public String MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }

        private String nationalityNumber;

        public String NationalityNumber
        {
            get { return nationalityNumber; }
            set { nationalityNumber = value; }
        }
        private String issueDate;

        public String IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        private String passportNumber;

        public String PassportNumber
        {
            get { return passportNumber; }
            set { passportNumber = value; }
        }

        private String nationality;

        public String Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        private String bloodGroup;

        public String BloodGroup
        {
            get { return bloodGroup; }
            set { bloodGroup = value; }
        }

        private String currentAddress;

        public String CurrentAddress
        {
            get { return currentAddress; }
            set { currentAddress = value; }
        }

        private String employer;

        public String Employer
        {
            get { return employer; }
            set { employer = value; }
        }
        private String employerAddress;

        public String EmployerAddress
        {
            get { return employerAddress; }
            set { employerAddress = value; }
        }

        private String designation;

        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private String officePhone;

        public String OfficePhone
        {
            get { return officePhone; }
            set { officePhone = value; }
        }
        private String officeEmail;

        public String OfficeEmail
        {
            get { return officeEmail; }
            set { officeEmail = value; }
        }

        private String insurer;

        public String Insurer
        {
            get { return insurer; }
            set { insurer = value; }
        }

        private String insurancePolicyNumber;

        public String InsurancePolicyNumber
        {
            get { return insurancePolicyNumber; }
            set { insurancePolicyNumber = value; }
        }

        private string insuranceExpiryDate;

        public string InsuranceExpiryDate
        {
            get { return insuranceExpiryDate; }
            set { insuranceExpiryDate = value; }
        }


        private String studyCenterName;

        public String StudyCenterName
        {
            get { return studyCenterName; }
            set { studyCenterName = value; }
        }

        private String levelOfStudy;

        public String LevelOfStudy
        {
            get { return levelOfStudy; }
            set { levelOfStudy = value; }
        }

        private String nameOfCourse;

        public String NameOfCourse
        {
            get { return nameOfCourse; }
            set { nameOfCourse = value; }
        }

        private String studyCenterPhone;

        public String StudyCenterPhone
        {
            get { return studyCenterPhone; }
            set { studyCenterPhone = value; }
        }

        private String studyCenterEmail;

        public String StudyCenterEmail
        {
            get { return studyCenterEmail; }
            set { studyCenterEmail = value; }
        }

        private String studyCenterAddress;

        public String StudyCenterAddress
        {
            get { return studyCenterAddress; }
            set { studyCenterAddress = value; }
        }
        private string occupation;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string familyMembDoc;
        public string FamilyMembDoc
        {
            get { return familyMembDoc; }
            set { familyMembDoc = value; }
        }
    }
}
