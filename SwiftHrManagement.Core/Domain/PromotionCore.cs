using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class PromotionCore
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int emp_id;

        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        private int position_id;

        public int Position_id
        {
            get { return position_id; }
            set { position_id = value; }
        }
        private string promotion_date;

        public string Promotion_date
        {
            get { return promotion_date; }
            set { promotion_date = value; }
        }
        private string oldposition;

        public string Oldposition
        {
            get { return oldposition; }
            set { oldposition = value; }
        }
        private string deptname;

        public string Deptname
        {
            get { return deptname; }
            set { deptname = value; }
        }

        private string subdeptname;

        public string SubDeptname
        {
            get { return subdeptname; }
            set { subdeptname = value; }
        }
        private string branchName;

        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
        private string promotion_type;

        public string Promotion_Type
        {
            get { return promotion_type; }
            set { promotion_type = value; }
        }

        public string SalarySet
        {
            get { return _salarySet; }
            set { _salarySet = value; }
        }

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public string SalarySetMaserId
        {
            get { return _salarySetMaserId; }
            set { _salarySetMaserId = value; }
        }

        private string _salarySet;
        private string _grade;
        private string _salarySetMaserId;


        private string applyOn;

        public string ApplyOn
        {
            get { return applyOn; }
            set { applyOn = value; }
        }
    }
}
