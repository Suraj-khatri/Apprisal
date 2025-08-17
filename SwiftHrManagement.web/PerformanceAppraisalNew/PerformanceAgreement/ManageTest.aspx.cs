using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class Manage : BasePage
    {
         RoleMenuDAOInv _RoleMenuDAOInv = null;
         PerformanceAgreementDao _Obj = null;

         public Manage()
        {
            _Obj = new PerformanceAgreementDao();            
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
             if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1111) == false)
            {
                Response.Redirect("/Error.aspx");
            }   
            
        }
      
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            var dbResult = _Obj.Update(ReadSession().UserName.ToString(),kraNoOfQuestions.Text, kraTotalWeightage.Text, kraRatingCeiling.Text, kpiPerKraQuestionNo.Text, kpiPerKraTotalWeightAge.Text, kpiPerKraRatingCeiling.Text, criticalJobsQuestionNo.Text, criticalJobsTotalWeightAge.Text, criticalJobsRatingCeiling.Text, trainingAssesQuestionNo.Text, trainingAssesTotalWeightAge.Text, trainingAssesRatingCeiling.Text);
            if (dbResult.ErrorCode.Equals("0"))
            {
                
                GetStatic.AlertMessage(this, dbResult.Msg);
            }
            else
            {
                GetStatic.AlertMessage(Page, dbResult.Msg);
                return;
            }
        }
    }
}