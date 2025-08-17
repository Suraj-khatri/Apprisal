using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.SalarySet;
namespace SwiftHrManagement.web.SalarySet
{
    public partial class ManageSalarySet :BasePage
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
                if (GetSalarySetMasterId() > 0 )
                {
                    PopulateData();

                }
                else
                {
                    BtnDelete.Visible = false;
                    SetDDL("");
                }
             }

        }

        protected long GetSalarySetMasterId()
        {
            return ReadNumericDataFromQueryString("MasterId");

        }
        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
        private  void PopulateData()
        {
            DataTable dt = _salarySetDao.FindSalarySetById(GetSalarySetMasterId());
            DataRow dr = null;
            if(dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];

            SetDDL(dr["Salary_Title"].ToString());
            txtDescription.Text = dr["Desccription"].ToString();
            txtGrades.Text = dr["No_of_Grades"].ToString();
            ddlSalaryTitle.Enabled = false;
             
        }


        private  void SetDDL(string salaryTitle) 
        {
            var sql = "SELECT ROWID,DETAIL_DESC FROM StaticDataDetail WHERE TYPE_ID = 98";
            _clsdao.setDDL(ref ddlSalaryTitle, sql, "ROWID", "DETAIL_DESC", salaryTitle, "select");

        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSaveUpdate();
        }

        private void OnSaveUpdate()
        {
            DataTable dt = _salarySetDao.OnSaveUpdateMaster(GetSalarySetMasterId().ToString(), ddlSalaryTitle.Text, txtDescription.Text, txtGrades.Text, ReadSession().Emp_Id.ToString());
            //DataRow dr = null;
            //if (dt == null || dt.Rows.Count < 0)
            //    return;


            //dr = dt.Rows[0];
            //if (dr["error_code"].ToString() == "1")
            //{
            //    DivMsg.InnerHtml = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "warning");
            //}
            //else
            //{
            //    DivMsg.InnerHtml = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "success");
            //}
            Response.Redirect("List.aspx");
            txtDescription.Text = "";
            txtGrades.Text = "";
            ddlSalaryTitle.SelectedValue = "";

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _salarySetDao.OnDeleteMaster(GetSalarySetMasterId());
            Response.Redirect("List.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}