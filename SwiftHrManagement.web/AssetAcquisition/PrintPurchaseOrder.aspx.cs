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

namespace SwiftHrManagement.web.AssetAcquisition
{
    public partial class PrintPurchaseOrder : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        public PrintPurchaseOrder()
        {
            _clsdao = new ClsDAOInv();
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
            this._CompanyCore = _company.FindCompany();
            //this.lblHeading.Text = string.Empty;
            //this.lbldesc.Text = _CompanyCore.Address;
        }
        private void loadreport()
        {
            long id = 0;
            string fromdate = Request.QueryString["fromdate"] == null ? "" : Request.QueryString["fromdate"].ToString();
            string todate = Request.QueryString["todate"] == null ? "" : Request.QueryString["todate"].ToString();
            if (Request.QueryString["id"] != null) id = long.Parse(Request.QueryString["id"]);


            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt10 = new DataTable();
            dt10 = _clsdao.getDataset("select C.CustomerName,O.order_no,convert(varchar,GETDATE(),107) as date from ASSET_PURCHASE_ORDER_MESSAGE O WITH(NOLOCK) INNER JOIN Customer C ON C.ID=O.vendor_id"
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
            str1.Append("</div>");
            rptDiv1.InnerHtml = str1.ToString();



            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            
            
            str.Append("</tr>");
            DataTable dt = _clsdao.getDataset("exec ProcPrintAssetPurchaseOrder 'o'," + filterstring(id.ToString()) + "").Tables[0];           
            
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {                
                if (i == 0 || i==2)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i > 2)
                {
                    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
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
                    if (i == 0 || i == 2)
                    {
                         str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i>2)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                   
                }
                str.Append("</tr>");
            }
            DataTable dt2 = _clsdao.getDataset("exec ProcPrintAssetPurchaseOrder 'o'," + filterstring(id.ToString()) + "").Tables[2];
            double totAmt = 0.00;
            foreach (DataRow dr in dt2.Rows)
            {
                totAmt = Double.Parse(dr["VAT"].ToString()) + Double.Parse(dr["Total"].ToString());
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>Sub Total</b></div></td><td><div align=\"right\"><b>" + dr["Total"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>VAT (13%) </b></div></td><td><div align=\"right\"><b>" + dr["VAT"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>Grand Total</b></div></td><td><div align=\"right\"><b>" + ShowDecimal(totAmt.ToString()) + "</b></div></td><tr>");
            }            
            str.Append("</table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();

            DataTable dt1 = _clsdao.getDataset("exec ProcPrintAssetPurchaseOrder 'o'," + filterstring(id.ToString()) + "").Tables[1];
            foreach (DataRow dr in dt1.Rows)
            {
                lblReceivedMsg.Text = dr["remarks"].ToString() + "<br><br><b>This order should be delivered within " + dr["deliver_date"].ToString()+".</b>";
                lblAuthorisedDate.Text = "Date:  " + System.DateTime.Now.ToString("MM/dd/yyyy");  
                lblOrderBy.Text = "Ordered By:  " + dr["order_by"].ToString();
                lblOrderedDate.Text = "Date:  " + dr["order_date"].ToString(); 
            }
           
        }
    }
}
