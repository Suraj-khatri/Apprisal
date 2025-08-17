using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.OrganoChart
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = null;
        public Manage()
        {
            _clsdao = new clsDAO();
        }
        private long GetChartId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private long GetChartIdForAdd()
        {
            return (Request.QueryString["Grpid"] != null ? long.Parse(Request.QueryString["Grpid"].ToString()) : 0);
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"].ToString()) : "");
        }

        private void populatechart()
        {
          DataTable dt =  _clsdao.getTable("exec procOrganizationChart 's',@id='" + GetChartId() + "'");
          foreach (DataRow dr in dt.Rows)
          {
              DdlItems.Text = dr["id"].ToString();
              TxtNewItems.Text = dr["unit_name"].ToString();
              TxtDecs.Text = dr["unit_desc"].ToString();
              Ddlempname.SelectedValue = dr["Name"].ToString();
              DdlItems.Enabled = false;
          }
        }
        private void manageChart()
        {
            string strflagflag = "";
            long id = GetChartId();
            if (id == 0)
                strflagflag = "i";
            else
                strflagflag = "u";
            _clsdao.runSQL("exec [procOrganizationChart] '"+ strflagflag +"','"+ id +"','"+ ReadSession().UserId +"',"+ filterstring(TxtNewItems.Text) +","
            + ""+ filterstring(TxtDecs.Text) +",'"+ DdlItems.Text +"','"+ Ddlempname.Text +"'");
            //populateDdl();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                manageChart();
                LblMsg.Text = "Inserted Successfully!";
                LblMsg.ForeColor = System.Drawing.Color.Green;

            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void populateDdl()
        {
            _clsdao.CreateDynamicDDl(DdlItems, "select unit_name, id from OrgChart", "id", "unit_name", "", "Select");
            _clsdao.CreateDynamicDDl(Ddlempname, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' "
            + " + LAST_NAME AS EmpName FROM Employee", "EMPLOYEE_ID", "EmpName", "", "Select");
            DdlItems.Text = GetChartIdForAdd().ToString();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetFlag() =="a") //check the user weather user is logged in or not

                this.Page.MasterPageFile = "~/ProjectMaster.Master";
            else
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
                if (GetChartId() > 0)
                {
                    populatechart();
                    BtnDelete.Visible = true;
                    btnSave.Visible = true;
                }

                if (DdlItems.SelectedItem.Text == "Board")
                {
                    BtnDelete.Visible = false;
                    btnSave.Visible = false;
                }
                 
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_clsdao.GetSingleresult("exec procOrganizationChart 'c',@id='" + GetChartId() + "'") == "No")
            {
                LblMsg.Text = "Cannot Delete, Has Got Child Node!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
                try
                {
                    _clsdao.runSQL("exec procExecuteSQLString 'd' , 'delete from OrgChart' , ' and id=''" + GetChartId() + "''', '" + ReadSession().UserId + "'");
                    LblMsg.Text = "Deleted Successfully!";
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    LblMsg.Text = "Error In Operation";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
        }

    }
}
