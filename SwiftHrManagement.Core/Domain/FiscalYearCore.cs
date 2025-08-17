using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class FiscalYearCore : BaseDomain
    {
        private long year;

        public long Year
        {
            get { return year; }
            set { year = value; }
        }

        //fiscal year start and end date in Roman Calendar

        private DateTime enYearStartDate;

        public DateTime EnYearStartDate
        {
            get { return enYearStartDate; }
            set { enYearStartDate = value; }
        }

        private DateTime enYearEndDate;

        public DateTime EnYearEndDate
        {
            get { return enYearEndDate; }
            set { enYearEndDate = value; }
        }

        //fiscal year start and end date in Nepali Calendar

        private String npYearStartDate;

        public String NpYearStartDate
        {
            get { return npYearStartDate; }
            set { npYearStartDate = value; }
        }

        private String npyearEndDate;

        public String NpyearEndDate
        {
            get { return npyearEndDate; }
            set { npyearEndDate = value; }
        }
    }
}
