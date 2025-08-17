using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.AssetParameters.DepreciationRules
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsDao = null;

        public Manage()
        {
            _clsDao = new ClsDAOInv();
        }

        private long GetRowId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 129) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                long Id = GetRowId();

                if (Id > 0)                
                    PopulateDepRuleDetails();
                else
                    PopulateDDL();
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
            TxtNumerator1.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtNumerator2.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtNumerator3.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtNumerator4.Attributes.Add("onblur", "isIntegerOnly(this);");

            TxtDenominator1.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtDenominator2.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtDenominator3.Attributes.Add("onblur", "isIntegerOnly(this);");
            TxtDenominator4.Attributes.Add("onblur", "isIntegerOnly(this);");

            txtDep_Percent_A.Attributes.Add("onblur", "checknumber(this);");
            txtDep_Percent_B.Attributes.Add("onblur", "checknumber(this);");
            txtDep_Percent_C.Attributes.Add("onblur", "checknumber(this);");
            txtDep_Percent_D.Attributes.Add("onblur", "checknumber(this);");

            txtMaintenance_Percent.Attributes.Add("onblur", "checknumber(this);");
            txtDisolve_Limit.Attributes.Add("onblur", "checknumber(this);");
        }

        private void PopulateDepRuleDetails()
        {
            PopulateAllForDLL();
            DataTable dt = _clsDao.getTable("SELECT ID,FY_ID,NUMERATOR_1,DENOMENATOR_1,NUMERATOR_2,DENOMENATOR_2,NUMERATOR_3, DENOMENATOR_3,NUMERATOR_4,"
                                            + " DENOMENATOR_4,Dep_Percent_A,Dep_Percent_B,Dep_Percent_C,Dep_Percent_D,Maintenance_Percent,Disolve_Limit"
                                            +" FROM DEPRECIATIONRULES WHERE ID = " + GetRowId() + "");

            if (dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    CmbFiscalYear.Text = dr["FY_ID"].ToString();                                 
                    TxtNumerator1.Text = dr["Numerator_1"].ToString();
                    TxtDenominator1.Text = dr["Denomenator_1"].ToString();
                    TxtNumerator2.Text = dr["Numerator_2"].ToString();
                    TxtDenominator2.Text = dr["Denomenator_2"].ToString();
                    TxtNumerator3.Text = dr["Numerator_3"].ToString();
                    TxtDenominator3.Text = dr["Denomenator_3"].ToString();
                    TxtNumerator4.Text = dr["Numerator_4"].ToString();
                    TxtDenominator4.Text = dr["Denomenator_4"].ToString();
                    txtDep_Percent_A.Text = dr["Dep_Percent_A"].ToString();
                    txtDep_Percent_B.Text = dr["Dep_Percent_B"].ToString();
                    txtDep_Percent_C.Text = dr["Dep_Percent_C"].ToString();
                    txtDep_Percent_D.Text = dr["Dep_Percent_D"].ToString();
                    txtMaintenance_Percent.Text = dr["Maintenance_Percent"].ToString();
                    txtDisolve_Limit.Text = dr["Disolve_Limit"].ToString();
                    CmbFiscalYear.Enabled = false;
                }
            }

        }

        private void PopulateDDL()
        {
            _clsDao.CreateDynamicDDl(CmbFiscalYear, "SELECT FISCAL_YEAR_ID,FISCAL_YEAR_NEPALI FROM FISCALYEAR WHERE FISCAL_YEAR_NEPALI NOT"
                                                    + " IN (SELECT FY_ID FROM DEPRECIATIONRULES) ", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
        }
        private void PopulateAllForDLL()
        {
            _clsDao.CreateDynamicDDl(CmbFiscalYear, "SELECT FISCAL_YEAR_ID,FISCAL_YEAR_NEPALI FROM FISCALYEAR", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageDepreciationRules();
                Response.Redirect("List.aspx");
            }
            catch
            {
            }
        }

        private void ManageDepreciationRules()
        {
            long id = GetRowId();

            if (id > 0)
            {
                _clsDao.runSQL("exec proc_Manage_DepreciationRules '" + id + "','" + CmbFiscalYear.SelectedValue + "',"
                    + "'" + TxtNumerator1.Text + "','" + TxtDenominator1.Text + "','" + TxtNumerator2.Text + "',"
                    + "'" + TxtDenominator2.Text + "','" + TxtNumerator3.Text + "','" + TxtDenominator3.Text + "',"
                    + "'" + TxtNumerator4.Text + "','" + TxtDenominator4.Text + "','" + ReadSession().Emp_Id + "',"
                    + "'" + DateTime.Now + "','" + "U" + "',"
                    + "'" + txtDep_Percent_A.Text + "','" + txtDep_Percent_B.Text + "','" + txtDep_Percent_C.Text + "',"
                    + "'" + txtDep_Percent_D.Text + "','" + txtMaintenance_Percent.Text + "','" + txtDisolve_Limit.Text + "'");
            }
            else
            {
                _clsDao.runSQL("exec proc_Manage_DepreciationRules '" + id + "','" + CmbFiscalYear.Text + "',"
                    + "'" + TxtNumerator1.Text + "','" + TxtDenominator1.Text + "','" + TxtNumerator2.Text + "',"
                    + "'" + TxtDenominator2.Text + "','" + TxtNumerator3.Text + "','" + TxtDenominator3.Text + "',"
                    + "'" + TxtNumerator4.Text + "','" + TxtDenominator4.Text + "','" + ReadSession().Emp_Id + "',"
                    + "'" + DateTime.Now + "','" + "I" + "',"
                    + "'" + txtDep_Percent_A.Text + "','" + txtDep_Percent_B.Text + "','" + txtDep_Percent_C.Text + "',"
                    + "'" + txtDep_Percent_D.Text + "','" + txtMaintenance_Percent.Text + "','" + txtDisolve_Limit.Text + "'");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
          
        }

    }
}
