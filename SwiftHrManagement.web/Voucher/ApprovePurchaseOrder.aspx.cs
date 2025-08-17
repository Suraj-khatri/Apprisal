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

namespace SwiftAssetManagement.Voucher
{
    public partial class ApprovePurchaseOrder : BasePage
    {

        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsdao = null;
        public ApprovePurchaseOrder()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new ClsDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 113) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
             
                getOrderInfromation();
                GetProductHistory();
                GetPurchaseHistory();
            }
            init();

        }
        private void getOrderInfromation()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select p.id,p.status,order_no,convert(varchar,order_date,107) as order_date,c.CustomerName as vendor_code,remarks,"
                + " dbo.GetEmployeeFullNameOfId(forwarded_to) as forwarded_to,dbo.GetEmployeeFullNameOfId(created_by) as forwarded_by,"
                + " convert(varchar,created_date,107) as created_date from Purchase_Order_Message p inner join Customer c on c.id=p.vendor_code"
                + " WHERE p.id=" + filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                orderno.Text = dr["order_no"].ToString();
                orderdate.Text = dr["order_date"].ToString();
                vendorname.Text = dr["vendor_code"].ToString();
                //remarks.Text = dr["remarks"].ToString();
                forwardedby.Text = dr["forwarded_by"].ToString();
                forwardedto.Text = dr["forwarded_to"].ToString();
                forwardeddate.Text = dr["created_date"].ToString();
                status.Text = dr["status"].ToString();
                if (dr["status"].ToString() == "Approved")
                {
                    BtnSave.Visible = false;
                    BtnDelete.Visible = false;
                }
            }
        }
        private void GetProductHistory()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsdao.getTable("Exec [procGetProductHistory] @flag='a',@branch="+filterstring(ReadSession().Branch_Id.ToString())+","
                                        +" @msg_id="+filterstring(GetId().ToString())+"");

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"right\"  Class=\"HeaderStyle\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("</tr>");
            int cnt = 0;
            foreach (DataRow row in dt.Rows)
            {
                cnt++;
                if (cnt % 2 == 0)
                {
                    str.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\" >");
                }
                else
                {
                    str.Append("<tr class=\"GridEvenRow\" onMouseOver=\"this.className='GridEvenRowOver'\" onMouseOut=\"this.className='GridEvenRow'\">");
                }
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 1)
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                    else 
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rptProductHistory.InnerHtml = str.ToString();
        }
        private void GetPurchaseHistory()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsdao.getTable("Exec [procGetProductHistory] @flag='b',@branch=" + filterstring(ReadSession().Branch_Id.ToString()) + ","
                                        + " @msg_id=" + filterstring(GetId().ToString()) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"right\" Class=\"HeaderStyle\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            int cnt = 0;
            foreach (DataRow row in dt.Rows)
            {
                cnt++;
                if (cnt % 2 == 0)
                {
                    str.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\" >");
                }
                else
                {
                    str.Append("<tr class=\"GridEvenRow\" onMouseOver=\"this.className='GridEvenRowOver'\" onMouseOut=\"this.className='GridEvenRow'\">");
                }
                for (int i = 0; i < cols; i++)
                {
                    if (i == 4)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 1 || i==5)
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rptPurchaseHistory.InnerHtml = str.ToString();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
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


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert
            String[,] matfilter = new String[,]{  
                        {"IP.porduct_code",    "Product Code",         "LT"},   
                        {"IP.product_desc",    "Product Name",         "LT"},
                        {"qty",    "Quantity",         "EN"}
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        {"prod_code",            "Prod Code",             "200",      "D"},
                        {"Product",            "Product Name",             "200",      "T"},
                        {"qty",       "Quantity",        "200",      "D"},
                        {"rate",    "Rate",     "200",      "M"},
                        {"amount",    "Amount",     "200",      "M"}                   
                        };



            string sortby = "id";
            string table_name = "Purchase_Order";

            String sql = "";
            
            sql = "SELECT P.id,order_message_id,IP.Id as prod_code,IP.porduct_code AS Product ,qty,dbo.ShowDecimal(rate) as rate,"
                + " dbo.ShowDecimal(amount) as amount FROM Purchase_Order p inner join IN_PRODUCT IP ON IP.id=P.product_code WHERE "
                +" order_message_id="+filterstring(GetId().ToString())+"";
          
            //forwarded_to=" + filterstring(ReadSession().emp) + "
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

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size) + "</center>";

        }
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size)
        {
            ClsDAOInv db = new ClsDAOInv();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";          

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "ApprovePurchaseOrder.aspx?sortd=" + sortd + "&sortby={sortby}&Id="+GetId()+"";


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
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("</tr>");
            double amt = 0.00;
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
                        case "M":
                            html.Append("<td align=\"right\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "D":
                            html.Append("<td align=\"center\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        default:
                            html.Append("<td align=\"left\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                    }
                    
                }
                amt = amt + double.Parse(dr["amount"].ToString());
                html.Append("</tr>");
            }
            string VatAmt="";
            VatAmt = _clsdao.GetSingleresult("select isnull(vat_amt,0) from Purchase_Order_Message where id=" + GetId() + "");
            double netAmt = double.Parse(VatAmt) + amt;

            html.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\"> <td align=\"right\" colspan='4'><b>Sub Total</b></td>");
            html.Append("<td align=\"right\"><b>" + ShowDecimal(amt.ToString()) + "</b></td></tr>");
            html.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\"> <td align=\"right\" colspan='4'><b>13% VAT</b></td>");
            html.Append("<td align=\"right\"><b>" + ShowDecimal(VatAmt.ToString()) + "</b></td></tr>");
            html.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\"> <td align=\"right\" colspan='4'><b>Net Total</b></td>");
            html.Append("<td align=\"right\"><b>" + ShowDecimal(netAmt.ToString()) + "</b></td></tr>");
            
            html.Append("</table>");
            html.Append("</div>");


            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "");


            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<table width=\"600\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");

            //html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            //html.Append("<tr>");
            //html.Append("<td class=\"GridTextNormal\" align=\"center\"><b>Filtered results</b>&nbsp;&nbsp;&nbsp;<a href=\"javascript:newTableToggle('td_Search', 'img_Search');\"><img src=\"/images/icon_show.gif\" border=\"0\" alt=\"Show\" id=\"img_Search\"></a></td>");
            //html.Append("</tr>");
            //html.Append("<tr>");
            //html.Append("<td id=\"td_Search\" style=\"display:none\" align=\"center\">");
            //html.Append("<table cellpadding=\"2\" cellspacing=\"2\" border=\"0\" width=\"400\">");

            //int arr_cnt = matfilter.GetUpperBound(0);
            //string ctlName = "";
            //string defValue = "";
            //for (int i = 0; i <= arr_cnt; i++)
            //{
            //    html.Append("<tr>");
            //    html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">" + matfilter.GetValue(i, 1).ToString() + "</td>");

            //    ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

            //    if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
            //        defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

            //    if (Request.Form[ctlName] != null)
            //        defValue = Request.Form[ctlName].ToString();

            //    Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

            //    html.Append("<td width=\"200\"><input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\"></td>");
            //    html.Append("</tr>");
            //}
            //html.Append("<tr>");
            //html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">&nbsp;</td>");
            //html.Append("<td width=\"200\"><input type=\"button\" value=\"Filter\" class=\"button\" onclick=\"submit_form();\"></td>");
            //html.Append("</tr>");
            //html.Append("</table>");
            //html.Append("</td>");
            //html.Append("</tr>");
            //html.Append("</table>");

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
        private string get_paging_block(int _total_record, int _page, int _page_size, Boolean _show_add_button, string _add_page)
        {

            StringBuilder html = new StringBuilder("<input type = \"hidden\" name=\"hdd_curr_page\" id = \"hdd_curr_page\" value=\"" + _page.ToString() + "\">");
            //html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            //html.Append("<tr>");
            //html.Append("<td width=\"247\" class=\"GridTextNormal\">Result :&nbsp;<b>" + _total_record.ToString() + "</b>&nbsp;records&nbsp;");
            //html.Append("<select name=\"ddl_per_page\" onChange=\"submit_form();\">");
            //html.Append("<option value=\"10\"" + autoSelect("10", _page_size.ToString()) + ">10</option>");
            //html.Append("<option value=\"20\"" + autoSelect("20", _page_size.ToString()) + ">20</option>");
            //html.Append("<option value=\"30\"" + autoSelect("30", _page_size.ToString()) + ">30</option>");
            //html.Append("<option value=\"40\"" + autoSelect("40", _page_size.ToString()) + ">40</option>");
            //html.Append("<option value=\"50\"" + autoSelect("50", _page_size.ToString()) + ">50</option>");
            //html.Append("</select>&nbsp;&nbsp;per page");
            //html.Append("</td>");
            //html.Append("<td width=\"539\" align=\"right\">");

            //if (_page > 1)
            //    html.Append("<a href=\"JavaScript:nav('" + (_page - 1).ToString() + "');\" title='Previous page'><img src='/images/prev.gif' border='0'></a>&nbsp;&nbsp;&nbsp;");
            //else
            //    html.Append("<img src='/images/prev.gif' border='0'>&nbsp;&nbsp;&nbsp;");

            //if (_page * _page_size < _total_record)
            //    html.Append("<a href=\"JavaScript:nav('" + (_page + 1).ToString() + "');\" title='Next page'><img src='/images/next.gif' border='0'></a>&nbsp;&nbsp;&nbsp;");
            //else
            //    html.Append("<img src='/images/next.gif' border='0'>&nbsp;&nbsp;&nbsp;");

            //if (_show_add_button)
            //    //html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' border='0'></a>");
            //    html.Append("</td>");
            //html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion

        private void manageapproval()
        {
            _clsdao.runSQL("proc_Approve_PurchaseOrder 'a'," + filterstring(GetId().ToString()) + ",'" + ReadSession().Emp_Id + "'");
        }

        private void manageForward()
        {
            string[] e =frwdEmployee. Text.Split('|');
            string emp_id = e[1];

            _clsdao.runSQL("exec proc_Approve_PurchaseOrder 'f'," + filterstring(GetId().ToString()) + "," + filterstring(emp_id) + "");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (rdoApprove.Checked == false && rdoForward.Checked == false)
                {
                    lblmsg.Text = "Please Specify Approve or Forward";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (rdoForward.Checked == true && rdoApprove.Checked == false)
                    {
                        if (frwdEmployee.Text != "" && frwdEmployee.Text != null)
                        {
                            manageForward();
                            Response.Redirect("ListPurchaseOrder.aspx");
                        }
                        else
                            lblmsg.Text = "Please Specify Employee Name";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        manageapproval();
                        Response.Redirect("ListPurchaseOrder.aspx");
                    }
                }

                //_clsdao.runSQL("update Purchase_Order_Message set approved_by="+filterstring(ReadSession().Emp_Id.ToString())+",approved_date="+filterstring(System.DateTime.Now.ToString())+",status='Approved' where id="+filterstring(GetId().ToString())+"");
                //Response.Redirect("ListPurchaseOrder.aspx");
            }
            catch
            {
                lblmsg.Text = "Could not be approved the order request!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("update Purchase_Order_Message set cancelled_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ",cancelled_date=" + filterstring(System.DateTime.Now.ToString()) + ",status='Cancelled' where id=" + filterstring(GetId().ToString()) + "");
                Response.Redirect("ListPurchaseOrder.aspx");
            }
            catch
            {
                lblmsg.Text = "Could not be Cancelled the order request!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPurchaseOrder.aspx");
        }

        protected void rdoApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoApprove.Checked == true)
            {
                lblmsg.Text = "";
                rdoForward.Checked = false;
                lblFdEmp.Visible = false;
                frwdEmployee.Visible = false;
                BtnForwrd.Visible = false;
                BtnSave.Visible = true;
            }

        }

        protected void rdoForward_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoForward.Checked == true)
            {
                lblmsg.Text = "";
                rdoApprove.Checked = false;
                lblFdEmp.Visible = true;
                frwdEmployee.Visible = true;
                BtnSave.Visible = false;
                BtnForwrd.Visible = true;
            }
        }

        //protected void BtnForwrd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdoApprove.Checked == false && rdoForward.Checked == false)
        //        {
        //            lblmsg.Text = "Please Specify Approve or Forward";
        //            lblmsg.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            if (rdoForward.Checked == true && rdoApprove.Checked == false)
        //            {
        //                if (frwdEmployee.Text != "" && frwdEmployee.Text != null)
        //                {
        //                    manageForward();
        //                    Response.Redirect("ListPurchaseOrder.aspx");
        //                }
        //                else
        //                    lblmsg.Text = "Please Specify Employee Name";
        //                    lblmsg.ForeColor = System.Drawing.Color.Red;
        //            }
        //        }
        //    }
        //    catch 
        //    {
 
        //    }
        //}
    }
}
