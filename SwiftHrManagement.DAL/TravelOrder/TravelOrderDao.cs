using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.TravelOrder
{
    public class TravelOrderDao : BaseDAOInv
    {
        public string OnAddAllowance(string allowanceType,string perdays,string days,string trvelOrderId,string sessionId,string currency,string rateId)
        {
            var sql = "Exec [proc_travelOrder]";
            sql += " @flag = 'a'";
            sql += ", @allowanceType = " + filterstring(allowanceType);
            sql += ", @days=" + filterstring(days);
            sql += ", @perDays=" + filterstring(perdays);
            sql += ", @sessionId=" + filterstring(sessionId);
            sql += ", @travelOrderId=" + filterstring(trvelOrderId);
            sql += ", @currency=" + filterstring(currency);
            sql += ", @travelOrderRateId=" + filterstring(rateId);
            
            
            return GetSingleresult(sql);
          
        }

        public DataTable DisplayAllowanceInfo(string sessionId)
        {
            var sql = "[proc_travelOrder]";
            sql += " @flag = 'sa'";
            sql += ", @sessionId=" + filterstring(sessionId);
            return ExecuteDataset(sql).Tables[0];

        }

        public DataTable OnSaveCurrency(string currency, string amount, string sessionId, string user)
        {
            var sql = "Exec Proc_Travel";
            sql += "  @flag='ic'";
            sql += ", @currency=" + filterstring(currency);
            sql += ", @amount=" + filterstring(amount);
            sql += ", @session_id=" + filterstring(sessionId);
            sql += ", @user=" + filterstring(user);

            return ExecuteDataset(sql).Tables[0];
        }

        public string OnSave(string branchId,string deptId,string reqBy,string travelorderReqDate
                        ,string placeOfVisit,string purposeOfVisit,string traspotation,string fromDate,string toDate
                        ,string recommendedBy,string sessionId,string requestRemarks,string advance,string region)
        {
            var sql = "Exec [proc_travelOrder]";
            sql += "  @flag = 'i'";
            sql += ", @branch = " + filterstring(branchId);
            sql += ", @dept = " + filterstring(deptId);
            sql += ", @reqBy=" + filterstring(reqBy);
            sql += ", @travelorderReqDate=" + filterstring(travelorderReqDate);
            sql += ", @placeOfVisit=" + filterstring(placeOfVisit);
            sql += ", @purposeOfVisit=" + filterstring(purposeOfVisit);
            sql += ", @transportation =" + filterstring(traspotation);
            sql += ", @fromDate=" + filterstring(fromDate);
            sql += ", @toDate=" + filterstring(toDate);
            sql += ", @recommendedBy=" + filterstring(recommendedBy);
            sql += ", @sessionId=" + filterstring(sessionId);
            sql += ", @requestRemarks=" + filterstring(requestRemarks);
            sql += ", @advance=" + filterstring(advance);
            sql += ", @region=" + filterstring(region);
            return GetSingleresult(sql);
        }

        public DataTable FindTadaCurrency(string Id)
        {
            var sql = @"SELECT
	                        ID,dbo.GetDetailTitle(Currency) Currency, Amount
                        FROM tada_Currency WHERE Session_Id = " + filterstring(Id);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindAuthorisedPerson(string Id)
        {
            var sql = @"SELECT
	                        ID,dbo.GetEmployeeFullNameOfId(Authorised_By) [Authorised By]
                        FROM TADA_Authorization WHERE Session_Id = " + filterstring(Id);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindCurrencyAndAmt(String Id)
        {
            var sql = @"SELECT
	                        ID,dbo.GetDetailTitle(Currency) Currency, Amount
                        FROM tada_Currency WHERE tada_id = " + Id;
            return ReturnDataset(sql).Tables[0];
        }

        public string OnDelete(string travelOrderId)
        {
            var sql = "Exec [proc_travelOrder]";
            sql += "  @flag = 'd'";
            sql += ", @traOrdAllowanceId = " + filterstring(travelOrderId);
            return GetSingleresult(sql);
        }
        public string FindHrByDeptId(string deptId)
        {
            var sql = "SELECT DEPARTMENT_SHORT_NAME FROM Departments where DEPARTMENT_ID = "+deptId;
            return GetSingleresult(sql);

        }
        public DataTable FindRateAllownce(string allowanceType,string positionId,string place)
        {
            var sql = "SELECT  travelRateId,dbo.ShowDecimal(rate)rate,s.DETAIL_TITLE  currency FROM travelOrderRate  tr inner join StaticDataDetail s "
                    +" on s.ROWID = tr.currency WHERE place=" + place + "  AND position = " + positionId + " AND allowanceType =" + allowanceType;
            return ExecuteDataset(sql).Tables[0];

        }

        public string GetPositionId(string empId)
        {
            var sql = "select POSITION_ID from Employee where EMPLOYEE_ID = " + empId;
            return GetSingleresult(sql);
        }

        public string FindEmpByEmpId(string empid)
        {
            var sql = "select FIRST_NAME +' '+ MIDDLE_NAME +' '+LAST_NAME +' |'+CAST(EMPLOYEE_ID as varchar) empName from Employee where EMPLOYEE_ID = " + empid;
            return GetSingleresult(sql);
        }

        public DataTable ShowAllowanceById(string travalOId)
        {
            var sql = "EXEC [proc_travelOrder] @flag='al',@traOrdAllowanceId="+travalOId;
            return ExecuteDataset(sql).Tables[0];

        }
        public DataTable FindAllowanceById(string allowanceId)
        {
            var sql = "SELECT allowanceType, dbo.ShowDecimal(perdays)perdays,days,dbo.ShowDecimal(total)total FROM travelOrderAllowance WHERE traOrdAllowanceId = " + filterstring(allowanceId);
            return ExecuteDataset(sql).Tables[0];
        

        }

        public string OnAdd(string travelOId,string allowanceType,string perDays,string days,string total)
        {
            var sql = "[proc_travelOrder]";
            sql += " @flag = 'ae'";
            sql += ", @allowanceType = " + filterstring(allowanceType);
            sql += ", @days=" + filterstring(days);
            sql += ", @perDays=" + filterstring(perDays);
            sql += ", @total=" + filterstring(total);
            sql += ", @traOrdAllowanceId=" + filterstring(travelOId);
            return GetSingleresult(sql);
        }


        public override object MapObject(DataRow dr)
        {
            throw new NotImplementedException();
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
