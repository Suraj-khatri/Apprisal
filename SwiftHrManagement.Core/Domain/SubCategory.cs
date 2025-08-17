using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class SubCategory : AbstractCategory
    {
        private long _categoryId;

        public long CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

    }
}
