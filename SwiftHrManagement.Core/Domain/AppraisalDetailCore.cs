using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AppraisalDetailCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String appraisalOf;

        public String AppraisalOf
        {
            get { return appraisalOf; }
            set { appraisalOf = value; }
        }
        private String from_Date;

        public String From_Date
        {
            get { return from_Date; }
            set { from_Date = value; }
        }
        private String to_Date;

        public String To_Date
        {
            get { return to_Date; }
            set { to_Date = value; }
        }
        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private String details;

        public String Details
        {
            get { return details; }
            set { details = value; }
        }
        private string branchId;

        public string BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
        private string depatId;

        public string DepatId
        {
            get { return depatId; }
            set { depatId = value; }
        }
        private string positionId;

        public string PositionId
        {
            get { return positionId; }
            set { positionId = value; }
        }
    }
}
