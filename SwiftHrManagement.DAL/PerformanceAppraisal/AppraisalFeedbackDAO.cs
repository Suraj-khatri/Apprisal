using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.PerformanceAppraisal
{
    public class AppraisalFeedbackDAO : BaseDAO
    {
        public AppraisalFeedbackDAO()
        {

        }
        public override void Save(object obj)
        {
            AppraisalFeedbackCore _appraisalFeedbackCore = (AppraisalFeedbackCore)obj;

            String sSql = ("exec ProcInsertAppraisalFeedback  " +filterstring(_appraisalFeedbackCore.AppraisalId.ToString()) + "," +filterstring(_appraisalFeedbackCore.FeedbackDetails) + "," +filterstring(_appraisalFeedbackCore.CreatedBy) + "," +filterstring(_appraisalFeedbackCore.CreatedDate.ToString())+ "".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public List<AppraisalFeedbackDetailsCore> FindAllByAppraisalID(string id)
        {
            DataTable dt = SelectByQuery("SELECT F.ID, A.ID AS APPRAISALID,A.TITLE,ISNULL(F.FEEDBACK_DETAILS,'') AS FEEDBACK_DETAILS,ISNULL(CONVERT(VARCHAR,F.CREATEDDATE,107),'') AS CREATEDDATE ,ISNULL(F.CREATEDBY,'') AS CREATEDBY, "
            + " E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPLOYEENAME FROM APPRAISALFEEDBACK F   LEFT JOIN APPRAISAL A ON F.APPRAISAL_ID = A.ID "
            + " INNER JOIN EMPLOYEE E ON E.EMPLOYEE_ID = A.EMPLOYEE_ID WHERE F.APPRAISAL_ID = '" + id + "'");
            List<AppraisalFeedbackDetailsCore> _appraisalFeedCore = new List<AppraisalFeedbackDetailsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AppraisalFeedbackDetailsCore _appdtllCore = (AppraisalFeedbackDetailsCore)this.MapObject(dr);
                    _appraisalFeedCore.Add(_appdtllCore);
                }
            }
            return _appraisalFeedCore;
        }

        public AppraisalFeedbackDetailsCore FindbyId(long Id)
        {
            DataTable dt = SelectByQuery("SELECT AF.Id,A.TITLE,AF.Appraisal_Id,AF.Feedback_Details,"
            +" E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPLOYEENAME  FROM AppraisalFeedback AF INNER JOIN Appraisal A"
            +" ON A.ID=AF.Appraisal_Id INNER JOIN Employee E ON E.EMPLOYEE_ID=A.EMPLOYEE_ID WHERE AF.ID="+Id+"");
            AppraisalFeedbackDetailsCore _appdtllCore = new AppraisalFeedbackDetailsCore();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _appdtllCore = (AppraisalFeedbackDetailsCore)this.MapObjectForView(dr);
                }
            }
            return _appdtllCore;
        }
        public object MapObjectForView(System.Data.DataRow dr)
        {

            AppraisalFeedbackDetailsCore _appraisalDtlCore = new AppraisalFeedbackDetailsCore();
            _appraisalDtlCore.Id = int.Parse(dr["ID"].ToString());
            _appraisalDtlCore.AppraisalTitle = dr["TITLE"].ToString();
            _appraisalDtlCore.AppraisalId = int.Parse(dr["Appraisal_Id"].ToString());
            _appraisalDtlCore.FeedbackDetails = dr["FEEDBACK_DETAILS"].ToString();
            _appraisalDtlCore.EmployeeName = dr["EMPLOYEENAME"].ToString();
            return _appraisalDtlCore;
        }
        public AppraisalFeedbackDetailsCore FindTitleEmpNameById(long id)
        {
            DataTable dt = SelectByQuery("SELECT A.TITLE, Isnull(E.EMP_CODE+' '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME,'') AS EMPLOYEENAME "
            + " FROM APPRAISAL A   LEFT JOIN EMPLOYEE E ON E.EMPLOYEE_ID = A.EMPLOYEE_ID WHERE A.ID = " + id + "");

            AppraisalFeedbackDetailsCore _apprCore = new AppraisalFeedbackDetailsCore();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _apprCore = (AppraisalFeedbackDetailsCore)this.MapEmpTitle(dr);
                }
            }
            return _apprCore;

        }

        public object MapEmpTitle(System.Data.DataRow dr)
        {

            AppraisalFeedbackDetailsCore _appraisalDtlCore = new AppraisalFeedbackDetailsCore();

            _appraisalDtlCore.AppraisalTitle = dr["TITLE"].ToString();
            _appraisalDtlCore.EmployeeName = dr["EMPLOYEENAME"].ToString();
            return _appraisalDtlCore;
        }


        public override void Update(object obj)
        {
            AppraisalFeedbackCore _appraisalFeedbackCore = (AppraisalFeedbackCore)obj;

            String sSql = ("exec ProcUpdateAppraisalFeedback  " + filterstring(_appraisalFeedbackCore.Id.ToString()) + "," +filterstring(_appraisalFeedbackCore.FeedbackDetails) + "," + filterstring(_appraisalFeedbackCore.CreatedBy) + "," +filterstring(_appraisalFeedbackCore.CreatedDate.ToString()) + "".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public override object MapObject(System.Data.DataRow dr)
        {

            AppraisalFeedbackDetailsCore _appraisalDtlCore = new AppraisalFeedbackDetailsCore();
            _appraisalDtlCore.Id = int.Parse(dr["ID"].ToString());
            _appraisalDtlCore.AppraisalTitle = dr["TITLE"].ToString();
            _appraisalDtlCore.AppraisalId = int.Parse(dr["Appraisal_Id"].ToString());
            _appraisalDtlCore.FeedbackDetails = dr["FEEDBACK_DETAILS"].ToString();
            _appraisalDtlCore.EmployeeName = dr["EMPLOYEENAME"].ToString();
            _appraisalDtlCore.CreatedBy = dr["CREATEDBY"].ToString();
            _appraisalDtlCore.FeedbackDate = (dr["CREATEDDATE"].ToString());
            return _appraisalDtlCore;
        }
        public DataSet FindAppraisalFeedbackById(string appraisalId, string positionid)
        {
            String sSql = ("exec proc_ListPerformance_Appraisal '" + appraisalId + "', '" + positionid + "'");
            return ReturnDataset(sSql);
        }
        //public void SaveAppraisalFeedback(String appraisalId, String Appraisal_Feedback, String CreatedBy, String CreatedDate)
        //{
        //    String sSql = ("exec sp_InsertAppraisalFeedback  '" + appraisalId + "','" + Appraisal_Feedback + "','" + CreatedBy + "','" + CreatedDate + "'".ToString());
        //    ExecuteUpdateProcedure(sSql);
        //}
        public void DeleteAppraisalFeedback(String Id)
        {
            ExecuteQuery("delete  from APPRAISALFEEDBACK where Id ='" + Id + "'");
        }
    }
}
