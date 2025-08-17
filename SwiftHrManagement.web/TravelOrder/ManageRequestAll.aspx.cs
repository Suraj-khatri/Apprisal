using System;
using System.Data;
using SwiftHrManagement.web.DAL.TravelOrder;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class ManageRequestAll : BasePage
    {
         clsDAO CLsDAo = null;
         TravelOrderDao _travelOrderDao = null;
         RoleMenuDAOInv _roleMenuDao = null;

        public ManageRequestAll()
        {
            this.CLsDAo = new clsDAO();
            this._travelOrderDao = new TravelOrderDao();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 273) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                BtnSave.Attributes.Add("onclick", "GetId();");
                if (GetID() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateDropDownList();
                    PopulateCurrency();
                    //PopluateAuthorisedBy();
                    PopulateTravelAuthorisation();

                }

                else
                {
                    PopulateDropDownList();
                    ////PopluateAuthorisedBy();
                 //PopulateTadaBySession();
                    BtnDelete.Visible = false;
                }
            }
            MakeNumericTextbox(ref txtamount);
        }
        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DdlCountry, "SELECT countriesId,dbo.GetDetailtitle(countriesId)country  from tadaClassificationOfAreas", "countriesId", "country", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlCountry2, "SELECT countriesId,dbo.GetDetailtitle(countriesId)country  from tadaClassificationOfAreas", "countriesId", "country", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlTravelReason, "EXEC ProcStaticDataView 's','99'", "Rowid", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(Ddlmode, "EXEC ProcStaticDataView 's','90'", "Rowid", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(Ddltransportation, "EXEC ProcStaticDataView 's','91'", "Rowid", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlAccomodation, "EXEC ProcStaticDataView 's','92'", "Rowid", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlFooding, "EXEC ProcStaticDataView 's','93'", "Rowid", "DETAIL_TITLE", "", "Select");
            populateAuthorisedBy(GetTadaId().ToString());
            populateCurrencyAmount(GetTadaId().ToString());
        }

//        private void PopulateTadaBySession()
//        {
//            DataTable dt = new DataTable();
//            dt = CLsDAo.getDataset(@"SELECT employee_id
//            ,dbo.GetEmployeeFullNameOfId(employee_id) AS empname
//            ,dbo.GetBranchName(BRANCH_ID) branchName
//            ,dbo.GetDeptName(DEPARTMENT_ID) deptName
//            ,dbo.GetDetailTitle(POSITION_ID) positionName
//            FROM Employee WHERE EMPLOYEE_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "").Tables[0];

//            DataRow dr = null;
//            if (dt.Rows.Count > 0)
//            {
//                dr = dt.Rows[0];
//            }

//            this.txtEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();

//            this.txtbranch.Text = dr["branchName"].ToString();
//            this.txtdepartment.Text = dr["deptName"].ToString();
//            this.txtposition.Text = dr["positionName"].ToString();

//        }

        private void PopulateTravelAuthorisation()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("EXEC proc_travel @flag='z', @id=" + filterstring(GetID().ToString()) + "").Tables[0];

            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            this.txtEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();
            this.txtbranch.Text = dr["branch_name"].ToString();
            this.txtdepartment.Text = dr["department_name"].ToString();
            this.txtposition.Text = dr["detail_title"].ToString();
            this.txtdestinationcity.Text = dr["destination_city"].ToString();
            this.DdlCountry.Text = dr["destination_country"].ToString();
            this.DdlTravelReason.Text = dr["reason_for_travel"].ToString();
            if (int.Parse(this.DdlTravelReason.Text) == 1434)
            {
                this.divtraveldate.Visible = false;
            }

            this.txtdurationfrom.Text = dr["duration_from"].ToString();
            this.txtdurationto.Text = dr["duration_to"].ToString();
            this.Ddlex.Text = dr["extension"].ToString();
            if (this.Ddlex.Text == "Yes")
            {
                this.divIsExtVisit.Visible = true;
                this.txtdurex_from.Text = dr["durex_from"].ToString();
                this.txtdurexto.Text = dr["durex_to"].ToString();
                this.lblnoofdays.Text = dr["dur_leave"].ToString();
                this.txtdurexcity.Text = dr["durex_city"].ToString();
                this.DdlCountry2.Text = dr["durex_country"].ToString();
            }

            this.Ddlmode.Text = dr["mode_of_travel"].ToString();
            this.Ddltransportation.Text = dr["transportation"].ToString();
            this.DdlAccomodation.Text = dr["accomodation"].ToString();
            this.DdlFooding.Text = dr["fooding"].ToString();
            this.DdlCashAdvance.Text = dr["cashadvance"].ToString();
            this.txtTravelDescription.Text = dr["Travel Description"].ToString();
            if (this.DdlCashAdvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
                PopulateCurrency();
                //this.Ddlcurrency.Text = dr["currency"].ToString();
                //this.txtamount.Text = dr["amount"].ToString();
                //DisplayCurrencyAmount();
            }

            //this.DdlAuthorisedby.Text = dr["authorised_by"].ToString();            
            if (dr["tada_status"].ToString() == "pending")
            {
                this.BtnSave.Visible = true;
                this.BtnDelete.Visible = true;
                this.btnAdd.Visible = true;
                this.btnAddCurrency.Visible = true;
            }
            else if (dr["tada_status"].ToString() == "approved")
            {
                this.BtnSave.Visible = false;
                this.BtnDelete.Visible = false;
                this.btnAdd.Visible = false;
                this.btnAddCurrency.Visible = false;
                //ccList.Visible = false;
            }


            if (Ddlmode.Text == "1416" && Ddltransportation.Text == "1420")
            {
                divFlightDetails.Visible = true;
                txtFlightDate.Text = dr["flightDate"].ToString();
                txtFromPlace.Text = dr["FromPlace"].ToString();
                txtToPlace.Text = dr["ToPlace"].ToString();
                txtFlightTime.Text = dr["FlightTime"].ToString();
                txtReturnFlightDate.Text = dr["returnFlightDate"].ToString();
                txtReturnFrom.Text = dr["ReturnFromPlace"].ToString();
                txtReturnTo.Text = dr["returnToPlace"].ToString();
                txtReturnFlightTime.Text = dr["returnFlightTime"].ToString();
            }
        }

        protected void DdlTravelReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DdlTravelReason.SelectedItem.Text == "Transfer")
            {
                this.divtraveldate.Visible = false;
            }
            else
            {
                this.divtraveldate.Visible = true;
            }
        }

        protected void Ddlex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Ddlex.Text == "Yes")
            {
                this.divIsExtVisit.Visible = true;
            }
            else
                this.divIsExtVisit.Visible = false;
        }

        protected void Ddltransportation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddlmode.Text == "1416" && Ddltransportation.Text == "1420")
            {
                divFlightDetails.Visible = true;
            }
            else
            {
                divFlightDetails.Visible = false;
            }
        }

        protected void Ddlmode_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Ddlmode.Text == "1416" && Ddltransportation.Text == "1420")
            {
                divFlightDetails.Visible = true;
            }
            else
            {
                divFlightDetails.Visible = false;
            }
        }
        protected void DdlCashAdvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DdlCashAdvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
                PopulateCurrency();
            }
            else
                this.divIsAdvance.Visible = false;
        }
        private void PopulateCurrency()
        {
            CLsDAo.CreateDynamicDDl(Ddlcurrency, "Exec Proc_Travel @flag='fc', @emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ", @destination_country=" + filterstring(DdlCountry.Text) + "", "Rowid", "DETAIL_TITLE", "", "Select");
        }
        protected void btnAddCurrency_Click(object sender, EventArgs e)
        {
            DataTable dt = _travelOrderDao.OnSaveCurrency(Ddlcurrency.Text, txtamount.Text, ReadSession().Sessionid, ReadSession().Emp_Id.ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];
            DisplayCurrencyAmount();
        }

        private void DisplayCurrencyAmount()
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelOrderDao.FindTadaCurrency(ReadSession().Sessionid);

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><img OnClick = 'DeleteCurrency(" + dr["Id"] + ")' class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");
                //img OnClick='DeleteCurrency(" + dr["Id"] + ")' class=\"clickimage\" src=\"../../Images/delete.gif\"

                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt2.InnerHtml = str.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblAuthorisedBy.Text = "";

            string[] arrayAuthorisedBy = txtAuthorisedBy.Text.Split('|');
            string authorisedBy = arrayAuthorisedBy[1];

            //if (authorisedBy == ReadSession().Emp_Id.ToString())
            //{
            //    printMsg.Text = "Assign is not valid";
            //    printMsg.Visible = true;
            //    return;
            //}
            string sql;
            sql = "EXEC Proc_Travel @flag='ia',@authorised_by=" + filterstring(authorisedBy) + ",@session_id=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";

            var dt = CLsDAo.ExecuteDataset(sql).Tables[0];

            DisplayAuthorisedBy();
            txtAuthorisedBy.Text = "";
        }

        private void DisplayAuthorisedBy()
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelOrderDao.FindAuthorisedPerson(ReadSession().Sessionid);

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">Delete</th>");
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
        }

        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("RequestAllList.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = checkLeave();
                if (msg.Contains("Please apply leave for your extension travel"))
                {
                    lblexterror.Text = msg;
                    lblexterror.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                OnSave();
                Response.Redirect("RequestList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string checkLeave()
        {
            return CLsDAo.GetSingleresult("EXEC Proc_travel @flag='cl',@emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ",@extension=" + filterstring(this.Ddlex.SelectedItem.Value) + ", @durex_from=" + filterstring(this.txtdurex_from.Text) + ",@durex_to=" + filterstring(this.txtdurexto.Text) + "");
        }

        private void OnSave()
        {
            char flag;
            if (GetID() > 0)
            {
                flag = 'u';
                Manage(flag);
            }
            else
            {
                flag = 'i';
                Manage(flag);
            }
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private void Manage(char flag)
        {
            string emp_id = getEmpIdfromInfo(txtEmpName.Text);
            if (emp_id == "0")
            {
                LblMsg.Text = "Please select employee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string sql = "EXEC Proc_travel @flag='" + flag + "'";
            sql = sql + ",@id=" + filterstring(GetID().ToString());
            sql = sql + ",@emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text));
            sql = sql + ",@destination_city=" + filterstring(txtdestinationcity.Text);
            sql = sql + ",@destination_country=" + filterstring(DdlCountry.Text);
            sql = sql + ",@reason_for_travel=" + filterstring(DdlTravelReason.Text);
            sql = sql + ",@duration_from=" + filterstring(txtdurationfrom.Text);
            sql = sql + ",@duration_to=" + filterstring(txtdurationto.Text);
            sql = sql + ",@extension=" + filterstring(Ddlex.SelectedItem.Value);
            sql = sql + ",@durex_from=" + filterstring(txtdurex_from.Text);
            sql = sql + ",@durex_to=" + filterstring(txtdurexto.Text);
            sql = sql + ",@durex_city=" + filterstring(txtdurexcity.Text);
            sql = sql + ",@durex_country=" + filterstring(DdlCountry2.Text);
            sql = sql + ",@dur_leave=" + filterstring(lblnoofdays.Text);
            sql = sql + ",@mode_of_travel=" + filterstring(Ddlmode.Text);
            sql = sql + ",@trasportation=" + filterstring(Ddltransportation.Text);
            sql = sql + ",@acomodation=" + filterstring(DdlAccomodation.Text);
            sql = sql + ",@fooding=" + filterstring(DdlFooding.Text);
            sql = sql + ",@cashadvance=" + filterstring(DdlCashAdvance.Text);
            sql = sql + ",@travelDesc=" + filterstring(txtTravelDescription.Text);
            sql = sql + ",@session_id=" + filterstring(ReadSession().Sessionid);
            sql = sql + ",@flightDate=" + filterstring(txtFlightDate.Text);
            sql = sql + ",@FromPlace=" + filterstring(txtFromPlace.Text);
            sql = sql + ",@ToPlace=" + filterstring(txtToPlace.Text);
            sql = sql + ",@flightTime=" + filterstring(txtFlightTime.Text);
            sql = sql + ",@returnFlightDate=" + filterstring(txtReturnFlightDate.Text);
            sql = sql + ",@returnFromPlace=" + filterstring(txtReturnFrom.Text);
            sql = sql + ",@returnToPlace=" + filterstring(txtReturnTo.Text);
            sql = sql + ",@returnFlightTime=" + filterstring(txtReturnFlightTime.Text);
            sql = sql + ",@ccList='" + HiddenFieldEmpEmail.Value + "'";


            string msg = CLsDAo.GetSingleresult(sql);

            if (msg.Contains("Success"))
            {
                Response.Redirect("RequestList.aspx");
            }
            else
            {
                LblMsg.Text = msg;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteOperation();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected long GetSalarySetMasterId()
        {
            return ReadNumericDataFromQueryString("Id");
        }

        private void deleteOperation()
        {
            string msg = CLsDAo.GetSingleresult("EXEC [proc_travel] @flag='x',@id=" + filterstring(GetID().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("RequestList.aspx");
            }
            else
            {
                this.LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        protected void btnDeleteCurrency_Click(object sender, EventArgs e)
        {
            var sql = "DELETE FROM tada_currency WHERE Id = " + hdnCurrency.Value + "";
            CLsDAo.runSQL(sql);
            DisplayCurrencyAmount();
        }

        protected void btnDeleteAuthorisation_Click(object sender, EventArgs e)
        {
            var sql = "DELETE FROM TADA_Authorization WHERE Id = " + hdnAuthorisedBy.Value + "";
            CLsDAo.runSQL(sql);
            DisplayAuthorisedBy();
        }

        private void populateAuthorisedBy(String tadaId)
        {
            lblAuthorisedBy.Text = "";

            StringBuilder str1 = new StringBuilder("<table width=\"350\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            if (tadaId == "0")
                return;
            var dt = CLsDAo.getDataset("EXEC Proc_Travel @flag='s',@Id=" + filterstring(tadaId) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            string appStatus = getApprovedStatus(GetTadaId().ToString());
            str1.Append("<tr>");
            str1.Append("<th>Sn</th>");
            for (int i = 1; i < cols; i++)
            {
                str1.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            if (appStatus == "pending")
            {
                str1.Append("<th>Delete</th>");
            }
            else if (appStatus == "approved")
            {
                str1.Append("");
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
                if (appStatus == "pending")
                {
                    str1.Append("<td align=\"left\"><img OnClick='OnDelete(" + dr["Id"] +
                                ")' class=\"clickimage\" src=\"../../Images/delete.gif\" /></td>");
                }
                else if (appStatus == "approved")
                {
                    str1.Append("");
                }
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rpt.InnerHtml = str1.ToString();
        }

        private string getApprovedStatus(string tadaid)
        {
            return CLsDAo.GetSingleresult("EXEC Proc_travel @flag='as',@id=" + tadaid);
        }

        private void populateCurrencyAmount(String tadaId)
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelOrderDao.FindCurrencyAndAmt(tadaId);
            string appStatus = getApprovedStatus(GetTadaId().ToString());

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            if (appStatus == "pending")
            {
                str.Append("<th align=\"left\">Delete</th>");
            }
            else if (appStatus == "approved")
            {
                str.Append("");
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
                if (appStatus == "pending")
                {
                    str.Append("<td align=\"left\"><img onclick = 'DeleteCurrency(" + dr["Id"] + ")' class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");
                }
                else if (appStatus == "approved")
                {
                    str.Append("");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt2.InnerHtml = str.ToString();
        }

        protected void txtdurationto_TextChanged(object sender, EventArgs e)
        {
            if ((this.txtdurex_from.Text).Length > 0 && (this.txtdurexto.Text).Length > 0)
            {
                TimeSpan t = DateTime.Parse(txtdurexto.Text) - DateTime.Parse(txtdurex_from.Text);
                this.lblnoofdays.Text = t.Days.ToString();
                int remaainingdays = int.Parse(this.lblnoofdays.Text) + 1;
                if (remaainingdays < 1)
                {
                    this.txtdurexto.Text = "";
                    this.txtdurex_from.Text = "";
                    this.lblerrordate.Text = "invalid date";
                }
                else
                {
                    this.lblnoofdays.Text = remaainingdays.ToString();
                    if (checkLeave().Contains("Please apply leave for your extension travel"))
                    {
                        if (GetID() == 0)
                        {
                            CallBackJs1(Page, "Popup", "LeaveExtendPopup();");
                        }
                    }
                }
            }
        }

        protected void txtdurationto_TextChanged1(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Parse(txtdurationto.Text) - DateTime.Parse(txtdurationfrom.Text);
            int remaainingdays = t.Days + 1;
            if (remaainingdays < 0)
            {
                this.txtdurationfrom.Text = "";
                this.txtdurationto.Text = "";
                this.lbldate.Text = "Invalid Date";
            }
            else
            {
                this.lbldate.Text = "";
            }
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            string emp_id = getEmpIdfromInfo(txtEmpName.Text);
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='b', @emp_id=" + emp_id + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (dr == null)
                return;
            
            txtbranch.Text = dr["BRANCH_NAME"].ToString();
            txtdepartment.Text = dr["DEPARTMENT_NAME"].ToString();
            txtposition.Text = dr["DETAIL_TITLE"].ToString();
        }
        
    }
}