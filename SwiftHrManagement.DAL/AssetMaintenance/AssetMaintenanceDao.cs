using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.AssetMaintenance
{
    public class AssetMaintenanceDao : BaseDAO
    {
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

        public DbResult ManageAssetMaintenance( Core.AssetMaintenance.AssetMaintenance asm)
        {
            var sql = "Exec Proc_AssetMaintenance @flag=" + (asm.RowId == 0 ? "'i'" : "'u'") ;
            sql += ",@Asset_id = " + filterstring(asm.AssetId.ToString());
            sql += ",@RequestingBranch = " + filterstring(asm.RequestingBranch.ToString());
            sql += ",@RequestingDepartment = " + filterstring(asm.RequestingDepartment.ToString());
            sql += ",@RequestingUser = " + filterstring(asm.RequestingUser.ToString());
            sql += ",@ForwardedToBranch = " + filterstring(asm.ForwardedToBranch.ToString()) ;
            sql += ",@ForwardedToDepartment = " + filterstring(asm.ForwardedToDepartment.ToString()) ;
            sql += ",@ForwardedToUser = " + filterstring(asm.ForwardedToUser.ToString()) ;

            sql += ",@ProcessStatus = " + filterstring(asm.ProcessStatus);
            sql += ",@RepairCost = " + filterstring(asm.RepairAmount.ToString());
            sql += ",@Narration = " + filterstring(asm.Narration);
            sql += ",@ApproxReturnDate = " + filterstring(asm.EstmDate);
            sql += ",@Vendor = " + filterstring(asm.Vendor.ToString());
            sql += ",@NewVendorName = " + filterstring(asm.NewVendorName);

            sql += ",@User = " + filterstring(asm.User);
            sql += ",@ReceivedDate = " + filterstring(asm.ReceivedDate);
            sql += ",@id = " + filterstring(asm.RowId.ToString());
            return  ParseDbResult(ExecuteStoreProcedure(sql));
            
        }

        public DataSet getAssetDetails(long id)
        {
            var sql = "Exec Proc_AssetMaintenance @flag='d'";
            sql += ",@id =" + filterstring(id.ToString());
            return ReturnDataset(sql);
        }



    }
}
