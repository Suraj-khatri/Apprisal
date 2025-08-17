using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.PerformanceAppraisal
{
    public class PerformanceAppraisalDAO : BaseDAO
    {
        private StringBuilder _insertQuery;
        public PerformanceAppraisalDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO AppraisalDetails(APPRAISAL_ID,APPRAISAL_MATRIC_ID,REMARKS,WEIGHT)VALUES "
            + "({APPRAISAL_ID},{APPRAISAL_MATRIC_ID},'{REMARKS}','{WEIGHT}')");
        }
        public override void Save(object obj)
        {
            PerformanceAppraisalCore _performAppraisalCore = (PerformanceAppraisalCore)obj;
            this._insertQuery.Replace("{APPRAISAL_MATRIC_ID}", _performAppraisalCore.Appraisal_Matric_Id.ToString());
            this._insertQuery.Replace("{APPRAISAL_ID}", _performAppraisalCore.Apraisal_id.ToString());
            this._insertQuery.Replace("{REMARKS}", _performAppraisalCore.Remarks.ToString());
            this._insertQuery.Replace("{WEIGHT}", _performAppraisalCore.Weight.ToString());
            ExecuteQuery(_insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }
        public DataSet FindAppraisalListById(string appraisalId, string positionid)
        {
            String sSql = ("exec proc_ListPerformance_Appraisal 'a','" + appraisalId + "','" + positionid + "'");
            return ReturnDataset(sSql);
        }
        //public DataSet FindMetrics(string positionid)
        //{
        //    String sSql = ("exec proc_ListPerformance_Appraisal 'v','','" + positionid + "'");
        //    return ReturnDataset(sSql);
        //}
        public void SaveAppraisalDetail(String appraisalId, String APPRAISAL_MATRIC_ID, String REMARKS, String WEIGHT)
        {
            String sSql = ("exec procperformanceAppraisal  '"+ appraisalId +"','"+ APPRAISAL_MATRIC_ID +"','"+ REMARKS +"','"+ WEIGHT +"'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public void DeleteAppraisalDetail(String appraisalId)
        {
            ExecuteQuery("delete  from AppraisalDetails where Appraisal_id ='" + appraisalId + "'");

        }
        public DataRow getYearStartEndDate()
        {
            var sql = "select top 1 en_year_start_date = CONVERT(VARCHAR,en_year_start_date,101),en_year_end_date = CONVERT(VARCHAR,en_year_end_date,101) from FiscalYear where flag<>'1' order by en_year_end_date desc";
            var ds = ReturnDataset(sql);
            if (ds == null)
                return null;
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public DataTable AddCommitteeMamber(string reviewType, string memPosition, string memName, string frmDate, string toDate,string user,string isRater)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='addMember'";
            sql += ",@reviewType=" + filterstring(reviewType);
            sql += ",@memPosition=" + filterstring(memPosition);
            sql += ",@memName=" + filterstring(memName);
            sql += ",@frmDate=" + filterstring(frmDate);
            sql += ",@toDate=" + filterstring(toDate);
            sql += ",@user=" +filterstring(user);
            sql += ",@isFirstRater=" + filterstring(isRater);
                        
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable GetEditData(string id)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='getMemberDetails'";
            sql += ",@rowId=" + filterstring(id);
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable UpdateCommitteeMamber(string rowId, string memPosition, string memName, string frmDate, string toDate, string user, string isRater)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='updateMember'";
            sql += ",@rowId=" + filterstring(rowId);
            sql += ",@memPosition=" + filterstring(memPosition);
            sql += ",@memName=" + filterstring(memName);
            sql += ",@frmDate=" + filterstring(frmDate);
            sql += ",@toDate=" + filterstring(toDate);
            sql += ",@user=" + filterstring(user);
            sql += ",@isFirstRater=" + filterstring(isRater);

            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable saveReviewType(string rewType, string revdesc, string maxPos, string minPos, string user,string active)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='addType'";
            sql += ",@reviewType=" + filterstring(rewType);
            sql += ",@typeDescription=" + filterstring(revdesc);
            sql += ",@maxPosition =" + filterstring(maxPos);
            sql += ",@minPosition =" + filterstring(minPos);
            sql += ",@isActive =" + filterstring(active);
            sql += ",@user=" + filterstring(user);           

            return ExecuteDataset(sql).Tables[0];
        }


        public DataTable updateReviewType(string rewType, string revdesc, string rowId, string user, string active)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='updateType'";
            sql += ",@reviewType=" + filterstring(rewType);
            sql += ",@typeDescription=" + filterstring(revdesc);
            sql += ",@rowId =" + filterstring(rowId);            
            sql += ",@isActive =" + filterstring(active);
            sql += ",@user=" + filterstring(user);

            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable deleteCommittee(string id,string user)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='deleteType'";
            sql += ",@rowId=" + filterstring(id);        
            sql += ",@user=" + filterstring(user);

            return ExecuteDataset(sql).Tables[0];
        }


        public DataTable deletePos(string id)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='deleteTypePos'";
            sql += ",@rowId=" + filterstring(id);            
            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable saveReviewPos(string rev, string pos, string user)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='addTypePos'";
            sql += ",@reviewType=" + filterstring(rev);
            sql += ",@maxPosition=" + filterstring(pos);           
            sql += ",@user=" + filterstring(user);

            return ExecuteDataset(sql).Tables[0];
        }

        public DataTable GetMemberType(string id)
        {
            var sql = "EXEC proc_AppriasalReviewDetails @flag='getTypeDetails'";
            sql += ",@rowId=" + filterstring(id);
            return ExecuteDataset(sql).Tables[0];
        }
    }
} 
		
     
    