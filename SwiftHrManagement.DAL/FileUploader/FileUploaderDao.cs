using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.FileUploader
{
    public class FileUploaderDao : BaseDAO
    {
        public void SaveUploadedInformation(String sSql, SqlParameter[] param)
        {
            executeProcedure("proc_EmployeeFileUpload", param);
        }
        public void SaveUploadedAttendanceFile(String sSql, SqlParameter[] param)
        {
            executeProcedure("proc_EmployeeAttendanceUpload", param);
        }
        public void SaveUploadedFile(String sSql, SqlParameter[] param)
        {
            executeProcedure("procCMSuploadFile", param);
        }
        public void SaveJobUploadedFile(String sSql,SqlParameter[] param)
        {
            executeProcedure("proc_JobFileUpload", param);
        }
       
        public void SaveUploadAdhocPayment(String sSql, SqlParameter[] param)
        {
            executeProcedure("ProcUploadAdhocPaymentFile", param);
        }
        public DataTable GetfileInformation(String Empid,string docType)
        {
            String sSql = "EXEC [proc_EmployeeFileUpload] @flag='s',@EMP_ID=" + filterstring(Empid) + ",@DOCTYPE="+filterstring(docType)+"";
            return ExecuteStoreProcedure(sSql);
        }
        public DataTable GetCmsFiles(String pageId)
        {
            String sSql = "SELECT rowid,funct_id,doc_desc,doc_ext FROM CMS_document where funct_id=" + pageId + "";
            return ExecuteStoreProcedure(sSql);
        }
        public DataSet delete_user_file(string sql)
        {
            return ReturnDataset(sql);
        }
        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

    }
}
