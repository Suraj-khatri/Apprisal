using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class JobApplicantCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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
        private string t_street;

        public string T_street
        {
            get { return t_street; }
            set { t_street = value; }
        }
        private string p_street;

        public string P_street
        {
            get { return p_street; }
            set { p_street = value; }
        }
        private string t_city;

        public string T_city
        {
            get { return t_city; }
            set { t_city = value; }
        }
        private string p_city;

        public string P_city
        {
            get { return p_city; }
            set { p_city = value; }
        }
        private string postal_zip;

        public string Postal_zip
        {
            get { return postal_zip; }
            set { postal_zip = value; }
        }
        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private double expected_sal;

        public double Expected_sal
        {
            get { return expected_sal; }
            set { expected_sal = value; }
        }
        private bool curr_employed;

        public bool Curr_employed
        {
            get { return curr_employed; }
            set { curr_employed = value; }
        }
        private string curr_education;

        public string Curr_education
        {
            get { return curr_education; }
            set { curr_education = value; }
        }
        private string notes;

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
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
        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
