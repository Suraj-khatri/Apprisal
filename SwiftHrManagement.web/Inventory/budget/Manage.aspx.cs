using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL.Customer;

namespace SwiftHrManagement.web.Inventory.Budget
{
    public partial class Manage : BasePage
    {
        CustomerCore custCore = new CustomerCore();
        CustomerDao custDAO = new CustomerDao();
        clsDAO _clsdao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        private long GetBudgetId() 
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 241) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                long id = GetBudgetId();
                if (id > 0)
                {
                    PopulateBudgetDetails(id);
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }

        private void GetData()
        {
            _clsdao.CreateDynamicDDl(DdlFY, "SELECT FISCAL_YEAR_NEPALI FROM FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "SELECT");
            DdlFY.SelectedValue = _clsdao.GetSingleresult("SELECT FISCAL_YEAR_NEPALI FROM FiscalYear WHERE FLAG=1");
            _clsdao.CreateDynamicDDl(DdlBranchType, "EXEC [procGetBranchList] @flag='I'", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");   
        }

        private void PopulateBudgetDetails(long id) 
        {
            custCore = custDAO.GetBudgetDetailByID(id);
            product.Text = _clsdao.GetSingleresult(" SELECT porduct_code +'|' + CAST(id AS VARCHAR)  FROM IN_PRODUCT where id='" + custCore.Product + "'").ToString();
            hdnProductId.Value = _clsdao.GetSingleresult(" SELECT CAST(id AS VARCHAR)  FROM IN_PRODUCT where id='" + custCore.Product + "'").ToString();
            DdlFY.SelectedValue= custCore.FiscalYear;
            DdlBranchType.SelectedValue =  custCore.Branch; 
            TxtTelNo.Text= custCore.Qty; 
            TxtFaxNo.Text= custCore.Price;
            TxtBusinessDetails.Text= custCore.Remarks;

            if (custCore.IsActive == "Active")
            {
                ChkIsActive.Checked = true;
            }
            else
            {
                ChkIsActive.Checked = false;
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                manageBudgetDetails();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void manageBudgetDetails() 
        {
            long id = GetBudgetId();
            PrepareCustomerDetails();
            if (id > 0)
            {
                custCore.Id = id;
                custCore.ModifyBy = ReadSession().UserId;
                custDAO.UpdateBudget(custCore);
            }
            else
            {
                custCore.CreatedBy = ReadSession().UserId;
                custDAO.SaveBudget(custCore);
            }

        }

        private void PrepareCustomerDetails()
        {
            custCore.Product = this.hdnProductId.Value;
            custCore.FiscalYear = this.DdlFY.SelectedValue;
            custCore.Branch = this.DdlBranchType.SelectedValue;
            custCore.Qty = this.TxtTelNo.Text;
            custCore.Price = this.TxtFaxNo.Text;
            custCore.Remarks = this.TxtBusinessDetails.Text;
            custCore.CustomerName = ReadSession().Emp_Id.ToString();
            if (ChkIsActive.Checked == true)
            {
                custCore.IsActive = "Active";
            }
            else
            {
                custCore.IsActive = "InActive";
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                manageBudgetDetails();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void product_TextChanged(object sender, EventArgs e)
        {
            if (product.Text.Contains('|'))
            {
                LblMsg.Text = "";
                int itemID = 0;
                string[] item = product.Text.Split('|');
                itemID = int.Parse(item[1]);
                hdnProductId.Value = itemID.ToString();
            }
            else
            {
                LblMsg.Text = "Please choose valid product!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                product.Focus();

            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                custCore.Id = GetBudgetId();
                custDAO.DeleteBudget(custCore);
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inventory/Budget/List.aspx");
        }

    }
}
