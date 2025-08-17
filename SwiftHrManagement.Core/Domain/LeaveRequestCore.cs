using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class LeaveRequestCore :BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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
        private String leave_Type_Id;

        public String Leave_Type_Id
        {
            get { return leave_Type_Id; }
            set { leave_Type_Id = value; }
        }
        private long request_Days;

        public long Request_Days
        {
            get { return request_Days; }
            set { request_Days = value; }
        }
        private String requested_By;

        public String Requested_By
        {
            get { return requested_By; }
            set { requested_By = value; }
        }
        private String request_Date;

        public String Request_Date
        {
            get { return request_Date; }
            set { request_Date = value; }
        }
        private String request_With;

        public String Request_With
        {
            get { return request_With; }
            set { request_With = value; }
        }
        private long approved_Days;

        public long Approved_Days
        {
            get { return approved_Days; }
            set { approved_Days = value; }
        }
        private String approved_date;

        public String Approved_date
        {
            get { return approved_date; }
            set { approved_date = value; }
        }
        private String approved_From;

        public String Approved_From
        {
            get { return approved_From; }
            set { approved_From = value; }
        }
        private String approved_To;

        public String Approved_To
        {
            get { return approved_To; }
            set { approved_To = value; }
        }
        private String leave_Purpose;

        public String Leave_Purpose
        {
            get { return leave_Purpose; }
            set { leave_Purpose = value; }
        }
        private String leave_Status;

        public String Leave_Status
        {
            get { return leave_Status; }
            set { leave_Status = value; }
        }
        private String approved_By;

        public String Approved_By
        {
            get { return approved_By; }
            set { approved_By = value; }
        }
        private string remaining_days;

        public string Remaining_days
        {
            get { return remaining_days; }
            set { remaining_days = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private bool iscashable;

        public bool Iscashable
        {
            get { return iscashable; }
            set { iscashable = value; }
        }
        private string requestedByName;

        public string RequestedByName
        {
            get { return requestedByName; }
            set { requestedByName = value; }
        }
        private string leaveTypeName;

        public string LeaveTypeName
        {
            get { return leaveTypeName; }
            set { leaveTypeName = value; }
        }
        private string reqDepartmant;

        public string ReqDepartment
        {
            get { return reqDepartmant; }
            set { reqDepartmant = value; }
        }
        private string reqByDept;

        public string ReqByDept
        {
            get { return reqByDept; }
            set { reqByDept = value; }
        }
        private string recommByDept;

        public string RecommByDept
        {
            get { return recommByDept; }
            set { recommByDept = value; }
        }
        private string appByDept;

        public string AppByDept
        {
            get { return appByDept; }
            set { appByDept = value; }
        }
        private string reqBybranch;

        public string ReqBybranch
        {
            get { return reqBybranch; }
            set { reqBybranch = value; }
        }
        private string recommBybranch;

        public string RecommBybranch
        {
            get { return recommBybranch; }
            set { recommBybranch = value; }
        }
        private string appBybranch;

        public string AppBybranch
        {
            get { return appBybranch; }
            set { appBybranch = value; }
        }

        private string requestedHour;

        public string RequestedHour
        {
            get { return requestedHour; }
            set { requestedHour = value; }
        }
        private string approvedHour;

        public string ApprovedHour
        {
            get { return approvedHour; }
            set { approvedHour = value; }
        }

        private string remainingHour;

        public string RemainingHour
        {
            get { return remainingHour; }
            set { remainingHour = value; }
        }

        private string _recremarks;

        public string Recremarks
        {
            get { return _recremarks; }
            set { _recremarks = value;}
        }
        private string isLFA;

        public string IsLFA
        {
            get { return isLFA; }
            set { isLFA = value; }
        }

        private string _substitutedFrom;
        public string SubstitutedFrom
        {
            get { return _substitutedFrom; }
            set { _substitutedFrom = value; }
        }

        private string _substitutedTo;
        public string SubstitutedTo
        {
            get { return _substitutedTo; }
            set { _substitutedTo = value; }
        }


#region Leave Forward
        private long forward_Id;

        public long Forward_Id
        {
            get { return forward_Id; }
            set { forward_Id = value; }
        }
        private String leave_Assign_Id;

        public String Leave_Assign_Id
        {
            get { return leave_Assign_Id; }
            set { leave_Assign_Id = value; }
        }
        private String forwarded_Date;

        public String Forwarded_Date
        {
            get { return forwarded_Date; }
            set { forwarded_Date = value; }
        }
        private String forwarded_By;

        public String Forwarded_By
        {
            get { return forwarded_By; }
            set { forwarded_By = value; }
        }
        private String forwarded_To;

        public String Forwarded_To
        {
            get { return forwarded_To; }
            set { forwarded_To = value; }
        }
#endregion

        #region Leave Call Back

        private string callBackId;

        public string CallBackId
        {
            get { return callBackId; }
            set { callBackId = value; }
        }
        private string requestId;

        public string RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }
        private string callbackFrom;

        public string CallbackFrom
        {
            get { return callbackFrom; }
            set { callbackFrom = value; }
        }
        private string callbackTo;

        public string CallbackTo
        {
            get { return callbackTo; }
            set { callbackTo = value; }
        }
        private string callbackdays;

        public string Callbackdays
        {
            get { return callbackdays; }
            set { callbackdays = value; }
        }
        private string callbackBy;

        public string CallbackBy
        {
            get { return callbackBy; }
            set { callbackBy = value; }
        }
        private string callbackDate;

        public string CallbackDate
        {
            get { return callbackDate; }
            set { callbackDate = value; }
        }

        #endregion
    }
}
