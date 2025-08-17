using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.DAL.RptDao
{
    public class AttendanceReports : BaseDAO
    {
        private StringBuilder _selectQuery;
        public AttendanceReports()
        {
            this._selectQuery = new StringBuilder("EXEC procMonthlyAttendanceReport ");
            this._selectQuery = new StringBuilder("EXEC ProcMonthlyReport ");
        }
        public String EmpSearch(String FromDate, String ToDate, String Emp_Id)
        {
            _selectQuery = new StringBuilder("EXEC procMonthlyAttendanceReport 'a'," + filterstring(FromDate) + "," + filterstring(ToDate) + "," + filterstring(Emp_Id) + "");
            return (_selectQuery.ToString());
        }
        public DataSet EmpSearch(String sSql)
        {
            return ReturnDataset(sSql);
        }

        public String DateWiseSearch(String FromDate, String ToDate, String branch_id, String dept_id)
        {
            _selectQuery = new StringBuilder("EXEC ProcMonthlyReport 'd'," + filterstring(FromDate) + "," + filterstring(ToDate) + "," + filterstring(branch_id) + "," + filterstring(dept_id) + "");
            return (_selectQuery.ToString());
        }
        public String DailyReport(String Flag, String OnDate, String toDate, String branch_id, String dept_id, String emp_id)
        {
            _selectQuery = new StringBuilder("EXEC ProcMonthlyReport " + filterstring(Flag) + "," + filterstring(OnDate) + ","
            + " " + filterstring(toDate) + "," + filterstring(branch_id) + "," + filterstring(dept_id) + ","
            + " " + filterstring(emp_id) + "");
            return (_selectQuery.ToString());
        }
        public String AttendanceTimeWiseRpt(String rptNature, String fromDate, String toDate, String branchId, String deptId)
        {
            _selectQuery = new StringBuilder("EXEC [ProcAttendanceRpt] @FLAG='I',@RPT_NATURE=" + filterstring(rptNature) + ","
            + " @FROM_DATE=" + filterstring(fromDate) + ",@TO_DATE=" + filterstring(toDate) + ",@BRANCH_ID=" + filterstring(branchId) + ","
            + " @DEPT_ID=" + filterstring(deptId) + "");
            return (_selectQuery.ToString());
        }
        public DataSet DateWiseSearch(String sSql)
        {
            return ReturnDataset(sSql);
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

