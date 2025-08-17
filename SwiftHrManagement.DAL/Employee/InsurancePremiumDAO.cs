using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.InsurancePremiumDAO;

namespace SwiftHrManagement.DAL.InsurancePremiumDAO
{
    public class InsurancePremiumDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public InsurancePremiumDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO InsurancePremium (INSURANCE_ID, PAYMENT_AMOUNT, PAYMENT_DATE, PREMIUM_RECEIPT_NUMBER)"
            + " VALUES ('INSURANCEID', 'PAYMENTAMOUNT', 'PAYMENTDATE', 'PREMIUMRECEIPTNUMBER')");

            this.updateQuery = new StringBuilder("UPDATE InsurancePremium SET PAYMENT_AMOUNT = 'PAYMENTAMOUNT', PAYMENT_DATE ='PAYMENTDATE' "
                + " , PREMIUM_RECEIPT_NUMBER = 'PREMIUMRECEIPTNUMBER'  WHERE ID= ID_");
            
            this.selectQuery = new StringBuilder("");
        }

        public override void Save(object obj)
        {
            InsurancePremiumCore _insurencePremium = (InsurancePremiumCore)obj;
            this.insertQuery.Replace("INSURANCEID", _insurencePremium.InsuranceId.ToString());
            this.insertQuery.Replace("PAYMENTAMOUNT", _insurencePremium.PaymentAmount.ToString());
            this.insertQuery.Replace("PAYMENTDATE", _insurencePremium.PaymentDate.ToString());
            this.insertQuery.Replace("PREMIUMRECEIPTNUMBER", _insurencePremium.ReceiptNumber.ToString());
                        
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            InsurancePremiumCore _insurencePremium = (InsurancePremiumCore)obj;

            this.updateQuery.Replace("ID_", _insurencePremium.Id.ToString());
            this.updateQuery.Replace("INSURANCEID", _insurencePremium.InsuranceId.ToString());
            this.updateQuery.Replace("PAYMENTAMOUNT", _insurencePremium.PaymentAmount.ToString());
            this.updateQuery.Replace("PAYMENTDATE", _insurencePremium.PaymentDate.ToString());
            this.updateQuery.Replace("PREMIUMRECEIPTNUMBER", _insurencePremium.ReceiptNumber.ToString());
          
            ExecuteQuery(this.updateQuery.ToString());
        }
        public InsurancePremiumCore FindById(long Id)
        {
            string sSql = ("SELECT IP.ID,dbo.ShowDecimal(I.INSURED_AMOUNT- SUM(IP.PAYMENT_AMOUNT)) AS UNPAID_AMOUNT,INSURANCE_ID,"
            +" I.INSURANCE_POLICY,PAYMENT_AMOUNT,convert(varchar,PAYMENT_DATE,101) as PAYMENT_DATE,PREMIUM_RECEIPT_NUMBER FROM"
            + " InsurancePremium IP INNER JOIN INSURANCE I ON IP.INSURANCE_ID=I.ID WHERE IP.ID=" + Id + " group by IP.ID,I.INSURED_AMOUNT,"
            +" IP.INSURANCE_ID,I.INSURANCE_POLICY,IP.PAYMENT_AMOUNT,PAYMENT_DATE,PREMIUM_RECEIPT_NUMBER").ToString();
            DataTable dt = SelectByQuery(sSql);
            InsurancePremiumCore _ins = null;
            if (dt != null)
                if (dt.Rows.Count == 0)
                    return _ins;
                _ins = (InsurancePremiumCore)this.MapObject(dt.Rows[0]);
            return _ins;
        }
        public InsurancePremiumCore FindInsurancePolicyById(long InsuranceId)
        {
            string sSql = ("Exec procGetInsuranceDetails 'i'," + InsuranceId + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            InsurancePremiumCore _ins = null;
            if (dt != null)
                if (dt.Rows.Count == 0)
                    return _ins;
            _ins = (InsurancePremiumCore)this.MapObject1(dt.Rows[0]);
            return _ins;
        }
        public object MapObject1(System.Data.DataRow dr)
        {
            InsurancePremiumCore _insurance = new InsurancePremiumCore();
            _insurance.UnpaidAmount = dr["UNPAID_AMOUNT"].ToString();
            _insurance.InsurancePolicy = dr["INSURANCE_POLICY"].ToString();
            return _insurance;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            InsurancePremiumCore _insurance = new InsurancePremiumCore();

            _insurance.Id = long.Parse(dr["ID"].ToString());
            _insurance.InsuranceId = dr["INSURANCE_ID"].ToString();
            _insurance.InsurancePolicy = dr["INSURANCE_POLICY"].ToString();
            _insurance.PaymentAmount = double.Parse(dr["PAYMENT_AMOUNT"].ToString());
            _insurance.PaymentDate = dr["PAYMENT_DATE"].ToString();
            _insurance.ReceiptNumber = dr["PREMIUM_RECEIPT_NUMBER"].ToString();
            _insurance.UnpaidAmount = dr["UNPAID_AMOUNT"].ToString();
            
            return _insurance;
        }
        public void DeleteInsurancePremium(long ID, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from InsurancePremium' , ' and ID=''"+ ID +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("InsurancePremium", "ID", Id);
        }
    }
}
