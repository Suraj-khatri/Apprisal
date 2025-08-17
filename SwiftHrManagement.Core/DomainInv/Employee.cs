using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class Employee :BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string empCode;

        public string EmpCode
        {
            get { return empCode; }
            set { empCode = value; }
        }    
        private string fname;

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        private string mname;

        public string Mname
        {
            get { return mname; }
            set { mname = value; }
        }

        private string lname;

        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        private string tempadd;

        public string Tempadd
        {
            get { return tempadd; }
            set { tempadd = value; }
        }

        private string permadd;

        public string Permadd
        {
            get { return permadd; }
            set { permadd = value; }
        }

        private string phoneoffice;

        public string Phoneoffice
        {
            get { return phoneoffice; }
            set { phoneoffice = value; }
        }

        private string phoneres;

        public string Phoneres
        {
            get { return phoneres; }
            set { phoneres = value; }
        }

        private string moboffice;

        public string Moboffice
        {
            get { return moboffice; }
            set { moboffice = value; }
        }

        private string mobpersonal;

        public string Mobpersonal
        {
            get { return mobpersonal; }
            set { mobpersonal = value; }
        }

        private string faxoffice;

        public string Faxoffice
        {
            get { return faxoffice; }
            set { faxoffice = value; }
        }

        private string faxpersonal;

        public string Faxpersonal
        {
            get { return faxpersonal; }
            set { faxpersonal = value; }
        }

        private string emailoffice;

        public string Emailoffice
        {
            get { return emailoffice; }
            set { emailoffice = value; }
        }

        private string emailperonal;

        public string Emailperonal
        {
            get { return emailperonal; }
            set { emailperonal = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string department_id;

        public string Department_id
        {
            get { return department_id; }
            set { department_id = value; }
        }

        private string position_id;

        public string Position_id
        {
            get { return position_id; }
            set { position_id = value; }
        }
        private string bloodgoup;

        public string Bloodgoup
        {
            get { return bloodgoup; }
            set { bloodgoup = value; }
        }
        private string nationality;

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        
        private string dateofbirth;

        public string Dateofbirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

        private string dateofjoining;

        public string Dateofjoining
        {
            get { return dateofjoining; }
            set { dateofjoining = value; }
        }

        private string meritalstatus;

        public string Meritalstatus
        {
            get { return meritalstatus; }
            set { meritalstatus = value; }
        }
        
        private string pannumber;

        public string Pannumber
        {
            get { return pannumber; }
            set { pannumber = value; }
        }
        private String empName;

        public String EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        private string branch_id;

        public string Branch_id
        {
            get { return branch_id; }
            set { branch_id = value; }
        }
        private string temp_district;

        public string Temp_district
        {
            get { return temp_district; }
            set { temp_district = value; }
        }
        private string temp_zone;

        public string Temp_zone
        {
            get { return temp_zone; }
            set { temp_zone = value; }
        }
        private string temp_country;

        public string Temp_country
        {
            get { return temp_country; }
            set { temp_country = value; }
        }
        private string temp_muni_vdc;

        public string Temp_muni_vdc
        {
            get { return temp_muni_vdc; }
            set { temp_muni_vdc = value; }
        }
        private string temp_wardno;

        public string Temp_wardno
        {
            get { return temp_wardno; }
            set { temp_wardno = value; }
        }
        private string temp_houseno;

        public string Temp_houseno
        {
            get { return temp_houseno; }
            set { temp_houseno = value; }
        }
        private string temp_streetname;

        public string Temp_streetname
        {
            get { return temp_streetname; }
            set { temp_streetname = value; }
        }
        private string per_district;

        public string Per_district
        {
            get { return per_district; }
            set { per_district = value; }
        }
        private string per_zone;

        public string Per_zone
        {
            get { return per_zone; }
            set { per_zone = value; }
        }
        private string per_country;

        public string Per_country
        {
            get { return per_country; }
            set { per_country = value; }
        }
        private string per_muni_vdc;

        public string Per_muni_vdc
        {
            get { return per_muni_vdc; }
            set { per_muni_vdc = value; }
        }
        private string per_wardno;

        public string Per_wardno
        {
            get { return per_wardno; }
            set { per_wardno = value; }
        }
        private string per_houseno;

        public string Per_houseno
        {
          get { return per_houseno; }
          set { per_houseno = value; }
        }
        private string per_streetname;

        public string Per_streetname
        {
            get { return per_streetname; }
            set { per_streetname = value; }
        }
        private string salute;

        public string Salute
        {
            get { return salute; }
            set { salute = value; }
        }
        private string isVehicleFacility;

        public string IsVehicleFacility
        {
            get { return isVehicleFacility; }
            set { isVehicleFacility = value; }
        }
        private string isHouseFacility;

        public string IsHouseFacility
        {
            get { return isHouseFacility; }
            set { isHouseFacility = value; }
        }
        private string isDisabled;

        public string IsDisabled
        {
            get { return isDisabled; }
            set { isDisabled = value; }
        }
        private string isPensionHolder;

        public string IsPensionHolder
        {
            get { return isPensionHolder; }
            set { isPensionHolder = value; }
        }
        private string pensionAmount;

        public string PensionAmount
        {
            get { return pensionAmount; }
            set { pensionAmount = value; }
        }
        private string disabledId;

        public string DisabledId
        {
            get { return disabledId; }
            set { disabledId = value; }
        }
    }
}
