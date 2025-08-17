using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.DailyActivityReport
{
    public partial class ActivityDetailReport : BasePage
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetFlag() == "s")
                {

                    btnVerify.Visible = false;
                    VerifyBy.Visible = true;
                    lblComment.Visible = true;
                    displayData();
                }
                else
                {
                    if (GetStatus() == "r")
                    {
                        populateData();
                        txtComment.Visible = true;
                        btnVerify.Visible = true;
                    }
                    else
                    {
                        VerifyBy.Visible = true;
                        lblComment.Visible = true;
                        displayData();
                    }
                }
            }
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"]) : "");
        }
        private string GetStatus()
        {
            return (Request.QueryString["status"] != null ? (Request.QueryString["status"]) : "");
        }

        private long activityId()
        {
            return long.Parse(Request.QueryString["activityId"] != null ? (Request.QueryString["activityId"]) : "");
        }

        private void populateData()
        {
            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataSet ds = _clsDao.getDataset("Exec [proc_activityDailyDetail] @flag='sm',@activityId=" + filterstring(activityId().ToString()) + ",@status=" + filterstring(GetStatus().ToString()));
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            foreach (DataRow dr in dt.Rows)
            {
                lblBranch.Text = dr["BRANCH"].ToString();
                lblDept.Text = dr["DEPARTMENT"].ToString();
                lblEmployee.Text = dr["empId"].ToString();
                lblPost.Text = dr["position"].ToString();
                lblDate.Text = dr["enterDate"].ToString();
            }
            str.Append("<tr>");
            int cols = dt1.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"left\" width=\"50px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:30em; height:4em;\">" + dr[i].ToString() + " </textarea></td>");
                    }
                    else 
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }

        private void displayData()
        {
            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataSet ds = _clsDao.getDataset("Exec [proc_activityDailyDetail] @flag='sm',@activityId=" + filterstring(activityId().ToString()) + ",@status=" + filterstring(GetStatus().ToString()));
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            foreach (DataRow dr in dt.Rows)
            {
                string verify = dr["verifyBy"].ToString();
               if (verify.Trim().ToUpper() == "ALL EMPLOYEE")
                {
                    lblVerify.Text = "Not verify";
                }
                else
                {
                    lblVerify.Text = verify;
                }
                lblBranch.Text = dr["BRANCH"].ToString();
                lblDept.Text = dr["DEPARTMENT"].ToString();
                lblEmployee.Text = dr["empId"].ToString();
                lblPost.Text = dr["position"].ToString();
                lblDate.Text = dr["enterDate"].ToString();
                lblVDate.Text = dr["verifyDate"].ToString();
                lblVPosition.Text = dr["verifyPosition"].ToString();
                lblComment.Text = dr["comments"].ToString();
            }
            str.Append("<tr>");
            int cols = dt1.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"left\" width=\"50px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:30em; height:4em;\">" + dr[i].ToString() + " </textarea></td>");
                    }
                    else
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            lblMsg.Text = _clsDao.GetSingleresult("Exec proc_activityDailyDetail @flag='sv',@verifyBy=" + filterstring(ReadSession().Emp_Id.ToString())
                + ",@verifyPosition=" + filterstring(ReadSession().Designation.ToString()) + ",@comments=" + filterstring(txtComment.Text)
                + ",@activityId =" + filterstring(activityId().ToString()));
            Response.Redirect("ActivityDetailReport.aspx?activityId=" + activityId() + "&status=" + lblMsg.Text);
        }

    }
}
