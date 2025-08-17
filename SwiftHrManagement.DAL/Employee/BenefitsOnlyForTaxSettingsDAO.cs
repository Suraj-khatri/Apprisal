using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsOnlyForTaxSettingsDAO;

namespace SwiftHrManagement.DAL.BenefitsOnlyForTaxSettingsDAO
{
    public class BenefitsOnlyForTaxSettingsDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public BenefitsOnlyForTaxSettingsDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO BenefitsOnlyForTaxSetting(EMPLOYEE_ID, BENEFIT_FOR_TAX_ID, AMOUNT)"
            + " VALUES ('_EMPLOYEE_ID', _BENEFIT_FOR_TAX_ID, '_AMOUNT' )");
            this.updateQuery = new StringBuilder("UPDATE BenefitsOnlyForTaxSetting SET BENEFIT_FOR_TAX_ID = '_BENEFIT_FOR_TAX_ID', AMOUNT = '_AMOUNT' WHERE ID= ID_");
        }
        public override void Save(object obj)
        {
            BenefitsOnlyForTaxSettingsCore _benefits = (BenefitsOnlyForTaxSettingsCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", _benefits.EmployeeId.ToString());
            this.insertQuery.Replace("_BENEFIT_FOR_TAX_ID", _benefits.BenefitForTaxId.ToString());
            this.insertQuery.Replace("_AMOUNT", _benefits.Amount.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            BenefitsOnlyForTaxSettingsCore _benefits = (BenefitsOnlyForTaxSettingsCore)obj;
            
            this.updateQuery.Replace("ID_", _benefits.Id.ToString());

            this.updateQuery.Replace("_EMPLOYEE_ID", _benefits.EmployeeId.ToString());
            this.updateQuery.Replace("_BENEFIT_FOR_TAX_ID", _benefits.BenefitForTaxId.ToString());
            this.updateQuery.Replace("_AMOUNT", _benefits.Amount.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }
        public List<BenefitsOnlyForTaxSettingsCore> FindAllByEmpId(long Id)
        {
            string sSql = "select IB.EMPLOYEE_ID, IB.INTEREST_BENIFIT_TYPE, IB.FISCAL_YEAR, IB.ACTUAL_INT_PAID, IB.MARKET_INT_RATE, IB.TAXABLE_INT_AMT, "
            + " IB.NARRATION from InterestBenefitsOnlyForTaxSetting IB inner join (select * from StaticDataDetail where TYPE_ID=42) "
            + " s on s.ROWID = IB.INTEREST_BENIFIT_TYPE where IB.EMPLOYEE_ID = "+ Id +"";

            DataTable dt = SelectByQuery(sSql);
            List<BenefitsOnlyForTaxSettingsCore> _benefits = new List<BenefitsOnlyForTaxSettingsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BenefitsOnlyForTaxSettingsCore _ben = (BenefitsOnlyForTaxSettingsCore)this.MapObject(dr);
                    _benefits.Add(_ben);
                }
            }
            return _benefits;
        }
        public BenefitsOnlyForTaxSettingsCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, BENEFIT_FOR_TAX_ID, AMOUNT FROM  BenefitsOnlyForTaxSetting WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            BenefitsOnlyForTaxSettingsCore _ben = null;
            if (dt != null)
                _ben = (BenefitsOnlyForTaxSettingsCore)this.MapForBenefits(dt.Rows[0]);
            return _ben;
        }

        public object MapForBenefits(System.Data.DataRow dr)
        {
            BenefitsOnlyForTaxSettingsCore _benefits = new BenefitsOnlyForTaxSettingsCore();
            _benefits.Id = long.Parse(dr["ID"].ToString());
            _benefits.EmployeeId = dr["EMPLOYEE_ID"].ToString();
            _benefits.BenefitForTaxId = dr["BENEFIT_FOR_TAX_ID"].ToString();
            _benefits.Amount = double.Parse(dr["AMOUNT"].ToString());
            return _benefits;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            BenefitsOnlyForTaxSettingsCore _benefits = new BenefitsOnlyForTaxSettingsCore();
            _benefits.Id = long.Parse(dr["ID"].ToString());
            _benefits.EmployeeId = dr["EMPLOYEE_NAME"].ToString();
            _benefits.BenefitForTaxId = dr["NAME"].ToString();
            _benefits.Amount = double.Parse(dr["AMOUNT"].ToString());
            return _benefits;
        }
    }
}