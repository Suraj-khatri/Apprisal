using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.PerformanceAppraisal.Details
{
    public partial class ManageAppraisalSupervisor : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (getID() > 0)
                {
                    btnSave.Visible = false;
                    OnPopulate();
                }
                else
                {
                    pnlAppraisee.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
            }
           
        }

        private long getID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0); 
        }

        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec procManageAppraisalSupervisor @flag='a',@id=" + filterstring(getID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            ddlRaterType.SelectedValue = dr["SUPERVISOR_TYPE"].ToString();
            if (dr["SUPERVISOR_TYPE"].ToString() == "rc" || dr["SUPERVISOR_TYPE"].ToString() == "h")
            {
                pnlAppraisee.Visible = false;
                txtRaterName.Text = dr["rater_name"].ToString();
                ddlStatus.SelectedValue = dr["record_status"].ToString();
            }
            else
            {
                txtRaterName.Text = dr["rater_name"].ToString();
                ddlStatus.SelectedValue = dr["record_status"].ToString();
                txtAppraiseeName.Text = dr["appraisee"].ToString();
                txtAppFromDate.Text = dr["FROM_DATE"].ToString();
                txtAppToDate.Text = dr["TO_DATE"].ToString();
                txtAppTargetDays.Text = dr["days"].ToString();

                ddlStatus.Enabled = false;
                txtAppFromDate.Enabled = false;
                txtAppToDate.Enabled = false;
                txtAppraiseeName.Enabled = false;
                ddlRaterType.Enabled = false;
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
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string[] a = txtRaterName.Text.Split('|');
            string rater_id = a[1];

            string msg=_clsDao.GetSingleresult("Exec procManageAppraisalSupervisor @flag='i',@rater_type=" + filterstring(ddlRaterType.Text) + ","
                                    +" @rater_id=" + filterstring(rater_id) + ",@status="+filterstring(ddlStatus.Text)+"");
            if (msg.Contains("Success"))
            {
                Response.Redirect("AppraisalSupervisor.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OnUpdate();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnUpdate()
        {
            string[] a = txtRaterName.Text.Split('|');
            string rater_id = a[1];

            string msg=_clsDao.GetSingleresult("Exec procManageAppraisalSupervisor @flag='u',@id=" + getID() + ",@rater_id="+filterstring(rater_id)+","
            + " @rater_type=" + filterstring(ddlRaterType.Text) + ",@status=" + filterstring(ddlStatus.Text) + ","
            + " @targetDays=" + filterstring(txtAppTargetDays.Text) + ",@user="+filterstring(ReadSession().Emp_Id.ToString())+"");

            if (msg.Contains("Success"))
            {
                Response.Redirect("AppraisalSupervisor.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("Exec procManageAppraisalSupervisor @flag='d',@id=" + getID() + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("AppraisalSupervisor.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppraisalSupervisor.aspx");
        }

    }
}
