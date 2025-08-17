using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.LeaveManagementModule.LeaveAssignment
{
    public class LeaveAssignmentDAO
    {
        private DbService service;

        public LeaveAssignmentDAO()
        {
            this.service = new DbService();
        }

        public DataRow SelectById(string ID)
        {
            var sql = "EXEC proc_LeaveAssignment";
            sql += " @flag = 's'";
            sql += ", @ID = " + this.service.filterstring(ID);
            

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        public DataSet SelectAssignedLeaveById(string ID, char IsPersonal)
        {
            var sql = "EXEC proc_LeaveAssignment";
            sql += " @flag = 's'";
            sql += ", @ID = " + this.service.filterstring(ID);
            sql += ",@IsPersonal = " + this.service.filterstring(IsPersonal.ToString());

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds;
        }

        public DataSet SelectAssignedLeaveByEmpId(string empId,char IsPersonal)
        {
            var sql = "EXEC proc_LeaveAssignment ";
            sql += "@flag = 'sl'";
            sql += ",@Employee_ID = " + this.service.filterstring(empId);
            sql += ",@IsPersonal = " + this.service.filterstring(IsPersonal.ToString());

            var ds = this.service.ReturnDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds;
        }


        public DataTable Save(string EMPLOYEE_ID,string LEAVE_TYPE_ID,string NO_OF_DAYS_ACTUAL,string IS_DISABLED
				            ,string IS_SATURDAY,string IS_HOLIDAY,string IS_LFA
				            ,string IS_CASHABLE,string IS_UNLIMITED,string IS_HALFDAY,string IS_SUBSTITUTED,string RELIEVING
				            ,string LAST_YEAR_LEAVE,string FORCE_LEAVE_DEDUCT
                            , string USER, string ID, string NxtYrDays, string NxtYrDefault, string fromDate, string toDate,string minReqDays,string maxReqDays)
        {
            var sql = "EXEC proc_LeaveAssignment";
            sql += " @flag = " + (ID == "0" || ID == "" ? "'i'" : "'u'");
				
            sql += ", @ID = " + this.service.filterstring(ID);
            sql += ", @Employee_ID = " + this.service.filterstring(EMPLOYEE_ID);
            sql += ", @LeaveType = " + this.service.filterstring(LEAVE_TYPE_ID);
            sql += ", @DefaultDays = " + this.service.filterstring(NO_OF_DAYS_ACTUAL);
            sql += ", @LastYrDays = " + this.service.filterstring(LAST_YEAR_LEAVE);
            sql += ", @ApplyLFA = " + IS_LFA;
            sql += ", @LFAdays = " + this.service.filterstring(FORCE_LEAVE_DEDUCT);
            sql += ", @Active = " + IS_DISABLED;
            sql += ", @Cashable = " + IS_CASHABLE;
            sql += ", @Unlimited = " + IS_UNLIMITED;
            sql += ", @HalfDay = " + IS_HALFDAY;
            sql += ", @Saturday = " + IS_SATURDAY;
            sql += ", @Holiday = " + IS_HOLIDAY;
            sql += ", @Substituted = " +IS_SUBSTITUTED;
            sql += ", @Relieving = " + RELIEVING;
            sql += ", @entryUser = " + this.service.filterstring(USER);
            sql += ", @NxtYrDays = " + this.service.filterstring(NxtYrDays);
            sql += ", @NxtYrDefault = " + NxtYrDefault;
            sql += ", @fromDate = " +this.service.filterstring(fromDate);
            sql += ", @toDate = " +this.service.filterstring(toDate);
            sql += ", @min_req_days = " + this.service.filterstring(minReqDays);
            sql += ", @max_req_days = " + this.service.filterstring(maxReqDays);
            
            return this.service.ReturnDataset(sql).Tables[0];

        }

        public DataTable GetDefaultValueOfLeave(string ID,string empId)
        {
            var sql = "EXEC proc_LeaveAssignment @flag = 'g',@leaveType=" + ID + ",@Employee_ID=" + empId;
            return this.service.ReturnDataset(sql).Tables[0];
        }

        public DataTable DeleteById(string ID)
        {
            var sql = "EXEC proc_LeaveAssignment @flag = 'd',@ID = " + ID;
            return this.service.ReturnDataset(sql).Tables[0];
        }
    }
}
