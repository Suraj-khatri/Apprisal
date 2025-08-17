using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ProfileparameterCore
    {
        private long rowid;

        public long Rowid
        {
            get { return rowid; }
            set { rowid = value; }
        }
        private string prf_user;

        public string Prf_user
        {
            get { return prf_user; }
            set { prf_user = value; }
        }
        private string prf_name;

        public string Prf_name
        {
            get { return prf_name; }
            set { prf_name = value; }
        }
        private int prf_value;

        public int Prf_value
        {
            get { return prf_value; }
            set { prf_value = value; }
        }
        private string profile_code;

        public string Profile_code
        {
            get { return profile_code; }
            set { profile_code = value; }
        }
    }
}
