using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.web.DAL.Project.UpdateTask;

namespace SwiftHrManagement.DAL.Project.UpdateTask
{
    public class UpdateTaskDao : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;
        public UpdateTaskDao()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Update_Task(POSTED_BY, ACTIVE_TASK, DESCRIPTION, PCT_COMPLETE, IS_COMPLETE, CREATED_BY,"
            + " CREATED_DATE) VALUES ('POSEDBY', 'ACTIVETASK', 'DESCRIPTION_', 'PCTCOMPLETE', 'ISCOMPLETE', 'CREATEDBY', 'CREATEDDATE')");
            this.updateQuery = new StringBuilder("UPDATE Update_Task SET DESCRIPTION='NOTES',PCT_COMPLETE='PCTCOMPLETE', "
            + " IS_COMPLETE='ISCOMPLETE',MODIFIED_BY='MODIFIEDBY',MODIFIED_DATE='MODIFIEDDATE' WHERE UPDT_TASK_ID='UPDTTASKID'");
            this.selectQuery = new StringBuilder("SELECT UPDT_TASK_ID, TU.DESCRIPTION, TU.PCT_COMPLETE, CASE WHEN TU.IS_COMPLETE = 'True' THEN 'Yes' "
            + " WHEN TU.IS_COMPLETE = 'False' THEN 'No' END AS 'IS_COMPLETE',"
            + "TU.CREATED_DATE, T.TITLE AS ACTIVE_TASK FROM  Update_Task AS TU INNER JOIN Tasks AS T ON TU.ACTIVE_TASK = T.TASK_ID");
        }
        public override void Save(object obj)
        {
            UpdateTaskCore _updateTaskCore = (UpdateTaskCore)obj;
            this.insertQuery.Replace("ACTIVETASK", _updateTaskCore.Active_Task.ToString());
            this.insertQuery.Replace("POSEDBY", _updateTaskCore.Posted_By.ToString());
            this.insertQuery.Replace("ISCOMPLETE", _updateTaskCore.Is_Complete.ToString());
            this.insertQuery.Replace("PCTCOMPLETE", _updateTaskCore.Complete_PCT.ToString());
            this.insertQuery.Replace("DESCRIPTION_", _updateTaskCore.Description.ToString());
            this.insertQuery.Replace("CREATEDBY", _updateTaskCore.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _updateTaskCore.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            UpdateTaskCore _updateTaskCore = (UpdateTaskCore)obj;
            this.updateQuery.Replace("UPDTTASKID", _updateTaskCore.UPDT_TASK_ID.ToString());           
            this.updateQuery.Replace("POSEDBY", _updateTaskCore.Posted_By.ToString());
            this.updateQuery.Replace("ISCOMPLETE", _updateTaskCore.Is_Complete.ToString());
            this.updateQuery.Replace("PCTCOMPLETE", _updateTaskCore.Complete_PCT.ToString());
            this.updateQuery.Replace("NOTES", _updateTaskCore.Description.ToString());
            this.updateQuery.Replace("MODIFIEDBY", _updateTaskCore.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", _updateTaskCore.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }
        public override object MapObject(DataRow dr)
        {
            UpdateTaskCore _updtCore = new UpdateTaskCore();
            _updtCore.UPDT_TASK_ID = long.Parse(dr["UPDT_TASK_ID"].ToString());
            _updtCore.Complete_PCT = dr["PCT_COMPLETE"].ToString();
            _updtCore.Active_Task = dr["ACTIVE_TASK"].ToString();
            _updtCore.Description = dr["DESCRIPTION"].ToString();
            _updtCore.Is_Complete = dr["IS_COMPLETE"].ToString();
            _updtCore.CreatedDate = DateTime.Parse(dr["CREATED_DATE"].ToString());
            _updtCore.Posted_By = dr["POSTED_BY"].ToString();
            return _updtCore;
        }
        public DataTable Getactivetasks(String userid)
        {
            String sSql = " exec [Procactivetasks] '" + userid + "'";
            return ExecuteStoreProcedure(sSql);
        }
        public UpdateTaskCore FindallById(string userId, string taskid)
        {
            String ssql = "Exec procShowTaksUpdates 'a' , " + filterstring(taskid) + " , " + filterstring(userId) + "";
            DataTable dt = SelectByQuery(ssql);
            UpdateTaskCore _updateTaskCore = null;
            if (dt != null)
            {
                _updateTaskCore = (UpdateTaskCore)this.MapObject(dt.Rows[0]);
            }
            return _updateTaskCore;
        }
        public UpdateTaskCore FindAllByUptID(string updtID)
        {
            String ssql = "Exec procShowTaksUpdates 's' ," + filterstring(updtID) + "";
            DataTable dt = SelectByQuery(ssql);
            UpdateTaskCore _updateTaskCore = null;
            if (dt != null)
            {
                _updateTaskCore = (UpdateTaskCore)this.MapObject(dt.Rows[0]);
            }
            return _updateTaskCore;
        }
        public void DeleteById(long Id)
        {
            String sSql = ("DELETE FROM UPDATE_TASK WHERE UPDT_TASK_ID = "+ Id +"").ToString();
            this.ExecuteQuery(sSql);
        }
        public DataTable FindAllForDashboard(String UserId)
        {
            DataTable dt = SelectByQuery("SELECT PROJECT_ID, PROJECT_TITLE, TASK_TITLE, DESCRIPTION, PCT_COMPLETE,"
            + " EMPLOYEE_LOGINNAME FROM VwDashBoard where FNAME='"+UserId+"'");
            return dt;
        }
        public DataTable FindRecord(string project_name, string task_name)
        {
            DataTable dt = SelectByQuery("SELECT PROJECT_ID, PROJECT_TITLE, TASK_TITLE, DESCRIPTION, PCT_COMPLETE,"
            + " EMPLOYEE_LOGINNAME FROM VwDashBoard where PROJECT_TITLE='" + project_name + "' OR TASK_TITLE='" + task_name + "'");
            return dt;
        }
        public List<UpdateTaskCore> FindallByUser(String userId, string taskid)
        {
            String ssql = "Exec procShowTaksUpdates 'a' , '"+ userId +"' , '"+ taskid +"'";  
            DataTable dt = SelectByQuery(ssql);
            List<UpdateTaskCore> updateTaskDao = new List<UpdateTaskCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UpdateTaskCore _udateTsk = (UpdateTaskCore)this.MapObject(dr);
                    updateTaskDao.Add(_udateTsk);
                }
            }
            return updateTaskDao;
        }
    }
}
