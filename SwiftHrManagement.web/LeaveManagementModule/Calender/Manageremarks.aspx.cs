using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.LeaveManagementModule.Calender
{
    public partial class Manageremarks : BasePage
    {
        clsDAO _clsdao = null;
        public Manageremarks()
        {
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateremarks();
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }
        private long getremarksid()
        {
            long id = 0;
            if (Request.QueryString["id"] != null)
                id = long.Parse(Request.QueryString["id"]);
            return id;
        }
        private void manageremarks()
        {
            long id = getremarksid();
            string strflag = "";
            id = getremarksid();
            if (id > 0)
                strflag = "u";
            else
                strflag = "i";

            LblMsg.Text = _clsdao.GetSingleresult("exec procholidayremarks " + filterstring(strflag) + "," + filterstring(id.ToString()) + "," + filterstring(TxtLeaveremarks.Text) + ",'R'");
        }
        private void populateremarks()
        {
            TxtLeaveremarks.Text = _clsdao.GetSingleresult("select rmarks from OfficialCalendar where id = " + filterstring(getremarksid().ToString()) + "");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                manageremarks();
                Response.Redirect("RemarksList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        private void deleteremarks()
        {
            LblMsg.Text = _clsdao.GetSingleresult("exec procholidayremarks 'd'," + filterstring(getremarksid().ToString()) + "");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                deleteremarks();
                Response.Redirect("RemarksList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
