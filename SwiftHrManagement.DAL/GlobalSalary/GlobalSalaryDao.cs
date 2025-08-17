using System;
using System.Data;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.GlobalSalary
{
   public class GlobalSalaryDao : BaseDAO
    {

        public DataTable OnUpdate(string jobType, string branchId, string positionId, string empId,string benefitId,string amt,string flatOrPercentage,string user)
        {
            var sql = "Exec [proc_GlobalSalaryCRUDOperation] @flag = " +filterstring(jobType);
                    sql += ", @branchId = " + filterstring(branchId);
                    sql += ", @positionId = " + filterstring(positionId);
                    sql += ", @empId=" + filterstring(empId);
                    sql += ", @BENEFIT_ID=" + filterstring(benefitId);
                    sql += ", @AMOUNT=" + filterstring(amt);
                    sql += ", @flatOrPercentage=" + filterstring(flatOrPercentage);
                    sql += ", @USER=" + filterstring(user);
                 return ReturnDataset(sql).Tables[0];

        }
       

        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
