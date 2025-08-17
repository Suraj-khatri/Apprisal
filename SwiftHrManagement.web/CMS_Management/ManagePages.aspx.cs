using System;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.CMS_Management;
using System.Data;
namespace SwiftHrManagement.web.CMS_Management
{
    public partial class ManagePages : BasePage
    {
        RoleMenuDAOInv roleMenuDao = null;
        clsDAO CLsDAo = null;
        CMSDAO cmsdao = null;
        CMSCore cmsCore = null;
        protected long Id = 0;
        public ManagePages()
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
        private string GetMSG()
        {
            return (Request.QueryString["msg"] != null ? (Request.QueryString["msg"].ToString()) : "");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (roleMenuDao.hasAccess(ReadSession().AdminId, 98) == false)
                {
                    Response.Redirect("/Error.aspx");
                }           
                PopulateCMSPage(GetID());
                Id = GetID();
                if (GetMSG() != "")
                {
                    lblmsg.Text = GetMSG();
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        public DataSet PopulateCMSPage(long Id)
        {
            return cmsdao.FindPageDetailsByID(Id);
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
                else if (pageType!= "Query")
                {
                    CLsDAo.runSQL("UPDATE CMS_functions SET func_type=" + filterstring(pageType) + ",func_name=" + filterstring(pageName) + ",func_head=" + filterstring(pageHead) + ",func_detail=" + filterStringCms(pageContent) + ",modify_by='" + ReadSession().UserId + "',modify_date='" + CLsDAo.ModifyDate + "' WHERE id='" + GetID() + "'");
                    Response.Redirect("ListPages.aspx");
                }
                else if(pageType=="Query")
                {
                    CLsDAo.runSQL("UPDATE CMS_functions SET func_type=" + filterstring(pageType) + ",func_name=" + filterstring(pageName) + ",func_head=" + filterstring(pageHead) + ",func_detail=" + filterPageContent(pageContent) + ",modify_by='" + ReadSession().UserId + "',modify_date='" + CLsDAo.ModifyDate + "' WHERE id='" + GetID() + "'");
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
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ckeck = CLsDAo.GetSingleresult("select func_id from CMS_Menu where func_id="+GetID()+"");
                if (ckeck != "")
                {
                    lblmsg.Text = "Sorry! You Can Not Delete This Page, This page is in use.";
                    Response.Redirect("ManagePages.aspx?ID=" + GetID() + "&msg=" + lblmsg.Text + "");
                }
                else
                {
                    this.cmsdao.DeleteById(this.GetID(), ReadSession().UserId);
                    Response.Redirect("ListPages.aspx");
                }
            }
            catch
            {
                lblmsg.Text = "Error In Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
