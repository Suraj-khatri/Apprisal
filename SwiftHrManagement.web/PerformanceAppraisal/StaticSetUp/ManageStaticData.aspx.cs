using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.DAL.StaticDataDetailsDAO;
using SwiftHrManagement.DAL.StaticDataTypeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.StaticSetUp
{
    public partial class ManageStaticData : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        StaticDataDetailsDAO _dataDetailDao = null;
        StaticDataDetailCore _dataDetailCore = null;
        StaticDataTypeDAO _dataTypeDao = null;
        StaticDataTypeCore _dataTypeCore = null;
        clsDAO _clsdao = null;
        public ManageStaticData()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();  
            _dataDetailDao = new StaticDataDetailsDAO();
            _dataDetailCore = new StaticDataDetailCore();
            _dataTypeDao = new StaticDataTypeDAO();
            _dataTypeCore = new StaticDataTypeCore();
        }
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetTypeId()
        {
            return (Request.QueryString["TypeID"] != null ? long.Parse(Request.QueryString["TypeID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 32) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetId() > 0)
                {
                    PopulateDataDetail();
                }
                else
                {
                    TxtTypeId.Text = GetTypeId().ToString();
                    
                }
                this._dataTypeCore = this._dataTypeDao.FindByTypeId(long.Parse(TxtTypeId.Text));
                this.TxtDataType.Text = this._dataTypeCore.Type_title;
            }
            init();

        }
        private void PopulateDataDetail()
        {
            this._dataDetailCore = this._dataDetailDao.FindById(GetId());
            this.TxtTypeId.Text = this._dataDetailCore.Type_id;
            this.TxtDetailTitle.Text = this._dataDetailCore.Detail_title;
            this.TxtDetailDesc.Text = this._dataDetailCore.Detail_desc;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetId() > 0)
                {
                    string check = _clsdao.GetSingleresult("select isnull(IS_DELETE,'Y') from StaticDataDetail where ROWID='" + GetId() + "'");
                    if (check == "N")
                    {
                        LblMsg.Text = "Sorry! System generated data can not be modified!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        manageDataDetail();
                        
                        //Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                    }
                }
                else
                {
                    manageDataDetail();
                    //Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                }
                init();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            TxtDetailDesc.Text = "";
            TxtDetailTitle.Text = "";
        }
        private void manageDataDetail()
        {
            long id = GetId();
            this.PrepareDataDetail();
            if (id > 0)
            {
                _dataDetailCore.ModifyBy = this.ReadSession().UserId;
                _dataDetailDao.Update(this._dataDetailCore);

            }
            else
            {
                _dataDetailCore.CreatedBy = this.ReadSession().UserId;
                _dataDetailDao.Save(this._dataDetailCore);
            }
        }
        private void PrepareDataDetail()
        {
            StaticDataDetailCore _dataDetailCore = new StaticDataDetailCore();
            long Id = this.GetId();
            if (Id > 0)
            {
                _dataDetailCore.Id = Id;
            }
            _dataDetailCore.Type_id = TxtTypeId.Text;
            _dataDetailCore.Detail_title = TxtDetailTitle.Text;
            _dataDetailCore.Detail_desc = TxtDetailDesc.Text;
            this._dataDetailCore = _dataDetailCore;
        }

      
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
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
                        {"DETAIL_TITLE",    "Data Title",         "LT"}                 
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                       
                        {"DETAIL_TITLE",            "Data Title",               "200",      "T"},
                        {"DETAIL_DESC",             "Data Description",          "200",      "T"}
                        };



            string sortby = "ID";
            string table_name = "StaticDataDetail";

            String sql = "";

            sql = "SELECT ROWID as ID,TYPE_ID,DETAIL_TITLE,DETAIL_DESC FROM StaticDataDetail where TYPE_ID='" + GetTypeId() + "'";

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

            rpt.InnerHtml = load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size);
        }
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size)
        {
            clsDAO db = new clsDAO();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "StaticDataDetailView.aspx?sortd=" + sortd + "&sortby={sortby}&ID=" + GetTypeId() + "";


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
            html.Append("<td>S.No.</td>");
            int sNo = 1;
            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th clas   s=\"text-center\" align=\"center\">Action</th>");
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

                html.Append("<td>" + sNo + "</td>");
                sNo++;
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
                html.Append("<td class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" onclick = \"DeleteNotification('" + dr["ID"] + "')\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete Static Data\" href=\"#\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                html.Append("</tr>");
            }

            html.Append("<tr> <td align=\"center\" colspan=\"4\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("</table>");
            html.Append("</div>");

            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/StaticView/ManageDataDetail.aspx?TypeID=" + GetTypeId() + "");


            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<div class=\"col-md-12 filter-bg\">");

            html.Append("<div class=\"pull-right\" ><a class=\"btn btn-primary  btn-md\" align=\"center\" href=\"javascript:newTableToggle('td_Search', 'img_Search');\"><i class=\"fa fa-filter\" id=\"img_Search\"></i> </a></div>");
            html.Append("<div class=\"clear-fix\"></div>");
            html.Append("<div id=\"td_Search\" style=\"display:none; width:100%; float:left;\" align=\"left\">");

            int arr_cnt = matfilter.GetUpperBound(0);
            string ctlName = "";
            string defValue = "";
            for (int i = 0; i <= arr_cnt; i++)
            {
                html.Append("<div class=\" col-md-3\">");
                html.Append("<div class=\" form-group\">");
                html.Append("<label align=\"left\">" + matfilter.GetValue(i, 1).ToString() + "</label>");

                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

                //if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                //    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                //Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

                html.Append("<input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\" class=\"form-control\">");
                html.Append("</div>");
                html.Append("</div>");
            }
            html.Append("<div class=\" col-md-3\">");
            html.Append("<div><input type=\"button\" value=\"Filter\" class=\"btn-filter btn btn-success\" onclick=\"submit_form();\"></div>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");

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
            html.Append("<div class=\"col-md-12 result-bg\">");
            html.Append("<div class=\"row\">");
            html.Append("<div class=\"col-md-7 text-left\">");
            html.Append("<div class=\"form-inline\">");
            html.Append("<div class=\"form-group\">Result");
            html.Append("</div>");
            html.Append("<div class=\"form-group\"><b>" + _total_record.ToString() + "</b>");
            html.Append("</div>");
            html.Append("<div class=\"form-group\">");
            html.Append("<select class=\"form-control\"  aria-describedby=\"sizing-addon3\" name=\"ddl_per_page\" onChange=\"submit_form();\">");
            html.Append("<option value=\"10\"" + autoSelect("10", _page_size.ToString()) + ">10</option>");
            html.Append("<option value=\"20\"" + autoSelect("20", _page_size.ToString()) + ">20</option>");
            html.Append("<option value=\"30\"" + autoSelect("30", _page_size.ToString()) + ">30</option>");
            html.Append("<option value=\"40\"" + autoSelect("40", _page_size.ToString()) + ">40</option>");
            html.Append("<option value=\"50\"" + autoSelect("50", _page_size.ToString()) + ">50</option>");
            html.Append("</select>");
            html.Append("</div>");
            html.Append("<div class=\"form-group\"> Per Page");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("<div class=\"col-md-5 text-right\">");

            if (_page > 1)
                html.Append("<a class=\"tool btn btn-default\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Previous\"  href=\"JavaScript:nav('" + (_page - 1).ToString() + "');\" title='Previous page'><i class=\"fa fa-arrow-left\"></i></a>");
            else
                html.Append("<span class=\"btn btn-default\"> <i class=\"fa fa-arrow-left\" aria-hidden=\"true\"></i></span>");

            if (_page * _page_size < _total_record)
                html.Append("<a class=\"tool btn btn-default\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Next\" href=\"JavaScript:nav('" + (_page + 1).ToString() + "');\" title='Next page'><i class=\"fa fa-arrow-right\"></i></a>");
            else
                html.Append("<span class=\"btn btn-default\"><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i></span>");

            if (_show_add_button)
                html.Append("<a class=\"tool btn btn-default\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Add\" href=\"" + _add_page + "\" title=\"Add a new record\"><i class=\"fa fa-plus\"></i></a>");
            html.Append("</div>");
            html.Append("</div></div>");

            return html.ToString();
        }
        #endregion

       protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            try
            {
                string check = _clsdao.GetSingleresult("select isnull(IS_DELETE,'Y') from StaticDataDetail where ROWID='" + hdnDeleteId.Value + "'");
                if (check == "N")
                {
                    LblMsg.Text = "Sorry! System generated data can not be deleted!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    this._dataDetailDao.DeleteById(long.Parse(hdnDeleteId.Value), ReadSession().UserId);
                    //Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                }
                init();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }





    }
}

