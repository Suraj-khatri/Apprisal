using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsOnlyForTaxDAO;

namespace SwiftHrManagement.DAL.BenefitsOnlyForTaxDAO
{
    public class BenefitsOnlyForTaxDAO : BaseDAO
    { 
        private StringBuilder insertQuery = null;
        private StringBuilder updateQuery = null;

        BenefitsOnlyForTaxCore _benefits = new BenefitsOnlyForTaxCore();
        BaseDomain _baseDomain = new BaseDomain();

        public BenefitsOnlyForTaxDAO()
        {
            this.insertQuery = new StringBuilder(" INSERT INTO InterestBenefitsOnlyForTaxSetting(EMPLOYEE_ID, INTEREST_BENIFIT_TYPE,FISCAL_YEAR, ACTUAL_INT_PAID, "
            + " APPLIED_INT_RATE, MARKET_INT_RATE, TAXABLE_INT_AMT, NARRATION, CREATED_BY, CREATED_DATE) VALUES('EMPLOYEEID', 'INTERESTBENIFITTYPE', "
            + " 'FISCALYEAR','ACTUALINTPAID', 'APPLIEDINTRATE','MARKETINTRATE','TAXABLEINTAMT','NARRATION_','CREATEDBY','CREATEDDATE') SELECT SCOPE_IDENTITY();");

            this.updateQuery = new StringBuilder("UPDATE InterestBenefitsOnlyForTaxSetting SET EMPLOYEE_ID='EMPLOYEEID',INTEREST_BENIFIT_TYPE='INTERESTBENIFITTYPE',"
            + " FISCAL_YEAR='FISCALYEAR',ACTUAL_INT_PAID='ACTUALINTPAID',APPLIED_INT_RATE='APPLIEDINTRATE',MARKET_INT_RATE='MARKETINTRATE',"
            + " TAXABLE_INT_AMT='TAXABLEINTAMT',NARRATION='NARRATION_',MODIFIED_BY='MODIFIEDBY',MODIFIED_DATE='MODIFIEDDATE' WHERE ID = 'Id_'");
        }
        public override void Save(object obj)
        {
            BenefitsOnlyForTaxCore _benCore = (BenefitsOnlyForTaxCore)obj;
            this.insertQuery.Replace("EMPLOYEEID", _benCore.Empid.ToString());
            this.insertQuery.Replace("ACTUALINTPAID", _benCore.Act_int_paid.ToString());
            this.insertQuery.Replace("APPLIEDINTRATE", _benCore.Applied_int_rate.ToString());
            this.insertQuery.Replace("FISCALYEAR", _benCore.Fis_year);
            this.insertQuery.Replace("INTERESTBENIFITTYPE", _benCore.Int_ben_type.ToString());
            this.insertQuery.Replace("MARKETINTRATE", _benCore.Market_int_rate.ToString());
            this.insertQuery.Replace("TAXABLEINTAMT", _benCore.Taxable_int_amt.ToString());
            this.insertQuery.Replace("NARRATION_", _benCore.Narration.ToString());
            this.insertQuery.Replace("CREATEDBY", _benCore.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _benCore.CreatedDate.ToString());
            int RowId = ExecuteQuery(this.insertQuery.ToString(),'y');
            _benCore.Id = RowId;
        }

        public override void Update(object obj)
        {
            BenefitsOnlyForTaxCore _benCore = (BenefitsOnlyForTaxCore)obj;
            this.updateQuery.Replace("Id_", _benCore.Id.ToString());
            this.updateQuery.Replace("EMPLOYEEID", _benCore.Empid.ToString());
            this.updateQuery.Replace("ACTUALINTPAID", _benCore.Act_int_paid.ToString());
            this.updateQuery.Replace("APPLIEDINTRATE", _benCore.Applied_int_rate.ToString());
            this.updateQuery.Replace("FISCALYEAR", _benCore.Fis_year);
            this.updateQuery.Replace("INTERESTBENIFITTYPE", _benCore.Int_ben_type.ToString());
            this.updateQuery.Replace("MARKETINTRATE", _benCore.Market_int_rate.ToString());
            this.updateQuery.Replace("TAXABLEINTAMT", _benCore.Taxable_int_amt.ToString());
            this.updateQuery.Replace("NARRATION_", _benCore.Narration.ToString());
            this.updateQuery.Replace("MODIFIEDBY", _benCore.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", _benCore.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<BenefitsOnlyForTaxCore> FindAllByEmpId(long Id)
        {
            string sSql = "select IB.ID, IB.EMPLOYEE_ID, S.DETAIL_TITLE 'INTEREST_BENIFIT_TYPE', IB.FISCAL_YEAR, IB.ACTUAL_INT_PAID, IB.MARKET_INT_RATE, IB.TAXABLE_INT_AMT, "
            + " IB.NARRATION, IB.APPLIED_INT_RATE from InterestBenefitsOnlyForTaxSetting IB inner join (select * from StaticDataDetail where TYPE_ID=42) "
            + " s on s.ROWID = IB.INTEREST_BENIFIT_TYPE where IB.EMPLOYEE_ID = " + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<BenefitsOnlyForTaxCore> _benefits = new List<BenefitsOnlyForTaxCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BenefitsOnlyForTaxCore _ben = (BenefitsOnlyForTaxCore)this.Mapbenefit(dr);
                    _benefits.Add(_ben);
                }
            }
            return _benefits;
        }

        public BenefitsOnlyForTaxCore FindBenefitById(long Id)
        {
            String sqlStatement = "SELECT ID, EMPLOYEE_ID, INTEREST_BENIFIT_TYPE, ACTUAL_INT_PAID, FISCAL_YEAR,APPLIED_INT_RATE,MARKET_INT_RATE,TAXABLE_INT_AMT,NARRATION FROM "
            + " InterestBenefitsOnlyForTaxSetting WHERE ID =" + Id + "";
            DataTable dTable = SelectByQuery(sqlStatement);
            BenefitsOnlyForTaxCore _oneBenefit = null;

            if (dTable != null)

                _oneBenefit = (BenefitsOnlyForTaxCore)this.Mapbenefit(dTable.Rows[0]);
              return _oneBenefit; 
         }

        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
        }
        public object Mapbenefit(System.Data.DataRow dr)
        {
            BenefitsOnlyForTaxCore _bCore = new BenefitsOnlyForTaxCore();
            _bCore.Id = long.Parse(dr["ID"].ToString());
            _bCore.Empid = long.Parse(dr["EMPLOYEE_ID"].ToString());
            _bCore.Int_ben_type = (dr["INTEREST_BENIFIT_TYPE"].ToString());
            _bCore.Fis_year = (dr["FISCAL_YEAR"].ToString());
            _bCore.Act_int_paid = double.Parse(dr["ACTUAL_INT_PAID"].ToString());
            _bCore.Applied_int_rate = double.Parse(dr["APPLIED_INT_RATE"].ToString());
            _bCore.Market_int_rate = double.Parse(dr["MARKET_INT_RATE"].ToString());
            _bCore.Taxable_int_amt = double.Parse(dr["TAXABLE_INT_AMT"].ToString());
            _bCore.Narration = (dr["NARRATION"].ToString());
            return _bCore;
        }

        public void deletebenifit(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from InterestBenefitsOnlyForTaxSetting' , ' and ID=''"+ id +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("InterestBenefitsOnlyForTaxSetting", "ID", Id);
        }

    }
}
