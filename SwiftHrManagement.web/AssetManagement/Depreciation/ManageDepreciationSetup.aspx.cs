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
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.AssetManagement.Depreciation
{
    public partial class ManageDepreciationSetup : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsdao = null;
        public ManageDepreciationSetup()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new ClsDAOInv();
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 207) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateDepSetup();
            }
        }
        private long GetSetupId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateDepSetup()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select d.id,ap.porduct_code,a.asset_number,d.fiscal_year,m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12,d.dep_pct,"
            +" dbo.ShowDecimal(d.acc_dep) as acc_dep,dbo.ShowDecimal(d.base_price) as base_price from depreciation_setup d with(nolock) inner join "
            +" ASSET_INVENTORY a with(nolock) on a.id=d.asset_id inner join ASSET_PRODUCT ap on ap.id=a.product_id where d.id='"+GetSetupId()+"'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblAssetType.Text = dr["porduct_code"].ToString();
                lblbasePrice.Text = dr["base_price"].ToString();
                lblDepPer.Text = dr["dep_pct"].ToString();
                lblFiscalYear.Text = dr["fiscal_year"].ToString();
                lblAssetNumber.Text = dr["asset_number"].ToString();
                lblAccDep.Text = dr["acc_dep"].ToString();

                txtBaishak.Text = dr["m1"].ToString();
                txtJeshta.Text = dr["m2"].ToString();
                txtAshad.Text = dr["m3"].ToString();
                txtShawan.Text = dr["m4"].ToString();
                txtBhadra.Text = dr["m5"].ToString();
                txtAshoj.Text = dr["m6"].ToString();
                txtKartik.Text = dr["m7"].ToString();
                txtMangshir.Text = dr["m8"].ToString();
                txtPoush.Text = dr["m9"].ToString();
                txtMagh.Text = dr["m10"].ToString();
                txtFalgun.Text = dr["m11"].ToString();
                txtChaitra.Text = dr["m12"].ToString();         
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("update depreciation_setup set m1="+filterstring(txtBaishak.Text)+",m2="+filterstring(txtJeshta.Text)+",m3="+filterstring(txtAshad.Text)+","
                + " m4=" + filterstring(txtShawan.Text) + ",m5=" + filterstring(txtBhadra.Text) + ",m6=" + filterstring(txtAshoj.Text) + ",m7="+filterstring(txtKartik.Text)+","
                + " m8=" + filterstring(txtMangshir.Text) + ",m9=" + filterstring(txtPoush.Text) + ",m10=" + filterstring(txtMagh.Text) + ",m11="+filterstring(txtFalgun.Text)+","
                + " m12=" + filterstring(txtChaitra.Text) + " where id="+filterstring(GetSetupId().ToString())+"");
                Response.Redirect("depreciation_setup_list.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
