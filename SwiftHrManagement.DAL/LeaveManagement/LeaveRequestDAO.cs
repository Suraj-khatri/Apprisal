using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.LeaveManagement
{
    public class LeaveRequestDAO : BaseDAOInv
    {
        private StringBuilder _insertQury;
        private StringBuilder _updateQuery;
        private StringBuilder _approveQuery;
        private StringBuilder _selectQuery;
        private StringBuilder _ForwardQuery;
        private StringBuilder _rejectQuery;
        private StringBuilder _cancelQuery;
        public LeaveRequestDAO()
        {
          
            this._insertQury = new StringBuilder(" exec [procLeaveRequestDetails] 'i', 'FROMDATE','TODATE','LEAVETYPEID','REQUESTEDDAYS','REQUESTEDBY','REQUESTEDWITH','LEAVESTATUS','LEAVEPURPOSE',"
             + " 'CREATEDBY','CREATEDDATE','REMAININGDAYS','FROMDATE','TODATE','REQUESTEDDAYS','?APPROVED_BY','REQUESTEDHOUR','0','REMAININGHOUR',null,'IsLFA','SUBSTITUTEDFROM'");

            this._updateQuery = new StringBuilder("exec [procLeaveRequestDetails] 'u','FROMDATE','TODATE','LEAVETYPEID', "
            + " 'REQUESTEDDAYS','REQUESTEDBY','REQUESTEDWITH','LEAVESTATUS','LEAVEPURPOSE'"
            + " ,'MODIFIEDBY','MODIFIEDDATE','REMAININGDAYS',"
            + " 'FROMDATE','TODATE','REQUESTEDDAYS','?APPROVED_BY','REQUESTEDHOUR','0','REMAININGHOUR','ID_','IsLFA','SUBSTITUTEDFROM'");

            this._selectQuery = new StringBuilder("Exec procExecuteSQLString 'n','select l.ID,CONVERT(VARCHAR,l.FROM_DATE,107) AS FROM_DATE,CONVERT(VARCHAR,l.TO_DATE,107) AS TO_DATE, "
            + " dbo.GetEmployeeFullNameOfId(REQUESTED_BY) as REQUESTED_BY, l.CREATED_DATE, dbo.GetEmployeeFullNameOfId(REQUESTED_WITH) "
            + " as REQUESTED_WITH, lt.NAME_OF_LEAVE as LEAVE_TYPE_ID, LEAVE_PURPOSE, LEAVE_STATUS, REQUESTED_DAYS,REMAINING_DAYS,CONVERT(VARCHAR,l.SUBSTITUTED_FROM,101)SUBSTITUTED_FROM from LeaveRequest l with(nolock), "
            + " LeaveTypes lt with(nolock) where lt.ID = l.LEAVE_TYPE_ID'");

            this._approveQuery = new StringBuilder("UPDATE LEAVEREQUEST SET APRPROVED_DATE = 'APPROVEDDATE',APPROVED_DAYS='APPROVEDDAYS', "
            + " LEAVE_STATUS='Approved',APPROVED_BY='APPROVEDBY',APPROVED_FROM='APPROVEDFROM',APPROVED_TO='APPROVEDTO',REMARKS='APPROVEDREMARKS',APPROVED_HOUR='APPROVEDHOUR',IS_LFA='IS_LFA' WHERE ID='?ID'");

            this._ForwardQuery = new StringBuilder("INSERT INTO Leave_Forward (LEAVE_ASSIGN_ID, FORWARDED_DATE, FORWARDED_BY, FORWARDED_TO )"
            + " VALUES ('LEAVEASSIGNID','FORWARDEDDATE','FORWARDEDBY','FORWARDEDTO')");

            this._rejectQuery = new StringBuilder("UPDATE LEAVEREQUEST SET LEAVE_STATUS='Rejected',REQUESTED_WITH_date=GETDATE() WHERE ID= 'ID_'");
            this._cancelQuery = new StringBuilder("UPDATE LEAVEREQUEST SET LEAVE_STATUS='Cancelled',REQUESTED_WITH_date=GETDATE() WHERE ID= 'ID_'");
        }
        public override void Save(object obj)
        {

            LeaveRequestCore _lrequest = (LeaveRequestCore)obj;
            this._insertQury.Replace("REQUESTEDBY", _lrequest.Requested_By);
            this._insertQury.Replace("REQUESTEDWITH", _lrequest.Request_With);
            this._insertQury.Replace("LEAVETYPEID", _lrequest.Leave_Type_Id.ToString());
            this._insertQury.Replace("FROMDATE", _lrequest.From_Date);
            this._insertQury.Replace("TODATE", _lrequest.To_Date.ToString());
            this._insertQury.Replace("REQUESTEDDAYS", _lrequest.Request_Days.ToString());
            this._insertQury.Replace("REMAININGDAYS", _lrequest.Remaining_days.ToString());
            this._insertQury.Replace("LEAVESTATUS", _lrequest.Leave_Status);
            this._insertQury.Replace("LEAVEPURPOSE", _lrequest.Leave_Purpose);
            this._insertQury.Replace("CREATEDBY", _lrequest.CreatedBy);
            this._insertQury.Replace("CREATEDDATE", _lrequest.CreatedDate.ToString());
            this._insertQury.Replace("?APPROVED_BY", _lrequest.RequestedByName.ToString());
            this._insertQury.Replace("REQUESTEDHOUR", _lrequest.RequestedHour.ToString());
            this._insertQury.Replace("REMAININGHOUR", _lrequest.RemainingHour.ToString());
            this._insertQury.Replace("IsLFA", _lrequest.IsLFA.ToString());
            this._insertQury.Replace("SUBSTITUTEDFROM", _lrequest.SubstitutedFrom.ToString());
            this.ExecuteQuery(_insertQury.ToString());
        }
   
        public override void Update(object obj)
        {
            LeaveRequestCore _lrequest = (LeaveRequestCore)obj;
            this._updateQuery.Replace("ID_", _lrequest.Id.ToString());
            this._updateQuery.Replace("FROMDATE", _lrequest.From_Date);
            this._updateQuery.Replace("TODATE", _lrequest.To_Date.ToString());
            this._updateQuery.Replace("LEAVETYPEID", _lrequest.Leave_Type_Id.ToString());
            this._updateQuery.Replace("REMAININGDAYS", _lrequest.Remaining_days.ToString());
            this._updateQuery.Replace("REQUESTEDDAYS", _lrequest.Request_Days.ToString());
            this._updateQuery.Replace("REQUESTEDWITH", _lrequest.Request_With);
            this._updateQuery.Replace("REQUESTEDBY", _lrequest.Requested_By);
            this._updateQuery.Replace("LEAVESTATUS", _lrequest.Leave_Status);
            this._updateQuery.Replace("LEAVEPURPOSE", _lrequest.Leave_Purpose);
            this._updateQuery.Replace("MODIFIEDBY", _lrequest.ModifyBy);
            this._updateQuery.Replace("MODIFIEDDATE", _lrequest.ModifyDate.ToString());
            this._updateQuery.Replace("?APPROVED_BY", _lrequest.RequestedByName);
            this._updateQuery.Replace("REQUESTEDHOUR", _lrequest.RequestedHour.ToString());
            this._updateQuery.Replace("REMAININGHOUR", _lrequest.RemainingHour.ToString());
            this._updateQuery.Replace("IsLFA", _lrequest.IsLFA.ToString());
            this._updateQuery.Replace("SUBSTITUTEDFROM", _lrequest.SubstitutedFrom.ToString());

            this.ExecuteQuery(_updateQuery.ToString());
        }
        public void ApproveLeave(object obj)
        {
            LeaveRequestCore _lrequest = (LeaveRequestCore)obj;
            this._approveQuery.Replace("?ID", _lrequest.Id.ToString());
            this._approveQuery.Replace("APPROVEDFROM", _lrequest.Approved_From.ToString());
            this._approveQuery.Replace("APPROVEDTO", _lrequest.Approved_To.ToString());
            this._approveQuery.Replace("APPROVEDDAYS", _lrequest.Approved_Days.ToString());
            this._approveQuery.Replace("APPROVEDDATE", _lrequest.Approved_date.ToString());
            this._approveQuery.Replace("APPROVEDBY", _lrequest.Approved_By.ToString());
            this._approveQuery.Replace("APPROVEDREMARKS", _lrequest.Remarks.ToString());
            this._approveQuery.Replace("APPROVEDBY", _lrequest.Approved_By.ToString());
            this._approveQuery.Replace("APPROVEDHOUR", _lrequest.ApprovedHour.ToString());
            this._approveQuery.Replace("IS_LFA", _lrequest.IsLFA.ToString());
            this.ExecuteQuery(this._approveQuery.ToString());
            //Console.WriteLine(this._approveQuery.ToString());
        }
        public void ForwardLeave(object obj)
        {
            LeaveRequestCore _lforward = (LeaveRequestCore)obj;
            this._ForwardQuery.Replace("LEAVEASSIGNID", _lforward.Leave_Assign_Id.ToString());
            this._ForwardQuery.Replace("FORWARDEDDATE", _lforward.Forwarded_Date.ToString());
            this._ForwardQuery.Replace("FORWARDEDBY", _lforward.Forwarded_By.ToString());
            this._ForwardQuery.Replace("FORWARDEDTO", _lforward.Forwarded_To.ToString());
            this.ExecuteQuery(_ForwardQuery.ToString());
        }
        public void RejectLeaveRequest(object obj)
        {
            LeaveRequestCore _lreject = (LeaveRequestCore)obj;
            this._rejectQuery.Replace("ID_", _lreject.Id.ToString());
            this.ExecuteQuery(_rejectQuery.ToString());
        }
        public void CancelLeaveRequest(object obj)
        {
            LeaveRequestCore _lcancel = (LeaveRequestCore)obj;
            this._cancelQuery.Replace("ID_", _lcancel.Id.ToString());
            this.ExecuteQuery(_cancelQuery.ToString());
        }
        public List<LeaveRequestCore> Findall()
        {
            DataTable dt = SelectByQuery(this._selectQuery.ToString());
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }
        public List<LeaveRequestCore> FindLeaveRequestForApproved(long EmpId)
        {
            String sSql = "select l.ID,CONVERT(VARCHAR,l.FROM_DATE,107) AS FROM_DATE,CONVERT(VARCHAR,l.TO_DATE,107) AS TO_DATE, l.CREATED_DATE, dbo.GetEmployeeFullNameOfId(REQUESTED_BY) as REQUESTED_BY, "
			+" lt.NAME_OF_LEAVE as LEAVE_TYPE_ID, LEAVE_PURPOSE,dbo.GetEmployeeFullNameOfId(REQUESTED_WITH) as REQUESTED_WITH,LEAVE_STATUS,"
            + " REQUESTED_DAYS,dbo.GetEmployeeFullNameOfId(REQUESTED_WITH) as REQUESTED_WITH,REMAINING_DAYS,APPROVED_BY from LeaveRequest l, LeaveTypes lt where lt.ID = l.LEAVE_TYPE_ID and l.REQUESTED_WITH=" + EmpId + "";
            DataTable dt = SelectByQuery(sSql);
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }
        public List<LeaveRequestCore> Findall(String Rqest_User)
        {
            string sSql = ("Exec procExecuteSQLString 's',' "
           + " select e.EMPLOYEE_ID, l.ID,CONVERT(VARCHAR,l.FROM_DATE,107) AS FROM_DATE,CONVERT(VARCHAR,l.TO_DATE,107) AS TO_DATE, l.CREATED_DATE,  e.FIRST_NAME +  + e.middle_name + +e.last_name as REQUESTED_BY,"
           + " dbo.GetEmployeeFullNameOfId(REQUESTED_WITH)  as REQUESTED_WITH, lt.NAME_OF_LEAVE as LEAVE_TYPE_ID, "
           + " LEAVE_PURPOSE, LEAVE_STATUS, REQUESTED_DAYS,REMAINING_DAYS,APPROVED_BY from LeaveRequest l with (nolock),  LeaveTypes lt with (nolock), "
           + " Employee e with (nolock) ','and 1=1 and lt.ID = l.LEAVE_TYPE_ID and e.EMPLOYEE_ID= l.REQUESTED_BY and e.EMPLOYEE_ID = ''" + Rqest_User + "'''").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }
     
        public LeaveRequestCore FindallById(long Id)
        {


            string sSql = ("SELECT ID,IS_LFA,CONVERT(VARCHAR,FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,TO_DATE,101) AS TO_DATE,lr.CREATED_DATE,ISNULL(REQUESTED_DAYS,0) [REQUESTED_DAYS],REQUESTED_WITH,LEAVE_PURPOSE,LEAVE_TYPE_ID, "
                              + " LEAVE_STATUS,REQUESTED_BY,Rec_Remarks,REMAINING_DAYS,APPROVED_BY,cast(REQUESTED_HOUR as Int) as REQUESTED_HOUR,cast(REMAINING_HOUR as Int) as REMAINING_HOUR,"
                              + " e.DEPARTMENT_ID as reqDpt,e.BRANCH_ID as reqBranch,e1.DEPARTMENT_ID as recommDpt,e1.BRANCH_ID as recommBranch,"
                              + " e2.DEPARTMENT_ID as appDpt,e2.BRANCH_ID as appBranch,lr.REQUESTED_HRS_STATUS,CONVERT(VARCHAR,lr.SUBSTITUTED_FROM,101) SUBSTITUTED_FROM"
                              + " FROM LeaveRequest lr"
                              + " INNER JOIN Employee e on lr.REQUESTED_BY = e.EMPLOYEE_ID"
                              + " INNER JOIN Employee e1 on lr.REQUESTED_WITH = e1.EMPLOYEE_ID"
                              + " INNER JOIN Employee e2 on lr.APPROVED_BY = e2.EMPLOYEE_ID where ID =" + Id + "").ToString();

       
            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)
                _leaveRequst = (LeaveRequestCore)this.MapObject(dt.Rows[0]);
            return _leaveRequst;
        }

        public LeaveRequestCore FindallByBranchId(long Id)
        {

            string sSql = (" SELECT  lr.ID,CONVERT(VARCHAR,lr.FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,lr.TO_DATE,101)AS TO_DATE, lr.CREATED_DATE,isnull(lr.REQUESTED_DAYS,0)[REQUESTED_DAYS],lr.REQUESTED_WITH,lr.APPROVED_BY as app_by"
                             + " ,LEAVE_PURPOSE,LEAVE_TYPE_ID,e.DEPARTMENT_ID as deptName,lr.LEAVE_STATUS,lr.REQUESTED_BY,"
                             + " REMAINING_DAYS,APPROVED_BY,cast(REQUESTED_HOUR as Int) as REQUESTED_HOUR,cast(REMAINING_HOUR as Int) as REMAINING_HOUR,REQUESTED_HRS_STATUS FROM LeaveRequest lr"
                             + " INNER JOIN Employee e on e.EMPLOYEE_ID=lr.REQUESTED_BY AND lr.ID =" + Id + "").ToString();

            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)
                _leaveRequst = (LeaveRequestCore)this.MapObjectBranch(dt.Rows[0]);
            return _leaveRequst;
        }
        public LeaveRequestCore FindApprovedDetails(long Id)
        {
            string sSql = ("SELECT REMAINING_DAYS,cast(REMAINING_HOUR as Int) as REMAINING_HOUR,cast(APPROVED_HOUR as Int) as APPROVED_HOUR,isnull(REQUESTED_HRS_STATUS,0) [REQUESTED_HRS_STATUS],CONVERT(VARCHAR,APPROVED_FROM,107) as APPROVED_FROM,CONVERT(VARCHAR,APPROVED_TO,107) AS APPROVED_TO,isnull(APPROVED_DAYS,0)as APPROVED_DAYS,"
                        + " dbo.GetEmployeeFullNameOfId(APPROVED_BY) as APPROVED_BY,CONVERT(VARCHAR,APRPROVED_DATE,107) AS APRPROVED_DATE,APPROVED_BY,Remarks from LeaveRequest where ID =" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)
                _leaveRequst = (LeaveRequestCore)this.MapObjectForApprovedDetails(dt.Rows[0]);
            return _leaveRequst;
        }
        public object MapObjectForApprovedDetails(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Approved_From = dr["APPROVED_FROM"].ToString();
            _leave.Approved_To = dr["APPROVED_TO"].ToString();
            _leave.Approved_Days = long.Parse(dr["APPROVED_DAYS"].ToString());
            _leave.Remaining_days = dr["REMAINING_DAYS"].ToString();
            _leave.Approved_By = dr["APPROVED_BY"].ToString();
            _leave.Approved_date = dr["APRPROVED_DATE"].ToString();
            _leave.RemainingHour = dr["REMAINING_HOUR"].ToString();
            _leave.ApprovedHour = dr["REQUESTED_HRS_STATUS"].ToString();
            _leave.Remarks = dr["Remarks"].ToString();
            return _leave;
        }

        public List<LeaveRequestCore> FindCallBackDetails(long Id)
        {
            string sSql = (" SELECT LC.ID,LT.NAME_OF_LEAVE AS LEAVE_REQUEST_ID,convert(varchar,LC.FROM_DATE,107) as FROM_DATE,"
            +" convert(varchar,LC.TO_DATE,107) as TO_DATE,CALL_BACK_DAYS,CALL_BACK_BY,convert(varchar,CALL_BACK_DATE,107) as CALL_BACK_DATE"
            +" FROM LeaveCallBack LC INNER JOIN LeaveRequest LR ON LR.ID=LC.LEAVE_REQUEST_ID INNER JOIN LeaveTypes LT ON  LR.LEAVE_TYPE_ID =LT.ID " 
            
            +" WHERE LEAVE_REQUEST_ID="+Id+"").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<LeaveRequestCore> _leaveRequst = new List<LeaveRequestCore>();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    return _leaveRequst = null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForCallBackView(dr);
                        _leaveRequst.Add(_lreq);
                    }
                }
               
            }
            return _leaveRequst;
        }
        public object MapObjectForCallBackView(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.CallBackId = dr["ID"].ToString();
            _leave.RequestId = dr["LEAVE_REQUEST_ID"].ToString();
            _leave.CallbackFrom = dr["FROM_DATE"].ToString();
            _leave.CallbackTo = dr["TO_DATE"].ToString();
            _leave.Callbackdays = dr["CALL_BACK_DAYS"].ToString();
            _leave.CallbackDate = dr["CALL_BACK_DATE"].ToString();
            _leave.CallbackBy = dr["CALL_BACK_BY"].ToString();
            return _leave;
        }


        public LeaveRequestCore FindRequestForApproved(long Id)
        {
            string sSql = ("SELECT ID,IS_LFA, CONVERT(VARCHAR,FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,TO_DATE,101) AS TO_DATE, CREATED_DATE,dbo.GetEmployeeNameWithEmpCode(REQUESTED_BY) as REQUESTED_NAME,REQUESTED_BY,REQUESTED_DAYS, REQUESTED_WITH, LEAVE_PURPOSE, LEAVE_TYPE_ID, isnull(REQUESTED_HRS_STATUS,0) [REQUESTED_HRS_STATUS] ,"
            + " LEAVE_STATUS,CONVERT(VARCHAR,APPROVED_FROM,101) as APPROVED_FROM,CONVERT(VARCHAR,APPROVED_TO,101) as APPROVED_TO,APPROVED_DAYS,REMAINING_DAYS,APPROVED_BY,cast(REMAINING_HOUR as Int) as REMAINING_HOUR,cast(APPROVED_HOUR as Int) as APPROVED_HOUR,isnull(Rec_Remarks,'')Rec_Remarks,convert(varchar,SUBSTITUTED_FROM,101) SUBSTITUTED_FROM FROM LeaveRequest where ID =" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)
                    _leaveRequst = (LeaveRequestCore)this.MapObjectForApproved(dt.Rows[0]);
            return _leaveRequst;
        }
        public object MapObjectForApproved(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.From_Date = dr["FROM_DATE"].ToString();
            _leave.Leave_Type_Id = dr["LEAVE_TYPE_ID"].ToString();
            _leave.To_Date = dr["TO_DATE"].ToString();
            _leave.Request_Days = long.Parse(dr["REQUESTED_DAYS"].ToString());
            _leave.Request_Date = dr["CREATED_DATE"].ToString();
            _leave.Request_With = dr["REQUESTED_WITH"].ToString();
            _leave.Leave_Status = dr["LEAVE_STATUS"].ToString();
            _leave.Leave_Purpose = dr["LEAVE_PURPOSE"].ToString();
            _leave.Requested_By = dr["REQUESTED_BY"].ToString();
            _leave.RequestedByName = dr["REQUESTED_NAME"].ToString();
            _leave.Approved_From = dr["APPROVED_FROM"].ToString();
            _leave.Approved_To = dr["APPROVED_TO"].ToString();
            _leave.Approved_Days = long.Parse(dr["APPROVED_DAYS"].ToString());
            _leave.Remaining_days = dr["REMAINING_DAYS"].ToString();
            _leave.RequestedByName = dr["APPROVED_BY"].ToString();
            _leave.RemainingHour = dr["REMAINING_HOUR"].ToString();
            _leave.ApprovedHour = dr["APPROVED_HOUR"].ToString();
            _leave.RequestedHour = dr["REQUESTED_HRS_STATUS"].ToString();
            //_leave.Remarks = dr["Remarks"].ToString();
            _leave.Recremarks = dr["Rec_Remarks"].ToString();
            _leave.IsLFA = dr["IS_LFA"].ToString();
            _leave.SubstitutedFrom = dr["SUBSTITUTED_FROM"].ToString();
            return _leave;
        }
        public LeaveRequestCore FindApprovedLeaveForCallBack(long Id)
        {

            string sSql = (" SELECT l.ID,CONVERT(VARCHAR,l.APPROVED_FROM,101) AS APPROVED_FROM,CONVERT(VARCHAR,l.APPROVED_TO,101) AS APPROVED_TO,"
                            + " dbo.GetEmployeeFullNameOfId(REQUESTED_BY) AS REQUESTED_NAME,l.REQUESTED_BY,lt.NAME_OF_LEAVE AS LEAVE_NAME,"
                            + " l.LEAVE_TYPE_ID,dbo.GetEmployeeFullNameOfId(APPROVED_BY) as APPROVED_BY, isnull(l.APPROVED_DAYS,0)as APPROVED_DAYS FROM LeaveRequest l, LeaveTypes lt "          
                            +" WHERE lt.ID = l.LEAVE_TYPE_ID and l.id="+Id+"").ToString();
            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)
                _leaveRequst = (LeaveRequestCore)this.MapObjectForCallBack(dt.Rows[0]);
            return _leaveRequst;
        }
        public object MapObjectForCallBack(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.Approved_From = dr["APPROVED_FROM"].ToString();
            _leave.Leave_Type_Id = dr["LEAVE_TYPE_ID"].ToString();
            _leave.Approved_To = dr["APPROVED_TO"].ToString();
            _leave.Approved_Days = long.Parse(dr["APPROVED_DAYS"].ToString());
            _leave.Approved_By = dr["APPROVED_BY"].ToString();           
            _leave.Requested_By = dr["REQUESTED_BY"].ToString();
            _leave.RequestedByName = dr["REQUESTED_NAME"].ToString();
            _leave.LeaveTypeName = dr["LEAVE_NAME"].ToString();

            return _leave;
        }
        public LeaveRequestCore FindremainingDays(string flag,string typeId, string empid, string rowid)
        {
            string sSql = ("Exec procLeaveRemain '"+flag+"' ,"+ filterstring(empid) +","+ filterstring(typeId) +","+filterstring(rowid)+"").ToString();
            DataTable dt = SelectByQuery(sSql);
            LeaveRequestCore _leaveRequst = null;
            if (dt != null)

                _leaveRequst = (LeaveRequestCore)this.MapObjectforremainingdays(dt.Rows[0]);
            return _leaveRequst;
        }
        public Boolean CheckPendingRequest(string leaveId, string user, string rowId)
        {
            string sSql = "Exec procLeaveRemain 'c'," + filterstring(user) + "," + filterstring(leaveId) + ",'" + rowId + "'";
            Boolean IfExists = this.CheckStatement(sSql);
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object MapObjectforremainingdays(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Remaining_days = dr["REMAIN_LEAVE"].ToString();
            _leave.RemainingHour = dr["REMAIN_HOUR"].ToString();
            return _leave;
        }
        public List<LeaveRequestCore> FindByReqstedUsr(String Rqest_User)
        {
            string sSql = ("Exec procExecuteSQLString 's',' "
            + " select e.EMPLOYEE_ID, l.ID,CONVERT(VARCHAR,l.FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,l.TO_DATE,101) AS TO_DATE, REQUEST_DATE,  e.FIRST_NAME +  + e.middle_name + +e.last_name as REQUESTED_BY, l.CREATED_DATE, "
            + " dbo.GetEmployeeFullNameOfId(REQUESTED_WITH)  as REQUESTED_WITH, lt.NAME_OF_LEAVE as LEAVE_TYPE_ID, "
            + " LEAVE_PURPOSE, LEAVE_STATUS, REQUESTED_DAYS from LeaveRequest l with (nolock),  LeaveTypes lt with (nolock), "
            + " Employee e with (nolock) ','and 1=1 and lt.ID = l.ID and e.EMPLOYEE_ID= l.REQUESTED_BY and e.FIRST_NAME like ''"+ Rqest_User +"%'''").ToString();
            DataTable dt = SelectByQuery(sSql);           
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }
        public List<LeaveRequestCore> FindByLevType(String LeaveType)
        {
            string sSql = ("Exec procExecuteSQLString 's','select l.ID,CONVERT(VARCHAR,l.FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,l.TO_DATE,101) AS TO_DATE,l.CREATED_DATE, "
            + " dbo.GetEmployeeFullNameOfId(REQUESTED_BY) as REQUESTED_BY, dbo.GetEmployeeFullNameOfId(REQUESTED_WITH) "
            + " as REQUESTED_WITH, lt.NAME_OF_LEAVE as LEAVE_TYPE_ID, LEAVE_PURPOSE, LEAVE_STATUS, REQUESTED_DAYS from LeaveRequest l with(nolock),"
            + " LeaveTypes lt with(nolock)','and lt.ID = l.ID and LEAVE_TYPE_ID=''" + LeaveType + "'''").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }
        public List<LeaveRequestCore> FindByMValue(String LeaveType, String ReqtedUsr)
        {
            string sSql = this._selectQuery.ToString();
            if (ReqtedUsr  != "")
            {
                sSql = sSql + ",' and dbo.GetEmployeeFullNameOfId(REQUESTED_BY) LIKE ''" + FilterQuote(ReqtedUsr) + "%''";
            }
            if (LeaveType != "")
            {
                sSql = sSql + " and LT.NAME_OF_LEAVE LIKE ''" + FilterQuote(LeaveType) + "%'' ";
            }
            sSql = sSql + "'";

            DataTable dt = SelectByQuery(sSql);
            List<LeaveRequestCore> _leaveReq = new List<LeaveRequestCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveRequestCore _lreq = (LeaveRequestCore)this.MapObjectForLr(dr);
                    _leaveReq.Add(_lreq);
                }
            }
            return _leaveReq;
        }

        public  object MapObjectForLr(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.From_Date = dr["FROM_DATE"].ToString();
            _leave.Leave_Type_Id = dr["LEAVE_TYPE_ID"].ToString();
            _leave.To_Date = dr["TO_DATE"].ToString();
            _leave.Request_Days = long.Parse(dr["REQUESTED_DAYS"].ToString());
            _leave.Remaining_days = dr["REMAINING_DAYS"].ToString();
            _leave.Request_Date = dr["CREATED_DATE"].ToString();
            _leave.Request_With = dr["REQUESTED_WITH"].ToString();
            _leave.Leave_Status = dr["LEAVE_STATUS"].ToString();
            _leave.Leave_Purpose = dr["LEAVE_PURPOSE"].ToString();
            _leave.Requested_By = dr["REQUESTED_BY"].ToString();
            return _leave;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.From_Date = dr["FROM_DATE"].ToString();
            _leave.Leave_Type_Id = dr["LEAVE_TYPE_ID"].ToString();
            _leave.To_Date = dr["TO_DATE"].ToString();
            _leave.Request_Days = long.Parse(dr["REQUESTED_DAYS"].ToString());
            _leave.Remaining_days = dr["REMAINING_DAYS"].ToString();
            _leave.Request_Date = dr["CREATED_DATE"].ToString();
            _leave.Request_With = dr["REQUESTED_WITH"].ToString();
            _leave.Leave_Status = dr["LEAVE_STATUS"].ToString();
            _leave.Leave_Purpose = dr["LEAVE_PURPOSE"].ToString();
            _leave.Requested_By = dr["REQUESTED_BY"].ToString();
            _leave.Approved_By = dr["APPROVED_BY"].ToString();
            
            _leave.RequestedByName = dr["APPROVED_BY"].ToString();
            _leave.ReqDepartment = dr["reqDpt"].ToString();
            _leave.RecommByDept = dr["recommDpt"].ToString();
            _leave.AppByDept = dr["appDpt"].ToString();
            _leave.ReqBybranch = dr["reqBranch"].ToString();
            _leave.RecommBybranch = dr["recommBranch"].ToString();
            _leave.AppBybranch = dr["appBranch"].ToString();
            _leave.RequestedHour = dr["REQUESTED_HRS_STATUS"].ToString();
            _leave.RemainingHour = dr["REMAINING_HOUR"].ToString();
            _leave.Recremarks = dr["Rec_Remarks"].ToString();
            _leave.IsLFA = dr["IS_LFA"].ToString();
            _leave.SubstitutedFrom = dr["SUBSTITUTED_FROM"].ToString();
            return _leave;
        }

        public  object MapObjectBranch(System.Data.DataRow dr)
        {
            LeaveRequestCore _leave = new LeaveRequestCore();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.From_Date = dr["FROM_DATE"].ToString();
            _leave.Leave_Type_Id = dr["LEAVE_TYPE_ID"].ToString();
            _leave.To_Date = dr["TO_DATE"].ToString();
            _leave.Request_Days = long.Parse(dr["REQUESTED_DAYS"].ToString());
            _leave.Remaining_days = dr["REMAINING_DAYS"].ToString();
            _leave.Request_Date = dr["CREATED_DATE"].ToString();
            _leave.Request_With = dr["REQUESTED_WITH"].ToString();
            _leave.Leave_Status = dr["LEAVE_STATUS"].ToString();
            _leave.Leave_Purpose = dr["LEAVE_PURPOSE"].ToString();
            _leave.Requested_By = dr["REQUESTED_BY"].ToString();
            _leave.Approved_By = dr["APPROVED_BY"].ToString();
            _leave.ReqDepartment = dr["deptName"].ToString();
            _leave.RequestedByName = dr["app_by"].ToString();
            _leave.RequestedHour = dr["REQUESTED_HRS_STATUS"].ToString();
            _leave.RemainingHour = dr["REMAINING_HOUR"].ToString();



            return _leave;
        }
        
        public void DeleteById(long id, String userName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from LeaveRequest' , ' and  ID=''" + id + "''', '" + userName + "'");      
        }
        public void ManageRecommend(string id, string recommendFrom, string recommendTo,string recRemarks)
        {
            ExecuteQuery("exec ProcForwardLeaveRequest 'f' ," + filterstring(id) + "," + filterstring(recommendFrom) + "," + filterstring(recommendTo) + "," + filterstring(recRemarks));
             
        }
    }
}
