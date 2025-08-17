using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.ReportEnging.EmployeeMovements.ExternalTransferPlan
{
    public class ExternalTransferPlanParameterised : BaseDAO
    {
        public String ExternalTransPlnPrm(int fromranch, int toBranch, String startDate, String EndDate, String rptType)
        {
            String sSql = "exec procExternalTransferPlanParameterised "+ fromranch +", "+ toBranch +", '"+ startDate +"', "
            + " '"+ EndDate +"','"+ rptType +"'"; 
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
        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
