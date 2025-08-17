using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftHrManagement.web.Model
{
    public class ApprisalStatus
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Group { get; set; }
        public int Sn { get; set; }

    }
}