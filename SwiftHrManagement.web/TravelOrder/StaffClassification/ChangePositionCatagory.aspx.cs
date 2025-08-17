using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.TravelOrder.StaffClassification
{
    public partial class ChangePositionCatagory : BasePage
    {
        private clsDAO ClsDao = null;
        public  ChangePositionCatagory()
        {
            ClsDao=new clsDAO();
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

        private void PopulateData()
        {
            ClsDao.CreateDynamicDDl(DdlCatagoryFor, "select * from staticdatadetail where type_id=41", "Rowid", "detail_title", "", "Select");
            ClsDao.CreateDynamicDDl(DdlCatagory, "select * from staticdatadetail where type_id=96", "Rowid", "detail_title", "", "Select");
            ClsDao.CreateDynamicDDl(DdlPosition, "select positionId, dbo.GetDetailTitle(positionId) as positionname from tadapositioncategory where id=" + GetID(), "positionId", "positionname", "", "");
            PopulateCatagory();
        }
        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

       
      
        private void PopulateCatagory()
        {
          
            DataTable dt = new DataTable();
           dt = ClsDao.getDataset("select * from tadaPositionCategory where id=" + filterstring(GetID().ToString()) + "").Tables[0];
           DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            this.DdlCatagoryFor.SelectedValue = dr["category_for"].ToString();
            this.DdlCatagory.SelectedValue = dr["categoryId"].ToString();
            this.DdlisActive.SelectedValue = dr["isActive"].ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            string sql = "Exec proc_travelOrderPostCategory @flag='u',@categoryfor=" + filterstring(this.DdlCatagoryFor.Text) + ", @categoryId=" + filterstring(this.DdlCatagory.Text) + "";
            sql = sql + ",@isActive=" + filterstring(this.DdlisActive.SelectedItem.Value);
            sql = sql + ",@id=" + GetID();

            ClsDao.GetSingleresult(sql);
            Response.Redirect("List.aspx");
            
        }
    }
}