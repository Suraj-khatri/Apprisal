using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class LeaveAssignmentCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String employee_id;

        public String Employee_id
        {
            get { return employee_id; }
            set { employee_id = value; }
        }
        private String leave_Type_Id;

        public String Leave_Type_Id
        {
            get { return leave_Type_Id; }
            set { leave_Type_Id = value; }
        }
        private String isdisabled;

        public String Isdisabled
        {
            get { return isdisabled; }
            set { isdisabled = value; }
        }
        private String no_Of_Days_Actual;

        public String No_Of_Days_Actual
        {
            get { return no_Of_Days_Actual; }
            set { no_Of_Days_Actual = value; }
        }

        //private String no_Of_Assign_Days;
        //public string No_Of_Assign_Days
        //{
        //    get { return no_Of_Assign_Days; }
        //    set { no_Of_Assign_Days = value; }
        //}

        private String isSaturday;

        public String IsSaturday
        {
            get { return isSaturday; }
            set { isSaturday = value; }
        }
        private String isPublic;

        public String IsPublic
        {
            get { return isPublic; }
            set { isPublic = value; }
        }
        private String approveThrough;

        public String ApproveThrough
        {
            get { return approveThrough; }
            set { approveThrough = value; }
        }
        private String recommendThrough;

        public String RecommendThrough
        {
            get { return recommendThrough; }
            set { recommendThrough = value; }
        }
        private String supportedBy;

        public String SupportedBy
        {
            get { return supportedBy; }
            set { supportedBy = value; }
        }

        private String balanceHour;

        public String BalanceHour
        {
            get { return balanceHour; }
            set { balanceHour = value; }
        }

        private string forceLeave;

        public string ForceLeave
        {
            get { return forceLeave; }
            set { forceLeave = value; }
        }

        private string lastYearLeave;

        public string LastYearLeave
        {
            get { return lastYearLeave; }
            set { lastYearLeave = value; }
        }
        
    }
}
