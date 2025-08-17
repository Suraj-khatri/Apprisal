using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.RptDao
{
    public class LoanAndadvence:BaseDAO
    {
        private StringBuilder _selectQuery;
        public LoanAndadvence()
        {
            this._selectQuery = new StringBuilder("EXEC [ProcLoanAndAdvanceSummeryReport] ");

        }


        public String FindLoansummaryReport(String Flag, String loantype, String branch, String dept, String empID, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC [ProcLoanAndAdvanceSummeryReport] '" + Flag + "','" + loantype + "','" + branch + "','" + dept + "','" + empID + "','" + FromDate + "','" + ToDate + "'");
            return (_selectQuery.ToString());
        }
        public String FindLoandetailsReport(String Flag, String loantype, String branch, String dept, String empID, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC [ProcLoanAndAdvanceSummeryReport] '" + Flag + "','" + loantype + "','" + branch + "','" + dept + "','" + empID + "','" + FromDate + "','" + ToDate + "'");
            return (_selectQuery.ToString());
        }

        public String FindAdvancesummaryReport(String Flag, String advancetype, String branch, String dept, String empID, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC [ProcLoanAndAdvanceSummeryReport] '" + Flag + "','" + advancetype + "','" + branch + "','" + dept + "','" + empID + "','" + FromDate + "','" + ToDate + "'");
            return (_selectQuery.ToString());
        }

        public String FindAdvanceDetailsReport(String Flag, String advancetype, String branch, String dept, String empID, String FromDate, String ToDate)
        {
            _selectQuery = new StringBuilder("EXEC [ProcLoanAndAdvanceSummeryReport] '" + Flag + "','" + advancetype + "','" + branch + "','" + dept + "','" + empID + "','" + FromDate + "','" + ToDate + "'");
            return (_selectQuery.ToString());
        }

        public String FindContributionProjectionReport(String fiscalyear, String month, String branchid, String deptid, String empid)
        {
            _selectQuery = new StringBuilder("EXEC [procContributionProjectionReport] '" + fiscalyear + "','" + month + "','" + branchid + "','" + deptid + "','" + empid + "'");
            return (_selectQuery.ToString());
        }


        public String FindContributionSummeryReport(String flag, String fiscalyear, String month, String branchid, String deptId, String empId)
        {
            _selectQuery = new StringBuilder("EXEC [procContributionReport] '" + flag + "', '" + fiscalyear + "','" + month + "','" + branchid + "','" + deptId + "','" + empId + "'");
            return (_selectQuery.ToString());
        }
        public String FindContributionDetailsReport(String flag, String fiscalyear, String month, String branchid, String deptId, String empId)
        {
            _selectQuery = new StringBuilder("EXEC [procContributionReport] '" + flag + "', '" + fiscalyear + "','" + month + "','" + branchid + "','" + deptId + "','" + empId + "'");
            return (_selectQuery.ToString());
        }
        public DataSet FindContributionDetailsReport(String sSql)
        {
            return ReturnDataset(sSql);
        }


        public DataSet FindContributionSummeryReport(String sSql)
        {
            return ReturnDataset(sSql);
        }


        public DataSet FindContributionProjectionReport(String sSql)
        {
            return ReturnDataset(sSql);
        }


        public DataSet FindLoansummaryReport(String sSql)
        {
            return ReturnDataset(sSql);
        }
        public DataSet FindAdvancesummaryReport(String sSql)
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
