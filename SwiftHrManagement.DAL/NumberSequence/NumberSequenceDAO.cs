using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL;
namespace SwiftHrManagement.DAL.NumberSequence
{
    public class NumberSequenceDAO : BaseDAOInv
    {

        public NumberSequenceCore GetNumberSequennceDetails()
        {
            string sSql = "SELECT [ID],[SeqDateFormat],[NumSequence],[IsSequenceSep],[SequenceSep],[IsCompShortCode]"
                    + ",[IsCompSep],[CompSeparator],[IsBranchCode],[IsBranchSep],[BranchSeparator],[IsAssetCode]"
                    + ",[IsAssetCodeSep],[AssetSeparator],[IsDateCode] FROM [ASSET_NumberSequence]";

            DataTable dt = SelectByQuery(sSql);

            NumberSequenceCore _nsCore = null;

            if (dt != null)
                _nsCore = (NumberSequenceCore)this.MapObject(dt.Rows[0]);

            return _nsCore;
        }

        public override object MapObject(DataRow dr)
        {
            NumberSequenceCore nCore = new NumberSequenceCore();
            nCore.SeqDateFormat = dr["SeqDateFormat"].ToString();
            nCore.NumSequence = dr["NumSequence"].ToString();
            nCore.IsSequenceSep = dr["IsSequenceSep"].ToString();
            nCore.SequenceSep = dr["SequenceSep"].ToString();
            nCore.IsCompShortCode = dr["IsCompShortCode"].ToString();
            nCore.IsCompSep = dr["IsCompSep"].ToString();
            nCore.CompSeparator = dr["CompSeparator"].ToString();
            nCore.IsBranchCode = dr["IsBranchCode"].ToString();
            nCore.IsBranchSep = dr["IsBranchSep"].ToString();
            nCore.BranchSeparator = dr["BranchSeparator"].ToString();
            nCore.IsAssetCode = dr["IsAssetCode"].ToString();
            nCore.IsAssetCodeSep = dr["IsAssetCodeSep"].ToString();
            nCore.AssetSeparator = dr["AssetSeparator"].ToString();
            nCore.IsDateCode = dr["IsDateCode"].ToString();
            return nCore;
        }

        public override void Save(object obj)
        {
            NumberSequenceCore _nCore = (NumberSequenceCore)obj;
            String sSql = "Exec procManageNumberSequence '" + _nCore.SeqDateFormat + "','" + _nCore.NumSequence + "',"
                          + "'" + _nCore.IsSequenceSep + "','" + _nCore.SequenceSep + "','" + _nCore.IsCompShortCode + "',"
                          + "'" + _nCore.IsCompSep + "','" + _nCore.CompSeparator + "','" + _nCore.IsBranchCode + "',"
                          + "'" + _nCore.IsBranchSep + "','" + _nCore.BranchSeparator + "','" + _nCore.IsAssetCode + "',"
                          + "'" + _nCore.IsAssetCodeSep + "','" + _nCore.AssetSeparator + "','" + _nCore.IsDateCode + "','" + _nCore.ActEmpID + "',"
                          + "'" + _nCore.CreatedDate + "'".ToString();
            ExecuteUpdateProcedure(sSql);
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
