using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.DeductionsDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ListDeductions : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        DeductionsDAO _deductionsDao = null;
        DeductionsCore _deductionsCore = null;
        public ListDeductions()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this._deductionsDao = new DeductionsDAO();
            this._deductionsCore = new DeductionsCore();
        }
        private long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            LblEmpName.Text = _empcore.EmpName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
            {
                Response.Redirect("/Error.aspx");
            } 
            this.GvEmpDeductions.DataSource = _deductionsDao.FindAllByEmpId(GetEmpId());
            GvEmpDeductions.DataBind();
            this.hdnempid.Value = GetEmpId().ToString();
            getemployee();
        }

        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            hdnempid.Value = GetEmpId().ToString();
            this.ReadSession().TempEmpId = long.Parse(hdnempid.Value);
            Response.Redirect("ManageDeductions.aspx");
        }
    }
}