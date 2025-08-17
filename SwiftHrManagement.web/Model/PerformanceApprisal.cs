using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class PerformanceApprisal
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string SuvName { get; set; }
        public string ReviewerName { get; set; }
        public string Status { get; set; }
        public DateTime  SuvAGreeDate { get; set; }
        public DateTime  AppraiseeDate{ get; set; }
        public DateTime  ReviewdDate { get; set; }
        public string  FiscalYear { get; set; }
    }
}