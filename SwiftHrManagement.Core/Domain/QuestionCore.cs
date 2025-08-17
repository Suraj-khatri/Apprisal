using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class QuestionCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string question;

        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        private string ansa;

        public string Ansa
        {
            get { return ansa; }
            set { ansa = value; }
        }

        private string ansb;

        public string Ansb
        {
            get { return ansb; }
            set { ansb = value; }
        }

        private string ansc;

        public string Ansc
        {
            get { return ansc; }
            set { ansc = value; }
        }

        private string ansd;

        public string Ansd
        {
            get { return ansd; }
            set { ansd = value; }
        }

        private string rightans;

        public string Rightans
        {
            get { return rightans; }
            set { rightans = value; }
        }

        private string qtype;

        public string Qtype
        {
            get { return qtype; }
            set { qtype = value; }
        }
    }
}
