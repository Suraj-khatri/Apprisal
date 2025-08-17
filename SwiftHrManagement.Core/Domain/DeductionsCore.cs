using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class DeductionsCore
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string deductionName;

        public string DeductionName
        {
            get { return deductionName; }
            set { deductionName = value; }
        }

        private string deductionDate;

        public string DeductionDate
        {
            get { return deductionDate; }
            set { deductionDate = value; }
        }

        private double deductionAmount;

        public double DeductionAmount
        {
            get { return deductionAmount; }
            set { deductionAmount = value; }
        }
        private Boolean istaxable;

        public Boolean Istaxable
        {
            get { return istaxable; }
            set { istaxable = value; }
        }
    }
}