using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.ContributionMadeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ListContributionsMade : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ContributionMadeDAO _cmDao = null;
        ContributionMadeCore _cmCore = null;

        public ListContributionsMade()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._cmDao = new ContributionMadeDAO();
            this._cmCore = new ContributionMadeCore();
        }
        private void SetTempContributionId()
        {
            hdnContributionId.Value = this.GetContributionId().ToString();
            this.ReadSession().TempContribution_Id = long.Parse(hdnContributionId.Value);
        }
        private long GetContributionId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false && _RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 104) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                SetTempContributionId();
                this.GvEmpContributions.DataSource = _cmDao.FindAllByContributionId(GetContributionId());
                GvEmpContributions.DataBind();
                this.hdnContributionId.Value = GetContributionId().ToString();
            }
        }

        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            hdnContributionId.Value = GetContributionId().ToString();
            this.ReadSession().TempContribution_Id = long.Parse(hdnContributionId.Value);
            Response.Redirect("ManageContributionsMade.aspx");
        }
    }
}