using System;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class WeightageDefination : BasePage
    {
        AppraisalDAO _appraisal = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public WeightageDefination()
        {
            _appraisal = new AppraisalDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("rowId", "")) && !string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("WRowId", "")))
                {
                    LoadWeightageDetails();
                    txtLevelName.Enabled = false;
                    Btn_Save.Text = "Edit";

                }
                else
                {
                    LoadLevelName();
                    txtLevelName.Enabled = false;
                }
            }


        }

        private void LoadWeightageDetails()
        {
            var dt = _appraisal.LoadWeightageDetails(GetStatic.ReadQueryString("rowId", ""));
            var comMatrixName = "";

            KRAWeightage1.Text = dt.Rows[0]["Kra"].ToString();
            KRAWeightage2.Text = dt.Rows[0]["Competencies"].ToString();
            comMatrixName = dt.Rows[0]["LevelName"].ToString();
            txtLevelName.Text = comMatrixName;
        }

        private void LoadLevelName()
        {
            var dt = _appraisal.LoadLevelName(GetStatic.ReadQueryString("rowId", ""));
            var comMatrixName = "";
           
            //KRAWeightage1.Text = dt.Rows[0]["Kra"].ToString();
            //KRAWeightage2.Text = dt.Rows[0]["Competencies"].ToString();
            comMatrixName = dt.Rows[0]["LevelName"].ToString();
            txtLevelName.Text = comMatrixName;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            float KRA1 =  float.Parse(KRAWeightage1.Text);
            float KRA2 =  float.Parse(KRAWeightage2.Text);
            if (KRA1 <= 0 )
            {
                GetStatic.SweetAlertMessage(this, "Alert", "The KRA Weightage must be greater than 0");
                return;
            }
            if (KRA2 <= 0)
            {
                GetStatic.SweetAlertMessage(this, "Alert", "The Compentencies Weightage must be greater than 0");
                return;
            }
            if ((KRA1 + KRA2) != 100)
            {
                GetStatic.SweetAlertMessage(this,"Alert", "The total weightage must be exactly 100");
                return;
            }
            else if (Btn_Save.Text =="Edit")
            {
                string res = _appraisal.EditWeightageDefination(GetStatic.ReadQueryString("rowId", ""),KRAWeightage1.Text, KRAWeightage2.Text, ReadSession().Emp_Id.ToString());
                if (res == "SUCCESS")
                {
                    GetStatic.SweetAlertSuccessMessage(this,"Sucessful", "Data saved successfully!");
                    LoadWeightageDetails();
                    Response.Redirect("CompetancyList.aspx");
                }
                else
                {
                    GetStatic.SweetAlertErrorMessage(this,"Failed", "uPDATE fAILED !");
                }
            }

            else
            {
                string res = _appraisal.WeightageDefination(GetStatic.ReadQueryString("rowId", ""), KRAWeightage1.Text, KRAWeightage2.Text, ReadSession().Emp_Id.ToString());

                if (res == "SUCCESS")
                {
                    GetStatic.AlertMessage(this, "Data saved successfully!");
                    LoadWeightageDetails();
                    Response.Redirect("CompetancyList.aspx");
                }
                else
                {
                    GetStatic.AlertMessage(this, "cannot insert again!");
                }
            }
           
        }

        private void ClearAllFields()
        {
            KRAWeightage1.Text = "";
            KRAWeightage2.Text = "";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompetancyList.aspx");
        }
    }
}