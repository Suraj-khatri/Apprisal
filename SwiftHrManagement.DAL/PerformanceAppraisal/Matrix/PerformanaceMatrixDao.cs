using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.PerformanceAppraisal.Matrix
{
   public  class PerformanaceMatrixDao:BaseDAO
    {
        private DbService service;

        public PerformanaceMatrixDao()
        {
            this.service = new DbService();
        }

        public DataSet FindMatrixSetupById(string positionID, string appraisalId)
        {
            var sql = "Exec proc_PerformanceAppraisalMatrix";
            sql += " @flag = 's'";
            sql += ",@positionId=" + this.service.filterstring(positionID);
            sql += ",@apprisalId=" + this.service.filterstring(appraisalId); 
            return this.service.ReturnDataset(sql);
        }

        public DataSet PopulateMatrixSetupDataById(string appraisalId)
        {
            var sql = "Exec proc_PerformanceAppraisalMatrix";
            sql += " @flag = 'all'";
            sql += ",@apprisalId=" + this.service.filterstring(appraisalId);
            sql += ",@raterType=" + 'a';
            return this.service.ReturnDataset(sql);
        }

        public DataRow InsertAppraiseeTask(string appraisalId, string soleComment, string Comments, string otherAchievements, string CommentBy, string raterType, string isAppraiseer, string  setFlag)
        {
            var sql = "Exec [proc_PerformanceAppraisalMatrix] @flag='a'";
            sql += ",@apprisalId=" + this.service.filterstring(appraisalId);
            sql += ",@commentBy=" + this.service.filterstring(CommentBy);
            sql += ",@soleComment=" + filter(soleComment);
            sql += ",@raterTypeFlag=" + filterstring(raterType);
            sql += ",@otherAchievements=" + filter(otherAchievements); ;
            sql += ",@comments=" +filter(Comments);
            sql += ",@isAppraiseer=" + this.service.filterstring(isAppraiseer);
            sql += ",@setFlag=" + this.service.filterstring(setFlag);
            return this.ReturnDataset(sql).Tables[0].Rows[0];
        }

        private String filter(String strVal)
        {
            string str = strVal;
            if (str != "" && str != "0" && str != "-1")
            {
                str = str.Replace("'", "`");
                str = "'" + str + "'";
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }

        public DataTable FindAppraiseeTask(long appraisalId, long commentBy, string raterType)
        {
            var sql = "SELECT soleComment,comments,otherAchievements,specialAssignments FROM appraisalComments where isnull(questionId,'') = '0' and isnull(flag,'') = 't' and appraisalId = " + appraisalId + " and raterTypeFlag=" + filterstring(raterType);
            return this.service.ReturnDataset(sql).Tables[0];
        }

        public DataRow FindAppraiseeTask(string appraisalId, string user)
        {
            var sql = "Exec [proc_PerformanceAppraisalMatrix] @flag='sat'";
            sql += ",@apprisalId=" + this.service.filterstring(appraisalId);
            sql += ",@commentBy=" + this.service.filterstring(user);
            var ds = ReturnDataset(sql);
            var dt =  ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataTable FindFeedBackInfoById(string appraisalId)
        {
            var sql = "Exec proc_PerformanceAppraisal";
            sql += " @flag = 'all'";
            //sql += ",@positionId=" + this.service.filterstring(appraisalId);
            sql += ",@appraisalId=" + this.service.filterstring(appraisalId);
            sql += ",@raterType='a'";
            return this.service.ReturnDataset(sql).Tables[0];

        }
        public DataTable OnSave(string apprisalId, string matrixId, string ratingBy, string rating, string raterBy, string setFlag, string reviewerVisorComment)
        {
            var sql = "Exec [proc_PerformanceAppraisalMatrix]";
            sql += " @flag = 'i'";
            sql += ", @apprisalId=" + this.service.filterstring(apprisalId);
            sql += ", @matrixId='" + matrixId;
            sql += "', @ratingBy=" + this.service.filterstring(ratingBy);
            sql += ", @rating='" + rating;
            sql += "', @ratertype=" +filterstring(raterBy);
            sql += ", @setFlag=" +filterstring(setFlag);
            sql += ", @srComments=" + this.FilterString(reviewerVisorComment);
            return ReturnDataset(sql).Tables[0];
        }

        public DataRow checkPartialOrFinalSave(long appraisalId,string raterType)
        {
            var sql = "select distinct setFlag from appraisalRating where appraisalId =" + this.filterstring(appraisalId.ToString()) + " and raterType = " + this.filterstring(raterType) + "";
            if (raterType.Equals("appraisee"))
                sql = "select distinct flag from appraisalComments where appraisalId =" + this.filterstring(appraisalId.ToString()) + " and raterTypeFlag = 'a' AND flag IS NOT NULL";
            else if (raterType.Equals("super"))
                sql = "select distinct flag from appraisalComments where appraisalId =" + this.filterstring(appraisalId.ToString()) + " and raterTypeFlag = 's' AND flag IS NOT NULL";
            var ds = ReturnDataset(sql);

            if (ds == null)
                return null;

            if (ds.Tables[0].Rows.Count == 0)
                return null;

            return ds.Tables[0].Rows[0];
        }

        public bool ChekSelfRating(string apprisalId)
        {
            var sql = " EXEC proc_allowApprisalRating @flag='chekSelfRating'";
            sql += ",@apprisalId = " + FilterString(apprisalId);
            var result = GetSingleresult(sql);
            if (result.Trim().ToUpper().Equals("TRUE"))
                return true;

            return false;
        }

        public bool IsPartialSave(long appraisalId,string raterType)
        {
            //var sql = "select distinct setFlag from appraisalRating where appraisalId =" + appraisalId + " and setFlag = 'p' and raterType = '" + raterType + "'";
            var sql = "select distinct setFlag from appraisalRating where appraisalId =" + appraisalId + " and raterType = '" + raterType + "'";
            var ds = ReturnDataset(sql);

            if (ds == null)
                return true;

            if (ds.Tables[0].Rows.Count == 0)
                return true;

            var dr = ds.Tables[0].Rows[0];
            if (dr["setFlag"].ToString().Trim().ToLower().Equals("p"))
                return true;
            else
                return false;

           // else if (dr["setFlag"].ToString().Trim().ToLower().Equals("f"))
              //  return false;
            

            //var msg = GetSingleresult(sql);
            //if (msg == "p")
            //    return true;
            //else
            //{
            //    return false;
            //}
        }

        public DataRow InsertComments(string appraisalId, string soleComment, string Comments, string CommentBy)
        {
            var sql = "Exec [proc_PerformanceAppraisalMatrix] @flag='sn',@apprisalId=" + this.service.filterstring(appraisalId)
                        + ",@commentBy=" + this.service.filterstring(CommentBy) + ",@soleComment=" + this.service.filterstring(soleComment) + ",@raterTypeFlag='a',@comments=" + this.service.filterstring(Comments);
            return this.ReturnDataset(sql).Tables[0].Rows[0];
            //return this.service.GetSingleresult(sql);
        }

        public string GetRater(string appraisalId)
        {
            var sql = "select distinct(raterType) from appraisalRating where appraisalId =" + this.service.filterstring(appraisalId) + "and raterType = 'r'";
          return this.service.GetSingleresult(sql);
        }

        public DataTable FindSoleComment(long appraisalId, long commentBy)
        {
            var sql = "SELECT soleComment,comments FROM appraisalComments where commentBy=" + commentBy + " "
            + " and isnull(questionId,'') = '0' and flag='f' and appraisalId = " + appraisalId + " and raterTypeFlag='a'";
            return this.service.ReturnDataset(sql).Tables[0];
        }

        public bool DoesAppraiseeAccess(long empId,long sessionEmpId)
        {
            var sql = "SELECT EMPLOYEE_ID FROM Appraisal WHERE EMPLOYEE_ID = " + empId;
            long DbEmpId =  long.Parse(this.service.GetSingleresult(sql));
            if (DbEmpId == sessionEmpId)
                return true;
            return false;
        }

        public bool DoesSuperVisorAccess(long empId)
        {
            var sql = "SELECT * FROM appraisalSupervisorAssignment WHERE EMP = " + empId + " AND SUPERVISOR_TYPE ='s'  AND record_status = 'y'";
            if (this.service.GetSingleresult(sql) == "")
                return false;
            return true;
        }
        public bool DoesRatingTypeAlreadyExist(string empIdFromSupervisor, string sessionEmpId)
        {
            var sql = "SELECT distinct y.EMP from Appraisal a"
                    + " right join"
                    + " (SELECT EMP FROM appraisalSupervisorAssignment WHERE  record_status = 'y'"
                    + " AND SUPERVISOR = '" + sessionEmpId + "' and SUPERVISOR_TYPE = 'r')y on y.EMP = a.EMPLOYEE_ID "
                    + " where y.EMP ='" + empIdFromSupervisor + "'";
            string dbratingType = GetSingleresult(sql);

            if (empIdFromSupervisor == dbratingType)
                return true;

            return false;


        }


       public bool CheckRole(string appraisalid,string role)
       {
           var sql = "select * from  appraisalSupervisorAssignment where appraisal_id = "+appraisalid+" and SUPERVISOR_TYPE ='"+role+"'";
           string  msg = GetSingleresult(sql);
           if (msg != "")
               return true;

           return false;
       }

        public bool DoesRaterAlreadyExist(string empIdFromSupervisor, string sessionEmpId,long  appraisalId)
        {
            var sql = @"select p.r  REVIEWER_ID from (
		            select SUPERVISOR_TYPE,SUPERVISOR,appraisal_id from appraisalSupervisorAssignment where EMP = "+empIdFromSupervisor+ @" and appraisal_id ="+appraisalId+ @"

	            )sa
	            pivot
	            (
		            max(SUPERVISOR) for SUPERVISOR_TYPE in ([s],[r])
	            )p";
            //var sql = "SELECT REVIEWER_ID from Appraisal a"
            //        + " where a.EMPLOYEE_ID ='" + empIdFromSupervisor + "'";
            string dbratingType = GetSingleresult(sql);

            if (sessionEmpId == dbratingType)
                return true;

            return false;


        }

       public string AppraiseeId(string appraisalId)
       {
            var sql = @"SELECT distinct a.EMPLOYEE_ID FROM Appraisal a
            INNER JOIN 
            appraisalRating  ar
            ON a.ID = ar.appraisalId
            WHERE ar.appraisalId = "+appraisalId+"";
           string id = GetSingleresult(sql);
           return id;

       }

       public DataTable RetreiveComments(string appraisalId)
        {
            var sql = @"select soleComment,comments from appraisalComments where appraisalId = " + appraisalId + " and questionId is null and  raterTypeFlag = 'r'";
            return ReturnDataset(sql).Tables[0];
        }

       public DataRow AllowApprisalRating(string apprisalId, string ratingTypeId, string postionId, string userId, string employeeId)
       {
           var sql = " EXEC proc_allowApprisalRating @flag='allowRating'";
            sql += ",@apprisalId = " + FilterString(apprisalId);
            sql += ",@ratingTypeId  = " + FilterString(ratingTypeId);
            sql += ",@postionId = " + FilterString(postionId);
            sql += ",@userId  = " + FilterString(userId);
            sql += ",@employeeId  = " + FilterString(employeeId);
            return ReturnDataset(sql).Tables[0].Rows[0];
       }

       public bool CheckReviewer(string empId)
       {
           var sql = "SELECT DISTINCT SUPERVISOR FROM appraisalSupervisorAssignment WHERE SUPERVISOR_TYPE='r' and record_status = 'y' and SUPERVISOR = '" + empId + "'";
           string msg = GetSingleresult(sql);
           if(msg!="")
           {
               return true;
           }
           else
           {
               return false;
           }
       }

    

       public override object MapObject(DataRow dr)
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
 