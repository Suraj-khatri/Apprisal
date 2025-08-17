using System;
using System.Data;

namespace SwiftHrManagement.DAL.CEA
{
    public class CEADao : BaseDAOInv
    {
        private DbService service;

        public CEADao()
        {
            this.service = new DbService();
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public DataTable OnSave(string flag, string id, string empId, string childId, string billDate, string billAmt, string fromFy, string fromMonth, string toFy, 
                            string toMonth,string desc,string filedesc,string type, string user)
        {
            var sql = "Exec [proc_CEA]";
            sql += "  @flag =  " + filterstring(flag);
            sql += ", @id = " + filterstring(id);
            sql += ", @empid=" + filterstring(empId);
            sql += ", @childId=" + filterstring(childId);
            sql += ", @billdate=" + filterstring(billDate);
            sql += ", @billamount=" + filterstring(billAmt);
            sql += ", @frm_FY=" + filterstring(fromFy);
            sql += ", @frm_month=" + filterstring(fromMonth);
            sql += ", @to_FY=" + filterstring(toFy);
            sql += ", @to_month=" + filterstring(toMonth);            
            sql += ", @desc ="+filterstring(desc);
            sql += ", @file_desc=" + filterstring(filedesc);
            sql += ", @file_type=" + filterstring(type);
            sql += ", @user=" + filterstring(user);

            return this.service.ReturnDataset(sql).Tables[0];
        }

        public string OnDelete(string id)
        {
            var sql = "Exec [proc_CEA]";
            sql += " @flag = 'd' ";
            sql += ", @id = " + filterstring(id);

            return GetSingleresult(sql);
        }

        public string OnApprove(string id,string amount)
        {
            var sql = "Exec [proc_CEA]";
            sql += " @flag = 'a' ";
            sql += ", @billamount = " + filterstring(amount);
            sql += ", @id = " + filterstring(id);

            return GetSingleresult(sql);
        }

        public string OnReject(string id)
        {
            var sql = "Exec [proc_CEA]";
            sql += " @flag = 'r' ";
            sql += ", @id = " + filterstring(id);

            return GetSingleresult(sql);
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
