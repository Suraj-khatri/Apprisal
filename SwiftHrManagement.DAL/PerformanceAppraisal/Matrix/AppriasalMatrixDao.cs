using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using System.Data;
namespace SwiftHrManagement.web.DAL.PerformanceAppraisal.Matrix
{
    public class AppriasalMatrixDao:BaseDAO
    {
        public DataTable OnSave(string templateId, string appraisalTopic, string appraisalSubTopic, string jobElement, string subTopicWeight, string jobElementWeight)
        {
            var sql = "Exec proc_PerformanceAppraisal";
            sql += " @flag = 'i'";
            sql += ", @templateId = " + filterstring(templateId);
            sql += ", @appraisalTopic=" + filterstring(appraisalTopic);
            sql += ", @appraisalSubTopic=" + filterstring(appraisalSubTopic);
            sql += ", @jobElement=" + filterstring(jobElement);
            sql += ", @appraisalSubTopicWeight=" + filterstring(subTopicWeight);
            sql += ", @jobElementWeight=" + filterstring(jobElementWeight);
            return ReturnDataset(sql).Tables[0];
         }
        public DataTable FindMatrixSetupById(string templateID)
        {
            var sql = "Exec proc_PerformanceAppraisal";
            sql += " @flag = 's'";
            sql += ", @templateId=" + filterstring(templateID);
            return ReturnDataset(sql).Tables[0];

        }

        public string OnDelete(string rowId)
        {
            var sql = "Exec proc_PerformanceAppraisal";
            sql += " @flag = 'd'";
            sql += ", @perAppMatSetUpId=" + filterstring(rowId);
            return GetSingleresult(sql);

        }
        public string FindTemplateNameById(long tempId)
        {

            var sql = "select templateName from templateRecord where templateId = " + tempId;
            return GetSingleresult(sql);
        }

        public DataTable FindAppraisalInfoById(string rowId)
        {

            var sql = "SELECT  appraisalSubTopic,appraisalSubTopicWeight,jobElement,jobElementWeight"
                        +" from performanceAppMatrixSetup  where perAppMatSetUpId = "+rowId;
            return ReturnDataset(sql).Tables[0];
        }
        public DataTable OnUpdate(string rowId,string subTopic,string jobElement,string subTopicWeight,string jobWeight)
        {
            var sql = "Exec [proc_PerformanceAppraisal]";
                sql += " @flag = 'u'";
                sql += ", @perAppMatSetUpId=" + filterstring(rowId);
                sql += ", @appraisalSubTopic=" + filterstring(subTopic);
                sql += ", @jobElement=" + filterstring(jobElement);
                sql += ", @appraisalSubTopicWeight=" + filterstring(subTopicWeight);
                sql += ", @jobElementWeight=" + filterstring(jobWeight);
                return ReturnDataset(sql).Tables[0];
        }

        public DataTable OnSaveOther(string section,string question,long templateId,string user,string answerType)
        {
            var sql = "Exec [proc_appraisalOtherSection]";
            sql += " @flag = 'i'";
            sql += ", @section = " + filterstring(section);
            sql += ", @question=" + filterstring(question);
            sql += ", @templateId=" + filterstring(templateId.ToString());
            sql += ", @user=" + filterstring(user);
            sql += ", @answerType=" + filterstring(answerType);
            return ReturnDataset(sql).Tables[0];
         }
        public DataTable FindOtherSectionById(long templateId)
        {
            var sql = "Exec [proc_appraisalOtherSection]";
            sql += " @flag = 's'";
            sql += ", @templateId = " + filterstring(templateId.ToString());
           return ReturnDataset(sql).Tables[0];
        }

        public DataTable OnDeleteOther(string OttherId)
        {
            var sql = "Exec [proc_appraisalOtherSection]";
            sql += " @flag = 'd'";
            sql += ", @appOtherSectionId = " + filterstring(OttherId.ToString());
            return ReturnDataset(sql).Tables[0];

        }

        public string GetTemplateNameById(long rowId)
        {
            var sql = "SELECT Top(1) tr.templateName from appraisalOtherSection ao"
             + "  inner join templateRecord tr on ao.templateId = tr.templateId where ao.templateId = " + filterstring(rowId.ToString());
            return GetSingleresult(sql);
             
        }

        public DataTable  GetAppraisalInfoById(long rowId)
        {
            //var sql = "SELECT dbo.GetBranchName(a.BRANCH_ID) branchId,dbo.GetDeptName(a.DEPARTMENT_ID) deptId"
            //+ " ,s.DETAIL_TITLE position,dbo.GetEmployeeFullNameOfId(a.EMPLOYEE_ID) empName,DATEDIFF(DAY,e.JOINED_DATE,a.CREATED_DATE) TotalDateInDays "
            //+ " ,CONVERT(varchar,FROM_DATE,107) FROM_DATE,CONVERT(varchar,TO_DATE,107) TO_DATE"
            //+ " ,CONVERT(varchar,previousAppraisalDate,107)   previousAppraisalDate,TITLE"
            //+ " from Appraisal a "
            //+ " inner join StaticDataDetail s on s.ROWID = a.POSITION_ID"
            //+ " inner join Employee e on e.EMPLOYEE_ID = a.EMPLOYEE_ID  where a.ID =" + rowId;

            var sql = "SELECT dbo.GetBranchName(a.BRANCH_ID) branchId,dbo.GetDeptName(a.DEPARTMENT_ID) deptId"
            + " ,s.DETAIL_TITLE position,dbo.GetEmployeeFullNameOfId(a.EMPLOYEE_ID) empName,DATEDIFF(DAY,e.JOINED_DATE,a.CREATED_DATE) TotalDateInDays "
            + " ,CONVERT(varchar,FROM_DATE,107) FROM_DATE,CONVERT(varchar,TO_DATE,107) TO_DATE"
            + " ,CONVERT(varchar,previousAppraisalDate,107)   previousAppraisalDate,TITLE"
            +",supervisor=  dbo.GetEmployeeFullNameOfId(sup.SUPERVISOR),reviewer = dbo.GetEmployeeFullNameOfId(rev.SUPERVISOR)"
            + " from Appraisal a "
            + " inner join StaticDataDetail s on s.ROWID = a.POSITION_ID"
            +" INNER JOIN appraisalSupervisorAssignment sup on a.ID = sup.appraisal_id  and sup.SUPERVISOR_TYPE='s'"
            +" INNER JOIN appraisalSupervisorAssignment rev on a.ID = rev.appraisal_id  and rev.SUPERVISOR_TYPE='r'"
            + " inner join Employee e on e.EMPLOYEE_ID = a.EMPLOYEE_ID  where a.ID =" + rowId;

            return ReturnDataset(sql).Tables[0];
        }

   


        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
