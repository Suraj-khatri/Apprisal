using System;
using System.Data;
using System.Text;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Requisition
{
    public partial class EditRequisition : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        String DelProduct = "";
        ClsDAOInv _clsdao = null;
        public EditRequisition()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 119) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                CreateDdlList();

                populaterequisition();
                string status = _clsdao.GetSingleresult("select status from IN_Requisition_Message where id="+GetReqId()+"");
                if (status != "Requested")
                {
                    btnSave.Visible = false;
                    BtnDelete.Visible = false;
                    BtnDeleted.Visible = false;
                    BtnAdd.Visible = false;
                }
                if (status == "Rejected")
                {
                    RejectionDetails.Visible = true;
                    DataTable dt = _clsdao.getTable("select dbo.GetEmployeeFullNameOfId(rejected_by) as rejected_by,convert(varchar,rejected_date,107) as rejected_date"
                                                    +" ,rejected_message from IN_Requisition_Message where id= " + GetReqId() + "");
                    foreach (DataRow dr in dt.Rows)
                    {
                        rejectedBy.Text = dr["rejected_by"].ToString();
                        rejectedDate.Text = dr["rejected_date"].ToString();
                        rejectedMsg.Text = (dr["rejected_message"].ToString());                        
                    }  
                }
            }            
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();
            init();
            AutoCompleteExtender2.ContextKey = ReadSession().Branch_Id.ToString();
            
        }
        private long GetReqId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
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
                    {"ip.porduct_code",    "Product Name",         "LT"},   
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        
                        {"porduct_code",      "Product",         "200",     "T"},
                        {"quantity",       "Quantity",        "10",      "M"},
                        {"package_unit",           "Unit",            "10",      "T"}
                        };

            string sortby = "id";
            string table_name = "IN_Requisition";

            String sql = " SELECT r.id,ip.porduct_code,ip.package_unit,r.quantity FROM IN_Requisition r "
                        + " INNER JOIN IN_PRODUCT ip ON ip.id=r.item WHERE Requistion_message_id=" + GetReqId() + "";
            
            
            /************************* editable vairable ends***************************************/

            string _page_size = "50";
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

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "EditListView.aspx?sortd=" + sortd + "&sortby={sortby}";


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
            html.Append("<th align=\"left\">Delete</th>");
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
                html.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                html.Append("</tr>");
            }
            html.Append("</table></table>");
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
        private void Deleteproduct()
        {
            if (DelProduct != "")
            {
                LblMsg.Text = _clsdao.GetSingleresult("exec proc_IN_Editrequisition 'd', @id='" + DelProduct + "',@msgid=" + GetReqId() + "");
            }
            init();
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Deleteproduct();
        }
        private string Getproductunit(int itemID)
        {
            string strunit = "";
            strunit = _clsdao.GetSingleresult("select package_unit from IN_PRODUCT where id = " + itemID + "");
            return strunit;
        }
        private void addproduct()
        {
            int itemID = 0;
            string[] item = product.Text.Split('|');
            itemID = int.Parse(item[1]);

            string msg = _clsdao.GetSingleresult("exec proc_IN_Editrequisition @flag='a',@item=" + filterstring(itemID.ToString()) + ","
                            + " @quantity=" + filterstring(quantity.Text) + ",@unit=" + filterstring(Getproductunit(itemID)) + ","
                            + " @msgid=" + filterstring(GetReqId().ToString()) + ",@branch="+filterstring(ReadSession().Branch_Id.ToString())+"");

            if (msg.Contains("Sorry"))
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        protected void BtnAdd_Click(object sender, EventArgs e)             
        {
            addproduct();
            init();
        }

        private void CreateDdlList()
        {
            _clsdao.CreateDynamicDDl(DdlBranchRqe, "select BRANCH_ID, BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "select");
            _clsdao.CreateDynamicDDl(DdlEmpName, "EXEC [procGetSupervisor] @FLAG='a',@EMP_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMP_ID", "SUPERVISOR", "", "SELECT");

        }
        private void proc_IN_Editrequisition()
        {
         
            string result = _clsdao.GetSingleresult("SELECT DBO.GetSchDay(" + filterstring(ReadSession().Branch_Id.ToString()) + ")");
            if (Convert.ToInt64(ReadSession().Branch_Id) != Convert.ToInt64(DdlBranchRqe.Text) && result == "0" && txtUnschReqMsg.Text == "")
            {
                LblMsg.Text = "Please give reason for unschedule requisition!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            LblMsg.Text = _clsdao.GetSingleresult("exec proc_IN_Editrequisition @flag='u',@forwarded_to=" + filterstring(DdlBranchRqe.Text) + ","
                                + " @department=" + filterstring(ReadSession().Department.ToString()) + ",@branch=" +filterstring(ReadSession().Branch_Id.ToString()) + ","
                                + " @priority=" + filterstring(Ddlpriority.Text) + ",@approverid = " + filterstring(DdlEmpName.Text) + ","
                                + " @msgid = " + filterstring(GetReqId().ToString()) + ",@message=" + filterstring(TxtMessage.Text) + ","
                                + " @unSchReason=" + filterstring(txtUnschReqMsg.Text) + "");
        }
        private void populaterequisition()
        {
            DataTable dt = _clsdao.getTable(@"select m.Forwarded_To,  m.priority, m.Requ_Message,
             M.recommed_by,UNSCHEDULE_REASON
             from IN_Requisition_Message m inner join Branches b on m.branch_id = b.branch_id 
             where m.id = " + GetReqId()+"");
            foreach (DataRow dr in dt.Rows)
            {
                DdlBranchRqe.SelectedValue = dr["Forwarded_To"].ToString();
                Ddlpriority.Text = dr["priority"].ToString();
                TxtMessage.Text = dr["Requ_Message"].ToString();
                DdlEmpName.SelectedValue = (dr["recommed_by"].ToString());
                if (dr["UNSCHEDULE_REASON"].ToString() == "")
                {
                    unschPnl.Visible = false;
                }
                else
                {
                    unschPnl.Visible = true;
                    txtUnschReqMsg.Text = dr["UNSCHEDULE_REASON"].ToString();
                }
                DdlBranchRqe.Enabled = false;
            }
            
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            proc_IN_Editrequisition();
            Response.Redirect("RequisitionList.aspx");
        }

        protected void DdlBranchRqe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBranchRqe.Text != "")
            {
                string result = _clsdao.GetSingleresult("SELECT DBO.GetSchDay(" + filterstring(ReadSession().Branch_Id.ToString()) + ")");
                if (Convert.ToInt64(ReadSession().Branch_Id) != Convert.ToInt64(DdlBranchRqe.Text) && result == "0")
                    unschPnl.Visible = true;
                else
                    unschPnl.Visible = false;
            }
            else
            {
                unschPnl.Visible = false;
            }
        }
        #endregion

        protected void BtnDeleted_Click(object sender, EventArgs e)
        {
            _clsdao.runSQL("Exec ProcDeleteRequisition 'a'," + filterstring(GetReqId().ToString()) + "");
            Response.Redirect("RequisitionList.aspx");
        }
    }

}
