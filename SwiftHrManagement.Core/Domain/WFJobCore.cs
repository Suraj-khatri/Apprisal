using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class WFJobCore : BaseDomain
    {

        private long jobID;

        public long JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }


        private long createdEmpID;

        public long CreatedEmpID
        {
            get { return createdEmpID; }
            set { createdEmpID = value; }
        }
        private long jobCatID;

        public long JobCatID
        {
            get { return jobCatID; }
            set { jobCatID = value; }
        }
        private string jobDescription;

        public string JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }
        private string jobCode;

        public string JobCode
        {
            get { return jobCode; }
            set { jobCode = value; }
        }

        private DateTime closedDate;

        public DateTime ClosedDate
        {
            get { return closedDate; }
            set { closedDate = value; }
        }

        private string custCode;

        public string CustCode
        {
            get { return custCode; }
            set { custCode = value; }
        }

        private long jobCreator;

        public long JobCreator
        {
            get { return jobCreator; }
            set { jobCreator = value; }
        }
        private string jobCategory;

        public string JobCategory
        {
            get { return jobCategory; }
            set { jobCategory = value; }
        }
        private string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
    }
}
