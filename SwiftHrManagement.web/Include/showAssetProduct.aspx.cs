using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Include
{
    public partial class showAssetProduct : BasePage
    {
        ClsDAOInv _clsdao = null;
        public showAssetProduct()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string ProdID = Request.QueryString["ProdID"];
            StringBuilder html = new StringBuilder("<div class=\"panel\">");

            DataSet DS = _clsdao.getDataset("select m.id,item_name,item_desc,is_product,p.id,parent_id,p.id as [prod_id],p.porduct_code from ASSET_ITEM m"
                           + " left join ASSET_PRODUCT p on p.item_id=m.id where parent_id=" + filterstring(ProdID.ToString()) + " order by p.porduct_code  ");
            DataTable dt = DS.Tables[0];

            int cnt = 0;
            bool isproduct = false;

            foreach (DataRow dr in dt.Rows)
            {
                cnt++;
                isproduct = bool.Parse(dr["is_product"].ToString());
                if (isproduct == true)
                {
                    html.Append("<div id=\"inventory1\" class=\"row\">");
                    html.Append("<div class=\"col-md-6 col-md-offset-1\">");
                    html.Append("<i class=\"fa fa-info-circle\" style=\"font-size:17px; color:#0094FF;\"></i> &nbsp;");
                    html.Append("<label>" + dr["porduct_code"].ToString() + "</label>  ");
                    html.Append("</div>");
                    html.Append("<div class=\"col-md-5\" style=\"color:#\">");
                    html.Append("<a href=# onclick=\"showEdit('" + dr["id"] + "','" + dr["parent_id"] + "','" + dr["is_product"] + "','" + dr["prod_id"] + "')\" class='link' >Edit</a>&nbsp;|&nbsp;"
                                + " <a href=# onclick=\"showBranchAssign('" + dr["prod_id"] + "')\" class='link'>Branch Assign</a>");
                    html.Append("</div>");
                    html.Append("</div>");
                }
                else
                {

                    html.Append("<div> <span onclick=\"ShowProduct('" + dr["id"] + "')\" style=\"cursor:pointer;\">");
                    html.Append("<div class=\"row\" style=\"margin-left:0;\">");
                    html.Append("<div class=\"col-md-8\">");
                    html.Append("<i class=\"fa fa-folder\" aria-hidden=\"true\"></i> &nbsp;&nbsp;");
                    html.Append("<span>" +dr["item_name"].ToString() + "</span>  ");
                    html.Append("</div>");
                    html.Append("<div class=\"col-md-4\">");
                    html.Append("<a href=# onclick=\"showEdit('" + dr["id"] + "','" + dr["parent_id"] + "','" + dr["is_product"] + "','A')\" class='link' >Edit</a>");
                    html.Append("</div></div></div> ");
                }
                html.Append("<div><span id='tdshow" + dr["id"] + "'> </span> </div>");
            }
            if (isproduct == false)
            {
                html.Append("<div class=\"col-md-6\"> <a style=\"margin-left:20px;\" href='#' class='link' onclick=\"AddNewGroup('" + ProdID + "','')\">New Group</a>");
            }
            else
            {
                html.Append(" <a href='#' style=\"margin-left:20px;\" class='link' onclick=\"AddNewProduct('" + ProdID + "','')\">New Product</a>");
            }
            if (cnt == 0)
            {
                html.Append(" <a style=\"margin-left:20px;\" href='#' class='link' onclick=\"AddNewProduct('" + ProdID + "','')\">New Product</a>");
            }
            html.Append("</div> ");
            html.Append("</div> ");

            Response.Write(html.ToString());
        }
    }
}
