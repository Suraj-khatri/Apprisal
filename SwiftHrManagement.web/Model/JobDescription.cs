using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class JobDescription
    {
        public int Sn { get; set; }
        public string EmployeeName { get; set; }
        public string SupervisorName { get; set; }
        public string StatrtDate { get; set; }
        public string EndDate { get; set; }
        public int FiscalId { get; set; }
        public string FiscalYear { get; set; }
        public string Sataus { get; set; }
        public string EmpIdEncrypt { get; set; }
        public string AppIdEncrypt { get; set; }
        public int EmpId { get; set; }
        public int AppId { get; set; }
        public string Branch { get; set; }
        public string Position { get; set; }
    }
}