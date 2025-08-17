using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.FlightDetails.FlightDetailsVerify
{
   
        public partial class Manage : BasePage
        {
            clsDAO CLsDAo = null;
            RoleMenuDAOInv _roleMenuDao = null;
            TravelOrderDao _travelOrderDao = null;

            public Manage()
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
                        PopulateFlightDetails();
                        populateAuthorisedBy(GetFlightId().ToString());
                    }
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 283) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                    lblreadsession.Text = ReadSession().Emp_Id.ToString();
                }
            }

            private long GetFlightId()
            {
                return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
            }

            public void PopulateFlightDetails()
            {
                DataTable dt = new DataTable();
                dt = CLsDAo.getDataset("exec procManageFlightDetails @flag='a', @id=" + filterstring(GetID().ToString()) + "").Tables[0];
                DataRow dr = null;
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                }

                this.LblEmpName.Text = dr["empname"] + "|" + dr["employee_id"].ToString();

                lblbranch.Text = dr["branch_name"].ToString();
                lbldepartment.Text = dr["department_name"].ToString();
                lblposition.Text = dr["Position"].ToString();
                lblFlightDate.Text = dr["flightDate"].ToString();
                lblFromPlace.Text = dr["FromPlace"].ToString();
                lblToPlace.Text = dr["ToPlace"].ToString();
                lblFlightTime.Text = dr["FlightTime"].ToString();
                lblReturnFlightDate.Text = dr["ReturnFlightDate"].ToString();
                lblReturnFrom.Text = dr["ReturnFromPlace"].ToString();
                lblReturnTo.Text = dr["ReturnToPlace"].ToString();
                lblReturnFlightTime.Text = dr["ReturnFlightTime"].ToString();
                lblPurpose.Text = dr["Purpose"].ToString();
                txtVerificationMsg.Text = dr["verificationMsg"].ToString();

                if (dr["verificationStatus"].ToString() == "Pending")
                {
                    txtVerificationMsg.ReadOnly = false;
                }

                else if (dr["verificationStatus"].ToString() == "Verified")
                {
                    txtVerificationMsg.ReadOnly = true;
                    if (dr["authorised_id"].ToString() == ReadSession().Emp_Id.ToString() || dr["emp_id"].ToString() == ReadSession().Emp_Id.ToString())
                    {
                        this.BtnSave.Visible = false;
                        this.BtnReject.Visible = false;
                    }

                    else
                    {
                        this.BtnSave.Visible = false;
                        this.BtnReject.Visible = false;

                    }
                }
                else if (dr["verificationStatus"].ToString() == "Rejected")
                {
                    txtVerificationMsg.ReadOnly = true;
                    this.BtnReject.Visible = false;
                    this.BtnSave.Visible = false;
                }
            }

            public long GetID()
            {
                return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
            }

            protected void BtnSave_Click(object sender, EventArgs e)
            {
                AcceptStatus();
                Response.Redirect("List.aspx");
            }

            protected void BtnBack_Click(object sender, EventArgs e)
            {
                Response.Redirect("../Request/List.aspx");
            }

            protected void BtnReject_Click(object sender, EventArgs e)
            {
                RejectStatus();
                Response.Redirect("List.aspx");
            }

            private void RejectStatus()
            {
                CLsDAo.GetSingleresult(("UPDATE FlightDetails set verificationStatus='Rejected',verifiedBy= " + filterstring(ReadSession().Emp_Id.ToString()) + ",verificationMsg=" + filterstring(txtVerificationMsg.Text) + " WHERE id=" + filterstring(GetID().ToString())));
            }


            private void AcceptStatus()
            {
                string sql;
                sql = "EXEC procManageFlightDetails @flag='v', @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ", @id=" + filterstring(GetID().ToString()) + ", @verificationMsg=" + filterstring(txtVerificationMsg.Text);
                var dt = CLsDAo.ExecuteDataset(sql).Tables[0];

                printMsg.Text = dt.Rows[0]["return_message"].ToString();
                printMsg.Visible = true;
            }

            private void populateAuthorisedBy(String flightId)
            {
                StringBuilder str1 = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

                var dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='sa',@Id=" + filterstring(flightId) + "").Tables[0];

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
                        str1.Append("<td align=\"left\">" + dr[i] + "</td>");
                    }
                    str1.Append("</tr>");
                }
                str1.Append("</table>");
                rpt.InnerHtml = str1.ToString();
            }

            private void DisplayAuthorisedBy(DataTable dt)
            {

                StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

                if (dt == null)
                    dt = CLsDAo.getDataset("EXEC procManageFlightDetails @flag='sa',@session_id=" + filterstring(ReadSession().Sessionid) + "").Tables[0];

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
                        str.Append("<td align=\"left\">" + dr[i] + "</td>");
                    }
                    str.Append("<td align=\"left\"><img OnClick='OnDelete(" + dr["Id"] + ")' class=\"clickimage\" src=\"../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
                rpt.InnerHtml = str.ToString();
            }
        }
    }
