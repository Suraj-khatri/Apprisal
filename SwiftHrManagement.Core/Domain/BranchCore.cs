using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class BranchCore : BaseDomain
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string group;

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        private string zone;

        public string Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        private string district;

        public string District
        {
            get { return district; }
            set { district = value; }
        }

        private string contactPerson;

        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }
        private string branchshortname;

        public string Branchshortname
        {
            get { return branchshortname; }
            set { branchshortname = value; }
        }
        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string IbtAccount
        {
            get { return ibtAccount; }
            set { ibtAccount = value; }
        }

        public string BatchCode
        {
            get { return batchCode; }
            set { batchCode = value; }
        }

        private string ibtAccount;

        private string batchCode;

        private string stockAc;

        public string StockAc
        {
            get { return stockAc; }
            set { stockAc = value; }
        }

        private string expAc;

        public string ExpAc
        {
            get { return expAc; }
            set { expAc = value; }
        }

        private string transitAc;

        public string TransitAc
        {
            get { return transitAc; }
            set { transitAc = value; }
        }

        private string isDirectExp;

        public string IsDirectExp
        {
            get { return isDirectExp; }
            set { isDirectExp = value; }
        }

    }
}
