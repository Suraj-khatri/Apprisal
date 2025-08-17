using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.IdCardTypeDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.FileUploader;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageIdentification : BasePage
    {
        IdCardTypeDAO _idCardDao = null;
        IdCardTypeCore _idCardCore = null;
        RoleMenuDAOInv _roleMenuDao = null;
        Employee emp = null;
        EmployeeDAO empdao = null;
        clsDAO _clsDao = null;

        public ManageIdentification()
        {
            this._idCardDao = new IdCardTypeDAO();
            this._idCardCore = new IdCardTypeCore();
            this._roleMenuDao = new RoleMenuDAOInv(); 
            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this._clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.PopulateDdlCardType();
                if (this.GetEmployeeCardID() > 0)
                {
                    this.PopulateIndentification();
                    this.BtnDelete.Visible = true;
                    string msg = _clsDao.GetSingleresult("select file_type from EMPLOYEE_IDENTIFICATION where ID=" + GetEmployeeCardID() + "");
                }
                else
                {
                    this.BtnDelete.Visible = false;
                    this.hdnEmpId.Value = GetEmpId().ToString();                   
                }                
            }
            txtIssueDate.Attributes.Add("onblur","checkDateFormat(this);");
        }

        private void OnDisplayFile()
        {

        }

        private void PopulateDdlCardType()
        {
            string selectValue = "";
            if (DdlCardType.SelectedItem != null)
                selectValue = DdlCardType.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlCardType, "Exec ProcStaticDataView 's','32'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Sorry! Cannot save the details. Please Verify the filled in details.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            //string fileType = "";
            string flag = "i";

            

                if (GetEmployeeCardID() > 0)
                    flag = "u";
                else
                    flag = "i";

                string msg = _clsDao.GetSingleresult("Exec procManageIdentification @flag=" + filterstring(flag) + ",@ID=" + filterstring(GetEmployeeCardID().ToString()) + ","
                            + " @emp_id=" + filterstring(GetEmpId().ToString()) + ", @card_type=" + filterstring(DdlCardType.Text) + ","
                            + " @card_no=" + filterstring(txtCardNo.Text) + ", @issue_place=" + filterstring(txtIssuePlace.Text) + ","
                            + " @issue_date=" + filterstring(txtIssueDate.Text) + ", @expire_date=" + filterstring(txtExpiryDate.Text) + ","
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            Response.Redirect("ListIdentification.aspx?Id=" + GetEmpId() + "");

        }

        private void PopulateIndentification()
        {
            DataTable dt = _clsDao.getDataset(" Exec [procManageIdentification] @flag='s',@id=" + filterstring(GetEmployeeCardID().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                DdlCardType.Text = dr["CARD_TYPE"].ToString();
                txtCardNo.Text = dr["CARD_NO"].ToString();
                txtIssuePlace.Text = dr["ISSUE_PLACE"].ToString();
                txtIssueDate.Text = dr["ISSUE_DATE"].ToString();
                txtExpiryDate.Text = dr["EXPIRY_DATE"].ToString();
            }
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected long GetEmployeeCardID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = _clsDao.GetSingleresult("Exec procManageIdentification @flag='D',@id=" + filterstring(GetEmployeeCardID().ToString()) + "");
                Response.Redirect("ListIdentification.aspx?Id=" + GetEmpId() + "");
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnDelete()
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListIdentification.aspx?Id=" + GetEmpId() + "");
        }       
    }
}
