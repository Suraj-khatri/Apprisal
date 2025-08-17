using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.DomainInv
{
    public class NumberSequenceCore : BaseDomain
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string seqdateFormat;

        public string SeqDateFormat
        {
            get { return seqdateFormat; }
            set { seqdateFormat = value; }
        }
        private string numsequence;

        public string NumSequence
        {
            get { return numsequence; }
            set { numsequence = value; }
        }
        private string isSequenceSep;

        public string IsSequenceSep
        {
            get { return isSequenceSep; }
            set { isSequenceSep = value; }
        }
        private string sequenceSep;

        public string SequenceSep
        {
            get { return sequenceSep; }
            set { sequenceSep = value; }
        }
        private string isCompShortCode;

        public string IsCompShortCode
        {
            get { return isCompShortCode; }
            set { isCompShortCode = value; }
        }
        private string isCompSep;

        public string IsCompSep
        {
            get { return isCompSep; }
            set { isCompSep = value; }
        }
        private string compSeparator;

        public string CompSeparator
        {
            get { return compSeparator; }
            set { compSeparator = value; }
        }
        private string isBranchCode;

        public string IsBranchCode
        {
            get { return isBranchCode; }
            set { isBranchCode = value; }
        }
        private string isBranchSep;

        public string IsBranchSep
        {
            get { return isBranchSep; }
            set { isBranchSep = value; }
        }
        private string branchSeparator;

        public string BranchSeparator
        {
            get { return branchSeparator; }
            set { branchSeparator = value; }
        }
        private string isAssetCode;

        public string IsAssetCode
        {
            get { return isAssetCode; }
            set { isAssetCode = value; }
        }
        private string isAssetCodeSep;

        public string IsAssetCodeSep
        {
            get { return isAssetCodeSep; }
            set { isAssetCodeSep = value; }
        }
        private string assetSeparator;

        public string AssetSeparator
        {
            get { return assetSeparator; }
            set { assetSeparator = value; }
        }

        private string isDateCode;

        public string IsDateCode
        {
            get { return isDateCode; }
            set { isDateCode = value; }
        }

        private int actEmpID;

        public int ActEmpID
        {
            get { return actEmpID; }
            set { actEmpID = value; }
        }

    }
}
