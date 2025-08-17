using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class StaticDataDetailCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string type_id;

        public string Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }
        private string type_Title;

        public string Type_Title
        {
            get { return type_Title; }
            set { type_Title = value; }
        }
        private string detail_title;

        public string Detail_title
        {
            get { return detail_title; }
            set { detail_title = value; }
        }
        private string detail_desc;

        public string Detail_desc
        {
            get { return detail_desc; }
            set { detail_desc = value; }
        }

    }
}
