using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.Payrole
{
    public class ManualAddDedDAO : BaseDAOInv
    {     
        //public override object MapObject(System.Data.DataRow dr)
        //{
        //    OfficialCalender _cal = new OfficialCalender();
        //    _cal.Leave_Name = dr["LEAVE_NAME"].ToString();
        //    _cal.Id = long.Parse(dr["ID"].ToString());
        //    _cal.Leave_Date = (dr["LEAVE_DATE"].ToString());
        //    _cal.Leave_Type = dr["LEAVE_TYPE"].ToString();
        //    _cal.Leave_Details = dr["LEAVE_DETAILS"].ToString();
        //    return _cal;
        //}
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
