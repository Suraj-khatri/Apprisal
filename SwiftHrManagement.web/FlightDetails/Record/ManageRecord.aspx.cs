using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.FlightDetails;
namespace SwiftHrManagement.web.FlightDetails.Record
{
    public partial class ManageRecord : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        FlightDetailsDao _flightDao = null;
        public ManageRecord()
        {
            CLsDAo = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
            _flightDao = new FlightDetailsDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 277) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetID() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateFlightDetails();
                    populateAuthorisedBy(GetFlightId().ToString());
                }

                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }
        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private void ManageFlight(char flag)
        {
            string emp_id = getEmpIdfromInfo(LblEmpName.Text);
            if (emp_id == "0")
            {
                LblMsg.Text = "Please select employee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string sql = "EXEC procManageFlightDetails @flag='" + flag + "'";
            sql = sql + ",@id = " + filterstring(GetID().ToString());
            sql = sql + ",@emp_id = " + filterstring(getEmpIdfromInfo(LblEmpName.Text));
            sql = sql + ",@flightDate = " + filterstring(txtFlightDate.Text);
            sql = sql + ",@fromPlace = " + filterstring(txtFrom.Text);
            sql = sql + ",@toPlace = " + filterstring(txtTo.Text);
            sql = sql + ",@flightTime = " + filterstring(txtFlightTime.Text);
            sql = sql + ",@returnFlightDate = " + filterstring(txtReturnFlightDate.Text);
            sql = sql + ",@returnFromPlace = " + filterstring(txtReturnFrom.Text);
            sql = sql + ",@returnToPlace = " + filterstring(txtReturnTo.Text);
            sql = sql + ",@returnFlightTime = " + filterstring(txtReturnFlightTime.Text);
            sql = sql + ",@purpose = " + filterstring(txtPurpose.Text);
            sql = sql + ",@user = " + filterstring(ReadSession().Emp_Id.ToString());
            sql = sql + ",@session_id = " + filterstring(ReadSession().Sessionid);

            string msg = CLsDAo.GetSingleresult(sql);
            
            Response.Redirect("ListRecord.aspx");
        }

        private void OnSave()
        {
            char flag;
            //if (GetID() > 0)
            //{
            //    flag = 'U';
            //    ManageFlight(flag);
            //}
            //else
            //{
                flag = 'R';
                ManageFlight(flag);
            //}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblAuthorisedBy.Text = "";

            string[] arrayAuthorisedBy = txtAuthorisedBy.Text.Split('|');
            string authorisedBy = arrayAuthorisedBy[1];

            string sql;
            sql = "EXEC procManageFlightDetails @flag='ia', @authorised_by=" + filterstring(authorisedBy) + ", @session_id=" + filterstring(ReadSession().Sessionid) + ", @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";

            var dt = CLsDAo.ExecuteDataset(sql).Tables[0];

            DisplayAuthorisedBy();
            txtAuthorisedBy.Text = "";
        }

        private void DisplayAuthorisedBy()
        {
            long count = 1;
            DataTable dt = _flightDao.FindAuthorisedPerson(ReadSession().Sessionid);

            if (dt == null || dt.Rows.Count == 0)
            {
                rpt.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

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

        private void PopulateFlightDetails()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='s', @id=" + filterstring(GetID().ToString()) + "").Tables[0];

            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            LblEmpName.Text = dr["empName"] + "|" + dr["employee_id"];
            lblBranch.Text = dr["branchName"].ToString();
            lblDepartment.Text = dr["departmentName"].ToString();
            lblPosition.Text = dr["position"].ToString();
            txtFlightDate.Text = dr["flightDate"].ToString();
            txtFrom.Text = dr["FromPlace"].ToString();
            txtTo.Text = dr["ToPlace"].ToString();
            txtFlightTime.Text = dr["FlightTime"].ToString();
            txtReturnFlightDate.Text = dr["ReturnFlightDate"].ToString();
            txtReturnFrom.Text = dr["ReturnFromPlace"].ToString();
            txtReturnTo.Text = dr["ReturnToPlace"].ToString();
            txtReturnFlightTime.Text = dr["ReturnFlightTime"].ToString();
            txtPurpose.Text = dr["Purpose"].ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private long GetFlightId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"]) : 0);
        }

        private void populateAuthorisedBy(String tadaId)
        {
            lblAuthorisedBy.Text = "";

            StringBuilder str1 = new StringBuilder("<table width=\"350\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            if (tadaId == "0")
                return;
            var dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='sa',@Id=" + filterstring(tadaId) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            string appStatus = GetApprovedStatus(GetFlightId().ToString());
            str1.Append("<tr>");
            str1.Append("<th>Sn</th>");
            for (int i = 1; i < cols; i++)
            {
                str1.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            if (appStatus == "Pending")
            {
                str1.Append("<th>Delete</th>");
            }
            else if (appStatus == "Approved")
            {
                str1.Append("");
                btnAdd.Visible = false;
                BtnSave.Visible = false;
            }
            str1.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str1.Append("<tr>");
                str1.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str1.Append("<td align=\"left\">" + dr[i] + "</td>");
                }
                if (appStatus == "Pending")
                {
                    str1.Append("<td align=\"left\"><img OnClick='OnDelete(" + dr["Id"] +
                                ")' class=\"clickimage\" src=\"../../Images/delete.gif\" /></td>");
                }
                else if (appStatus == "Approved")
                {
                    str1.Append("");
                }
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rpt.InnerHtml = str1.ToString();
        }

        private string GetApprovedStatus(string id)
        {
            return CLsDAo.GetSingleresult("EXEC procManageFlightDetails @flag='as',@id=" + id);
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            LblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, LblEmpName.Text);
            if (GetEmpInfoForLabel(txtEmpName.Text, LblEmpName.Text) == null)
                return;

            txtEmpName.Text = "";
            string emp_id = getEmpIdfromInfo(LblEmpName.Text);

            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='b', @emp_id=" + emp_id + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (dr == null)
                return;
            
            lblBranch.Text = dr["BRANCH_NAME"].ToString();
            lblDepartment.Text = dr["DEPARTMENT_NAME"].ToString();
            lblPosition.Text = dr["DETAIL_TITLE"].ToString();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var sql = "Exec procManageFlightDetails @flag='dr',@id=" + filterstring(GetID().ToString()) + ",@flightId=" +
                      filterstring(GetFlightId().ToString()) + "";
            var msg = CLsDAo.GetSingleresult(sql);
           if(msg.Contains("Success"))
           {
               Response.Redirect("ListRecord.aspx");
           }
           else
           {
               LblMsg.Text = "Error In Operation!";
               LblMsg.ForeColor = System.Drawing.Color.Red;
           }
        }

        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ListRecord.aspx");
        }

        protected void btnDeleteAuthorisation_Click(object sender, EventArgs e)
        {
            var sql = "DELETE FROM Flight_Authorization WHERE Id = " + hdnAuthorisedBy.Value + "";
            CLsDAo.runSQL(sql);
            DisplayAuthorisedBy();
        }
        
    }
}