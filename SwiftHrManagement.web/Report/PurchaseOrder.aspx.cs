using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report
{
    public partial class PurchaseOrder : BasePage
    {
        ClsDAOInv _clsdao = null;
        public PurchaseOrder()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadreport();       
        }
        private void loadreport()
        {
            long id = 0;
            string fromdate = Request.QueryString["fromdate"] == null ? "" : Request.QueryString["fromdate"].ToString();
            string todate = Request.QueryString["todate"] == null ? "" : Request.QueryString["todate"].ToString();
            if (Request.QueryString["id"] != null) id = long.Parse(Request.QueryString["id"]);


            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt10 = new DataTable();
            dt10 = _clsdao.getDataset(@"select C.CustomerName+', '+C.CustomerAddress CustomerName,CustomerPANNo,O.order_no,convert(varchar,GETDATE(),107) as date,
                                        convert(varchar,delivery_date,107) delivery_date 
                                        from Purchase_Order_Message O WITH(NOLOCK) INNER JOIN Customer C ON C.ID=O.vendor_code
                                        where O.id=" + filterstring(id.ToString()) + "").Tables[0];
            str1.Append("<tr>");
            foreach (DataRow dr in dt10.Rows)
            {
                str1.Append("<td align=\"left\" nowrap=\"nowrap\" class=\"NOBORDER\"><b> Vendor Name : </b> " + dr["CustomerName"].ToString() + "<br>"
                    + "<b> P.O.No : </b> " + dr["order_no"].ToString() + " </td>");

                str1.Append("<td align=\"right\" valign=\"top\" nowrap=\"nowrap\" class=\"NOBORDER\"><b>PAN No. :</b>" + dr["CustomerPANNo"].ToString() + "<br>"
                    +" <b>P.O. Date : </b> " + dr["date"].ToString() + "</td>");
                lblDeliverDate.Text ="Expected Delivery Date: "+ dr["delivery_date"].ToString();
            }
            str1.Append("</tr>");
            str1.Append("</table>");
            str1.Append("</table>");
            rptDiv1.InnerHtml = str1.ToString();

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");            
            
            str.Append("</tr>");
            DataTable dt = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt @flag='a',@id=" + filterstring(id.ToString()) + "").Tables[0];           
            
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {                
                if (i == 1 || i==4)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i > 4)
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
                    if (i == 1 || i == 4)
                    {
                         str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i>4)
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
            DataTable dt2 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt @flag='b',@id=" + filterstring(id.ToString()) + "").Tables[0];

            foreach (DataRow dr in dt2.Rows)
            {
                str.Append("<tr><td colspan=\"6\"><div align=\"right\"><b>Sub Total</b></div></td><td><div align=\"right\"><b>" + dr["Total"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"6\"><div align=\"right\"><b>VAT (13%) </b></div></td><td><div align=\"right\"><b>" + dr["VAT"].ToString() + "</b></div></td><tr>");
                str.Append("<tr><td colspan=\"6\"><div align=\"right\"><b>Grand Total</b></div></td><td><div align=\"right\"><b>" + dr["Grand_Amt"].ToString() + "</b></div></td><tr>");
            }            
            str.Append("</table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();

            StringBuilder str12 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">"); 
            DataTable dt1 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt @flag='c',@id=" + filterstring(id.ToString()) + "").Tables[0];
            int cols12 = dt1.Columns.Count;
            foreach (DataRow dr in dt1.Rows)
            {
                str12.Append("<tr>");
                for (int i = 0; i < cols12; i++)
                {
                    if (i == 0)
                    {
                        str12.Append("<td align=\"left\">" + dr[i].ToString() + ")</td>");
                    }
                    else
                    {
                        str12.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str12.Append("</tr>");
            }
            str12.Append("</table>");
            str12.Append("</div>");
            divNotes.InnerHtml = str12.ToString();

            StringBuilder str2 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">"); 
            DataTable dt12 = _clsdao.getDataset("exec ProcReceivePurchaseOrderRpt @flag='c',@id=" + filterstring(id.ToString()) + "").Tables[1];
            int cols123 = dt12.Columns.Count;
            foreach (DataRow dr in dt12.Rows)
            {
                str2.Append("<tr>");
                for (int i = 0; i < cols123; i++)
                {
                    if (i == 0)
                    {
                        str2.Append("<td align=\"left\" width='10px'>" + dr[i].ToString() + ")</td>");
                    }
                    else
                    {
                        str2.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str2.Append("</tr>");
            }  
            str2.Append("</table>");
            str2.Append("</div>");
            divSpecification.InnerHtml = str2.ToString();
        }
    }
}
