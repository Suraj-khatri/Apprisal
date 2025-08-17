using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.Core.Domain;
namespace SwiftHrManagement.ReportEnging.TrainingProgram
{
    public class TrainingSummary : BaseDAOInv
    {
        private StringBuilder _selectQuery; 
        public TrainingSummary()
        {

        }
        public String FindTrainingSummaryReport(String FromDate, String To_Date)
        {
            _selectQuery = new StringBuilder("select tp.TRAINING_PROGRAM_TITLE as 'Training Program', tp.NUMBER_OF_DAYS as 'Total Days', "
            + " tp.VENUE + ', ' + tp.CITY + ', ' + tp.COUNTRY as venue from TrainingProgram as tp where "
            + "tp.ACTUAL_START_DATE between '" + FromDate + "' and '"+ To_Date +"'");
            return  _selectQuery.ToString();
            //return (ReturnDataset(_selectQuery.ToString()));
        }
        public DataSet FindTrainingSummaryReport(String sSql)
        {
            return (ReturnDataset(sSql));
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
