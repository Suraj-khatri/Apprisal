using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.Payrole;
using SwiftHrManagement.web.DAL.SalarySet;

namespace SwiftHrManagement.web.Payrole_management.GratuitySetup
{
    public partial class Manage : BasePage
    {
        payroleDAO payroll = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _role = null;
        private SalarySetDao _salarySetDao = null;
        public Manage()
        {
            _clsDao = new clsDAO();
            payroll = new payroleDAO();
            _role = new RoleMenuDAOInv();
            _salarySetDao = new SalarySetDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_role.hasAccess(ReadSession().AdminId, 245) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    PopulateGratuity();
                }
            }
            DivMsg.InnerText = "";
        }

        private long GetGratuityId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PopulateGratuity()
        {
            DataTable dt = _salarySetDao.FindGratuityMasterDetails(GetId());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];

            DdlStartFrom.Text = dr["Start_From"].ToString();
            ddlCalculateOn.Text = dr["Calculate_On"].ToString();
            txtStartYear.Text = dr["Start_Year"].ToString();
            txtEndYear.Text = dr["End_Year"].ToString();
        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            DataTable dt = _salarySetDao.OnSaveGratuityMaster(DdlStartFrom.Text, ddlCalculateOn.Text, txtStartYear.Text, txtEndYear.Text, ReadSession().Emp_Id.ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];
            if (dr["error_code"].ToString() == "1")
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "warning");
            }
            else
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "success");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}