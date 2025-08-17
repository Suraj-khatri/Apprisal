using System.Data;
using System.Collections.Generic;
using System.Text;
using SwiftHrManagement.Core.Domain;


namespace SwiftHrManagement.DAL.PayableDAO
{
    public class PayableDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private DbService service;

        public PayableDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Payable(EMPLOYEE_ID, BENEFIT_ID, AMOUNT)"
            + " VALUES ('_EMPLOYEE_ID', _BENEFIT_ID, '_AMOUNT' )");
            this.updateQuery = new StringBuilder(@"UPDATE Payable SET  
                                                         AMOUNT = '_AMOUNT'
                                                        ,EFFECTIVE_FROM ='_effectiveFrom'
                                                        ,APPLY_FROM = '_applyFrom'
                                                        ,effective_upto = '_effectiveUpto' 
                                                    WHERE ID= ID_");
            this.service = new DbService();
        }
        public override void Save(object obj)
        {
            PayableCore _payable = (PayableCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", _payable.EmployeeId.ToString());
            this.insertQuery.Replace("_BENEFIT_ID", _payable.BenefitId.ToString());
            this.insertQuery.Replace("_AMOUNT", _payable.Amount.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            PayableCore _payable = (PayableCore)obj;
            this.updateQuery.Replace("ID_", _payable.Id.ToString());
            this.updateQuery.Replace("_AMOUNT", _payable.Amount.ToString());
            this.updateQuery.Replace("_effectiveFrom", _payable.EffectiveDate.ToString());
            this.updateQuery.Replace("_applyFrom", _payable.AppliedDate.ToString());
            this.updateQuery.Replace("_effectiveUpto", _payable.EffectiveUpto.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public DataTable Insert(string empId, string effFrom, string appFrom, string setId,string payablehead, string payableAmount, string user)
        {
            var sql = "EXEC ProcUpdateNewPayable";
            sql += "  @flag = 'i'";
            sql += " ,@empId =" + this.service.filterstring(empId);
            sql += " ,@effectiveFrom =" + this.service.filterstring(effFrom);
            sql += " ,@applyFrom =" + this.service.filterstring(appFrom);
            sql += " ,@set_Id =" + this.service.filterstring(setId);
            sql += " ,@payablehead ="+this.service.filterstring(payablehead);
            sql += " ,@payableamount =" + this.service.filterstring(payableAmount);
            sql += " ,@user =" + this.service.filterstring(user);

            return this.service.ReturnDataset(sql).Tables[0];
        }

        public List<PayableCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT p.ID, p.EMPLOYEE_ID 'EMPLOYEE_NAME', s.DETAIL_TITLE 'BENEFIT_NAME', p.AMOUNT FROM Payable p INNER JOIN (SELECT * FROM "
            + " StaticDataDetail WHERE TYPE_ID IN (36,37,38)) s ON s.ROWID=P.BENEFIT_ID WHERE P.EMPLOYEE_ID = "+ Id +""; 
            DataTable dt = SelectByQuery(sSql);
            List<PayableCore> _payable = new List<PayableCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PayableCore _pay = (PayableCore)this.MapObject(dr);
                    _payable.Add(_pay);
                }
            }
            return _payable;
        }
        public PayableCore FindById(long Id)
        {
            string sSql = (@"SELECT p.ID
                                ,p.EMPLOYEE_ID
                                ,p.BENEFIT_ID
                                ,p.AMOUNT
                                ,benefitType=sdd.detail_title
                                ,CONVERT(VARCHAR,p.APPLY_FROM,101) APPLY_FROM
                                ,CONVERT(VARCHAR,p.effective_upto,101) effective_upto
                                ,CONVERT(VARCHAR,p.EFFECTIVE_FROM,101) EFFECTIVE_FROM
                            FROM Payable p LEFT JOIN staticDataDetail sdd ON p.benefit_id=sdd.rowid 
                            WHERE p.ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            PayableCore _pay = null;
            if (dt != null)
                _pay = (PayableCore)this.MapForPayables(dt.Rows[0]);
            return _pay;
        }

        public object MapForPayables(System.Data.DataRow dr)
        {
            PayableCore _payables = new PayableCore();
            _payables.Id = long.Parse(dr["ID"].ToString());
            _payables.EmployeeId = dr["EMPLOYEE_ID"].ToString();
            _payables.BenefitId = dr["BENEFIT_ID"].ToString();
            _payables.Amount = double.Parse(dr["AMOUNT"].ToString());
            _payables.BenefitType = dr["benefitType"].ToString();
            _payables.EffectiveDate = dr["EFFECTIVE_FROM"].ToString();
            _payables.AppliedDate = dr["APPLY_FROM"].ToString();
            _payables.EffectiveUpto = dr["effective_upto"].ToString();
            return _payables;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            PayableCore _payables = new PayableCore();
            _payables.Id = long.Parse(dr["ID"].ToString());
            _payables.EmployeeId = dr["EMPLOYEE_NAME"].ToString();
            _payables.BenefitId = dr["BENEFIT_NAME"].ToString();
            _payables.Amount = double.Parse(dr["AMOUNT"].ToString());
            return _payables;
        }
        
        public DataTable FindPayableHeadAllById(string masterId,string postId,string gradeType)
        {

            var sql = @"EXEC [procManageGradeSetup] @flag='s',@salarySetId=" + filterstring(masterId) + ",@post_id=" + filterstring(postId) + ",@gradeType=" + filterstring(gradeType) + "";
			

            return ReturnDataset(sql).Tables[0];
        }
        public DataTable FindPayableHeadAllByIdSet(string masterId, string EmpId)
        {

            var sql = @"EXEC [procManageGradeSetup] @flag='set',@salarySetId=" + filterstring(masterId) + ",@post_id=" + filterstring(EmpId) + "";


            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindPayableHeadAllBySetId(long setId, long empId)
        {
            var sql = "SELECT p.BENEFIT_ID [PayableHeadId],p.ID salaryDetailId,sd.DETAIL_TITLE [Payable Head],p.AMOUNT [Payable Value] "
             + " FROM payable p INNER JOIN StaticDataDetail sd on p.BENEFIT_ID = sd.ROWID WHERE  EMPLOYEE_ID = " + empId + " AND set_id = " + setId;
            return ReturnDataset(sql).Tables[0];
        }

        public PayableCore FindFutureById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, BENEFIT_ID,AMOUNT FROM  FuturePayable WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            PayableCore _pay = null;
            if (dt != null)
                _pay = (PayableCore)this.MapForPayables(dt.Rows[0]);
            return _pay;
        }
       

        public void Deletepayable(long Id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Payable' , ' and ID=''"+ Id +"''', '"+ user +"'");
        }
        public void DeleteById(long Id, string user)
        {
            
        }
        public bool checkmultiple(long empid, long benifit)
        {
            return CheckStatement("select EMPLOYEE_ID from Payable where EMPLOYEE_ID = " + empid + " and BENEFIT_ID = " + benifit + "");
        }
        public bool checkmultipleFuture(long empid, long benifit, string fy_id)
        {
            return CheckStatement("select EMPLOYEE_ID from FuturePayable where EMPLOYEE_ID = " + empid + " and BENEFIT_ID = " + benifit + " and fy_id = '" + fy_id + "'");
        }
        public string CRUDLog(string Id)
        {
            return GetCurrentRecordInformation("Payable", "ID", Id);
        }
        public string CRUDFutLog(string Id)
        {
            return GetCurrentRecordInformation("FuturePayable", "ID", Id);
        }



    }
}