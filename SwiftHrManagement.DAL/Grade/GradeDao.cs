using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.Grade
{
    public class GradeDao:DbService
    {
        DbService service = new DbService();
        public DbResult Update(string user,string empId, string gradeId, string effectiveDate, string gradeFlag, string grade, string amount)
        {
            var sql = "EXEC proc_Grade";
            sql += " @flag = " + (gradeId == "0" || gradeId == "" ? "'i'" : "'u'");
            sql += ", @user = " + filterstring(user);
            sql += ", @gradeId = " + filterstring(gradeId);

            sql += ", @empId = " + filterstring(empId);
            sql += ", @effectiveDate = " + filterstring(effectiveDate);
            sql += ", @gradeFlag = " + filterstring(gradeFlag);
            sql += ", @grade = " + filterstring(grade);
            sql += ", @amount = " + filterstring(amount);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult Delete(string user, string gradeId)
        {
            var sql = "EXEC proc_Grade";
            sql += " @flag = 'd'";
            sql += ", @user = " + filterstring(user);
            sql += ", @gradeId = " + filterstring(gradeId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DataRow SelectById(string gradeId)//To Do
        {
            var sql = "EXEC proc_Grade";
            sql += " @flag = 'a'";
            sql += ", @gradeId = " + filterstring(gradeId);

            var ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];

        }

        public DbResult Delete(string gradeId)
        {
            var sql = "EXEC proc_Grade";
            sql += " @flag = 'd'";
            sql += ", @gradeId = " + filterstring(gradeId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DataRow LoadAmount(string empId, string gradeType)
        {
            var sql = "EXEC proc_Grade";
            sql += " @flag = 'la'";
            sql += ", @gradeId = " + filterstring(gradeType);
            sql += ", @empId = " + filterstring(empId);

            var ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }
    }
}
