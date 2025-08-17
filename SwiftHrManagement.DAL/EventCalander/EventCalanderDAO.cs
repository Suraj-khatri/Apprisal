using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.EventCalander
{
    public class EventCalanderDAO : BaseDAOInv
    {
        public DataSet GetEventCalander(string year, string month)
        {
            return ReturnDataset("Exec [procDepartmentalEvents] " + year + "," + month);
        }
        public String GetEvents(DateTime eventDate)
        {
       
            String sSql = "SELECT LEAVE_NAME as Name, convert(varchar, LEAVE_DATE, 103) as Date, LEAVE_TYPE as [Nature/Venue], LEAVE_DETAILS as Details, CASE WHEN LEAVE_FLAG ='H' then 'Holiday' when LEAVE_FLAG='E' "
            + " then 'Events' end 'Events/Holiday' FROM OfficialCalendar where LEAVE_DATE='"+ eventDate +"'";
            return sSql;
        }
        public DataSet GetEvents(String sSql)
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
