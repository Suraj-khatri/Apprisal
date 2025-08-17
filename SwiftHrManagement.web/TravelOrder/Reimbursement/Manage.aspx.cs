using System;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.TravelOrder.Reimbursement
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        TravelOrderDao _travelOrderDao = new TravelOrderDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["status"] == "rejected" || Request.QueryString["status"]=="pending")
               {
                   Response.Redirect("/TravelOrder/RequestList.aspx?status=" + Request.QueryString["status"]);
               }
                populateDdl();
                PopulateTADA();
                populateReimbersement();
                displayOtherExpenses();
            }
        }

        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void populateDdl()
        {
            //_clsdao.CreateDynamicDDl(ddlOtherExpenses, "Exec ProcStaticDataView @flag='s',@type_id='101'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            _clsdao.CreateDynamicDDl(ddlHead, "Exec [proc_tadaReimbersement] @flag='ph',@id=" + filterstring(GetID().ToString()) + "", "headId", "headName", "", "Select");
            _clsdao.CreateDynamicDDl(ddlHeadCurrency, "Exec ProcStaticDataView @flag='s',@type_id='72'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            _clsdao.CreateDynamicDDl(ddlothercurrency, "Exec [procStaticDataView] @flag= 's',@type_id= '72'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            string str=_clsdao.GetSingleresult(@"Select status_tr from tadaReimbersement where isdelete='N' and tadaId=" +filterstring(GetID().ToString()));
            if(str=="Approved"||str=="Verified")
            {
                this.btnFinalSave.Visible = false;
                this.btnAddNew.Visible = false;
                this.btnAddNewClaim.Visible = false;
            }
            populateAuthorisedBy(GetTadaId().ToString());
            populateCurrencyAmount(GetTadaId().ToString());
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void PopulateTADA()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec proc_travel @flag='a', @id=" + filterstring(GetID().ToString()) + "").Tables[0];
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
            this.txtFromDate.Text = dr["duration_from"].ToString();
            this.lbltodate.Text = dr["duration_to"].ToString();
            this.txtToDate.Text = dr["duration_to"].ToString();
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

            if (this.lblcashadvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
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
            string msg = _clsdao.GetSingleresult("Exec proc_tadaReimbersement @flag='b',@tadaId="+filterstring(GetID().ToString())+","
            + " @currencyId=" + filterstring(ddlothercurrency.Text) + ",@claimAmount=" + filterstring(txtAmountClaimOther.Text) + ","
            + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@otherExpenses="+filterstring(txtOtherExpenses.Text)+"");
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
        private void populateReimbersement()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsdao.getTable("Exec proc_tadaReimbersement @FLAG='ss',"
                           + " @tadaId=" + filterstring(GetID().ToString()) + 
                             ",@sessionId=" + filterstring(ReadSession().Sessionid) + "");
           
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
                        //if(i==9)
                        //{
                        //    str.Append("<td align=\"left\"><a  target='_blank' href='/doc/TADABILL" + "/" + dr["id"] + "." + dr["fileExt"].ToString() + "'><u>" + dr[i].ToString() + "</u></a></td>");
                        //}
                        //else
                        //{
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        //}
                        
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                disReimbersement.InnerHtml = str.ToString();
            }
        }
        private void displayOtherExpenses()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsdao.getTable("Exec proc_tadaReimbersement @FLAG='c',@tadaId=" + filterstring(GetID().ToString()) + ","
                            +" @sessionId="+filterstring(ReadSession().Sessionid)+"");
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
                str.Append("</div>");
                disOtherExpenses.InnerHtml = str.ToString();
            }
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("exec proc_tadaReimbersement @flag='d',@id="+filterstring(hdnId.Value)+"");
                _clsdao.runSQL("exec proc_tadaReimbersement @flag='do',@id=" + filterstring(hdnId.Value) + "");
                populateReimbersement();
                displayOtherExpenses();
            }
            catch
            {
                lblMsg.Text = "Error In Deletion!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddNewClaim_Click(object sender, EventArgs e)
        {
            double clAmount = (string.IsNullOrWhiteSpace(txtClaimAmount.Text) ? 0 : Convert.ToDouble(txtClaimAmount.Text));
            double ttEAmount = (string.IsNullOrWhiteSpace(txtTotalEntitlement.Text) ? 0 : Convert.ToDouble(txtTotalEntitlement.Text));
            if (checkReimbersementDate())
            {
                if (checkRemberseMent())
                {
                    if (clAmount< ttEAmount)
                    {
                        OnSaveReimbersement();
                    }
                }
            }
        }
        private bool checkReimbersementDate()
        {
            var sql = "EXEC proc_tadaReimbersement @FLAG='ddf'";
            sql +=",@fromDate="+filterstring(txtFromDate.Text);
            sql +=",@toDate="+ filterstring(txtToDate.Text );
            sql += ",@headId=" + filterstring(ddlHead.Text);
            sql +=",@tadaId=" + GetID();
            var dt = _clsdao.getDataset(sql).Tables[0];
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

        private bool checkRemberseMent()
        {
            var sql = "EXEC proc_tadaReimbersement @FLAG='ddf'";
            sql += ",@fromDate=" + filterstring(txtFromDate.Text);
            sql += ",@toDate=" + filterstring(txtToDate.Text);
            sql += ",@headId=" + filterstring(ddlHead.Text);

            sql += ",@tadaId=" + GetID();
            var dt = _clsdao.getDataset(sql).Tables[1];
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
        private void OnSaveReimbersement()
        {
            //string fileExt = "";
            //if (ddlBillEnclosed.Text == "Yes")
            //{
               //SaveReimbersementWithFile();
            //}
            //else
            //{
                SaveReimbersementWithoutFile();
            //}
            
            populateReimbersement();
        }

        private void SaveReimbersementWithoutFile()
        {
            string msg = _clsdao.GetSingleresult("Exec [proc_tadaReimbersement] @flag='i',@tadaId=" + filterstring(GetID().ToString()) + ","
                + " @headId=" + filterstring(ddlHead.Text) + ",@currencyId=" + filterstring(ddlHeadCurrency.Text) + ","
                + " @perDayEntitle=" + filterstring(txtPerDayEntitlement.Text) + ",@totalEntitle=" + filterstring(txtTotalEntitlement.Text) + ","
                + " @billsToBeClosed=" + filterstring(ddlBillEnclosed.Text) + ",@claimAmount=" + filterstring(txtClaimAmount.Text) + ","
                + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                + " @remarks=" + filterstring(txtRemarks.Text) + ",@fromDate=" + filterstring(txtFromDate.Text) + ",@toDate=" + filterstring(txtToDate.Text) + "");

            if (msg.Contains("Already Added!"))
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            lblMsg.Text = "";
            lblMsg.Visible = false;
        }
        private void SaveReimbersementWithFile()
        {
            string type = "";
           
            //string p_file = billFile.PostedFile.FileName.ToString().Replace("\\", "/");
          
            //int pos = p_file.LastIndexOf(".");
            //if (pos < 0)
            //    type = "";
            //else
            //    type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {
                case "xls":
                    break;
                case "xlsx":
                    break;
                case "doc":
                    break;
                case "docx":
                    break;
                case "jpg":
                    break;
                case "gif":
                    break;
                case "pdf":
                    break;
                case "txt":
                    break;
                default:
                    lblMsg.Text = "Error:Unable to upload,Invalid file type!";
                    lblMsg.ForeColor =System.Drawing.Color.Red;
                    return;
            }
            string docPath = ConfigurationSettings.AppSettings["root"];

            //string info = uploadFile("tadaBill." + type, GetID().ToString(), docPath);

            //if (info.Substring(0, 5) == "error")
            //    return;


            string retValue = _clsdao.GetSingleresult("Exec [proc_tadaReimbersement] @flag='i',@tadaId=" + filterstring(GetID().ToString()) + ","
            + " @headId=" + filterstring(ddlHead.Text) + ",@currencyId=" + filterstring(ddlHeadCurrency.Text) + ","
            + " @perDayEntitle=" + filterstring(txtPerDayEntitlement.Text) + ",@totalEntitle=" + filterstring(txtTotalEntitlement.Text) + ","
            + " @billsToBeClosed=" + filterstring(ddlBillEnclosed.Text) + ",@claimAmount=" + filterstring(txtClaimAmount.Text) + ","
            + " @fileExt=" + filterstring(type) + ",@sessionId=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");


            string location_2_move = docPath + "\\doc\\TADABILL".ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            //File.Move(info, file_2_create);

        }
        //public string uploadFile(String fileName, string rowid, string WorkFlowPath)
        //{
        //    if (fileName == "")
        //    {
        //        return "error:Invalid filename supplied";
        //    }
        //    //if (billFile.PostedFile.ContentLength == 0)
        //    //{
        //    //    return "error:Invalid file content";
        //    //}
        //    //try
        //    //{
        //    //    if (billFile.PostedFile.ContentLength <= 2048000)
        //    //    {
        //    //        string saved_file_name = WorkFlowPath + "\\doc\\TADABILL\\" + fileName;
        //    //        billFile.PostedFile.SaveAs(saved_file_name);
        //    //        return saved_file_name;
        //    //    }
        //    //    eles
        //    //    {
        //    //        lblMsg.Text = "Error:Unable to upload,File size is too large!";
        //    //        lblMsg.ForeColor = System.Drawing.Color.Red;
        //    //        return "error:Unable to upload,file exceeds maximum limit";
        //    //    }
        //    //}
        //    catch (UnauthorizedAccessException ex)
        //    {
        //        return "error:" + ex.Message + "Permission to upload file denied";
        //    }
        //}

        protected void ddlBillEnclosed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHead.Text == "1445" && (lblaccomodation.Text == "To Be Self-Arranged" || lblaccomodation.Text == "To Be Stayed In Hotel") && ddlBillEnclosed.Text == "Yes")
            {
                this.divclaimamount.Visible = true;
                txtClaimAmount.Text = "";
            }
            if (ddlHead.Text == "1445" && (lblaccomodation.Text == "To Be Self-Arranged" || lblaccomodation.Text == "To Be Stayed In Hotel") && ddlBillEnclosed.Text == "No")
            {
                this.divclaimamount.Visible = true;
                Double num1;
                num1 = Convert.ToDouble(txtTotalEntitlement.Text)/2;
                txtClaimAmount.Text = num1.ToString();
            }


            /*if(this.ddlBillEnclosed.Text=="Yes")
            {
                this.divclaimamount.Visible = true;
                this.txtClaimAmount.Text = "";
                this.txtClaimAmount.Enabled = true;
                //this.divselectbill.Visible = true;
            }

            if(this.ddlBillEnclosed.Text=="No")
            {
                this.divclaimamount.Visible = true;
                //this.divselectbill.Visible = false;
                if (this.txtTotalEntitlement.Text == "")
                    return;
                double totalentlement = double.Parse(this.txtTotalEntitlement.Text);
                this.txtClaimAmount.Text = totalentlement.ToString();
                //double claimamount = 0.5*totalentlement;
                //this.txtClaimAmount.Text = claimamount.ToString();
                //this.txtClaimAmount.Enabled = false;

            }*/
        }

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DateTime.Parse(this.txtToDate.Text) > DateTime.Parse(this.lbltodate.Text))
            //{
            //    lblMsg.Text = "Operation Fail...Date should be valid!";
            //    return;
            //}
            
            if(ddlHead.Text!="")
            {
                if(ddlHead.Text=="1447")
                {
                    divbill.Visible = false;
                }
                else
                {
                    divbill.Visible = true;
                    
                }
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("exec [proc_tadaReimbersement] @flag='A', @ID=" + filterstring(GetID().ToString()) + ","
                + "@headId=" + filterstring(ddlHead.Text) + "").Tables[0];
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
                //this.txtTotalEntitlement.Text = dr["totEnt"].ToString();
                if (this.lblreasontravel.Text != "transfer")
                {
                    TimeSpan t = DateTime.Parse(this.txtToDate.Text) -
                               DateTime.Parse(this.txtFromDate.Text);

                    int remainingdays;
                    if (dr["headId"].ToString().Trim() == "Accommodation")
                    { remainingdays = t.Days; }
                    else { remainingdays = t.Days + 1; }
                   
                    //double perDayEntitlement = double.Parse(this.txtPerDayEntitlement.Text);
                    if (ddlHead.Text=="1445" && lblaccomodation.Text == "To Be Borne By Organizer")
                    {
                        ddlBillEnclosed.Enabled = true;
                        divclaimamount.Visible = true;
                        //txtPerDayEntitlement.Text = (Convert.ToDouble(txtPerDayEntitlement.Text) / 2).ToString();
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        txtClaimAmount.Text = "0";
                    }
                    else if (ddlHead.Text == "1447" && lblfooding.Text == "To Be Borne By Organizer")
                    {
                        this.divclaimamount.Visible = true;
                        //this.ddlBillEnclosed.Enabled = false;
                        //txtPerDayEntitlement.Text = (Convert.ToDouble(txtPerDayEntitlement.Text) / 2).ToString();
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        Double n3;
                        n3 = Convert.ToDouble(txtTotalEntitlement.Text)/2;
                        txtClaimAmount.Text = n3.ToString();
                    }
                    else if (ddlHead.Text == "1447" && (lblfooding.Text == "To Be Self-Arranged" || lblfooding.Text == "To Be Stayed In Hotel"))
                    {
                        this.divclaimamount.Visible = true;
                        //ddlBillEnclosed.Enabled = false;
                        //txtPerDayEntitlement.Text = (Convert.ToDouble(txtPerDayEntitlement.Text) / 2).ToString();
                        double totalentilement = (remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text));
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                        txtClaimAmount.Text = totalentilement.ToString();
                    }
                    else
                    {
                        double totalentilement = remainingdays * Convert.ToDouble(txtPerDayEntitlement.Text);
                        this.txtTotalEntitlement.Text = totalentilement.ToString();
                    }
                    //if (lblfooding.Text == "To Be Borne By Organizer" && ddlHead.Text == "1447")
                    //{
                    //    double totalentilement = (remainingdays * perDayEntitlement)/2;
                    //    this.txtTotalEntitlement.Text = totalentilement.ToString();
                    //}
                    //else
                    //{
                    //    double totalentilement = remainingdays * perDayEntitlement;
                    //    this.txtTotalEntitlement.Text = totalentilement.ToString();
                    //}

                }
            }
        }

        protected void btnFinalSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnFinalSave();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void OnFinalSave()
        {
            string msg = _clsdao.GetSingleresult("Exec [proc_tadaReimbersement] @flag='finalSave',@tadaId=" + filterstring(GetID().ToString()) + ","
                + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("/TravelOrder/RequestList.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void populateAuthorisedBy(String tadaId)
        {
            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            var dt = _clsdao.getDataset("EXEC Proc_Travel @flag='s',@Id=" + filterstring(tadaId) + "").Tables[0];

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
            str1.Append("</div>");
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
            //str.Append("<th align=\"left\">Delete</th>");
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
                //str.Append("<td align=\"left\"><img onclick = 'DeleteCurrency(" + dr["Id"] + ")' class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt2.InnerHtml = str.ToString();
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (checkDate(lblfromdate.Text, lbltodate.Text, txtFromDate.Text))
            {
                LblDateMsg.Text = "Invalid Date";
                LblDateMsg.Visible = true;
                return;
            }
            else
            {
                LblDateMsg.Text = "";
                LblDateMsg.Visible = false;
            }
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            if (checkDate(lblfromdate.Text, lbltodate.Text, txtToDate.Text))
            {
                LblDateMsg1.Text = "Invalid Date";
                LblDateMsg1.Visible = true;
                return;
            }
            else
            {
                LblDateMsg1.Text = "";
                LblDateMsg1.Visible = false;
            }
        }

        private bool checkDate(string A, string B, string C)
        {
            DateTime date = new DateTime();
            DateTime lblFromDate = new DateTime();
            DateTime lblToDate = new DateTime();
            date = DateTime.Parse(C);
            lblFromDate = DateTime.Parse(A);
            lblToDate = DateTime.Parse(B);

            TimeSpan ts = lblFromDate - date;
            if (date.Day < lblFromDate.Day || date.Day > lblToDate.Day)
            {
                return true;
            }
            else
                return false;
        }
   }
}