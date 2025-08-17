using System;
using System.Data;
using System.Text;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class TadaExtention : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        TravelOrderDao _travelOrderDao = new TravelOrderDao();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (getAppStatus() == "1")
                {
                    if (getIsmanual() == "N")
                    {
                        PopulateExtention();
                        if (!string.IsNullOrWhiteSpace(txtFromDate.Text))
                        {
                            btnSave.Visible = false;
                        }
                        else
                        {
                            btnSave.Visible = true;
                        }
                    }
                    else
                    {
                        PopulateExtention();
                    }
                }
                PopulateTADA();
                populateAuthorisedBy(GetTadaId().ToString());
                populateCurrencyAmount(GetTadaId().ToString());
                _clsdao.setDDL(ref DdlApprovedBy, "select dbo.GetEmployeeFullNameOfId(Authorised_By)Authorised_By,Authorised_By as Id from TADA_Authorization where tada_id=" + filterstring(GetID().ToString()) + "", "id", "Authorised_By", "", "Select");
            }
        }

        private string getAppStatus()
        {
            string msg;
            msg = _clsdao.GetSingleresult("exec proc_travel @flag = 'al', @tadaId = " + filterstring(GetID().ToString()) + "");
            return msg;
        }

        private string  getIsmanual()
        {
            return (Request.QueryString["Manual"] != null ? (Request.QueryString["Manual"].ToString()) : "0");
            
        }

        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private void PopulateExtention()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec proc_travel @flag = 'ex', @tadaId = " + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            txtFromDate.Text = dr["ExtFromDate"].ToString();
            txtToDate.Text = dr["ExtToDate"].ToString();
            txtRemarks.Text = dr["ExtRemarks"].ToString();
           // DdlApprovedBy.SelectedValue = dr["ExtApproveBy"].ToString();
            //if (dr["ExtStatus"].ToString() == "Approved" || dr["ExtStatus"].ToString() == "Rejected")
            //{
            //    btnSave.Visible = false;
            //}
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

        private void populateAuthorisedBy(String tadaId)
        {
            StringBuilder str1 = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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
            rpt.InnerHtml = str1.ToString();
        }

        private void populateCurrencyAmount(String tadaId)
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<br/><table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
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
                        str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
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
            rpt2.InnerHtml = str.ToString();
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (checkDate(lbltodate.Text,txtFromDate.Text))
            {
                LblDateMsg.Text = "";
                LblDateMsg.Visible = false;
            }
            else
            {
                LblDateMsg.Text = "Invalid Date";
                LblDateMsg.Visible = true;
                return;
            }
        }

        private bool checkDate(string A, string B)
        {
            DateTime lblToDate = new DateTime();
            DateTime txtfromTime = new DateTime();

            lblToDate = DateTime.Parse(A);
            txtfromTime = DateTime.Parse(B);

            //int txtfromTime = Int32.Parse(B);
            //int lblToDate = Int32.Parse(A);
            

            TimeSpan ts = txtfromTime - lblToDate;
            if (ts.Days == 1)
            {
                return true;
            }
            else
                return false;
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFromDate.Text))
            {
                LblDateMsg.Text = "Dates cannot be blank";
                LblDateMsg.Visible = true;
                return;
            }
            else
            {
                DateTime date = new DateTime();
                DateTime lblFromDate = new DateTime();
                DateTime lblToDate = new DateTime();
                lblFromDate = DateTime.Parse(txtFromDate.Text);
                lblToDate = DateTime.Parse(txtToDate.Text);

                if (lblFromDate > lblToDate)
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*string msg = checkLeave();
                if (msg.Contains("Please apply leave for your extension travel"))
                {
                    lblexterror.Text = msg;
                    lblexterror.ForeColor = System.Drawing.Color.Red;
                    return;
                }*/
                OnSave();
               
                    Response.Redirect("RequestList.aspx");
                
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string checkLeave()
        //{
        //    return _clsdao.GetSingleresult("EXEC Proc_travel @flag='cl',@emp_id=" + filterstring(getEmpIdfromInfo(LblEmpName.Text)) + ",@extension=" + filterstring(this.Ddlex.SelectedItem.Value) + ", @durex_from=" + filterstring(this.txtdurex_from.Text) + ",@durex_to=" + filterstring(this.txtdurexto.Text) + "");
        //}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if(getIsmanual()=="N")
            {
                Response.Redirect("TADARecord/TADARecordList.aspx");
            }
            else
            {
                Response.Redirect("RequestList.aspx");
            }
          
        }

        private void OnSave()
        {
            char flag;
            if(getIsmanual()=="N")
            {
                flag = 'y';
                Manage(flag);
            }
            else
            {
                flag = 'v';
                Manage(flag);
            }
          
        }

        private void Manage( char flag)
        {
            string sql = "EXEC Proc_travel @flag='" + flag + "'";
            sql = sql + ", @tadaId = " + filterstring(GetID().ToString());
            sql = sql + ", @emp_id = " + filterstring(getEmpIdfromInfo(LblEmpName.Text));
            sql = sql + ", @extFromDate = "+filterstring(txtFromDate.Text);
            sql = sql + ", @extToDate = " + filterstring(txtToDate.Text);
            sql = sql + ", @extRemarks = " + filterstring(txtRemarks.Text);
            sql = sql + ", @extApproveBy=" + filterstring(DdlApprovedBy.Text);


            string msg = _clsdao.GetSingleresult(sql);

            if (msg.Contains("Success"))
            {   
                if(getIsmanual().ToString()=="N")
                {
                    Response.Redirect("TADARecord/TADARecordList.aspx");
                }
                {
                    Response.Redirect("RequestList.aspx");
                }
              
            }
            else
            {
                LblMsg.Text = msg;
            }
        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            string sql = "Exec proc_travel @flag='De',@tadaId=" + GetID().ToString();
            string msg = _clsdao.GetSingleresult(sql);
            if(msg.Contains("Success"))
            {
                if (getIsmanual().ToString() == "N")
                {
                    Response.Redirect("TADARecord/TADARecordList.aspx");
                }
                {
                    Response.Redirect("RequestList.aspx");
                }
            }
            else
            {
                LblMsg.Text = msg;
            }
        }
    }
}