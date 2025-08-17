using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class SalaryLeadgerMappingCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long branchID;

        public long BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        private string headerID;

        public string HeaderID
        {
            get { return headerID; }
            set { headerID = value; }
        }
        private string leaderNumber;

        public string LeaderNumber
        {
            get { return leaderNumber; }
            set { leaderNumber = value; }
        }

        private long actEmpId;

        public long ActEmpId
        {
            get { return actEmpId; }
            set { actEmpId = value; }
        }
    }
}
