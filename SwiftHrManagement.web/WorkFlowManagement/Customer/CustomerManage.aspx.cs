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
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.web.WorkFlowManagement.Customer
{
    public partial class CustomerManage : BasePage
    {
        CustomerCore custCore = new CustomerCore();
        WFCustomerDAO custDAO = new WFCustomerDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        private long GetCustomerId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 85) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                    long id = GetCustomerId();
                    if (id > 0)
                    {
                        PopulateCustomerDetails(id);
                        Btn_Save.Visible = false;
                    }
                    else
                    {
                        Btn_Update.Visible = false;
                        BtnDelete.Visible = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void PopulateCustomerDetails(long id)
        {            
            custCore = custDAO.GetCustomerDetailByID(id);
            this.TxtCustCode.Text = custCore.CustomerCode;
            this.TxtCustName.Text = custCore.CustomerName;
            this.TxtAddress.Text = custCore.CustomerAddress;
            this.TxtTelNo.Text = custCore.CustomerTelNo;
            this.TxtTelNo2.Text = custCore.CustomerTelNoSec;
            this.TxtMobileNo.Text = custCore.CustomerMobileNo;
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
            //
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            
            try
            {
                manageCustomerDetails();
                Response.Redirect("CustomerList.aspx");
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


            if (id > 0)
            {
                PrepareCustomerDetails();
                custCore.Id = id;
                custDAO.Update(custCore);
            }
            else
            {
                PrepareCustomerDetails();
                custDAO.Save(custCore);
            }

        }

        private void PrepareCustomerDetails()
        {
            custCore.CustomerCode = this.TxtCustCode.Text;
            custCore.CustomerName = this.TxtCustName.Text;
            custCore.CustomerAddress = this.TxtAddress.Text;
            custCore.CustomerTelNo = this.TxtTelNo.Text;
            custCore.CustomerTelNoSec = this.TxtTelNo2.Text;
            custCore.CustomerMobileNo = this.TxtMobileNo.Text;
            custCore.CustomeFax = this.TxtFaxNo.Text;
            custCore.ContactPersonFirst = this.TxtContact1.Text;
            custCore.ContactPersonSec =  this.TxtContact2.Text;
            custCore.ContactPersonThird = this.TxtContact3.Text;
            custCore.CustomerEmail= this.TxtEmail.Text;
            custCore.CustomerWebsite = this.TxtWebsite.Text;
            custCore.BusinessDetails = this.TxtBusinessDetails.Text;
            //custCore.FacilityDetails = this.TxtFacilityDetails.Text; 
           
            //
            custCore.ContPersonMobile1 = this.TxtMobile1.Text;
            custCore.ContPersonEmail1 = this.TxtEmail1.Text;
            custCore.ContPersonMobile2 = this.TxtMobile2.Text;
            custCore.ContPersonEmail2 = this.TxtEmail2.Text;
            custCore.ContPersonMobile3 = this.TxtMobile3.Text;
            custCore.ContPersonEmail3 = this.TxtEmail3.Text;                                   
            //
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                manageCustomerDetails();
                Response.Redirect("CustomerList.aspx");
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
                Response.Redirect("CustomerList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }
    }
}
