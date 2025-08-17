using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.ExternalTransferPlanDAO
{
    public class ExternalTransferPlanDAO : BaseDAOInv
    {     
        public ExternalTransferPlanDAO()
        {
            
        }
        public override void Save(object obj)
        {

        }
        public override void Update(object obj)
        {       
        }

       
        public ExternalTransferPlanCore FindById(long Id)
        {
            string sSQL = "select ID,STAFF_ID,FROM_BRANCH,FROM_DEPARTMENT,WHICH_BRANCH,WHICH_DEPARTMENT,WHICH_POSITION,convert(varchar,EFFECTIVE_DATE,101) as EFFECTIVE_DATE,"
            + " convert(varchar,ACTUAL_REPORT_DATE,101) as ACTUAL_REPORT_DATE,dbo.GetEmployeeInfoById(RECOMMEND_BY)RECOMMEND_BY,"
            + " convert(varchar,recommend_date,101) recommend_date,TRANSFER_DESCRIPTION,TRANSFER_TYPE from ExternalTransferPlan where ID=" + Id + "";

            DataTable dt = SelectByQuery(sSQL);
            ExternalTransferPlanCore _extTransCore = null;
            if (dt != null)
                _extTransCore = (ExternalTransferPlanCore)this.MapObject(dt.Rows[0]);
            return _extTransCore;
        }
        public ExternalTransferPlanCore FindByTempId(long Id)
        {
            string sSQL = "select ID,EMPLOYEE_ID,FROM_BRANCH,FROM_DEPARTMENT,WHICH_DEPARTMENT,WHICH_POSITION,convert(varchar,EFFECTIVE_DATE,101) as EFFECTIVE_DATE,"
            + " convert(varchar,END_DATE,101) as END_DATE,TRANSFER_DESCRIPTION,service_flag from temporary_transfer where ID=" + Id + "";

            DataTable dt = SelectByQuery(sSQL);
            ExternalTransferPlanCore _extTransCore = null;
            if (dt != null)
                _extTransCore = (ExternalTransferPlanCore)this.MapObjectForTempTransfer(dt.Rows[0]);
            return _extTransCore;
        }
        public ExternalTransferPlanCore FindEmpDiscontinuousByID(long Id)
        {
            string sSQL = "select ID,STAFF_ID,DISCONTINUOUS_REASON,DISCRIPTION,convert(varchar,EFFECTIVE_DATE,101) as EFFECTIVE_DATE from EmployeeDiscontinuousPlan where ID=" + Id + "";

            DataTable dt = SelectByQuery(sSQL);
            ExternalTransferPlanCore _extTransCore = null;
            if (dt != null)
                _extTransCore = (ExternalTransferPlanCore)this.MapObjectForDiscontinuous(dt.Rows[0]);
            return _extTransCore;
        }
        public object MapObjectForDiscontinuous(DataRow dr)
        {
            ExternalTransferPlanCore empDiscontinuous = new ExternalTransferPlanCore();
            empDiscontinuous.Id = long.Parse(dr["ID"].ToString());
            empDiscontinuous.StaffId = (dr["STAFF_ID"].ToString());
            empDiscontinuous.DiscontinuousMode = (dr["DISCONTINUOUS_REASON"].ToString());
            empDiscontinuous.Description = (dr["DISCRIPTION"].ToString());
            empDiscontinuous.EffectiveDate = (dr["EFFECTIVE_DATE"].ToString());
            return empDiscontinuous;
        }
        public override object MapObject(DataRow dr)
        {
            ExternalTransferPlanCore tTransferPlan = new ExternalTransferPlanCore();
            tTransferPlan.Id = long.Parse(dr["ID"].ToString());
            tTransferPlan.StaffId = (dr["STAFF_ID"].ToString());         
            tTransferPlan.FromWhichBranch = (dr["FROM_BRANCH"].ToString());
            tTransferPlan.FromWhichDepartment = (dr["FROM_DEPARTMENT"].ToString());
            tTransferPlan.WhichBranch = (dr["WHICH_BRANCH"].ToString());
            tTransferPlan.WhichDepartment = (dr["WHICH_DEPARTMENT"].ToString());
            tTransferPlan.WhichPosition = (dr["WHICH_POSITION"].ToString());
            tTransferPlan.EffectiveDate = (dr["EFFECTIVE_DATE"].ToString());
            tTransferPlan.ActualReportDate = (dr["ACTUAL_REPORT_DATE"].ToString());
            tTransferPlan.TransferDescription = (dr["TRANSFER_DESCRIPTION"].ToString());
            tTransferPlan.TransferType = (dr["TRANSFER_TYPE"].ToString());
            tTransferPlan.RecommendBy = (dr["RECOMMEND_BY"].ToString());
            tTransferPlan.RecommendDate = (dr["recommend_date"].ToString());  
            return tTransferPlan;
        }

        public object MapObjectForTempTransfer(DataRow dr)
        {
            ExternalTransferPlanCore tTransferPlan = new ExternalTransferPlanCore();
            tTransferPlan.Id = long.Parse(dr["ID"].ToString());
            tTransferPlan.StaffId = (dr["EMPLOYEE_ID"].ToString());
            tTransferPlan.FromWhichBranch = (dr["FROM_BRANCH"].ToString());
            tTransferPlan.FromWhichDepartment = (dr["FROM_DEPARTMENT"].ToString());
            tTransferPlan.WhichDepartment = (dr["WHICH_DEPARTMENT"].ToString());
            tTransferPlan.WhichPosition = (dr["WHICH_POSITION"].ToString());
            tTransferPlan.EffectiveDate = (dr["EFFECTIVE_DATE"].ToString());
            tTransferPlan.Enddate = (dr["END_DATE"].ToString());
            tTransferPlan.TransferDescription = (dr["TRANSFER_DESCRIPTION"].ToString());
            tTransferPlan.ServiceEvent = (dr["service_flag"].ToString());
            return tTransferPlan;
        }
    }
}