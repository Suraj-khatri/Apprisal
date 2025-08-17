using System.Data;

namespace SwiftHrManagement.DAL.PerformanceApprasialNew
{
    public class AppraisalDAO : BaseDAO
    {
        public string QuestionCountSetup(string kraNoQsns, string kraTotalWt, string kraRating, string kpiNoQsn, string kpiTotalWt, string kpiRating,
            string criticalNoQsns, string criticalTotalWt, string criticalRating, string trainNoQsn, string trainTotalWt, string trainRating, string user)
        {
            string sql = "exec performance_proc @flag='qsn'";
            sql += ",@KraQuestionNo =" +filterstring(kraNoQsns);			
			sql += ",@KraTotalWeightAge =" +filterstring(kraTotalWt);			
			sql += ",@KraRatingCeiling =" +filterstring(kraRating);
			sql += ",@KpiPerKraQuestionNo =" +filterstring(kpiNoQsn);
			sql += ",@KpiPerKraTotalWeightAge =" +filterstring(kpiTotalWt);
			sql += ",@KpiPerKraRatingCeiling =" +filterstring(kpiRating);
			sql += ",@CriticalJobsQuestionNo =" +filterstring(criticalNoQsns);
			sql += ",@CriticalJobsTotalWeightAge =" +filterstring(criticalTotalWt);
			sql += ",@CriticalJobsRatingCeiling	=" +filterstring(criticalRating);
			sql += ",@TrainingAssesQuestionNo =" +filterstring(trainNoQsn);
			sql += ",@TrainingAssesTotalWeightAge =" +filterstring(trainTotalWt);
			sql += ",@TrainingAssesRatingCeiling =" +filterstring(trainRating);
            sql += ",@CreatedBy =" + filterstring(user);
            
            return GetSingleresult(sql);
        }

        public string QuestionCountSetup(string qstnType,string noOfQstn,string totalWeightage,string ratingCeiling, string user)
        {
            string sql = "exec proc_QuestionCountSetup @flag='qsnCount'";
            sql += ",@QstnType =" + filterstring(qstnType);
            sql += ",@NoOfQstn =" + filterstring(noOfQstn);
            sql += ",@TotalWeightage =" + filterstring(totalWeightage);
            sql += ",@RatingCeiling =" + filterstring(ratingCeiling);			
            sql += ",@CreatedBy =" + filterstring(user);

            return GetSingleresult(sql);
        }
        public string CompetencyMatrixSetup(string rowId, string competency, string competencyWeight, string competencyKey, string competencyKeyWeight,string user)
        {
            string sql = "exec proc_CompetancyMatrixSetup @flag='compMatrixSetup'";
            sql += ",@rowId =" + filterstring(rowId);
            sql += ",@competency =" + filterstring(competency);
            sql += ",@competencyWeight =" + filterstring(competencyWeight);
            sql += ",@competencyKey =" + filterstring(competencyKey);
            sql += ",@competencyKeyWeight =" + filterstring(competencyKeyWeight);
            sql += ",@CreatedBy =" + filterstring(user);

            return GetSingleresult(sql);
        }

        public DataTable GetQuestionCountTable()
        {
            string sql = "exec proc_QuestionCountSetup @flag='grid'";

            return ExecuteDataset(sql).Tables[0];
        }
      

        public DataTable GetCompetencyMatrixTable(string LrowId)
        {
            string sql = "exec proc_CompetancyMatrixSetup @flag='grid'";
            sql += ",@LrowId =" + filterstring(LrowId);
            return ExecuteDataset(sql).Tables[0];
        }

        public void DeleteQuestionCount(string rowId)
        {
            string sql = "exec proc_QuestionCountSetup @flag='del', @rowId=" + filterstring(rowId) + "";
            ExecuteQuery(sql);
        }
        public void DeleteCompetencyMatrix(string rowId)
        {
            string sql = "exec proc_CompetancyMatrixSetup @flag='del', @rowId=" + filterstring(rowId) + "";
            ExecuteQuery(sql);
        }

        public string EditQuestionCount(string noOfQstn,string totalWeightage,string ratingCeiling, string user,string rowId)
        {
            string sql = "exec proc_QuestionCountSetup @flag='update'";
            sql += ",@NoOfQstn =" + filterstring(noOfQstn);
            sql += ",@TotalWeightage =" + filterstring(totalWeightage);
            sql += ",@RatingCeiling =" + filterstring(ratingCeiling);	
            sql += ",@ModifiedBy =" + filterstring(user);
            sql += ",@rowId =" + filterstring(rowId);

            return GetSingleresult(sql);
        }

        public string EditCompetencyMatrix(string txtWeight, string txtWeight1, string user, string rowId, string CompId,string CompKeyId,string lRowId)
        {
            string sql = "exec proc_CompetancyMatrixSetup @flag='update'";
            sql += ",@TxtWeight =" + filterstring(txtWeight);
            sql += ",@TxtWeight1 =" + filterstring(txtWeight1);
            sql += ",@ModifiedBy =" + filterstring(user);
            sql += ",@rowId =" + filterstring(rowId);
            sql += ",@competency =" + filterstring(CompId);
            sql += ",@competencyKey=" + filterstring(CompKeyId);
            sql += ",@LrowId =" + filterstring(lRowId);


            return GetSingleresult(sql);
        }
        
        public string WeightageDefination(string id, string kra, string competencies, string user)
        {
            string sql = "exec performance_proc @flag='wAge'";
            sql += ",@rowId =" + filterstring(id);
            sql += ",@Kra =" + filterstring(kra);
            sql += ",@Competencies =" + filterstring(competencies);
            sql += ",@CreatedBy =" + filterstring(user);

            return GetSingleresult(sql);
        }

        public string EditWeightageDefination(string id, string kra, string competencies, string user)
        {
            string sql = "exec performance_proc @flag='UpdatewAge'";
            sql += ",@rowId =" + filterstring(id);
            sql += ",@Kra =" + filterstring(kra);
            sql += ",@Competencies =" + filterstring(competencies);
            sql += ",@CreatedBy =" + filterstring(user);

            return GetSingleresult(sql);
        }

        public string PerformanceRating(string kraAchiveScore, string performLblRating, string PercentIncrement, string user)
        {
            string sql = "exec performance_proc @flag='rating'";
            sql += ",@KraAchiveScore =" + filterstring(kraAchiveScore);
            sql += ",@PerformLblRating =" + filterstring(performLblRating);
            sql += ",@PercentIncrement =" + filterstring(PercentIncrement);
            sql += ",@CreatedBy =" + filterstring(user);

            return GetSingleresult(sql);
        }

        public DataTable GetPerformanceTable()
        {
            string sql = "exec performance_proc @flag='grid'";

            return ExecuteDataset(sql).Tables[0];
        }

        public void DeleteReocrd(string rowId)
        {
            string sql = "exec performance_proc @flag='del', @rowId=" + filterstring(rowId) + "";
            ExecuteQuery(sql);
        }

        public string EditData(string kraAchiveScore, string performLblRating, string PercentIncrement, string user, string rowId)
        {
            string sql = "exec performance_proc @flag='update'";
            sql += ",@KraAchiveScore =" + filterstring(kraAchiveScore);
            sql += ",@PerformLblRating =" + filterstring(performLblRating);
            sql += ",@PercentIncrement =" + filterstring(PercentIncrement);
            sql += ",@ModifiedBy =" + filterstring(user);
            sql += ",@rowId =" + filterstring(rowId);

            return GetSingleresult(sql);
        }
        public override object MapObject(DataRow dr)
        {
            throw new System.NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(object obj)
        {
            throw new System.NotImplementedException();
        }

        public DataTable manageCompetency(string comMatrixName, string status, string position, string sessionId, string rowId, string user,string Probation)
        {
            string sql = "Exec proc_Competency  @flag= " + (string.IsNullOrWhiteSpace(rowId) ? "'addCom'" : "'editCom'");
            sql += ", @position=" + filterstring(position);
            sql += ", @active=" + filterstring(status);
            sql += ", @comMatrixName=" + filterstring(comMatrixName);
            sql += ",@sessionId = " + filterstring(sessionId);
            sql += ",@rowId = " + filterstring(rowId);
            sql += ",@user = " + filterstring(user);
            sql += ",@Probation = " + Probation;
            return ExecuteStoreProcedure(sql);
        }
        public DataTable assignReviewCommittee(string levelName,string empName,string status, string sessionId, string id)
        {
            string sql = "Exec proc_assignReviewCommittee @flag= " + (string.IsNullOrWhiteSpace(id) ? "'addCom'" : "'editCom'");
            sql += ", @levelName=" + filterstring(levelName);
            sql += ", @empName=" + filterstring(empName);
            sql += ", @active=" + filterstring(status);
            sql += ",@sessionId = " + filterstring(sessionId);
            sql += ",@rowId = " + filterstring(id);
            return ExecuteStoreProcedure(sql);
        }
        public DataTable ShowUnsavedData(string sessionId, string levelname)
        {
            string sql = "Exec proc_Competency @flag='sud',@sessionId = " + filterstring(sessionId);
            sql += ",@comMatrixName=" + filterstring(levelname);
            return ExecuteStoreProcedure(sql);
        }
        public DataTable ShowAssignReviewTempData(string lRowId,string rowId)
        {
            string sql = "Exec proc_assignReviewCommittee @flag='sartd'";
            sql += ",@lRowId = " + filterstring(lRowId);
            sql += ",@rowId = " + filterstring(rowId);
            return ExecuteStoreProcedure(sql);
        }

        public DataTable DeleteTempCompetency(string position,string Probation)
        {
            string sql = "Exec proc_Competency @flag='delCom'";
            sql += ",@position = " + filterstring(position);
            //sql += ",@rowId = " + filterstring(rowId);
            sql += ",@Probation = " + filterstring(Probation);
            return ExecuteStoreProcedure(sql);
        }
        public DataTable DeletePosition(string position, string Probation)
        {
            string sql = "Exec proc_Competency @flag='delPosition'";
            sql += ",@rowId = " + filterstring(position);
            sql += ",@Probation = " + filterstring(Probation);
            return ExecuteStoreProcedure(sql);
        }
        

        public DataTable DeleteTempAssignReviewCommittee(string id)
        {
            string sql = "Exec proc_assignReviewCommittee @flag='delAssignReview',@rowId = " + filterstring(id);
            return ExecuteStoreProcedure(sql);
        }

        public string GetTempCompetencyById(string id)
        {
            string sql = "Exec proc_Competency @flag='getComData',@rowId = " + filterstring(id);
            return GetSingleresult(sql);
        }

        public DataTable SaveCompetency(string comMatrixName,string active, string user, string sessionId, string id,string Probation)
        {
            string sql = "Exec proc_Competency @flag= " + (string.IsNullOrWhiteSpace(id) ? "'saveCom'" : "'updateCom'");
            sql += ",@user = " + filterstring(user) + ",@sessionId = " + filterstring(sessionId);
            sql += ",@comMatrixName = " + filterstring(comMatrixName);
            sql += ",@active = " + filterstring(active);
            sql += ",@rowId = " + filterstring(id);
            sql += ",@Probation = " + filterstring(Probation);
            return ExecuteStoreProcedure(sql);
        }

          public DataTable UpdateCompetency(string comMatrixName,string active, string user, string sessionId, string id,string Probation)
         {
           string sql = "Exec proc_Competency @flag='updateCom'";
            sql += ",@user = " + filterstring(user) + ",@sessionId = " + filterstring(sessionId);
            sql += ",@comMatrixName = " + filterstring(comMatrixName);
            sql += ",@active = " + filterstring(active);
            sql += ",@Probation = " + filterstring(Probation);
            sql += ",@rowId = " + filterstring(id);
            return ExecuteStoreProcedure(sql);
        }
        public DataTable SaveAssignReviewCommittee(string user, string LevelName, string empId, string active, string id,string rowId)
        {
            string sql = "Exec proc_assignReviewCommittee @flag='saveCom'";
            sql += ",@user = " + filterstring(user);
            sql += ",@levelName = " + filterstring(LevelName);
            sql += ",@empId = " + filterstring(empId);
            sql += ",@active = " + filterstring(active);
            sql += ",@lRowId = " + filterstring(id);
            sql += ",@rowId = " + filterstring(rowId);
            return ExecuteStoreProcedure(sql);
        }

        public DataTable LoadCompetencyDetails(string id, string sessionId)
        {
            string sql = "Exec proc_Competency @flag='editSelect',@rowId = " + filterstring(id)+",@sessionId = " + filterstring(sessionId);
            return ExecuteStoreProcedure(sql);
        }
        public DataTable LoadAssignReviewDetails(string id, string sessionId)
        {
            string sql = "Exec proc_assignReviewCommittee @flag='editSelect',@rowId = " + filterstring(id) + ",@sessionId = " + filterstring(sessionId);
            return ExecuteStoreProcedure(sql);
        }

        public DataTable LoadLevelName(string id)
        {
            string sql = "Exec proc_Competency @flag='loadLevelname'";
            sql += ",@rowId = " + filterstring(id);
            return ExecuteStoreProcedure(sql);
        }

        public DataTable LoadWeightageDetails(string id)
        {
            string sql = "Exec proc_Competency @flag='LoadWeightageDetails'";
            sql += ",@rowId = " + filterstring(id);
            return ExecuteStoreProcedure(sql);
        }

        public DataTable DepartMentTem()
        {
            string sql = "Select * from StaticDataDetail where TYPE_ID=7";
            return ExecuteStoreProcedure(sql);
        }
    }
}
