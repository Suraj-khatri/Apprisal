using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.RptDao
{
    public class EmpDetlRpt:BaseDAO
    {
        public EmpDetlRpt()
        {

        }
        public String EmpDetlQuryStr(String fromdate, String todate, String branch, String department, String position)
        {
            String sSql = "exec proc_Emp_Detail '" + fromdate + "','" + todate + "','" + branch + "','" + department + "','" + position + "'";
            return sSql;
        }
        public DataSet EmpDetlQuryStr(String Ssql)
        {
            return ReturnDataset(Ssql);
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
