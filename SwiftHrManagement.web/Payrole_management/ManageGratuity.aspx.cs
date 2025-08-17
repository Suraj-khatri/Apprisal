using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.SalarySet;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class ManageGratuity : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        private SalarySetDao _salarySetDao = null;
        public ManageGratuity()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._salarySetDao = new SalarySetDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 163) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    populateData();
                    BtnDelete.Visible = false;
                    BtnSave.Visible = false;
                }
                //DisplayGratuityDetails();
            }
            DivMsg.InnerText = "";
        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void populateData()
        {
            DataTable dt = _salarySetDao.FindGratuityDeatilsById(GetId());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];

            txtFromYear.Text = dr["start_year"].ToString();
            txtToYear.Text = dr["end_year"].ToString();
            txtRate.Text = dr["rate"].ToString();
            //ddlRateOn.Text = dr["rate_on"].ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string GetmaxLimit = _clsdao.GetSingleresult("select End_Year from GratuityMaster_Setup");
            string GetmaxYear = _clsdao.GetSingleresult("select isnull(max(end_year),0) from GratuitySetup");

            if (Convert.ToInt16(GetmaxYear) < Convert.ToInt16(GetmaxLimit))
            {
                OnSave();
            }
            else
            {
                DivMsg.InnerHtml = "Gartuity End Year cannot be more than Master Setup End Year";
            }
            
        }

        private void OnSave()
        {
            
            DataTable dt = _salarySetDao.OnSaveUpdateGratuity(txtFromYear.Text, txtToYear.Text, txtRate.Text, ReadSession().Emp_Id.ToString());
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListGratuity.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
                _salarySetDao.OndeleteGratuity(GetId());
                DivMsg.InnerHtml = "Data Delete Successfully";
                DivMsg.Attributes.Add("class", "success");
                //txtFromYear.Text = "";
                //txtToYear.Text = "";
                //txtRate.Text = "";
                Response.Redirect("ListGratuity.aspx");
                //DisplayGratuityDetails();
        }


    }
}