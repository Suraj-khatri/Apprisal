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
    public class TrainingListDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public TrainingListDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO TrainingList (TRAINING_NAME,DESIGNED_FOR, COURSE_CONTENTS, CREATED_BY, CREATED_DATE) "
                + " VALUES ('_TRAINING_NAME','_DESIGNED_FOR',"
                + " '_COURSE_CONTENTS', 'CREATEDBY', 'CREATEDDATE')");

            this.updateQuery = new StringBuilder("UPDATE TrainingList SET "
               + " TRAINING_NAME='_TRAINING_NAME',DESIGNED_FOR='_DESIGNED_FOR',COURSE_CONTENTS='_COURSE_CONTENTS', MODIFIED_BY='MODIFIEDBY', MODIFIED_DATE='MODIFIEDDATE' where ID=id");
        }

        public override void Save(object obj)
        {
            TrainingListCore tList = (TrainingListCore)obj;
            this.insertQuery.Replace("_TRAINING_NAME", tList.TrainingName.ToString());
            this.insertQuery.Replace("_DESIGNED_FOR", tList.DesignedFor.ToString());
            this.insertQuery.Replace("_COURSE_CONTENTS", tList.CourseContents.ToString());
            this.insertQuery.Replace("CREATEDBY", tList.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", tList.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            TrainingListCore _tList = (TrainingListCore)obj;
            this.updateQuery.Replace("id", _tList.Id.ToString());
            this.updateQuery.Replace("_TRAINING_NAME", _tList.TrainingName.ToString());
            this.updateQuery.Replace("_DESIGNED_FOR", _tList.DesignedFor.ToString());
            this.updateQuery.Replace("_COURSE_CONTENTS", _tList.CourseContents.ToString());
            this.updateQuery.Replace("MODIFIEDBY", _tList.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", _tList.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<TrainingListCore> FindAll()
        {
            string sSql = "SELECT ID, TRAINING_NAME, DESIGNED_FOR, COURSE_CONTENTS,CREATED_BY,CREATED_DATE FROM TrainingList";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingListCore> tList = new List<TrainingListCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingListCore _tList = (TrainingListCore)this.MapObject(dr);
                    tList.Add(_tList);
                }
            }
            return tList;
        }
        public List<TrainingListCore> FindTrainingProgram()
        {
            string sSql = "SELECT ID, TRAINING_NAME FROM TrainingList";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingListCore> tList = new List<TrainingListCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingListCore _tList = (TrainingListCore)this.MapObjectForProgram(dr);
                    tList.Add(_tList);
                }
            }
            return tList;
        }
        public object MapObjectForProgram(DataRow dr)
        {
            TrainingListCore tList = new TrainingListCore();
            tList.Id = long.Parse(dr["ID"].ToString());
            tList.TrainingName = (dr["TRAINING_NAME"].ToString());
            return tList;
        }

        public TrainingListCore FindById(long Id)
        {
            string sSql = "SELECT ID,TRAINING_NAME,DESIGNED_FOR,COURSE_CONTENTS,CREATED_BY,CREATED_DATE FROM TrainingList WHERE ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            TrainingListCore _tList = null;
            if (dt != null)
                _tList = (TrainingListCore)this.MapObject(dt.Rows[0]);
            return _tList;
        }
        public List<TrainingListCore> FindByField(string t_name)
        {
            string sSql = "SELECT ID,TRAINING_NAME,DESIGNED_FOR,COURSE_CONTENTS,CREATED_BY,CREATED_DATE FROM TrainingList WHERE TRAINING_NAME like '"+t_name+"%'";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingListCore> tLists = new List<TrainingListCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingListCore _tList = (TrainingListCore)this.MapObject(dr);
                    tLists.Add(_tList);
                }
            }
            return tLists;
        }

        public override object MapObject(DataRow dr)
        {
            TrainingListCore tList = new TrainingListCore();
            tList.Id = long.Parse(dr["ID"].ToString());
            tList.TrainingName = (dr["TRAINING_NAME"].ToString());
            tList.DesignedFor = (dr["DESIGNED_FOR"].ToString());
            tList.CourseContents = (dr["COURSE_CONTENTS"].ToString());
            tList.CreatedBy = (dr["CREATED_BY"].ToString());
            tList.CreatedDate = DateTime.Parse(dr["CREATED_DATE"].ToString());
            return tList;
        }
        public void DeleteById(long Id)
        {
            String sSql = "";
            sSql = "DELETE FROM TrainingList WHERE ID = " + Id + "";
            this.ExecuteQuery(sSql);
        }

    }
}