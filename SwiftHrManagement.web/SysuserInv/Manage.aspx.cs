using System;
using System.Threading;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.SysuserInv
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsDao = null;
        public Manage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsDao = new clsDAO();
        }

        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            bool capsLock = Console.CapsLock;
            Console.WriteLine(capsLock);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetUserId().ToString() != "")
                {
                    string id = StringEncryption.Decrypt(this.GetUserId().ToString());
                    
                    if (id != "")
                    {
                        this.populateUser(id);
                        this.txtEmployee.Enabled = false;
                        this.TxtUsername.Enabled = false;
                        this.TxtPassword.Text = "";
                        this.BtnDelete.Visible = true;
                        this.BtnBack.Visible = true;
                    }
                }
                
                else
                {
                    this.BtnDelete.Visible = false;
                    this.BtnBack.Visible = false;
                }
            }
        }
        

        private void populateUser(string id)
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec [ProcManageUser] @flag='s',@user_id=" + filterstring(id) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtUsername.Text = dr["UserName"].ToString(); 
                lblEmpName.Text = dr["emp_name"].ToString();
                DdlUserType.SelectedValue = dr["user_type"].ToString();
                if (dr["status"].ToString() == "Y")
                {
                    this.Chkstatus.Checked = true;
                }
                else
                {
                    this.Chkstatus.Checked = false;
                }
            }
        }


        private string GetUserId()
        {
            return Request.QueryString["Admin_Id"] != null ? Uri.UnescapeDataString(Request.QueryString["Admin_Id"].ToString()) : "";
        }
        private void ManageUser()
        {
            if (lblEmpName.Text != "")
            {
                string id = StringEncryption.Decrypt(this.GetUserId().ToString());
                //long Id = this.GetUserId();
                string isActive = "";
                string msg = "";
                if (Chkstatus.Checked == true)
                {
                    isActive = "Y";
                }
                else
                {
                    isActive = "N";
                }
                if (id == "")
                {
                    //msg = _clsDao.GetSingleresult("Exec [proc_passwordPolicy] @flag='u',@user_id=" + filterstring(GetUserId().ToString()) + ","
                    //        + " @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).Trim()) + ",@user_name=" + filterstring(TxtUsername.Text) + ","
                    //        + " @user_password=" + filterstring(TxtPassword.Text) + ",@user_type=" + filterstring(DdlUserType.Text) + ","
                    //        + " @status=" + filterstring(isActive) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
                    msg = _clsDao.GetSingleresult("Exec [ProcManageUser] @flag='i',"
                            + " @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ",@user_name=" + filterstring(TxtUsername.Text) + ","
                            + " @user_password=" + filterstring(TxtPassword.Text) + ",@user_type=" + filterstring(DdlUserType.Text) + ","
                            + " @status=" + filterstring(isActive) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
                }
                else
                {
                    msg = _clsDao.GetSingleresult("Exec [ProcManageUser] @flag='u',@user_id=" + filterstring(id) + ","
                           + " @emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).Trim()) + ",@user_name=" + filterstring(TxtUsername.Text) + ","
                           + " @user_password=" + filterstring(TxtPassword.Text) + ",@user_type=" + filterstring(DdlUserType.Text) + ","
                           + " @status=" + filterstring(isActive) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
                    
                }
                if (msg.Contains("SUCCESS"))
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                LblMsg.Text = "Please choose employee full name!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ManageUser();                
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("Exec [ProcManageUser] @flag='d',@user_id=" + filterstring(StringEncryption.Decrypt(GetUserId().ToString())) + "");
                Response.Redirect("/SysuserInv/List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SysuserInv/List.aspx");
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
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
    }
}
