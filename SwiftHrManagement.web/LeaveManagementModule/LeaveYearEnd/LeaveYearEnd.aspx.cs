using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveYearEnd
{
    public partial class LeaveYearEnd : BasePage
    {
        clsDAO _CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public LeaveYearEnd()
        {
            _CLsDAo = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 28) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                SetDefaultYear();
            }
        }

        public string GetEmpId()
        {
            return ReadSession().Emp_Id.ToString();

        }

        public void DoEndLeaveYear()
        {
            string sql = "exec procLeaveYearEnd @user=" + filterstring(GetEmpId()) + ",@year=" + filterstring(txtDefaultYear.Text);
            string msg = _CLsDAo.GetSingleresult(sql);
            LblMsg.Text = msg;
            //LblMsg.Text = SQL;
        }

        public void DoEndLeaveYearContract()
        {
            string sql = "exec procLeaveYearEndContract @user=" + filterstring(GetEmpId()) + ",@year=" + filterstring(txtDefaultYear.Text);
            string msg = _CLsDAo.GetSingleresult(sql);
            LblMsg.Text = msg;
            //LblMsg.Text = SQL;
        }

        public void DoEndLeaveYearOther()
        {
            string sql = "exec procLeaveYearEndOther @user=" + filterstring(GetEmpId()) + ",@year=" + filterstring(txtDefaultYear.Text);
            string msg = _CLsDAo.GetSingleresult(sql);
            LblMsg.Text = msg;
            //LblMsg.Text = SQL;
        }

        public void DoChangeYear()
        {
            string sql = "exec proc_UpdateFiscalMonth @year=" + filterstring(txtDefaultYear.Text);
            string msg = _CLsDAo.GetSingleresult(sql);
            LblMsg.Text = msg;
            //LblMsg.Text = SQL;
        }


        public void SetDefaultYear()
        {

            string sql = "select nplYear from Fiscal_Month where DefaultYr='1'";
            string msg = _CLsDAo.GetSingleresult(sql);
            txtDefaultYear.Text = msg;
        }

        protected void BtnEndYear_Click(object sender, EventArgs e)
        {
            DoEndLeaveYear();
        }

        protected void BtnEndYearContract_Click(object sender, EventArgs e)
        {
            DoEndLeaveYearContract();
        }

        protected void BtnEndYearOther_Click(object sender, EventArgs e)
        {
            DoEndLeaveYearOther();
        }

        protected void BtnChangeBSYear_Click(object sender, EventArgs e)
        {
            DoChangeYear();
        }
    }
}
