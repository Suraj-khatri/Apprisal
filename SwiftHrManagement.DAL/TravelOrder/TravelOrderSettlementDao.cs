using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.TravelOrder
{
    public class TravelOrderSettlementDao : BaseDAOInv
    {
        public string OnAddAllowance(string allowanceType, string days, string total, string sessionId)
        {
            var sql = "[proc_travelOrder]";
            sql += " @flag = 'a'";
            sql += ", @allowanceType = " + filterstring(allowanceType);
            sql += ", @days=" + filterstring(days);
            sql += ", @total=" + filterstring(total);
            sql += ", @sessionId=" + filterstring(sessionId);
            return GetSingleresult(sql);

        }

        public DataTable FindTravelOrderInfoById(string travelId)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 's'";
            sql += ", @travelOrderId=" + filterstring(travelId);
            return ExecuteDataset(sql).Tables[0];

        }
        public DataTable FindTravelAllowanceById(string travelId)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'st'";
            sql += ", @traOrdAllowanceId=" + filterstring(travelId);
            return ExecuteDataset(sql).Tables[0];

        }
      

        public DataTable FindAllowanceById(string traveAlllId)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'sa'";
            sql += ", @traOrdAllowanceId=" + filterstring(traveAlllId);
            return ExecuteDataset(sql).Tables[0]; 

        }

        public DataTable EditAllownceById(string allowanceSettleId)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'sl'";
            sql += ", @traOrdAllowanceId=" + filterstring(allowanceSettleId);
            return ExecuteDataset(sql).Tables[0];

        }
        public string OnAllowanceAdd(string allowanceType,string perDays,string total,string sessionID,string days,string travelOrderId,string currency)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'ia'";
            sql += ", @allowanceType=" + filterstring(allowanceType);
            sql += ", @perDays=" + filterstring(perDays);
            sql += ", @total=" + filterstring(total);
            sql += ", @sessionId=" + filterstring(sessionID);
            sql += ", @days=" + filterstring(days);
            sql += ", @currency=" + filterstring(currency);
            sql += ", @travelOrderId=" + filterstring(travelOrderId);

            return GetSingleresult(sql);
        			   
        }

        public string EditAllowanceById(string allowanceType, string perDays, string total, string sessionID, string days, string travelOrderAllId)
        {
            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'se'";
            sql += ", @allowanceType=" + filterstring(allowanceType);
            sql += ", @perDays=" + filterstring(perDays);
            sql += ", @total=" + filterstring(total);
            sql += ", @days=" + filterstring(days);
            sql += ", @traOrdAllowanceId=" + filterstring(travelOrderAllId);

            return GetSingleresult(sql);

        }

        public DataTable FindTravelSettlementById(string sessionId, string travelOrderId)
        {

            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'ss'";
            sql += ", @sessionId=" + filterstring(sessionId);
            sql += ", @travelOrderId=" + filterstring(travelOrderId);
            
            return ExecuteDataset(sql).Tables[0];

        }
        public string OnDelete(string traveAlllId)
        {

            var sql = "Exec [proc_travelOrderSettlement]";
            sql += " @flag = 'd'";
            sql += ", @traOrdAllowanceId=" + filterstring(traveAlllId);
            return GetSingleresult(sql);
        }

        public string OnFinalSave(string travelOrderId,string reqBY,string settleFromDate,string settleToDate,string recommDate,string remarks,string sessionId,string positionId)
        {

                var sql = "Exec [proc_travelOrderSettlement]";
                sql += " @flag = 'fs'";
                sql += ", @travelOrderId=" + filterstring(travelOrderId);
                sql += ", @reqBy=" + filterstring(reqBY);
                sql += ", @settlementfromDate=" + filterstring(settleFromDate);
                sql += ", @settlementtoDate=" + filterstring(settleToDate);
                sql += ", @recommendedBy=" + filterstring(recommDate);
                sql += ", @requestRemarks=" + filterstring(remarks);
                sql += ", @sessionId=" + filterstring(sessionId);
                sql += ", @positionId=" + filterstring(positionId);
                return GetSingleresult(sql);

         
        }
       



        public override object MapObject(System.Data.DataRow dr)
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
