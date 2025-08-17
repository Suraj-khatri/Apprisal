using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.LeaveCalender;
using SwiftHrManagement.DAL.Role;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.LeaveManagementModule.Calender
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsDao=null;
        string menuList = "";

        public Manage()
        {
            this._clsDao=new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            menuList = Request.Form["chkId"];
            string selectValue = "";
            if (DdlBranchGroup.SelectedItem != null)
                selectValue = DdlBranchGroup.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlBranchGroup, "Exec ProcStaticDataView 'b','103'", "ROWID", "DETAIL_TITLE", selectValue, "All");
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 25) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetHoilidayCalenderId() > 0)
                {
                    this.btnDelete.Visible = false;
                    branchPnl.Visible = true;
                    //DisableFields();
                    showAllBranch.Visible = false;
                    PopulateCalander();
                    OnShowBranch();
                }
                else
                {
                    OnShowBranch();
                    this.btnDelete.Visible = false;
                }
            }
        }

        private long GetHoilidayCalenderId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private string GetTitle() 
        {
            return (Request.QueryString["TITLE"] != null ? Request.QueryString["TITLE"].ToString() : "");
        }
        private string GetDate()
        {
            return (Request.QueryString["DATE"] != null ? Request.QueryString["DATE"].ToString() : "");
        }
        private string checkFemaleOnly()
        {
            string checkFemale;
            if (ChkFemaleOnly.Checked == true)
            {
                checkFemale = "F";
            }
            else
            {
                checkFemale = "A";
            }
            return checkFemale;
        }
        private void DisableFields()
        {
            ddlBranchName.Enabled = false;
            txtholidayTitle.Enabled = false;
            TxtDate.Enabled = false;
            ChkFemaleOnly.Enabled = false;
        }
        private void ManageCalender()
        {
            long Id = this.GetHoilidayCalenderId();
            string flag = "";
            string msg = "";
            if (Id > 0)
            {
                msg = _clsDao.GetSingleresult("Exec procManageHolidayCalender @FLAG='u',@id='"+Id+"',@BRANCHES='" + menuList + "',"
                + " @TITLE=" + filterstring(txtholidayTitle.Text) + ",@DATE=" + filterstring(TxtDate.Text) + ","
                + " @DESC=" + filterstring(TxtDescription.Text) + ",@FEMALE_ONLY=" + filterstring(checkFemaleOnly()) + ","
                + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            }
            else
            {
                msg = _clsDao.GetSingleresult("Exec procManageHolidayCalender @FLAG='i',@BRANCHES='" + menuList + "',"
                + " @TITLE=" + filterstring(txtholidayTitle.Text) + ",@DATE=" + filterstring(TxtDate.Text) + ","
                + " @DESC=" + filterstring(TxtDescription.Text) + ",@FEMALE_ONLY=" + filterstring(checkFemaleOnly()) + ","
                + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            }
            
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Green;
            }            
        }

        private void PopulateCalander()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec [procManageHolidayCalender] @flag='s',@id=" + filterstring(GetHoilidayCalenderId().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            _clsDao.CreateDynamicDDl(ddlBranchName, "SELECT BRANCH_ID,UPPER(BRANCH_NAME+' ('+BRANCH_SHORT_NAME+')') BRANCH_NAME FROM BRANCHES", "BRANCH_ID", "BRANCH_NAME", "" + dr["BRANCH_ID"].ToString() + "", "SELECT");
            txtholidayTitle.Text = dr["TITLE"].ToString();
            TxtDate.Text = dr["DATE"].ToString();
            TxtDescription.Text = dr["DESCRIPTION"].ToString();
            if (dr["FEMALE_ONLY"].ToString() == "F")
            {
                this.ChkFemaleOnly.Checked = true;
            }
            else
            {
                this.ChkFemaleOnly.Checked = false;
            }
        }

        private void OnShowBranch()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt;
            if (this.GetHoilidayCalenderId() > 0)
            {
                dt = _clsDao.getTable("Exec [procManageHolidayCalender] @flag='x',@TITLE=" + filterstring(GetTitle()) + ",@DATE=" + filterstring(TxtDate.Text) + ",@BRANCH_GROUP=" + filterstring(DdlBranchGroup.Text) + "");
            }
            else
            {
                dt = _clsDao.getTable("Exec [procManageHolidayCalender] @flag='b',@BRANCH_GROUP=" + filterstring(DdlBranchGroup.SelectedItem.ToString()) + "");
            }
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"CENTER\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\"><b><a href=\"javascript:void(0);\" onClick=\"CheckAll(this)\">Check All</a> / <a href=\"javascript:void(0);\" onClick=\"UncheckAll(this)\">Uncheck All</a></b> </th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    string title;
                    str.Append("<tr>");
                    for (int i = 2; i < cols; i++)
                    {
                          str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    if (this.GetHoilidayCalenderId() > 0)
                    {
                        str.Append("<td align=\"center\"><input type='checkbox' id = \"chk_" + dr["branch_id"].ToString() + "\" name ='chkId' value='" + dr["branch_id"].ToString() + "' " + (dr["FLAG"].ToString() == "1" ? "checked='checked'" : "") + " /></td>");
                    }
                    else
                    {
                        str.Append("<td align=\"center\"><input type='checkbox' id = \"chk_" + dr["branch_id"].ToString() + "\" name ='chkId' value='" + dr["branch_id"].ToString() + "' " + (dr["branch_id"].ToString() != "" ? "checked='checked'" : "") + " /></td>");
                    }
                    str.Append("</tr>");
                }
                str.Append("</table></div>");
                rptDiv.InnerHtml = str.ToString();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageCalender();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnDelete()
        {
            string msg = _clsDao.GetSingleresult("EXEC [procManageHolidayCalender] @FLAG='d',@ID=" + filterstring(GetHoilidayCalenderId().ToString()) + "");
            
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

        protected void DdlBranchGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
                OnShowBranch();
        }
    }
}
