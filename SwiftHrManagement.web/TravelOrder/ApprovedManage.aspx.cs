using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class ApprovedManage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        TravelOrderDao _travelOrderDao = null;
        
        public ApprovedManage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._travelOrderDao = new TravelOrderDao();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetID() > 0)
                {
                    PopulateTravelAuthorisation();
                    populateCurrencyAmount(GetTadaId().ToString());
                    populateAuthorisedBy(GetTadaId().ToString());
                }
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 172) == false) //242
                {
                    Response.Redirect("/Error.aspx");
                }
                this.lblreadsession.Text = ReadSession().Emp_Id.ToString();
            }

           // BtnBack.Attributes.Add("onclick", "history.back();return false");
            //txtExtensionNum.Attributes.Add("onblur", "checknumber(this);");
            
        }

        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        public void PopulateTravelAuthorisation()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("exec proc_travel @flag='a', @id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            this.LblEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();

            this.lblbranch.Text = dr["branch_name"].ToString();
            this.lbldepartment.Text = dr["department_name"].ToString();
            this.lblposition.Text = dr["detail_title"].ToString();
            this.lblcity.Text = dr["destination_city"].ToString();
            this.lblcountry.Text = dr["country"].ToString();
            this.lblreasontravel.Text = dr["reason_for_travel"].ToString();
            if (this.lblreasontravel.Text == "Transfer")
            {
                this.divtraveldate.Visible = false;
            }

            this.lblfromdate.Text = dr["duration_from"].ToString();
            this.lbltodate.Text = dr["duration_to"].ToString();
            
                this.lblextension.Text = dr["extension"].ToString();

            if (this.lblextension.Text == "Yes")
            {
                this.divIsExtVisit.Visible = true;
                this.lblextfrom.Text = dr["durex_from"].ToString();
                this.lblextto.Text = dr["durex_to"].ToString();
                this.lblextcity.Text = dr["durex_city"].ToString();
                this.Lblextcountry.Text = dr["extension_country"].ToString();
                this.lblleaveaaplied.Text = "Yes";
                this.lblremainingdays.Text = dr["dur_leave"].ToString();
            }
           
            this.lblmode.Text = dr["mode_of_travel"].ToString();
            this.lbltransportation.Text = dr["transportation"].ToString();
            this.lblaccomodation.Text = dr["accomodation"].ToString();
            this.lblfooding.Text = dr["fooding"].ToString();
            this.lblcashadvance.Text = dr["cashadvance"].ToString();
            this.lblauthor.Text = dr["authorised_id"].ToString();
            

            if (this.lblcashadvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
                //this.lblcurrency.Text = dr["currency"].ToString();
                //this.lblamount.Text = dr["amount"].ToString();
            }
            //this.lblauthorisedy.Text = dr["authorised_by"].ToString();

            if(dr["tada_status"].ToString()=="pending")
            {
                this.BtnVerify.Visible = false;
            }
            else if (dr["tada_status"].ToString() == "approved" || dr["tada_status"].ToString() == "rejected" || dr["tada_status"].ToString() == "verified")
            {
                if (dr["authorised_id"].ToString() == ReadSession().Emp_Id.ToString() ||dr["emp_id"].ToString() == ReadSession().Emp_Id.ToString())
                {
                    this.BtnSave.Visible = false;
                    this.BtnVerify.Visible = false;
                    this.BtnReject.Visible = false;
                    btnAdd.Visible = false;
                }

                else
                {
                    this.BtnVerify.Visible = true;
                    this.BtnSave.Visible = false;
                }
            }
            else
            {
                this.BtnVerify.Visible = false;
                this.BtnReject.Visible = false;
                this.BtnSave.Visible = false;
                btnAdd.Visible = false;
            }

            if (lblmode.Text == "By Air" && lbltransportation.Text == "To be Paid By Bank")
            {
                divflightDetails.Visible = true;
                lblFlightDate.Text = dr["flightDate"].ToString();
                lblFromPlace.Text = dr["fromPlace"].ToString();
                lblToPlace.Text = dr["toPlace"].ToString();
                lblFlightTime.Text = dr["flightTime"].ToString();
                lblReturnFlightDate.Text = dr["returnFlightDate"].ToString();
                lblReturnFromPlace.Text = dr["ReturnFromPlace"].ToString();
                lblReturnToPlace.Text = dr["returnToPlace"].ToString();
                lblReturnFlightTime.Text = dr["returnFlightTime"].ToString();
            }
            else if (dr["flightDate"] == null)
            {
                divflightDetails.Visible = false;
            }
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
          AcceptStatus();
          Response.Redirect("pendingrequestlist.aspx");
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            AcceptStatusByHr();
            Response.Redirect("ApprovedRequestList.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

            if (FlagId() == 1)
            {
                Response.Redirect("PendingRequestList.aspx"); 
            }
            else
            {
                Response.Redirect("ApprovedRequestList.aspx");  
            }
        }

        private long FlagId()
        {
            return (Request.QueryString["flagId"] != null ? long.Parse(Request.QueryString["flagId"].ToString()) : 0);
        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            RejectStatus();
            string str = ReadSession().Emp_Id.ToString();

            if (FlagId() == 1)
            {
                Response.Redirect("pendingrequestlist.aspx"); 
            }
            else
            {
                Response.Redirect("ApprovedRequestList.aspx"); 
            }
        }
        
        private void AcceptStatusByHr()
        {
            CLsDAo.GetSingleresult("UPDATE tada SET tada_status='verified' WHERE id=" + filterstring(GetID().ToString()));
        }

        private void AcceptStatus()
        {
            string sql;
            sql = "EXEC [Proc_Travel] @flag='ae', @user=" + filterstring(this.ReadSession().Emp_Id.ToString()) + ", @tadaId=" + filterstring(GetID().ToString());
            var dt = CLsDAo.ExecuteDataset(sql).Tables[0];

            printMsg.Text = dt.Rows[0]["return_message"].ToString();
            printMsg.Visible = true;
            //string sql =
            //    CLsDAo.GetSingleresult("update tada set tada_status='approved' where  id=" +
            //                           filterstring(GetID().ToString()));
             //, @user=" + filterstring(this.ReadSession().UserId) + 
            //"EXEC [Proc_Travel] @flag='ae', @user=" + filterstring(this.ReadSession().Emp_Id.ToString()) + "@tadaId=" + filterstring(GetID().ToString())
        }

        private void RejectStatus()
        {
            CLsDAo.GetSingleresult(("update tada set tada_status='rejected' where id=" +
                                                 filterstring(GetID().ToString())));
        }

        private void populateAuthorisedBy(String tadaId)
        {
            StringBuilder str1 = new StringBuilder("<table width=\"200\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            var dt = CLsDAo.getDataset("EXEC Proc_Travel @flag='s',@Id=" + filterstring(tadaId) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            str1.Append("<tr>");
            str1.Append("<th>S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str1.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str1.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str1.Append("<tr>");
                str1.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str1.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rpt.InnerHtml = str1.ToString();
        }

        private void populateCurrencyAmount(String tadaId)
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _travelOrderDao.FindCurrencyAndAmt(tadaId);

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {
                    if (i == 2)
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
            str.Append("</table>");
            str.Append("</div>");
            rpt2.InnerHtml = str.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            lblAuthorisedBy.Text = "";

            string[] arrayAuthorisedBy = txtAuthorisedBy.Text.Split('|');
            string authorisedBy = arrayAuthorisedBy[1];

            if (authorisedBy == ReadSession().Emp_Id.ToString())
            {
                printMsg.Text = "Assign is not valid";
                printMsg.Visible = true;
                return;
            }
            string sql;
            sql = "EXEC Proc_Travel @flag='ia',@FLG ='af',@authorised_by=" + filterstring(authorisedBy) + ",@tadaId = " + filterstring(GetID().ToString()) + ",@session_id=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";

            var dt = CLsDAo.ExecuteDataset(sql); //.Tables[0]
            var Tcount = dt.Tables.Count;
            if (Tcount == 1)
            {
                printMsg.Text = dt.Tables[0].Rows[0]["return_message"].ToString();
                printMsg.Visible = true;

            }
            else
            {
                DisplayAuthorisedBy(dt.Tables[0]);
                txtAuthorisedBy.Text = "";
            }
            Response.Redirect(Request.RawUrl);

            //Response.Redirect("ApprovedManage.aspx?flagID=" + FlagId().ToString() + "&id" + GetID().ToString());
        }

        private void DisplayAuthorisedBy(DataTable dt)
        {
            lblAuthorisedBy.Text = "";

            StringBuilder str = new StringBuilder("<table width=\"350\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            if (dt == null)
                dt = CLsDAo.getDataset("EXEC Proc_Travel @flag='s',@session_id=" + filterstring(ReadSession().Sessionid) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            str.Append("<tr>");
            str.Append("<th>Sn</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th>Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\"><img OnClick='OnDelete(" + dr["Id"] + ")' class=\"clickimage\" src=\"../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
            rpt.InnerHtml = str.ToString();
        }

        protected void btn_forward_Click(object sender, EventArgs e)
        {
            var sql = "EXEC Proc_Travel @flag='af', @user=" + filterstring(this.ReadSession().Emp_Id.ToString()) + ", @tadaId=" + filterstring(GetID().ToString());
            var dt = CLsDAo.ExecuteDataset(sql).Tables[0];
            if (dt.Rows[0]["return_id"].ToString() != "1")
            {
                DisplayAuthorisedBy(dt);
                txtAuthorisedBy.Text = "";
            }
            else
            {
                printMsg.Text=dt.Rows[0]["return_message"].ToString();
                printMsg.Visible = true;
            }
            //string sql =
            //  CLsDAo.GetSingleresult();
        }
    }
}
    
