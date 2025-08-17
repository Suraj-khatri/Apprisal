using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.StaticView.FiscalYearSetup
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public Manage()
        {
            _clsdao = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        private long GetTaskid()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }                
                if(GetTaskid() > 0)
                populatefiscalyear();
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }
        private void managefiscalyear()
        {
            long id = GetTaskid();
            bool isdefault;
            if (ChkCurrent.Checked == true)
                isdefault = true;
            else
                isdefault = false;
            if (id == 0)
                _clsdao.runSQL("exec [proc_fiscalyear_setup] 'i','" + ReadSession().UserId + "','" + id + "','" + TxtfyEnglish.Text + "','" + TxtFyNepali.Text + "','" + TxtEngStartDate.Text + "','" + TxtEngyearEndDate.Text + "','"+ isdefault +"'");
            else
                _clsdao.runSQL("exec [proc_fiscalyear_setup] 'u','" + ReadSession().UserId + "','" + id + "','" + TxtfyEnglish.Text + "','" + TxtFyNepali.Text + "','" + TxtEngStartDate.Text + "','" + TxtEngyearEndDate.Text + "','"+ isdefault +"'");
        }
        private string alreadyexists()
        {
            long id = GetTaskid();
            DataTable dt = _clsdao.getTable("exec [proc_fiscalyear_setup] 'c'");
            string ifexists = "";
            foreach (DataRow dr in dt.Rows)
            {
                 ifexists = (dr["FLAG"].ToString()).ToString();   
            }
            return (ifexists);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            long id = GetTaskid();
            if (alreadyexists() == "True" && id == 0 && ChkCurrent.Checked == true)
            {
                LblMsg.Text = "Setup Already Exists";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                managefiscalyear();
                Response.Redirect("List.aspx");
            }
        }
        private void populatefiscalyear()
        {
            long id = GetTaskid();
            DataTable dt = _clsdao.getTable("exec [proc_fiscalyear_setup] 's',@id ='"+ id +"'");
            foreach (DataRow dr in dt.Rows)
            {
                TxtfyEnglish.Text = dr["FISCAL_YEAR_ENGLISH"].ToString();
                TxtFyNepali.Text = dr["FISCAL_YEAR_NEPALI"].ToString();
                TxtEngStartDate.Text = dr["EN_YEAR_START_DATE"].ToString();
                TxtEngyearEndDate.Text = dr["EN_YEAR_END_DATE"].ToString();
                if (Convert.ToString(dr["FLAG"]) == "True")
                    ChkCurrent.Checked = true;
                else
                    ChkCurrent.Checked = false;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
