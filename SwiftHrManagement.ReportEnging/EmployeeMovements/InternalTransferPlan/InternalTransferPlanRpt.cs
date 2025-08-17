using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.ReportEnging.EmployeeMovements.InternalTransferPlan
{
    public class InternalTransferPlanRpt : BaseDAO
    {
        public InternalTransferPlanRpt()
        {
        }
        public String EmpInternalTransferQuryStr(String fromdate, String todate)
        {
            String sSql = "exec procInternalTransferPlanSummary '" + fromdate + "','" + todate + "'";
            return sSql;
        }
        public DataSet EmpInternalTransferQuryStr(String sSql)
        {
            return ReturnDataset(sSql);
        }
        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
