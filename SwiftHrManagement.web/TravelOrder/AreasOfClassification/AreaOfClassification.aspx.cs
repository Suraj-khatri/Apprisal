using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder.AreasOfClassification
{
    public partial class AreaOfClassification : BasePage
    {
        clsDAO Clsdao = null;
        private string countries_ids = "";
        private RoleMenuDAOInv _roleMenuDao = null;

        public AreaOfClassification()
        {
            Clsdao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateZone();
            }
            countries_ids = Request.Form["ctl00$MainPlaceHolder$Ddlassigned"];
        }

        private void PopulateAssigned()
        {
            Clsdao.CreateDynamicDDl(Ddlassigned, "EXEC proc_ClassificationOfAreas @flag='b',@zoneId=" + this.ddlZone.Text + "", "countriesId", "countriesName", "", "");
        }

        private void PopulateZone()
        {
            Clsdao.CreateDynamicDDl(ddlZone, @"select * from staticDataDetail where TYPE_ID=97", "Rowid", "DETAIL_TITLE", "", "Select");
        }
       
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();

        }

        private void OnSave()
        {

            string sql = "EXEC proc_ClassificationOfAreas @flag='i', @countriesId='" + countries_ids + "'";
            sql = sql + ",@zoneId=" + filterstring(this.ddlZone.Text);
            sql = sql + ",@user=" + filterstring(ReadSession().Emp_Id.ToString());
            string msg = Clsdao.GetSingleresult(sql);
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void DdlUnassigned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Ddlassigned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlZone.Text == "")
            {
                Ddlassigned.Items.Clear();

            }
            else
            {
                PopulateAssigned();
                Clsdao.CreateDynamicDDl(DdlUnassigned, "EXEC proc_ClassificationOfAreas @flag='z',@rowId='1'", "Rowid", "DETAIL_TITLE", "", "");
            }

        }




    }
}