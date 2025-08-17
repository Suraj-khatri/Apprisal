using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.FlightDetails
{
    public class FlightDetailsDao : BaseDAO
    {
        public DataTable FindAuthorisedPerson(string Id)
        {
            var sql = @"SELECT
	                        ID,dbo.GetEmployeeFullNameOfId(Authorised_By) AuthorisedPerson
                        FROM Flight_Authorization WHERE Session_Id = " + filterstring(Id);
            return ReturnDataset(sql).Tables[0];
        }

        public override object MapObject(DataRow dr)
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
