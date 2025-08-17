using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class EmployeeMedical : BaseDomain
    {
        private long medicalid;

        public long Medicalid
        {
            get { return medicalid; }
            set { medicalid = value; }
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string problem;

        public string Problem
        {
            get { return problem; }
            set { problem = value; }
        }

        private string diagnosis;

        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        private string doctor;

        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        private string hospital;

        public string Hospital
        {
            get { return hospital; }
            set { hospital = value; }
        }

        private string checheddate;

        public string Checheddate
        {
            get { return checheddate; }
            set { checheddate = value; }
        }

        private string desease;

        public string Desease
        {
            get { return desease; }
            set { desease = value; }
        }
    }
}
