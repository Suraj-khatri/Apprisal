using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.SalarySet;

namespace SwiftHrManagement.web.SalarySetSetup
{
    public partial class ManageSalarySet : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        private SalarySetDao _salarySetDao = null;
        public ManageSalarySet()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._salarySetDao = new SalarySetDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 210) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetSalarySetId() > 0)
                {
                    PopulateData();

                }
                else
                {
                    //btnDelete.Visible = false;
                    SetDDL("");
                }
            }

        }

        private long GetSalarySetId()
        {
            return ReadNumericDataFromQueryString("setId");

        }

        private void PopulateData()
        {
            DataTable dt = _salarySetDao.FindSalarySetById(GetSalarySetId());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];

            SetDDL(dr["positionId"].ToString());
            txtSetTitle.Text = dr["setTitle"].ToString();
            txtSetRemarks.Text = dr["setRemarks"].ToString();
            txtGradeNo.Text = dr["noOfGrades"].ToString();
            txtStartBasicSalary.Text = dr["startBasic"].ToString();
            ddlIsActive.Text = dr["setStatus"].ToString();

        }


        private void SetDDL(string positionId)
        {
            var sql = "SELECT ROWID,DETAIL_DESC FROM StaticDataDetail WHERE TYPE_ID = 4";
            _clsdao.setDDL(ref ddlPosition, sql, "ROWID", "DETAIL_DESC", positionId, "select");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveUpdate();
            Response.Redirect("/SalarySetSetup/ListSalarySet.aspx");
        }
        private void OnSaveUpdate()
        {
            DataTable dt = _salarySetDao.OnSaveUpdateSalarySet(GetSalarySetId().ToString(), ddlPosition.Text, txtSetTitle.Text, txtSetRemarks.Text, txtGradeNo.Text, txtStartBasicSalary.Text, ReadSession().Emp_Id.ToString(), ddlIsActive.Text);
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

            txtSetTitle.Text = "";
            ddlPosition.SelectedValue = "";
            

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SalarySetSetup/ListSalarySet.aspx");
        }
    }
}