using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;


namespace SwiftHrManagement.DAL.ExitInterview
{
   public class ExitInterViewDao:BaseDAOInv
    {
        public string OnGiveQuestinAns(string questionType,string questionAns,string sessionId)
        {
            var sql = "Exec [proc_exitInterview]";
                sql += " @flag = 'iq'";
                sql += ", @questionType = " + filterstring(questionType);
                sql += ", @questionAns=" + filterstring(questionAns);
                sql += ", @sessionId=" + filterstring(sessionId);
            return GetSingleresult(sql);   
        }

        public string OnFinalSave(string exitIntId,string branch, string dept, string empId,string exitReason,string comments,string createdBy,string sessionId,string discountID)
        {
            var sql = "Exec [proc_exitInterview]";
                        sql += "@flag =" + (exitIntId == "0" ? "'ie'" : "'ue'");
                        sql += ", @exitIntId = " + filterstring(exitIntId);
                        sql += ", @branch = " + filterstring(branch);
                        sql += ", @dept=" + filterstring(dept);
                        sql += ", @empId=" + filterstring(empId);
                        sql += ", @exitReason=" + filterstring(exitReason);
                        sql += ", @comments=" + filterstring(comments);
                        sql += ", @createdBy=" + filterstring(createdBy);
                        sql += ", @sessionId=" + filterstring(sessionId);
                        sql += ", @discountID=" + filterstring(discountID);
            return GetSingleresult(sql); 
        }       	     

        public DataTable FindQusAnsById(string sessionId,string exitId)
        {
            var sql = "Exec [proc_exitInterview]";
            sql += " @flag = 'sq'";
            sql += ", @sessionId=" + filterstring(sessionId);
            sql += ", @exitIntId=" + filterstring(exitId);
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable OnPopulateQuesAns(string exitQuesId)
        {
            var sql = "select questionType,questionAns from exitInterviewQuestion  where exitIntQuesId = " + exitQuesId + "";
            return ExecuteDataset(sql).Tables[0];
        }
        public DataTable PopulateData(string exitId)
        {
            var sql = "select exitReason,comments from exitInterview  where exitIntId = " + exitId + "";
            return ExecuteDataset(sql).Tables[0];
        }
     
        public string DeleteRecord(string exitId)
        {
            var sql = "Exec [proc_exitInterview]";
            sql += " @flag = 'd'";
            sql += ", @exitIntQuesId=" + filterstring(exitId);
            return GetSingleresult(sql);
        }

       public string EditQueAns(string questionType,string questionAns,string exitquesId,string exitId)
        {
            var sql = "Exec [proc_exitInterview]";
                sql += " @flag = 'e'";
                sql += ", @questionType=" + filterstring(questionType);
                sql += ", @questionAns=" + filterstring(questionAns);
                sql += ", @exitIntQuesId=" + filterstring(exitquesId);
                sql += ", @exitIntId=" + filterstring(exitId);
                return GetSingleresult(sql);
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
