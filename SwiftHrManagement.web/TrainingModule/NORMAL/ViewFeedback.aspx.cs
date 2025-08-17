using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.TrainingModule.NORMAL
{
    public partial class ViewFeedback : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            onLoadFirstReport();
            onLoadSubjectiveReport();
        }
        private long GetTrainingId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private string GetFeedbackId()
        {
            string feedback_id="";
            if (GetFlag() == "h")
            {
                feedback_id = (Request.QueryString["feedback_id"] != null ? Request.QueryString["feedback_id"].ToString() : "");
            }
            else
            {
                feedback_id = _clsdao.GetSingleresult("select trainingFbId from TrainingFeedback where trainingProgramId=" + GetTrainingId() + " and empId=" + ReadSession().Emp_Id + "");
            }
            return feedback_id;
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }

        private void onLoadFirstReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"700\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getDataset("Exec [proc_TrainingFeedBack] @flag='e',@trainingFbId=" + filterstring(GetFeedbackId()) + "").Tables[1];
            DataTable dt1 = _clsdao.getDataset("Exec [proc_TrainingFeedBack] @flag='e',@trainingFbId=" + filterstring(GetFeedbackId()) + "").Tables[0];
            int cols = dt.Columns.Count;
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                str.Append("<td colspan='3'><div align=\"left\">"
                    + "Employee Name:" + dr["emp"].ToString() + "</br></br>"
                    +" Branch Name: " + dr["branch"].ToString() + "</br></br>"
                    + "Department Name: " + dr["dept"].ToString() + "</br></br>"
                    + "Training Program:" + dr["program"].ToString() + "</br></br> </div></td>");
                str.Append("</tr>");
            }
            
            str.Append("<tr>");
            str.Append("<th><div align=\"left\">S.N.</div></th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");
            string type_id = "0";
            int sn = 0;
            foreach (DataRow row in dt.Rows)
            {                
                if (row["TYPE_ID"].ToString() == "67" && row["TYPE_ID"].ToString()!=type_id)
                {
                    str.Append("<tr>");
                    str.Append("<td>&nbsp;</td>");
                    str.Append("<td colspan='2'><div align=\"left\"><u>Preparation</u></div></td>");
                    str.Append("</tr>");
                }
                if (row["TYPE_ID"].ToString() == "68" && row["TYPE_ID"].ToString() != type_id)
                {
                    str.Append("<tr>");
                    str.Append("<td>&nbsp;</td>");
                    str.Append("<td colspan='2'><div align=\"left\"><u>Content Delivery</u></div></td>");
                    str.Append("</tr>");
                }
                if (row["TYPE_ID"].ToString() == "69" && row["TYPE_ID"].ToString() != type_id)
                {
                    str.Append("<tr>");
                    str.Append("<td>&nbsp;</td>");
                    str.Append("<td colspan='2'><div align=\"left\"><u>Facilitator</u></div></td>");
                    str.Append("</tr>");
                }
                if (row["TYPE_ID"].ToString() == "70" && row["TYPE_ID"].ToString() != type_id)
                {
                    str.Append("<tr>");
                    str.Append("<td>&nbsp;</td>");
                    str.Append("<td colspan='2'><div align=\"left\"><u>Facility</u></div></td>");
                    str.Append("</tr>");
                }
                if (row["TYPE_ID"].ToString() == "71" && row["TYPE_ID"].ToString() != type_id)
                {
                    str.Append("<tr>");
                    str.Append("<td>&nbsp;</td>");
                    str.Append("<td colspan='2'><div align=\"left\"><u>General Satisfaction</u></div></td>");
                    str.Append("</tr>");
                }
                type_id = row["TYPE_ID"].ToString();
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + (++sn) + ".</td>");  
                for (int i = 1; i < cols; i++)
                {                    
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");                    
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }

        private void onLoadSubjectiveReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"700\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getDataset("Exec [proc_TrainingFeedBack] @flag='e',@trainingFbId=" + filterstring(GetFeedbackId()) + "").Tables[2];

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptSubjective.InnerHtml = str.ToString();
        }
    }
}
