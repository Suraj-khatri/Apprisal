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

namespace SwiftHrManagement.web.Report
{
    public partial class received_order : BasePage
    {
        ClsDAOInv _clsdao = null;

        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        BranchCore _branchCore = null;
        BranchDao _branch = null;

        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        public received_order()
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

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

        }
        private void loadreport()
        {
            long id = 0;
            string fromdate = Request.QueryString["fromdate"] == null ? "" : Request.QueryString["fromdate"].ToString();
            string todate = Request.QueryString["todate"] == null ? "" : Request.QueryString["todate"].ToString();
            if (Request.QueryString["id"] != null) id = long.Parse(Request.QueryString["id"]);


            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
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
            str1.Append("</div>");
            rptDiv1.InnerHtml = str1.ToString();



            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            
            
            str.Append("</tr>");
            DataTable dt = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt 'r',"+ filterstring(id.ToString()) +"").Tables[0];           
            
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {                
                if (i == 3)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i > 3)
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
                    if (i == 3)
                    {
                         str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i>3)
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
            DataTable dt2 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt 'r'," + filterstring(id.ToString()) + "").Tables[2];
            double totAmt = 0.00;
            foreach (DataRow dr in dt2.Rows)
            {
                totAmt = Double.Parse(dr["VAT"].ToString()) + Double.Parse(dr["Total"].ToString());
                str.Append("<tr><td colspan=\"5\"><div align=\"right\"><b>Sub Total</b></div></td><td><div align=\"right\"><b>" + dr["Total"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"5\"><div align=\"right\"><b>VAT (13%) </b></div></td><td><div align=\"right\"><b>" + dr["VAT"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"5\"><div align=\"right\"><b>Grand Total</b></div></td><td><div align=\"right\"><b>" + ShowDecimal(totAmt.ToString()) + "</b></div></td><tr>");
            }            
            str.Append("</table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();

            DataTable dt1 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt 'r'," + filterstring(id.ToString()) + "").Tables[1];
            foreach (DataRow dr in dt1.Rows)
            {
                lblReceivedMsg.Text = "Note: Above products has been received for this purchase order.</b><br>";
                lblReceivedDate.Text = "Date:  " + dr["received_date"].ToString();
                lblReceivedBy.Text = "Received By:  " + dr["received_by"].ToString();
                lblDeliveredDate.Text = "Date:  " + System.DateTime.Now.ToString("MM/dd/yyyy");  
            }
           
        }
    }
}
