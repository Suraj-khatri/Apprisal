using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class PerformanceAgreement
    {
        public int Sn { get; set; }
        public string AppriseeName { get; set; }
        public string Status { get; set; }
        public string Fiscalyear { get; set; }
        public string StartDate { get; set; }
        public string Supervisor { get; set; }
        public string Reviewer { get; set; }
        public int ReviewerId { get; set; }
        public int SupervisorId { get; set; }
        public string EndDate { get; set; }
        public int AppId { get; set; }
        public string AppIdEncrypt { get; set; }
        public int EmpId { get; set; }
        public string EmpIdEncrypt { get; set; }

        public string Branch { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string flag { get; set; }
       public int statusCode { get; set; }
       public int FiscalId { get; set; }
       
       public int Reviewrid { get; set; }
    }
}