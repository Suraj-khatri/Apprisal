using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class PossibleAnswer : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string choice;

        public string Choice
        {
            get { return choice; }
            set { choice = value; }
        }

        

       
    }
}
