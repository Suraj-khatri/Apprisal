    using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.Project.TaskDetail
{
    public class TaskDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;
        private StringBuilder _selectByProc;

        public TaskDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO TASKS(PROJECT_ID,TITLE, START_DATE, END_DATE, CATEGORY, PRIORITY, REPORT_TO, "
            + " IS_ASSIGNED,CREATED_BY,CREATED_DATE,COMPLETED) VALUES ('PROJECTID','TASK_TITLE_','STARTDATE','ENDDATE','CATEGORY_','PRIORITY_','REPORTTO', "
            + "0,'CREATEDBY',GETDATE(),0)");
            this._updateQuery = new StringBuilder("UPDATE TASKS SET PROJECT_ID='PROJECTID',TITLE='TASK_TITLE_', START_DATE='STARTDATE',END_DATE='ENDDATE',"
            + " CATEGORY='CATEGORY_',PRIORITY='PRIORITY_',REPORT_TO='REPORTTO',ASSIGNED_BY='ASSIGNEDBY',COMPLETED='COMPLETED_',MODIFIED_BY='MODIFIEDBY',MODIFIED_DATE=GETDATE() WHERE TASK_ID='TASKID'");

            this._selectQuery = new StringBuilder("SELECT  ab.Name AS ASSIGNED_BY, rt.Name AS REPORT_TO, t.TASK_ID,CONVERT(VARCHAR,t.START_DATE,101) AS START_DATE,CONVERT(VARCHAR,t.END_DATE,101) AS END_DATE, t.CATEGORY, t.PRIORITY, t.COMPLETED, t.TITLE, "
            + "dbo.Projects.PROJECT_TITLE AS PROJECT_ID FROM   dbo.Tasks AS t INNER JOIN  dbo.Admins AS ab ON t.ASSIGNED_BY = ab.UserName LEFT OUTER JOIN "
            + "dbo.Admins AS rt ON t.REPORT_TO = rt.UserName LEFT OUTER JOIN  dbo.Projects ON t.PROJECT_ID = dbo.Projects.PROJECT_ID ");

            this._selectByProc = new StringBuilder("");

        }

        public override object MapObject(DataRow dr)
        {
            TaskCore _taskDetlCore = new TaskCore();
            _taskDetlCore.Task_id = long.Parse(dr["TASK_ID"].ToString());
            _taskDetlCore.Project_id = (dr["PROJECT_ID"].ToString());
            _taskDetlCore.Title = dr["TITLE"].ToString();
            _taskDetlCore.Start_date = (dr["START_DATE"].ToString());
            _taskDetlCore.End_date = (dr["END_DATE"].ToString());
            _taskDetlCore.Category = (dr["CATEGORY"].ToString());
            _taskDetlCore.Priority = (dr["PRIORITY"].ToString());
            _taskDetlCore.Report_to = (dr["REPORT_TO"].ToString());
            _taskDetlCore.Completed = Boolean.Parse((dr["COMPLETED"].ToString()));
            return _taskDetlCore;
        }   
        public override void Save(object obj)
        {
            TaskCore _taskdtlcore = (TaskCore)obj;
            this._insertQuery.Replace("PROJECTID", _taskdtlcore.Project_id.ToString());
            this._insertQuery.Replace("TASK_TITLE_", _taskdtlcore.Title.ToString());
            this._insertQuery.Replace("STARTDATE", _taskdtlcore.Start_date.ToString());
            this._insertQuery.Replace("ENDDATE", _taskdtlcore.End_date.ToString());
            this._insertQuery.Replace("CATEGORY_", _taskdtlcore.Category.ToString());
            this._insertQuery.Replace("PRIORITY_", _taskdtlcore.Priority.ToString());
            this._insertQuery.Replace("REPORTTO", _taskdtlcore.Report_to.ToString());
            this._insertQuery.Replace("CREATEDBY", _taskdtlcore.CreatedBy.ToString());

            ExecuteQuery(this._insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            TaskCore _taskdtlcore = (TaskCore)obj;
            this._updateQuery.Replace("TASKID", _taskdtlcore.Task_id.ToString());
            this._updateQuery.Replace("TASK_TITLE_", _taskdtlcore.Title.ToString());
            this._updateQuery.Replace("PROJECTID", _taskdtlcore.Project_id.ToString());
            this._updateQuery.Replace("STARTDATE", _taskdtlcore.Start_date.ToString());
            this._updateQuery.Replace("ENDDATE", _taskdtlcore.End_date.ToString());
            this._updateQuery.Replace("CATEGORY_", _taskdtlcore.Category.ToString());
            this._updateQuery.Replace("PRIORITY_", _taskdtlcore.Priority.ToString());
            this._updateQuery.Replace("REPORTTO", _taskdtlcore.Report_to.ToString());
            this._updateQuery.Replace("MODIFIEDBY", _taskdtlcore.ModifyBy.ToString());
            this._updateQuery.Replace("COMPLETED_", _taskdtlcore.Completed.ToString());
            ExecuteQuery(this._updateQuery.ToString());   
        }
        public DataTable FindByAssignedTo(String Assigned_To)
        {
            String sSql = "SELECT  TASK_ID, TITLE FROM   Tasks  WHERE  ASSIGNED_TO ='" + Assigned_To + "'";
            DataTable dt = SelectByQuery(sSql);
            this.ExecuteStoreProcedure(sSql);
            return dt;
        }
        public void DeletebyId(long id, String user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Tasks' , ' and TASK_ID=''" + id + "''', '" + user + "'");
        }
        public TaskCore FindbyId(String Id)
        {
            //String Ssql = ("SELECT t.ASSIGNED_BY, t.REPORT_TO, t.TASK_ID, t.START_DATE, t.END_DATE, t.CATEGORY, t.PRIORITY, t.COMPLETED, t.TITLE, "
            //+ "dbo.Projects.PROJECT_TITLE AS PROJECT_ID FROM dbo.Tasks AS t INNER JOIN dbo.Admins AS ab ON t.ASSIGNED_BY = ab.UserName LEFT OUTER JOIN "
            //+ "dbo.Admins AS rt ON t.REPORT_TO = rt.UserName LEFT OUTER JOIN dbo.Projects ON t.PROJECT_ID = dbo.Projects.PROJECT_ID where TASK_ID='" + Id + "'");
            string Ssql = "SELECT PROJECT_ID,TITLE,CONVERT(VARCHAR,START_DATE,101) AS START_DATE,CONVERT(VARCHAR,END_DATE,101) AS END_DATE,CATEGORY,PRIORITY,REPORT_TO,COMPLETED,TASK_ID FROM Tasks WHERE TASK_ID=" + Id + "";
            DataTable dt = SelectByQuery(Ssql);
            TaskCore _taskCore = null;
            if (dt.Rows.Count != null)
                _taskCore = (TaskCore)this.MapObject(dt.Rows[0]);
            return _taskCore;
        }

        public DataTable FindRptById()
        {
            DataTable dt = this.ExecuteStoreProcedure("exec procTaskReport ");
            return dt;
        }
        public DataTable FindNotAssignedTask()
        {
            DataTable dt = this.ExecuteStoreProcedure("exec procNotAssignedTaskReport");
            return dt;
        }
        public DataTable FindTaskTitle(long ID)
        {
            DataTable dt = this.ExecuteStoreProcedure("SELECT TASK_ID, TITLE FROM TASKS WHERE PROJECT_ID="+ ID +"");
            return dt;
        }
        public Boolean CheckIfExists(string emp_id, long task_id)
        {
            return (CheckStatement("select FNAME from Assigned_Group_Task where TASK_ID =" + task_id + " and EMP_ID='" + emp_id + "'"));
        }
        public TaskCore FindTaskTitle(string task_id)
        {
            string sSql = "SELECT TASK_ID, TITLE FROM TASKS where TASK_ID='" + task_id + "'";
            DataTable dt = SelectByQuery(sSql);
            TaskCore _TaskCore = null;
            if (dt != null)
            {
                _TaskCore = (TaskCore)this.MapTaskObject(dt.Rows[0]);
            }
            return _TaskCore;
        }
        public List<TaskCore> FindTask(long Task_Id)
        {
            string sSql = "SELECT TASK_ID, TITLE FROM TASKS where TASK_ID='" + Task_Id + "'";
            DataTable dt = SelectByQuery(sSql);
            List<TaskCore> taskcore = new List<TaskCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TaskCore _tskcore = (TaskCore)this.MapTaskObject(dr);
                    taskcore.Add(_tskcore);
                }
            }
            return taskcore;
        }
        public object MapTaskObject(DataRow dr)
        {
            TaskCore _taskDetlCore = new TaskCore();
            _taskDetlCore.Task_id = long.Parse(dr["TASK_ID"].ToString());
            _taskDetlCore.Title = dr["Title"].ToString();
            return _taskDetlCore;
        }
        public List<TaskCore> Findall()
        {
            string sSql = this._selectQuery.ToString();
            DataTable dt = SelectByQuery(sSql);
            List<TaskCore> taskcore = new List<TaskCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TaskCore _tskcore = (TaskCore)this.MapObject(dr);
                    taskcore.Add(_tskcore);
                }
            }
            return taskcore;
        }
    }
}
