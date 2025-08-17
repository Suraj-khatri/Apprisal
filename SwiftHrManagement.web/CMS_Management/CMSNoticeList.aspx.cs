using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.User;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.CMS_Management;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.CMS_Management
{
    public partial class CMSNoticeList : BasePage
    {
        RoleMenuDAOInv roleMenuDao = null;
        clsDAO CLsDAo = null;
        CMSDAO cmsdao = null;
        CMSCore cmsCore = null;
        protected long Id = 0;
        public CMSNoticeList()
        {
            cmsCore = new CMSCore();
            cmsdao = new CMSDAO();
            CLsDAo = new clsDAO();
            roleMenuDao = new RoleMenuDAOInv();       
        }
        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCMSNotice(GetID());
                Id = GetID();
            }
        }
        public DataSet PopulateCMSNotice(long id)
        {
            return cmsdao.FindNoticeByID(id);
        }
    }
}
