using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.CMS_Management
{
    public partial class AddCmsPage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO CLsDAo = null;
        public AddCmsPage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();       
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 98) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string pageType = Request.Form["pageType"] != null ? Request.Form["pageType"].ToString() : "";
                string pageHead = Request.Form["textarea3"] != null ? Request.Form["textarea3"].ToString() : "";
                string pageContent = Request.Form["textarea2"] != null ? Request.Form["textarea2"].ToString() : "";
                string pageName = Request.Form["txtPageName"] != null ? Request.Form["txtPageName"].ToString() : "";
                if (pageType == "")
                {
                    lblmsg.Text = "Please enter page type!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else if (pageName == "")
                {
                    lblmsg.Text = "Please enter page name!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else if (pageHead == "")
                {
                    lblmsg.Text = "Please enter page heading!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else if (pageContent == "")
                {
                    lblmsg.Text = "Please enter page content!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else if(pageType!="Query")
                {
                    CLsDAo.runSQL("INSERT INTO CMS_functions(func_type,func_name,func_head,func_detail,created_date,create_by)VALUES("
                    + " " + filterstring(pageType) + "," + filterstring(pageName) + "," + filterstring(pageHead) + "," + filterstring(pageContent) + "," + filterstring(CLsDAo.CreatedDate.ToString()) + ","
                    + " " + filterstring(ReadSession().Emp_Id.ToString()) + ")");
                    Response.Redirect("ListPages.aspx");
                }
                else if (pageType == "Query")
                {
                    CLsDAo.runSQL("INSERT INTO CMS_functions(func_type,func_name,func_head,func_detail,created_date,create_by)VALUES("
                    + " " + filterstring(pageType) + "," + filterstring(pageName) + "," + filterstring(pageHead) + "," + filterPageContent(pageContent) + "," + filterstring(CLsDAo.CreatedDate.ToString()) + ","
                    + " " + filterstring(ReadSession().Emp_Id.ToString()) + ")");
                    Response.Redirect("ListPages.aspx");
                }
                
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPages.aspx");
        }
    }
}
