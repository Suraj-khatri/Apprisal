using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.DAL.WorkFlowManagement
{
    public class WFMemberDAO : BaseDAO
    {
        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            WFMemberCore _wfMemCore = (WFMemberCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowMember '" + _wfMemCore.MemberID + "','" + _wfMemCore.CategoryID + "','" + _wfMemCore.EmployeeID + "','" + "I" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }


        public void Delete(object obj)
        {
            WFMemberCore _wfMemCore = (WFMemberCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowMember '" + _wfMemCore.MemberID + "','" + _wfMemCore.CategoryID + "','" + _wfMemCore.EmployeeID + "','" + "D" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }


        public WFMemberCore GetMemberDetails(long Id)
        {

           //string sSql = "SELECT WF_CATNAME,WF_CATDETAILS FROM WF_CATEGORY WHERE WF_CATEGORYID = " + Id + "";
            string sSql = "SELECT M.WF_MEMBERID,M.WF_CATEGORYID,C.WF_CATNAME,M.EMPLOYEE_ID,E.BRANCH_ID,E.DEPARTMENT_ID FROM WF_MEMBER M INNER JOIN"
                            +" WF_CATEGORY C ON C.WF_CATEGORYID = M.WF_CATEGORYID INNER JOIN Employee E ON E.EMPLOYEE_ID=M.Employee_ID"
                            + " WHERE M.WF_MEMBERID = " + Id + "";

            DataTable dt = SelectByQuery(sSql);
            
            

            WFMemberCore _wFMem = null;

            if (dt != null)
                _wFMem = (WFMemberCore)this.MapMemDetails(dt.Rows[0]);

            return _wFMem;
        }

        public object MapMemDetails(System.Data.DataRow dr)
        {
            WFMemberCore _wfMemCore = new WFMemberCore();
            _wfMemCore.EmployeeID = long.Parse(dr["EMPLOYEE_ID"].ToString());
            _wfMemCore.CategoryID = long.Parse(dr["WF_CATEGORYID"].ToString());
            _wfMemCore.MemberID = long.Parse(dr["WF_MEMBERID"].ToString());
            _wfMemCore.CatName = dr["WF_CATNAME"].ToString();
            return _wfMemCore;
        }


        public override void Update(object obj)
        {
            WFMemberCore _wfMemCore = (WFMemberCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowMember '" + _wfMemCore.MemberID + "','" + _wfMemCore.CategoryID + "','" + _wfMemCore.EmployeeID + "','" + "U" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        
    }
}
