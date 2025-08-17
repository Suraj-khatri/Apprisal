using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class EmployeeAllInfo : BasePage
    {
        protected string empId = "";
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsDao = new clsDAO();
        public EmployeeAllInfo()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetFlag() == "IPR")
                    empSearchPanel.Visible = false;
                else
                    empSearchPanel.Visible = true;  

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false && _RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (getMsg() == "a")
                {
                    lblmsg.Text = "Sorry, Invalid Employee For Search!";
                }
                else
                {
                    lblmsg.Text = "";
                }

                
                empId = Crypto(GetEmployeeId(),false);
                //empId = GetEmployeeId();
                getemployee(empId);
            }
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text.Contains("|"))
            {
                string[] a = txtEmpName.Text.Split('|');
                string empId = a[1];
                string msg = _clsDao.GetSingleresult("EXEC ProcCheckEmployee @FLAG='i',@EMPLOYEE_ID=" + filterstring(empId.ToString()) + "");
                if (msg == "1")
                {
                    var en = Crypto(empId);
                    en = Uri.EscapeDataString(en);
                    Response.Redirect("EmployeeAllInfo.aspx?ID=" + en + "");
                }
                else
                {
                    lblmsg.Text = "Sorry, Invalid Employee For Search!";
                    lblmsg.Focus();
                    return;
                }
            }
            else
            {
                Response.Redirect("EmployeeAllInfo.aspx?ID=" + GetEmployeeId() + "&msg=a");
            }

        }
        public string GetFlag()
        {
            return (Request.QueryString["FLAG"] == null ? "" : Request.QueryString["FLAG"].ToString());
        }
        public string getMsg()
        {
            return (Request.QueryString["msg"] == null ? "" : Request.QueryString["msg"].ToString());
        }
        public string GetEmployeeId()
        {
            return (Request.QueryString["Id"] != null ? Uri.UnescapeDataString(Request.QueryString["Id"].ToString()) : "");
        }
        private void getemployee(string empid)
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(int.Parse(empid));
            LblEmpName.Text = "Employee Name : " + _empcore.EmpName;
        }
    }
}
