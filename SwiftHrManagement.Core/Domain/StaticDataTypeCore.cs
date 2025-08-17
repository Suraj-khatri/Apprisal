using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class StaticDataTypeCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string type_title;

        public string Type_title
        {
            get { return type_title; }
            set { type_title = value; }
        }
        private string type_desc;

        public string Type_desc
        {
            get { return type_desc; }
            set { type_desc = value; }
        }

    }
}
