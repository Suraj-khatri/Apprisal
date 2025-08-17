using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class FiscalCore
    {
        private long month_number;

        public long Month_number
        {
            get { return month_number; }
            set { month_number = value; }
        }
        private string fiscal_year;

        public string Fiscal_year
        {
            get { return fiscal_year; }
            set { fiscal_year = value; }
        }
        private string engfrom;

        public string Engfrom
        {
            get { return engfrom; }
            set { engfrom = value; }
        }
        private string engto;

        public string Engto
        {
            get { return engto; }
            set { engto = value; }
        }
        private string nepfrom;

        public string Nepfrom
        {
            get { return nepfrom; }
            set { nepfrom = value; }
        }
        private string nepto;

        public string Nepto
        {
            get { return nepto; }
            set { nepto = value; }
        }
    }
}
