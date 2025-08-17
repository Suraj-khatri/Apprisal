using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.LeaveManagementModule.LeaveApprove
{
    public class LeaveApproveDao
    {
        private DbService service;

        public LeaveApproveDao()
        {
            this.service = new DbService();
        }

        public DataSet SelectById(string ID)
        {
            var sql = "EXEC proc_ApproveLeaveRequest";
            sql += " @flag = 's'";
            sql += ",@ID = " + this.service.filterstring(ID);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds;

        }

        public DataTable Update(string status,string appFromDate,string appToDate,string appDays,string halfDay,string lfa
            , string substituteDate, string relieving, string recRemarks, string appRemarks, string entryUser, string id)
        {
           
            var sql = "EXEC proc_ApproveLeaveRequest "
                      + " @flag=" + (status == "Pending" ? "'r'" : "'a'")
                      + " ,@AppFromDate=" + this.service.filterstring(appFromDate)
                      + " ,@AppToDate=" + this.service.filterstring(appToDate)
                      + " ,@AppDays=" + this.service.filterstring(appDays)
                      + " ,@HalfDay=" + this.service.filterstring(halfDay)
                      + " ,@LFA=" + this.service.filterstring(lfa)
                      + " ,@SubstituteDate	=" + this.service.filterstring(substituteDate)
                      + " ,@Relieving=" + this.service.filterstring(relieving)
                      + " ,@Status=" + this.service.filterstring(status)
                      + " ,@Remarks=" + (status == "Pending" ? this.service.filterstring(recRemarks) : this.service.filterstring(appRemarks))
                      + " ,@entryUser=" + this.service.filterstring(entryUser)
                      + " ,@ID=" + this.service.filterstring(id);
            
            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];
        }


        public DataTable Reject(string user, string id, string status, string appDays ,string recRemarks, string appRemarks)
        {
            var sql = "EXEC proc_ApproveLeaveRequest ";
            sql += " @flag = 'c'";
            sql += ",@entryuser = " + this.service.filterstring(user);
            sql += ",@Status = " + this.service.filterstring(status);
            sql += ",@AppDays = " + this.service.filterstring(appDays);
            sql += ",@Remarks=" +
                   (status == "Pending" ? this.service.filterstring(recRemarks) : this.service.filterstring(appRemarks));
            sql += ",@ID = " + this.service.filterstring(id);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];
        }

        public DataTable CalculateDays(string fromdate,string todate, string id)
        {
            var sql = "EXEC proc_GetLeaveData ";
            sql += " @jobflag = 'AD'";
            sql += ",@ID = " + this.service.filterstring(id);
            sql += ",@fromdate = " + this.service.filterstring(fromdate);
            sql += ",@todate=" + this.service.filterstring(todate);

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];
        }

        

    }
}
