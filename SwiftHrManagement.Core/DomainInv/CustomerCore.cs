using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class CustomerCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string customerCode;

        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        private string customerAddress;

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        private string customerTelNo;

        public string CustomerTelNo
        {
            get { return customerTelNo; }
            set { customerTelNo = value; }
        }

        private string customerTelNoSec;

        public string CustomerTelNoSec
        {
            get { return customerTelNoSec; }
            set { customerTelNoSec = value; }
        }


        private string customerPANno;

        public string CustomerPANNo
        {
            get { return customerPANno; }
            set { customerPANno = value; }
        }
        private string customeFax;

        public string CustomeFax
        {
            get { return customeFax; }
            set { customeFax = value; }
        }
        private string contactPersonFirst;

        public string ContactPersonFirst
        {
            get { return contactPersonFirst; }
            set { contactPersonFirst = value; }
        }
        private string contactPersonSec;

        public string ContactPersonSec
        {
            get { return contactPersonSec; }
            set { contactPersonSec = value; }
        }
        private string contactPersonThird;

        public string ContactPersonThird
        {
            get { return contactPersonThird; }
            set { contactPersonThird = value; }
        }
        private string customerEmail;

        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value; }
        }
        private string customerWebsite;

        public string CustomerWebsite
        {
            get { return customerWebsite; }
            set { customerWebsite = value; }
        }
        private string businessDetails;

        public string BusinessDetails
        {
            get { return businessDetails; }
            set { businessDetails = value; }
        }
        private string facilityDetails;

        public string FacilityDetails
        {
            get { return facilityDetails; }
            set { facilityDetails = value; }
        }

        private string contPersonMobile1;

        public string ContPersonMobile1
        {
            get { return contPersonMobile1; }
            set { contPersonMobile1 = value; }
        }
        private string contPersonEmail1;

        public string ContPersonEmail1
        {
            get { return contPersonEmail1; }
            set { contPersonEmail1 = value; }
        }
        private string contPersonMobile2;

        public string ContPersonMobile2
        {
            get { return contPersonMobile2; }
            set { contPersonMobile2 = value; }
        }
        private string contPersonEmail2;

        public string ContPersonEmail2
        {
            get { return contPersonEmail2; }
            set { contPersonEmail2 = value; }
        }
        private string contPersonMobile3;

        public string ContPersonMobile3
        {
            get { return contPersonMobile3; }
            set { contPersonMobile3 = value; }
        }
        private string contPersonEmail3;

        public string ContPersonEmail3
        {
            get { return contPersonEmail3; }
            set { contPersonEmail3 = value; }
        }
        private string product;

        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        private string fiscalYear;

        public string FiscalYear
        {
            get { return fiscalYear; }
            set { fiscalYear = value; }
        }
        private string branch;

        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        private string qty;

        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private string isActive;

        public string IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
