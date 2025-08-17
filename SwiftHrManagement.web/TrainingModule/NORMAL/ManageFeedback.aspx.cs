using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingModule.NORMAL
{
    public partial class ManageFeedback : BasePage
    {
        string comments = "";
        string RowIDs = "";
        RoleMenuDAOInv _roleMenuDao = null; 
        clsDAO _clsDao = null; 
        public ManageFeedback()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _clsDao =new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            comments = (Request.Form["txtComment"] ?? "").ToString();
            RowIDs = (Request.Form["rowId"] ?? "").ToString();
            comments = comments.Replace("\t", " ");
     
            comments = comments.Replace("\n", " ");
            comments = comments.Replace("\r", " ");
            var RowId = Request.Form["rowIdfirst"];
            var reponseId = Request.Form["Response_"];

            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 219) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateQuestion();
                populateSubQuestion();
                EmployeeInfo();
            }            
        }

        private long GetTrainingId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void EmployeeInfo()
        {
            DataTable dt = _clsDao.getDataset(@"select dbo.GetBranchName(a.branchId) branch,
		dbo.GetDeptName(a.deptId) dept,dbo.GetEmployeeFullNameOfId(a.employeeId) emp,
		b.programName program from trainingParticipation a inner join training b on b.id=a.trainingId
		where a.trainingId=" + GetTrainingId() + " and a.employeeId="+ReadSession().Emp_Id+"").Tables[0];
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
            return;
            dr = dt.Rows[0];

            lblBranch.Text = dr["branch"].ToString();
            lblName.Text = dr["emp"].ToString();
            lblDept.Text = dr["dept"].ToString();
            lblDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy"); 
            lblProgramName.Text = dr["program"].ToString();

        }      
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        private string PrintList(ref DataTable dt, string typeId, string groupCaption)
        {
            DataRow[] rows = dt.Select("TYPE_ID='" + typeId + "'");

            var str = new StringBuilder();

            str.Append("<tr>");
            str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + groupCaption + "</font></strong></div></td>");
            str.Append("</tr>");

            var rowCount = rows.Length;
            int sn = 0;
            foreach (DataRow dr in rows)
            {
                str.Append("<tr>");
                rowCount--;
                str.Append("<td align=\"left\"><div style = \"margin-left:20px\">" + (++sn) + ". " + dr["DETAIL_TITLE"].ToString() + "</td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + dr["Response"].ToString() + dr["rowId_hidden"].ToString() + "</td>");
                str.Append("</tr>");
            }            
            return str.ToString();
        }

        private void populateQuestion()
        {
            DataTable dt = null;
            dt = _clsDao.getTable("EXEC [proc_TrainingFeedBack] @flag='s'");

            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<table width=\"700\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            str.Append("<tr>");
            str.Append("<th style=\"text-align:center\"><strong>Category</strong></th><th style=\"text-align:center\"><strong>Response</strong></th><th style=\"text-align:center\"></th>");
            str.Append("</tr>");

            var html = PrintList(ref dt, "67", "Preparation");
            str.AppendLine(html);

            html = PrintList(ref dt, "68", "Content Delivery");
            str.AppendLine(html);

            html = PrintList(ref dt, "69", "Facilitator");
            str.AppendLine(html);

            html = PrintList(ref dt, "70", "Facility");
            str.AppendLine(html);

            html = PrintList(ref dt, "71", "General Satisfaction");
            str.AppendLine(html);

            str.Append("</table>");
            rptFeedback.InnerHtml = str.ToString();
        }
        private void populateSubQuestion()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _clsDao.getTable("Exec [proc_TrainingFeedBack] @flag='a'");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"CENTER\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        if (i == 3)
                        {
                            str.Append("<td align=\"right\"><textarea class='inputTextBoxLP1' rows=\"4\" cols=\"40\" overflow=\"auto\" style=\"height:100px;width:300px;text-align:top;text-mode:multiline\" name='txtComment' id='txtComment_" + dr["ROWID"] + "' value='" + (dr["Answer"].ToString()) + "'></textarea></td>");
                        }
                        else if (i==1)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                        else if (i == 2)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }

                    }
                    str.Append("<input type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + dr["ROWID"].ToString() + "\" value = \"" + dr["ROWID"].ToString() + "\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rptSubjectiveFeedback.InnerHtml = str.ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblMsg.Text = "Error In Operation!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnSave()
        {
            //INSERTING FEEDBACK MASTER TABLE 
            string feedback_id = _clsDao.GetSingleresult("Exec [proc_TrainingFeedBack] @flag='c',"
                +" @trainingProgramId="+filterstring(GetTrainingId().ToString())+",@empId="+filterstring(ReadSession().Emp_Id.ToString())+"");

            // INSERTING RATING FOR FEEDBACK

            string[] feedBackId = Request.Form["rowIdfirst"].Split(',');
            int fcnt = feedBackId.GetUpperBound(0);
            string feedback = feedBackId[0];
            string[] responseId = Request.Form["Response_"].Split(',');
            int rcnt = responseId.GetUpperBound(0);
            string response = responseId[0];
            for (int i = 0; i < fcnt; i++)
            {
                _clsDao.runSQL("insert into trainingFeedbackDetails(traningFbId,staticRowId,responseId,createdBy,createdDate)"
                + " values(" + feedback_id + "," + filterstring(feedBackId[i].ToString()) + "," + filterstring(responseId[i].ToString()) + ","
                +" "+ReadSession().Emp_Id+","+ filterstring(System.DateTime.Now.ToString())+")");

            }

            // INSERTING SUBJECTIVE ANSWER
            string msg = _clsDao.GetSingleresult("Exec [proc_TrainingFeedBack] @flag='b',@ROWIDS='" + RowIDs + "',@subjectiveRemarks='" + comments + "',"
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@trainingFbId=" + feedback_id + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
