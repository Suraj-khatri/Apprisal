using System;

namespace SwiftHrManagement.Core.Domain
{
    public class onSiteDutyAssignmentCore:BaseDomain
    {

        private long onsiteid;

        public long OnsiteID
        {
            get { return onsiteid; }
            set { onsiteid = value; }
        }

        private String empId;

        public String EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        private String siteDateFrom;

        public String SiteDateFrom
        {
            get { return siteDateFrom; }
            set { siteDateFrom = value; }
        }

        private String siteDateTo;

        public String SiteDateTo
        {
            get { return siteDateTo; }
            set { siteDateTo = value; }
        }

        private String siteLocation;

        public String SiteLocation
        {
            get { return siteLocation; }
            set { siteLocation = value; }
        }

        private String purpose;

        public String Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private String userid;

        public String UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        private String approveBy;

        public String ApproveBy
        {
            get { return approveBy; }
            set { approveBy = value; }
        }

        private String recorded;

        public String Recorded
        {
            get { return recorded; }
            set { recorded = value; }
        }

        private String approvedDate;

        public String ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        private String approvedRemarks;

        public String ApprovedRemarks
        {
            get { return approvedRemarks; }
            set { approvedRemarks = value; }
        }

        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
     
    }
}
