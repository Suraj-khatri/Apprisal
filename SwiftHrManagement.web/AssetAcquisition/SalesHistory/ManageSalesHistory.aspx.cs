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

namespace SwiftAssetManagement.AssetAcquisition.SalesHistory
{
    public partial class ManageSalesHistory : BasePage
    {
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        public ManageSalesHistory()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 54) == false)
                {
                    Response.Redirect("/Error.aspx");
                }                
                populateForwardedTo();
                if (ReadSession().UserType == "A")
                {
                    AutoCompleteExtender3.ContextKey = "null";
                }
                else
                {
                    AutoCompleteExtender3.ContextKey = ReadSession().Branch_Id.ToString();
                }
                if (GetId() > 0)
                {
                    populateSalesRequest();
                }
                
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void populateForwardedTo()
        {
            if (ReadSession().Branch_Id == 1)
            {
                _clsdao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
            else
            {
                _clsdao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
        }

        private void populateSalesRequest()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec proc_Asset_sales @flag='s',@id=" + filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtBookvalue.Text = dr["Book_Value"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["asset_narration"].ToString();
                TxtBookvalue.Enabled = false;
                txtPurchaseValue.Enabled = false;
                txtAssetNarration.Enabled = false;
                TxtAssetNumber.Text = dr["asset_number"].ToString();
                TxtSolddate.Text = dr["sold_date"].ToString();
                txtSoldby.Text = dr["sold_by"].ToString();
                TxtSoldAmount.Text = dr["sold_amt"].ToString();
                TxtCollectionLedger.Text = dr["collection_ledger"].ToString();
                ddlForwardedTo.SelectedValue = dr["forwarded_to"].ToString();
                TxtNarration.Text = dr["narration"].ToString();
                txtRejectionReason.Text = dr["rejection_reason"].ToString();
                HdnAssetnumber.Value = dr["id"].ToString();
                Hdnempid.Value = dr["sold_id"].ToString();
                HdnLedger.Value = dr["collection_ledger"].ToString();
            }
        }
        private void getbookvalue()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec proc_Asset_sales @flag='a',@asset_id=" + HdnAssetnumber.Value + "").Tables[0];
            
            foreach (DataRow dr in dt.Rows)
            {
                TxtBookvalue.Text = dr["Book_Value"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAssetNarration.Text = dr["narration"].ToString();
                TxtBookvalue.Enabled = false;
                txtPurchaseValue.Enabled = false;
                txtAssetNarration.Enabled = false;
            }
        }
        private void manage()
        {
            string flag="";
            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            _clsdao.runSQL("exec [proc_Asset_sales] @flag="+filterstring(flag)+",@id="+filterstring(GetId().ToString())+","
            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            + " @asset_id=" + filterstring(HdnAssetnumber.Value) + ",@sold_date=" + filterstring(TxtSolddate.Text) + ","
            + " @sold_by=" + filterstring(Hdnempid.Value) + ",@narration=" + filterstring(TxtNarration.Text) + ","
            + " @soldamt=" + filterstring(TxtSoldAmount.Text) + ",@collection_ledger=" + filterstring(HdnLedger.Value) + ","
            + " @forwarded_to=" + filterstring(ddlForwardedTo.Text) + "");
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                manage();
                Response.Redirect("SalesHistoryList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            getbookvalue();
        }
    }
}
