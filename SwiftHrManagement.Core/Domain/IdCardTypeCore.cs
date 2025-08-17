using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class IdCardTypeCore: BaseDomain  
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long empId;

        public long EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private String cardType;

        public String CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
        private String cardNo;

        public String CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
        private String issuePlace;

        public String IssuePlace
        {
            get { return issuePlace; }
            set { issuePlace = value; }
        }
        private String issueDate;

        public String IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }
        private String expiryDate;

        public String ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
        private String empName;

        public String EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
    }
}
