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
    public class TrainingProgramDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public TrainingProgramDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO TrainingProgram (TRAINING_ID,TRAINING_PROGRAM_TITLE,PLANNED_START_DATE,PLANNED_END_DATE,"
            + " MAXIMUM_CAPACITY,VENUE,CITY,COUNTRY,NUMBER_OF_DAYS,TOTAL_HOURS,HOURS_EACH_DAY,DETAILED_COURSE_CONTENT,CREATED_BY,CREATED_DATE,ACTUAL_START_DATE,ACTUAL_END_DATE)"
                 + " VALUES ('_TRAINING_ID','_TRAINING_PROGRAM_TITLE','_PLANNED_START_DATE','_PLANNED_END_DATE','_MAXIMUM_CAPACITY',"
            + " '_VENUE','_CITY','_COUNTRY','_NUMBER_OF_DAYS','_TOTAL_HOURS','_HOURS_EACH_DAY','_DETAILED_COURSE_CONTENT', '_CREATED_BY','_CREATED_DATE','_ACTUAL_START_DATE','_ACTUAL_END_DATE')");

            this.updateQuery = new StringBuilder("UPDATE TrainingProgram SET "
               + " TRAINING_ID='_TRAINING_ID',TRAINING_PROGRAM_TITLE='_TRAINING_PROGRAM_TITLE',ACTUAL_START_DATE ='_ACTUAL_START_DATE' ,ACTUAL_END_DATE='_ACTUAL_END_DATE',MAXIMUM_CAPACITY="
            + " '_MAXIMUM_CAPACITY', VENUE='_VENUE', CITY='_CITY', COUNTRY='_COUNTRY', NUMBER_OF_DAYS='_NUMBER_OF_DAYS', TOTAL_HOURS='_TOTAL_HOURS',"
            + " HOURS_EACH_DAY='_HOURS_EACH_DAY',DETAILED_COURSE_CONTENT='_DETAILED_COURSE_CONTENT',ISACTIVE ='_ISACTIVE', MODIFIED_BY='_MODIFIED_BY',"
            + " MODIFIED_DATE='_MODIFIED_DATE' where ID=ID_");

        }

        public override void Save(object obj)
        {
            TrainingProgramCore tProgram = (TrainingProgramCore)obj;
            this.insertQuery.Replace("_TRAINING_ID", tProgram.TrainingId.ToString());            
            this.insertQuery.Replace("_TRAINING_PROGRAM_TITLE", tProgram.TrainingProgramTitle.ToString());
            this.insertQuery.Replace("_PLANNED_START_DATE", tProgram.PlannedStartDate.ToString());
            this.insertQuery.Replace("_PLANNED_END_DATE", tProgram.PlannedEndDate.ToString());
            this.insertQuery.Replace("_ACTUAL_START_DATE", tProgram.ActualStartDate.ToString());
            this.insertQuery.Replace("_ACTUAL_END_DATE", tProgram.ActualEndDate.ToString());  
            this.insertQuery.Replace("_MAXIMUM_CAPACITY", tProgram.MaximumCapacity.ToString());
            this.insertQuery.Replace("_VENUE", tProgram.Venue.ToString());
            this.insertQuery.Replace("_CITY", tProgram.City.ToString());
            this.insertQuery.Replace("_COUNTRY", tProgram.Country.ToString());
            this.insertQuery.Replace("_NUMBER_OF_DAYS", tProgram.NumberOfDays.ToString());
            this.insertQuery.Replace("_TOTAL_HOURS", tProgram.TotalHours.ToString());
            this.insertQuery.Replace("_HOURS_EACH_DAY", tProgram.HoursEachDay.ToString());
            this.insertQuery.Replace("_DETAILED_COURSE_CONTENT", tProgram.DetailedCourseContents.ToString());
            this.insertQuery.Replace("_CREATED_BY", tProgram.CreatedBy.ToString());
            this.insertQuery.Replace("_CREATED_DATE", tProgram.CreatedDate.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            try
            {
                TrainingProgramCore _tProgram = (TrainingProgramCore)obj;
                this.updateQuery.Replace("ID_", _tProgram.Id.ToString());
                this.updateQuery.Replace("_TRAINING_ID", _tProgram.TrainingId.ToString());                
                this.updateQuery.Replace("_TRAINING_PROGRAM_TITLE", _tProgram.TrainingProgramTitle.ToString());
                this.updateQuery.Replace("_ACTUAL_START_DATE", _tProgram.ActualStartDate.ToString());
                this.updateQuery.Replace("_ACTUAL_END_DATE", _tProgram.ActualEndDate.ToString());
                this.updateQuery.Replace("_MAXIMUM_CAPACITY", _tProgram.MaximumCapacity.ToString());
                this.updateQuery.Replace("_VENUE", _tProgram.Venue.ToString());
                this.updateQuery.Replace("_CITY", _tProgram.City.ToString());
                this.updateQuery.Replace("_COUNTRY", _tProgram.Country.ToString());
                this.updateQuery.Replace("_NUMBER_OF_DAYS", _tProgram.NumberOfDays.ToString());
                this.updateQuery.Replace("_TOTAL_HOURS", _tProgram.TotalHours.ToString());
                this.updateQuery.Replace("_HOURS_EACH_DAY", _tProgram.HoursEachDay.ToString());
                this.updateQuery.Replace("_DETAILED_COURSE_CONTENT", _tProgram.DetailedCourseContents.ToString());
                this.updateQuery.Replace("_MODIFIED_BY", _tProgram.ModifyBy.ToString());
                this.updateQuery.Replace("_MODIFIED_DATE", _tProgram.ModifyDate.ToString());

                this.updateQuery.Replace("_ISACTIVE", _tProgram.IsActive.ToString());
                
                ExecuteQuery(this.updateQuery.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<TrainingProgramCore> FindAll()
        {
            string sSql = "SELECT P.ID, L.TRAINING_NAME AS TRAINING_ID,TRAINING_PROGRAM_TITLE, CAST(PLANNED_START_DATE AS DATE)AS"
            + " PLANNED_START_DATE, CONVERT(VARCHAR,ACTUAL_START_DATE,107) AS ACTUAL_START_DATE, CAST(PLANNED_END_DATE AS DATE) AS PLANNED_END_DATE,"
            + " CONVERT(VARCHAR,ACTUAL_END_DATE,107) AS ACTUAL_END_DATE, MAXIMUM_CAPACITY,VENUE, CITY, COUNTRY, NUMBER_OF_DAYS, TOTAL_HOURS, "
            + " HOURS_EACH_DAY, DETAILED_COURSE_CONTENT, P.CREATED_BY, P.CREATED_DATE, P.MODIFIED_BY,ISNULL(P.ISACTIVE,0) AS ISACTIVE,"
            +" P.MODIFIED_DATE FROM TrainingProgram P INNER JOIN TrainingList L ON L.ID=P.TRAINING_ID";       
            DataTable dt = SelectByQuery(sSql);

            List<TrainingProgramCore> tProgram = new List<TrainingProgramCore>();
            if (dt != null)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {                       
                        TrainingProgramCore _tProgram = (TrainingProgramCore)this.MapObject(dr);
                        tProgram.Add(_tProgram);                     
                    }
                }
                catch
                {
                }
            }
            return tProgram;
        }

   //For BranchWise Participants Add Function  
   
        public List<TrainingProgramCore> FindAllActive()
        {
            string sSql = "SELECT P.ID, L.TRAINING_NAME AS TRAINING_ID,TRAINING_PROGRAM_TITLE,Convert(varchar,PLANNED_START_DATE,107)AS PLANNED_START_DATE, "
            + " CONVERT(VARCHAR,ACTUAL_START_DATE,107) AS ACTUAL_START_DATE, CONVERT(VARCHAR,PLANNED_END_DATE,107) AS PLANNED_END_DATE,"
            + " CONVERT(VARCHAR,ACTUAL_END_DATE,107) AS ACTUAL_END_DATE, MAXIMUM_CAPACITY,VENUE, CITY, COUNTRY, NUMBER_OF_DAYS, TOTAL_HOURS, "
            + " HOURS_EACH_DAY, DETAILED_COURSE_CONTENT, P.CREATED_BY, P.CREATED_DATE, P.MODIFIED_BY,ISNULL(P.ISACTIVE,0) AS ISACTIVE,"
            + " P.MODIFIED_DATE FROM TrainingProgram P INNER JOIN TrainingList L ON L.ID=P.TRAINING_ID WHERE P.ISACTIVE=1";
            DataTable dt = SelectByQuery(sSql);

            List<TrainingProgramCore> tProgram = new List<TrainingProgramCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingProgramCore _tProgram = (TrainingProgramCore)this.MapObject(dr);
                    tProgram.Add(_tProgram);
                }
            }
            return tProgram;
        }
        public TrainingProgramCore FindActiveProgramByID(long Id)
        {
            string sSql = "SELECT P.ID, L.TRAINING_NAME AS TRAINING_ID,TRAINING_PROGRAM_TITLE,Convert(varchar,PLANNED_START_DATE,107)AS PLANNED_START_DATE, "
            + " CONVERT(VARCHAR,ACTUAL_START_DATE,107) AS ACTUAL_START_DATE, CONVERT(VARCHAR,PLANNED_END_DATE,107) AS PLANNED_END_DATE,"
            + " CONVERT(VARCHAR,ACTUAL_END_DATE,107) AS ACTUAL_END_DATE, MAXIMUM_CAPACITY,VENUE, CITY, COUNTRY, NUMBER_OF_DAYS, TOTAL_HOURS, "
            + " HOURS_EACH_DAY, DETAILED_COURSE_CONTENT, P.CREATED_BY, P.CREATED_DATE, P.MODIFIED_BY,ISNULL(P.ISACTIVE,0) AS ISACTIVE,"
            + " P.MODIFIED_DATE FROM TrainingProgram P INNER JOIN TrainingList L ON L.ID=P.TRAINING_ID WHERE P.ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            TrainingProgramCore _tProgram = null;
            if (dt != null)
                _tProgram = (TrainingProgramCore)this.MapObject(dt.Rows[0]);
            return _tProgram;
        }

//End of For BranchWise Participants Add Function
 

        public List<TrainingProgramCore> FindTrainingProgramByBranch(long BranchId)
        {
            string sSql = "select ID, TRAINING_PROGRAM_TITLE from TrainingProgram where BRANCH_ID = " + BranchId + "";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingProgramCore> emp = new List<TrainingProgramCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingProgramCore _emp = (TrainingProgramCore)this.MapObjectforProgramByBranchid(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }

        public object MapObjectforProgramByBranchid(DataRow dr)
        {
            TrainingProgramCore tProgram = new TrainingProgramCore();
            tProgram.Id = long.Parse(dr["ID"].ToString());
            tProgram.TrainingProgramTitle = (dr["TRAINING_PROGRAM_TITLE"].ToString());
            return tProgram;
        }
        public TrainingProgramCore FindById(long Id)
        {
            string sSql = "SELECT ID, TRAINING_ID,TRAINING_PROGRAM_TITLE,CONVERT(VARCHAR,PLANNED_START_DATE,101) AS PLANNED_START_DATE,"
                          + " CONVERT(VARCHAR,ACTUAL_START_DATE,101) AS ACTUAL_START_DATE,"
                          + " CONVERT(VARCHAR,PLANNED_END_DATE,101) AS PLANNED_END_DATE,CONVERT(VARCHAR,ACTUAL_END_DATE,101) AS ACTUAL_END_DATE,"
                          + " MAXIMUM_CAPACITY, VENUE, CITY, COUNTRY, NUMBER_OF_DAYS, TOTAL_HOURS, HOURS_EACH_DAY, DETAILED_COURSE_CONTENT,ISNULL(ISACTIVE,0) AS ISACTIVE  "
                          + " FROM TrainingProgram WHERE ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            TrainingProgramCore _tProgram = null;
            if (dt != null)
                _tProgram = (TrainingProgramCore)this.MapObject(dt.Rows[0]);
            return _tProgram;
        }      
        public List<TrainingProgramCore> FindByFields(string programName)
        {
            string sSql = "SELECT ID, TRAINING_ID,TRAINING_PROGRAM_TITLE,CONVERT(VARCHAR,PLANNED_START_DATE,101) AS PLANNED_START_DATE,"
            + " CONVERT(VARCHAR,ACTUAL_START_DATE,101) AS ACTUAL_START_DATE,CONVERT(VARCHAR,PLANNED_END_DATE,101)"
            + " AS PLANNED_END_DATE, CONVERT(VARCHAR,ACTUAL_END_DATE,101) AS ACTUAL_END_DATE, MAXIMUM_CAPACITY, VENUE, CITY, COUNTRY, NUMBER_OF_DAYS,"
            + " TOTAL_HOURS, HOURS_EACH_DAY, DETAILED_COURSE_CONTENT, ISNULL(ISACTIVE,0)"
            + " FROM TrainingProgram WHERE TRAINING_PROGRAM_TITLE like '" + programName + "%'";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingProgramCore> tProgram = new List<TrainingProgramCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingProgramCore _tProgram = (TrainingProgramCore)this.MapObject(dr);
                    tProgram.Add(_tProgram);
                }
            }
            return tProgram;
        }

        public TrainingProgramCore FindByTrainProgramId(long Id)
        {

            string sSql = "SELECT TP.ID,TL.TRAINING_NAME AS TRAINING_ID,TRAINING_PROGRAM_TITLE,ISNULL(TP.ISACTIVE,0) AS ISACTIVE from "
                + " TrainingProgram TP INNER JOIN TrainingList TL ON TL.ID=TP.TRAINING_ID WHERE TP.ID=" + Id + "";

                DataTable dt = SelectByQuery(sSql);
                TrainingProgramCore _tProgram = null;
                if (dt != null)
                   
                        _tProgram = (TrainingProgramCore)this.MapObjectbyID(dt.Rows[0]);
                   
                return _tProgram;            

        }

        // Start Checking maximum capacity for training program to add participants ...
        public TrainingProgramCore FindMaxCapacity(long programId)
        {
            string sSql = "SELECT MAXIMUM_CAPACITY from TrainingProgram where ID=" + programId + "";
            DataTable dt = SelectByQuery(sSql);
            TrainingProgramCore _tProgram = null;
            if (dt != null)
                _tProgram = (TrainingProgramCore)this.MapMaxCapacity(dt.Rows[0]);
            return _tProgram;
        }
        public object MapMaxCapacity(DataRow dr)
        {
            TrainingProgramCore tProgram = new TrainingProgramCore();          
            tProgram.MaximumCapacity = (dr["MAXIMUM_CAPACITY"].ToString());
            return tProgram;
        }
        public TrainingProgramCore FindUsedCapacity(long programId)
        {
            string sSql = "select count(ID) as UsedCapacity from TrainingParticipants where TRAINING_PROGRAM_ID=" + programId + " and IS_APPROVED=1";
            DataTable dt = SelectByQuery(sSql);
            TrainingProgramCore _tProgram = null;
            if (dt != null)
                _tProgram = (TrainingProgramCore)this.MapUsedCapacity(dt.Rows[0]);
            return _tProgram;
        }
        public object MapUsedCapacity(DataRow dr)
        {
            TrainingProgramCore tProgram = new TrainingProgramCore();
            tProgram.UsedCapacity = (dr["UsedCapacity"].ToString());
            return tProgram;
        }
        // End of checking maximum capacity for training program to add participants ...

        public List<TrainingProgramCore> FindTrainingProgram(long empid)
        {
            string sSql = "select P.ID,P.TRAINING_PROGRAM_TITLE from TrainingProgram P inner join TrainingParticipants TP on P.ID=TP.TRAINING_PROGRAM_ID WHERE STAFF_ID='"+empid+"'";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingProgramCore> emp = new List<TrainingProgramCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingProgramCore _emp = (TrainingProgramCore)this.MapObjectbyProgram(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public object MapObjectbyProgram(DataRow dr)
        {
            TrainingProgramCore tProgram = new TrainingProgramCore();
            tProgram.Id = long.Parse(dr["ID"].ToString());       
            tProgram.TrainingProgramTitle = (dr["TRAINING_PROGRAM_TITLE"].ToString());
            return tProgram;
        }
        public object MapObjectbyID(DataRow dr)
        {
            TrainingProgramCore tProgram = new TrainingProgramCore();
            tProgram.Id = long.Parse(dr["ID"].ToString());
            tProgram.TrainingId = (dr["TRAINING_ID"].ToString());
            tProgram.TrainingProgramTitle = (dr["TRAINING_PROGRAM_TITLE"].ToString());
            return tProgram;
        }
        
        public override object MapObject(DataRow dr)
        {
            
                TrainingProgramCore tProgram = new TrainingProgramCore();
                tProgram.Id = long.Parse(dr["ID"].ToString());
                tProgram.TrainingId = (dr["TRAINING_ID"].ToString());                
                tProgram.TrainingProgramTitle = (dr["TRAINING_PROGRAM_TITLE"].ToString());
                tProgram.PlannedStartDate = (dr["PLANNED_START_DATE"].ToString());
                tProgram.PlannedEndDate = (dr["PLANNED_END_DATE"].ToString());
                tProgram.ActualStartDate = (dr["ACTUAL_START_DATE"].ToString());
                tProgram.ActualEndDate = (dr["ACTUAL_END_DATE"].ToString());
                tProgram.MaximumCapacity = (dr["MAXIMUM_CAPACITY"].ToString());
                tProgram.Venue = (dr["VENUE"].ToString());
                tProgram.City = (dr["CITY"].ToString());
                tProgram.Country = (dr["COUNTRY"].ToString());
                tProgram.NumberOfDays = (dr["NUMBER_OF_DAYS"].ToString());
                tProgram.TotalHours = (dr["TOTAL_HOURS"].ToString());
                tProgram.HoursEachDay = (dr["HOURS_EACH_DAY"].ToString());
                tProgram.DetailedCourseContents = (dr["DETAILED_COURSE_CONTENT"].ToString());
                tProgram.IsActive = Convert.ToBoolean((dr["ISACTIVE"]));
                    
            return tProgram;
        }
        public void DeleteById(long Id)
        {
            String sSql = "";
            sSql = "DELETE FROM TrainingProgram WHERE ID = " + Id + "";
            this.ExecuteQuery(sSql);
        }
    }
}