using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.Probation
{
  public  class ProbationDao:DbService
    {

      public DbResult Update(string user, string proSalId, string empId, string currentEmpType, string newEmpType, string effectiveDate, string currentPosition, string newPosition, string currentBranch, string currentDept, string newBranch, string newDept, string promotionFlag, string transferFlag, string salarySetMasterId)
      {
          var sql = "EXEC proc_probationSalary";
          sql += " @flag = " + (proSalId == "0" || proSalId == "" ? "'i'" : "'u'");
          sql += ", @user = " + filterstring(user);
          sql += ", @proSalId = " + filterstring(proSalId);
          sql += ", @empId = " + filterstring(empId);
          sql += ", @currentEmpType = " + filterstring(currentEmpType);
          sql += ", @newEmpType = " + filterstring(newEmpType);
          sql += ", @effectiveDate = " + filterstring(effectiveDate);
          sql += ", @currentPosition = " + filterstring(currentPosition);
          sql += ", @newPosition = " + filterstring(newPosition);
          sql += ", @currentBranch = " + filterstring(currentBranch);
          sql += ", @currentDept = " + filterstring(currentDept);
          sql += ", @newBranch = " + filterstring(newBranch);
          sql += ", @newDept = " + filterstring(newDept);
          sql += ", @promotionFlag = " + filterstring(promotionFlag);
          sql += ", @transferFlag = " + filterstring(transferFlag);
          sql += ", @salarySetMasterId = " + filterstring(salarySetMasterId);
          //sql += ", @gradeId = " + filterstring(gradeId);
          return ParseDbResult(ExecuteDataset(sql).Tables[0]);
      }

        public DbResult Delete(string user, string proSalId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'd'";
            sql += ", @user = " + filterstring(user);
            sql += ", @proSalId = " + filterstring(proSalId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DataRow SelectById(string user, string proSalId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'a'";
            sql += ", @user = " + filterstring(user);
            sql += ", @proSalId = " + filterstring(proSalId);

            var ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        public DataTable SelectSalarySetByEmpId(string empId, string salSetMasterId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'p'";
            sql += ", @empId = " + filterstring(empId);
            sql += ", @salarySetMasterId = " + filterstring(salSetMasterId);
            //sql += ", @gradeType = " + filterstring(gradeType);

            var ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];

        }
        public DataRow SelectSalarySet(string empId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'ssm'";
            sql += ", @empId = " + filterstring(empId);

            var ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }
        public DbResult Approve(string user, string proSalId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'approve'";
            sql += ", @user = " + filterstring(user);
            sql += ", @proSalId = " + filterstring(proSalId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult Reject(string user, string proSalId)
        {
            var sql = "EXEC proc_probationSalary";
            sql += " @flag = 'reject'";
            sql += ", @user = " + filterstring(user);
            sql += ", @proSalId = " + filterstring(proSalId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }


    }
}
