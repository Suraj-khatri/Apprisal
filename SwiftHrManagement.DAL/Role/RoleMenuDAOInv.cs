using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SwiftHrManagement.Core.Domain;
using System.Data;

namespace SwiftHrManagement.DAL.Role
{
    public class RoleMenuDAOInv : BaseDAOInv
    {

        private StringBuilder _insertQuery;
        private StringBuilder _selectQuery;

        public RoleMenuDAOInv()
        {
            this._insertQuery = new StringBuilder("procSaveMenuRole @role_id ='{role_Id}',@menu_List='{menu_List}'");
            this._selectQuery = new StringBuilder("SELECT ROLE_NAME, ROLE_ID FROM ROLE_MASTER");
        }
        public override  void Save(object obj)
        {
            RoleMenuCore _rolemenuCore = (RoleMenuCore)obj;
            this._insertQuery.Replace("{role_Id}", _rolemenuCore.Role_id);
            this._insertQuery.Replace("{menu_List}", _rolemenuCore.MenuList);
            ExecuteQuery(this._insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public List<RoleMenuCore> Findrole()
        {
            String ssql = this._selectQuery.ToString();
            DataTable dt = SelectByQuery(ssql);
            List<RoleMenuCore> _roleCore = new List<RoleMenuCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    RoleMenuCore _rCore = (RoleMenuCore)this.MapObject(dr);
                    _roleCore.Add(_rCore);
                }
            }
            return _roleCore;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            RoleMenuCore _rolemenu = new RoleMenuCore();
            _rolemenu.Role_id = dr["ROLE_NAME"].ToString();
            _rolemenu.Id = long.Parse(dr["ROLE_ID"].ToString());
            return _rolemenu;
        }
        public DataTable getMeluList_For_User(String userId, String menuType)
        {
            String sSql = " exec procGetUserMenu '" + userId + "','" + menuType +"'";
            return ExecuteStoreProcedure(sSql);
        }
        public DataTable getMeluList_For_Role(String roleId)
        {
            String sSql = " exec procGetRoleMenu " + roleId + "";
            return ExecuteStoreProcedure(sSql);
        }
        public  bool hasAccess(long userId, long menuId)
        {
            bool _hasAccess;
            String sSql="exec procHasAccess @userId=" + userId.ToString() + ",@menuId=" + menuId;
            _hasAccess = CheckStatement(sSql);
            return _hasAccess;
        }
        public void hasAccess(long userId, long menuId,bool redirectIfNotAuthorised)
        {
            bool _hasAccess;
            String sSql = "exec procHasAccess @userId=" + userId.ToString() + ",@menuId=" + menuId;
            _hasAccess = CheckStatement(sSql);
            if (!_hasAccess)
            {
                
            }
        }

        public Boolean CheckForValidUserRole(string Id)
        {
            String sSql = "SELECT S.DETAIL_TITLE from user_role U inner join Admins A on A.AdminID=U.USER_ID INNER JOIN "
                        +" StaticDataDetail S ON U.ROLE_ID=S.ROWID WHERE a.AdminID="+Id+"";
            return CheckStatement(sSql);
        }

        public  object MapObjectForRole(System.Data.DataRow dr)
        {
            RoleMenuCore _rolemenu = new RoleMenuCore();
            _rolemenu.Role_id = dr["ROLE_ID"].ToString();
            _rolemenu.Userid = long.Parse(dr["USER_ID"].ToString());
            return _rolemenu;
        }
    }
}
