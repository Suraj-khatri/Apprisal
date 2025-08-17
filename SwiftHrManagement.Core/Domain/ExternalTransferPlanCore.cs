using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ExternalTransferPlanCore : BaseDomain
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
        private String effectiveDate;

        public String EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }
        private String actualReportDate;

        public String ActualReportDate
        {
            get { return actualReportDate; }
            set { actualReportDate = value; }
        }
        private string whichBranch;

        public string WhichBranch
        {
            get { return whichBranch; }
            set { whichBranch = value; }
        }
        private string whichDepartment;

        public string WhichDepartment
        {
            get { return whichDepartment; }
            set { whichDepartment = value; }
        }
        private string reportingSupervisor;

        public string ReportingSupervisor
        {
            get { return reportingSupervisor; }
            set { reportingSupervisor = value; }
        }
        private object transferLetter;

        public object TransferLetter
        {
            get { return transferLetter; }
            set { transferLetter = value; }
        }
        private string transferDescription;

        public string TransferDescription
        {
          get { return transferDescription; }
          set { transferDescription = value; }
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
        private string newJobDetails;

        public string NewJobDetails
        {
            get { return newJobDetails; }
            set { newJobDetails = value; }
        }
        private string whichPosition;

        public string WhichPosition
        {
            get { return whichPosition; }
            set { whichPosition = value; }
        }
        private String actualTransferDate;

        public String ActualTransferDate
        {
            get { return actualTransferDate; }
            set { actualTransferDate = value; }
        }
        private string fromWhichBranch;

        public string FromWhichBranch
        {
            get { return fromWhichBranch; }
            set { fromWhichBranch = value; }
        }
        private string fromWhichDepartment;

        public string FromWhichDepartment
        {
            get { return fromWhichDepartment; }
            set { fromWhichDepartment = value; }
        }



        private string discontinuousMode;

        public string DiscontinuousMode
        {
            get { return discontinuousMode; }
            set { discontinuousMode = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string enddate;

        public string Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        private string serviceevent;

        public string ServiceEvent
        {
            get { return serviceevent; }
            set { serviceevent = value; }
        }

        public string TransferType
        {
            get { return _transferType; }
            set { _transferType = value; }
        }

        private string _transferType;
        private string recommendBy;

        public string RecommendBy
        {
            get { return recommendBy; }
            set { recommendBy = value; }
        }
        private string recommendDate;

        public string RecommendDate
        {
            get { return recommendDate; }
            set { recommendDate = value; }
        }
    }
}
