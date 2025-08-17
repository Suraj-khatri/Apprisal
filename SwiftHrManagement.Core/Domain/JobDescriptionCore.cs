

namespace SwiftHrManagement.Core.Domain
{
  public class JobDescriptionCore
    {
        public string EmpId { get; set; }
        public string BranchId { get; set; }
        public string PositionId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FunctionalId { get; set; }
        public string FunctionalObjectives { get; set; }
        public string SuperVisor { get; set; }
        public string GeneralJd { get; set; }
        public string ServicesJd { get; set; }
        public string KeyCompetent { get; set; }
        public long User { get; set; }
        public string Flag { get; set; }
        public int CreatedBy { get; set; }
        public int Id { get; set; }
        public string RowId { get; set; }
        public string EmpDate { get; set; }
        public string SuvDate { get; set; }
        public string FiscalYear  { get; set; }
    }
}
