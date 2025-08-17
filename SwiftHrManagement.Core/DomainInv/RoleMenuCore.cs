using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class RoleMenuCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long userid;

        public long Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private String role_id;

        public String Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }
        private String menuList;

        public String MenuList
        {
            get { return menuList; }
            set { menuList = value; }
        }

        private long function_Id;

        public long Function_Id
        {
            get { return function_Id; }
            set { function_Id = value; }
        }
    }
}
