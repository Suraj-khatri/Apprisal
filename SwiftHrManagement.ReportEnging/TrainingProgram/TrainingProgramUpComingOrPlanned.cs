using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.ReportEnging.TrainingProgram
{
    public class TrainingProgramUpComingOrPlanned : BaseDAOInv
    {
        public String UpcomingorPlannedTraining(String branchId, String programId, String rptType)
        {
            String sSql = "exec procUpcomingAndRunningTrainingProgramBranchWise '" + branchId + "','" + programId + "', '" + rptType + "'";
            return sSql;
        }
        public DataSet UpcomingorPlannedTraining(String sSql)
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
