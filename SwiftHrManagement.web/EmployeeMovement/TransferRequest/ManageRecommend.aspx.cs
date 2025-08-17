using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TransferRequest
{
    public partial class ManageRecommend : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}

                OnPopulateDDL();                
                OnPopulateTransfer();
                OnDisabledForm();
                BtnBack.Attributes.Add("onclick", "history.back();return false");
                txtEffectiveDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                txtReportedDate.Attributes.Add("OnBlur", "checkDateFormat(this);");

            }
        }
        private void OnDisabledForm()
        {
            DdlToBranch.Enabled = false;
            DdlToDept.Enabled = false;
            txtRecommendBy.Enabled = false;
            txtTransferDesc.Enabled = false;
        }

        private void OnPopulateDDL()
        {
            _clsDao.CreateDynamicDDl(DdlFromBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlFromDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlFromBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "" + ReadSession().Department + "", "SELECT");
            DdlFromBranch.Enabled = false;
            DdlFromDept.Enabled = false;
            _clsDao.CreateDynamicDDl(DdlToBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
        }

        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }


        private void OnPopulateTransfer()
        {
            _clsDao.CreateDynamicDDl(DdlFromDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            _clsDao.CreateDynamicDDl(DdlToDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");

            DataTable dt = _clsDao.getTable("Exec proc_ManageTransferRequest @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                DdlFromBranch.SelectedValue = dr["FROM_BRANCH"].ToString();
                DdlFromDept.SelectedValue = dr["FROM_DEPARTMENT"].ToString();
                DdlToBranch.SelectedValue = dr["WHICH_BRANCH"].ToString();
                DdlToDept.SelectedValue = dr["WHICH_DEPARTMENT"].ToString();
                txtEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
                txtReportedDate.Text = dr["ACTUAL_REPORT_DATE"].ToString();
                txtTransferDesc.Text = dr["TRANSFER_DESCRIPTION"].ToString();
                //ddlTransferType.Text = dr["TRANSFER_TYPE"].ToString();
                lblRecommendBy.Text = dr["RECOMMEND_BY"].ToString();
            }
        }


        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("Exec proc_ManageTransferRequest @flag='d',"
                       + " @id=" + filterstring(GetId().ToString()) + "");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
        }

        protected void txtRecommendBy_TextChanged(object sender, EventArgs e)
        {
            lblRecommendBy.Text = GetEmpInfoForLabel(txtRecommendBy.Text, lblRecommendBy.Text);
            txtRecommendBy.Text = "";
        }
        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
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

        protected void DdlToBranch_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DdlToDept.Items.Clear();
            if (DdlToBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(DdlToDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlToBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string msg = _clsDao.GetSingleresult("Exec proc_ManageTransferRequest @flag='REC',"
                       + " @id=" + filterstring(GetId().ToString()) + "");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("ListRecommend.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string msg = _clsDao.GetSingleresult("Exec proc_ManageTransferRequest @flag='REJ',"
                       + " @id=" + filterstring(GetId().ToString()) + "");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("ListRecommend.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}