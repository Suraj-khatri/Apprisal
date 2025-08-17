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

namespace SwiftAssetManagement.AssetManagement
{
    public partial class ManageAssetCapitalization : BasePage
    {
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        public ManageAssetCapitalization()
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
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 201) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateForwardedTo();
                if (GetRowId() > 0)
                {
                    PopulateAssetCapitalization();
                }
                else
                {
                    btnDelete.Visible = false;
                }
                if (ReadSession().UserType == "A")
                {
                    AutoCompleteExtender3.ContextKey = "null";
                }
                else
                {
                    AutoCompleteExtender3.ContextKey = ReadSession().Branch_Id.ToString();
                }
            }

            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void populateForwardedTo()
        {
            if (ReadSession().Branch_Id == 1)
            {
                _clsDao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
            else
            {
                _clsDao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
        }

        private void PopulateAssetCapitalization()
        {
            DataTable dt = _clsDao.getTable("Exec proc_ManageCapitalizationHistory @flag='s',@id=" + GetRowId() + "");

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HdnAssetnumber.Value = dr["id"].ToString();
                    TxtAssetNumber.Text = dr["asset_number"].ToString();
                    TxtCapitalizationDate.Text = dr["Capitalization_date"].ToString();
                    TxtBookValue.Text = dr["book_value"].ToString();
                    TxtCapitalizedAmount.Text = dr["Capitalization_amt"].ToString();
                    txtAssetNarration.Text = dr["asset_narration"].ToString();
                    TxtNarration.Text = dr["Narration"].ToString();
                    txtPurchaseValue.Text = dr["purchase_value"].ToString();
                    txtAccDep.Text = dr["acc_dep"].ToString();
                    ddlForwardedTo.Text = dr["forwarded_to"].ToString();
                    txtRejectedReason.Text = dr["rejection_reason"].ToString();
                }
            }            
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAssetCapitalizationList();
            }
            catch
            {
                LblMsg.Text = "Error in Saving!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ManageAssetCapitalizationList()
        {
            string flag="";
            if (GetRowId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            _clsDao.runSQL("exec proc_ManageCapitalizationHistory @flag=" + filterstring(flag) + ",@id="+filterstring(GetRowId().ToString())+","
            + " @assetid=" + filterstring(HdnAssetnumber.Value) + ",@capitalization_date=" +filterstring(TxtCapitalizationDate.Text) + ","
            + " @book_value=" + filterstring(TxtBookValue.Text) + ",@capitalization_amt=" + filterstring(TxtCapitalizedAmount.Text) + ","
            + " @narration=" + filterstring(TxtNarration.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            + " @forwarded_to="+filterstring(ddlForwardedTo.Text)+"");

            Response.Redirect("ListAssetCapitalization.aspx");                
        }

        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = _clsDao.getTable("exec [ProcPopulateAssetDetails] " + filterstring(HdnAssetnumber.Value) + "");

            foreach (DataRow dr in dt.Rows)
            {
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["narration"].ToString();
                TxtBookValue.Text = dr["book_Value"].ToString();
                txtAccDep.Text = dr["acc_dep"].ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string flag = "d";
            try
            {
                _clsDao.runSQL("exec proc_ManageCapitalizationHistory @flag=" + filterstring(flag) + ",@id="+filterstring(GetRowId().ToString())+"");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
