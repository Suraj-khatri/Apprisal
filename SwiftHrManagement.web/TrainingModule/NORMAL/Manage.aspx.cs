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

namespace SwiftHrManagement.web.TrainingModule.NORMAL
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

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 219) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            OnDisplay();
            OnDisplayNominee();
            OnDisplayFile();
        }
        private void OnDisplayFile()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procTrainingFileUpload] @flag='s',@trainingId=" + filterstring(GetID().ToString()) + "").Tables[0];

            var str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            
            str.Append("<th align=\"left\">File Description</th>");
            str.Append("<th align=\"left\">File Extension</th>");
            str.Append("<th align=\"left\"></th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\"><a target='_blank' href='/doc/TrainingDoc" + "/" + dr["rowid"] + "." + dr["doc_ext"].ToString() + "'> Open </a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            displayFile.InnerHtml = str.ToString();

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
        }

        private long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private long GetEmpId()
        {
            return (Request.QueryString["emp_id"] != null ? long.Parse(Request.QueryString["emp_id"].ToString()) : 0);
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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetEmpId() > 0) //check the user weather user is logged in or not

                this.Page.MasterPageFile = "~/ProjectMaster.Master";
            else
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
        }

    }
}
