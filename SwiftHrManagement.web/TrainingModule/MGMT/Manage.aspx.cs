using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingModule.MGMT
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
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 218) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                CLsDAo.CreateDynamicDDl(ddlForwardedTo, "[ProcGetSupervisor] @flag='a',"
 + "@EMP_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMP_ID", "SUPERVISOR", "", "Select");                
            }
            OnCheckStatus(); 
            OnDisplay();
            OnDisplayNominee();

            //btnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void OnCheckStatus()
        {
            string status = CLsDAo.GetSingleresult("select status from training where id=" + GetID() + "");
            if (status == "Approved")
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnSave.Visible = false;
            }

            if (status == "Forwarded")
            {
                btnReject.Visible = true;
                btnApprove.Visible = true;
            }
            if (status == "Closed")
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnAddNominee.Visible = false;
            }
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
            lblTrainerCost.Text = dr["trainerCost"].ToString();
            lblFoodVenueCost.Text = dr["foodVenueCost"].ToString();
            lblPerPersonCost.Text = dr["perPersonCost"].ToString();
            lblOtherCost.Text = dr["otherCost"].ToString();
            lblTotalCost.Text = dr["totCost"].ToString();
        }

        private long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
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
                txtEmployeeName.Text = "";
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
            string status = CLsDAo.GetSingleresult("select status from training where id=" + GetID() + "");
            dt = CLsDAo.getDataset("Exec [procTrainingManage] @flag='e',@id=" + filterstring(GetID().ToString()) + "").Tables[0];

            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            if (status != "Recorded")
            {
                str.Append("<th align=\"left\">Delete</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                if (status != "Recorded")
                {
                    str.Append("<td align=\"left\"><a href=\"\"><span onclick = \"OnDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><img src=\"../../Images/delete.gif\"/></span></a></td>");
                }
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
                OnDisplayNominee();
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManage] @flag='app',@user="+filterstring(ReadSession().Emp_Id.ToString())+","
            +" @id=" + filterstring(GetID().ToString()) + "");
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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                OnReject();
            }
            catch
            {
                LblMsg.Text = "Error In Rejection!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnReject()
        {
            CLsDAo.GetSingleresult("Exec [procTrainingManage] @flag='r',@id=" + filterstring(GetID().ToString()) + "");
            Response.Redirect("List.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnForward();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnForward()
        {
            string msg = CLsDAo.GetSingleresult("Exec [procTrainingManage] @flag='forward',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            + " @id=" + filterstring(GetID().ToString()) + ",@forwardEmp="+filterstring(ddlForwardedTo.Text)+"");
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



    }
}
