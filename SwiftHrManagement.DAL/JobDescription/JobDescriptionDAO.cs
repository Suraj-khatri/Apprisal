using System;
using System.Data;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.JobDescription
{
   public class JobDescriptionDAO: BaseDAO
    {
       
       public override Object MapObject(DataRow dr)
       {
           throw new NotImplementedException();
       }

       public override void Save(Object obj)
       {
           throw new NotImplementedException(); 
       }

       public override void Update(Object obj)
       {
           throw new NotImplementedException();
       }
       public DataTable GetEmpDetails(string empId,string Userid)
       {
           string sql = "EXEC proc_JobDescription @flag='getEmpDetails'";
            sql += ",@employeeId=" + FilterString(empId);
            sql += ",@user=" + FilterString(Userid);
            DataTable dt = ExecuteDataset(sql).Tables[0];
           return dt;
       }
       public string InsertTemp(string staffId, string user)
       {
           string sql = "EXEC proc_JobDescription @flag='ti'";
           sql += ",@employeeId=" + staffId;
           sql += ",@user=" + user;
           return GetSingleresult(sql);
       }
       public DataTable GetRptDetails()
       {
           string sql = "EXEC proc_JobDescription @flag='getRpt'";
           DataTable dt = ExecuteDataset(sql).Tables[0];
           return dt;
       }
       public string DeleteTemp(string id)
       {
           string sql = "EXEC proc_JobDescription @flag='del'";
           sql += ",@rowId=" + id;
           return GetSingleresult(sql);
       }
        public string Delete(string id)
        {
            string sql = "EXEC proc_JobDescription @flag='delete'";
            sql += ",@rowId=" + id;
            return GetSingleresult(sql);
        }
        public string InsertJobDesc(JobDescriptionCore job)
       {
           string sql = "EXEC proc_JobDescription @flag='insert'";
           sql += ",@branchId=" + FilterString(job.BranchId);
           sql += ",@employeeId=" + FilterString(job.EmpId);
           sql += ",@funcId=" + FilterString(job.FunctionalId);
           sql += ",@positionId=" + FilterString(job.PositionId);
           sql += ",@superVisor=" + FilterString(job.SuperVisor);
           sql += ",@startDate=" + FilterString(job.StartDate);
           sql += ",@endDate=" + FilterString(job.EndDate);
           sql += ",@funcobj=" + FilterString(job.FunctionalObjectives);
           sql += ",@generalJD=" + FilterString(job.GeneralJd);
           sql += ",@servicesJD=" + FilterString(job.ServicesJd);
           sql += ",@keyCompetent=" + FilterString(job.KeyCompetent);
           sql += ",@user=" + FilterString(job.User.ToString());
           return GetSingleresult(sql);
       }


        public string UpdateJd(JobDescriptionCore job)
        {
            string sql = "EXEC proc_JobDescription @flag='update'";
          
            sql += ",@superVisor=" + FilterString(job.SuperVisor);
            sql += ",@startDate=" + FilterString(job.StartDate);
            sql += ",@endDate=" + FilterString(job.EndDate);
            sql += ",@funcobj=" + FilterString(job.FunctionalObjectives);
            sql += ",@generalJD=" + FilterString(job.GeneralJd);
            sql += ",@servicesJD=" + FilterString(job.ServicesJd);
            sql += ",@keyCompetent=" + FilterString(job.KeyCompetent);
            sql += ",@rowId=" + FilterString(job.RowId.ToString());

            return GetSingleresult(sql);
        }
        public void RemoveTemp(string user)
       {
           string sql = "EXEC proc_JobDescription @flag='trunc'";
           sql += ",@user=" + FilterString(user);
           ExecuteQuery(sql);
       }

       public DataTable GetData(string id)
       {
           string sql = "EXEC proc_JobDescription @flag='getData'";
           sql += ",@rowid=" + FilterString(id);
           return ExecuteDataset(sql).Tables[1];
       }

       public JobDescriptionCore ReturnData(string id)
       {
           JobDescriptionCore job = new JobDescriptionCore();
           string sql = "EXEC proc_JobDescription @flag='getData'";
           sql += ",@rowid=" + FilterString(id);
           DataTable dt = ExecuteDataset(sql).Tables[0];
           if (dt == null || dt.Rows.Count <= 0)
               return null; 
           foreach (DataRow dr in dt.Rows)
           {
               job.BranchId = dr["Branch"].ToString();
               job.PositionId = dr["Position"].ToString();
               job.EmpId = dr["Employee"].ToString();
               job.FunctionalId = dr["Functional"].ToString();
               job.StartDate = dr["startDate"].ToString();
               job.EndDate = dr["endDate"].ToString();
               job.ServicesJd = dr["servicesJD"].ToString();
               job.SuperVisor = dr["Supervisor"].ToString();
               job.KeyCompetent = dr["keyCompetence"].ToString();
               job.GeneralJd = dr["generalJD"].ToString();
               job.FunctionalObjectives = dr["functionalObjectives"].ToString();
               job.CreatedBy = Convert.ToInt32(dr["createdBy"].ToString());
               job.Id = Convert.ToInt32(dr["empId"].ToString());
               job.ServicesJd= dr["servicesJD"].ToString();
               job.EmpDate = dr["empEntryDate"].ToString(); ;
               job.SuvDate = dr["SuvEntryDate"].ToString();
                job.FiscalYear= dr["FiscalYear"].ToString();
            }
           return job;
       }

       public string AcceptJd(string rowId)
       {
           string sql = "EXEC proc_JobDescription @flag='accept'";
            sql += ",@rowid=" + FilterString(rowId);
           return GetSingleresult(sql);
       }
        public string DisagreeJd(string rowId,string Message)
        {
            string sql = "EXEC proc_JobDescription @flag='disagree'";
            sql += ",@rowid=" + FilterString(rowId);
            sql += ",@servicesJD=" + FilterString(Message);
            return GetSingleresult(sql);
        }
        public string ApproveJd(string rowId)
       {
           string sql = "EXEC proc_JobDescription @flag='approve'";
           sql += ",@rowid=" + FilterString(rowId);
           return GetSingleresult(sql);
       }
        public string CheckFiscalyear(DateTime SDate, string Enddate)
        {
            string result = "";
            if(SDate>Convert.ToDateTime(Enddate))
            {
                result = "Invalid !! Start Date can not be grater than End Date";
                return result;
            }
            string sql = "Select * from FiscalYear where " + FilterString(SDate.ToString("yyyy-MM-dd")) + " Between  EN_YEAR_START_DATE  AND  EN_YEAR_END_DATE;";
            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                result = "";
            var data = ds.Tables[0].Rows[0];

            DateTime sEndDate = Convert.ToDateTime(data["EN_YEAR_END_DATE"]);
            DateTime sStartDate = Convert.ToDateTime(data["EN_YEAR_START_DATE"]);

            if ((Convert.ToDateTime(Enddate)>=sStartDate) && ((Convert.ToDateTime(Enddate) <= sEndDate)))
            {
                result = "Success";
            }else
            {
                result = "Invalid !!  StartDate and  EndDate does not belong to the same fiscalyear";
            }
            return result;

        }
        public DataTable CheckStaffRpt()
       {
           string sql = "EXEC proc_JobDescription @flag='chkstaff'";
           return ExecuteDataset(sql).Tables[0];
       }


    }
}
