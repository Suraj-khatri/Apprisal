using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class PO_without_pricePrint : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        public PO_without_pricePrint()
        {
            this._clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadreport();
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
        }
        private void loadreport()
        {
            long id = 0;
            if (Request.QueryString["id"] != null) id = long.Parse(Request.QueryString["id"]);

            StringBuilder str1 = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt10 = new DataTable();
            dt10 = _clsdao.getDataset("select C.CustomerName,O.order_no,convert(varchar,GETDATE(),107) as date from Purchase_Order_Message O WITH(NOLOCK) INNER JOIN Customer C ON C.ID=O.vendor_code"
                    + " where O.id=" + filterstring(id.ToString()) + "").Tables[0];
            str1.Append("<tr>");
            foreach (DataRow dr in dt10.Rows)
            {
                str1.Append("<td align=\"left\" nowrap=\"nowrap\" class=\"NOBORDER\"><b> Supplier : </b> " + dr["CustomerName"].ToString() + "<br>"
                    + "<b> P.O.No : </b> " + dr["order_no"].ToString() + " </td>");

                str1.Append("<td align=\"right\" valign=\"top\" nowrap=\"nowrap\" class=\"NOBORDER\"><b> Date : </b> " + dr["date"].ToString() + "</td>");
            }
            str1.Append("</tr>");
            str1.Append("</table>");
            rptDiv1.InnerHtml = str1.ToString();
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");            
            
            str.Append("</tr>");
            DataTable dt = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt 'a',"+ filterstring(id.ToString()) +"").Tables[0];
            double amt = 0.00,qty=0.00;
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {                
                if (i == 3)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {                
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                         str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i == 4 || i == 5)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }                   
                }
                amt = amt + double.Parse(dr["AMOUNT"].ToString());
                qty = qty + double.Parse(dr["QTY"].ToString());
                str.Append("</tr>");
            }
            str.Append("<TR>");
                str.Append("<td colspan=\"3\">&nbsp;</td>");
                str.Append("<td align=\"center\"><b>" + qty.ToString() + "</b></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(amt.ToString()) + "</b></td></tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();

            DataTable dt1 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt 'a'," + filterstring(id.ToString()) + "").Tables[1];
            foreach (DataRow dr in dt1.Rows)
            {
                Desc.Text = "Purchase Order should be deliverd within 7 days.<br><br>"
                            +"<b> Note:  " + dr["remarks"].ToString()+"</b><br>";
                lblOrderDate.Text ="Date:  "+ dr["order_date"].ToString();
                lblOrderBy.Text = "Ordered By:  "+ dr["empname"].ToString();
                lblApproveDate.Text = "Date:  " + dr["approved_date"].ToString();
                lblApproveBy.Text = "Approved By:  " + dr["approvedby"].ToString();
            }
           
        }
    }
}
