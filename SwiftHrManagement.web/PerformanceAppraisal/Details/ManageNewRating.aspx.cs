using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class ManageNewRating : BasePage
    {
        clsDAO _clsDao = new clsDAO();
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            for (int i = 0; i <= 100;i++ )
            {
                ddlNewRating.Items.Add(i.ToString());
                i = i + 4;
            }

            PopulateData();
        }

        private string GetMatrixId()
        {
            return ReadQueryString("matrixId", "");
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("appraisalId");
        }

        private void PopulateData()
        {
            
            if(GetMatrixId().ToString().ToLower()=="undefined")
            {
                return;
            }
            string[] arrayMatixIdFlag = GetMatrixId().ToString().Split('_');
            string matrixId = arrayMatixIdFlag[0];
            string flag = arrayMatixIdFlag[1];

            var sql = "select rating,R_comments  from appraisalRating where appraisalId ="+GetAppraisalId()+" and matrixId ="+matrixId+" and raterType ="+filterstring(flag)+" and R_flag ='r'";
            DataTable dt = _clsDao.getDataset(sql).Tables[0];
            DataRow dr = null;

            if(dt==null || dt.Rows.Count<0)
            {
                return;
            }

            dr = dt.Rows[0];

            lblOldRating.Text = dr["rating"].ToString();
            lblComments.Text = dr["R_comments"].ToString();



        }

    
    }
}
