using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SwiftHrManagement.DAL.LeaveManagementModule.LeaveType
{
    public class LeaveTypesDao
    {

     private DbService service;

     public LeaveTypesDao()
     {
         this.service = new DbService();
     }

     public DataTable Update(string ID, string NAME_OF_LEAVE, string LEAVE_DETAILS,
                             string NO_OF_DAYS_DEFAULT,
                             string OCCURRENCE, string MAX_DAYS,
                             string MAX_ACCUMULATION, string IS_LFA, string LFADAYS,
                             string IS_ACTIVE, string IS_CASHABLE, string IS_UNLIMITED,
                             string IS_HOURLY, string IS_SATURDAY, string IS_HOLIDAY,
                             string IS_SUBSTITUTED, string RELIEVING, string user, string MAX_REQ_DAYS,string min_req_days
                            )
     {
         var sql = "EXEC proc_LeaveTypeSetUp";
         sql += " @flag = " + (ID == "0" || ID == "" ? "'i'" : "'u'");
         sql += ", @ID = " + this.service.filterstring(ID);
         sql += ", @LeaveType = " + this.service.filterstring(NAME_OF_LEAVE);
         sql += ", @Leave_Details = " + this.service.filterstring(LEAVE_DETAILS);
         sql += ", @DefaultDays = " + this.service.filterstring(NO_OF_DAYS_DEFAULT);
         sql += ", @Occurrence = " + this.service.filterstring(OCCURRENCE);
         sql += ", @MaxDays = " + this.service.filterstring(MAX_DAYS);
         sql += ", @MaxAccumulation = " + this.service.filterstring(MAX_ACCUMULATION);
         sql += ", @ApplyLFA = " + IS_LFA;
         sql += ", @LFAdays = " + this.service.filterstring(LFADAYS);
         sql += ", @Active = " + IS_ACTIVE;
         sql += ", @Cashable = " + IS_CASHABLE;
         sql += ", @Unlimited = " + IS_UNLIMITED;
         sql += ", @HalfDay = " + IS_HOURLY;
         sql += ", @Saturday = " + IS_SATURDAY;
         sql += ", @Holiday = " + IS_HOLIDAY;
         sql += ", @Substituted = " + IS_SUBSTITUTED;
         sql += ", @RELIEVING = " + RELIEVING;
         sql += ", @entryUser = " + this.service.filterstring(user);
         sql += ", @MAX_REQ_DAYS = " + this.service.filterstring(MAX_REQ_DAYS);
         sql += ", @min_req_days = " + this.service.filterstring(min_req_days);
        return this.service.ReturnDataset(sql).Tables[0]; 
       
     }


     public DataRow SelectById(string ID)
     {
         var sql = "EXEC proc_LeaveTypeSetUp";
         sql += " @flag = 's'";
         sql += ", @ID = " + this.service.filterstring(ID);

         var ds = this.service.ReturnDataset(sql);
         if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
             return null;
         return ds.Tables[0].Rows[0];

     }

     public DataRow Delete(string ID)
     {
         var sql = "EXEC proc_LeaveTypeSetUp";
         sql += " @flag = 'd'";
         sql += ", @ID = " + this.service.filterstring(ID);

         //return this.service.ReturnDataset(sql).Tables[0];
         var ds = this.service.ReturnDataset(sql);
         if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
             return null;
         return ds.Tables[0].Rows[0];
     }


    }
}
