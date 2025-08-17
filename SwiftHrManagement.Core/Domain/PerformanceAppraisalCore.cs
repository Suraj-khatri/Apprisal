using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class PerformanceAppraisalCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long apraisal_id;

        public long Apraisal_id
        {
            get { return apraisal_id; }
            set { apraisal_id = value; }
        }
        private String[] appraisal_Matric_Id;

        public String[] Appraisal_Matric_Id
        {
            get { return appraisal_Matric_Id; }
            set { appraisal_Matric_Id = value; }
        }
        private String[] remarks;

        public String[] Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private String[] weight;

        public String[] Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
