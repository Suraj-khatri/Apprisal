using SwiftHrManagement.DAL.Models;
using SwiftHrManagement.web.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SwiftHrManagement.DAL.PerformanceApprasialNew
{
    public class PerformanceReviewDao : SwiftDao
    {
        public DataTable GetAppraisalReviewEmployeeData(string fromDate, string toDate, string user)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='appEmpList'";
            sql += ",@fromDate =" + FilterString(fromDate);
            sql += ",@toDate =" + FilterString(toDate);
            sql += ",@empId =" + FilterString(user);
            return ExecuteDataset(sql).Tables[0];
        }

        public DataRow SelectByIdPerformanceReview(string empId, string appId)
        {
            string sql = "EXEC proc_PerformanceAppraisalReview";
            sql += " @flag = 'pas'";
            //sql += ", @user = " + FilterString(user);
            sql += ", @empId = " + FilterString(empId);
            sql += ", @appId = " + FilterString(appId);

            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }
        #region KRAKPI
        public List<KraKpiGrid> GetKRAKPIData(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='krakpigrid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            List<KraKpiGrid> Result = new List<KraKpiGrid>();
            DataTable Dt = ExecuteDataset(sql).Tables[0];
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow item in Dt.Rows)
                {

                    Result.Add(new KraKpiGrid
                    {
                        RowId = Convert.ToInt64(item["rowId"].ToString()),
                        KraTopic = item["kraTopic"].ToString(),
                        KpiTopic = item["kpiTopic"].ToString(),
                        kraWeightage = String.IsNullOrEmpty(item["kraWeightage"].ToString()) ? 0 : Convert.ToDecimal(item["kraWeightage"].ToString()),
                        KpiWeightage = String.IsNullOrEmpty(item["kpiWeightage"].ToString()) ? 0 : Convert.ToDecimal(item["kpiWeightage"].ToString()),
                        PAchievement = String.IsNullOrEmpty(item["performanceAchievement"].ToString()) ? 0 : Math.Round(Convert.ToDecimal(item["performanceAchievement"].ToString()),2),
                        PerformanceRemarks = item["performanceRemarks"].ToString(),
                        Variance = String.IsNullOrEmpty(item["variance"].ToString()) ? 0 : Math.Round(Convert.ToDecimal(item["variance"].ToString()),2),
                        Rating = String.IsNullOrEmpty(item["Rating"].ToString()) ? 0 : Math.Round(Convert.ToDecimal(item["Rating"].ToString()),2),
                        performanceScore = String.IsNullOrEmpty(item["performanceScore"].ToString()) ? 0 : Math.Round(Convert.ToDecimal(item["performanceScore"]),2),
                        Status = item["Status"].ToString(),



                    });

                }

            }
            return Result;
        }
        public DbResult SaveKRAKPIRating(string sb, string user, string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveKRAKPI'";
            sql += ",@xml =" + FilterString(sb);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@user =" + FilterString(user);
            sql += ",@appId =" + FilterString(appId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        #endregion
        #region Critical Jobs
        public DataTable GetCriticalJobsData(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='c_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }

        public string GetFiscalYear(string appId)
        {
            
            string sql = "select FiscalYear  from appraisalInitation i where i.appraisalId="+appId;
           return GetSingleResult(sql);
          
        }
        public DbResult SaveCJRating(string sb, string user, string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveCJR'";
            sql += ",@xml =" + FilterString(sb);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@user =" + FilterString(user);
            sql += ",@appId =" + FilterString(appId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        #endregion
        #region performance Rating
        public DataSet GetProposedTrainingData(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='pr_pt_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql);
        }
        public DataTable GetPerformanceRatingData()
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='pr_grid'";

            return ExecuteDataset(sql).Tables[0];
        }
        public DbResult SavePerformanceRating(string sb,string prChkAck, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SavePR'";
            sql += ",@appId =" + FilterString(appId);
            sql += ",@prChkAck =" + FilterString(prChkAck);
            sql += ",@xml =" + FilterString(sb);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }


        #endregion
        #region score
        public DataSet GetScoreData(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='score_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql);
        }
        #endregion
        #region Competency
        public DataTable GetCompetencyData(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='comp_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }

        public string CountPR(string empId, string appId)
        {
            string sql = "select count(*) from ProposedTraining where AppraisalId=" + appId;
           
            return  GetSingleResult(sql);
        }
        public string ValidateKraKpi(string appid)
        {
            string sql = "exec sp_performanceAgreement @flag='krakapivalidate'";
            sql += ",@appId =" + FilterString(appid);
            return GetSingleResult(sql);
        }
        public string CheckPerformanceRatingAck(string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='chkPrAck'";
            sql += ",@appId =" + FilterString(appId);
            return GetSingleResult(sql);
        }
        public DbResult SaveCompetencyRating(string xml,string user,string empId,string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveCompetency'";
            sql += ",@xml =" + FilterString(xml);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@user =" + FilterString(user);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        #endregion
        public DbResult SaveSupervisorComment(string an1, string an2, string an3, string an4, string an5, string remarks, string Y, string supervisor, string user, string Appraisee, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveSupervisorComment'";
            //sql += ",@chkKRA =" + FilterString(t);
            sql += ",@an1 =" + FilterString(an1);
            sql += ",@an2 =" + FilterString(an2);
            sql += ",@an3 =" + FilterString(an3);
            sql += ",@an4 =" + FilterString(an4);
            sql += ",@an5 =" + FilterString(an5);
            sql += ",@remarks =" + FilterString(remarks);
            sql += ",@checked =" + FilterString(Y);
            sql += ",@commenterType =" + FilterString(supervisor);
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(Appraisee);
            sql += ",@appId =" + FilterString(appId);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public string SaveAppraiseeComment(string remarks,  string commenterType, string user, string Appraisee, string appId,string Comment)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveAppraiseeComment'";
            sql += ",@remarks =" + FilterString(remarks);
            sql += ",@commenterType =" + FilterString(commenterType);
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(Appraisee);
            sql += ",@appId =" + FilterString(appId);
            sql += ",@an1 =" + FilterString(Comment);
            return GetSingleResult(sql);
        }
        public DataTable getAppraiseeComment(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getAppraiseeComment'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }
        public DataTable getSupervisorComment(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getSupervisorComment'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }
        public string getReviewerType(string empId, string user, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getReviewerType'";
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return GetSingleResult(sql);
        }
        public DbResult SaveRevComment(string txtRevOfficer, string txtRevReason, string sb, string empId, string user, string revRemarks, string appId)
        {
             string sql = "exec proc_PerformanceAppraisalReview @flag='SaveRevComment'";
             sql += ",@an6 =" + FilterString(txtRevOfficer);
             sql += ",@an7 =" + FilterString(txtRevReason);
             sql += ",@xml =" + FilterString(sb);
             sql += ",@empId =" + FilterString(empId);
             sql += ",@user =" + FilterString(user);
             sql += ",@remarks =" + FilterString(revRemarks);
             sql += ",@appId =" + FilterString(appId);
             return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult DisagreeComment(string empId, string user,string appId,string Reason)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='disagreeComment'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@user =" + FilterString(user);
            sql += ",@appId =" + FilterString(appId);
            sql += ",@remarks =" + FilterString(Reason);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DataSet getReviewerComment(string empId,string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getReviewerComment'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql);
        }
        public DataSet getComMemberComment(string empId, string appId,string UserId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getComMemberComment'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            sql += ",@user =" + FilterString(UserId);
            return ExecuteDataset(sql);
        }
        public DataTable getCommitteeMembers(string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='getCommitteeMembers'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataTable(sql);

        }
        public DbResult SaveComMemberComment(string txtComMember, string user, string empId, string remark, string instruction, char freeze, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveComMemberComment'";
            sql += ",@an9 =" + FilterString(txtComMember);
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@remarks =" + FilterString(remark);
            sql += ",@freeze =" + FilterString(freeze.ToString());
            sql += ",@an10 =" + FilterString(instruction);
            sql += ",@appId =" + FilterString(appId);

             return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult UpdateComMemberComment(string txtComMember, string user, string empId, string remark, string instruction, char freeze, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='UpdateComMemberComment'";
            sql += ",@an9 =" + FilterString(txtComMember);
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@remarks =" + FilterString(remark);
            sql += ",@freeze =" + FilterString(freeze.ToString());
            sql += ",@an10 =" + FilterString(instruction);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult SaveCEOComment(string txtCEO, string user, string empId, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='SaveCEOComment'";
            sql += ",@an8 =" + FilterString(txtCEO);
            sql += ",@user =" + FilterString(user);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult SendDisagreeMail(string empName, string approver, string appId)
        {
            string sql = "exec proc_PerformanceAppraisalReview @flag='DisagreeMail'";
            sql += ",@empId =" + FilterString(empName);
            sql += ",@user =" + FilterString(approver);
            sql += ",@appId =" + FilterString(appId);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
    }
}
