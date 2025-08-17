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
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob
{
    public partial class ManageProcessingJob : BasePage
    {

        WFJobProcessingCore _jobProcCore = null;
        WFJobDAO _jobDao = null;
        clsDAO CLsDAo = null;
        public ManageProcessingJob()
        {
            _jobProcCore = new WFJobProcessingCore();
            _jobDao = new WFJobDAO();
            CLsDAo = new clsDAO();
        }

        private long GetJobId()
        {
            return (Request.QueryString["JobId"] != null ? long.Parse(Request.QueryString["JobId"].ToString()) : 0);
        }
        private long GetRowId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private long GetJobCatId()
        {
            return (Request.QueryString["CatId"] != null ? long.Parse(Request.QueryString["CatId"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDDL();
                PopulateAssignedJob();
                getJobDetails();
            }
        }
        private void getJobDetails()
        {
            try
            {
                WFJobCore jobCore = new WFJobCore();
                WFJobDAO jobDao = new WFJobDAO();
                jobCore = jobDao.FindJobDetails(GetJobId());
                lblJobDetails.Text = "Category Name: " + jobCore.JobCategory + ", Job Code: " + jobCore.JobCode + "";
            }
            catch
            {
            }
        }

        private void PopulateAssignedJob()
        {
            try
            {

                DataSet ds = CLsDAo.getDataset("EXEC PROCGETJOBPROCDETAILSBYROWID " + GetRowId());
                DataTable dtCurrent = ds.Tables[0];
                DataTable dtAccepted = ds.Tables[1];

                lblForwardedFrom.Text = dtCurrent.Rows[0]["MODE"].ToString();
                lblForwardedFrom.Text = dtCurrent.Rows[0]["EMPNAME"].ToString();
                lblForwardedDate.Text = dtCurrent.Rows[0]["ACTION_DATE"].ToString();
                TxtRecievedComment.Text = dtCurrent.Rows[0]["COMMENTS"].ToString();

                ForwardPanel.Visible = false;
                AcceptDetailPanel.Visible = false;
                Btn_Accept.Visible = false;

                if (dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() == "Y")
                {
                    Btn_Accept.Visible = false;
                }
                if (dtCurrent.Rows[0]["JOB_STATUS"].ToString().ToLower() == "approved")
                {
                    Btn_Save.Visible = false;
                    Btn_Accept.Visible = false;
                }
                //else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "accepted" && long.Parse(dtCurrent.Rows[0]["ACTION_BY_EMPID"].ToString()) == ReadSession().Emp_Id)
                //{
                //    lblForwardedFrom.Text = dtAccepted.Rows[0]["EMPNAME"].ToString();
                //    lblForwardedDate.Text = dtAccepted.Rows[0]["ACTION_DATE"].ToString();
                //    lblAcceptedBy.Text = dtCurrent.Rows[0]["EMPNAME"].ToString();
                //    lblAcceptedDate.Text = dtCurrent.Rows[0]["ACTION_DATE"].ToString();
                //    TxtRecievedComment.Text = dtAccepted.Rows[0]["COMMENTS"].ToString();
                //    ForwardPanel.Visible = true;
                //    AcceptDetailPanel.Visible = true;
                //}                
                //else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "accepted" && long.Parse(dtAccepted.Rows[0]["ACTION_BY_EMPID"].ToString()) == 1000)
                //{
                //    lblForwardedFrom.Text = dtAccepted.Rows[0]["EMPNAME"].ToString();
                //    lblForwardedDate.Text = dtAccepted.Rows[0]["ACTION_DATE"].ToString();
                //    lblAcceptedBy.Text = dtCurrent.Rows[0]["EMPNAME"].ToString();
                //    lblAcceptedDate.Text = dtCurrent.Rows[0]["ACTION_DATE"].ToString();
                //    TxtRecievedComment.Text = dtAccepted.Rows[0]["COMMENTS"].ToString();
                //    ForwardPanel.Visible = true;
                //    AcceptDetailPanel.Visible = true;
                //}

                else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "forwarded" && dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() == "Y" && long.Parse(dtCurrent.Rows[0]["ACTION_BY_EMPID"].ToString()) == ReadSession().Emp_Id)
                {
                    Btn_Accept.Visible = false;
                }
                else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() != "accepted" && long.Parse(dtCurrent.Rows[0]["FORWARD_TO"].ToString()) == ReadSession().Emp_Id && dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() != "Y")
                {
                    Btn_Accept.Visible = true;
                }

                //dipesh modified
                else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "forwarded" && long.Parse(dtCurrent.Rows[0]["ACTION_BY_EMPID"].ToString()) == ReadSession().Emp_Id && dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() != "Y")
                {
                    DdlStaffName.SelectedValue = dtCurrent.Rows[0]["FORWARD_TO"].ToString();
                    DdlJobStatus.SelectedItem.Text = dtCurrent.Rows[0]["JOB_STATUS"].ToString();
                    TxtJobDescription.Text = dtCurrent.Rows[0]["COMMENTS"].ToString();
                    ForwardPanel.Visible = true;
                    AcceptDetailPanel.Visible = true;
                    Btn_Save.Visible = false;
                    Btn_Update.Visible = true;
                }
                else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "accepted" && dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() == "F")
                {
                    lblForwardedFrom.Text = "";
                    lblForwardedDate.Text = "";
                    TxtRecievedComment.Text = "";

                    lblForwardedFrom.Text = dtAccepted.Rows[0]["EMPNAME"].ToString();
                    lblForwardedDate.Text = dtAccepted.Rows[0]["ACTION_DATE"].ToString();

                    lblAcceptedBy.Text = dtCurrent.Rows[0]["EMPNAME"].ToString();
                    lblAcceptedDate.Text = dtCurrent.Rows[0]["ACTION_DATE"].ToString();

                    TxtRecievedComment.Text = dtAccepted.Rows[0]["COMMENTS"].ToString();
                    Btn_Accept.Visible = false;
                    ForwardPanel.Visible = false;
                    AcceptDetailPanel.Visible = true;
                    //ForwardPanel.Visible = true;
                }
                else if (dtCurrent.Rows[0]["MODE"].ToString().ToLower() == "accepted" && dtCurrent.Rows[0]["FLAG"].ToString().ToUpper() == "A")
                {
                    lblForwardedFrom.Text = "";
                    lblForwardedDate.Text = "";
                    TxtRecievedComment.Text = "";

                    lblForwardedFrom.Text = dtAccepted.Rows[0]["EMPNAME"].ToString();
                    lblForwardedDate.Text = dtAccepted.Rows[0]["ACTION_DATE"].ToString();

                    lblAcceptedBy.Text = dtCurrent.Rows[0]["EMPNAME"].ToString();
                    lblAcceptedDate.Text = dtCurrent.Rows[0]["ACTION_DATE"].ToString();

                    TxtRecievedComment.Text = dtAccepted.Rows[0]["COMMENTS"].ToString();
                    Btn_Accept.Visible = false;
                    AcceptDetailPanel.Visible = true;
                    ForwardPanel.Visible = true;
                }

            }
            catch
            {
            }
        }


        private void PopulateDDL()
        {
            clsDAO CLsDAo = new clsDAO();
            CLsDAo.CreateDynamicDDl(DdlJobStatus, "SELECT ROWID,DETAIL_TITLE FROM STATICDATADETAIL WHERE TYPE_ID = 51", "ROWID", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlStaffName, "SELECT M.EMPLOYEE_ID,E.EMP_CODE+' | '+E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPNAME FROM WF_MEMBER M INNER JOIN EMPLOYEE E  ON E.EMPLOYEE_ID = M.EMPLOYEE_ID WHERE M.WF_CATEGORYID =" + GetJobCatId() + " and M.Employee_ID<>"+ReadSession().Emp_Id+"", "EMPLOYEE_ID", "EmpName", "", "Select");
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                prepareJobProcList();
                _jobDao.SaveJobProcessing(_jobProcCore);
                Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");
                
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void prepareJobProcList()
        {
            _jobProcCore.JobId = GetJobId();
            _jobProcCore.Id = GetRowId();
            _jobProcCore.ForwartTo = long.Parse(DdlStaffName.SelectedValue);
            _jobProcCore.ActionEmpId = ReadSession().Emp_Id;
            _jobProcCore.CreatedDate = DateTime.Now;
            _jobProcCore.Comments = TxtJobDescription.Text;
            _jobProcCore.JobMode = "Forwarded";
            _jobProcCore.JobStatus = DdlJobStatus.SelectedItem.ToString();
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            try
            {
                prepareJobProcList();
                _jobDao.UpdateJobProcessing(_jobProcCore);
                Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                _jobProcCore.Id = GetRowId();
                _jobDao.DeleteJobProcessing(_jobProcCore);
                Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");

            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                Btn_Accept.Enabled = false;
                _jobProcCore.CreatedDate = DateTime.Now;
                _jobProcCore.JobId = GetJobId();
                _jobProcCore.ActionEmpId = ReadSession().Emp_Id;                
                _jobProcCore.JobMode = "Accepted";
                _jobDao.AcceptJobProcessing(_jobProcCore);
                Btn_Accept.Visible = false;
                Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");
        }
        protected void Btn_Update_Click1(object sender, EventArgs e)
        {
            try
            {
                prepareJobProcList();
                _jobDao.UpdateJobProcessing(_jobProcCore);
                Response.Redirect("ProcessingJobList.aspx?JobId=" + GetJobId() + "");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
