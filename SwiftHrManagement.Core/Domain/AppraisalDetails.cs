using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AppraisalDetails : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long appraisal_Id;

        public long Appraisal_Id
        {
            get { return appraisal_Id; }
            set { appraisal_Id = value; }
        }
        private long appraisal_Max_Id;

        public long Appraisal_Max_Id
        {
            get { return appraisal_Max_Id; }
            set { appraisal_Max_Id = value; }
        }
        private String remarks;

        public String Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private String weight;

        public String Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
