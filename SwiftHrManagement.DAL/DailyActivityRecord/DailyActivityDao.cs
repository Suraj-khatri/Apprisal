using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL;


namespace SwiftHrManagement.web.DAL.DailyActivityRecord
{
    public class DailyActivityDao : BaseDAOInv
    {
       public string OnAddDailyActivity(string fromTime,string toTime,string details,string sessionId,string date,string empId)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'id'";
           sql += ", @fromTime = " + filterstring(fromTime);
           sql += ", @toTime=" + filterstring(toTime);
           sql += ", @details=" + filterstring(details);
           sql += ", @sessionId=" + filterstring(sessionId);
           sql += ", @getDate=" + filterstring(date);
           sql += ", @empId=" + filterstring(empId);
           return GetSingleresult(sql);

       }
       public DataTable DisplayActivityDetails(string sessionId)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'sd'";
           sql += ", @sessionId=" + filterstring(sessionId);
           return ExecuteDataset(sql).Tables[0];

       }
       public DataTable DisplayEmpInfo(string empId)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'sa'";
           sql += ", @empId=" + filterstring(empId);
           return ExecuteDataset(sql).Tables[0];

       }

       public string OnFinalSave(string branch, string dept, string position, string empId,string sessionId,string date,string recommend)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'im'";
           sql += ", @branch = " + filterstring(branch);
           sql += ", @department=" + filterstring(dept);
           sql += ", @position=" + filterstring(position);
           sql += ", @empId=" + filterstring(empId);
           sql += ", @sessionId=" + filterstring(sessionId);
           sql += ", @getDate=" + filterstring(date);
           sql += ", @recommendedTo=" + filterstring(recommend);
          return GetSingleresult(sql);

       }

       public string OnUpdateActivityDetails(string fromTime,string toTime,string details,string rowId)
       {
            var sql = "Exec proc_activityDailyDetail";
            sql += " @flag = 'ed'";
            sql += ", @fromTime=" +filterstring(fromTime);
            sql += ", @toTime=" +filterstring(toTime);
            sql += ", @details=" +filterstring(details);
            sql += ", @activityDetailId=" + rowId;
           return GetSingleresult(sql);

       }
 

       public string OnDeleteActivityDeatils(long acDId)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'dd'";
           sql += ", @activityDetailId=" + acDId;
           return GetSingleresult(sql);

       }

       public DataTable OnSearch(string empId,string getDate)
       {
           var sql = "Exec proc_activityDailyDetail";
           sql += " @flag = 'sc'";
           sql += ", @empId=" + filterstring(empId);
           sql += ", @getDate=" + filterstring(getDate);
           return ExecuteDataset(sql).Tables[0];

       }
       public DataTable OnPupalate(string rowId)
       {
           var sql = "select fromTime,toTime,details from activityDetail  where activityDetailId = "+rowId;
           return ExecuteDataset(sql).Tables[0];

       }

     
	
       public override object MapObject(System.Data.DataRow dr)
       {
           throw new NotImplementedException();
       }

       public override void Save(object obj)
       {
           throw new NotImplementedException();
       }

       public override void Update(object obj)
       {
           throw new NotImplementedException();
       }
    }
}
