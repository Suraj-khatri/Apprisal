using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OverTime.OverTimeDataSetup
{
    public partial class ManageOtRateSetUp :BasePage
    {
           clsDAO _clsDao = null;
           RoleMenuDAOInv _RoleMenuDAOInv = null;

           public ManageOtRateSetUp()
        {
            _clsDao = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetRateId() > 0)
                {
                    PopulateData();

                }
                else
                {

                    Btn_delete.Visible = false;
                }

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 56) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }

        }

        private long GetRateId()
        {
            return (Request.QueryString["Rate_Id"] != null ? long.Parse(Request.QueryString["Rate_Id"].ToString()) : 0);
        }

        private void PopulateData()
        {

            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec [proc_OtRateSetUp] @flag='s',@ot_rate_id="+GetRateId()+"").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (dr == null)
                return;

            txtDescription.Text = dr["description"].ToString();
            DdlRateType.Text = dr["rate_type"].ToString();
            txtAmount.Text = dr["amount"].ToString();
            DdlOverTimeON.Text = dr["overtime_on"].ToString();
            if(dr["rate_type"].ToString() == "f")
                DdlOverTimeON.Enabled = false;
            else
                DdlOverTimeON.Enabled = true;

        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            ProcessData();
            Response.Redirect("/OverTime/OverTimeDataSetup/ListRateSetup.aspx");
        }

        private void ProcessData()
        {
            string sql = "Exec [proc_OtRateSetUp] @flag =" +(GetRateId().ToString() == "0" ? "'i'" : "'u'");
            sql = sql + ", @ot_rate_id = " + filterstring(GetRateId().ToString());
            sql = sql + ", @description = " + filterstring(txtDescription.Text);
            sql = sql + ", @rate_type = " + filterstring(DdlRateType.Text);
            sql = sql + ", @amount = " + filterstring(txtAmount.Text);
            sql = sql + ", @user = " + filterstring(ReadSession().UserId);
            sql = sql + " ,@overtime_on=" + filterstring(DdlOverTimeON.Text);
            _clsDao.runSQL(sql);
        

        }

        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            DeleteOperation();
        }
        private void DeleteOperation()
        {
            _clsDao.runSQL("Exec proc_OtRateSetUp @flag='d',@ot_rate_id=" + GetRateId() + "");
            Response.Redirect("/OverTime/OverTimeDataSetup/ListRateSetup.aspx");

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/OverTime/OverTimeDataSetup/ListRateSetup.aspx");

        }


        protected void DdlRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlRateType.SelectedValue == "f")
            {
                DdlOverTimeON.Enabled = false;
            }
            else
                DdlOverTimeON.Enabled = true;
        }
    }
}
