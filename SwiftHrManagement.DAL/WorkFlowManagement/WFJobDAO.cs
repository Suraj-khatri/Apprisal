using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.DAL.WorkFlowManagement
{
    public class WFJobDAO : BaseDAO
    {

        public override object MapObject(DataRow dr)
        {
            WFJobCore _jCore = new WFJobCore();
            _jCore.JobID = long.Parse((dr["WF_JOBID"].ToString()));
            _jCore.JobCatID = long.Parse(dr["WF_CATID"].ToString());
            _jCore.JobDescription = dr["WF_JOB_DESCRIPTION"].ToString();
            _jCore.CreatedBy = dr["CREATEDBY"].ToString();
            _jCore.CreatedDate = DateTime.Parse(dr["CREATEDDATE"].ToString());
            _jCore.JobCode = dr["JOB_CODE"].ToString();
            _jCore.CustCode = dr["CUSTOMERCODE"].ToString();
            return _jCore;

        }

        public override void Save(object obj)
        {
            WFJobCore _wfJobCore = (WFJobCore)obj;
            String sSql = ("exec PROCINSERTUPDATEWFJOB '" + _wfJobCore.JobID + "','" + _wfJobCore.JobCatID + "','" + _wfJobCore.JobDescription + "','" + _wfJobCore.CreatedEmpID + "','" + _wfJobCore.JobCreator + "','" + _wfJobCore.CreatedDate + "','" + _wfJobCore.ClosedDate + "','" + _wfJobCore.JobCode + "','" + _wfJobCore.CustCode + "','" + "I" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }


        public void Delete(Object obj)
        {
            WFJobCore _wfJobCore = (WFJobCore)obj;
            String sSql = ("exec PROCINSERTUPDATEWFJOB '" + _wfJobCore.JobID + "','" + _wfJobCore.JobCatID + "','" + _wfJobCore.JobDescription + "','" + _wfJobCore.CreatedEmpID + "','" + _wfJobCore.JobCreator + "','" + _wfJobCore.CreatedDate + "','" + _wfJobCore.ClosedDate + "','" + _wfJobCore.JobCode + "','" + _wfJobCore.CustCode + "','" + "D" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public void SaveJobProcessing(object obj)
        {
            WFJobProcessingCore _wfJobProcCore = (WFJobProcessingCore)obj;
            String sSql = ("exec PROCINSERTUPDATEJOBPROCESSING  '" + _wfJobProcCore.Id + "','" + _wfJobProcCore.JobId + "','" + _wfJobProcCore.ActionEmpId + "','" + _wfJobProcCore.ForwartTo + "','" + _wfJobProcCore.CreatedDate + "','" + _wfJobProcCore.Comments + "','" + _wfJobProcCore.JobStatus + "','" + _wfJobProcCore.JobMode + "','" + "I" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public void AcceptJobProcessing(object obj)
        {
            WFJobProcessingCore _wfJobProcCore = (WFJobProcessingCore)obj;
            String sSql = ("exec PROCINSERTUPDATEJOBPROCESSING  '" + _wfJobProcCore.Id + "','" + _wfJobProcCore.JobId + "','" + _wfJobProcCore.ActionEmpId + "','" + _wfJobProcCore.ForwartTo + "','" + _wfJobProcCore.CreatedDate + "','" + _wfJobProcCore.Comments + "','" + _wfJobProcCore.JobStatus + "','" + _wfJobProcCore.JobMode + "','" + "A" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public void UpdateJobProcessing(object obj)
        {
            WFJobProcessingCore _wfJobProcCore = (WFJobProcessingCore)obj;
            String sSql = ("exec PROCINSERTUPDATEJOBPROCESSING  '" + _wfJobProcCore.Id + "','" + _wfJobProcCore.JobId + "','" + _wfJobProcCore.ActionEmpId + "','" + _wfJobProcCore.ForwartTo + "','" + _wfJobProcCore.CreatedDate + "','" + _wfJobProcCore.Comments + "','" + _wfJobProcCore.JobStatus + "','" + _wfJobProcCore.JobMode + "','" + "U" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public void DeleteJobProcessing(object obj)
        {
            WFJobProcessingCore _wfJobProcCore = (WFJobProcessingCore)obj;
            String sSql = ("exec PROCINSERTUPDATEJOBPROCESSING  '" + _wfJobProcCore.Id + "','" + _wfJobProcCore.JobId + "','" + _wfJobProcCore.ActionEmpId + "','" + _wfJobProcCore.ForwartTo + "','" + _wfJobProcCore.CreatedDate + "','" + _wfJobProcCore.Comments + "','" + _wfJobProcCore.JobStatus + "','" + _wfJobProcCore.JobMode + "','" + "D" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public WFJobProcessingCore GetJobProcDetailsByEmpID(long empID)
        {
            string sSql = " SELECT D.ID,D.WF_JOBID,J.WF_CatID,J.JOB_CODE,J.WF_JOB_DESCRIPTION,E.FIRST_NAME,CONVERT(VARCHAR,J.CREATEDDATE,107) AS CREATEDDATE,D.JOB_STATUS FROM WF_DETAILS D"
                         + " INNER JOIN  WF_JOB J ON D.WF_JOBID = J.WF_JOBID INNER JOIN EMPLOYEE E ON E.EMPLOYEE_ID = D.ACTION_BY_EMPID"
                         + " WHERE ACTION_BY_EMPID = " + empID + "";

            DataTable dt = SelectByQuery(sSql);

            WFJobProcessingCore _jPCore = null;

            if (dt != null)
            {
                _jPCore = (WFJobProcessingCore)this.MapToJobProcessingCore(dt.Rows[0]);
            }
            return _jPCore;
        }

        public object MapToJobProcessingCore(System.Data.DataRow dr)
        {
            WFJobProcessingCore _jPCore = new WFJobProcessingCore();
            _jPCore.Id = long.Parse(dr["ID"].ToString());
            _jPCore.JobId = long.Parse(dr["WF_JOBID"].ToString());
            _jPCore.ActDate = dr["CREATEDDATE"].ToString();
            //_jPCore.ForwartTo = long.Parse(dr["

            return _jPCore;
        }

        public WFJobProcessingCore GetJobRecievingByEmpIDandJobID(string username, long empID, long jobID)
        {
            //String sSql = ("exec GETJOBPOCESSINGDETAILS '" + username + "','" + jobID + "','" + empID + "'".ToString());
            String sSql = ("exec procGETJOBPOCESSINGDETAILS '" + jobID + "'".ToString());
            DataTable dt = ReturnDataset(sSql).Tables[0];

            WFJobProcessingCore _wJCore = null;
            try
            {
                if (dt != null)
                    _wJCore = (WFJobProcessingCore)this.MapToGetProc(dt.Rows[0]);

                return _wJCore;
            }
            catch
            {
                return null;
            }

        }

        public object MapToGetProc(System.Data.DataRow dr)
        {
            WFJobProcessingCore jpCore = new WFJobProcessingCore();
            jpCore.JobId = long.Parse(dr["WF_JOBID"].ToString());
            jpCore.Comments = dr["COMMENTS"].ToString();

            if (String.IsNullOrEmpty(jpCore.Comments))
            {
                jpCore.Comments = dr["ACCEPTEDCOMMENTS"].ToString();
            }

            jpCore.SenderName = dr["FIRST_NAME"].ToString();
            jpCore.ActDate = dr["ACTION_DATE"].ToString();
            jpCore.JobMode = dr["MODE"].ToString();
            jpCore.JobStatus = dr["JOB_STATUS"].ToString();
            jpCore.strFlag = dr["FLAG"].ToString();
            jpCore.ForwartTo = long.Parse(dr["FORWARD_TO"].ToString());
            jpCore.ActionEmpId = long.Parse(dr["ACTION_BY_EMPID"].ToString());

            return jpCore;
        }

        public void SaveUploadedFiles(object obj)
        {
            WFUploadJobFilesCore _jobFileCore = (WFUploadJobFilesCore)obj;
            String sSql = ("exec PROCUPLOADJOBFILEHISORY '" + _jobFileCore.DocId + "','" + _jobFileCore.JobId + "','" + _jobFileCore.DocName + "',"
                           + "'" + _jobFileCore.DocDesciption + "','" + _jobFileCore.FileExtn + "','" + _jobFileCore.CreatedBy + "','" + _jobFileCore.CreatedDate + "','" + "I" + "'".ToString());

            ExecuteUpdateProcedure(sSql);

        }

        public DataTable GetUploadedFileInfo(String JobID)
        {
            String sSql = ("exec PROCGETJOBFILEINFO '" + JobID + "'".ToString());
            return ExecuteStoreProcedure(sSql);
        }

        public DataSet delete_job_file(string sql)
        {
            return ReturnDataset(sql);
        }

        public WFJobCore FindJobDetails(long id)
        {
            try
            {
                string sSql = "SELECT Isnull(Job_Code,'') as Job_Code,isnull(C.WF_CatName,'') as WF_CatName,WF_DeptName FROM WF_Job J INNER JOIN WF_Category C ON C.WF_CategoryID=J.WF_CatID"
                                + " WHERE WF_JOBID = " + id + "";
                DataTable dt = SelectByQuery(sSql);
                WFJobCore _jCore = null;
                if (dt != null)
                    _jCore = (WFJobCore)this.MapObjectJobDetails(dt.Rows[0]);
                return _jCore;
            }
            catch
            {
                return null;
            }
        }
        public object MapObjectJobDetails(System.Data.DataRow dr)
        {
            WFJobCore jpCore = new WFJobCore();
            jpCore.JobCode = dr["Job_Code"].ToString();
            jpCore.JobCategory = dr["WF_CatName"].ToString();
            jpCore.DeptName = dr["WF_DeptName"].ToString();
            return jpCore;
        }
        ////
        //public WFJobCore FindMemberCategoryDetails(long id)
        //{
        //    try
        //    {
        //        string sSql = "SELECT Isnull(Job_Code,'') as Job_Code,isnull(C.WF_CatName,'') as WF_CatName FROM WF_Job J INNER JOIN WF_Category C ON C.WF_CategoryID=J.WF_CatID"
        //                        + " WHERE WF_JOBID = " + id + "";
        //        DataTable dt = SelectByQuery(sSql);
        //        WFJobCore _jCore = null;
        //        if (dt != null)
        //            _jCore = (WFJobCore)this.MapObjectJobDetails(dt.Rows[0]);
        //        return _jCore;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        ////

        public WFJobCore getJobDetailsByJobID(long id)
        {
            string sSql = "SELECT W.WF_JOBID,W.WF_CATID,W.WF_JOB_DESCRIPTION,W.CREATEDBY,W.CREATEDDATE,W.CLOSEDDATE,W.JOB_CODE,"
            +" C.CUSTOMERCODE+'-'+C.CUSTOMERNAME+'|'+cast(C.ID as varchar) as CUSTOMERCODE FROM WF_JOB W INNER JOIN CUSTOMER C ON C.ID=W.CustomerCode"
            +" WHERE WF_JOBID = '"+id+"'";
            DataTable dt = SelectByQuery(sSql);

            WFJobCore _jCore = null;

            if (dt != null)
                _jCore = (WFJobCore)this.MapObject(dt.Rows[0]);

            return _jCore;
        }

        public override void Update(object obj)
        {
            WFJobCore _wfJobCore = (WFJobCore)obj;
            String sSql = ("exec PROCINSERTUPDATEWFJOB '" + _wfJobCore.JobID + "','" + _wfJobCore.JobCatID + "'," + filterstring(_wfJobCore.JobDescription) + ",'" + _wfJobCore.CreatedEmpID + "','" + _wfJobCore.JobCreator + "','" + _wfJobCore.CreatedDate + "','" + _wfJobCore.ClosedDate + "','" + _wfJobCore.JobCode + "','" + _wfJobCore.CustCode + "','" + "U" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public string getJobCode()
        {
            string sSql = " SELECT ISNULL(MAX(WF_JobID),0) AS JOB_CODE FROM WF_JOB";
            DataTable dt = SelectByQuery(sSql);

            WFJobCore _wFJob = null;

            if (dt != null)
                _wFJob = (WFJobCore)this.MapJobCode(dt.Rows[0]);

            long max = long.Parse(_wFJob.JobCode);

            long final = max + 1;

            string formatedNum = final.ToString("0000");

            string jobCode = "RM" + '-' + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("00") + '-' + formatedNum;

            return jobCode;
        }

        public object MapJobCode(System.Data.DataRow dr)
        {
            WFMemberCore _wfMemCore = new WFMemberCore();

            WFJobCore _jobCore = new WFJobCore();
            _jobCore.JobCode = dr["JOB_CODE"].ToString();

            return _jobCore;
        }
    }
}
