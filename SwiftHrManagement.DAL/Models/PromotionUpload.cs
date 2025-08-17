using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.Models
{
   public class PromotionUpload
    {

        public string Emp_code { get; set; }
        public string New_Position { get; set; }
        public string OLD_POSITION { get; set; }
        public string PROMOTION_DATE { get; set; }
        public string BRANCH { get; set; }
        public string DEPARTMENT { get; set; }
        public string emp_type { get; set; }
        public string IsPosted { get; set; }
        public string Error { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string BatchId { get; set; }
    }
}
