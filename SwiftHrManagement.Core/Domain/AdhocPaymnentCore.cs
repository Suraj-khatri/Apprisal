using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class AdhocPaymentCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String employeeId;

        public String EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string add_deduct;

        public string Add_deduct
        {
            get { return add_deduct; }
            set { add_deduct = value; }
        }
        private string head_id;

        public string Head_id
        {
            get { return head_id; }
            set { head_id = value; }
        }
        private string applied_date;

        public string Applied_date
        {
            get { return applied_date; }
            set { applied_date = value; }
        }
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private double tax_deduct;

        public double Tax_deduct
        {
            get { return tax_deduct; }
            set { tax_deduct = value; }
        }
        private string ispaid;

        public string Ispaid
        {
            get { return ispaid; }
            set { ispaid = value; }
        }
        private string narration;

        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
        private string istaxed;

        public string Istaxed
        {
            get { return istaxed; }
            set { istaxed = value; }
        }

        private string App_for_month;

        public string App_for_Month
        {
            get { return App_for_month; }
            set { App_for_month = value; }
        }

        private string App_for_year;

        public string App_for_Year
        {
            get { return App_for_year; }
            set { App_for_year = value; }
        }

    }
}
