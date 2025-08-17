using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.LeaveManagement;

namespace SwiftHrManagement.DAL.LeaveManagement
{
    public class LeaveAssignmentDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;
        public LeaveAssignmentDAO()
        {

            this._insertQuery = new StringBuilder("INSERT INTO leaveAssignment(EMPLOYEE_ID, LEAVE_TYPE_ID, IS_DISABLED, CREATED_BY, CREATED_DATE,"
            + " NO_OF_DAYS_ACTUAL,IS_SATURDAY,IS_HOLIDAY,FORCE_LEAVE_DEDUCT,LAST_YEAR_LEAVE,HOUR_BALANCE) VALUES(EMPLOYEEID,LEAVETYPEID,ISDISABLED,CREATEDBY,"
            + " CREATEDDATE,isnull(NOOFDAYSACTUAL,''),ISSATURDAY,ISPUBLIC,isnull(force_leave,''),LAST_LEAVE_DAYS,HOURBALANCE)");
            //
            this._updateQuery = new StringBuilder("UPDATE leaveAssignment SET EMPLOYEE_ID=EMPLOYEEID,LEAVE_TYPE_ID=LEAVETYPEID,IS_DISABLED "
            + " =ISDISABLED,MODIFIED_BY=MODIFIEDBY,MODIFIED_DATE=MODIFIEDDATE,NO_OF_DAYS_ACTUAL=isnull(NOOFDAYSACTUAL,''),IS_SATURDAY=ISSATURDAY,"
            + " IS_HOLIDAY=ISPUBLIC,FORCE_LEAVE_DEDUCT=isnull(force_leave,''),LAST_YEAR_LEAVE=LAST_LEAVE_DAYS,HOUR_BALANCE=HOURBALANCE WHERE ID = ID_");
            //
            this._selectQuery = new StringBuilder("SELECT LA.ID, LA.NO_OF_DAYS_ACTUAL,dbo.GetEmployeeFullNameOfId(LA.EMPLOYEE_ID) as Employee_id ,LA.HOUR_BALANCE, "
            + " case when LA.IS_DISABLED='1' then 'Yes' when LA.IS_DISABLED='0' then 'No' end as IS_DISABLED,LT.NAME_OF_LEAVE as LEAVE_TYPE_ID,FORCE_LEAVE_DEDUCT FROM "
            + "leaveAssignment AS LA inner join Admins A on A.Name=LA.EMPLOYEE_ID, LeaveTypes AS LT WHERE LA.LEAVE_TYPE_ID = LT.ID");

           
        }
        public override void Save(object obj)
        {
            LeaveAssignmentCore _leaveAssign = (LeaveAssignmentCore)obj;
            this._insertQuery.Replace("EMPLOYEEID",filterstring( _leaveAssign.Employee_id));
            this._insertQuery.Replace("LEAVETYPEID",filterstring( _leaveAssign.Leave_Type_Id.ToString()));
            this._insertQuery.Replace("ISDISABLED",filterstring( _leaveAssign.Isdisabled));
            this._insertQuery.Replace("NOOFDAYSACTUAL",filterstring( _leaveAssign.No_Of_Days_Actual.ToString()));
            this._insertQuery.Replace("CREATEDBY",filterstring( _leaveAssign.CreatedBy));
            this._insertQuery.Replace("CREATEDDATE",filterstring( _leaveAssign.CreatedDate.ToString()));
            this._insertQuery.Replace("ISSATURDAY",filterstring( _leaveAssign.IsSaturday));
            this._insertQuery.Replace("ISPUBLIC",filterstring( _leaveAssign.IsPublic));
            this._insertQuery.Replace("force_leave",filterstring(  _leaveAssign.ForceLeave));
            this._insertQuery.Replace("LAST_LEAVE_DAYS", filterstring((((int)(double.Parse(_leaveAssign.LastYearLeave.ToString()) * 10)) / 10).ToString()));
            this._insertQuery.Replace("HOURBALANCE", filterstring(((double.Parse(_leaveAssign.LastYearLeave.ToString()) - (((int)(double.Parse(_leaveAssign.LastYearLeave.ToString()) * 10)) / 10)) * 8).ToString()));
            

            ExecuteQuery(_insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            LeaveAssignmentCore _leaveAssign = (LeaveAssignmentCore)obj;
            this._updateQuery.Replace("ID_",filterstring( _leaveAssign.Id.ToString()));
            this._updateQuery.Replace("EMPLOYEEID",filterstring( _leaveAssign.Employee_id));
            this._updateQuery.Replace("LEAVETYPEID",filterstring( _leaveAssign.Leave_Type_Id.ToString()));
            this._updateQuery.Replace("ISDISABLED",filterstring( _leaveAssign.Isdisabled));
            this._updateQuery.Replace("NOOFDAYSACTUAL",filterstring( _leaveAssign.No_Of_Days_Actual.ToString()));
            this._updateQuery.Replace("MODIFIEDBY", filterstring(_leaveAssign.ModifyBy));
            this._updateQuery.Replace("MODIFIEDDATE",filterstring( _leaveAssign.CreatedDate.ToString()));
            
            this._updateQuery.Replace("ISSATURDAY",filterstring( _leaveAssign.IsSaturday));
            this._updateQuery.Replace("ISPUBLIC",filterstring( _leaveAssign.IsPublic));
            this._updateQuery.Replace("force_leave",filterstring( _leaveAssign.ForceLeave));
            this._updateQuery.Replace("LAST_LEAVE_DAYS", filterstring((((int)(double.Parse(_leaveAssign.LastYearLeave.ToString()) * 10)) / 10).ToString()));
            this._updateQuery.Replace("HOURBALANCE", filterstring(((double.Parse(_leaveAssign.LastYearLeave.ToString()) - (((int)(double.Parse(_leaveAssign.LastYearLeave.ToString()) * 10)) / 10)) * 8).ToString()));
           
            ExecuteQuery(_updateQuery.ToString());
        }
        public LeaveAssignmentCore FindallById(long Id)
        {
            string sSql = "select ID,EMPLOYEE_ID,LEAVE_TYPE_ID,NO_OF_DAYS_ACTUAL,HOUR_BALANCE,case when IS_DISABLED='1' then 'Yes' when IS_DISABLED='0' then 'No' end as IS_DISABLED,"
            + " case when IS_SATURDAY='1' then 'Yes' when IS_SATURDAY='0' then 'No' end as IS_SATURDAY,case when IS_HOLIDAY='1' then 'Yes' when"
            + " IS_HOLIDAY='0' then 'No' end as IS_HOLIDAY,APPROVED_THORUGH from  leaveAssignment where ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            LeaveAssignmentCore _leaveAssign = null;
            if (dt != null)
                _leaveAssign = (LeaveAssignmentCore)this.MapObject(dt.Rows[0]);
            return _leaveAssign;
        }
        public Boolean ValidateLeaveType(int Emp_Id, int Leave_Type)
        {
            String sSql = "select LEAVE_TYPE_ID, NO_OF_DAYS_ACTUAL, EMPLOYEE_ID from leaveAssignment where EMPLOYEE_ID = " + Emp_Id + " and "
            + " LEAVE_TYPE_ID = " + Leave_Type + "";
            return CheckStatement(sSql);
        }
        public Boolean Isdisabled(String _leaveTpe)
        {
            String sSql = "select LT.NAME_OF_LEAVE from LeaveTypes LT, leaveAssignment LA where LA.LEAVE_TYPE_ID=LT.ID and LT.IS_ACTIVE ='False' "
            + " and LT.NAME_OF_LEAVE = '"+ _leaveTpe +"'";
            return CheckStatement(sSql);
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            LeaveAssignmentCore _leaveAssign = new LeaveAssignmentCore();
            _leaveAssign.Id = long.Parse(dr["ID"].ToString());
            _leaveAssign.Employee_id = dr["EMPLOYEE_ID"].ToString();
            _leaveAssign.Leave_Type_Id = (dr["LEAVE_TYPE_ID"].ToString());
            _leaveAssign.No_Of_Days_Actual = (dr["NO_OF_DAYS_ACTUAL"].ToString());
            _leaveAssign.Isdisabled = (dr["IS_DISABLED"].ToString());
            _leaveAssign.IsPublic = (dr["IS_HOLIDAY"].ToString());
            _leaveAssign.IsSaturday = (dr["IS_SATURDAY"].ToString());
            _leaveAssign.ApproveThrough = (dr["APPROVED_THORUGH"].ToString());
            _leaveAssign.BalanceHour = (dr["HOUR_BALANCE"].ToString());
            return _leaveAssign; 
        }
        public void DeleteById(long Id, String UserName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from leaveAssignment' , ' and  ID=''" + Id + "''', '" + UserName + "'");
        }
    }
}
