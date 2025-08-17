using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.PerformanceAppraisal.Matrix
{
    public class HRFeedbackDao : DbService
    {

        public DataTable GetSection(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='pc',@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable SetSection(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s2',@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataRow InsertComments(string appraisalId, string questionList, string CommentsList, string CommentBy,string flag,string mailFlag)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='insertRC'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@commentBy=" + filterstring(CommentBy);
            sql += ",@setFlag=" + filterstring(flag);
            sql += ",@raterTypeFlag ='rc'";
            sql += ",@questionId='" + questionList + "'";
            sql += ",@comments='" + CommentsList + "'";
            sql += ",@sendMailFlag=" + filterstring(mailFlag);

            var dt = ReturnDataset(sql).Tables[0];
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public string GetRater(string appraisalId)
        {
            var sql = "select distinct(raterType) from appraisalRating where appraisalId =" + filterstring(appraisalId) + "and raterType = 'r'";
            return GetSingleresult(sql);
        }
        public bool DoesRatingTypeAlreadyExist(string empIdFromSupervisor, string sessionEmpId)
        {
            var sql = "SELECT distinct y.EMP from Appraisal a"
                    + " right join"
                    + " (SELECT EMP FROM appraisalSupervisorAssignment WHERE  record_status = 'y'"
                    + " AND SUPERVISOR = '" + sessionEmpId + "' and SUPERVISOR_TYPE = 'rc')y on y.EMP = a.EMPLOYEE_ID "
                    + " where y.EMP ='" + empIdFromSupervisor + "'";
            string dbratingType = GetSingleresult(sql);

            if (empIdFromSupervisor == dbratingType)
                return true;

            return false;
        }
        public bool DoesActivEmpIsHRC(string sessionEmpId)
        {
            var sql = "select SUPERVISOR from appraisalSupervisorAssignment where SUPERVISOR_TYPE='hrc'"
                    +" and SUPERVISOR=" + sessionEmpId + " and record_status='y'";
            string dbratingType = GetSingleresult(sql);

            if (dbratingType!="")
                return true;
            else
                return false;
        }


        public DataTable OnSaveSoleComment(string appraisalId, string questionId, string comments, string soleComment, string commentBy,string flag,string mailFlag)
        {
            var sql = "Exec proc_appraisalComments";
            sql += " @flag = 'insertRC'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@questionId=" + filterstring(questionId);
            sql += ",@comments=" + filterstring(comments);
            sql += ",@soleComment=" + filterstring(soleComment);
            sql += ",@commentBy=" + filterstring(commentBy);
            sql += ",@raterTypeFlag= 'rc'";
            sql += ",@sFlag=" + filterstring(flag);
            sql += ",@sendMailFlag=" + filterstring(mailFlag);
            
            // sql += ",@raterTypeFlag = "+(commentBy == CEOID().ToString() ? "'c'" : "'r'");
            return ReturnDataset(sql).Tables[0];
        }
    }
}
