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
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;


namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ViewReport : BasePage
    {
         ClsDAOInv _clsdao = null;
         CompanyDAO _company = null;
         CompanyCore _CompanyCore = null;
         public ViewReport()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            double tot_amount = 0.00;
            double tot_qty = 0;
            string branchid = Request.QueryString["Branch"] == null ? "" : Request.QueryString["Branch"].ToString();
            string ProductGroup = Request.QueryString["ProductGroup"] == null ? "" : Request.QueryString["ProductGroup"].ToString();
            string ProductName = Request.QueryString["ProductName"] == null ? "" : Request.QueryString["ProductName"].ToString();
            if (branchid == "")            
                LblBranchName.Text = "All";            
            else
                LblBranchName.Text = _clsdao.GetSingleresult("select branch_name as branch from branches where branch_id=" + branchid + "");
            
            if (ProductGroup == "")
                LblProductGroupWise.Text = "All";
            else
                LblProductGroupWise.Text = _clsdao.GetSingleresult("select item_name from IN_ITEM where id=" + ProductGroup + "");

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  

            DataTable dt = _clsdao.getTable("Exec [procStockInHandGroupWise] @flag='a',@BRANCH_ID=" + filterstring(branchid) + ""
            + ",@GROUP_ID=" + filterstring(ProductGroup) + ",@PRODUCT_ID=" + filterstring(ProductName) + "");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 3)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i == 0 || i == 2 || i == 3)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i == 1)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                tot_amount = tot_amount + Double.Parse(dr["AMOUNT"].ToString());
                tot_qty = tot_qty + Double.Parse(dr["STOCK"].ToString());
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"3\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + tot_qty.ToString() + " </b></td>");

            str.Append("<td>&nbsp;</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(tot_amount.ToString()) + "</b> </td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }
}
