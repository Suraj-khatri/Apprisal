using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.Models
{
  public  class KraKpiGrid
    {
        public long RowId { get; set; }
        public string KraTopic { get; set; }
        public string KpiTopic { get; set; }
        public decimal kraWeightage { get; set; }
        public decimal KpiWeightage { get; set; }
        public string Edit { get; set; }
        public bool IsEditEnable { get; set; }
        public bool IsDeleteEnable { get; set; }
        public string Status { get; set; }
        public decimal? PAchievement { get; set; }
        public decimal? Rating { get; set; }
        public decimal? Variance { get; set; }
        public string PerformanceRemarks { get; set; }
        public decimal? performanceScore { get; set; }
        public decimal Total { get; set; }
        public int AppId { get; set; }



    }
}
