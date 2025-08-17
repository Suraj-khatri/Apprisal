using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.TrainingMangement;

namespace SwiftHrManagement.DAL.TrainingMangement
{
    public class TrainingEvaluationDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        public TrainingEvaluationDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO TrainingEvaluation (TRAINING_PROGRAM_ID,EVALUATION_RATE,EVALUATION,CREATED_BY, CREATED_DATE)"
                + " VALUES ('_TRAINING_PROGRAM_ID','_EVALUATIONRATE', '_EVALUATION', '_CREATED_BY','_CREATED_DATE')");

            /*  no need to update Training Evaluation *         
                this.updateQuery = new StringBuilder("UPDATE TrainingEvaluation SET "
                + " TRAINING_PROGRAM_ID='_TRAINING_PROGRAM_ID',EVALUATION ='_EVALUATION'"); 
            */
        }

        public override void Save(object obj)
        {
            TrainingEvaluationCore tEvaluation = (TrainingEvaluationCore)obj;
            this.insertQuery.Replace("_TRAINING_PROGRAM_ID", tEvaluation.TrainingProgramId.ToString());
            this.insertQuery.Replace("_EVALUATIONRATE", tEvaluation.EvaluationRate.ToString());
            this.insertQuery.Replace("_EVALUATION", tEvaluation.Evaluation.ToString());
            this.insertQuery.Replace("_CREATED_BY", tEvaluation.CreatedBy.ToString());
            this.insertQuery.Replace("_CREATED_DATE", tEvaluation.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            //no need to update Training Evaluation
        }
        public List<TrainingEvaluationCore> FindAll(long id)
        {
            string sSql = "SELECT TE.ID, TP.TRAINING_PROGRAM_TITLE AS TRAINING_PROGRAM_ID,S.DETAIL_TITLE AS EVALUATION_RATE, TE.EVALUATION, TE.CREATED_BY,CONVERT(VARCHAR,TE.CREATED_DATE,107) AS CREATED_DATE from TrainingEvaluation"
            + " TE inner join TrainingProgram TP ON TP.ID=TE.TRAINING_PROGRAM_ID INNER JOIN StaticDataDetail S ON S.ROWID=TE.EVALUATION_RATE where TE.TRAINING_PROGRAM_ID='" + id + "'";         
            DataTable dt = SelectByQuery(sSql);
            List<TrainingEvaluationCore> tEvaluation = new List<TrainingEvaluationCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingEvaluationCore _tEvaluation = (TrainingEvaluationCore)this.MapObject(dr);
                    tEvaluation.Add(_tEvaluation);
                }
            }
            return tEvaluation;
        }
        public TrainingEvaluationCore FindById(long Id)
        {
            string sSql = "SELECT TE.ID, TP.TRAINING_PROGRAM_TITLE AS TRAINING_PROGRAM_ID,TE.EVALUATION_RATE,TE.EVALUATION, TE.CREATED_BY,TE.CREATED_DATE FROM "
                + " TrainingEvaluation TE inner join TrainingProgram TP ON TE.TRAINING_PROGRAM_ID=TP.ID WHERE TE.ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            TrainingEvaluationCore _tEvaluation = null;
            if (dt != null)
                _tEvaluation = (TrainingEvaluationCore)this.MapObject(dt.Rows[0]);
            return _tEvaluation;
        }

        public override object MapObject(DataRow dr)
        {
            TrainingEvaluationCore tEvaluation = new TrainingEvaluationCore();
            tEvaluation.Id = long.Parse(dr["ID"].ToString());
            tEvaluation.TrainingProgramId = (dr["TRAINING_PROGRAM_ID"].ToString());
            tEvaluation.Evaluation = (dr["EVALUATION"].ToString());
            tEvaluation.EvaluationRate = (dr["EVALUATION_RATE"].ToString());
            tEvaluation.EvailuationDate = dr["CREATED_DATE"].ToString();
            tEvaluation.CreatedBy = (dr["CREATED_BY"].ToString());

            return tEvaluation;
        }
    }
}