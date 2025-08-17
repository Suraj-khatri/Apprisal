using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class SystemUser
    {
        private long _admin_Id;

        public long Admin_Id
        {
            get { return _admin_Id; }
            set { _admin_Id = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }
        private String post;

        public String Post
        {
            get { return post; }
            set { post = value; }
        }
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String phone;

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private String cell_Phone;

        public String Cell_Phone
        {
            get { return cell_Phone; }
            set { cell_Phone = value; }
        }
        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private String oldPass;

        public String OldPass
        {
            get { return oldPass; }
            set { oldPass = value; }
        }
        private String newPass;

        public String NewPass
        {
            get { return newPass; }
            set { newPass = value; }
        }
        private String roleName;

        public String RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        private String roleId;

        public String RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        private string userType;

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private String empId;

        public String EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private String branchId;

        public String BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
        private String departmentId;

        public String DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
        private String branchLevelAccess;

        public String BranchLevelAccess
        {
            get { return branchLevelAccess; }
            set { branchLevelAccess = value; }
        }
    }
}
