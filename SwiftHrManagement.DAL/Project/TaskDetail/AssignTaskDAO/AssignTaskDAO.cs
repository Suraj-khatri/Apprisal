using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.Project.TaskDetail.AssignTaskDAO
{
    public class AssignTaskDAO : BaseDAO
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;
        public AssignTaskDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO ASSIGNED_GROUP_TASK (EMP_ID, TASK_ID) VALUES ('FNAME_',TASKID)");
            this._updateQuery = new StringBuilder ("");
            
        }

        public override void Save(object obj)
        {
            TaskAssignCore _taskAssign = (TaskAssignCore)obj;
            this._insertQuery.Replace("FNAME_", _taskAssign.Fname);
            this._insertQuery.Replace("TASKID", _taskAssign.Id.ToString());
            ExecuteQuery(this._insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            TaskAssignCore _taskAssign = new TaskAssignCore();
            this._updateQuery.Replace("fname", _taskAssign.Fname);
            this._updateQuery.Replace("TaskId", _taskAssign.Id.ToString());
            ExecuteQuery(this._updateQuery.ToString());
        }
        public DataTable FindAllByUser(String Fname)
        {
            String sSql = ("SELECT AGT.ID, AGT.EMP_ID, T.TITLE AS TASK_ID FROM ASSIGNED_GROUP_TASK AS AGT, Tasks AS T WHERE "
            + " AGT.TASK_ID = T.TASK_ID AND AGT.EMP_ID='" + Fname + "'").ToString();
            DataTable Dt = SelectByQuery(sSql);
            return Dt;
        }
        //public Boolean CheckifAlreadyExists(String _name, long _task_Id)
        //{
        //    String sSql = "select TASK_ID, FNAME from Assigned_Group_Task where FNAME = '"+ _name +"' and TASK_ID = "+ _task_Id +"";
        //    return CheckStatement(sSql);
        //}
        public Boolean CheckIfExistsTask(string emp_id, long task_id)
        {
            return (CheckStatement("select EMP_ID from Assigned_Group_Task where TASK_ID =" + task_id + " and EMP_ID='" + emp_id + "'"));
        }
        public void AssignTask(String _name, long _task_Id, string user)
        {
            String sSql = "ProcAssignTask '" + _name + "'," + _task_Id + ",'"+ user +"'";
            this.ExecuteUpdateProcedure(sSql);
        }
        public void DeleteById(String ids)
        {
            String sSql = "delete from Assigned_Group_Task where ID in ("+ ids +")";
            this.ExecuteUpdateProcedure(sSql);
        }
        public DataSet AssignTask(long id)
        {
            String sSql = ("select ID, EMP_ID FROM ASSIGNED_GROUP_TASK where TASK_ID ='"+ id +"'");
            return ReturnDataset(sSql);
        }
        public List<TaskAssignCore> FindTask(String UserId, string task_id)
        {
            string sSql = "";
            if (UserId == "admin")
            {
                sSql = "SELECT T.TITLE, T.TASK_ID FROM  Tasks AS T WHERE T.TASK_ID in ( select  TASK_ID from Assigned_Group_Task where task_id = '"+ task_id +"')";
            }
            else
            {
                sSql = "SELECT T.TITLE, T.TASK_ID FROM  Tasks AS T WHERE T.TASK_ID in ( select  TASK_ID from Assigned_Group_Task where "
            + "  EMP_ID='" + UserId + "' and task_id = " + task_id + ")";
            }
            
            DataTable dt = SelectByQuery(sSql);
            List<TaskAssignCore> taskcore = new List<TaskAssignCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TaskAssignCore _tskcore = (TaskAssignCore)this.MapName(dr);
                    taskcore.Add(_tskcore);
                }
            }
            return taskcore;
        }
        public object MapName(System.Data.DataRow dr)
        {
            TaskAssignCore _taskAssign = new TaskAssignCore();
            _taskAssign.Id =long.Parse(dr["TASK_ID"].ToString());
            _taskAssign.TaskId = dr["TITLE"].ToString();
            return _taskAssign;
        }

        public TaskAssignCore GetTaskDetailById(long id)
        {
            String Ssql = ("SELECT TITLE,convert(varchar,START_DATE,107)as START_DATE,convert(varchar,END_DATE,107) as END_DATE, CATEGORY, REPORT_TO from Tasks where TASK_ID='" + id + "'").ToString();          
            DataTable dt = SelectByQuery(Ssql);
            TaskAssignCore _taskcore = null;
            if (dt.Rows.Count != null)
                _taskcore = (TaskAssignCore)this.MapObject(dt.Rows[0]);
            return _taskcore;
        }
        public DataSet GetAssignedTask(long id)
        {
            return ReturnDataset("select id, dbo.EmployeeFullName(EMP_ID) as EMP_ID from Assigned_Group_Task where TASK_ID =" + id + "");
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            TaskAssignCore _taskAssign = new TaskAssignCore();
            _taskAssign.Title = (dr["TITLE"].ToString());
            _taskAssign.Category = dr["CATEGORY"].ToString();
            _taskAssign.Report_to = (dr["REPORT_TO"].ToString());
            _taskAssign.Start_date = dr["START_DATE"].ToString();
            _taskAssign.End_date = dr["END_DATE"].ToString();
            return _taskAssign;
        }
    }
}
