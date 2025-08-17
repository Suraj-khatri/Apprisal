using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web
{
    public class SessionStore : System.Web.UI.Page
    {
        private bool canViewProfile = false;

        public bool CanViewProfile
        {
            get { return canViewProfile; }
            set { canViewProfile = value; }
        }

        private String userId;

        public String UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private long tempEmpId;

        public long TempEmpId
        {
            get { return tempEmpId; }
            set { tempEmpId = value; }
        }
        private long tempInsurance_Id;

        public long TempInsurance_Id
        {
            get { return tempInsurance_Id; }
            set { tempInsurance_Id = value; }
        }
        private long tempContribution_Id;

        public long TempContribution_Id
        {
            get { return tempContribution_Id; }
            set { tempContribution_Id = value; }
        }
        private long type_Id;

        public long Type_Id
        {
            get { return type_Id; }
            set { type_Id = value; }
        }
        private long adminId;

        public long AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
        private long trainingProgramId;

        public long TrainingProgramId
        {
            get { return trainingProgramId; }
            set { trainingProgramId = value; }
        }
        private String rptQuery;

        public String RptQuery
        {
            get { return rptQuery; }
            set { rptQuery = value; }
        }
        private long emp_Id;

        public long Emp_Id
        {
            get { return emp_Id; }
            set { emp_Id = value; }
        }
        private int branch_Id;

        public int Branch_Id
        {
            get { return branch_Id; }
            set { branch_Id = value; }
        }
        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private String current_Fiscal_Year;

        public String Current_Fiscal_Year
        {
            get { return current_Fiscal_Year; }
            set { current_Fiscal_Year = value; }
        }
        private int position_hierarchy;

        public int Position_hierarchy
        {
            get { return position_hierarchy; }
            set { position_hierarchy = value; }
        }
        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        private string fiscal_nepali;

        public string Fiscal_nepali
        {
            get { return fiscal_nepali; }
            set { fiscal_nepali = value; }
        }
        private string fiscal_english;

        public string Fiscal_english
        {
            get { return fiscal_english; }
            set { fiscal_english = value; }
        }
        private string sessionid;

        public string Sessionid
        {
            get { return sessionid = Session.SessionID; }
            set { sessionid = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string userType;

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        public string BranchLevelAccess
        {
            get { return _branchLevelAccess; }
            set { _branchLevelAccess = value; }
        }

        private string _branchLevelAccess;

        private string menuType;

        public string MenuType
        {
            get { return menuType; }
            set { menuType = value; }
        }

        private string Message;

        public string message
        {
            get { return Message; }
            set { Message = value; }
        }
    }
}
