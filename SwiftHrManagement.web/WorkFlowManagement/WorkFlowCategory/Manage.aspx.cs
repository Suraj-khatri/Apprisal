using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowCategory
{
    public partial class Manage : BasePage
    {

        RoleMenuDAOInv _roleMenuDao = null;
        WFCategoryCore _catCore = null;
        WFCategoryDAO _wfCatDAO = null;
        public Manage()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _catCore = new WFCategoryCore();
            _wfCatDAO = new WFCategoryDAO();
        }

        private long GetWorkFlowCatId()
        {
            return (Request.QueryString["WFCat_Id"] != null ? long.Parse(Request.QueryString["WFCat_Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 81) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetWorkFlowCatId() > 0)
                {
                    populateWFcatDetails();                    
                    this.Btn_Delete.Visible = true;                    
                }
                else
                {
                    this.Btn_Delete.Visible = false;
                }
            }
            Btn_Back.Attributes.Add("onclick", "history.back();return false");
        }

        private void populateWFcatDetails()
        {
            _catCore = _wfCatDAO.FindByCatId(GetWorkFlowCatId());
            this.TxtCatName.Text = _catCore.WFCatName;
            this.TxtCatDetails.Text = _catCore.WFCatDetails;
            DdlDeptName.SelectedValue = _catCore.WFDept;
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
        
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                manageCategoryList();                
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void manageCategoryList()
        {
            long id = GetWorkFlowCatId();

            prepareCategoryList();

            if (id > 0)
            {
                _catCore.CreatedBy = this.ReadSession().UserId;
                _catCore.CreatedDate = DateTime.Now;
                _wfCatDAO.Update(_catCore);
            }
            else
            {
                _catCore.CreatedBy = this.ReadSession().UserId;
                _catCore.CreatedDate = DateTime.Now;
                _wfCatDAO.Save(_catCore);
            }
           
        }

        private void prepareCategoryList()
        {
            long id = GetWorkFlowCatId();
            if (id > 0)
            {
                _catCore.WFCategoryID = id;                
            }           
            _catCore.WFCatName = this.TxtCatName.Text;
            _catCore.WFCatDetails = this.TxtCatDetails.Text;
            _catCore.WFDept = DdlDeptName.Text;             
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                _catCore.WFCategoryID = GetWorkFlowCatId();
                _wfCatDAO.Delete(_catCore);
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void manageWFCategoryList()
        {

        }

    }
}

