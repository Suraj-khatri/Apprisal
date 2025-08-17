using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.DAL.PerformanceAppraisal
{
    public class AppraisalReportDao : DbService
    {
        public DataTable GetBranchReport(string branchId,string deptId,string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='s',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetTrainingReport(string branchId, string deptId, string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='t',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetBranchReportAll(string branchId, string deptId, string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='r',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetBranchReportFinal(string branchId, string deptId, string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='f',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }


        public DataTable GetAppraisalSummaryReport(string branchId, string deptId, string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='Final',@branchId=" + filterstring(branchId) + ",@departmentId=" + filterstring(deptId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }

        
        public DataTable GetEmployeeReport(string branchId, string employeeId, string fromDate, string toDate)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='e',@branchId=" + filterstring(branchId) + ",@employeeId=" + filterstring(employeeId) + ",@fromDate=" + filterstring(fromDate) + ",@toDate=" + filterstring(toDate);
            return ReturnDataset(sql).Tables[0];
        }

        public DataSet GetdetailReport(string appraisalId,string employeeId,string superType)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='al',@appraisalId=" + filterstring(appraisalId) + ",@empId=" + filterstring(employeeId) + ",@superType=" + filterstring(superType);
            return ReturnDataset(sql);
        }

        public DataTable CommentByList(string appraisalId)
        {
            var sql = "select distinct(commentBy),dbo.GetEmployeeFullNameOfId(commentBy)[EmpName],convert(varchar,commentDate,101)[commentDate]" +
                        ",raterTypeFlag from appraisalComments a where appraisalId =" + filterstring(appraisalId);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetHrCommittee(string EmployeeId)
        {
            var sql = "select dbo.GetEmployeeFullNameOfId(SUPERVISOR)[HR  Member] from appraisalSupervisorAssignment where SUPERVISOR_TYPE='h'";
            return ReturnDataset(sql).Tables[0];
        }


        public DataRow GetSection1(string appraisalId)
        {
            var sql = "Exec [proc_PerformanceAppraisalMatrix] @flag='sat'";            
            sql += ",@apprisalId=" + filterstring(appraisalId);
           // sql += ",@commentBy=" + this.service.filterstring(user);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataTable GetSection2(string appraisalId, string employeeId)
        {
            var sql = "Exec [proc_AppraisalReport] @flag='matrix'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            sql += ",@empId=" + filterstring(employeeId);           
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataTable GetSection3(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s3'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataTable GetSection4(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s4'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataRow GetSection5(string appraisalId)
        {
            var sql = @"select soleComment,comments from appraisalComments where appraisalId = " + appraisalId + " and questionId is null and  raterTypeFlag = 'r'";
             var ds = ReturnDataset(sql);
             if (ds == null)
                 return null;
            var dt = ds.Tables[0];
            if(dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataTable GetSection6(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s6'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataRow GetSection7(string appraisalId, string commentBy)
        {
            var sql = "SELECT soleComment,comments FROM appraisalComments where commentBy=" + commentBy + " "
               + " and isnull(questionId,'') = '0' and flag='f' and appraisalId = " + appraisalId + " and raterTypeFlag='a'";
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataTable GetSection8(string appraisalId)
        {
            var sql = "Exec [proc_AppraiserRating] @flag='s8'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataTable GetReviewCommittee(string appraisalId,string employeeId)
        {
            var sql = "Exec [proc_getAppraisalReviewCommittee]";
            sql += "@user="+filterstring(employeeId)+",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public DataRow GetHRAction(string appraisalId)
        {
            var sql = "select letterissuedOn = CONVERT(VARCHAR,letterissuedOn,101),incrementEffectedOn = CONVERT(VARCHAR,incrementEffectedOn,101) from appraisalComments where appraisalId = " + appraisalId + " and questionId is null and  raterTypeFlag = 'h'";
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataRow GetEverageRating(string appraisalId)
        {
            var sql = "Exec [proc_AppraisalReport] @flag ='ar'";
            sql += ",@appraisalId=" + filterstring(appraisalId);
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataRow GetReviewCommitteeRating(string appraisalId)
        {
            var sql = @"select soleComment,comments from appraisalComments where appraisalId = " + appraisalId
                    + " and questionId is null and  raterTypeFlag = 'rc' and soleComment in ('Substandard','Acceptable','Good','Very Good','Excellent')";
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }
    }
}