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

namespace SwiftHrManagement.web.Customer
{
    public partial class Manage : BasePage
    {
        CustomerCore custCore = new CustomerCore();        
        CustomerDao custDAO = new CustomerDao();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        private long GetCustomerId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                    
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 110) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                ChkIsActive.Checked = true;
                long id = GetCustomerId();
                if (id > 0)
                {
                    PopulateCustomerDetails(id);                       
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }            
        }

        private void PopulateCustomerDetails(long id)
        {
            custCore = custDAO.GetCustomerDetailByID(id);
            this.TxtCustName.Text = custCore.CustomerName;
            this.TxtAddress.Text = custCore.CustomerAddress;
            this.TxtTelNo.Text = custCore.CustomerTelNo;
            this.TxtTelNo2.Text = custCore.CustomerTelNoSec;
            this.TxtPANNo.Text = custCore.CustomerPANNo;
            this.TxtFaxNo.Text = custCore.CustomeFax;
            this.TxtContact1.Text = custCore.ContactPersonFirst;
            this.TxtContact2.Text = custCore.ContactPersonSec;
            this.TxtContact3.Text = custCore.ContactPersonThird;
            this.TxtEmail.Text = custCore.CustomerEmail;
            this.TxtWebsite.Text = custCore.CustomerWebsite;
            this.TxtBusinessDetails.Text = custCore.BusinessDetails;
            this.TxtMobile1.Text = custCore.ContPersonMobile1;
            this.TxtEmail1.Text = custCore.ContPersonEmail1;
            this.TxtMobile2.Text = custCore.ContPersonMobile2;
            this.TxtEmail2.Text = custCore.ContPersonEmail2;
            this.TxtMobile3.Text = custCore.ContPersonMobile3;
            this.TxtEmail3.Text = custCore.ContPersonEmail3;
            if (custCore.IsActive == "Y")
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
                manageCustomerDetails();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void manageCustomerDetails()
        {
            long id = GetCustomerId();
            PrepareCustomerDetails();
            if (id > 0)
            {                
                custCore.Id = id;
                custCore.ModifyBy = ReadSession().UserId;
                custDAO.Update(custCore);
            }
            else
            {
                custCore.CreatedBy = ReadSession().UserId;              
                custDAO.Save(custCore);
            }

        }

        private void PrepareCustomerDetails()
        {
            custCore.CustomerName = this.TxtCustName.Text;
            custCore.CustomerAddress = this.TxtAddress.Text;
            custCore.CustomerTelNo = this.TxtTelNo.Text;
            custCore.CustomerTelNoSec = this.TxtTelNo2.Text;
            custCore.CustomerPANNo = this.TxtPANNo.Text;
            custCore.CustomeFax = this.TxtFaxNo.Text;
            custCore.ContactPersonFirst = this.TxtContact1.Text;
            custCore.ContactPersonSec = this.TxtContact2.Text;
            custCore.ContactPersonThird = this.TxtContact3.Text;
            custCore.CustomerEmail = this.TxtEmail.Text;
            custCore.CustomerWebsite = this.TxtWebsite.Text;
            custCore.BusinessDetails = this.TxtBusinessDetails.Text;
            custCore.ContPersonMobile1 = this.TxtMobile1.Text;
            custCore.ContPersonEmail1 = this.TxtEmail1.Text;
            custCore.ContPersonMobile2 = this.TxtMobile2.Text;
            custCore.ContPersonEmail2 = this.TxtEmail2.Text;
            custCore.ContPersonMobile3 = this.TxtMobile3.Text;
            custCore.ContPersonEmail3 = this.TxtEmail3.Text;
            if (ChkIsActive.Checked == true)
            {
                custCore.IsActive = "Y";
            }
            else
            {
                custCore.IsActive = "N";
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                manageCustomerDetails();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                custCore.Id = GetCustomerId();
                custDAO.Delete(custCore);
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
            Response.Redirect("List.aspx");
        }
    }
}
