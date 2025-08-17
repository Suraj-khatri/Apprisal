using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class WFMemberCore
    {
        private long memberID;

        public long MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }
        private long categoryID;

        public long CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private long employeeID;

        public long EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        private string catName;

        public string CatName
        {
            get { return catName; }
            set { catName = value; }
        }
    }
}
