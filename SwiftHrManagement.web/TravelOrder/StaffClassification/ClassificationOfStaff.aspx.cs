using System;
using  SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder.StaffClassification
{
    public partial class ClassificationOfStaff : BasePage
    {
        clsDAO Clsdao = null;
        private string post_ids = "";
        private RoleMenuDAOInv _roleMenuDao = null;
        

        public ClassificationOfStaff()
        {
            Clsdao = new clsDAO();
            _roleMenuDao=new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PopulateCatagory();
            }
            post_ids = Request.Form["ctl00$MainPlaceHolder$Ddlassigned"]; 
        }

        private void PopulateAssigned()
        {
            Clsdao.CreateDynamicDDl(Ddlassigned, "EXEC proc_travelOrderPostCategory @flag='b',@categoryId=" + this.ddlCatagory.Text + ",@categoryfor=" + filterstring(ddlCategoryFor.Text) + "", "positionId", "positionName", "", "");
        }

        private void PopulateCatagory()
        {
            Clsdao.CreateDynamicDDl(ddlCategoryFor, @"select * from staticDataDetail where TYPE_ID=41", "Rowid", "DETAIL_TITLE", "", "Select");
            Clsdao.CreateDynamicDDl(ddlCatagory, @"select * from staticDataDetail where TYPE_ID=96", "Rowid", "DETAIL_TITLE", "", "Select");
        }

        protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCatagory.Text == "")
            {
                Ddlassigned.Items.Clear();

            }
            else
            {
                PopulateAssigned();
                Clsdao.CreateDynamicDDl(DdlUnassigned, "EXEC proc_travelOrderPostCategory @flag='z',@rowId='4',@categoryId=" + this.ddlCatagory.Text + ",@categoryfor=" + filterstring(ddlCategoryFor.Text) + "",  "Rowid", "DETAIL_TITLE", "", "");
            }
        }

        

        protected void BtnSave_Click(object sender, EventArgs e)
       {
           
           OnSave();
       }
         
        private void OnSave()
        {
           
                string sql2 = "Exec proc_travelOrderPostCategory @flag='i', @positionId='" + post_ids + "'";
                sql2 = sql2 + ",@categoryfor="+filterstring(this.ddlCategoryFor.Text)+", @categoryId=" + filterstring(this.ddlCatagory.Text);
                sql2 = sql2 + ",@user=" + filterstring(ReadSession().Emp_Id.ToString());
                string msg2 = Clsdao.GetSingleresult(sql2);
                if (msg2.Contains("Success"))
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    lblmsg.Text = msg2;
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

        
        
       
    }
}