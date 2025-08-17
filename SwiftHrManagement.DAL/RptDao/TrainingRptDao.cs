using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.RptDao
{
    public class TrainingRptDao:BaseDAO
    {
        private StringBuilder _selectQuery; 
        public String FindTrainingRptByEmployeeOrDept(String EmpId, String DeptId)
        {
            String sSql = "exec  procTrainingTakenByEmployeeOrAllEmployeesInDepartment '" + DeptId + "','" + EmpId + "'";
            return sSql;
        }
        public DataSet FindTrainingRptByEmployeeOrDept(String sSql)
        {
            return ReturnDataset(sSql);
        }
        public String UpcomingorPlannedTraining(String branchId, String programId, String rptType)
        {
            String sSql = "exec procUpcomingAndRunningTrainingProgramBranchWise '" + branchId + "','" + programId + "', '" + rptType + "'";
            return sSql;
        }
        public DataSet UpcomingorPlannedTraining(String sSql)
        {
            return ReturnDataset(sSql);
        }

        public String FindTrainingSummaryReport(String FromDate, String To_Date)
        {
            _selectQuery = new StringBuilder("select tp.TRAINING_PROGRAM_TITLE as 'Training Program', tp.NUMBER_OF_DAYS as 'Total Days', "
            + " tp.VENUE + ', ' + tp.CITY + ', ' + tp.COUNTRY as venue from TrainingProgram as tp where "
            + "tp.ACTUAL_START_DATE between '" + FromDate + "' and '" + To_Date + "'");
            return _selectQuery.ToString();
        }


        public String FindAppraisalTrainingReport(String branchId, String deptId, String employeeId, String fromDate, String toDate)
        {
            _selectQuery = new StringBuilder("Exec [proc_AppraisalReport] @flag='t',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate));
            return _selectQuery.ToString();
        }

        public DataSet FindTrainingSummaryReport(String sSql)
        {
            return (ReturnDataset(sSql));
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
