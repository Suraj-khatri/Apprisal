using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class Performance
    {
        public int Id { get; set; }
        public string   EmployeeName { get; set; }
        public DateTime   Fromdate { get; set; }
        public DateTime   ToDate { get; set; }
        public string StatusText { get; set; }
        public int Status { get; set; }
        public int FiscalId { get; set; }
        public int EmpCode { get; set; }
        

    }
}