using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class FiscalYear
    {
        public int Id { get; set; }
        public string StartDateAd { get; set; }
        public string EndDateAd { get; set; }
        public string StartDateBs { get; set; }
        public string EndDateBs { get; set; }
        public string FiscalName { get; set; }
    }
}