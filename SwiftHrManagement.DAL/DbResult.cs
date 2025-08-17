using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SwiftHrManagement.DAL
{
    public class DbResult
    {
        private string _errorCode = "1";
        private string _msg = "Error";
        private string _id = "0";

        public DbResult() { }

        public string ErrorCode
        {
            set { _errorCode = value; }
            get { return _errorCode; }
        }

        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }

    }
}
