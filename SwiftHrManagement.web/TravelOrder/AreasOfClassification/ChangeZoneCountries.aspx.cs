using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.TravelOrder.AreasOfClassification
{
    public partial class ChangeZoneCountries :BasePage
    {
        private clsDAO ClsDao = null;
        public ChangeZoneCountries()
        {
            this.ClsDao=new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetID() > 0)
                {
                    PopulateData();
                }
            }
        }

       
        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private void PopulateData()
        {
            ClsDao.CreateDynamicDDl(DdlZone, "select * from staticDataDetail where TYPE_ID=97", "Rowid", "DETAIL_TITLE", "", "Select");
            ClsDao.CreateDynamicDDl(DdlCountries, "select countriesId, dbo.GetDetailTitle(countriesId) as countriesname from tadaClassificationOfAreas where id=" + GetID(), "countriesId", "countriesname", "", "");
            PopulateZone();  
        }
     
        private void PopulateZone()
        {

            DataTable dt = new DataTable();
            dt = ClsDao.getDataset("select * from tadaClassificationOfAreas where id=" + filterstring(GetID().ToString()) + "").Tables[0];

            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            this.DdlZone.SelectedValue = dr["zoneId"].ToString();
            this.DdlisActive.SelectedValue = dr["isActive"].ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            string sql = "Exec proc_ClassificationOfAreas @flag='u', @zoneId=" + filterstring(this.DdlZone.Text) + "";
            sql = sql + ",@isActive=" + filterstring(this.DdlisActive.SelectedItem.Value);
            sql = sql + ",@id=" + GetID();

            ClsDao.GetSingleresult(sql);
            Response.Redirect("List.aspx");

        }

        protected void DdlZone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlisActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}