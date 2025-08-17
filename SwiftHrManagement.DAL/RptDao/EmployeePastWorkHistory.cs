using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.RptDao
{
    public class EmployeePastWorkHistory:BaseDAO
    {
        public String EmpWorkHistoryQuryString(Int16 EmpId)
        {
            String sSql = "exec procWorkHistory " + EmpId + "";
            return sSql;
        }
        public DataSet EmpWorkHistoryQuryString(String sSql)
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
