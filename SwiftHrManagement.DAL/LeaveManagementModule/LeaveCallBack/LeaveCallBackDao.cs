using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.LeaveManagementModule.LeaveCallBack
{
    public class LeaveCallBackDao
    {
        private DbService service;

        public LeaveCallBackDao()
        {
            this.service = new DbService();
        }

        public DataRow SelectById(string reqId)
        {
            var sql = "EXEC proc_LeaveCallBack";
            sql += " @flag = 'sa'";
            sql += ", @LEAVEREQ_ID = " + this.service.filterstring(reqId);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        public DataRow SelectById(string reqId, string callBackId)
        {
            var sql = "EXEC proc_LeaveCallBack";
            sql += " @flag = 'sa'";
            sql += ",@LEAVEREQ_ID = " + this.service.filterstring(reqId);
            sql += ",@CALLBACK_ID = " + this.service.filterstring(callBackId);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        
        public DataRow Save(string LEAVE_REQUEST_ID, string FROM_DATE, string TO_DATE, string CALL_BACK_DAYS, string CALL_BACK_BY)
        {
            var sql = "EXEC proc_LeaveCallBack";
            sql += " @flag = 'i'";
            sql += ", @LEAVEREQ_ID = " + this.service.filterstring(LEAVE_REQUEST_ID);
            sql += ", @FromDate = " + this.service.filterstring(FROM_DATE);
            sql += ", @ToDate = " + this.service.filterstring(TO_DATE);
            sql += ", @Days = " + this.service.filterstring(CALL_BACK_DAYS);
            sql += ", @entryUser = " + this.service.filterstring(CALL_BACK_BY);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        public DataRow CalculateDays(string LEAVE_REQUEST_ID, string FROM_DATE, string TO_DATE)
        {
            var sql = "EXEC proc_GetLeaveData ";
            sql += "@jobflag = 'CD'";
            sql += ",@ID = " + this.service.filterstring(LEAVE_REQUEST_ID);
            sql += ",@fromdate = " + this.service.filterstring(FROM_DATE);
            sql += ",@todate=" + this.service.filterstring(TO_DATE);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

    }
}
