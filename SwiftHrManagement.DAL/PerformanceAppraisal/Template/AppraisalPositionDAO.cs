using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.PerformanceAppraisal.Template
{
    public  class AppraisalPositionDAO : DbService
    {
        public string insertData(string position, string sessionId)
        {
            string sql = "Exec [proc_appraisalPosition] @flag='i',@position=" + filterstring(position) + ",@sessionId=" +filterstring(sessionId);
            return GetSingleresult(sql);
        }

        public string getTemplateName(string templateId)
        {
            string sql = "select templateName from templateRecord where templateId=" + filterstring(templateId);
            return GetSingleresult(sql);
        }

        public DataTable getAddedData(string sessionId, string templateId)
        {
            string sql = "Exec [proc_appraisalPosition] @flag='s',@sessionId=" + filterstring(sessionId) + ",@templateId=" + filterstring(templateId);
            return ReturnDataset(sql).Tables[0];
        }

        public String deleteRecord(string positionId)
        {
            string sql = "Exec [proc_appraisalPosition] @flag='d',@positionId=" + filterstring(positionId);
            return GetSingleresult(sql);
        }

        public string saveRecord(string templateId, string sessionId)
        {
            string sql = "Exec [proc_appraisalPosition] @flag='fs',@sessionId=" + filterstring(sessionId) + ",@templateId=" + filterstring(templateId);
            return GetSingleresult(sql);
        }
    }
}