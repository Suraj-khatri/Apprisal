using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
namespace SwiftHrManagement.DAL.StaticTable.FiscalMonthSetup
{
    public class FiscalMonthDAO : BaseDAOInv
    {
        private StringBuilder _selectQuery;
        public FiscalMonthDAO()
        {
            this._selectQuery = new StringBuilder("SELECT MONTH_NUMBER, FISCALYEAR, ENGFROM, ENGTO, NEPFROM, NEPTO FROM Fiscal_Month");
        }
        public DataSet FindFiscalsetup(String fiscalyear)
        {
            return ReturnDataset(" [proc_Fiscal_Month] 'a','"+ fiscalyear +"'");
        }
        public void Save(String month_number, String fiscalyear,String engFrom, String engTo, String nepFrom, String nepTo)
        {
            ExecuteQuery("[proc_Fiscal_Month] 'i','" + fiscalyear + "','" + month_number + "','" + engFrom + "','" + engTo + "','" + nepFrom + "','" + nepTo + "'");
        }
        public FiscalCore FindById(long month_number)
        {
            String sSql = this._selectQuery.Append(" where MONTH_NUMBER = "+ month_number +"").ToString();            
            DataTable dt = SelectByQuery(sSql);            
            FiscalCore _payroll = null;
            if (dt.Rows.Count != 0)
                _payroll = (FiscalCore)this.MapObject(dt.Rows[0]);
            return _payroll;
        }
        public override object MapObject(DataRow dr)
        {
            FiscalCore _payroll = new FiscalCore();
            _payroll.Month_number = long.Parse(dr["MONTH_NUMBER"].ToString());
            _payroll.Engfrom = dr["ENGFROM"].ToString();
            _payroll.Engto = (dr["ENGTO"].ToString());
            _payroll.Nepfrom = dr["NEPFROM"].ToString();
            _payroll.Nepto = (dr["NEPTO"].ToString());
            _payroll.Fiscal_year = dr["FISCALYEAR"].ToString();
            return _payroll;
        }
        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }        
    }
}
