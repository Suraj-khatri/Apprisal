using System;
using System.Data;
using SwiftHrManagement.web.DAL.TravelOrder;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder.TADARecord
{
    public partial class ManageTADARecord : BasePage
    {
       RoleMenuDAOInv _roleMenuDao=new RoleMenuDAOInv();
        clsDAO CLsDAo=new clsDAO();
        TravelOrderDao _travelOrderDao=new TravelOrderDao();

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
            MakeNumericTextbox(ref txtClaimAmount);
            MakeNumericTextbox(ref txtAmountClaimOther);
        }
        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
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
        private void PopulateCurrency()
        {
            CLsDAo.CreateDynamicDDl(Ddlcurrency, "Exec Proc_Travel @flag='fc', @emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ", @destination_country=" + filterstring(DdlCountry.Text) + "", "Rowid", "DETAIL_TITLE", "", "Select");
        }
        private void PopulateTravelAuthorisation()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("EXEC proc_recordTada @FLAG='Z', @id=" + filterstring(GetID().ToString()) + "").Tables[0];

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
            //this.DdlOExtension.Text = dr["IsExtention"].ToString();
            this.DdlReimbursement.Text = dr["IsReimbursement"].ToString();
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
            //if (dr["tada_status"].ToString() == "pending")
            //{
            //    this.BtnSave.Visible = true;
            //    this.BtnDelete.Visible = true;
            //    this.btnAdd.Visible = true;
            //    this.btnAddCurrency.Visible = true;
            //}
           if (dr["tada_status"].ToString() == "Approved")
            {
                this.BtnSave.Visible = false;
                this.BtnDelete.Visible = true;
                this.btnAdd.Visible = false;
                this.btnAddCurrency.Visible = false;
                btnAddNewClaim.Visible = false;
                btnAddNew.Visible = false;
                ccList.Visible = false;
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
            //if(DdlOExtension.Text=="Y")
            //{
            //    extension.Visible = true;
            //    txtEFromDate.Text = dr["ExtFromDate"].ToString();
            //    txtEToDate.Text = dr["ExtToDate"].ToString();
            //    txtERemarks.Text = dr["ExtRemarks"].ToString();
            //}
            if (DdlReimbursement.Text == "Y")
            {

                reimburse.Visible = true;
                DisplayReimbursement();
                PopulateOtherExpense();

            }
        }
        private void populateAuthorisedBy(String tadaId)
        {
            lblAuthorisedBy.Text = "";


            if (tadaId == "0")
                return;
            var dt = CLsDAo.getDataset("EXEC Proc_Travel @flag='s',@Id=" + filterstring(tadaId) + "").Tables[0];

            if (dt == null || dt.Rows.Count == 0)
            {
                rpt.InnerHtml = "";
                return;
            }

            StringBuilder str1 = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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
        private void populateCurrencyAmount(String tadaId)
        {
            long count = 1;
            DataTable dt = _travelOrderDao.FindCurrencyAndAmt(tadaId);
            if (dt == null || dt.Rows.Count == 0)
            {
                rpt2.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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
                        str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
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
        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private string getApprovedStatus(string tadaid)
        {
            return CLsDAo.GetSingleresult("EXEC Proc_travel @flag='as',@id=" + tadaid);
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
            {
                this.divIsExtVisit.Visible = false;
                txtdurex_from.Text = "";
                txtdurexto.Text = "";
                txtdurexcity.Text = "";
                DdlCountry2.Items.Clear();
                lblnoofdays.Text = "";
            }
                
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
        private void DisplayCurrencyAmount()
        {
            long count = 1;
            DataTable dt = _travelOrderDao.FindTadaCurrency(ReadSession().Sessionid);
            if (dt == null || dt.Rows.Count == 0)
            {
                rpt2.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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
                        str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
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
        private void DisplayAuthorisedBy()
        {
            long count = 1;
            DataTable dt = _travelOrderDao.FindAuthorisedPerson(ReadSession().Sessionid);

            if (dt == null || dt.Rows.Count==0)
            {
                rpt.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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
            Response.Redirect("TADARecordList.aspx");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                OnSave();
                Response.Redirect("TADARecordList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnSave()
        {
            char flag;
                flag = 'i';
                Manage(flag);
           
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

            string sql = "EXEC Proc_recordTada @flag='" + flag + "'";
            sql = sql + ",@id=" + filterstring(GetID().ToString());
            sql = sql + ",@empId=" + filterstring(getEmpIdfromInfo(txtEmpName.Text));
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
            //sql = sql + ",@extFromDate=" + filterstring(txtEFromDate.Text);
            //sql = sql + ",@extToDate=" + filterstring(txtEToDate.Text);
            //sql = sql + ",@extRemarks=" + filterstring(txtERemarks.Text);
            //sql = sql + ",@IsExtention=" + filterstring(DdlOExtension.Text);
            sql = sql + ",@IsReimbursement=" + filterstring(DdlReimbursement.Text);
            string msg = CLsDAo.GetSingleresult(sql);

            if (msg.Contains("Success"))
            {
                Response.Redirect("TADARecordList.aspx");
            }
            else
            {
                LblMsg.Text = msg;
            }
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtAuthorisedBy.Text))
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
                sql = "EXEC proc_recordTada @flag='Ia',@authorised_by=" + filterstring(authorisedBy) + ",@session_id=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";

                var dt = CLsDAo.ExecuteDataset(sql).Tables[0];

                DisplayAuthorisedBy();
                txtAuthorisedBy.Text = "";
            }
            else
            {
                return;
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
        private void deleteOperation()
        {
            string msg = CLsDAo.GetSingleresult("EXEC [proc_recordTada] @flag='D',@id=" + filterstring(GetID().ToString()) + ",@tadaId="+GetTadaId().ToString()+"");
            if (msg.Contains("Success"))
            {
                Response.Redirect("TADARecordList.aspx");
            }
            else
            {
                this.LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void DdlReimbursement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlReimbursement.Text == "Y" )
            {
                populateReimbursement();
                reimburse.Visible = true;
            }
            else
            {
                 reimburse.Visible = false;
            }
        }
        //protected void DdlOExtension_SelectedIndexChanged(object sender, EventArgs e)
        //{
       
        //        if(DdlOExtension.Text == "Y")
        //        {
        //            extension.Visible = true;
        //        }
        //        else
        //        {
        //            extension.Visible = false;
        //        }
        //}
        protected void txtdurexto_TextChanged(object sender, EventArgs e)
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
        private string checkLeave()
        {
            return CLsDAo.GetSingleresult("EXEC Proc_travel @flag='cl',@emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ",@extension=" + filterstring(this.Ddlex.SelectedItem.Value) + ", @durex_from=" + filterstring(this.txtdurex_from.Text) + ",@durex_to=" + filterstring(this.txtdurexto.Text) + "");
        }

        #region reimbursement
        private void populateReimbursement()
        {
            CLsDAo.CreateDynamicDDl(ddlHead, "select Distinct headId,dbo.GetDetailTitle(headId) headName from tadaMatrix ", "headId", "headName", "", "Select");
            CLsDAo.CreateDynamicDDl(ddlothercurrency, "Exec Proc_Travel @flag='fc', @emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ", @destination_country=" + filterstring(DdlCountry.Text) + "", "Rowid", "DETAIL_TITLE", "", "");
            CLsDAo.CreateDynamicDDl(ddlHeadCurrency, "Exec Proc_Travel @flag='fc', @emp_id=" + filterstring(getEmpIdfromInfo(txtEmpName.Text)) + ", @destination_country=" + filterstring(DdlCountry.Text) + "", "Rowid", "DETAIL_TITLE", "", "");
        }
        protected void btnAddNewClaim_Click(object sender, EventArgs e)
        {
            double clAmount = (string.IsNullOrWhiteSpace(txtClaimAmount.Text) ? 0 : Convert.ToDouble(txtClaimAmount.Text));
            double ttEAmount = (string.IsNullOrWhiteSpace(txtTotalEntitlement.Text) ? 0 : Convert.ToDouble(txtTotalEntitlement.Text));
            if (checkReimbersementDate())
            {
                if (checkRemberseMent())
                {
                    if (!(clAmount > ttEAmount))
                    {
                        OnSaveReimbersement();
                    }
                }
            }
        }
        private bool checkRemberseMent()
        {
            var sql = "EXEC proc_tadaReimbersement @FLAG='ddf'";
            sql += ",@fromDate=" + filterstring(txtFromDate.Text);
            sql += ",@toDate=" + filterstring(txtToDate.Text);
            sql += ",@headId=" + filterstring(ddlHead.Text);
            sql += ",@tadaId=" + GetID();
            var dt = CLsDAo.getDataset(sql).Tables[1];
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                //string PrrevtoDate = dr[0].ToString();
                return (DateTime.Parse(txtFromDate.Text) >= DateTime.Parse(dr[0].ToString()) ? true : false);
            }
            else
            {
                return true;
            }
        }
        private bool checkReimbersementDate()
        {
            var sql = "EXEC proc_tadaReimbersement @FLAG='ddf'";
            sql += ",@fromDate=" + filterstring(txtFromDate.Text);
            sql += ",@toDate=" + filterstring(txtToDate.Text);
            sql += ",@headId=" + filterstring(ddlHead.Text);
            sql += ",@tadaId=" + GetID();
            var dt = CLsDAo.getDataset(sql).Tables[0];
            return (!(dt.Rows.Count > 0));
            //if (string.IsNullOrEmpty(dr[0].ToString()) && string.IsNullOrEmpty(dr[1].ToString()))
            //{
            //    return true;
            //}
            //if (DateTime.Parse(txtFromDate.Text) >= DateTime.Parse(dr[1].ToString()))
            //{
            //    return true;
            //}
            //{
            //    return false;
            //}
        }
        private void OnSaveReimbersement()
        {

            SaveReimbersementWithoutFile();
            populateReimbersement();
           
        }

        private void SaveReimbersementWithoutFile()
        {
            string msg = CLsDAo.GetSingleresult("Exec [proc_recordTada] @flag='Ir',  @headId=" + filterstring(ddlHead.Text) + ",@currencyId=" + filterstring(ddlHeadCurrency.Text) + ","
                + " @perDayEntitle=" + filterstring(txtPerDayEntitlement.Text) + ",@totalEntitle=" + filterstring(txtTotalEntitlement.Text) + ","
                + " @billsToBeClosed=" + filterstring(ddlBillEnclosed.Text) + ",@claimAmount=" + filterstring(txtClaimAmount.Text) + ","
                + " @session_id=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                + " @remarks=" + filterstring(txtRemarks.Text) + ",@fromDate=" + filterstring(txtFromDate.Text) + ",@toDate=" + filterstring(txtToDate.Text) + "");

            if (msg.Contains("Already Added!"))
            {
                msgLbl.Text = msg;
                msgLbl.ForeColor = System.Drawing.Color.Red;
                return;
            }
            msgLbl.Text = "";
            msgLbl.Visible = false;
        }
        private void populateReimbersement()
        {

            DataTable dt = CLsDAo.getTable("Exec proc_recordTada @FLAG='Sr',@session_id=" + filterstring(ReadSession().Sessionid) + "");

            if (dt == null || dt.Rows.Count == 0)
            {
                disReimbersement.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                disReimbersement.InnerHtml = str.ToString();
            }
            //StringBuilder str = new StringBuilder();
            //str.Append("<table>");
            //str.Append("<tr>");
            //str.Append("<td>From Back</td>");
            //str.Append("</tr>");
            //str.Append("</table>");
            //disReimbersement.InnerHtml = str.ToString();


        }
        protected void ddlBillEnclosed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHead.Text == "1445" && (DdlAccomodation.SelectedItem.Text == "To Be Self-Arranged" || DdlAccomodation.SelectedItem.Text == "To Be Stayed In Hotel") && ddlBillEnclosed.SelectedItem.Text == "Yes")
            {
                this.divclaimamount.Visible = true;
                txtClaimAmount.Text = "";
            }
            if (ddlHead.Text == "1445" && (DdlAccomodation.SelectedItem.Text == "To Be Self-Arranged" || DdlAccomodation.SelectedItem.Text == "To Be Stayed In Hotel") && ddlBillEnclosed.SelectedItem.Text == "No")
            {
                this.divclaimamount.Visible = true;
                Double num1;
                num1 = Convert.ToDouble(txtTotalEntitlement.Text) / 2;
                txtClaimAmount.Text = num1.ToString();
            }
        }
        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHead.Text != "")
            { 
                DataTable dt = new DataTable();
                dt =
                    CLsDAo.getTable("exec proc_recordTada @flag='Rr', @empId=" +
                                      filterstring(getEmpIdfromInfo(txtEmpName.Text)) +
                                      ",@headId=" + filterstring(ddlHead.Text) + ",@countryId=" +
                                      filterstring(DdlCountry.Text) + "");
                
                DataRow dr = null;

                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];

                }
                if (dr == null)
                {
                    return;
                }
                this.ddlHeadCurrency.SelectedValue = dr["currency"].ToString();
                this.txtPerDayEntitlement.Text = dr["perDayEnt"].ToString();
                if (this.DdlTravelReason.Text != "transfer")
                {
                    TimeSpan t = DateTime.Parse(this.txtToDate.Text) -
                                 DateTime.Parse(this.txtFromDate.Text);

                    int remainingdays;
                    if (dr["headId"].ToString().Trim() == "Accommodation")
                    {
                        remainingdays = t.Days;
                    }
                    else
                    {
                        remainingdays = t.Days + 1;
                    }

                    if (ddlHead.Text == "1445" && DdlAccomodation.Text == "To Be Borne By Organizer")
                    {
                        ddlBillEnclosed.Enabled = true;
                        divclaimamount.Visible = true;
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        txtClaimAmount.Text = "0";
                    }
                    else if (ddlHead.Text == "1447" && DdlAccomodation.Text == "To Be Borne By Organizer")
                    {
                        this.divclaimamount.Visible = true;
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        Double n3;
                        n3 = Convert.ToDouble(txtTotalEntitlement.Text) / 2;
                        txtClaimAmount.Text = n3.ToString();
                    }
                    else if (ddlHead.Text == "1447" &&
                             (DdlFooding.Text == "To Be Self-Arranged" || DdlFooding.Text == "To Be Stayed In Hotel"))
                    {
                        this.divclaimamount.Visible = true;
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        txtClaimAmount.Text = totalentilement.ToString();
                    }
                    else
                    {
                        double totalentilement = remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text);
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                    }

                }
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                OnSaveOtherExp();
            }
            catch
            {
                lblMsgOther.Text = "Error in operation!";
                lblMsgOther.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        private void OnSaveOtherExp()
        {
            string msg = CLsDAo.GetSingleresult("Exec proc_recordTada @flag='Ioe',@currencyId=" + filterstring(ddlothercurrency.Text) + ",@claimAmount=" + filterstring(txtAmountClaimOther.Text) + ","
            + " @session_id=" + filterstring(ReadSession().Sessionid) + ",@otherExpenses=" + filterstring(txtOtherExpenses.Text) + "");
            if (msg.Contains("Success"))
            {
                displayOtherExpenses();
            }
            else
            {
                lblMsgOther.Text = msg;
                lblMsgOther.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        private void displayOtherExpenses()
        {

            DataTable dt = CLsDAo.getTable("Exec proc_recordTada @FLAG='Soe', @session_id=" + filterstring(ReadSession().Sessionid) + "");
            if (dt == null || dt.Rows.Count == 0)
            {
                disOtherExpenses.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                disOtherExpenses.InnerHtml = str.ToString();
            }
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("exec proc_recordTada @flag='Dr',@id=" + filterstring(hdnId.Value) + "");
                CLsDAo.runSQL("exec proc_recordTada @flag='Do',@id=" + filterstring(hdnId.Value) + "");
                populateReimbersement();
                displayOtherExpenses();
            }
            catch (Exception)
            {
                msgLbl.Text = "Error in Deletion!";
                msgLbl.ForeColor = System.Drawing.Color.Red;

            }
        }
        private void DisplayReimbursement()
        {

            DataTable dt = CLsDAo.getTable("Exec proc_recordTada @FLAG='Sdr',@tadaId=" + filterstring(GetTadaId().ToString()) + "");
            if (dt == null || dt.Rows.Count == 0)
            {
                disReimbersement.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                disReimbersement.InnerHtml = str.ToString();
            }

            #endregion

        }

        private void PopulateOtherExpense()
        {

            DataTable dt = CLsDAo.getTable("Exec proc_recordTada @FLAG='Sodr', @tadaId=" + filterstring(GetTadaId().ToString()) + "");

            if (dt == null || dt.Rows.Count == 0 )
            {
                disOtherExpenses.InnerHtml = "";
                return;
            }
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");


            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                disOtherExpenses.InnerHtml = str.ToString();
            }
        }

    }
}