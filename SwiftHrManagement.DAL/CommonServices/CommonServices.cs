using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.CommonServices
{
   public class CommonServices:BaseDAO
    {

       public bool DoesHrUser(string empId)
       {
           var sql = "SELECT EMPLOYEE_ID FROM Employee WHERE DEPARTMENT_ID =28 and EMPLOYEE_ID = " + filterstring(empId) + "";
           return CheckStatement(sql);
       }

       public bool DoesTrainingFeedbackAccess(string empId)
       {
           var sql = "select STAFF_ID from TrainingParticipants where IS_APPROVED = '1' and STAFF_ID = " + filterstring(empId) + "";
           return CheckStatement(sql);
       }
       public string HrHead()
       {
           var sql =" SELECT e.FIRST_NAME +' '+e.MIDDLE_NAME +' '+ e.LAST_NAME HRHead,EMPLOYEE_ID from Employee e where FUNCTIONAL_TITLE =955";
           return GetSingleresult(sql);
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
