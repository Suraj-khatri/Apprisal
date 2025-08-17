using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class CustomerFileCore:BaseDomain
    {
        private long docId;

        public long DocId
        {
            get { return docId; }
            set { docId = value; }
        }
        private long custId;

        public long CustID
        {
            get { return custId; }
            set { custId = value; }
        }
        
        private string docName;

        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
        private string docDesciption;

        public string DocDesciption
        {
            get { return docDesciption; }
            set { docDesciption = value; }
        }
        private string fileExtn;

        public string FileExtn
        {
            get { return fileExtn; }
            set { fileExtn = value; }
        }
    }
}
