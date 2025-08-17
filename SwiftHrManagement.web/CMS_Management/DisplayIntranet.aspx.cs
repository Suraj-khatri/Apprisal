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

using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.StaticDataDetailsDAO;

namespace SwiftHrManagement.web.CMS_Management
{
    public partial class DisplayIntranet : BasePage
    {
        RoleMenuDAOInv roleMenuDao = null;
        CMSDAO cmsdao = null;
        CMSCore cmsCore = null;
        clsDAO _clsDao = null;
        public DisplayIntranet()
        {
            _clsDao = new clsDAO();
            cmsCore = new CMSCore();
            cmsdao = new CMSDAO();
            roleMenuDao = new RoleMenuDAOInv();    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (roleMenuDao.hasAccess(ReadSession().AdminId, 97) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                
                PopulateCMSMenu();
                populateNoticeBoard();
                populateLatestUpload();
            }
        }
        private void populateNoticeBoard()
        {
            StringBuilder str = new StringBuilder("<ul>");
            DataTable dt = _clsDao.getTable("SELECT top 10 id,func_head FROM CMS_functions WHERE func_type='Notice' ORDER BY id DESC");
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                    {
                        str.Append("<li><a target=\"MainFrame\" href=\"/CMS_Management/CMSPageList.aspx?ID=" + row[0].ToString() + "\">" + row[i].ToString() + "</a></li>");
                    }
                }
            }
            str.Append("</ul>");
            rpt.InnerHtml = str.ToString();

        }
        private void populateLatestUpload()
        {
            StringBuilder str = new StringBuilder("<ul>");
            DataTable dt = _clsDao.getTable(@"SELECT TOP 10 rowid,funct_id,doc_desc+'| '+convert(varchar,file_date,107) AS file_desc,doc_ext
FROM CMS_document where funct_id NOT IN(SELECT func_id FROM CMS_Menu) ORDER BY rowid DESC");
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                    {
                        str.Append("<li><a target='_blank' href='/doc/CMS_Management/" + row[1].ToString() + "/" + row[0].ToString() + "." + row[3].ToString() + "'>" + row[2].ToString() + "</a></li>");
                    }
                }
            }
            str.Append("</ul>");
            rpt1.InnerHtml = str.ToString();
        }
        private void loadheading()
        {
            
        }
        public DataSet PopulateCMSMenu()
        {
            string displayFlag = "b";
            return cmsdao.FindAllMenus(displayFlag);
        }
    }
}
