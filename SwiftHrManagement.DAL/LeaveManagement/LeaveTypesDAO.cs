using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.LeaveManagement
{
    public class LeaveTypesDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;

        public LeaveTypesDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO LeaveTypes (NAME_OF_LEAVE, LEAVE_DETAILS, NO_OF_DAYS_DEFAULT, "
            + " OCCURRENCE, MAX_ACCUMULATION, NATURE, IS_ACTIVE, CREATED_BY, CREATED_DATE,IS_CASHABLE,IS_UNLIMITED,IS_HOURLY,TOTAL_WORKING_HOUR,LFADAYS,IS_SUBSTITUTED)"
            + " VALUES ('NAMEOFLEAVE', 'LEAVEDETAILS', 'NOOFDAYSDEFAULT', "
            + " 'OCCURRENCE_', 'MAXACCUMULATION', 'NATURE_', 'ISACTIVE', 'CREATEDBY', 'CREATEDDATE','ISCASHABLE','ISUNLIMITED','ISHOURLY','TOTALWORKINGHOUR',_LFADAYS,_ISSUBSTITUTED)");
            this._updateQuery = new StringBuilder("UPDATE LeaveTypes SET NAME_OF_LEAVE='NAMEOFLEAVE',"
            +" NO_OF_DAYS_DEFAULT = 'NOOFDAYSDEFAULT',OCCURRENCE='OCCURRENCE_',"
            + " MAX_ACCUMULATION='MAXACCUMULATION',NATURE='NATURE_',IS_ACTIVE='ISACTIVE',LEAVE_DETAILS='LEAVEDETAILS',MODIFIED_BY='MODIFIEDBY',"
            + " MODIFIED_DATE='MODIFIEDDATE',IS_CASHABLE='ISCASHABLE',IS_UNLIMITED='ISUNLIMITED',IS_HOURLY='ISHOURLY',LFADAYS=_LFADAYS,IS_SUBSTITUTED=_ISSUBSTITUTED WHERE ID = 'ID_'");
            this._selectQuery = new StringBuilder("SELECT ID, NAME_OF_LEAVE,case when IS_CASHABLE ='True' then 'Yes' when IS_CASHABLE='False' then 'No' "
            + " end 'IS_CASHABLE',LEAVE_DETAILS, NO_OF_DAYS_DEFAULT, OCCURRENCE, MAX_ACCUMULATION, NATURE, IS_ACTIVE,IS_UNLIMITED,IS_HOURLY,TOTAL_WORKING_HOUR,LFADAYS,IS_SUBSTITUTED FROM LeaveTypes with (nolock) where 1=1 ");
        }
        public override void Save(object obj)
        {
            LeaveType _officialCal = (LeaveType)obj;
            this._insertQuery.Replace("NAMEOFLEAVE", _officialCal.Name_Of_Leave);
            this._insertQuery.Replace("LEAVEDETAILS", _officialCal.Leave_Details);
            this._insertQuery.Replace("NOOFDAYSDEFAULT", _officialCal.No_Of_Days_Default.ToString());
            this._insertQuery.Replace("OCCURRENCE_", _officialCal.Occurance.ToString());
            this._insertQuery.Replace("NATURE_", _officialCal.Nature);
            this._insertQuery.Replace("ISACTIVE", _officialCal.IsActive);
            this._insertQuery.Replace("MAXACCUMULATION", _officialCal.Max_Accumulation.ToString());
            this._insertQuery.Replace("CREATEDBY", _officialCal.CreatedBy);
            this._insertQuery.Replace("CREATEDDATE", _officialCal.CreatedDate.ToString());
            this._insertQuery.Replace("ISCASHABLE", _officialCal.Cashable.ToString());
            this._insertQuery.Replace("ISUNLIMITED", _officialCal.Unlimited.ToString());
            this._insertQuery.Replace("ISHOURLY", _officialCal.Hourly.ToString());
            this._insertQuery.Replace("TOTALWORKINGHOUR", _officialCal.WorkingHour.ToString());
            this._insertQuery.Replace("_LFADAYS", filterstring(_officialCal.LFADays.ToString()));
            this._insertQuery.Replace("_ISSUBSTITUTED", filterstring(_officialCal.IsSubstituted.ToString()));
            this.ExecuteQuery(this._insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            LeaveType _officialCal = (LeaveType)obj;
            this._updateQuery.Replace("ID_", _officialCal.Id.ToString());
            this._updateQuery.Replace("NAMEOFLEAVE", _officialCal.Name_Of_Leave);
            this._updateQuery.Replace("LEAVEDETAILS", _officialCal.Leave_Details);
            this._updateQuery.Replace("NOOFDAYSDEFAULT", _officialCal.No_Of_Days_Default.ToString());
            this._updateQuery.Replace("OCCURRENCE_", _officialCal.Occurance.ToString());
            this._updateQuery.Replace("NATURE_", _officialCal.Nature);
            this._updateQuery.Replace("ISACTIVE", _officialCal.IsActive);
            this._updateQuery.Replace("MAXACCUMULATION", _officialCal.Max_Accumulation.ToString());
            this._updateQuery.Replace("ISCASHABLE", _officialCal.Cashable.ToString());
            this._updateQuery.Replace("ISUNLIMITED", _officialCal.Unlimited.ToString());
            this._updateQuery.Replace("MODIFIEDBY", _officialCal.ModifyBy);
            this._updateQuery.Replace("MODIFIEDDATE", _officialCal.ModifyDate.ToString());
            this._updateQuery.Replace("ISHOURLY", _officialCal.Hourly.ToString());
            this._updateQuery.Replace("_LFADAYS",filterstring( _officialCal.LFADays.ToString()));
            this._updateQuery.Replace("_ISSUBSTITUTED", filterstring(_officialCal.IsSubstituted.ToString()));
         //   this._updateQuery.Replace("TOTALWORKINGHOUR", _officialCal.WorkingHour.ToString());
            this.ExecuteQuery(this._updateQuery.ToString());
        }
        public List<LeaveType> Findall()
        {
            DataTable dt = SelectByQuery(this._selectQuery.ToString());
            List<LeaveType> _leaveType = new List<LeaveType>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType _cal = (LeaveType)this.MapObject(dr);
                    _leaveType.Add(_cal);
                }
            }
            return _leaveType;
        }
        public List<LeaveType> FindByFilter(String LeaveType, String FromDate, String ToDate)
        {
            String sSql = this._selectQuery.ToString();
            if (LeaveType != "")
            {
                sSql = sSql + " and NAME_OF_LEAVE LIKE '" + FilterQuote(LeaveType) + "%'";
            }
            //if (FromDate != "")
            //{
            //    sSql = sSql + " and FROM_DATE>= '" + FilterQuote(FromDate) + "'";
            //}
            //if (ToDate != "")
            //{
            //    sSql = sSql + " and TO_DATE <= '" + FilterQuote(ToDate) + "'";
            //}
            DataTable dt = SelectByQuery(sSql);
            List<LeaveType> _leaveType = new List<LeaveType>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType _cal = (LeaveType)this.MapObject(dr);
                    _leaveType.Add(_cal);
                }
            }
            return _leaveType;
        }
        public List<LeaveType> FindLeaveByid(String User)
        {
            string sSql = "SELECT LT.NAME_OF_LEAVE, LT.ID FROM LeaveTypes AS LT, leaveAssignment AS LA WHERE LT.ID = LA.LEAVE_TYPE_ID "
            + " AND LA.EMPLOYEE_ID='"+ User +"'";
            DataTable dt = SelectByQuery(sSql);
            List<LeaveType> _leaveType = new List<LeaveType>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType _lType = (LeaveType)this.MapObjectLeave(dr);
                    _leaveType.Add(_lType);
                }
            }
            return _leaveType;
        }
        public List<LeaveType> FindLeave()
        {
            string sSql = "SELECT NAME_OF_LEAVE, ID FROM LeaveTypes where IS_ACTIVE=1";
            DataTable dt = SelectByQuery(sSql);
            List<LeaveType> _leaveType = new List<LeaveType>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType _lType = (LeaveType)this.MapObjectLeave(dr);
                    _leaveType.Add(_lType);
                }
            }
            return _leaveType;
        }
        public List<LeaveType> FindLeave(long empid)
        {
            string sSql = "select lt.NAME_OF_LEAVE , lt.ID from LeaveTypes lt, leaveAssignment la where lt.ID = la.LEAVE_TYPE_ID and "
            + " la.EMPLOYEE_ID=" + empid + " and IS_DISABLED=1";
            
            DataTable dt = SelectByQuery(sSql);
            List<LeaveType> _leaveType = new List<LeaveType>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType _lType = (LeaveType)this.MapObjectLeave(dr);
                    _leaveType.Add(_lType);
                }
            }
            return _leaveType;
        }
        public LeaveType FindDefaultDays(String NameOfLeave)
        {
            string sSql = "SELECT NO_OF_DAYS_DEFAULT FROM LEAVETYPES WHERE NAME_OF_LEAVE= '" + NameOfLeave + "'";
            DataTable dt = SelectByQuery(sSql);
            LeaveType _leaveType = null;
            if (dt != null)
                _leaveType = (LeaveType)this.MapForDefaultDays(dt.Rows[0]);
            return _leaveType;
        }
        public LeaveType FindAssignDays(string nameOfLeave,string empId)
        {

            string sSql = "select Top 1  NO_OF_DAYS_DEFAULT from( select 1 sn,NO_OF_DAYS_ACTUAL as NO_OF_DAYS_DEFAULT from leaveAssignment LA " 
             + " join LeaveTypes LT on LA.LEAVE_TYPE_ID=LT.ID  where LT.NAME_OF_LEAVE='" + nameOfLeave + "' and EMPLOYEE_ID='" + empId + "'"
              + " union all "
             + " select 2,0 "
             + " )a order by sn ";
            
            DataTable dt = SelectByQuery(sSql);
            LeaveType _leaveType = null;
            if (dt != null)
                _leaveType = (LeaveType)this.MapForDefaultDays(dt.Rows[0]);
            return _leaveType;

        }

        public object MapForDefaultDays(DataRow dr)
        {
            LeaveType _leave = new LeaveType();
            _leave.No_Of_Days_Default = long.Parse(dr["NO_OF_DAYS_DEFAULT"].ToString());
            return _leave;
        }
        public  object MapObjectLeave(DataRow dr)
        {
            LeaveType _leave = new LeaveType();
            _leave.Id = long.Parse(dr["ID"].ToString());
            _leave.Name_Of_Leave = dr["NAME_OF_LEAVE"].ToString();
            return _leave;
        }
        public LeaveType FindallById(long Id)
        {
            string sSql = this._selectQuery.Append(" AND ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LeaveType _leaveType = null;
            if (dt != null)
                _leaveType = (LeaveType)this.MapObject(dt.Rows[0]);
            return _leaveType;
        }
        public bool IfExists(String leaveType)
        {
            String sSql = "select NAME_OF_LEAVE from LeaveTypes where NAME_OF_LEAVE ='"+ leaveType +"'";
            return CheckStatement(sSql);
        }
        public override object MapObject(DataRow dr)
        {
            LeaveType _leave = new LeaveType();
            _leave.Id  = long.Parse(dr["ID"].ToString());
            _leave.Name_Of_Leave = dr["NAME_OF_LEAVE"].ToString();
            _leave.Leave_Details = (dr["LEAVE_DETAILS"].ToString());
            //_leave.From_Date = (dr["FROM_DATE"].ToString());
            //_leave.To_Date = (dr["TO_DATE"].ToString());
            _leave.Occurance = dr["OCCURRENCE"].ToString();
            _leave.No_Of_Days_Default = long.Parse(dr["NO_OF_DAYS_DEFAULT"].ToString());
            _leave.IsActive = dr["IS_ACTIVE"].ToString();
            _leave.Max_Accumulation = long.Parse(dr["MAX_ACCUMULATION"].ToString());
            _leave.Nature = dr["NATURE"].ToString();
            _leave.Cashable = (dr["IS_CASHABLE"]).ToString();
            _leave.Unlimited = (dr["IS_UNLIMITED"]).ToString();
            _leave.Hourly = (dr["IS_HOURLY"]).ToString();
            _leave.WorkingHour = dr["TOTAL_WORKING_HOUR"].ToString();
            _leave.LFADays = dr["LFADAYS"].ToString();
            _leave.IsSubstituted = dr["IS_SUBSTITUTED"].ToString();
            return _leave; 
        }
        public void DeleteById(long Id, String UserName)
        {
            ExecuteQuery("exec proc_DeleteLeaveTypes 'd',"+ filterstring(Id.ToString()) +","+ filterstring(UserName) +"");      
        }

        public string  IsLFAAssign()
        {

           string GetLFA =  GetSingleresult("SELECT LFADAYS FROM LeaveTypes WHERE LFADAYS<>0");

           return GetLFA.ToString();

        }
        public string IsLFAAssign(string TypeId)
        {   
            string GetLFA = GetSingleresult("SELECT LFADAYS FROM LeaveTypes WHERE ID = "+TypeId);
             return GetLFA.ToString();

        }
        public string IsDefaultLFA(string LeaveTypeId)
        {
            string NoOfDefaultLFA = GetSingleresult("select LFADAYS from LeaveTypes where ID ="+LeaveTypeId);
            return NoOfDefaultLFA.ToString();

        }
    }
}
