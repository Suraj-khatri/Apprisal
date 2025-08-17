using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.DepartmentWeb
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        DepartmentDAO departmentdao = null;
        DepartmentCore department = null;
        clsDAO _clsDao = null;
        public Manage()
        {
            this._clsDao = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this.departmentdao = new DepartmentDAO();
            this.department = new DepartmentCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 7) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                string selectValue = "";
                if (DdlDeptName.SelectedItem != null)
                    selectValue = DdlDeptName.SelectedItem.Value.ToString();
                clsDAO swift = new clsDAO();
                swift.setDDL(ref DdlDeptName, "Exec ProcStaticDataView 's','7'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
                this.AddBranch();
                if (this.GetBranchId() != "")
                    this.PopulateBranch();
            }
        }


        private string CheckSpaces(string value1)
        {
            string res = value1;
            if (value1.Contains(" "))
            {
                res = value1.Replace(" ", "+");
            }
            return res;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg="";
                if (GetBranchId() != "")
                {
                    msg=_clsDao.GetSingleresult("Exec ProcManageDepartment 'u'," + filterstring(ddlbranchname.Text) + "," + filterstring(txtDeptShortname.Text) + "," + filterstring(DdlDeptName.Text) + ","
                + " " + filterstring(StringEncryption.Decrypt(GetBranchId().ToString())) + "," + filterstring(ReadSession().UserId) + "");
                }
                else
                {
                    msg = _clsDao.GetSingleresult("Exec ProcManageDepartment 'i'," + filterstring(ddlbranchname.Text) + "," + filterstring(txtDeptShortname.Text) + "," + filterstring(DdlDeptName.Text) + ","
                + " null," + filterstring(ReadSession().UserId) + "");
                }
                if (msg.Contains("SUCCESS!"))
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    lblmsg.Text = msg;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                lblmsg.Text = "Error In Insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        private string GetBranchId()
        {
            //return Request.QueryString["Id"] != null ? HttpServerUtility.UrlTokenDecode(Request.QueryString["Id"].ToString()) : "";
            return Request.QueryString["Id"] != null ? Request.QueryString["Id"] : "";
        }
        private void PopulateBranch()
        {
            DataTable dt = new DataTable();

            dt = _clsDao.getDataset("SELECT DEPARTMENT_ID,BRANCH_ID,DEPARTMENT_SHORT_NAME,STATIC_ID FROM DEPARTMENTS"
            + " WHERE DEPARTMENT_ID = " + StringEncryption.Decrypt(GetBranchId()) + "").Tables[0];
            
            foreach (DataRow dr in dt.Rows)
            {
                ddlbranchname.Text = dr["BRANCH_ID"].ToString();
                txtDeptShortname.Text = dr["DEPARTMENT_SHORT_NAME"].ToString();
                DdlDeptName.Text = dr["STATIC_ID"].ToString();
            }
        }

        private void AddBranch()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "Select";
                branchlist.Insert(0, DefaultBrn);
                this.ddlbranchname.DataSource = branchlist;
                this.ddlbranchname.DataTextField = "Name";
                this.ddlbranchname.DataValueField = "Id";            
                this.ddlbranchname.DataBind();
                this.ddlbranchname.SelectedIndex = 0;
            }
        }
        private void ManageDepartments()
        {
            string id = StringEncryption.Decrypt(this.GetBranchId());
            this.PrepareDepartments();
            if (id != "")
            {
                this.department.ModifyBy = this.ReadSession().UserId;
                this.departmentdao.Update(this.department);
            }
            else
            {
                this.department.CreatedBy = this.ReadSession().UserId;
                this.departmentdao.Save(this.department);
            }
        }
        private void PrepareDepartments()
        {
            DepartmentCore dept = new DepartmentCore();
            string Id = StringEncryption.Decrypt(this.GetBranchId());
            if (Id != "")
            {
                dept.Id = Id;
            }
            dept.Branchid = ddlbranchname.Text.ToString();
            dept.Deptshortname = txtDeptShortname.Text;
            dept.Deptname = DdlDeptName.Text;
            this.department = dept;
            lblmsg.Visible = true;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
