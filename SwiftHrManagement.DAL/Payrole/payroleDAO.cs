using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.DAL.Payrole
{
    public class payroleDAO : BaseDAOInv
    {
        public DataSet Executepayroll(String sSql)
        {
            return ReturnDataset(sSql);
        }

        public bool hasPayrollGenerated(string Month_Number, string Fiscal_Year_Id)
        {
            DataTable dt = ReturnDataset("[proc_calc_payrole] 'a','" + Fiscal_Year_Id + "','"+ Month_Number +"','i',null,'i'").Tables[0];

            return (dt==null?false:Convert.ToInt16(dt.Rows[0][0])>0);
        }
        public DataSet Generatepayroll(string Month_Number, string Fiscal_Year_Id)
        {
            return ReturnDataset("[proc_calc_payrole] 'a','" + Fiscal_Year_Id + "',"+ Month_Number +",'i',null,'i'");
        }
        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
