using System;
using System.Data;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.DAL.Grade;

namespace SwiftHrManagement.web.Company.EmployeeWeb.Grade
{
    public partial class ManageGrade : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        //clsDAO _clsdao = null;
        GradeDao _gradedao = new GradeDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                PopulateDDLGrade();
                if (GetId() > 0)
                {
                    PopulateDataById();
                    Btn_delete.Visible = true;
                }
                else
                {
                    
                    Btn_delete.Visible = false;
                }
            }
            BtnBack.Attributes.Add("onclick","history.back();return false");
        }

        private void PopulateDDLGrade()
        {
            _clsdao.setDDL(ref ddlGrade, @"select Grade from Grade_Setup g inner join salarySetMaster s
                                            on g.Salary_set_id=s.salarySetMasterId
                                            where Salary_Title=(select Salary_Title from Employee where EMPLOYEE_ID="+ GetEmpId().ToString() +")", "Grade", "Grade", "", "Select");//TO DO                
        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            Update();
        }

        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            DeleteGrade();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListGrade.aspx");
        }

        #region Method
        private long GetId()
        {
            return ReadNumericDataFromQueryString("gradeId");
        }

        private long GetEmpId()
        {
            return ReadNumericDataFromQueryString("empId");
        }


        private void DeleteGrade()
        {
            var dbResult = _gradedao.Delete(GetId().ToString());
            ManageMessage(dbResult);
            
        }

        private void PopulateDataById()
        {
            DataRow dr = _gradedao.SelectById(GetId().ToString());
            if (dr == null)
                return;


           
            txtEffectiveDate.Text = dr["effectiveDate"].ToString();
            ddlIncrementDec.SelectedValue= dr["gradeFlag"].ToString();
            ddlGrade.SelectedValue = dr["grade"].ToString();
            txtAmount.Text = dr["amount"].ToString();
        }

        private void Update()
        {
            var dbResult = _gradedao.Update(ReadSession().Emp_Id.ToString(), GetEmpId().ToString(), GetId().ToString(), txtEffectiveDate.Text, ddlIncrementDec.SelectedValue, ddlGrade.SelectedValue, txtAmount.Text);
            ManageMessage(dbResult);
            
        }

        private void ManageMessage(DbResult dbResult)
        {
            SetMessage(dbResult);
            if (dbResult.ErrorCode == "0")
            {
                Response.Redirect("ListGrade.aspx?Id=" + GetEmpId());
            }
            else
            {
                var css = SetMessageBox();
                divMsg.InnerText = dbResult.Msg;
                divMsg.Attributes.Add("class", css);
            }
        }

        #endregion

        #region Element Method
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Update();
        }


        #endregion
        private void LoadAmount()
        {
            DataRow dr = _gradedao.LoadAmount(GetEmpId().ToString(), ddlGrade.SelectedValue);
            if (dr == null)
                return;

            txtAmount.Text = ShowDecimal(dr["amount"].ToString());
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAmount();
        }
        

    }
}