using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL;
using System.Data;

namespace SwiftHrManagement.DAL.User
{
    public class UserDaoInv : BaseDAOInv
    {
        private StringBuilder _insertquery;
        private StringBuilder _updatequery;

        public UserDaoInv()
        {
            this._insertquery = new StringBuilder("INSERT INTO ADMINS (UserName,UserPassword,Name,status) VALUES "
                + "('Usr', dbo.encryptDb('Pwd'),'Name_','status_')");

            this._updatequery = new StringBuilder("UPDATE ADMINS SET UserName='Usr', UserPassword=dbo.encryptDb('Pwd'),Name='Name_',"
                + " status= 'status_' WHERE ADMINID='ADMINID_' ");          
        }

        public override  void Save(object obj)
        {
            SystemUser usr = (SystemUser)obj;
            this._insertquery.Replace("Name_", usr.Name);
            this._insertquery.Replace("Usr", usr.UserName);
            this._insertquery.Replace("Pwd", usr.UserPassword);
            this._insertquery.Replace("status_", usr.Status);
            ExecuteQuery(this._insertquery.ToString());
        }
        public override  void Update(object obj)
        {
            SystemUser usr = (SystemUser)obj;
            this._updatequery.Replace("ADMINID_", usr.Admin_Id.ToString());
            this._updatequery.Replace("Name_", usr.Name);
            this._updatequery.Replace("Usr", usr.UserName);
            this._updatequery.Replace("Pwd", usr.UserPassword);
            this._updatequery.Replace("status_", usr.Status);
            ExecuteQuery(this._updatequery.ToString());
        }
        public void ChangePassword(string newPassword, long id)
        {
            string sSql = "update Admins set UserPassword=" + filterstring(newPassword) + " where AdminID=" + filterstring(id.ToString()) + "";
            ExecuteQuery(sSql);
        }

        public void InsertAssignRole(String roleId, string userId)
        {
            string sSql = "Exec procAssignRoles 'u', " + filterstring(userId.ToString()) + "," + filterstring(roleId);
            ExecuteQuery(sSql);
        }
        public LoginInformationCore Getsessioninformation(String Admin_Id, String UserName, String UserPassword)
        {
            string sSql = ("Exec ProcUserLogin " + filterstring(UserName) + "," + filterstring(UserPassword) + "," + filterstring(Admin_Id) + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LoginInformationCore _user = null;
            if (dt != null)
                if (dt.Rows.Count == 0)
                    return _user;
            _user = (LoginInformationCore)this.MapforLoginsession(dt.Rows[0]);
            return _user;
        }
        public object MapforLoginsession(DataRow dr)
        {
            LoginInformationCore usr = new LoginInformationCore();
            usr.lAdminid = int.Parse(dr["AdminID"].ToString());
            usr.lUsername = dr["UserName"].ToString();
            usr.lUsername = dr["UserName"].ToString();
            usr.Lempid = long.Parse(dr["EMPLOYEE_ID"].ToString());
            usr.Lusertype = dr["user_type"].ToString();
            usr.lPositionid = dr["POSITION_ID"].ToString();
            usr.Lbranchid = int.Parse(dr["BRANCH_ID"].ToString());
            usr.Ldepartmentid = int.Parse(dr["DEPARTMENT_ID"].ToString());
            usr.Fiscalenglish = dr["Fiscal_english"].ToString();
            usr.Fiscalnepali = dr["Fiscal_nepali"].ToString();
            return usr;
        }
        public List<SystemUser> FindUserByDepartment()
        {
            string sSql = "select Name as UserName,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName from Admins A join"
            + " Employee E on E.EMPLOYEE_ID=A.Name ";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindUserByDepartment(int Dept_Id)
        {
            string sSql = "select Name as UserName,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName from Admins A join"
            + " Employee E on E.EMPLOYEE_ID=A.Name where E.DEPARTMENT_ID = " + Dept_Id + "";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindAll(string strSQL)
        {
            string sSql = "SELECT	AdminID, UserName,dbo.decryptDb(USERPASSWORD) as UserPassword,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME as Name,"
                            + " CASE WHEN status = 'N' THEN 'In Active' WHEN status = 'Y' THEN 'Active' END AS status"
                            + " FROM ADMINS A Left JOIN Employee E ON cast(E.EMPLOYEE_ID as varchar)=A.Name where 1=1 " + strSQL;

            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObject(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindAllByAddress(String Address)
        {
            string sSql = "SELECT AdminID, USERNAME, dbo.decryptDb(UserPassword) as UserPassword,Name,CASE WHEN status = 'N' THEN 'In Active' WHEN status = 'Y' THEN 'Active' END AS status "
            + " FROM ADMINS WHERE Address='" + Address + "'";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObject(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public SystemUser FindUserById(long Id)
        {
            string sSql = ("SELECT A.AdminID,E.EMPLOYEE_ID  as EmpId,B.BRANCH_NAME AS BRANCH_ID,D.DEPARTMENT_NAME AS DEPARTMENT_ID,A.USERNAME,dbo.decryptDb(UserPassword) as UserPassword,"
            + " E.EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS Name,CASE WHEN status = 'N' THEN "
            + " 'In Active' WHEN status = 'Y' THEN 'Active' END AS status from admins A INNER JOIN Employee E ON E.EMPLOYEE_ID=A.Name INNER JOIN"
            + " Branches B ON B.BRANCH_ID=E.BRANCH_ID INNER JOIN Departments D ON D.DEPARTMENT_ID=E.DEPARTMENT_ID where AdminId =" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapObjectByID(dt.Rows[0]);
            return _user;
        }
        public SystemUser FindUserPosition(String user)
        {
            string sSql = ("select Post from Admins where UserName='" + user + "'").ToString();
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapObjectUserPosition(dt.Rows[0]);
            return _user;
        }
        public object MapObjectUserPosition(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Post = dr["Post"].ToString();
            return usr;
        }
        public SystemUser FindUserPassword(long Id)
        {
            string sSql = ("SELECT dbo.decryptDb(UserPassword) as UserPassword from admins"
            + " where AdminId =" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapObjectUserPassword(dt.Rows[0]);
            return _user;
        }
        public object MapObjectUserPassword(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.UserPassword = dr["UserPassword"].ToString();
            return usr;
        }
        public SystemUser FindByName(String Name)
        {
            string sSql = "SELECT USERNAME FROM ADMINS WHERE NAME = '" + Name + "'";
            DataTable dt = SelectByQuery(sSql);
            SystemUser _usr = null;
            if (dt != null)
                _usr = (SystemUser)this.MapUser(dt.Rows[0]);
            return _usr;
        }
        public object MapUser(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.UserName = dr["UserName"].ToString();
            return usr;
        }
        public SystemUser FindEmpIdByUser(String UserName)
        {
            string sSql = ("SELECT Name as EmpId from Admins where UserName = '" + UserName + "'").ToString();
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapEmpIdForSession(dt.Rows[0]);
            return _user;
        }
        public object MapEmpIdForSession(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Name = dr["EmpId"].ToString();
            return usr;
        }
        public SystemUser FindFullUserName(string userName)
        {
            string sSql = "select E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME+' ('+B.BRANCH_NAME+', '+D.DEPARTMENT_NAME+')' as "
        + " Name from Employee E inner join Admins A on E.EMPLOYEE_ID=A.Name INNER JOIN Branches B "
        + " ON B.BRANCH_ID=E.BRANCH_ID INNER JOIN Departments D ON E.DEPARTMENT_ID=D.DEPARTMENT_ID  where A.UserName='" + userName + "'";
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapObjectForUserName(dt.Rows[0]);
            return _user;
        }
        public object MapObjectForUserName(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Name = dr["Name"].ToString();
            return usr;
        }
        public SystemUser FindUserRole(string admin_id)
        {
            string sSql = "select S.DETAIL_TITLE,U.role_id from user_role U inner join Admins A on A.AdminID=U.USER_ID INNER JOIN "
                        + " StaticDataDetail S ON U.ROLE_ID=S.ROWID WHERE AdminID=" + admin_id + "";
            DataTable dt = SelectByQuery(sSql);
            SystemUser _user = null;
            if (dt != null)
                _user = (SystemUser)this.MapObjectForUserRole(dt.Rows[0]);

            return _user;

        }
        public object MapObjectForUserRole(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.RoleName = dr["DETAIL_TITLE"].ToString();
            usr.RoleId = dr["role_id"].ToString();
            return usr;
        }
        public List<SystemUser> FindUserName(int Branch_Id)
        {
            string sSql = "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E"
            + " inner join Admins A on A.Name=E.EMPLOYEE_ID where E.BRANCH_ID=" + Branch_Id + "";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindAllEmployee()
        {
            string sSql = "SELECT UserName,EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName FROM Employee E"
            + " inner join Admins A on A.Name=E.EMPLOYEE_ID";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindUserName(int Branch_Id, int position_hierarchy)
        {
            string sSql = "SELECT distinct A.Name AS UserName, E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName "
            + " FROM Admins AS A JOIN dbo.Employee AS E ON E.EMPLOYEE_ID = A.Name JOIN "
            + " StaticDataDetail s ON E.POSITION_ID = s.ROWID "
            + " WHERE  s.TYPE_ID = 4 and (E.BRANCH_ID = " + Branch_Id + ")  and cast(s.DETAIL_DESC as int) > " + position_hierarchy + "";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public List<SystemUser> FindByUserName(int userid)
        {
            string sSql = "select Name as UserName,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName from Admins A join"
            + " Employee E on E.EMPLOYEE_ID=A.Name where A.new_user = " + userid + "";
            DataTable dt = SelectByQuery(sSql);
            List<SystemUser> usr = new List<SystemUser>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SystemUser Sysusr = (SystemUser)this.MapObjectForName(dr);
                    usr.Add(Sysusr);
                }
            }
            return usr;
        }
        public object MapObjectForName(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Name = dr["EmpName"].ToString();
            usr.UserName = dr["UserName"].ToString();
            return usr;
        }
        public void DeleteById(long Id, String userName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from ADMINS' , ' and  ADMINID=''" + Id + "''', '" + userName + "'");
        }
        public override object MapObject(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Admin_Id = long.Parse(dr["AdminID"].ToString());
            usr.UserName = dr["UserName"].ToString();
            usr.UserPassword = dr["UserPassword"].ToString();
            usr.Name = dr["Name"].ToString();
            usr.Status = dr["status"].ToString();
            return usr;
        }
        public object MapObjectByID(DataRow dr)
        {
            SystemUser usr = new SystemUser();
            usr.Admin_Id = long.Parse(dr["AdminID"].ToString());
            usr.EmpId = dr["EmpId"].ToString();
            usr.BranchId = dr["BRANCH_ID"].ToString();
            usr.DepartmentId = dr["DEPARTMENT_ID"].ToString();
            usr.UserName = dr["UserName"].ToString();
            usr.UserPassword = dr["UserPassword"].ToString();
            usr.Name = dr["Name"].ToString();
            usr.Status = dr["status"].ToString();
            return usr;
        }        


        //public override object MapObject(DataRow dr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Save(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Update(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public override object MapObject(DataRow dr)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
