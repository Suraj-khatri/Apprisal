using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.EmployeeWeb.ExtendHistory
{
    public partial class Manage : BasePage
    {

        protected string Id = "";
        private clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnPopulate();
                btnUpdate.Visible = true;
            }
           
        }
         private int dec(string Crypt){
             Id = StringEncryption.Decrypt(GetId());
                return ParseInt(Id);            
            }


        private string GetId()
        {
            return (Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "");

        }



        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec [procManageEmployeeType] @flag='d',@id=" + filterstring(dec(GetId().ToString()).ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            lblEmpName.Text = dr["emp_name"].ToString();
            lblBranch.Text = dr["branch_name"].ToString();
            lblDept.Text = dr["dept_name"].ToString();
            lblPost.Text = dr["post_name"].ToString();
            lblEmpType.Text = dr["emp_type"].ToString();
            lblCreatedBy.Text = dr["created_by"].ToString();
            lblCreatedDate.Text = dr["created_date"].ToString();
            txtFromDate.Text = dr["Cont_DateFrm"].ToString();
            txtToDate.Text = dr["Cont_DateTo"].ToString();
        }
        private void OnUpdate()
        {
            string msg=_clsDao.GetSingleresult("Exec [procManageEmployeeType] @flag='b',@id=" + filterstring(GetId().ToString()) + ","
                                                +" @from_date="+filterstring(txtFromDate.Text)+",@to_date="+filterstring(txtToDate.Text)+","
                                                +" @user="+filterstring(ReadSession().Emp_Id.ToString())+"");
            if(msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OnUpdate();
            }
            catch
            {
                LblMsg.Text = "Error in insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                LblMsg.Text = "Error in insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("Exec [procManageEmployeeType] @flag='c',@id=" + filterstring(GetId().ToString()) + ","
                                                  + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

    }
}