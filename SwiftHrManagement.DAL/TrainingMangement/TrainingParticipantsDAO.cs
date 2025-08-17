using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.DAL.TrainingMangement
{
    public class TrainingParticipantsDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public TrainingParticipantsDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO TrainingParticipants (TRAINING_PROGRAM_ID, STAFF_ID,IS_APPROVED) VALUES('_TRAINING_PROGRAM_ID','_STAFF_ID','_IS_APPROVED')");
            this.updateQuery = new StringBuilder("UPDATE TrainingParticipants SET "
               + " TRAINING_PROGRAM_ID='_TRAINING_PROGRAM_ID',STAFF_ID ='_STAFF_ID',IS_APPROVED ='_IS_APPROVED' where ID=ID_");

        }

        public override void Save(object obj)
        {
            TrainingParticipantsCore tParticipants = (TrainingParticipantsCore)obj;
            this.insertQuery.Replace("_TRAINING_PROGRAM_ID", tParticipants.TrainingProgramId.ToString());
            this.insertQuery.Replace("_STAFF_ID", tParticipants.StaffId.ToString());
            this.insertQuery.Replace("_IS_APPROVED", tParticipants.IsApproved.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            TrainingParticipantsCore _tParticipants = (TrainingParticipantsCore)obj;
            BaseDomain basedomain = (BaseDomain)obj;
            this.updateQuery.Replace("ID_", _tParticipants.Id.ToString());
            this.updateQuery.Replace("_TRAINING_PROGRAM_ID", _tParticipants.TrainingProgramId.ToString());
            this.updateQuery.Replace("_STAFF_ID", _tParticipants.StaffId.ToString());
            this.updateQuery.Replace("_IS_APPROVED", _tParticipants.IsApproved.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }

        // Sujit        
        public void DeleteParticipantByID(long id)
        {
            string sSql = "";
            sSql = "DELETE FROM TrainingParticipants WHERE ID = " + id + "";
            this.ExecuteQuery(sSql);
        }
        //

        public List<TrainingParticipantsCore> FindAll(long id)
        {
            //string sSql = "SELECT TP.ID,ISNULL(T.BRANCH_ID,0) AS BRANCH_ID,ISNULL(B.BRANCH_NAME,'') AS BRANCH_NAME,TL.TRAINING_NAME,T.TRAINING_PROGRAM_TITLE as TRAINING_PROGRAM_ID ,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME"
            //+ " AS STAFF_ID,D.DEPARTMENT_ID,TP.IS_APPROVED FROM TrainingParticipants TP inner join TrainingProgram T on T.ID=TP.TRAINING_PROGRAM_ID"
            //+ " INNER JOIN EMPLOYEE E ON E.EMPLOYEE_ID =  TP.STAFF_ID INNER JOIN DEPARTMENTS D ON D.DEPARTMENT_ID = E.DEPARTMENT_ID"
            //+ " INNER JOIN TRAININGLIST TL ON TL.ID = T.TRAINING_ID"
            //+ " INNER JOIN Branches B ON B.BRANCH_ID = T.BRANCH_ID"
            //+ " WHERE TP.TRAINING_PROGRAM_ID='" + id + "'";

            string sSql = " SELECT TP.ID,ISNULL(E.BRANCH_ID,0) AS BRANCH_ID,TRAINING_PROGRAM_TITLE,"
                          + "  TL.TRAINING_NAME,T.TRAINING_PROGRAM_TITLE as TRAINING_PROGRAM_ID ,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + "
                            + " E.LAST_NAME AS STAFF_ID,E.DEPARTMENT_ID,TP.IS_APPROVED FROM TrainingParticipants TP"
                            + " INNER join TrainingProgram T on T.ID=TP.TRAINING_PROGRAM_ID"
                            + " LEFT JOIN EMPLOYEE E ON E.EMPLOYEE_ID =  TP.STAFF_ID"
                            + " INNER JOIN TRAININGLIST TL"
                            + " ON TL.ID = T.TRAINING_ID  WHERE TP.TRAINING_PROGRAM_ID= '" + id + "'";

            DataTable dt = SelectByQuery(sSql);
            List<TrainingParticipantsCore> tParticipants = new List<TrainingParticipantsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingParticipantsCore _tParticipants = (TrainingParticipantsCore)this.MapObject(dr);
                    tParticipants.Add(_tParticipants);
                }
            }
            return tParticipants;
        }
        public List<TrainingParticipantsCore> FindByField(string t_program)
        {
            string sSql = "SELECT TP.ID,TL.TRAINING_NAME as TRAINING_PROGRAM_ID ,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS STAFF_ID"
            + " FROM TrainingParticipants TP inner join TrainingList TL on TP.TRAINING_PROGRAM_ID=TL.ID INNER JOIN Employee E ON TP.STAFF_ID="
            + " E.EMPLOYEE_ID where TP.TRAINING_PROGRAM_ID='" + t_program + "'";
            DataTable dt = SelectByQuery(sSql);

            List<TrainingParticipantsCore> tParticipants = new List<TrainingParticipantsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingParticipantsCore _tParticipants = (TrainingParticipantsCore)this.MapObject(dr);
                    tParticipants.Add(_tParticipants);
                }
            }
            return tParticipants;
        }
        public List<TrainingParticipantsCore> FindFullNameofParticipants()
        {
            string sSql = "select STAFF_ID,dbo.EmployeeFullName(STAFF_ID)as STAFF_NAME from TrainingParticipants";
            DataTable dt = SelectByQuery(sSql);
            List<TrainingParticipantsCore> emp = new List<TrainingParticipantsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainingParticipantsCore _emp = (TrainingParticipantsCore)this.MapSelectedObject(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public object MapSelectedObject(DataRow dr)
        {
            TrainingParticipantsCore tParticipants = new TrainingParticipantsCore();
            tParticipants.StaffId = dr["STAFF_ID"].ToString();
            tParticipants.StaffName = dr["STAFF_NAME"].ToString();
            return tParticipants;
        }
        public TrainingParticipantsCore FindById(long Id)
        {
            string sSql = "SELECT TP.ID,TL.TRAINING_NAME,TM.TRAINING_PROGRAM_TITLE,TP.STAFF_ID,E.BRANCH_ID,E.DEPARTMENT_ID,TP.IS_APPROVED FROM"
            +" TrainingParticipants TP WITH(NOLOCK) INNER JOIN TrainingProgram TM WITH(NOLOCK) ON TP.TRAINING_PROGRAM_ID=TM.ID INNER JOIN TrainingList TL"
            + " WITH(NOLOCK) ON TL.ID=TM.TRAINING_ID INNER JOIN Employee E WITH(NOLOCK) ON E.EMPLOYEE_ID=TP.STAFF_ID WHERE TP.ID='"+Id+"'";

            DataTable dt = SelectByQuery(sSql);
            TrainingParticipantsCore _tParticipants = null;
            if (dt != null)
                _tParticipants = (TrainingParticipantsCore)this.MapObject(dt.Rows[0]);
            return _tParticipants;
        }

        public override object MapObject(DataRow dr)
        {
            TrainingParticipantsCore tParticipants = new TrainingParticipantsCore();
            tParticipants.Id = long.Parse(dr["ID"].ToString());
            tParticipants.StaffId = dr["STAFF_ID"].ToString();

            tParticipants.IsApproved = Convert.ToBoolean(dr["IS_APPROVED"]);

            if (tParticipants.IsApproved == true)
                tParticipants.Approved = "Yes";
            else
                tParticipants.Approved = "No";                      

            tParticipants.DepartmentID = dr["DEPARTMENT_ID"].ToString();
            tParticipants.TrainingCategory = dr["TRAINING_NAME"].ToString();
            tParticipants.BranchName = (dr["BRANCH_ID"]).ToString();
            tParticipants.BranchID = Convert.ToInt32((dr["BRANCH_ID"]));
            tParticipants.TrainingProgramId = dr["TRAINING_PROGRAM_TITLE"].ToString();            
            return tParticipants;
        }
    }
}