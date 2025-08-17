using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
namespace SwiftHrManagement.ReportEnging.TrainingProgram
{
    public class TrainingProgByEmpOrEmployees : BaseDAOInv
    {
        public String FindTrainingRptByEmployeeOrDept(String EmpId, String DeptId)
        {
            String sSql = "exec  procTrainingTakenByEmployeeOrAllEmployeesInDepartment '"+ DeptId +"','"+ EmpId +"'";
            return sSql;
        }
        public DataSet FindTrainingRptByEmployeeOrDept(String sSql)
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
