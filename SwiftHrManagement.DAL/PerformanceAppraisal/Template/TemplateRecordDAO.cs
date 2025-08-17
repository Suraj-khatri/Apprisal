using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.PerformanceAppraisal.Template
{
    public class TemplateRecordDAO : DbService
    {
        public string insertAddData(string markingBy, string markingType, string percentage, string sessionId)
        {
            string sql = "Exec [proc_templateRecord] @flag='a',@markingBy=" + filterstring(markingBy)
                    + ",@markingType=" + filterstring(markingType) + ",@percentage=" + filterstring(percentage) + ",@sessionId=" + filterstring(sessionId) +"";
            return GetSingleresult(sql);

        }

        public DataTable getAddedData(string sessionId, string templateId)
        {
            string sql = "Exec [proc_templateRecord] @flag='s',@sessionId=" + filterstring(sessionId) + ",@templateId=" + filterstring(templateId);
            return ReturnDataset(sql).Tables[0];
        }

        public String deleteRecord(string rowid)
        {
            string sql = "Exec [proc_templateRecord] @flag='d',@rowId=" + filterstring(rowid);
            return GetSingleresult(sql);
        }

        public string saveRecord(string tName, string tDescript,string createdBy,string sessionId)
        {
            string sql = "Exec [proc_templateRecord] @flag='fs',@templateName=" + filterstring(tName) + ",@tDescription=" + filterstring(tDescript) 
                        + ",@createdBy=" + filterstring(createdBy) + ",@sessionId=" + filterstring(sessionId);
            return GetSingleresult(sql);
        }

        public string updateRecord(string tName, string tDescript, string modifiedBy, string sessionId, string templateId)
        {
            string sql = "Exec [proc_templateRecord] @flag='u',@templateName=" + filterstring(tName) + ",@tDescription=" + filterstring(tDescript)
                        + ",@modifiedBy=" + filterstring(modifiedBy) + ",@sessionId=" + filterstring(sessionId) + ",@templateId=" + filterstring(templateId);
            return GetSingleresult(sql);
        }

        public string AddNewData(string markingBy, string markingType, string percentage, string tName, string tDesc, string templateId, string modifyBy)
        {
            string sql = "Exec [proc_templateRecord] @flag='ds',@markingBy=" + filterstring(markingBy) + ",@markingType=" + filterstring(markingType) + ",@percentage=" + filterstring(percentage) 
                        + ",@templateName=" + filterstring(tName) + ",@tDescription=" + filterstring(tDesc) + ",@templateId=" + filterstring(templateId) + ",@modifiedBy=" + filterstring(modifyBy);
            return GetSingleresult(sql);
        }
    }
}
