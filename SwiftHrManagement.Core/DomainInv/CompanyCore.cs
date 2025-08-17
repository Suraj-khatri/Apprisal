using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class CompanyCore : BaseDomain
    {
        private long id;

        public long Id
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

        private string shortname;

        public string Shortname
        {
            get { return shortname; }
            set { shortname = value; }
        }

        //public string Short_name
        //{
        //    get { return shortname; }
        //    set { shortname = value; }
        //}
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string address2;

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        private string phone_no;

        public string Phone_no
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
        private string fax_no;

        public string Fax_no
        {
            get { return fax_no; }
            set { fax_no = value; }
        }
        private string contact_person;

        public string Contact_person
        {
            get { return contact_person; }
            set { contact_person = value; }
        }
        private string map_code;

        public string Map_code
        {
            get { return map_code; }
            set { map_code = value; }
        }
        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
