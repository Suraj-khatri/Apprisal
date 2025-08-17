using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TrainingParticipantsCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long branchid;

        public long BranchID
        {
            get { return branchid; }
            set { branchid = value; }
        }

        private string branchName;

        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }

        private string trainingProgramId;

        public string TrainingProgramId
        {
            get { return trainingProgramId; }
            set { trainingProgramId = value; }
        }
        private string staffId;

        public string StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        private string staffName;

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        //Sujit

        private string departmentID;

        public string DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        private string departmentName;

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        private bool isApproved;

        public bool IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }

        private string approved;

        public string Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        private string trainingCat;

        public string TrainingCategory
        {
            get { return trainingCat; }
            set { trainingCat = value; }
        }


    }
}
