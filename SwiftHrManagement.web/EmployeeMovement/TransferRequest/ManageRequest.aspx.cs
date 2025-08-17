using System;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TransferRequest
{
    public partial class ManageRequest : BasePage
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


                if (this.GetId() > 0 && GetStatus()=="Requested")
                {

                    BtnDelete.Visible = true;
                    OnPopulateTransfer();
                }
                else if (this.GetId() > 0 && GetStatus() != "Requested")
                {

                    BtnDelete.Visible = true;
                    OnPopulateTransfer();
                    Btn_Save.Visible = false;
                    BtnDelete.Visible = false;
                }
                else
                {
                    BtnDelete.Visible = false;
                }

                BtnBack.Attributes.Add("onclick", "history.back();return false");
                txtEffectiveDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                txtReportedDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                
            }
        }
        private string GetStatus()
        {
            return (_clsDao.GetSingleresult("select STATUS from ExternalTransferPlan where ID=" + GetId() + ""));
        }
        private void OnPopulateDDL()
        {
            _clsDao.CreateDynamicDDl(DdlFromBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", ""+ReadSession().Branch_Id+"", "SELECT");
            _clsDao.CreateDynamicDDl(DdlFromDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlFromBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "" + ReadSession().Department + "", "SELECT");
           
            string subdepart = _clsDao.GetSingleresult("SELECT SUB_DEPARTMENT FROM EMPLOYEE WHERE EMPLOYEE_ID = "+ReadSession().Emp_Id+"");
            if (!string.IsNullOrEmpty(subdepart))
            {
                  deptsub.Visible = true;
                  _clsDao.CreateDynamicDDl(ddlSubdept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments where DEPARTMENT_ID = " + subdepart + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "" + subdepart + "", "SELECT");
                  ddlSubdept.Enabled = false;
            }
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
            _clsDao.CreateDynamicDDl(DdlToSubDept, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");

            DataTable dt = _clsDao.getTable("Exec proc_ManageTransferRequest @flag='s',@id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                    DdlFromBranch.SelectedValue = dr["FROM_BRANCH"].ToString();
                    DdlFromDept.SelectedValue = dr["FROM_DEPARTMENT"].ToString();
                    DdlToBranch.SelectedValue = dr["WHICH_BRANCH"].ToString();
                    DdlToSubDept.SelectedValue = dr["WHICH_SUBDEPARTMENT"].ToString();
                    DdlToDept.SelectedValue = dr["WHICH_DEPARTMENT"].ToString();
                    txtEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
                    txtReportedDate.Text = dr["ACTUAL_REPORT_DATE"].ToString();
                    txtTransferDesc.Text = dr["TRANSFER_DESCRIPTION"].ToString();
                    //ddlTransferType.Text = dr["TRANSFER_TYPE"].ToString();
                    lblRecommendBy.Text = dr["RECOMMEND_BY"].ToString();
            }               
        }

        
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string empid = getEmpIdfromInfo(lblRecommendBy.Text);
                if (empid == "0")
                {
                    lblmsg.Text = "Please select employee for recommendation!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    OnSave();
                }
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string flag = "";
            if (GetId() > 0)
                flag = "u";
            else
                flag = "i";

            
            string msg = _clsDao.GetSingleresult("Exec proc_ManageTransferRequest @flag="+filterstring(flag)+","
                       // + " @id="+filterstring(GetId().ToString())+",@transfer_type="+filterstring(ddlTransferType.Text)+","
                        + " @id=" + filterstring(GetId().ToString()) + ","
                        + " @emp_id=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@from_branch="+filterstring(DdlFromBranch.Text)+","
                        + " @from_dept=" + filterstring(DdlFromDept.Text) + ",@to_branch=" + filterstring(DdlToBranch.Text) + ","
                        + " @from_subdept=" + filterstring(ddlSubdept.SelectedValue) + ",@to_subdept=" + filterstring(DdlToSubDept.SelectedValue) + ","
                        + " @to_dept=" + filterstring(DdlToDept.Text) + ",@effective_date="+filterstring(txtEffectiveDate.Text)+","
                        + " @actual_report_date=" + filterstring(txtReportedDate.Text) + ",@desc="+filterstring(txtTransferDesc.Text)+","
                        + " @recommend_by=" + filterstring(getEmpIdfromInfo(lblRecommendBy.Text)) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
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
                _clsDao.CreateDynamicDDl(DdlToSubDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlToBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
            }
        }
    }
}