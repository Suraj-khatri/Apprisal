using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OnTheJobTraining
{
    public partial class JobFeedBackDetails : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        string feedbackDetailId = null;
        string IdentityId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
                loadReport();
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 40) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (Request.Form["hdn_"] != null)
                    IdentityId = Request.Form["hdn_"].ToString();

                if (Request.Form["feedback_"] != null)
                    feedbackDetailId = Request.Form["feedback_"].ToString();
          
        }

        private string autoSelect(string str1, string str2)
        {
            if (str1 == str2)
                return "selected=\"selected\"";
            else
                return "";

        }
        
               private string GetFlag()
            {
                return (Request.QueryString["Status"] != null ? Request.QueryString["Status"] : "");
            }
           private long GetJobGroupId()
            {
                 return (Request.QueryString["JOB_GROUP_ID"] != null ? long.Parse(Request.QueryString["JOB_GROUP_ID"]) : 0);
            }


            private long GetOJTId()
             {
                 return (Request.QueryString["OJT_ID"] != null ? long.Parse(Request.QueryString["OJT_ID"]) : 0);
             }
          private long GetSuperVisorId()
             {
                 return (Request.QueryString["SuperVisorID"] != null ? long.Parse(Request.QueryString["SuperVisorID"]) : 0);
             }
          private long GetTraineeId()
          {
              return (Request.QueryString["TraineeId"] != null ? long.Parse(Request.QueryString["TraineeId"]) : 0);
          }
          private long GetMasterId()
          {
              return (Request.QueryString["JFBM_ID"] != null ? long.Parse(Request.QueryString["JFBM_ID"]) : 0);
          }


        
        private void ArrayOpertation()
           {
               if (IdentityId != null && feedbackDetailId != null)
               {     
                    
                     string [] cat_id = IdentityId.Split(',');
                     string[] fd = feedbackDetailId.Split(',');
                  
                     string sql ="";
                     int c = 0;
                            for (int i=0; i<fd.Count()-1; i=i+4)
                             {
                                 sql = "UPDATE JobFeedBackDetails SET  JOB_DESC='" + fd[i + 1] + "' ,"
                                      +" WEIGHT='" + fd[i + 2] + "',JOB_FEEDBACK_CAT='" + fd[i + 3] + "' WHERE JFD_ID=" + cat_id[c];
                                 _clsDao.runSQL(sql);
                                 
                                 c++;
                             }
                 
               }
       }


        string MakeDDL(string defValue, string keyValue, ref DataTable dt)
        {
            var html = new StringBuilder("");
            html.Append("<select id = \"feedback_" + keyValue + "\" name = \"feedback_\">");
            html.Append("<option value=\"\">select</option>");
            foreach (DataRow dr in dt.Rows)
            {
                html.Append("<option value = \"" + dr["ROWID"].ToString() + "\"" + autoSelect(dr[0].ToString(), defValue) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
            }
            html.Append("</select>");
            return html.ToString();
        }


        private void loadReport()
        {
           
    
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            string sql = "Exec procOJT_DETAILS @Flag='s',@JOB_GROUP_ID=" + filterstring(GetJobGroupId().ToString()) + ",@OJT_ID=" +filterstring(GetOJTId().ToString()) + ""
                + ", @MAIN_ID=" + filterstring(GetMasterId().ToString()) + ",@SUPERVISOR=" + filterstring(GetSuperVisorId().ToString()) + ",@TRAINEE_ID=" + filterstring(GetTraineeId().ToString()) + "";

            DataTable dt = _clsDao.getDataset(sql).Tables[0];
            var dtCAT = _clsDao.getDataset("SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE [TYPE_ID]=59").Tables[0]; 

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
              
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i ==0)
                    { 

                    }
                   else if (i == 4)
                    {
                        str.Append("<td align=\"right\" nowrap>" + MakeDDL(dr[4].ToString(), dr[0].ToString(), ref dtCAT));
                       
                    }
                  
                  
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            ArrayOpertation();
            LblMsg.Text = "Update Successfully"; ;
            LblMsg.ForeColor = System.Drawing.Color.Green;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (GetSuperVisorId() > 0)
            {

                Response.Redirect("/OnTheJobTraining/SuperVisorFeedBack/ListSuperVisorFeedBack.aspx");
            }
            else if (GetTraineeId() > 0)
            {

                Response.Redirect("/OnTheJobTraining/TraineeFeedBack/ListTraineeFeedBack.aspx");
            }
            else
            {

                Response.Redirect("/OnTheJobTraining/SuperVisorFeedBack/ListDateWiseSVFeedBack.aspx");
            }
        }
    }
}
