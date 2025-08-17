using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class LoginInformationCore
    {
        private long lempid;

        public long Lempid
        {
            get { return lempid; }
            set { lempid = value; }
        }
        private int ladminid;

        public int lAdminid
        {
            get { return ladminid; }
            set { ladminid = value; }
        }
        private string lusername;

        public string lUsername
        {
            get { return lusername; }
            set { lusername = value; }
        }
        private int lbranchid;

        public int Lbranchid
        {
            get { return lbranchid; }
            set { lbranchid = value; }
        }
        private int ldepartmentid;

        public int Ldepartmentid
        {
            get { return ldepartmentid; }
            set { ldepartmentid = value; }
        }
        private string lpositionid;

        public string lPositionid
        {
            get { return lpositionid; }
            set { lpositionid = value; }
        }
        private string lusertype;

        public string Lusertype
        {
            get { return lusertype; }
            set { lusertype = value; }
        }
        private string fiscalenglish;

        public string Fiscalenglish
        {
            get { return fiscalenglish; }
            set { fiscalenglish = value; }
        }
        private string fiscalnepali;

        public string Fiscalnepali
        {
            get { return fiscalnepali; }
            set { fiscalnepali = value; }
        }
        public string BranchLevelAccess
        {
            get { return _branchLevelAccess; }
            set { _branchLevelAccess = value; }
        }

        private string _branchLevelAccess;
    }
}
