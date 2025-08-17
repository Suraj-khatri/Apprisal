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
    public partial class OtRuleSetup : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

         public OtRuleSetup()
        {
            _clsDao = new clsDAO();
             this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 55) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }


        }      

        protected void BtnSave_Click1(object sender, EventArgs e)
        {

            OperationData();
            ResetField();

        }
        private void OperationData()
        {
            string msg= _clsDao.GetSingleresult("Exec [proc_OtRuleSetUp] @flag='i',@days_in_month="+ filterstring(txtDaysInMonth.Text)+",@hour_in_day="+filterstring(txtHourInDay.Text)+","
            + " @created_by="+filterstring(ReadSession().UserId)+"");

            lblmsg.Text = msg;
            lblmsg.ForeColor = System.Drawing.Color.Green;
      }

        private void ResetField()
        {
            txtDaysInMonth.Text = "";
            txtHourInDay.Text = "";
           // DdlOverTimeON.SelectedValue = "";
        }
    }
}
