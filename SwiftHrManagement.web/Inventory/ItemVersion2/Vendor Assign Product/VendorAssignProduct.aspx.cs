using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Inventory.ItemVersion2.Vendor_Assign_Product
{
    public partial class VendorAssignProduct : BasePage
    {
        String DelProduct = "";
        ClsDAOInv _clsdao = null;

        public VendorAssignProduct()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatelbl();
                populateddl();
                init();
            }
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();
        }
        private void populatelbl()
        {
            string ProductId = Request.QueryString["product_id"];

            string productName = _clsdao.GetSingleresult("select porduct_code from in_product where id=" + ProductId + "");
            lblproductName.Text = productName;
        }

        private void populateddl()
        {
            _clsdao.CreateDynamicDDl(DdlVendorName, "select ID,CustomerName from Customer where 1=1", "ID", "CustomerName", "", "Select");
        }
        #region SwiftGrid
        private string autoSelect(string str1, string str2)
        {
            if (str1 == str2)
                return "selected=\"selected\"";
            else
                return "";
        }
        protected void btnHidden_Click(object sender, EventArgs e)
        {
        }
        private void init()
        {
            /************************* editable vairable starts***************************************/


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert,  ED= equal to Date
            String[,] matfilter = new String[,]{  
                            {"CustomerName",    "Vendor Name",         "LT"},
                      
                    };


            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                    {"CustomerName",     "Vendor Name",       "100",      "T"},
                    {"porduct_code",     "Product Name",       "100",      "T"},
                    {"price",     "Price",        "100",      "T"},
                    {"IsActive",     "Status",        "100",      "T"}
                    
                                        
            };

            string sortby = "id";
            string table_name = "Vendor_Bid_Price";

            string ProductId = Request.QueryString["product_id"];
            String sql = "";



            sql = "SELECT v.id,c.CustomerName,dbo.ShowDecimal(v.price) as price,case when v.is_active='Y' then 'Yes' else 'No' end as IsActive,"
        + " I.porduct_code,v.product_id from Vendor_Bid_Price v inner join Customer c on c.ID=v.vendor_id inner join IN_PRODUCT I on I.id=v.product_id "
        + " where v.product_id=" + ProductId + "";




            /************************* editable vairable ends***************************************/

            string _page_size = "10";
            string sortd = "desc";
            int _page = 1;

            if (Request.Form["hdd_curr_page"] != null)
                _page = Convert.ToInt32(Request.Form["hdd_curr_page"].ToString());

            if (Request.Cookies["page_size"] != null)
                _page_size = Request.Cookies["page_size"].Value.ToString();

            if (Request.Form["ddl_per_page"] != null)
                _page_size = Request.Form["ddl_per_page"].ToString();

            Response.Cookies["page_size"].Value = _page_size;

            int page_size = Convert.ToUInt16(_page_size);

            if (Request.QueryString["sortd"] != null)
                sortd = Request.QueryString["sortd"].ToString();

            if (Request.QueryString["sortby"] != null)
                sortby = Request.QueryString["sortby"].ToString();

            sortd = (sortd == "desc" ? "asc" : "desc");


            sql = sql + get_filter_sql(table_name, matfilter);

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, sortd, sortby, _page, page_size) + "</center>";

        }
        private string load_report(string table_name, string sql, String[,] matgrid, String sortd, string sortby, int _page, int page_size)
        {
            ClsDAOInv db = new ClsDAOInv();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "VendorAssignProduct.aspx?sortd=" + sortd + "&sortby={sortby}";

            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt16(dtTotal.Rows[0]["totalRecord"].ToString());
            int remainder = total_record % page_size;
            int total_page = (total_record - remainder) / page_size;

            if (remainder > 0)
                total_page++;

            DataTable dt = ds.Tables[1];

            //get_dt(matgrid);
            int arr_cnt = matgrid.GetUpperBound(0);


            StringBuilder html = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\">";

                html.Append("<th align=\"left\">" + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th align=\"right\">Delete</th>");
            html.Append("</tr>");

            int cnt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cnt++;

                if (cnt % 2 == 0)
                {
                    html.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\" >");
                }
                else
                {
                    html.Append("<tr class=\"GridEvenRow\" onMouseOver=\"this.className='GridEvenRowOver'\" onMouseOut=\"this.className='GridEvenRow'\">");
                }

                for (int i = 0; i <= arr_cnt; i++)
                {

                    switch (matgrid.GetValue(i, 3).ToString())
                    {


                        case "N":
                            html.Append("<td align=\"right\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "M":
                            html.Append("<td align=\"right\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "T":
                            html.Append("<td align=\"left\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "D":
                            html.Append("<td align=\"center\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        default:
                            html.Append("<td align=\"left\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                    }
                }
                html.Append("<td><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["ID"].ToString() + "\"></td>");
                html.Append("</tr>");
            }
            html.Append("<tr> <td align=\"center\" colspan=\"11\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("</table>");
            html.Append("</div>");
            return html.ToString();
        }
        private string get_filter_sql(String table_name, String[,] matfilter)
        {
            int arr_cnt = matfilter.GetUpperBound(0);
            string query = "";
            string ctlName = "";
            string defValue = "";

            for (int i = 0; i <= arr_cnt; i++)
            {
                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();


                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                if (defValue.Trim() != "")
                {
                    switch (matfilter.GetValue(i, 2).ToString().ToUpper())
                    {
                        case "LT":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " LIKE '%" + defValue + "%'";
                            break;
                        case "ET":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = '" + defValue + "'";
                            break;
                        case "EB":
                        case "EN":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = " + defValue;
                            break;
                    }
                }
            }
            return query;
        }
        #endregion

        public Boolean CheckDublicateEntry()
        {
            string ProductId = Request.QueryString["product_id"];
            Boolean IfExists = _clsdao.CheckStatement("select * from Vendor_Bid_Price where vendor_id=" + filterstring(DdlVendorName.Text) + " and product_id=" + filterstring(ProductId) + " ");
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string IsActive;
            string ProductId = Request.QueryString["product_id"];
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
                _clsdao.runSQL("insert into Vendor_Bid_Price(vendor_id,product_id,price,is_active)values(" + filterstring(DdlVendorName.Text) + ","
                                + " " + filterstring(ProductId) + "," + filterstring(txtAmt.Text) + "," + filterstring(IsActive) + ")");
            }
            init();
            resetForm();
        }
        private void resetForm()
        {
            DdlVendorName.Text = "";
            txtAmt.Text = "";
            ChkIsActive.Checked = false;
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Deleteproduct();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void Deleteproduct()
        {
            if (DelProduct != "")
            {
                _clsdao.runSQL("delete from Vendor_Bid_Price where ID = " + DelProduct + "");
            }
            init();
        }
    }
}
