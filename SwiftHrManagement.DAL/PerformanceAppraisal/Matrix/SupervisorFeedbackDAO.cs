using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.DAL.PerformanceAppraisal.Matrix
{
    public class SupervisorFeedbackDAO : BaseDAO
    {
        //public DataSet FindMatrixSetupById(string appraisalId, string raterType)
        //{
        //    var sql = "Exec [proc_AppraiserRating]";
        //    sql += " @flag = 's'";
        //    sql += ",@appraisalId=" + filterstring(appraisalId);
        //    sql += ",@raterType=" + filterstring(raterType);
        //    return ReturnDataset(sql);
        //}

        public DataSet FindMatrixSetupById(string positionID, string appraisalId)
        {
            var sql = "Exec proc_PerformanceAppraisalMatrix";
            sql += " @flag = 's'";
            sql += ",@positionId=" + filterstring(positionID);
            sql += ",@apprisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql);

        }

        public DataTable GetSection2(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='pc',@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable SetSection2(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s2',@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetSection6(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s6'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetSection8(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s8'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }


        public DataTable InsertRating(string appraisalId, string matrixId, string ratingValue, string ratingBy, string partialFlag, string superVisorComment)
        {
            var sql = "Exec [proc_AppraiserRating] @flag = 'ir'";
            sql += ", @appraisalId = " + FilterString(appraisalId);
            sql += ", @ratingBy = " + FilterString(ratingBy);
            sql += ", @raterType ='s'";
            sql += ", @matrixId = " + FilterString(matrixId);
            sql += ", @setFlag = " + FilterString(partialFlag);
            sql += ", @rating = " + FilterString(ratingValue);
            sql += ", @srComments = " + FilterString(superVisorComment);

            return ReturnDataset(sql).Tables[0];
        }

        public DataRow InsertComments(string appraisalId, string questionList, string CommentsList, string CommentBy, string raterTypeFlag)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='i'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@commentBy=" + filterstring(CommentBy);
            sql += ",@raterTypeFlag=" + filterstring(raterTypeFlag);
            sql += ",@questionId='" + questionList + "'";
            sql += ",@comments='" + CommentsList + "'";

            var dt = ReturnDataset(sql).Tables[0];
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];

        }

        public DataRow UpdateHrComments(string appraisalId, string commentBy, string letterIssuedOn, string incrementEffectedOn)
        {
            var sql = "EXEC proc_AppraiserRating @flag='hDepComment'";
            sql += ",@appraisalId=" + FilterString(appraisalId);
            sql += ",@commentBy=" + FilterString(commentBy);
            sql += ",@letterIssuedOn=" + FilterString(letterIssuedOn);
            sql += ",@incrementEffectedOn=" + FilterString(incrementEffectedOn);
            var dt = ReturnDataset(sql).Tables[0];
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataRow GetHrDepartMentComment(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='getHdepComment',@appraisalId=" + filterstring(appraisalId);
            var dt = ReturnDataset(sql).Tables[0];
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }

        public DataTable OnSaveSoleComment(string appraisalId, string questionId, string comments, string soleComment, string commentBy)
        {
            var sql = "Exec proc_appraisalComments";
            sql += " @flag = 'i'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@questionId=" + filterstring(questionId);
            sql += ",@comments=" + filter(comments);
            sql += ",@soleComment=" + filterstring(soleComment);
            sql += ",@commentBy=" + filterstring(commentBy);
            sql += ",@raterTypeFlag= 'r'";
            // sql += ",@raterTypeFlag = "+(commentBy == CEOID().ToString() ? "'c'" : "'r'");
            return ReturnDataset(sql).Tables[0];
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

        public DataTable OnSaveSoleCommentCEO(string appraisalId, string questionId, string comments, string soleComment, string commentBy)
        {
            var sql = "Exec proc_appraisalComments";
            sql += " @flag = 'i'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@questionId=" + filterstring(questionId);
            sql += ",@comments=" + filterstring(comments);
            sql += ",@soleComment=" + filterstring(soleComment);
            sql += ",@commentBy=" + filterstring(commentBy);
            sql += ",@raterTypeFlag= 'c'";
            // sql += ",@raterTypeFlag = "+(commentBy == CEOID().ToString() ? "'c'" : "'r'");
            return ReturnDataset(sql).Tables[0];
        }


        public DataTable FindSoleComment(long appraisalId, long commentBy, string raterType)
        {
            var sql = "SELECT soleComment,comments FROM appraisalComments where commentBy=" + filterstring(commentBy.ToString()) + " "
            + " and isnull(questionId,'') = '0' and appraisalId = " + filterstring(appraisalId.ToString()) + " and raterTypeFlag=" + filterstring(raterType);
            return ReturnDataset(sql).Tables[0];
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
                    + " AND SUPERVISOR = '" + sessionEmpId + "' and SUPERVISOR_TYPE = 's')y on y.EMP = a.EMPLOYEE_ID "
                    + " where y.EMP ='" + empIdFromSupervisor + "'";
            string dbratingType = GetSingleresult(sql);

            if (empIdFromSupervisor == dbratingType)
                return true;

            return false;
        }

        public bool DoesReviewerAlreadyExits(string empIdFromSupervisor, string sessionEmpId)
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



        public string OnReject(string comments, string raterType, string appraisalId, string matrixId)
        {
            var sql = "exec [proc_AppraiserRating] @flag='rj',@R_comments= " + filterstring(comments) + ","
                      + "@appraisalId=" + appraisalId + ",@matrixId=" + matrixId + ",@raterType=" + filterstring(raterType);
            string msg = GetSingleresult(sql);
            return msg;

        }

        public bool CheckRole(string ID)
        {
            var sql = "select * from StaticDataDetail where TYPE_ID =62 and ROWID not in(743) and ROWID in (" + ID + ")";
            return CheckStatement(sql);

        }

        public string CheckAlreadyReject(string appraisalId, string matrixId, string raterType)
        {
            string msg;
            var sql = "SELECT R_flag flag FROM appraisalRating WHERE appraisalId = " + appraisalId + " AND matrixId = " + matrixId + " AND raterType = " + filterstring(raterType) + " and R_flag is not null ";
            string returnMsg = GetSingleresult(sql);
            if (returnMsg == "")
            {
                return msg = "0";
            }
            else
            {
                return msg = "1";
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
