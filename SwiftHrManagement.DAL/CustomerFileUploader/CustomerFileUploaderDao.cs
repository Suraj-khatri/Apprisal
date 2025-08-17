using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.CustomerFileUploader
{
    public class CustomerFileUploaderDao :BaseDAOInv
    {        
        public void SaveCustUploadedInformation(String sSql, SqlParameter[] param)
        {
            executeProcedure("proc_CustomerFileUpload", param);
        }

        public DataTable GetCustomerFileInfo(String custID)
        {
            String sSql = "select doc_id, Cust_id,Doc_Description,File_Extension from Cust_Doc_History where Cust_ID = " + custID + "";
            return ExecuteStoreProcedure(sSql);
        }
        public DataSet delete_cust_file(string sql)
        {
            return ReturnDataset(sql);
        }

        public DataTable GetTrainingFileInfo1(String externalTrainingID)
        {
            String sSql = "select ROWID,CUST_ID,[FILE_DESC],UPLOAD_BY,UPLOAD_DATE,FILE_TYPE from TrainingFileUpload "
            + " where CUST_ID = " + externalTrainingID;

            return ExecuteStoreProcedure(sSql);
        }
        //**///
        public DataTable GetTrainingFileInfo(String Quot_ID, string SessionID)
        {
            String sSql = "select ROWID,CUST_ID,[FILE_DESC],UPLOAD_BY,UPLOAD_DATE,FILE_TYPE from TrainingFileUpload "
            + " where CUST_ID = " + Quot_ID + " and session_id='" + SessionID + "'";

            return ExecuteStoreProcedure(sSql);
        }

        public DataSet delete_user_file(string sql)
        {
            return ReturnDataset(sql);
        }


        public override object MapObject(DataRow dr)
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
