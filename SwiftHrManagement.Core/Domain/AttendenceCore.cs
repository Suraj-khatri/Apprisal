using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AttendenceCore : BaseDomain
    {
        private long attendenceid;

        public long Attendenceid
        {
            get { return attendenceid; }
            set { attendenceid = value; }
        }

        private string employeeid;

        public string Employeeid
        {
            get { return employeeid; }
            set { employeeid = value; }
        }

        private string attdate;

        public string Attdate
        {
            get { return attdate; }
            set { attdate = value; }
        }



        private string atttimeout;

        public string Atttimeout
        {
            get { return atttimeout; }
            set { atttimeout = value; }
        }

        private string attremarks;

        public string Attremarks
        {
            get { return attremarks; }
            set { attremarks = value; }
        }

        private string intime;

        public string Intime
        {
            get { return intime; }
            set { intime = value; }
        }

        private string outtime;

        public string Outtime
        {
            get { return outtime; }
            set { outtime = value; }
        }
    }
}
