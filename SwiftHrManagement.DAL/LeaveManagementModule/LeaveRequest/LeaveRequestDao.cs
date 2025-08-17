using System.Data;

namespace SwiftHrManagement.DAL.LeaveManagementModule.LeaveRequest
{
   public  class LeaveRequestDao
    {
       private DbService service;

       public LeaveRequestDao()
        {
            this.service = new DbService();
        }

       public DataSet SelectLeaveTypesCondition(string EmpID,string LeaveTypeID)
       {
           var sql = "EXEC proc_GetLeaveData"
                    + " @jobflag = 'CL'"
                    + ", @emp_ID = " + this.service.filterstring(EmpID)
                    + ", @leaveType = " + this.service.filterstring(LeaveTypeID);

           var ds = this.service.ReturnDataset(sql);
           if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
               return null;
           return ds;
       }
       public DataRow SelectRequestedDays(string EmpID, string LeaveTypeID, string Fromdate, string Todate)
       {
           var sql = "EXEC proc_GetLeaveData"
                    + " @jobflag = 'RD'"
                    + ", @emp_ID = " + this.service.filterstring(EmpID)
                    + ", @leaveType = " + this.service.filterstring(LeaveTypeID)
                    + ", @fromDate = " + this.service.filterstring(Fromdate)
                    + ", @toDate = " + this.service.filterstring(Todate);

           var ds = this.service.ReturnDataset(sql);
           if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
               return null;
           return ds.Tables[0].Rows[0];
           
       }

       public DataTable Save(string ID, string REQUESTED_BY, string LEAVE_TYPE_ID, string FROM_DATE, string TO_DATE,
                               string REQUESTED_DAYS, string REQUESTED_HRS_STATUS, string LEAVE_STATUS,
                               string LEAVE_PURPOSE, string REQUESTED_WITH,
                               string APPROVED_BY,
                               string REMAINING_DAYS,  string IS_LFA,
                               string substituted_with, string SUBSTITUTED_FROM, string user, string cclist,string session_id
                              )
       {
           var sql = "EXEC proc_LeaveRequest";
           sql += " @flag = " + (ID == "0" || ID == "" ? "'i'" : "'u'");          
           sql += ", @ID = " + this.service.filterstring(ID);

           sql += ", @Employee_ID ="+ this.service.filterstring(REQUESTED_BY);
           sql += ", @LeaveType	 ="+ this.service.filterstring(LEAVE_TYPE_ID);
           sql += ", @ReqFromDate ="+ this.service.filterstring(FROM_DATE);
           sql += ", @ReqToDate	 =" + this.service.filterstring(TO_DATE);
           sql += ", @ReqDays   ="+ this.service.filterstring(REQUESTED_DAYS);
           sql += ", @HalfDay =" + this.service.filterstring(REQUESTED_HRS_STATUS);

           sql += ", @Status ="+ this.service.filterstring(LEAVE_STATUS);
           sql += ", @Purpose =" + this.service.filterstring(LEAVE_PURPOSE);

           sql += ", @RecommendedBy =" + this.service.filterstring(REQUESTED_WITH);
           sql += ", @ApprovedBy =" + this.service.filterstring(APPROVED_BY);
           sql += ", @Remdays =" + this.service.filterstring(REMAINING_DAYS);

           sql += ", @LFA =" + IS_LFA;
           sql += ", @Relieving =" + this.service.filterstring(substituted_with);
           sql += ", @SubstituteDate =" + this.service.filterstring(SUBSTITUTED_FROM);
           sql += ", @entryUser =" + this.service.filterstring(user);
           sql += ", @session_id =" + this.service.filterstring(session_id);
           sql += ", @cclist ='" + cclist+"'";
           
           return this.service.ReturnDataset(sql).Tables[0];
       }

       public DataTable Delete(string user, string ID)
       {
           var sql = "EXEC proc_LeaveRequest";
           sql += " @flag = 'd'";
           sql += ", @entryUser = " + this.service.filterstring(user);
           sql += ", @ID = " + this.service.filterstring(ID);
           return this.service.ReturnDataset(sql).Tables[0];
       }

       public DataSet SelectById(string ID)
       {
           var sql = "EXEC proc_LeaveRequest";
           sql += " @flag = 's'";
           sql += ", @ID = " + this.service.filterstring(ID);

           var ds = this.service.ReturnDataset(sql);
           if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
               return null;
           return ds;

       }
    }
}
