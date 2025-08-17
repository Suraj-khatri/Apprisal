using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class BankAccountsCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String employee_Id;

        public String Employee_Id
        {
            get { return employee_Id; }
            set { employee_Id = value; }
        }
        private string accountNumber;

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        private string accountProvider;

        public string AccountProvider
        {
            get { return accountProvider; }
            set { accountProvider = value; }
        }

        private string accountDetails;

        public string AccountDetails
        {
            get { return accountDetails; }
            set { accountDetails = value; }
        }

        private bool isDefault;

        public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

        private string sIsdefault;

        public string SisDefault
        {
            get { return sIsdefault; }
            set { sIsdefault = value; }
        }
    }
}
