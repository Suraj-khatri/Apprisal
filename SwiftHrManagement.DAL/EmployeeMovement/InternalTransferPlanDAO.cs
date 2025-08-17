using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.InternalTransferPlanDAO
{
    public class InternalTransferPlanDAO : BaseDAOInv
    {
        public InternalTransferPlanDAO()
        {
        }
        public override void Save(object obj)
        {
        }
        public override void Update(object obj)
        {
        }
        public InternalTransferPlanCore FindById(long Id)
        {
            string sSql = "select ID,STAFF_ID,FROM_DEPARTMENT,WHICH_DEPARTMENT,WHICH_POSITION,convert(varchar,EFFECTIVE_DATE,101) as EFFECTIVE_DATE,"
             + " convert(varchar,ACTUAL_REPORT_DATE,101) as ACTUAL_REPORT_DATE,TRANSFER_DESCRIPTION from ExternalTransferPlan where ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            InternalTransferPlanCore _intTransCore = null;
            if (dt != null)
                _intTransCore = (InternalTransferPlanCore)this.MapObject(dt.Rows[0]);
            return _intTransCore;
        }
        public override object MapObject(DataRow dr)
        {
            InternalTransferPlanCore intTransferPlan = new InternalTransferPlanCore();
            intTransferPlan.Id = long.Parse(dr["ID"].ToString());
            intTransferPlan.StaffId = (dr["STAFF_ID"].ToString());            
            intTransferPlan.FromDept = (dr["FROM_DEPARTMENT"].ToString());
            intTransferPlan.WhichDepartment = (dr["WHICH_DEPARTMENT"].ToString());
            intTransferPlan.WhichPosition = (dr["WHICH_POSITION"].ToString());
            intTransferPlan.EffectiveDate = (dr["EFFECTIVE_DATE"].ToString());
            intTransferPlan.ReportedDate = (dr["ACTUAL_REPORT_DATE"].ToString());
            intTransferPlan.TransferDesc = (dr["TRANSFER_DESCRIPTION"].ToString()); 
            return intTransferPlan;
        }
    }
}