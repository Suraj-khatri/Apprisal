using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class BenefitsOnlyForTaxCore : BaseDomain
    {
        private long id;

        private string benifit_name;

        public string Benifit_name
        {
            get { return benifit_name; }
            set { benifit_name = value; }
        }
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private long empid;

        public long Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        private string int_ben_type;

        public string Int_ben_type
        {
            get { return int_ben_type; }
            set { int_ben_type = value; }
        }
        private string fis_year;

        public string Fis_year
        {
            get { return fis_year; }
            set { fis_year = value; }
        }
        private double act_int_paid;

        public double Act_int_paid
        {
            get { return act_int_paid; }
            set { act_int_paid = value; }
        }
        private double applied_int_rate;

        public double Applied_int_rate
        {
            get { return applied_int_rate; }
            set { applied_int_rate = value; }
        }
        private double market_int_rate;

        public double Market_int_rate
        {
            get { return market_int_rate; }
            set { market_int_rate = value; }
        }
        private double taxable_int_amt;

        public double Taxable_int_amt
        {
            get { return taxable_int_amt; }
            set { taxable_int_amt = value; }
        }
        private string narration;

        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
    }
}
