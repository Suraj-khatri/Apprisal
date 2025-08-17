using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class RoleCore :BaseDomain
    {
        private long role_Id;

        public long Role_Id
        {
            get { return role_Id; }
            set { role_Id = value; }
        }
        private String role_Name;

        public String Role_Name
        {
            get { return role_Name; }
            set { role_Name = value; }
        }
        private String role_Type;

        public String Role_Type
        {
            get { return role_Type; }
            set { role_Type = value; }
        }
    }
}
