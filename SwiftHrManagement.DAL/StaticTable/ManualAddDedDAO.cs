using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.StaticTable
{
    public class ManualAddDedDAO : BaseDAOInv
    {   
        public void Save(String flag, int malualentry_id, String name, String enable)
        {
            String sSql = "exec proc_ManualBenifitDeduction_Head '"+ flag +"',"+ malualentry_id +",'"+ name +"','"+ enable +"'";
            ExecuteQuery(sSql);
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public DataTable GetBenDedHead()
        {
            String sSql = "exec proc_ManualBenifitDeduction_Head 'a'";
            return SelectByQuery(sSql);
        }
        public ManualAddDeductionCore FindallbyId(long Id)
        {
            String sSql = "SELECT MANUALENTRYID, NAME, ADDDEDUCT, ENABLE FROM ManualBenifitDeduction_Head WHERE MANUALENTRYID = " + Id + "";
            DataTable dt = SelectByQuery(sSql);
            ManualAddDeductionCore _manual = null;
            if (dt != null)
                _manual = (ManualAddDeductionCore)this.MapObject(dt.Rows[0]);
            return _manual;
        }
        public override object MapObject(DataRow dr)
        {
            ManualAddDeductionCore _manul = new ManualAddDeductionCore();
            _manul.Manual_entry_id = long.Parse(dr["MANUALENTRYID"].ToString());
            _manul.Name = dr["NAME"].ToString();
            _manul.AddDeduct = dr["ADDDEDUCT"].ToString();
            _manul.Enable = Boolean.Parse(dr["ENABLE"].ToString());
            return _manul;
        }
    }
}
