using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Vendor
{
    public partial class ManageBidFor : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsdao = null;
        public ManageBidFor()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new ClsDAOInv();
        }
        private long GetVendorId()
        {
            return (Request.QueryString["VenId"] != null ? long.Parse(Request.QueryString["VenId"].ToString()) : 0);
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 110) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                ChkIsActive.Checked = true;
                if (GetId() > 0)
                {
                    populateProduct();
                    BtnDelete.Visible = true;
                }
                else
                {
                    string vendor = _clsdao.GetSingleresult("SELECT CustomerName FROM Customer WHERE ID="+GetVendorId()+"");
                    txtVendor.Text = vendor;
                    txtVendor.Enabled = false;
                    BtnDelete.Visible = false;
                }               
            }
            AutoCompleteExtender2.ContextKey = ReadSession().Branch_Id.ToString();
        }
        private void populateProduct()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select v.id,c.CustomerName as vendor_id,p.porduct_code as product_name,v.product_id,CONVERT(VARCHAR,v.price,0) as  price,v.is_active from "
                + " Vendor_Bid_Price v inner join Customer c on c.ID=v.vendor_id inner join IN_PRODUCT p on p.id=v.product_id WHERE v.id='" + GetId() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                txtVendor.Text = dr["vendor_id"].ToString();
                txtVendor.Enabled = false;
                hdnProductId.Value = dr["product_id"].ToString();
                txtProduct.Text = dr["product_name"].ToString();
                txtPrice.Text = dr["price"].ToString();
                if (dr["is_active"].ToString() == "Y")
                {
                    ChkIsActive.Checked = true;
                }
                else
                {
                    ChkIsActive.Checked = false;
                }
            }
        }
        public Boolean CheckDublicateEntry()
        {

            string[] arrayProduct = txtProduct.Text.Split('|');
            string productId = arrayProduct[1];

            Boolean IfExists = _clsdao.CheckStatement("select * from Vendor_Bid_Price where vendor_id=" + filterstring(GetVendorId().ToString()) + " and product_id=" + filterstring(productId) + "");
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (GetId() > 0)
                    {
                        string IsActive;
                        if (ChkIsActive.Checked == true)
                        {
                            IsActive = "Y";
                        }
                        else
                        {
                            IsActive = "N";
                        }
                        _clsdao.runSQL("Update Vendor_Bid_Price set vendor_id=" + filterstring(GetVendorId().ToString()) + ",product_id=" + filterstring(hdnProductId.Value) + ",price=" + filterstring(txtPrice.Text) + ",is_active=" + filterstring(IsActive) + " where ID=" + GetId() + "");
                    }
                 else
                 {
                     string[] arrayProduct = txtProduct.Text.Split('|');
                     string productId = arrayProduct[1];

                     if (productId == "")
                     {
                         LblMsg.Text = "Please Use AutoComplte for Product Selection!";
                         LblMsg.ForeColor = System.Drawing.Color.Red;
                     }
                     else
                     {
                         string IsActive;
                         if (ChkIsActive.Checked == true)
                         {
                             IsActive = "Y";
                         }
                         else
                         {
                             IsActive = "N";
                         }
                         if (CheckDublicateEntry() == true)
                         {
                             LblMsg.Text = "This product has already inserted for this vendor!";
                             LblMsg.ForeColor = System.Drawing.Color.Red;
                             return;
                         }
                         else
                         {
                             _clsdao.runSQL(
                                 "insert into Vendor_Bid_Price(vendor_id,product_id,price,is_active)values(" +
                                 filterstring(GetVendorId().ToString()) + ","
                                 + " " + filterstring(productId) + "," + filterstring(txtPrice.Text) + "," +
                                 filterstring(IsActive) + ")");
                         }
                     }
                 }
                Response.Redirect("BidForProductList.aspx?Id=" + GetVendorId() + "");
                
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("delete from Vendor_Bid_Price where ID="+GetId()+"");
                Response.Redirect("BidForProductList.aspx?Id=" + GetVendorId() + "");
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BidForProductList.aspx?Id="+GetVendorId()+"");
        }
    }
}
