using System;
using System.Data;


namespace SwiftHrManagement.web.Payrole_management.RateSetup
{
    public partial class ManageRateSetup : BasePage
    {
        private clsDAO ClsDao = null;
        public ManageRateSetup()
        {
            ClsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetID() > 0)
                {
                    PopulateData();
                    PopulateCatagory();
                }
                else
                {
                    PopulateData();
                    BtnDelete.Visible = false;
                }
            }
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private void PopulateData()
        {
            ClsDao.CreateDynamicDDl(ddlCategoryFor, "select * from staticdatadetail where type_id=41", "Rowid", "detail_title", "", "Select");
            ClsDao.CreateDynamicDDl(ddlCategory, "select * from staticdatadetail where type_id=96", "Rowid", "detail_title", "", "Select");
        }
        private void PopulateCatagory()
        {

            DataTable dt = new DataTable();
            dt = ClsDao.getDataset("select * from payratesetup where id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            this.ddlCategoryFor.SelectedValue = dr["category_for"].ToString();
            this.ddlCategory.SelectedValue = dr["category"].ToString();
            this.txtAmount.Text = ShowDecimal(dr["amount"].ToString());
            if (dr["flag"].ToString()=="Y")
                this.ChkActive.Checked = true;
            else
                this.ChkActive.Checked = false;
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            string active = "";
            string Flag = "";
            if (this.ChkActive.Checked == true)
                active = "Y";
            else
               active = "N";

            if (GetID() > 0)
                Flag = "u";
            else
                Flag = "i";

            string sql = "Exec Proc_PayableRateSetup @flag=" + filterstring(Flag) + ",@id=" + filterstring(GetID().ToString()) + ",@caterogy_for=" + filterstring(this.ddlCategoryFor.Text) + "" +
                         ", @category=" + filterstring(this.ddlCategory.Text) + ",@amount="+filterstring(txtAmount.Text)+",@user="+filterstring(ReadSession().Emp_Id.ToString())+"" +
                         ", @Active=" + filterstring(active)+"";

            String Msg = ClsDao.GetSingleresult(sql);

            if (Msg == "Success!")
            {
                LblMsg.Text = "Rate has been recorded successfully!!";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                txtAmount.Text = "";
                ddlCategory.Text = "";
            }
            else
            {
                LblMsg.Text = Msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string sql = "Exec Proc_PayableRateSetup @flag='d',@id=" + filterstring(GetID().ToString()) + "";

            String Msg = ClsDao.GetSingleresult(sql);
            LblMsg.Text = Msg;
            LblMsg.ForeColor = System.Drawing.Color.Green;

        }

        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ListRateSetup.aspx");
        }
    }
}