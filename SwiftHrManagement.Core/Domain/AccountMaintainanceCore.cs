using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AccountMaintainanceCore:BaseDomain
    {
        private long acID;

        public long AcID
        {
            get { return acID; }
            set { acID = value; }
        }
        private string acNumber;

        public string AcNumber
        {
            get { return acNumber; }
            set { acNumber = value; }
        }
        private string acName;

        public string AcName
        {
            get { return acName; }
            set { acName = value; }
        }
        private string acCurrency;

        public string AcCurrency
        {
            get { return acCurrency; }
            set { acCurrency = value; }
        }
        private long acBranchId;

        public long AcBranchId
        {
            get { return acBranchId; }
            set { acBranchId = value; }
        }
        private string acTypeCode;

        public string AcTypeCode
        {
            get { return acTypeCode; }
            set { acTypeCode = value; }
        }
        private double acbalance;

        public double Acbalance
        {
            get { return acbalance; }
            set { acbalance = value; }
        }

        private long actEmpID;

        public long ActEmpID
        {
            get { return actEmpID; }
            set { actEmpID = value; }
        }
    }
}
