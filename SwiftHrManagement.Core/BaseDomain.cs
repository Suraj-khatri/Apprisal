using System;

namespace SwiftHrManagement.Core
{
    public class BaseDomain
    {
        protected DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return DateTime.Now; }
            set { createdDate = value; }
        }
        protected String createdBy;

        public String CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        protected DateTime modifyDate;

        public DateTime ModifyDate
        {
            get { return DateTime.Now; }
            set { modifyDate = value; }
        }
        protected String modifyBy;

        public String ModifyBy
        {
            get { return modifyBy; }
            set { modifyBy = value; }
        }
    }
}
