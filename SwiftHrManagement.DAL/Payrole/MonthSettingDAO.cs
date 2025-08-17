using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.Payrole
{
    public class MonthSettingDAO : BaseDAOInv
    {
        public void Save(string monthId, string monthName)
        {
            ExecuteQuery("proc_MonthList 'u','" + monthId + "','" + monthName + "'");
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
