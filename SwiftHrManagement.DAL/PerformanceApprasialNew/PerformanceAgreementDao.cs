using System;
using System.Data;
using SwiftHrManagement.web.DAL;
using SwiftHrManagement.DAL.Models;
using System.Collections.Generic;

namespace SwiftHrManagement.DAL.PerformanceApprasialNew
{
    public class PerformanceAgreementDao : SwiftDao
    {
        public DbResult Update(string user, string kraNoOfQuestions, string kraTotalWeightage, string kraRatingCeiling, string kpiPerKraQuestionNo,
                               string kpiPerKraTotalWeightAge, string kpiPerKraRatingCeiling, string criticalJobsQuestionNo, string criticalJobsTotalWeightAge,
                               string criticalJobsRatingCeiling, string trainingAssesQuestionNo, string trainingAssesTotalWeightAge, string trainingAssesRatingCeiling)
        {
            string sql = "exec sp_performanceAgreement @flag='i'";
            sql += ",@user =" + FilterString(user);
            sql += ",@kraNoOfQuestions =" + FilterString(kraNoOfQuestions);
            sql += ",@kraTotalWeightage =" + FilterString(kraTotalWeightage);
            sql += ",@kraRatingCeiling =" + FilterString(kraRatingCeiling);
            sql += ",@kpiPerKraQuestionNo =" + FilterString(kpiPerKraQuestionNo);
            sql += ",@kpiPerKraTotalWeightAge =" + FilterString(kpiPerKraTotalWeightAge);
            sql += ",@kpiPerKraRatingCeiling =" + FilterString(kpiPerKraRatingCeiling);
            sql += ",@criticalJobsQuestionNo =" + FilterString(criticalJobsQuestionNo);
            sql += ",@criticalJobsTotalWeightAge =" + FilterString(criticalJobsTotalWeightAge);
            sql += ",@criticalJobsRatingCeiling	=" + FilterString(criticalJobsRatingCeiling);
            sql += ",@trainingAssesQuestionNo =" + FilterString(trainingAssesQuestionNo);
            sql += ",@trainingAssesTotalWeightAge =" + FilterString(trainingAssesTotalWeightAge);
            sql += ",@trainingAssesRatingCeiling =" + FilterString(trainingAssesRatingCeiling);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DataTable GetAppraisalEmployeeData(string fromDate, string toDate, string role, string user)
        {
            string sql = "exec sp_performanceAgreement @flag='appEmpList'";
            sql += ",@fromDate =" + FilterString(fromDate);
            sql += ",@toDate =" + FilterString(toDate);
            sql += ",@role =" + FilterString(role);
            sql += ",@user =" + FilterString(user);
            return ExecuteDataset(sql).Tables[0];
        }

        public DbResult ReviewInitiation(string user, string sessionId, string empId, string currentBranch, string currentDepartment, string currentSubDepartment, string currentSubDepartment2, string currentPosition ,
                                         string currentFunctionalTitle, string dateOfJoining, string Supervisor, string ReviewingOfficer, string paEffectiveFrom,
                                         string paEffectiveTo, string lastPromotedDate, string mode, string appId)
        {
            string sql = "exec sp_performanceAgreement ";
            sql += " @flag = " + (mode == "Update" ? "'ri_update'" : "'ri'");
            sql += ",@user =" + FilterString(user);
            sql += ",@session_id=" + FilterString(sessionId);
            sql += ",@empId=" + FilterString(empId);
            sql += ",@currentBranch  =" + FilterString(currentBranch);
            sql += ",@currentDepartment  =" + FilterString(currentDepartment);
            sql += ",@currentSubDepartment  =" + FilterString(currentSubDepartment);
            sql += ",@currentSubDepartment2  =" + FilterString(currentSubDepartment2);
            sql += ",@currentFunctionalTitle  =" + FilterString(currentFunctionalTitle);
            sql += ",@currentPosition  =" + FilterString(currentPosition);
            sql += ",@dateOfJoining  =" + FilterString(dateOfJoining);
            sql += ",@lastPromotedDate  =" + FilterString(dateOfJoining);
            //sql += ",@timeSpentInTheCurrentBranchDept  =" + FilterString(timeSpentInTheCurrentBranchDept);
            //sql += ",@timeSpentInTheCurrentPosition  =" + FilterString(timeSpentInTheCurrentPosition);
            sql += ",@Supervisor =" + FilterString(Supervisor);
            sql += ",@ReviewingOfficer =" + FilterString(ReviewingOfficer);
            sql += ",@paEffectiveFrom  =" + FilterString(paEffectiveFrom);
            sql += ",@paEffectiveTo =" + FilterString(paEffectiveTo);
            sql += ",@appId =" + FilterString(appId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult UpdateKriKpi(string user, string kraTopic, string kraWeigth, string kpiTopic, string kpiWeight, string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='i'";
            sql += ",@user =" + FilterString(user);
            sql += ",@kraTopic =" + FilterString(kraTopic);
            sql += ",@kraWeight =" + FilterString(kraWeigth);
            sql += ",@kpiTopic =" + FilterString(kpiTopic);
            sql += ",@kpiWeight =" + FilterString(kpiWeight);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult UpdateLevelKriKpi(string user, string kraTopic, string kraWeigth, string kpiTopic, string kpiWeight, string lrowId,string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='i'";
            sql += ",@user =" + FilterString(user);
            sql += ",@kraTopic =" + FilterString(kraTopic);
            sql += ",@kraWeight =" + FilterString(kraWeigth);
            sql += ",@kpiTopic =" + FilterString(kpiTopic);
            sql += ",@kpiWeight =" + FilterString(kpiWeight);
            sql += ",@departId =" + FilterString(DepartId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult EditData(string kraTopic, string kraWeight, string kpiTopic, string kpiWeight, string user, string rowId, string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='u'";
            sql += ",@kraTopic =" + FilterString(kraTopic);
            sql += ",@kraWeight =" + FilterString(kraWeight);
            sql += ",@kpiTopic =" + FilterString(kpiTopic);
            sql += ",@kpiWeight =" + FilterString(kpiWeight);
            sql += ",@user =" + FilterString(user);
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult EditLevelKriKpiData(string kraTopic, string kraWeight, string kpiTopic, string kpiWeight, string user, string rowId, string lrowId,string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='u'";
            sql += ",@kraTopic =" + FilterString(kraTopic);
            sql += ",@kraWeight =" + FilterString(kraWeight);
            sql += ",@kpiTopic =" + FilterString(kpiTopic);
            sql += ",@kpiWeight =" + FilterString(kpiWeight);
            sql += ",@user =" + FilterString(user);
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@LrowId =" + FilterString(lrowId);
            sql += ",@departId =" + FilterString(DepartId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult DeleteReocrd(string rowId)
        {
            string sql = "exec sp_performanceAgreement @flag='del', @rowId=" + FilterString(rowId) + "";

            return ParseDbResult(sql);
        }
        public DbResult DeleteLevelRecord(string rowId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='del', @rowId=" + FilterString(rowId) + "";

            return ParseDbResult(sql);
        }



        //levelAppraisalMatrix
        #region
        public DataTable GetLevelAppraisalMatrixDetails(string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='grid'";
            sql += ",@departId =" + FilterString(DepartId);
            return ExecuteDataset(sql).Tables[0];
        }
        public DataTable GetDepartAppraisalMatrixDetails(string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='depgrid'";
            sql += ",@DepartId =" + FilterString(DepartId);
            return ExecuteDataset(sql).Tables[0];
        }
        public string  ReturnDepartname(string deptId)
        {
            string result = "";
           
            string sql = "Select DETAIL_TITLE from StaticDataDetail where ROWID = " + FilterString(deptId);
            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                result = "";
            var data = ds.Tables[0].Rows[0];
            result= data["DETAIL_TITLE"].ToString();



            return result;

        }
        #endregion 

        public List<KraKpiGrid> GetPrintKraList(string appid)
        {
            string sql = @"SELECT                           
			  appraisalid,                          
			  rowid,                           
			  kratopic,                           
			  kpitopic,                           
			  kraweightage,                           
			  kpiweightage                           
			  FROM   appraisalmatrix WITH ( nolock )                           
			  WHERE  appraisalid ="+ appid + @"                           
			  ORDER  BY rowid ASC";
            List<KraKpiGrid> Result = new List<KraKpiGrid>();
            try
            {
                DataTable Dt = ExecuteDataset(sql).Tables[0];
                foreach (DataRow item in Dt.Rows)
                {

                    try
                    {
                        Result.Add(new KraKpiGrid
                        {
                            RowId = Convert.ToInt64(item["RowId"].ToString()),
                            KpiTopic = item["KpiTopic"].ToString(),
                            KpiWeightage = Convert.ToDecimal(item["KpiWeightage"].ToString()),
                            KraTopic = item["KraTopic"].ToString(),
                            kraWeightage = Convert.ToDecimal(item["KraWeightage"].ToString()),
                            AppId = Convert.ToInt32(item["appraisalid"].ToString())

                        });
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }


                }
            }
            catch (Exception ex)
            {

                return null;
            }


            return Result;
        }
        public List<KraKpiGrid> GetKRAKPIDate(string empId, string appId,string user)
        {
            List<KraKpiGrid> Result = new List<KraKpiGrid>();
            try
            {
                string sql = "exec sp_performanceAgreement @flag='grid'";
                sql += ",@empId =" + FilterString(empId);
                sql += ",@appId =" + FilterString(appId);
                sql += ",@user =" + FilterString(user);
                
                DataTable Dt = ExecuteDataset(sql).Tables[0];
                foreach (DataRow item in Dt.Rows)
                {

                    try
                    {
                        Result.Add(new KraKpiGrid
                        {
                            RowId = Convert.ToInt64(item["RowId"].ToString()),
                            KpiTopic = item["KpiTopic"].ToString(),
                            KpiWeightage = Convert.ToDecimal(item["KpiWeightage"].ToString()),
                            KraTopic = item["KraTopic"].ToString(),
                            kraWeightage = Convert.ToDecimal(item["KraWeightage"].ToString()),
                            AppId = Convert.ToInt32(item["appraisalid"].ToString())

                        });
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }


                }
            }
            catch (Exception)
            {

                return null;
            }
            
         
            return Result;
        }

        public DataTable getAgreementStatus(string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='getStatus'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable GetCriticalJobsDate(string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='c_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable GetLevelCriticalJobsDate(string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='c_grid'";
            sql += ",@DepartId =" + FilterString(DepartId);
            return ExecuteDataset(sql).Tables[0];
        }

        public DbResult UpdateCriticalJobs(string user, string objectives, string deductionScore, string employee, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='ci'";
            sql += ",@user =" + FilterString(user);
            sql += ",@objectives =" + FilterString(objectives);
            sql += ",@deductionScore =" + FilterString(deductionScore);
            sql += ",@empId =" + FilterString(employee);
            sql += ",@appId =" + FilterString(appId);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult UpdateLevelCriticalJobs(string user, string objectives, string deductionScore, string DepartId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='ci'";
            sql += ",@user =" + FilterString(user);
            sql += ",@objectives =" + FilterString(objectives);
            sql += ",@deductionScore =" + FilterString(deductionScore);
            sql += ",@DepartId =" + FilterString(DepartId);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult EditDataCriticalJobs(string objectives, string deductionScore, string user, string rowId, string employee, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='cu'";
            sql += ",@objectives =" + FilterString(objectives);
            sql += ",@deductionScore =" + FilterString(deductionScore);
            sql += ",@user =" + FilterString(user);
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@empId =" + FilterString(employee);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(sql);
        }

        public DbResult EditDataLevelCriticalJobs(string objectives, string deductionScore, string user, string rowId, string Departid)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='cu'";
            sql += ",@objectives =" + FilterString(objectives);
            sql += ",@deductionScore =" + FilterString(deductionScore);
            sql += ",@user =" + FilterString(user);
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@departId =" + FilterString(Departid);

            return ParseDbResult(sql);
        }

        public DbResult DeleteReocrdCriticalJobs(string rowId)
        {
            string sql = "exec sp_performanceAgreement @flag='cdel', @rowId=" + FilterString(rowId) + "";

            return ParseDbResult(sql);
        }

        public DbResult DeleteReocrdLevelCriticalJobs(string rowId)
        {
            string sql = "exec proc_LevelAppraisalMatrix @flag='cdel', @rowId=" + FilterString(rowId) + "";

            return ParseDbResult(sql);
        }


        public DataTable GetPerformanceRatingData()
        {
            string sql = "exec sp_performanceAgreement @flag='pr_grid'";

            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable GetProposedTrainingData(string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='pr_pt_grid'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql).Tables[0];
        }

        public DbResult EditDataPerformanceRating(string proposedArea, string criticality, string date, string user, string rowId, string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='pru'";
            sql += ",@proposedArea =" + FilterString(proposedArea);
            sql += ",@criticality =" + FilterString(criticality);
            sql += ",@pRDate =" + FilterString(date);
            sql += ",@user =" + FilterString(user);
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult UpdateCriticalPerformanceRating(string user, string proposedArea, string criticality, string date, string empId, string remarks, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='pri'";
            sql += ",@user =" + FilterString(user);
            sql += ",@proposedArea =" + FilterString(proposedArea);
            sql += ",@criticality =" + FilterString(criticality);
            sql += ",@pRDate =" + FilterString(date);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@remarks =" + FilterString(remarks);
            sql += ",@appId =" + FilterString(appId);


            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DbResult DeleteRecordPerformanceRating(string rowId)
        {
            string sql = "exec sp_performanceAgreement @flag='prdel', @rowId=" + FilterString(rowId) + "";

            return ParseDbResult(sql);
        }

        public DataRow SelectById(string user, string empId)
        {
            string sql = "EXEC sp_performanceAgreement";
            sql += " @flag = 'a'";
            sql += ", @user = " + FilterString(user);
            sql += ", @empId = " + FilterString(empId);

            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

        public DataRow SelectByIdPerformance(string empId, string appId,string User)
        {
            string sql = "EXEC sp_performanceAgreement";
            sql += " @flag = 'pas'";
            sql += ", @user = " + FilterString(User);
            sql += ", @empId = " + FilterString(empId);
            sql += ", @appId = " + FilterString(appId);

            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

        public DataRow ViewDataPerformanceRating(string rowId, string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='pr_ViewData'";
            sql += ",@rowId =" + FilterString(rowId);
            sql += ",@empId =" + FilterString(empId);
            sql += ", @appId = " + FilterString(appId);

            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

        //public DbResult SaveAckApprData(string emp, string appChkd, string commentType, string empId)
        //{
        //    string sql = "exec performance_Ackn @flag='Appr'";
        //    sql += ",@user =" + FilterString(emp);
        //    sql += ",@checked =" + FilterString(appChkd);
        //    sql += ",@commenterType =" + FilterString(commentType);
        //    sql += ",@empId =" + FilterString(empId);

        //    return ParseDbResult(sql);
        //}
        //public DbResult SaveAckOffData(string emp, string appChkd,string comment,string commentType,string empId)
        //{
        //    string sql = "exec performance_Ackn @flag='Ofcr'";
        //    sql += ",@user =" + FilterString(emp);
        //    sql += ",@checked =" + FilterString(appChkd);
        //    sql += ",@comment =" + FilterString(comment);
        //    sql += ",@commenterType =" + FilterString(commentType);
        //    sql += ",@empId =" + FilterString(empId);

        //    return ParseDbResult(sql);
        //}
        public DbResult SaveAckHRDData(string emp, string appChkd, string comment, string commentType, string empId, string appId)
        {
            string sql = "exec performance_Ackn @flag='HRD'";
            sql += ",@user =" + FilterString(emp);
            sql += ",@checked =" + FilterString(appChkd);
            sql += ",@comment =" + FilterString(comment);
            sql += ",@commenterType =" + FilterString(commentType);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(sql);
        }
        public DataTable DisagreeAck(string emp, string comment, string commentType, string empId, string appId)
        {
            string sql = "exec performance_Ackn @flag='Disagreed'";
            sql += ",@user =" + FilterString(emp);
            sql += ",@comment =" + FilterString(comment);
            sql += ",@commenterType =" + FilterString(commentType);
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ExecuteDataTable(sql);
        }
        public DataSet AckData(string empId, string appId)
        {
            string sql = "exec performance_Ackn @flag='AckData'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);
            return ExecuteDataset(sql);
        }

        public DbResult DeleteAppraisalInitiatedRecord(string empId, string appId)
        {
            string sql = "exec sp_performanceAgreement @flag='delAppIniRecord'";
            sql += ",@empId =" + FilterString(empId);
            sql += ",@appId =" + FilterString(appId);

            return ParseDbResult(sql);
        }
        public DataTable CheckHrAdmin(string empId)
        {
            string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND s.DETAIL_TITLE = 'HR Admin'
                                AND a.Name = " + FilterString(empId);
            return ExecuteDataset(sql).Tables[0];

        }

        public string CheckFiscalyear(DateTime SDate, DateTime Enddate)
        {
            string result = "";
            if (SDate > Convert.ToDateTime(Enddate))
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

            bool Sd = Convert.ToDateTime(SDate).Date >= sStartDate && Convert.ToDateTime(SDate).Date <= sEndDate;
            bool Ed = Convert.ToDateTime(Enddate).Date >= sStartDate && Convert.ToDateTime(Enddate).Date <= sEndDate;
            if (Sd & Ed)
            {
                result = "Success";
            }
            else
            {
                result = "Invalid !!  StartDate and  EndDate does not belong to the same fiscalyear";
            }
            return result;

        }
    }
}
