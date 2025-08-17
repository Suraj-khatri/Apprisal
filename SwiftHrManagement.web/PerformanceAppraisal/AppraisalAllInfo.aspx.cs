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
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.web.DAL.PerformanceAppraisal.Matrix;

namespace SwiftHrManagement.web.PerformanceAppraisal
{
    public partial class AppraisalAllInfo : BasePage
    {
        protected int appraisalId = 0;
        protected int positionId = 0;
        protected int ratingTypeId = 0;
        RoleMenuDAOInv _roleMenuDao = null;
        AppriasalMatrixDao _Dao = null;
        public AppraisalAllInfo()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._Dao = new AppriasalMatrixDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }


                //TabAppraiseeTask.Visible = false;
                
                if (GetRatingTypeId().Equals(710) || GetRatingTypeId().Equals(711) || GetRatingTypeId().Equals(712) ) {
                    TabPanel4.Visible = false;
                    TabPanel6.Visible = false;
                }

                if (GetRatingTypeId().Equals(2053))
                {
                    TabPanel6.Visible = false;
                }


               if (GetRatingTypeId().ToString().Equals("1832"))
                    TabContainer2.ActiveTabIndex = 2;
               else if (GetRatingTypeId().ToString().Equals("1833"))
                   TabContainer2.ActiveTabIndex = 3;
               else if (GetRatingTypeId().ToString().Equals("1834"))
                   TabContainer2.ActiveTabIndex = 4;
               else if (GetRatingTypeId().ToString().Equals("1836"))
                   TabContainer2.ActiveTabIndex = 5;
                else 
                    TabContainer2.ActiveTabIndex = 0;
                

            }
            appraisalId = GetAppraisalId();
            positionId = GetPositionId();
            ratingTypeId = GetRatingTypeId();
            GetAppraisalId();
            DisplayAppraisalInfo();
        }

        //public string GetReatingType()
        //{
        //    string typeID = GetRatingTypeId().ToString();
        //    string ratingType = "";
        //    if (typeID == "656")
        //        ratingType = "Appraisee";
        //    else if (typeID == "657")
        //        ratingType = "Appraiser";
        //    else if (typeID == "658")
        //        ratingType = "Revisor";
        //    else if (typeID == "659")
        //        ratingType = "HR";
        //    else if (typeID == "660")
        //        ratingType = "CEO";
        //    return ratingType;
        //}

        protected int GetAppraisalId()
        {
            return (Request.QueryString["appraisalId"] != null ? int.Parse(Request.QueryString["appraisalId"].ToString()) : 0);
        }

        protected int GetPositionId()
        {
            return (Request.QueryString["positionId"] != null ? int.Parse(Request.QueryString["positionId"].ToString()) : 0);
        }
        protected int GetEmployeeTypeId()
        {
            return (Request.QueryString["EmpIdType"] != null ? int.Parse(Request.QueryString["EmpIdType"].ToString()) : 0);
        }
        
        protected int GetEmployeeId()
        {
            return (Request.QueryString["EmpId"] != null ? int.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected int GetRatingTypeId()
        {
            return (Request.QueryString["ratingTypeId"] != null ? int.Parse(Request.QueryString["ratingTypeId"].ToString()) : 0);

        }

        private void DisplayAppraisalInfo()
        {
            DataTable dt = _Dao.GetAppraisalInfoById(ReadNumericDataFromQueryString("appraisalId"));
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];
            lblEmployeeName.Text = dr["empName"].ToString();
            lblBranchName.Text = dr["branchId"].ToString();
            lblDeptName.Text = dr["deptId"].ToString();
            lblDesignation.Text = dr["position"].ToString();
            lblTotalBankPeriod.Text = dr["TotalDateInDays"].ToString();
            lblPeriodFrom.Text = dr["FROM_DATE"].ToString();
            lblPeriodTo.Text = dr["TO_DATE"].ToString();
            lblPreviousAppraisal.Text = dr["previousAppraisalDate"].ToString();
            lblFunctionalTitel.Text = dr["TITLE"].ToString();
            lblSupervisor.Text = dr["supervisor"].ToString();
            lblReviewer.Text = dr["reviewer"].ToString();
           
        }
    }
}
