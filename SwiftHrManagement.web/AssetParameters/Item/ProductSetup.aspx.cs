using System;
using System.Data;
using SwiftHrManagement.web;
namespace SwiftAssetManagement.AssetParameters.Item
{
    public partial class ProductSetup : BasePage
    {
        ClsDAOInv _clsdao = null;
        public ProductSetup()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LblProduct.Text = _clsdao.GetSingleresult("select item_name from ASSET_ITEM where id=" + GetGroupId() + "");

                if (GetProductId() > 0)
                {
                    populateproduct();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }

            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetProductId()
        {
            return (Request.QueryString["product_id"] != null ? long.Parse(Request.QueryString["product_id"]) : 0);
        }

        private long GetItemId()
        {
            return (Request.QueryString["item_id"] != null ? long.Parse(Request.QueryString["item_id"]) : 0);
        }
        private long GetGroupId()
        {
            return (Request.QueryString["group_id"] != null ? long.Parse(Request.QueryString["group_id"]) : 0);
        }

        private void manageproduct()
        {
            string strflag;
            if (GetProductId() > 0)
                strflag = "u";
            else
                strflag = "i";

            string SQL = "exec Proc_Asset_ProductSetup @flag=" + filterstring(strflag) + ",@id=" + filterstring(GetProductId().ToString()) + ","
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@porduct_code=" + filterstring(TxtProductCode.Text) + ","
                            + " @product_desc=" + filterstring(TxtProductDesc.Text) + ","
                            + " @assetcode=" + filterstring(TxtAssetCode.Text) + ",@parentid=" + filterstring(GetGroupId().ToString()) + "";

            string Msg = _clsdao.GetSingleresult(SQL);

            LblMsg.Text = Msg;

        }
        private void populateproduct()
        {
            string SQL = "EXEC Proc_Asset_ProductSetup 's',@id=" + GetProductId();
            DataTable dt = _clsdao.getTable(SQL);
            foreach (DataRow dr in dt.Rows)
            {
                TxtProductCode.Text = dr["porduct_code"].ToString();
                TxtProductDesc.Text = dr["product_desc"].ToString();
                TxtAssetCode.Text = dr["ASSET_CODE"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            manageproduct();
            TxtAssetCode.Text = "";
            TxtProductCode.Text = "";
            TxtProductDesc.Text = "";
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procDeleteInventorySetup @FLAG='ass_product',@ID=" + GetProductId() + ",@USER=" + filterstring(ReadSession().UserId) + "");
            if (msg.Contains("SUCCESS"))
            {
                TxtAssetCode.Text = "";
                TxtProductCode.Text = "";
                TxtProductDesc.Text = "";
                LblMsg.Text = msg;
                return;
            }
            else
            {
                LblMsg.Text = msg;
                return;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
