using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class EmployeeEducation : BaseDomain
    {
        private long educationid;

        public long Educationid
        {
            get { return educationid; }
            set { educationid = value; }
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string levels;

        public string Levels
        {
            get { return levels; }
            set { levels = value; }
        }

        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private string fecaulty;

        public string Fecaulty
        {
            get { return fecaulty; }
            set { fecaulty = value; }
        }

        private long facultyID;

        public long FacultyID
        {
            get { return facultyID; }
            set { facultyID = value; }
        }

        private string division;

        public string Division
        {
            get { return division; }
            set { division = value; }
        }

        private string percentage;

        public string Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        private string passedyear;

        public string Passedyear
        {
            get { return passedyear; }
            set { passedyear = value; }
        }

        private string nameofintitution;

        public string Nameofintitution
        {
            get { return nameofintitution; }
            set { nameofintitution = value; }
        }

        private string countyname;

        public string Countyname
        {
            get { return countyname; }
            set { countyname = value; }
        }
        private string empId;

        public string EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

    }
}
