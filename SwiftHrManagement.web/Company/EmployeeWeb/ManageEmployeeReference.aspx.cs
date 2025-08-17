using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageEmployeeReference : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null; 
         clsDAO _clsdao = null;
         public ManageEmployeeReference()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv(); 
        }     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                if (this.GetEmployeeReferenceID() > 0)
                {
                    BtnDelete.Visible = true;
                    populateitem();
                }
                else
                {
                    BtnDelete.Visible = false;
                    txtempid.Value = GetEmpId().ToString();
                }
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
            txtfaxNo. Attributes.Add("onblur", "checknumber(this);");
            txtHomepne. Attributes.Add("onblur", "checknumber(this);");
            txtMobileNo. Attributes.Add("onblur", "checknumber(this);");
            txtOfficepne. Attributes.Add("onblur", "checknumber(this);");


        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetEmployeeReferenceID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void manageitem()
        {
            string strflagflag = "";
            long id = 0;
            id = GetEmployeeReferenceID();
            if (id > 0)
                strflagflag = "u";
            else
                strflagflag = "i";

            _clsdao.runSQL("exec [proc_emprefrences] @flag='" + strflagflag + "',@id =" + filterstring(id.ToString()) + ",@EMPLOYEE_ID ='" + txtempid.Value + "',@full_name=" + filterstring(txtFullName.Text) + ", @address=" + filterstring(txtAddress.Text) + ","
               + " @homephone =" + filterstring(txtHomepne.Text) + ",@officephone=" + filterstring(txtOfficepne.Text) + ",@mobile=" + filterstring(txtMobileNo.Text) + ",@fax=" + filterstring(txtfaxNo.Text) + ","
               + " @email=" + filterstring(txtEmail.Text) + "");

        }
        private void populateitem()
        {
            DataTable dt = _clsdao.getTable("exec proc_emprefrences 's',@id='" + GetEmployeeReferenceID().ToString() + "'");

            foreach (DataRow dr in dt.Rows)
            {
                txtempid.Value = dr["EMPLOYEE_ID"].ToString();
                txtFullName.Text = dr["Full_Name"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtHomepne.Text = dr["home_phone"].ToString();
                txtOfficepne.Text = dr["office_phone"].ToString();
                txtMobileNo.Text = dr["mobile"].ToString();
                txtfaxNo.Text = dr["fax"].ToString();
                txtEmail.Text = dr["email"].ToString();


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            manageitem();
            Response.Redirect("ListEmployeeReferience.aspx?Id=" + txtempid.Value);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            long id = 0;
            id = GetEmployeeReferenceID();
            _clsdao.runSQL("exec proc_emprefrences 'd' ,@id='" + GetEmployeeReferenceID().ToString() + "'");
            Response.Redirect("ListEmployeeReferience.aspx?Id=" + txtempid.Value);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListEmployeeReferience.aspx?Id=" + txtempid.Value);
        }
    }
}
