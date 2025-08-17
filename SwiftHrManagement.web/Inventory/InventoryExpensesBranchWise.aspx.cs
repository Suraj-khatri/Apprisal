using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class InventoryExpensesBranchWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public InventoryExpensesBranchWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetBranchID()
        {
            return (Request.QueryString["Branch"] != null ? (Request.QueryString["Branch"]) : "");
        }
        private string GetDeptID()
        {
            return (Request.QueryString["Dept"] != null ? (Request.QueryString["Dept"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID()!="")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblBranchName.Text = dr["BRANCH_NAME"].ToString();
                }
            }
            else
            {
                lblBranchName.Text = "All Branches";
            }
            if (GetDeptID() != "")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select DEPARTMENT_NAME from Departments where DEPARTMENT_ID='" + GetDeptID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblDeptName.Text = dr["DEPARTMENT_NAME"].ToString();
                }
            }
            else
            {
                lblDeptName.Text = "All Departments";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            double tot_amount = 0.00;
            double tot_qty = 0;
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'f', " + filterstring(GetBranchID().ToString()) + ","+filterstring(GetDeptID().ToString())+",'null','null'");

            _CompanyCore = _company.FindCompany(); 

            this.divCompany.InnerText = _CompanyCore.Name;
            //this.lbldesc.Text = _CompanyCore.Address;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  
            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                if (i>1)
                {
                    str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                tot_amount = tot_amount + Double.Parse(row["AMOUNT (Rs.)"].ToString());
                tot_qty = tot_qty + Double.Parse(row["QTY"].ToString());
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    if (i ==0 || i==2)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else if (i > 2)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"2\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + tot_qty.ToString() + " </b></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(tot_amount.ToString()) + "</b> </td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
