using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SwiftHrManagement.web.Inventory.ReqSchedule
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDDL();
                if (GetId() > 0)
                {
                    OnPouplateSchedule();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }

        private void PopulateDDL()
        {
            _clsDao.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME+' ('+BRANCH_SHORT_NAME+')' BRANCH_NAME FROM Branches ORDER BY BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnSave()
        {
            string flag = "";
            string msg = "";
            
            if (GetId() > 0)
                flag = "u";
            else
                flag = "i";

            msg = _clsDao.GetSingleresult("EXEC [procManageINReqSchedule] @FLAG=" + filterstring(flag) + ",@ID=" + filterstring(GetId().ToString()) + ","
                                + " @BRANCH_ID=" + filterstring(ddlBranch.Text) + ",@DAY_NUM=" + filterstring(txtDayNum.Text) + ","
                                + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("SORRY"))
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("EXEC [procManageINReqSchedule] @FLAG='D',@ID=" + filterstring(GetId().ToString()) + "");

            if (msg.Contains("SORRY"))
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        private void OnPouplateSchedule()
        {
            DataTable dt = _clsDao.getTable("EXEC [procManageINReqSchedule] @FLAG='S',@ID=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                ddlBranch.SelectedValue = dr["BRANCH_ID"].ToString();
                txtDayNum.Text = dr["DAY_NUM"].ToString();
            }
        }
    }
}