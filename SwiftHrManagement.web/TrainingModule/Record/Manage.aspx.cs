using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.TrainingModule.Record
{
    public partial class Manage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 223) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                OnPopulateDdl();
                if (GetID() > 0)
                {
                    OnDisplay();
                    displayArea.Visible = true;
                    formArea.Visible = false;
                    btnDelete.Visible = true;
                    addNominee.Visible = false;
                    dis_nominee.Visible = true;
                    OnDisplayNominee1();
                    btnSave.Visible = false;
                }
                else
                {
                    formArea.Visible = true;
                    displayArea.Visible = false;
                    btnDelete.Visible = false;
                    dis_nominee.Visible = false;
                }

                MakeNumericTextbox(ref TxtCostEstimate);
                MakeNumericTextbox(ref txtOtherCost);
                MakeNumericTextbox(ref txtFoodCostVenue);
                MakeNumericTextbox(ref txtTrainerCost);
                MakeNumericTextbox(ref txtTotalCapacity);
                MakeNumericTextbox(ref txtCostPerPerson);
                MakeNumericTextbox(ref txtNoOfDays);
            }
            txtStartDate.Attributes.Add("onblur", "checkDateFormat(this);");
            txtEndDate.Attributes.Add("onblur", "checkDateFormat(this);");
            txtNominateWithin.Attributes.Add("onblur", "checkDateFormat(this);");
            TxtCostEstimate.Attributes.Add("onblur", "checknumber(this);");
            txtNoOfHOurs.Attributes.Add("onblur", "checknumber(this);");
            txtTotalCapacity.Attributes.Add("onblur", "checknumber(this);");
        }
        private void OnPopulateDdl()
        {
            CLsDAo.CreateDynamicDDl(ddlProgramType, "Exec ProcStaticDataView 's','86'", "ROWID", "DETAIL_TITLE", "", "Select");
            CLsDAo.CreateDynamicDDl(ddlCategory, "SELECT ID, TRAINING_NAME FROM TrainingList", "ID", "TRAINING_NAME", "", "Select");
        }
        private void OnDisplay()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procTrainingManage] @flag='a',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            lblCategory.Text = dr["categoryId"].ToString();
            lblProgramType.Text = dr["programType"].ToString();
            lblProgramName.Text = dr["programName"].ToString();
            lblStartDate.Text = dr["startDate"].ToString();
            lblEndDate.Text = dr["endDate"].ToString();
            lblConductedBy.Text = dr["conductedBy"].ToString();
            lblVenue.Text = dr["venue"].ToString();
            lblTotCapacity.Text = dr["totCapacity"].ToString();
            lblCity.Text = dr["city"].ToString();
            lblCountry.Text = dr["country"].ToString();
            lblNoOfDays.Text = dr["noOfDays"].ToString();
            lblNoOfHours.Text = dr["noOfHours"].ToString();
            lblEstimatedCost.Text = dr["costEstimate"].ToString();
            lblNarration.Text = dr["narration"].ToString();
            lblNomineeWithin.Text = dr["nomineeWithin"].ToString();
            lblCreatedBy.Text = dr["createdBy"].ToString();
            lblCreatedDate.Text = dr["createdDate"].ToString();
            lblStatus.Text = dr["status"].ToString();
            lblApprovedby.Text = dr["approvedBy"].ToString();
            lblApprovedDate.Text = dr["approvedDate"].ToString();

            lblTrainerCost.Text = dr["trainerCost"].ToString();
            lblFoodVenueCost.Text = dr["foodVenueCost"].ToString();
            lblPerPersonCost.Text = dr["perPersonCost"].ToString();
            lblOtherCost.Text = dr["otherCost"].ToString();
            lblTotalCost.Text = dr["totCost"].ToString();
            lblPlannedStartDate.Text = dr["plannedStartDate"].ToString();
            lblPlannedEndDate.Text = dr["plannedEndDate"].ToString();
        }


        private long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDeleteTraining();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnDeleteTraining()
        {
            string msg = CLsDAo.GetSingleresult("exec [procTrainingManageRecord] @flag='DEL_T',@id=" + filterstring(GetID().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            txtNoOfDays.Text = "";
            if (txtStartDate.Text != "0" && txtEndDate.Text != "0")
            {
                DateTime startDate = DateTime.Parse(txtStartDate.Text);
                DateTime endDate = DateTime.Parse(txtEndDate.Text);
                string days = (endDate - startDate).TotalDays.ToString();
                days = (int.Parse(days) + 1).ToString();
                txtNoOfDays.Text = days;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnSave()
        {
            string[] a = txtForwardWith.Text.Split('|');
            string emp_id = a[1];
            hdnForwardEmp.Value = emp_id;

            string flag = "";
            if (GetID() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = CLsDAo.GetSingleresult("exec [procTrainingManageRecord] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetID().ToString()) + ""
                        + " ,@type=" + filterstring(ddlProgramType.Text) + ",@name=" + filterstring(TxtProgramName.Text) + ""
                        + " ,@startDate=" + filterstring(txtStartDate.Text) + ",@endDate=" + filterstring(txtEndDate.Text) + ""
                        + " ,@conductedBy=" + filterstring(txtConductedBy.Text) + ",@venue=" + filterstring(txtVenue.Text) + ""
                        + " ,@totcapacity=" + filterstring(txtTotalCapacity.Text) + ",@city=" + filterstring(txtCity.Text) + ""
                        + " ,@country=" + filterstring(txtCountry.Text) + ",@noOfDays=" + filterstring(txtNoOfDays.Text) + ""
                        + " ,@noOfHours=" + filterstring(txtNoOfHOurs.Text) + ",@costEstimate=" + filterstring(TxtCostEstimate.Text) + ""
                        + " ,@nomineeWithin=" + filterstring(txtNominateWithin.Text) + ",@narration=" + filterstring(txtProgramDesc.Text) + ""
                        + " ,@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@sessionId="+filterstring(ReadSession().Sessionid)+""
                        + " ,@categoryId=" + filterstring(ddlCategory.Text) + ",@trainerCost=" + filterstring(txtTrainerCost.Text) + ""
                        + " ,@foodVenueCost=" + filterstring(txtFoodCostVenue.Text) + ",@perPersonCost=" + filterstring(txtCostPerPerson.Text) + ""
                        + " ,@otherCost=" + filterstring(txtOtherCost.Text) + ""
                        + " ,@status=" + filterstring(ddlStatus.Text) + ",@forwardEmp=" + filterstring(hdnForwardEmp.Value) + ""
                        + " ,@plannedStartDate=" + filterstring(txtPlannedStartDate.Text) + ",@plannedEndDate=" + filterstring(txtPlannedEndDate.Text) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddNominee_Click(object sender, EventArgs e)
        {
            try
            {
                OnAddNominee();
                txtEmployeeName.Text = "";
            }
            catch
            {
                LblMsg.Text = "Error In Add Nominee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnAddNominee()
        {
            string[] a = txtEmployeeName.Text.Split('|');
            string emp_id = a[1];
            hdnEmpId.Value = emp_id;

            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManageRecord] @flag='ADD_N',@sessionId=" + filterstring(ReadSession().Sessionid.ToString()) + ","
            + " @nomineeId=" + filterstring(hdnEmpId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                OnDisplayNominee();
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        private void OnDisplayNominee()
        {
            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("Exec [procTrainingManageRecord] @flag='DIS_N',@sessionId=" + filterstring(ReadSession().Sessionid.ToString()) + "").Tables[0];

            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\"><a href=\"\"><span onclick = \"OnDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><img src=\"../../Images/delete.gif\"/></span></a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            displayNomniee.InnerHtml = str.ToString();
        }
        private void OnDisplayNominee1()
        {
            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("Exec [procTrainingManage] @flag='e',@id=" + filterstring(GetID().ToString()) + "").Tables[0];

            var str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            //str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                //str.Append("<td align=\"left\"><a href=\"\"><span onclick = \"OnDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><img src=\"../../Images/delete.gif\"/></span></a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptNominee.InnerHtml = str.ToString();
        }
        protected void btnDeleteNominee_Click(object sender, EventArgs e)
        {
            try
            {
                OnDeleteNominee();
            }
            catch (Exception sqlException)
            {
                throw sqlException;
            }
        }
        private void OnDeleteNominee()
        {
            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManageRecord] @flag='DEL_N',@id=" + filterstring(hdnId.Value) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("Manage.aspx?ID=" + GetID() + "");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void txtTrainerCost_TextChanged(object sender, EventArgs e)
        {
            if (txtTrainerCost.Text == "")
                txtTrainerCost.Text = "0";
            if (txtFoodCostVenue.Text == "")
                txtFoodCostVenue.Text = "0";
            if (txtOtherCost.Text == "")
                txtOtherCost.Text = "0";
            if (txtTotalCapacity.Text == "")
                txtTotalCapacity.Text = "1";
            txtCostPerPerson.Text = ((double.Parse(txtTrainerCost.Text) + double.Parse(txtFoodCostVenue.Text) +
                                    double.Parse(txtOtherCost.Text)) / double.Parse(txtTotalCapacity.Text)).ToString();
        }

        protected void txtFoodCostVenue_TextChanged(object sender, EventArgs e)
        {
            if (txtTrainerCost.Text == "")
                txtTrainerCost.Text = "0";
            if (txtFoodCostVenue.Text == "")
                txtFoodCostVenue.Text = "0";
            if (txtOtherCost.Text == "")
                txtOtherCost.Text = "0";
            if (txtTotalCapacity.Text == "")
                txtTotalCapacity.Text = "1";
            txtCostPerPerson.Text = ((double.Parse(txtTrainerCost.Text) + double.Parse(txtFoodCostVenue.Text) +
                                    double.Parse(txtOtherCost.Text)) / double.Parse(txtTotalCapacity.Text)).ToString();
        }

        protected void txtOtherCost_TextChanged(object sender, EventArgs e)
        {
            if (txtTrainerCost.Text == "")
                txtTrainerCost.Text = "0";
            if (txtFoodCostVenue.Text == "")
                txtFoodCostVenue.Text = "0";
            if (txtOtherCost.Text == "")
                txtOtherCost.Text = "0";
            if (txtTotalCapacity.Text == "")
                txtTotalCapacity.Text = "1";
            txtCostPerPerson.Text = ((double.Parse(txtTrainerCost.Text) + double.Parse(txtFoodCostVenue.Text) +
                                    double.Parse(txtOtherCost.Text)) / double.Parse(txtTotalCapacity.Text)).ToString();
        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            txtNoOfDays.Text = "";
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                DateTime startDate = DateTime.Parse(txtStartDate.Text);
                DateTime endDate = DateTime.Parse(txtEndDate.Text);
                string days = (endDate - startDate).TotalDays.ToString();
                days = (int.Parse(days) + 1).ToString();
                txtNoOfDays.Text = days;
            }
        }

        protected void txtCostPerPerson_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTotalCapacity_TextChanged(object sender, EventArgs e)
        {
            if (txtTrainerCost.Text == "")
                txtTrainerCost.Text = "0";
            if (txtFoodCostVenue.Text == "")
                txtFoodCostVenue.Text = "0";
            if (txtOtherCost.Text == "")
                txtOtherCost.Text = "0";
            if (txtTotalCapacity.Text == "")
                txtTotalCapacity.Text = "1";
            txtCostPerPerson.Text = ((double.Parse(txtTrainerCost.Text) + double.Parse(txtFoodCostVenue.Text) +
                                    double.Parse(txtOtherCost.Text)) / double.Parse(txtTotalCapacity.Text)).ToString();
        }

    }
}
