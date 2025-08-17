using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class AppraisalView : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        PerformanceAppraisalDAO _performanceAppraisalDao = null;
        PerformanceAppraisalCore _performanceAppraisalCore = null;
        protected int appId = 0;
        public AppraisalView()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._performanceAppraisalDao = new PerformanceAppraisalDAO();
            this._performanceAppraisalCore = new PerformanceAppraisalCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 27) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                AppraisalList(GetAppraisalId());
            }
            appId = GetAppraisalId();
        }
        protected int GetAppraisalId()
        {
            return (Request.QueryString["Id"] != null ? int.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        public void test()
        {
        }
        public DataSet AppraisalList(int appraisalId)
        {
            return _performanceAppraisalDao.FindAppraisalListById(appraisalId.ToString(), "");
        }
        private void ManageAppraisal()
        {
            PerformanceAppraisalCore _paCore = new PerformanceAppraisalCore();
            string ids = Request.Form["element_Id"] != null ? Request.Form["element_Id"].ToString() : "";
            string weights = Request.Form["element_weight"] != null ? Request.Form["element_weight"].ToString() : "";

            string[] idList = ids.Split(',');
            string[] weightList = weights.Split(',');
            string[] remarksList = new string[idList.Length];

            for (int i = 0; i < idList.Length; i++)
            {
                if (Request.Form["element_remarks_" + idList[i].ToString()] != null)
                    remarksList[i] = Request.Form["element_remarks_" + idList[i].ToString()].ToString();
            }
            this._performanceAppraisalDao.DeleteAppraisalDetail(appId.ToString());
            for (int i = 0; i < idList.Length; i++)
            {
                {
                    this._performanceAppraisalDao.SaveAppraisalDetail(appId.ToString(), idList[i].ToString(), remarksList[i].ToString(), weightList[i].ToString());
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAppraisal();
            }
            catch
            {

            }
        }
    }
}
