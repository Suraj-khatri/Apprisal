using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class DepartmentCore : BaseDomain
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private String branchid;

        public String Branchid
        {
            get { return branchid; }
            set { branchid = value; }
        }

        private string branchname;

        public string Branchname
        {
            get { return branchname; }
            set { branchname = value; }
        }

        private string deptshortname;

        public string Deptshortname
        {
            get { return deptshortname; }
            set { deptshortname = value; }
        }

        private string deptname;

        public string Deptname
        {
            get { return deptname; }
            set { deptname = value; }
        }

        private string depttype;

        public string Depttype
        {
            get { return depttype; }
            set { depttype = value; }
        }
    }
}
