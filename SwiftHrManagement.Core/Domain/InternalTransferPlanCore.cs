using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class InternalTransferPlanCore: BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String staffId;

        public String StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        private String fromDept;

        public String FromDept
        {
            get { return fromDept; }
            set { fromDept = value; }
        }
        private String effectiveDate;

        public String EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }
        private String reportedDate;

        public String ReportedDate
        {
            get { return reportedDate; }
            set { reportedDate = value; }
        }
        private String whichDepartment;

        public String WhichDepartment
        {
            get { return whichDepartment; }
            set { whichDepartment = value; }
        }
        private String whichPosition;

        public String WhichPosition
        {
            get { return whichPosition; }
            set { whichPosition = value; }
        }
        private String transferDesc;

        public String TransferDesc
        {
            get { return transferDesc; }
            set { transferDesc = value; }
        }
        private String newJobDetails;

        public String NewJobDetails
        {
            get { return newJobDetails; }
            set { newJobDetails = value; }
        }
        private String newSupervisor;

        public String NewSupervisor
        {
            get { return newSupervisor; }
            set { newSupervisor = value; }
        }

        private String branchManager;

        public String BranchManager
        {
            get { return branchManager; }
            set { branchManager = value; }
        }
        private String isApproved;

        public String IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }
        private String approvedBy;

        public String ApprovedBy
        {
            get { return approvedBy; }
            set { approvedBy = value; }
        }
        private String approvedDate;

        public String ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }
        private String actualTransferDate;

        public String ActualTransferDate
        {
            get { return actualTransferDate; }
            set { actualTransferDate = value; }
        }
        private String userFileNumber;

        public String UserFileNumber
        {
            get { return userFileNumber; }
            set { userFileNumber = value; }
        }
    }
}
