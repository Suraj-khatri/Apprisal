using System;
using System.Data;
using System.Text;
using System.Web.UI;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.JobDescription;
using SwiftHrManagement.web.Library;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb.JobDescription
{
    public partial class JobDescription : BasePage
    {
        JobDescriptionCore _job = new JobDescriptionCore();
        private JobDescriptionDAO _db = new JobDescriptionDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {

            AutoCompleteExtender2.ContextKey = ReadSession().Emp_Id.ToString();
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1117) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                txtDisagree.Visible = false;
                lblDisagree.Visible = false;
                CheckUnusedStaffRpt();

                if (GetId() != null && GetStatus() != null)
                {
                    PopulateData();
                }
            }
        }

        #region EmployeeDetails

        protected void txtJobHolder_OnTextChanged(object sender, EventArgs e)
        {
            if (txtJobHolder.Text.Contains("|"))
            {
                PopulateEmpDetails();
                if (hdnJobHold.Value == ReadSession().Emp_Id.ToString())
                {
                    string message = "alert('Job Description cannot be assigned by self !')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    txtJobHolder.Text = string.Empty;
                }
                else
                {
                    string[] splitEmpName = txtJobHolder.Text.Split('-');
                    lblJobHold.Text = splitEmpName[0];
                    lblSupvis.Text = txtSuperVis.Text;
                    DateTime now = DateTime.Now;
                    date.Text = now.ToString();
                    date1.Text = now.ToString();

                }
            }
            else
            {
                LblMsg.Text = "Invalid Name";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void PopulateEmpDetails()
        {
            string[] empName = txtJobHolder.Text.Split('|');
            hdnJobHold.Value = empName[1];


            DataTable dt = _db.GetEmpDetails(hdnJobHold.Value,ReadSession().Emp_Id.ToString());
            if (dt == null || dt.Rows.Count <= 0)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                lblBranch.Text = dr["branch"].ToString();
                lblFuncTitle.Text = dr["functional"].ToString();
                lblCorpTitle.Text = dr["position"].ToString();
                hdbBranch.Value = dr["BRANCH_ID"].ToString();
                hdnPosition.Value = dr["POSITION_ID"].ToString();
                hdnFuncTitle.Value = dr["FUNCTIONAL_TITLE"].ToString();
                txtSuperVis.Text = dr["SupName"].ToString();
                hdnSuperVis.Value = dr["SUPERVISOR"].ToString();
                HdnEmpType.Value = dr["Emptype"].ToString();
            }
        }

        #endregion
        #region StaffReporting

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (staffRptto.Text.Contains("|"))
            {
                string[] splitRptTo = staffRptto.Text.Split('|');
                hdnRptTo.Value = splitRptTo[1];
                if (hdnRptTo.Value == hdnJobHold.Value)
                {
                    string message = "alert('Staff Reporting cannot be Job Holder!')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    staffRptto.Text = string.Empty;
                }
                else
                {
                    string result = _db.InsertTemp(hdnRptTo.Value, ReadSession().Emp_Id.ToString());
                    if (result.Contains("SUCCESS"))
                    {
                        DisplayRpt();
                        staffRptto.Text = string.Empty;
                    }
                }
            }
            else
            {
                LblMsg.Text = "Invalid Name";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void DisplayRpt()
        {
            DataTable dt = _db.GetRptDetails();
            int sno = 1;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th align=\"center\">SNo</th>");
            sb.AppendLine("<th align=\"center\">Staff Name</th>");
            sb.AppendLine("<th align=\"center\">Delete</th>");
            sb.AppendLine("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td align=\"left\">" + sno + "</td>");
                sb.AppendLine("<td align=\"left\">" + dr["name"].ToString() + "</td>");
                sb.AppendLine("<td><a href = \"javascript:void(0)\" onclick = Delete(" + dr["Id"] + ") >Delete</a></td>");
                sb.AppendLine("</tr>");
                sno++;
            }
            sb.AppendLine("</table></div>");
            rptDiv.InnerHtml = sb.ToString();
        }
        protected void hdnBtn_OnClick(object sender, EventArgs e)
        {
            string result = _db.DeleteTemp(hdnDel.Value);
            if (result.Contains("SUCCESS"))
            {
                rptDiv.InnerHtml = "";
                DisplayRpt();
            }
        }
        private void DeleteTemp(string id)
        {
            _db.DeleteTemp(id);
        }
        #endregion
        #region SaveData



        #endregion
        #region ReadDecryptQueryString

        private string GetId()
        {
            string id = string.Empty;
            id = string.IsNullOrEmpty(Request.QueryString["Id"]) ? null : Uri.UnescapeDataString(Crypto(Request.QueryString["Id"], false));
            return id;
        }

        private string GetStatus()
        {
            string status = Uri.UnescapeDataString(Crypto(Request.QueryString["flag"], false));
            return status;
        }

        private string Crypto(string value, bool isEncrypt = true)
        {
            var forReturn = "";
            if (isEncrypt)
                forReturn = Cryptographer.Encrypt(value, Cryptographer.PrivateKey());
            else
                forReturn = Cryptographer.Decrypt(value, Cryptographer.PrivateKey());

            return forReturn;
        }
        #endregion
        #region PopulateData
        private void PopulateData()
        {
            var jobDetails = _db.ReturnData(GetId());
            txtJobHolder.Text = jobDetails.EmpId;
            lblBranch.Text = jobDetails.BranchId;
            lblFuncTitle.Text = jobDetails.FunctionalId;
            lblCorpTitle.Text = jobDetails.PositionId;
            txtSuperVis.Text = jobDetails.SuperVisor;
            startDate.Text = GetStatic.FormatData(jobDetails.StartDate, "D");
            endDate.Text = GetStatic.FormatData(jobDetails.EndDate, "D");
            txtKeyComp.Text = jobDetails.KeyCompetent;
            txtGeneralJd.Text = jobDetails.GeneralJd;
            txtObj.Text = jobDetails.FunctionalObjectives;
            txtDisagree.Text = jobDetails.ServicesJd;

            DataTable dt = _db.GetData(GetId());
            int sno = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th align=\"center\">SNo</th>");
            sb.AppendLine("<th align=\"center\">Staff Name</th>");
            sb.AppendLine("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td align=\"left\">" + sno + "</td>");
                sb.AppendLine("<td align=\"left\">" + dr["RptStaff"].ToString() + "</td>");
                sb.AppendLine("</tr>");
                sno++;
            }
            sb.AppendLine("</table></div>");
            rptDiv.InnerHtml = sb.ToString();


            if (GetStatus() == "PENDING")
            {
                BtnSave.Visible = false;
                txtDisagree.Visible = true;
                txtDisagree.Enabled = false;
                lblDisagree.Visible = true;
                if (jobDetails.Id == ReadSession().Emp_Id)
                {
                    btnAccept.Visible = true;
                    btnUpdate.Visible = false;
                    BtnDelete.Visible = false;
                    btnDisagree.Visible = true;
                    txtDisagree.Enabled = true;
                    DisableTxtFields();
                }
                else

                 if (jobDetails.CreatedBy == ReadSession().Emp_Id)
                {
                    btnAccept.Visible = false;
                    btnUpdate.Visible = true;
                    BtnDelete.Visible = true;
                    txtDisagree.Enabled = false;
                }
                else
                {
                    DisableTxtFields();
                    txtDisagree.Enabled = false;
                }

            }
            if (GetStatus() == "ACCEPTED")
            {
                btnAccept.Visible = false;
                btnDisagree.Visible = false;
                btnAssign.Visible = true;
                if (jobDetails.Id == ReadSession().Emp_Id)
                {
                    btnAssign.Visible = false;
                }
                BtnSave.Visible = false;
                txtDisagree.Visible = false;
                DisableTxtFields();
            }
            if (GetStatus() == "APPROVED")
            {
                btnAccept.Visible = false;
                btnDisagree.Visible = false;
                btnAssign.Visible = false;
                BtnSave.Visible = false;
                txtDisagree.Visible = false;
                DisableTxtFields();
            }
            if (GetStatus() == "DISAGREED")
            {
                txtDisagree.Visible = true;
                lblDisagree.Visible = true;
                txtDisagree.Enabled = false;
                if (jobDetails.Id == ReadSession().Emp_Id)
                {
                    btnAccept.Visible = true;
                    btnUpdate.Visible = false;
                    BtnDelete.Visible = false;
                    txtDisagree.Visible = true;
                    DisableTxtFields();
                }
                else
                if (jobDetails.CreatedBy == ReadSession().Emp_Id)
                {
                    btnAccept.Visible = false;
                    btnUpdate.Visible = true;
                    BtnDelete.Visible = true;
                    txtDisagree.Enabled = false;

                }
                else
                {
                    DisableTxtFields();
                    txtDisagree.Enabled = false;
                }

                btnDisagree.Visible = false;
                btnAssign.Visible = false;
                BtnSave.Visible = false;


            }
        }
        private void DisableTxtFields()
        {
            txtJobHolder.Enabled = false;
            lblBranch.Enabled = false;
            lblFuncTitle.Enabled = false;
            lblCorpTitle.Enabled = false;
            txtSuperVis.Enabled = false;
            startDate.Enabled = false;
            endDate.Enabled = false;
            txtKeyComp.Enabled = false;
            txtGeneralJd.Enabled = false;
            txtObj.Enabled = false;
            staffRptto.Enabled = false;
            BtnSave.Visible = false;
            btnAdd.Visible = false;
            staffRptto.Visible = false;
        }
        #endregion

        private void CheckUnusedStaffRpt()
        {
            _db.RemoveTemp(ReadSession().Emp_Id.ToString());
        }
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            DataTable checkStaffRpt = _db.CheckStaffRpt();
            //if (checkStaffRpt == null || checkStaffRpt.Rows.Count <= 0)
            //{
            //    string message = "alert('Please Add Staffs Reporting!')";
            //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //}
            //else
            //{
            _job.EmpId = hdnJobHold.Value;
            _job.BranchId = hdbBranch.Value;
            _job.PositionId = hdnPosition.Value;
            _job.FunctionalId = hdnFuncTitle.Value;
            _job.SuperVisor = hdnSuperVis.Value;
            _job.StartDate = Convert.ToDateTime(startDate.Text.Trim()).ToString("yyyy-MM-dd");
            _job.EndDate = Convert.ToDateTime(endDate.Text.Trim()).ToString("yyyy-MM-dd");
            _job.KeyCompetent = txtKeyComp.Text;
            _job.FunctionalObjectives = txtObj.Text;
            _job.GeneralJd = txtGeneralJd.Text;
            _job.User = ReadSession().Emp_Id;
            string res = _db.CheckFiscalyear(Convert.ToDateTime(_job.StartDate), _job.EndDate);
            DateTime d1 = Convert.ToDateTime(_job.EndDate);
            DateTime d2 = Convert.ToDateTime(_job.StartDate);

            TimeSpan t = d1 - d2;
            double NrOfDays = t.TotalDays;
            if (HdnEmpType.Value == "558" && NrOfDays > 366)
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Difference of StartDate and EndDate Should not exceed 1 year");
                return;
            }
            if (res.Contains("Invalid") && HdnEmpType.Value != "558")
            {
                GetStatic.SweetAlertErrorMessage(this, "Invalid Date",res);
                return;
            }
            string result = _db.InsertJobDesc(_job);
            if (result.Contains("SUCCESS"))
            {
                LblMsg.Text = result;
                LblMsg.ForeColor = System.Drawing.Color.Green;
                label.Visible = true;
                DisableTxtFields();

                Response.Redirect("JDList.aspx");
            }
            else
            {
              
                GetStatic.SweetAlertErrorMessage(this, "", result.ToString());
                return;
                
            }
            //}
        }
        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/JobDescription/JDList.aspx");
        }
        protected void btnAccept_OnClick(object sender, EventArgs e)
        {
            string res = _db.AcceptJd(GetId());
            if (res.Contains("Accepted"))
            {
                LblMsg.Text = res;
                LblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnAssign_OnClick(object sender, EventArgs e)
        {
            string res = _db.ApproveJd(GetId());
            if (res.Contains("Approved"))
                Response.Redirect("JDList.aspx");
            else
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void endDate_OnTextChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(startDate.Text) > DateTime.Parse(endDate.Text))
            {
                string message = "alert('End Date cannot be less than Start Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                endDate.Text = string.Empty;
            }
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {

            _job.EmpId = hdnJobHold.Value;
            _job.BranchId = hdbBranch.Value;
            _job.PositionId = hdnPosition.Value;
            _job.FunctionalId = hdnFuncTitle.Value;
            _job.SuperVisor = hdnSuperVis.Value;
            _job.StartDate = startDate.Text.Trim();
            _job.EndDate = endDate.Text.Trim();
            _job.KeyCompetent = txtKeyComp.Text;
            _job.FunctionalObjectives = txtObj.Text;
            _job.GeneralJd = txtGeneralJd.Text;
            _job.User = ReadSession().Emp_Id;

            _job.RowId = GetId();

            string res = _db.CheckFiscalyear(Convert.ToDateTime(_job.StartDate), _job.EndDate);
            DateTime d1 = Convert.ToDateTime(_job.EndDate);
            DateTime d2 = Convert.ToDateTime(_job.StartDate);

            TimeSpan t = d1 - d2;
            double NrOfDays = t.TotalDays;
            if (HdnEmpType.Value == "558" && NrOfDays>366)
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Difference of StartDate and EndDate Should not exceed 1 year");
                return;
            }
            if (res.Contains("Invalid") && HdnEmpType.Value != "558")
            {
                GetStatic.SweetAlertErrorMessage(this, "InValid Date",res);
                return;
            }
            string result = _db.UpdateJd(_job);
            if (result.Contains("Updated"))
            {
                LblMsg.Text = result;
                LblMsg.ForeColor = System.Drawing.Color.Green;
                label.Visible = true;
                DisableTxtFields();

                Response.Redirect("JDList.aspx");
            }
            else
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Focus();
            }
        }
        protected void btnDisagree_OnClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDisagree.Text))
            {
                string res = _db.DisagreeJd(GetId(), txtDisagree.Text);
                if (res.Contains("Disagreed"))
                {
                    LblMsg.Text = res;
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("List.aspx");
                }
                else
                {
                    LblMsg.Text = "Error in Operation";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Disagree reason should not be blank");
            }


        }
        protected void BtnDelete_OnClick(object sender, EventArgs e)
        {
            string res = _db.Delete(GetId());

            if (res.Contains("SUCCESS"))
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", "Job Description Deleted Successfully");
                Response.Redirect("JDList.aspx");
            }
            else
            {
                GetStatic.SweetAlertSuccessMessage(this, "Error", "Error while deleting Job description");
                Response.Redirect("JDList.aspx");
            }
        }
    }
}


