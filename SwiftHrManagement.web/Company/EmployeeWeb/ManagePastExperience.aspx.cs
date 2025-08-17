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
    public partial class ManagePastExperience : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManagePastExperience()
        {
            _clsdao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv(); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                if (this.GetEmployeePastID() > 0)
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
            txtLastSalary.Attributes.Add("onblur", "checknumber(this);");
            txtServiceTo.Attributes.Add("onblur", "checkDateFormat(this);");
            txtServiceFrom.Attributes.Add("onblur", "checkDateFormat(this);");

        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected long GetEmployeePastID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void manageitem()
        {
            string strflagflag = "";
            long id = 0;
            id = GetEmployeePastID();
            if (id > 0)
                strflagflag = "u";
            else
                strflagflag = "i";

            _clsdao.runSQL("exec [ProcPastExp] @flag='" + strflagflag + "',@id =" + filterstring(id.ToString()) + ",@EMPLOYEE_ID ='" + txtempid.Value + "',@comp_name=" + filterstring(txtCompanyName.Text) + ", @location=" + filterstring(txtLocation.Text) + ","
               + " @last_designation =" + filterstring(txtLastdesigation.Text) + ",@service_from=" + filterstring(txtServiceFrom.Text) + ",@service_to=" + filterstring(txtServiceTo.Text) + ",@last_salary=" + filterstring(txtLastSalary.Text) + ","
               + " @remarks=" + filterstring(txtRemarks.Text) + "");

        }
        private void populateitem()
        {
            DataTable dt = _clsdao.getDataset("exec ProcPastExp 'S',@id='" + GetEmployeePastID().ToString() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                txtempid.Value = dr["EMPLOYEE_ID"].ToString();
                txtCompanyName.Text = dr["comp_name"].ToString();
                txtLocation.Text = dr["location"].ToString();
                txtLastdesigation.Text = dr["last_designation"].ToString();
                txtServiceFrom.Text = dr["service_from"].ToString();
                txtServiceTo.Text = dr["service_to"].ToString();
                txtLastSalary.Text = dr["last_salary"].ToString();
                txtRemarks.Text = dr["remarks"].ToString();


            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPastExperience.aspx?Id=" + txtempid.Value);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            manageitem();
            Response.Redirect("ListPastExperience.aspx?Id=" + txtempid.Value);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            long id = 0;
            id = GetEmployeePastID();
            _clsdao.runSQL("exec ProcPastExp 'd' ,@id='" + GetEmployeePastID().ToString() + "'");
            Response.Redirect("ListPastExperience.aspx?Id=" + txtempid.Value);
        }

    }
}
