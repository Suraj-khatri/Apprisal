using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.PayableDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManagePayable : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        PayableDAO _payableDAO = null;
        clsDAO swift = new clsDAO();
        string[] payableHead;
        string[] payableValue;
        string option = "";
        public ManagePayable()
        {
            swift = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this._payableDAO = new PayableDAO();
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAddForm();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx?flag=y");
                }
                if (GetPayableId() > 0)
                {
                    ShowEditForm();
                    PopulateDataById();
                    BtnDelete.Visible = true;
                    AddSingleBenefit.Visible = false;
                    txtBenefit.Enabled = false;
                    txtAppliedDate.Enabled = false;
                    txtEffecctiveDate.Enabled = false;
                }
                else
                {
                    SetDDL("");
                    lblEffectiveUpto.Visible = false;
                    txtEffectiveUpto.Visible = false;
                    
                }
                head.Visible = false;
            }
            if (Request.Form["payableHead"] != null || Request.Form["payableValue"] != null)
            {
                payableHead = Request.Form["payableHead"].Split(',');
                payableValue = Request.Form["payableValue"].Split(',');
            }
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetPayableId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void ShowAddForm()
        {
            txtBenefit.Visible = false;
            lblBenefit.Visible = false;
            BtnSearch.Visible = true;
            ddlChooseSet.Visible = true;
            lblChooseSet.Visible = true;
            asterisk.Visible = true;
        }
        private void ShowEditForm()
        {
            txtBenefit.Visible = true;
            lblBenefit.Visible = true;
            BtnSearch.Visible = false;
            ddlChooseSet.Visible = false;
            lblChooseSet.Visible = false;
            asterisk.Visible = false;
        }
        private void PopulateDataById()
        {
            var _payable = _payableDAO.FindById(GetPayableId());
            if (_payable == null)
                return;
            txtBenefit.Text = _payable.Amount.ToString();
            lblBenefit.Text = _payable.BenefitType;
            txtEffecctiveDate.Text = _payable.EffectiveDate;
            txtAppliedDate.Text = _payable.AppliedDate;
            txtEffectiveUpto.Text = _payable.EffectiveUpto;
        }
        private void ManagePay()
        {
            if (GetPayableId() > 0)
            {
                var _payable = new PayableCore();
                _payable.Id = GetPayableId();
                _payable.Amount = Convert.ToInt32(txtBenefit.Text);
                _payable.EffectiveDate = txtEffecctiveDate.Text;
                _payable.AppliedDate = txtAppliedDate.Text;
                _payable.EffectiveUpto = txtEffectiveUpto.Text;
                _payableDAO.Update(_payable);
            }
            else
            {
                var dt = _payableDAO.Insert(GetEmpId().ToString(), txtEffecctiveDate.Text, txtAppliedDate.Text, ddlChooseSet.Text, DdlBenefitHead.Text, txtAmount.Text, ReadSession().UserId);
            }
        }

        private bool checkHeadAssign(string pHead)
        {
            var sql = "SELECT 'X' FROM Payable WHERE BENEFIT_ID IN (" + pHead + ") AND EMPLOYEE_ID=" + GetEmpId();
            return swift.CheckStatement(sql);

        }

        private  void  SetDDL(string selectValue)
        {
            var sql = @"SELECT salarySetMasterId,sdd.DETAIL_DESC setName
                        FROM salarySetMaster SM 
                        INNER JOIN StaticDataDetail sdd ON SM.Salary_Title=Sdd.ROWID
                        INNER JOIN Employee E ON SM.Salary_Title=E.Salary_Title 
                        WHERE E.EMPLOYEE_ID=" + GetEmpId() + "";
            swift.setDDL(ref ddlChooseSet, sql, "salarySetMasterId", "setName", selectValue, "SELECT");

            
        }
        private  void FindSetName()
        {
            var sql = "SELECT top(1)p.set_id FROM Payable p  INNER JOIN salarySetMaster sm ON p.set_id = sm.salarySetMasterId WHERE set_id = "+GetSetId();
            string setId = swift.GetSingleresult(sql);
            SetDDL(setId);
        }

        private long GetSetId()
        {

            var sql = "SELECT TOP(1) isnull(set_id,'') setId from Payable where EMPLOYEE_ID = " + GetEmpId();
            string rowId = swift.GetSingleresult(sql);
            if (rowId == "")
                return 0;
            return long.Parse(rowId);
        }

        private bool checkmultiple()
        {
            return _payableDAO.checkmultiple(GetEmpId(),long.Parse(ddlChooseSet.Text));
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
                {
                    ManagePay();
                    lblTransactionMessage.Text = "Operation Completed Successfully";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListPayable.aspx?Id=" + GetEmpId()+ "");                   
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            DisplaySalaryHead();
        }
        
        private  void DisplaySalaryHead()
        {
            DataTable dt = null;
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            if(GetPayableId() == 0)
            {
                dt = _payableDAO.FindPayableHeadAllByIdSet(ddlChooseSet.Text, GetEmpId().ToString());
 
            }

          
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {

                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                   

                }
                str.Append("<td align=\"left\"><img ><input type=\"text\" id =\"payableHead_" + dr["head_id"] + "\" name =\"payableHead\" value=\"" + dr["head_id"] + "\" style=\"display:none\" /></td>");
                str.Append("<td align=\"left\"><input type=\"text\" id =\"payableValue_" + dr["head_id"] + "\" name =\"payableValue\" value=\"" + dr["Amount"] + "\" style=\"display:none\" /></td>");

                str.Append("</tr>");
            }
            str.Append("</table>");
          


        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/ListPayable.aspx?Id=" + GetEmpId() + "");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _payableDAO.Deletepayable(GetPayableId(), ReadSession().UserId);

                Response.Redirect("/Company/EmployeeWeb/ListPayable.aspx?Id=" + GetEmpId() + "");
            }
            catch
            {
                lblTransactionMessage.Text = "Error in operaton";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void chkAddBenefit_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAddBenefit.Checked == true)
            {
                head.Visible = true;
                option = "Yes";
            }
            else
            {
                head.Visible = false;
                option = "No";
            }
            
        }

        protected void ddlChooseSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql1 = @"EXEC [procManageGradeSetup] @flag='head',@salarySetId=" + filterstring(ddlChooseSet.Text) + "";

            swift.setDDL(ref DdlBenefitHead, sql1, "BENEFIT_ID", "benefit_name", "", "SELECT");
        }
    }
}