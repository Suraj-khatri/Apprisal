using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.Inventory.Item
{
    public partial class ProductSearch : BasePage
    {
        // Old code
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsdao = null;
        public ProductSearch()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 43) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        protected void BtnSeacrh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("Exec procSearchProduct 's'," + filterstring(txtCode.Text) + "," + filterstring(txtName.Text) + "," + filterstring(txtGroup.Text) + "").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<th align=\"left\" class=\"HeaderStyle\">Select</th>");
            for (int i = 0; i < cols; i++)
            {
                if (dt.Columns[i].ColumnName != "prod_info")
                {
                    str.Append("<th align=\"left\" class=\"HeaderStyle\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value='" + dr["prod_info"] + "'></td>");
                for (int i = 0; i < cols; i++)
                {
                    if (dr[i].ToString() != dr["prod_info"].ToString())
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");

            rpt.InnerHtml = str.ToString();
        }

        // upto here old code

       
    }
}
