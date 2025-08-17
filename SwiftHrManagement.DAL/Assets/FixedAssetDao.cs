using System.Data;
using SwiftHrManagement.web.DAL;

namespace SwiftHrManagement.DAL.Assets
{
    public class FixedAssetDao : SwiftDao
    {
        public DbResult ApproveChanges(string user, string tblName, string tblId, string queueId)
        {
            string spName = "";
            if (tblName == "ASSET_INVENTORY_TEMP")
                spName = "procAssetBookingApproval";
            if (tblName == "ASSET_WRITEOFF_TEMP")
                spName = "proc_Asset_writeoff";
            if (tblName == "ASSET_SALES_HISTORY_TEMP")
                spName = "procApprovaAssetSalesRequest";
            if (tblName == "ASSET_CAPITALIZATION_TEMP")
                spName = "procApprovalAssetCapitalizeRequest";
            if (tblName == "ASSET_MAINTENANCE_TEMP")
                spName = "procApproveAssetMaintenanceRequest";
            if (tblName == "ASSET_TRANSFER_TEMP")
                spName = "procManageApprovedAssetTransfer";
            if (tblName == "DEPRECIATION_BOOKING_REQUEST")
                spName = "procApprovalDepreciationBooking";

            string sql = "Exec " + spName;
            sql += "  @flag = 'i'";
            sql += ", @user = " + FilterString(user);
            sql += ", @table_id = " + FilterString(tblId);
            sql += ", @queue_id = " + FilterString(queueId);
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }
        public DataRow GetApprovalLog(string user, string id, string tblName)
        {
            string sql = "EXEC proc_approvalLog";
            sql += " @flag = 'a'";
            sql += ", @user = " + FilterString(user);
            sql += ", @id = " + FilterString(id);
            sql += ", @tblName = " + FilterString(tblName);

            DataSet ds = ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

        public DataSet GetApprovalSummary(string user)
        {
            string sql = "EXEC proc_ApproveHoldedTXN ";
            sql += "  @flag = 's_txn_summary'";
            sql += ", @user = " + FilterString(user);
            return ExecuteDataset(sql);
        }
        public DbResult AssetBookingRequest(string user, string id, string branchId, string deptId, string assetId, string bookingDate,
            string purchaseDate, string assetQty, string purchaseValue, string accDep, string depStartDate, string insuranceId, string billId,
            string assetStatus, string warrentyExpDate, string holderId, string nextMainDate, string narration, string serialNo, string depPer,
            string receiveId, string isAmortised, string life, string remainLife, string empId, string forwardedEmpId, string oldAssetNo,
            string oldAssetCode, string modelNo, string brand)
        {
            var sql = "EXEC [procManageAssetBookingRequest] ";
            sql += "  @flag = " + (id == "0" || id == "" ? "'i'" : "'u'");
            sql += ", @row_id = " + FilterString(id);
            sql += ", @branch_id = " + FilterString(branchId);
            sql += ", @dept_id = " + FilterString(deptId);
            sql += ", @product_id = " + FilterString(assetId);
            sql += ", @booked_date = " + FilterString(bookingDate);
            sql += ", @purchase_date = " + FilterString(purchaseDate);
            sql += ", @qty = " + FilterString(assetQty);
            sql += ", @purchase_value = " + FilterString(purchaseValue);
            sql += ", @acc_depriciation = " + FilterString(accDep);
            sql += ", @dep_start_date = " + FilterString(depStartDate);
            sql += ", @ins_id = " + FilterString(insuranceId);
            sql += ", @bill_id = " + FilterString(billId);
            sql += ", @asset_status = " + FilterString(assetStatus);
            sql += ", @warr_expiry = " + FilterString(warrentyExpDate);
            sql += ", @asset_holder = " + FilterString(holderId);
            sql += ", @next_maintenance_date = " + FilterString(nextMainDate);
            sql += ", @narration = " + FilterString(narration);
            sql += ", @asset_serial = " + FilterString(serialNo);
            sql += ", @depre_pct = " + FilterString(depPer);
            sql += ", @received_id = " + FilterString(receiveId);
            sql += ", @is_amortised = " + FilterString(isAmortised);
            sql += ", @life_month = " + FilterString(life);
            sql += ", @remian_month = " + FilterString(remainLife);
            sql += ", @empId = " + FilterString(empId);
            sql += ", @forward_to = " + FilterString(forwardedEmpId);
            sql += ", @old_asset_no = " + FilterString(oldAssetNo);
            sql += ", @old_asset_code = " + FilterString(oldAssetCode);
            sql += ", @model = " + FilterString(modelNo);
            sql += ", @brand = " + FilterString(brand);
            sql += ", @user = " + FilterString(user);
            return ParseDbResult(sql);
        }
    }
}
