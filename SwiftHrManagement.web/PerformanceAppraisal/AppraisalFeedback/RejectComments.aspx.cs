using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class RejectComments : BasePage
    {
        protected string msg = "";
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            var sql = "SELECT R_flag flag FROM appraisalRating WHERE appraisalId = " + GetAppraisalId() + " AND matrixId = " + GetMatixId() + " AND raterType = " + filterstring(GetRaterType()) + " and R_flag is not null ";
            string returnMsg = _clsDao.GetSingleresult(sql);
            if (returnMsg == "")
            {
                msg = "0";
            }
            else
            {
                msg = "1";
                lblMsg.Text = "The rating has already been rejected.!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("appraisalId");
        }
        private string GetRaterType()
        {
            return ReadQueryString("raterType","");
        }
        private long GetMatixId()
        {
            return ReadNumericDataFromQueryString("matrixId");
        }
    }
}
