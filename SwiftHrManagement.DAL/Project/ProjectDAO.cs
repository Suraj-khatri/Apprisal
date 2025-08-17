using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.Project
{
    public class ProjectDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;

        public ProjectDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO PROJECTS(PROJECT_TITLE,START_DATE, END_DATE, CATEGORY, PRIORITY, OWNER, PROJECT_MANAGER, COMPLETED,CREATED_BY,CREATED_DATE)"
            + "  VALUES ('PROJECTTITLE','STARTDATE', 'ENDDATE', 'CATEGORY_', 'PRIORITY_', 'OWNER_', 'PROJECTMANAGER', 'COMPLETED_','CREATEDBY',GETDATE())");
            this._updateQuery = new StringBuilder("UPDATE PROJECTS SET PROJECT_TITLE='PROJECTTITLE',START_DATE='STARTDATE', END_DATE='ENDDATE',CATEGORY='CATEGORY_', "
            + " PRIORITY ='PRIORITY_', OWNER='OWNER_', PROJECT_MANAGER='PROJECTMANAGER', COMPLETED='COMPLETED_',MODIFIED_BY='MODIFIEDBY',MODIFIED_DATE=GETDATE() WHERE PROJECT_ID='PROJECTID'");
            
        }
        public override void Save(object obj)
        {
            ProjectCore _projectCore = (ProjectCore)obj;
            this._insertQuery.Replace("PROJECTTITLE", _projectCore.Title.ToString());
            this._insertQuery.Replace("STARTDATE", _projectCore.Start_date.ToString());
            this._insertQuery.Replace("ENDDATE", _projectCore.End_date.ToString());
            this._insertQuery.Replace("CATEGORY_", _projectCore.Category.ToString());
            this._insertQuery.Replace("PRIORITY_", _projectCore.Priority.ToString());
            this._insertQuery.Replace("OWNER_", _projectCore.Owner.ToString());
            this._insertQuery.Replace("PROJECTMANAGER", _projectCore.Prj_manager.ToString());
            this._insertQuery.Replace("COMPLETED_", _projectCore.Completed.ToString());
            this._insertQuery.Replace("CREATEDBY", _projectCore.CreatedBy.ToString());
            ExecuteQuery(this._insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            ProjectCore _projectCore = (ProjectCore)obj;
            this._updateQuery.Replace("PROJECTID", _projectCore.Project_id.ToString());
            this._updateQuery.Replace("PROJECTTITLE", _projectCore.Title.ToString());
            this._updateQuery.Replace("STARTDATE", _projectCore.Start_date.ToString());
            this._updateQuery.Replace("ENDDATE", _projectCore.End_date.ToString());
            this._updateQuery.Replace("CATEGORY_", _projectCore.Category.ToString());
            this._updateQuery.Replace("PRIORITY_", _projectCore.Priority.ToString());
            this._updateQuery.Replace("OWNER_", _projectCore.Owner.ToString());
            this._updateQuery.Replace("PROJECTMANAGER", _projectCore.Prj_manager.ToString());
            this._updateQuery.Replace("COMPLETED_", _projectCore.Completed.ToString());
            this._updateQuery.Replace("MODIFIEDBY", _projectCore.ModifyBy.ToString());
            ExecuteQuery(this._updateQuery.ToString());
        }
        public DataTable FindProjectTitlebyId(String Id)
        {
            DataTable dt = SelectByQuery("SELECT PROJECT_TITLE as Title, Project_id FROM PROJECTS WHERE PROJECT_ID ='" + Id + "'");
            return dt;
        }
        public Boolean CheckIfExists(string emp_id, long project_id)
        {
            return (CheckStatement("select EMP_ID from Assign_Project where PROJECT_ID =" + project_id + " and EMP_ID='" + emp_id + "'"));
        }
        public DataSet GetAssignedproject(long id)
        {
            return ReturnDataset("select id, dbo.EmployeeFullName(EMP_ID) as EMP_ID from Assign_Project where PROJECT_ID =" + id + "");
        }
        public ProjectCore GetprojectById(long id)
        {
            String Ssql = ("SELECT PROJECT_TITLE as Title, CATEGORY, CONVERT(VARCHAR,START_DATE,107) AS START_DATE,CONVERT(VARCHAR,END_DATE,107) AS END_DATE,PRIORITY, OWNER, PROJECT_MANAGER FROM PROJECTS "
            + " WHERE PROJECT_ID='" + id + "'").ToString();
            DataTable dt = SelectByQuery(Ssql);
            ProjectCore _prjcore = null;
            if (dt.Rows.Count != null)
                _prjcore = (ProjectCore)this.MapObjectForPrjTitle(dt.Rows[0]);
            return _prjcore;
        }
        public object MapObjectForPrjTitle(System.Data.DataRow dr)
        {
            ProjectCore _projCore = new ProjectCore();
            _projCore.Title = dr["Title"].ToString();
            _projCore.Start_date = dr["START_DATE"].ToString();
            _projCore.End_date = dr["END_DATE"].ToString();
            _projCore.Owner = dr["OWNER"].ToString();
            _projCore.Prj_manager = dr["PROJECT_MANAGER"].ToString();
            _projCore.Category = dr["CATEGORY"].ToString();
            _projCore.Priority = dr["PRIORITY"].ToString();
            return _projCore;
        }
        public List<ProjectCore> FindProject()
        {
            string sSql = this._selectQuery.ToString();
            DataTable dt = SelectByQuery("SELECT PROJECT_TITLE , PROJECT_ID FROM Projects");
            List<ProjectCore> _lstprojectCore = new List<ProjectCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProjectCore _prjCore = (ProjectCore)this.MapForPrjTitle(dr);
                    _lstprojectCore.Add(_prjCore);
                }
            }
            return _lstprojectCore;
        }
        public ProjectCore CheckProjectStatus(long id)
        {
            String Ssql = ("SELECT COMPLETED FROM Projects where PROJECT_ID=" + id + "").ToString();
            DataTable dt = SelectByQuery(Ssql);
            ProjectCore _prjcore = null;
            if (dt.Rows.Count != null)
                _prjcore = (ProjectCore)this.MapProjectStatus(dt.Rows[0]);
            return _prjcore;
        }
        public object MapProjectStatus(System.Data.DataRow dr)
        {
            ProjectCore _projCore = new ProjectCore();         
            _projCore.Completed = dr["COMPLETED"].ToString();
            return _projCore;
        }
        public ProjectCore FindProject(long id)
        {
            String Ssql = ("SELECT PROJECT_TITLE , PROJECT_ID FROM Projects where PROJECT_ID=" + id + "").ToString();
            DataTable dt = SelectByQuery(Ssql);
            ProjectCore _prjcore = null;
            if (dt.Rows.Count != null)
                _prjcore = (ProjectCore)this.MapForPrjTitle(dt.Rows[0]);
            return _prjcore;
        }
        public List<ProjectCore> FindAll(string struser)
        {
            string sSql = "exec procDisplaiProject 'a','" + struser + "'";
            DataTable dt = SelectByQuery(sSql);

            List<ProjectCore> _lstprojectCore = new List<ProjectCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProjectCore _prjCore = (ProjectCore)this.MapObject(dr);
                    _lstprojectCore.Add(_prjCore);
                }
            }
            return _lstprojectCore;
        }
        public ProjectCore FindbyId(long Id)
        {
            String Ssql = ("SELECT P.PROJECT_TITLE,P.PROJECT_ID,CONVERT(VARCHAR,P.START_DATE,101) AS START_DATE,CONVERT(VARCHAR,P.END_DATE,101) AS END_DATE,P.CATEGORY, P.PRIORITY,P.COMPLETED,"
                        + " P.PROJECT_MANAGER, P.OWNER FROM Projects AS P where P.PROJECT_ID='" + Id + "'");
            DataTable dt = SelectByQuery(Ssql);
            ProjectCore _prjcore = null;
            if (dt.Rows.Count != null)
                _prjcore = (ProjectCore)this.MapObject(dt.Rows[0]);
            return _prjcore;
        }
        public List<ProjectCore> FindByFilterFields(String userId, String _startDate, String _endDate, String Priority, String assignedUser)
        {
            string sSql = "exec procDisplaiProject 'a'," + filterstring(userId) + "," + filterstring(_startDate) + "," + filterstring(_endDate) + "," + filterstring(Priority) + "," + filterstring(assignedUser) + "";
            DataTable dt = SelectByQuery(sSql);

            List<ProjectCore> _lstprojectCore = new List<ProjectCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProjectCore _prjCore = (ProjectCore)this.MapObject(dr);
                    _lstprojectCore.Add(_prjCore);
                }
            }
            return _lstprojectCore;
        }

        public DataTable FindProjectTitle()
        {
            DataTable dt = this.ExecuteStoreProcedure("SELECT PROJECT_ID, PROJECT_TITLE FROM PROJECTS");
            return dt;
        }
        public object MapForPrjTitle(System.Data.DataRow dr)
        {
            ProjectCore _prjCore = new ProjectCore();
            _prjCore.Title = dr["PROJECT_TITLE"].ToString();
            _prjCore.Project_id = long.Parse(dr["PROJECT_ID"].ToString());
            return _prjCore;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            ProjectCore _projCore = new ProjectCore();
            _projCore.Title = dr["PROJECT_TITLE"].ToString();
            _projCore.Project_id = long.Parse(dr["PROJECT_ID"].ToString());
            _projCore.Start_date = dr["START_DATE"].ToString();
            _projCore.End_date = dr["END_DATE"].ToString();
            _projCore.Owner = dr["OWNER"].ToString();
            _projCore.Prj_manager = dr["PROJECT_MANAGER"].ToString();
            _projCore.Category = dr["CATEGORY"].ToString();
            _projCore.Priority = dr["PRIORITY"].ToString();
            _projCore.Completed = dr["COMPLETED"].ToString();
            return _projCore;
        }
        public void AssignProject(int Project_id, string Emp_Id, string user)
        {
            ExecuteQuery("exec ProcAssignProject 'i','" + user + "'," + Project_id + ",'" + Emp_Id + "'");
        }
        public void DeleteProjectById(long id, string User)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Projects' , ' and PROJECT_ID=''" + id + "''', '" + User + "'");
        }

        public void DeleteAssignedEmp(string id)
        {

            ExecuteQuery("exec ProcAssignProject 'd',@id=" + filterstring(id));
        }
    }
}
