using System;
using System.Data;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class ReviewInitiation : BasePage
    {       
        PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ReviewInitiation()
        {
            _Obj = new PerformanceAgreementDao();  
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AutoCompleteExtender3.ContextKey = ReadSession().Emp_Id.ToString();
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1116) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            appraisalStartDate.Attributes.Add("readonly", "readonly");
            appraisalEndDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                SetDetails();
               
            }
           
        }
        private void SetDetails()
        {
            hdnEmpName.Value = GetEmpID();
            
            if (!string.IsNullOrWhiteSpace(hdnEmpName.Value))
            {
                saveBtn.Text = "Update";
                txtEmployee.Enabled = false;
                deleteBtn.Visible = true;
                PopulateDataByEmployeeId();
                SetAutority();
            }
           
        }
       
        private void PopulateDataByEmployeeId()
        {

            var res = _Obj.SelectByIdPerformance(hdnEmpName.Value, GetAppID().ToString(),ReadSession().Emp_Id.ToString());
            if (res == null)
                return;

            lblEmpName.Text = res["EMPNAME"].ToString();

            currentBranchId.Text = res["BRANCH_NAME"].ToString();
            currDeptId.Text = res["DEPARTMENT_NAME"].ToString();
            currSubDeptID1.Text = res["SUBDEPARTMENT_NAME"].ToString();
            //currSubDeptID2.Text = res["SUBDEPARTMENT_NAME2"].ToString();

            //currSubDeptID.Visible = !string.IsNullOrWhiteSpace(res["SUBDEPARTMENT_NAME"].ToString());

            currFuncTitle.Text = res["FunctionalTitle"].ToString();
            currPosition.Text = res["CURRPOSITION"].ToString();
            joiningDate.Text = res["joiningDate"].ToString();
            timeSpentInTheCurrentBranchDept.Text = res["timeSpentOnCurrBranch"].ToString();
            timeSpentInTheCurrentPosition.Text = res["timeSpentOnCurrPosition"].ToString();
            supervisorId.Text = res["supervisorName"].ToString();
            hdnSupervisorId.Value = res["supervisorId"].ToString();
            reviewerId.Text = res["reviewerName"].ToString();
            hdnReviewerId.Value = res["reviewerId"].ToString();
            appraisalStartDate.Text = res["appraisalStartDate"].ToString();
            appraisalEndDate.Text = res["appraisalEndDate"].ToString();
            EmpType.Value = res["Emptype"].ToString();

            
        }
        private void SetAutority()
        {
            string empid = ReadSession().Emp_Id.ToString();
            if (hdnSupervisorId.Value == empid)
            {
                saveBtn.Visible = true;
                deleteBtn.Visible = true;
            }
            else
            {
                saveBtn.Visible = false;
                deleteBtn.Visible = false;
            }
        }
        private string GetEmpID()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("empId", "")))
            {
                return Crypto(GetStatic.ReadQueryString("empId", ""), false);
            }
            return "";
        }
        private string GetAppID()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("appId", "")))
            {
                return Crypto(GetStatic.ReadQueryString("appId", ""), false);
            }
            return "";
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
        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            PopulateDataById();
        }
        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }
        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }
        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hdnEmpName.Value))
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Please select Employee from Auto Complete");
                return;
            }
           
            string res = _Obj.CheckFiscalyear(Convert.ToDateTime(appraisalStartDate.Text), (Convert.ToDateTime(appraisalEndDate.Text)));
           
            if (res.Contains("Invalid") && EmpType.Value != "558")
            {
                GetStatic.SweetAlertErrorMessage(this, "Invalid Date", res);
                return;
            }
            DbResult dbResult = _Obj.ReviewInitiation(ReadSession().Emp_Id.ToString(), ReadSession().Sessionid, filterstring(hdnEmpName.Value), hdnBrachId.Value, hdnDeptId.Value, hdnSubDeptId.Value, hdnSubDeptId2.Value, hdnPositionId.Value, hdnFunctionalTitle.Value, joiningDate.Text, hdnSupervisorId.Value, hdnReviewerId.Value, appraisalStartDate.Text, appraisalEndDate.Text, hdnLastPromotedDate.Value, saveBtn.Text,GetAppID());

            if (dbResult.ErrorCode == "0")
            {
                GetStatic.SetMessage(dbResult);
                Response.Redirect("ReviewInitiationList.aspx");
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", dbResult.Msg);
            }
        }
        private void PopulateDataById()
        {
            DataRow dr = _Obj.SelectById(ReadSession().UserName, filterstring(getEmpIdfromInfo(lblEmpName.Text)));
            if (dr == null)
                return;
            AutoCompleteExtender1.ContextKey = dr["empId"].ToString();
            currentBranchId.Text = dr["curBranch"].ToString();
            currDeptId.Text = dr["curDept"].ToString();
            currSubDeptID1.Text = dr["curSubDept"].ToString();
            //currSubDeptID2.Text = dr["curSubDept2"].ToString();

            // currSubDeptID1.Visible = !string.IsNullOrWhiteSpace(dr["curSubDept"].ToString());
            EmpType.Value = dr["EmpType"].ToString();
            currFuncTitle.Text = dr["FunctionalTitle"].ToString();
            currPosition.Text = dr["currPosition"].ToString();
            joiningDate.Text = dr["joiningDate"].ToString();
            timeSpentInTheCurrentBranchDept.Text = dr["timeSpentOnCurrBranch"].ToString();
            timeSpentInTheCurrentPosition.Text = dr["timeSpentOnCurrPosition"].ToString();

            hdnDeptId.Value = dr["curDeptId"].ToString();
            hdnFunctionalTitle.Value = dr["functionalId"].ToString();
            hdnSubDeptId.Value = dr["curSubDeptId"].ToString();
            hdnSubDeptId2.Value = dr["curSubDeptId2"].ToString();
            hdnPositionId.Value = dr["currpositionId"].ToString();
            hdnOldPositionId.Value = dr["oldpositionId"].ToString();
            hdnOldBrachId.Value = dr["oldBranchID"].ToString();
            hdnBrachId.Value = dr["currBranchId"].ToString();
            hdnLastPromotedDate.Value = dr["lastPromotedDate"].ToString();
            
        }
        protected void deleteBtn_OnClick(object sender, EventArgs e)
        {
            var dbResult = _Obj.DeleteAppraisalInitiatedRecord(hdnEmpName.Value,GetAppID());
            if (dbResult.ErrorCode == "0")
            {
                GetStatic.SetMessage(dbResult);
                Response.Redirect("ReviewInitiationList.aspx");
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", dbResult.Msg);
            }
        }
        protected void cancelBtn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ReviewInitiationList.aspx");
        }
        protected void supervisorId_OnTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supervisorId.Text))
            {
                reviewerId.Enabled = true;
                AutoCompleteExtender2.ContextKey = hdnSupervisorId.Value;
            }
        }


    }
}