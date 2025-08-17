using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.ReportEnging.EmployeeMovements.ExternalTransferPlan
{
    public class ExternalTransferPlanRpt : BaseDAO
    {
        public ExternalTransferPlanRpt()
        {

        }
        public String EmpExternalTransferQuryStr(String fromdate, String todate)
        {
            String sSql = "exec procExternalTransferPlanSummary '" + fromdate + "','" + todate + "'";
            return sSql;
        }
        public DataSet EmpExternalTransferQuryStr(String sSql)
        {
            return ReturnDataset(sSql);
        }
        public String ExternalTransPlnPrm(int fromranch, int toBranch, String startDate, String EndDate, String rptType)
        {
            String sSql = "exec procExternalTransferPlanParameterised " + fromranch + ", " + toBranch + ", '" + startDate + "', "
            + " '" + EndDate + "','" + rptType + "'";
            return sSql;
        }
        public DataSet ExternalTransPlnPrm(String sSql)
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
        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

    }
}
