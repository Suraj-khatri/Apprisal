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
    public class TrainingFeedbackDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        //private StringBuilder updateQuery;

        public TrainingFeedbackDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO TrainingFeedback(TRAINING_PROGRAM_ID,FEEDBACK,CREATED_BY,CREATED_DATE)"
                + " VALUES ('_TRAINING_PROGRAM_ID','_FEEDBACK','_CREATED_BY','_CREATED_DATE')");

            /*
             * no need to update Training Feedback *
         
                this.updateQuery = new StringBuilder("UPDATE TrainingFeedback SET "
                   + " TRAINING_PROGRAM_ID='_TRAINING_PROGRAM_ID',EVALUATION ='_EVALUATION'"); 
            */

        }

        public override void Save(object obj)
        {
            TrainingFeedbackCore tFeedback = (TrainingFeedbackCore)obj;
            this.insertQuery.Replace("_TRAINING_PROGRAM_ID", tFeedback.TrainingProgramId.ToString());
            this.insertQuery.Replace("_FEEDBACK", tFeedback.Feedback.ToString());
            this.insertQuery.Replace("_CREATED_BY", tFeedback.CreatedBy.ToString());
            this.insertQuery.Replace("_CREATED_DATE", tFeedback.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            //no need to update Training Feedback
        }

        public List<TrainingFeedbackCore> FindAll()
        {
            string sSql = "SELECT TF.ID, TP.TRAINING_PROGRAM_TITLE AS TRAINING_PROGRAM_ID, FEEDBACK, TF.CREATED_BY,CONVERT(VARCHAR,TF.CREATED_DATE,107) AS CREATED_DATE from "
            + " TrainingFeedback TF inner join TrainingProgram TP ON TP.ID=TF.TRAINING_PROGRAM_ID";             
            DataTable dt = SelectByQuery(sSql);

            List<TrainingFeedbackCore> tFeedback = new List<TrainingFeedbackCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingFeedbackCore _tFeedback = (TrainingFeedbackCore)this.MapObject(dr);
                    tFeedback.Add(_tFeedback);
                }
            }
            return tFeedback;
        }
        public TrainingFeedbackCore FindById(long Id)
        {
            string sSql = "SELECT ID, TRAINING_PROGRAM_ID, FEEDBACK, CREATED_BY,CONVERT(VARCHAR,CREATED_DATE,107) AS CREATED_DATE"
                + " FROM TrainingFeedback WHERE ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            TrainingFeedbackCore _tFeedback = null;
            if (dt != null)
                _tFeedback = (TrainingFeedbackCore)this.MapObject(dt.Rows[0]);
            return _tFeedback;
        }

        public override object MapObject(DataRow dr)
        {
            TrainingFeedbackCore tFeedback = new TrainingFeedbackCore();
            tFeedback.Id = long.Parse(dr["ID"].ToString());
            tFeedback.TrainingProgramId = dr["TRAINING_PROGRAM_ID"].ToString();
            tFeedback.Feedback = dr["FEEDBACK"].ToString();
            //tFeedback.CreatedDate = DateTime.Parse(dr["CREATED_DATE"].ToString());
            tFeedback.FeedbackDate = dr["CREATED_DATE"].ToString();            
            tFeedback.CreatedBy = dr["CREATED_BY"].ToString();

            return tFeedback;
        }
    }
}