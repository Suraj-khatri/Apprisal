using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
namespace SwiftHrManagement.DAL.EmployeePromotion
{
    public class promotionDao : BaseDAO
    {
        public DbResult Update(string empid, string promotion_date, string position_id, string OLD_POSITION, string BRANCH_ID,
            string DETP_ID, string user, string rowid, string applyOn, string salaryset, string grade, string basicSalary, string sessionId)
        {
            string sql = "EXEC procEmployeePromotion";
            sql += " @flag = " + (rowid == "0" || rowid == "" ? "'i'" : "'u'");
            sql += ", @user = " + FilterString(user);
            sql += ", @id=" + FilterString(rowid);
            sql += ", @emp_id=" + FilterString(empid);
            sql += ", @promote_Post=" + FilterString(position_id);
            sql += ", @promotion_date=" + FilterString(promotion_date);
            sql += ", @ApplyOn=" + FilterString(applyOn);
            sql += ", @salary_setID=" + FilterString(salaryset);
            sql += ", @salaryBasic=" + FilterString(basicSalary);
            sql += ", @grade_Id=" + FilterString(grade);
            sql += ", @session_id=" + FilterString(sessionId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult UpdateSupervisor(string empId, string newSupType, string newSup, string currSupType, string currSup,
            string rowId, string sessionId,string user)
        {

            string sql = "EXEC procEmployeePromotion";
            sql += " @flag = " + (rowId == "0" || rowId == "" ? "'a'" : "'au'");
            sql += ", @user = " + FilterString(user);
            sql += ", @id=" + FilterString(rowId);
            sql += ", @emp_id=" + FilterString(empId);
            sql += ", @New_Supervisor_type=" + FilterString(newSupType);
            sql += ", @Current_Supervisor_Type=" + FilterString(currSupType);
            sql += ", @New_Supervisor=" + FilterString(newSup);
            sql += ", @Current_Supervisor=" + FilterString(currSup);
            sql += ", @session_id=" + FilterString(sessionId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public DbResult DeleteSupervisor(string rowId, string user)
        {
            string sql = "EXEC procEmployeePromotion";
            sql += "  @flag = 'DS'";
            sql += ", @user = " + FilterString(user);
            sql += ", @id=" + FilterString(rowId);

            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public promotionDao()
        {

        }
        public void ManagePromotion(string flag, string empid, string promotion_date, string position_id, string OLD_POSITION, string BRANCH_ID, 
            string DETP_ID, string user, long rowid, string promotion_type, string salaryset,string grade,string salarySetMasterId,string sessionId)
        {
            ExecuteQuery("exec [procEmployeePromotion] @flag='" + flag + "',@user=" + filterstring(user) + ","
            + " @id=" + filterstring(rowid.ToString()) + ",@emp_id=" + filterstring(empid) + ",@promote_Post=" + filterstring(position_id) + ","
            + " @promotion_date=" + filterstring(promotion_date) + ",@promotion_type=" + filterstring(promotion_type) + ","
            + " @salary_setID=" + salarySetMasterId + ",@session_id="+sessionId+",@grade_Id=" + grade);
        }
        public PromotionCore FindallById(long Id)
        {
            string sSql = @"SELECT ROWID, EMP_ID,POSITION_ID,convert(varchar,PROMOTION_DATE,101) as PROMOTION_DATE,OLD_POSITION,BRANCH_ID,DETP_ID,
            Promotion_Type,salary_set,grade,salarySetMasterId,convert(varchar,ApplyOn,101) ApplyOn,SUB_DEPT FROM Promotion where rowid=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            PromotionCore _promotionCore = null;
            if (dt != null)
                _promotionCore = (PromotionCore)this.MapObject(dt.Rows[0]);
            return _promotionCore;
        }

        public PromotionCore FindEmpPosition(long Id)
        {
            string sSql = "SELECT POSITION_ID FROM Employee WHERE EMPLOYEE_ID = " + Id + "";
            DataTable dt = SelectByQuery(sSql);
            PromotionCore _empposition = null;
            if (dt != null)
                _empposition = (PromotionCore)this.MapObjectforPosition(dt.Rows[0]);
            return _empposition;
        }

        public object MapObjectforPosition(System.Data.DataRow dr)
        {
            PromotionCore _promotionCore = new PromotionCore();
            _promotionCore.Position_id = int.Parse(dr["POSITION_ID"].ToString());
            return _promotionCore;
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            PromotionCore _promotionCore = new PromotionCore();
            _promotionCore.Emp_id = int.Parse(dr["EMP_ID"].ToString());
            _promotionCore.Id = int.Parse(dr["ROWID"].ToString());
            _promotionCore.Position_id = int.Parse(dr["POSITION_ID"].ToString());
            _promotionCore.Promotion_date = dr["PROMOTION_DATE"].ToString();
            _promotionCore.Oldposition = dr["OLD_POSITION"].ToString();
            _promotionCore.BranchName = dr["BRANCH_ID"].ToString();
            _promotionCore.Deptname = dr["DETP_ID"].ToString();
            _promotionCore.Promotion_Type = dr["Promotion_Type"].ToString();
            _promotionCore.ApplyOn = dr["applyOn"].ToString();
            _promotionCore.SalarySet = dr["salary_set"].ToString();
            _promotionCore.Grade = dr["grade"].ToString();
            _promotionCore.SalarySetMaserId = dr["salarySetMasterId"].ToString();
            _promotionCore.SubDeptname = dr["SUB_DEPT"].ToString();
           
            return _promotionCore;
        }
        public void deleteposition(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from promotion' , ' and ROWID=''"+ id +"''', '"+ user +"'");
        }
    }
}
