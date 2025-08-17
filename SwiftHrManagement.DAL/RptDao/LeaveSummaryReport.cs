using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.RptDao
{
    public class LeaveSummaryReport:BaseDAO
    {
        private StringBuilder _selectQuery;
        public LeaveSummaryReport()
        {
            this._selectQuery = new StringBuilder("EXEC ProcLeaveSummaryReport ");

        }

        public String FindLeavesummaryReport(String Flag, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC ProcLeaveSummaryReport @flag='i',@datefrom=" + filterstring(FromDate)
                + ",@dateto=" + filterstring(ToDate));

            return (_selectQuery.ToString());
        }

        public DataSet FindLeavesummaryReport(String sSql)
        {
            return ReturnDataset(sSql);
        }
        public String FindLeavesummaryReport(String Flag, String branch, String dept, String empID, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC ProcLeaveSummaryReport " + filterstring(Flag) + "," + filterstring(branch) + "," + filterstring(dept) + "," + filterstring(empID) + "," + filterstring(FromDate) + "," + filterstring(ToDate) + "");
            return (_selectQuery.ToString());
        }
        public String FindLeaveRecordType(String branch, String dept, String empID, String FromDate, string Todate)
        {
            _selectQuery = new StringBuilder("EXEC [ProcLeaveSummaryRecords] " + filterstring(branch) + "," + filterstring(dept) + ", " + filterstring(empID) + ",'" + FromDate + "','" + Todate + "'");
            return (_selectQuery.ToString());
        }


        public String FindLeavesummaryReport(String branch, String dept, String empID, String asDate)
        {
            _selectQuery = new StringBuilder("EXEC ProcLeaveSummaryReport 'j','" + branch + "','" + dept + "','" + empID + "','" + asDate + "'");
            return (_selectQuery.ToString());
        }
        public String FindLeavesummaryReport2(String empID, String FromDate, String Todate)
        {
            _selectQuery = new StringBuilder("EXEC ProcLeaveSummaryReport 'a', @empID=" + filterstring(empID) + ",@datefrom=" + filterstring(FromDate) + ",@dateto=" + filterstring(Todate));
            return (_selectQuery.ToString());
        }

        public String FindLeaveIncashmentReport(String reptype, String branch, String dept, String empid, String year)
        {
            string sql = "Exec PROC_LEAVE_INCASHMENT @flag=" + filterstring(reptype)
                        + ",@bs_year=" + filterstring(year)
                        + ",@branchid =" + filterstring(branch)
                        + ",@dept=" + filterstring(dept)
                        + ",@emp_id=" + filterstring(empid);

            _selectQuery = new StringBuilder(sql);
            return (_selectQuery.ToString());
        }

        public String FindLeaveIndividualReport(String flag, String empId, String year)
        {
            string sql = "Exec Proc_LeaveIndividualReport @flag=" + filterstring(flag)
                        + ",@bs_year=" + filterstring(year)
                        + ",@emp_id=" + filterstring(empId);

            _selectQuery = new StringBuilder(sql);
            return (_selectQuery.ToString());
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
