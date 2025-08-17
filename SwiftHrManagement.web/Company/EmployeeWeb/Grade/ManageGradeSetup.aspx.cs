using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb.Grade
{
    public partial class ManageGradeSetup : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ManageGradeSetup()
        {
            CLsDAo = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnPopulateDDL();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 58) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetId() > 0)
                {
                    PopulateGrade();              
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }

        private void OnPopulateDDL()
        {
            CLsDAo.CreateDynamicDDl(DdlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void PopulateGrade()
        {
            var sql = "SELECT id,position_id,rate from GRADE_SETUP where ID=" + GetId() + "";
            DataTable dt = CLsDAo.getDataset(sql).Tables[0];
            if(dt== null )
                return;
            DataRow dr = null;

            dr = dt.Rows[0];
            DdlPosition.SelectedValue = dr["position_id"].ToString();
            txtRate.Text = dr["rate"].ToString();
        }
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string flag="";
            if(GetId()>0)
               flag="u";
            else
                flag="i";

            if (txtRate.Text != "")
            {
                if (ParseDouble(txtRate.Text) > 100.00)
                {
                    lblmsg.Text = "Greater than 100.!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            string msg=CLsDAo.GetSingleresult("Exec procManageGradeSetup @flag="+filterstring(flag)+",@id="+filterstring(GetId().ToString())+","
                            +" @post_id="+filterstring(DdlPosition.Text)+",@rate="+filterstring(txtRate.Text)+",@user="+filterstring(ReadSession().Emp_Id.ToString())+"");
            if(msg.Contains("Success"))
            {
                Response.Redirect("ListGradeSetup.aspx");
            }
            else
            {
                lblmsg.Text=msg;
                lblmsg.ForeColor=System.Drawing.Color.Red;
                return;
            }
            
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                msg = CLsDAo.GetSingleresult("exec procManageGradeSetup @flag='d', @id=" + filterstring(GetId().ToString()));
                if(msg.Contains("Success"))
                {
                    Response.Redirect("ListGradeSetup.aspx");
                }
                else
                {
                    lblmsg.Text=msg;
                    lblmsg.ForeColor=System.Drawing.Color.Red;
                    return;
                }
            
            }
            catch
            {
                lblmsg.Text = "Error in Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
           
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListGradeSetup.aspx");
        }
    }
}