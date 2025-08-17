using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class CMSCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string funcName;

        public string FuncName
        {
            get { return funcName; }
            set { funcName = value; }
        }
        private string funcHead;

        public string FuncHead
        {
            get { return funcHead; }
            set { funcHead = value; }
        }
        private string funcDetail;

        public string FuncDetail
        {
            get { return funcDetail; }
            set { funcDetail = value; }
        }
    }
}
