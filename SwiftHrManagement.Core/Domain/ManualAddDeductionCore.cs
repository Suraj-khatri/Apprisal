using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ManualAddDeductionCore
    {
        private long manual_entry_id;

        public long Manual_entry_id
        {
            get { return manual_entry_id; }
            set { manual_entry_id = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String addDeduct;

        public String AddDeduct
        {
            get { return addDeduct; }
            set { addDeduct = value; }
        }
        private Boolean enable;

        public Boolean Enable
        {
            get { return enable; }
            set { enable = value; }
        }
    }
}
