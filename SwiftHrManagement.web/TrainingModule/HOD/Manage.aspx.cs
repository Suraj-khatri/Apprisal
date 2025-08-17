using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingModule.HOD
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

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 216) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                OnPopulateDdl();
                if (GetID() > 0)
                {
                    // CHECKING FORM CONTROL BY STATUS
                    OnPoulate();
                    string status = CLsDAo.GetSingleresult("select status from training	where id=" + GetID() + "");
                    if (status == "Requested")
                    {
                        formArea.Visible = true;
                        btnDelete.Visible = true;
                        displayArea.Visible = false;
                        addNominee.Visible = false;
                        OnDisplayNominee();
                        OnPoulate();
                    }
                    else if (status == "Forwarded")
                    {
                        formArea.Visible = false;
                        displayArea.Visible = true;
                        addNominee.Visible = true;
                        OnDisplay();
                        OnDisplayNominee();
                        btnAddNominee.Visible = true;
                    }
                    else if (status == "Approved")
                    {
                        formArea.Visible = false;
                        displayArea.Visible = true;
                        addNominee.Visible = true;
                        OnDisplay();
                        OnDisplayNominee();
                        btnAddNominee.Visible = false;
                    }
                    else if (status == "Closed")
                    {
                        formArea.Visible = false;
                        displayArea.Visible = true;
                        addNominee.Visible = true;
                        OnDisplay();
                        OnDisplayNominee();
                        btnAddNominee.Visible = false;                        
                    }
                    else if (status == "Recorded")
                    {
                        formArea.Visible = false;
                        displayArea.Visible = true;
                        addNominee.Visible = true;
                        OnDisplay();
                        OnDisplayNominee();
                        btnAddNominee.Visible = false;
                    }

                    // CHECKING USER IS CREATOR OR NOT
                    string createdBY = CLsDAo.GetSingleresult("select createdBy from training where id=" + GetID() + "");
                    if (createdBY != ReadSession().Emp_Id.ToString())
                    {
                        btnSave.Visible = false;
                        btnDelete.Visible = false;
                    }
                }
                else
                {
                    formArea.Visible = true;
                    displayArea.Visible = false;
                    addNominee.Visible = false;
                    btnDelete.Visible = false;
                }
            }

            //btnBack.Attributes.Add("onclick", "history.back();return false");

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
            lblPlannedStartDate.Text = dr["plannedStartDate"].ToString();
            lblPlannedEndDate.Text = dr["plannedEndDate"].ToString();
        }

        private void OnPoulate()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procTrainingManage] @flag='s',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            ddlCategory.SelectedValue = dr["categoryId"].ToString();
            ddlProgramType.SelectedValue = dr["programType"].ToString();
            TxtProgramName.Text = dr["programName"].ToString();
            txtStartDate.Text = dr["startDate"].ToString();
            txtEndDate.Text = dr["endDate"].ToString();
            txtConductedBy.Text = dr["conductedBy"].ToString();
            txtVenue.Text = dr["venue"].ToString();
            txtTotalCapacity.Text = dr["totCapacity"].ToString();
            txtCity.Text = dr["city"].ToString();
            txtCountry.Text = dr["country"].ToString();
            txtNoOfDays.Text = dr["noOfDays"].ToString();
            txtNoOfHOurs.Text = dr["noOfHours"].ToString();
            TxtCostEstimate.Text = dr["costEstimate"].ToString();
            txtProgramDesc.Text = dr["narration"].ToString();
            txtNominateWithin.Text = dr["nomineeWithin"].ToString();
            txtPlannedStartDate.Text = dr["plannedStartDate"].ToString();
            txtPlannedEndDate.Text = dr["plannedEndDate"].ToString();
        }

        private long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void diseableOperation()
        {            
            TxtProgramName.Enabled = false;
            txtStartDate.Enabled = false;
            txtEndDate.Enabled = false;
            txtConductedBy.Enabled = false;
            txtVenue.Enabled = false;
            txtTotalCapacity.Enabled = false;
            txtCity.Enabled = false;
            txtCountry.Enabled = false;
            txtNoOfDays.Enabled = false;
            txtNoOfHOurs.Enabled = false;
            TxtCostEstimate.Enabled = false;
            txtProgramDesc.Enabled = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
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
            string msg = CLsDAo.GetSingleresult("exec [procTrainingManage] @flag='d',@id=" + filterstring(GetID().ToString()) + "");
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
            string flag = "";
            if (GetID() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string msg = CLsDAo.GetSingleresult("exec [procTrainingManage] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetID().ToString()) + ""
                        + " ,@type=" + filterstring(ddlProgramType.Text) + ",@name=" + filterstring(TxtProgramName.Text) + ",@startDate=" + filterstring(txtStartDate.Text) + ""
                        + " ,@endDate=" + filterstring(txtEndDate.Text) + ",@conductedBy=" + filterstring(txtConductedBy.Text) + ",@venue=" + filterstring(txtVenue.Text) + ""
                        + " ,@totcapacity=" + filterstring(txtTotalCapacity.Text) + ",@city=" + filterstring(txtCity.Text) + ""
                        + " ,@country=" + filterstring(txtCountry.Text) + ",@noOfDays=" + filterstring(txtNoOfDays.Text) + ""
                        + " ,@noOfHours=" + filterstring(txtNoOfHOurs.Text) + ",@costEstimate=" + filterstring(TxtCostEstimate.Text) + ""
                        + " ,@nomineeWithin=" + filterstring(txtNominateWithin.Text) + ",@narration=" + filterstring(txtProgramDesc.Text) + ""
                        + " ,@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@status=" + filterstring("Requested") + ","
                        + " @categoryId=" + filterstring(ddlCategory.Text) + ",@plannedStartDate=" + filterstring(txtPlannedStartDate.Text) + ","
                        + " @plannedEndDate="+filterstring(txtPlannedEndDate.Text)+"");
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

            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManage] @flag='b',@id=" + filterstring(GetID().ToString()) + ","
            + " @nomineeId=" + filterstring(hdnEmpId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            if (msg.Contains("Success"))
            {
                OnDisplayNominee();
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnDisplayNominee()
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
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                //str.Append("<td align=\"left\"><a href=\"\"><span onclick = \"OnDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><img src=\"../../Images/delete.png\"/></span></a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            displayNomniee.InnerHtml = str.ToString();
        }
        protected void btnDeleteNominee_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch (Exception sqlException)
            {
                throw sqlException;
            }
        }
        private void OnDelete()
        {
            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManage] @flag='f',@id=" + filterstring(hdnId.Value) + "");
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

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
