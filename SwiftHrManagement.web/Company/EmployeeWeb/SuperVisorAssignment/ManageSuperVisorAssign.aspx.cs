using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment
{
    public partial class ManageSuperVisorAssign : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        BranchDao branchDao = null;

         public ManageSuperVisorAssign()
        {
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this.branchDao = new BranchDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 13) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            lblmsg.Text = "";
        }

        private void OnSave()
         {   
                string[] a = txtSuperVisor.Text.Split('|');
                string SuperVisorId = a[1];

                string emp_id = getEmpIdfromInfo(lblEmpName.Text);
                if (emp_id == "")
                {
                    lblmsg.Text = "Please choose employee!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    string sql = "Exec [proc_SuperVisroAssignment] @flag='i',@EMP_ID=" + filterstring(getEmpIdfromInfo(lblEmpName.Text));
                    sql = sql + ",@SUP_ID=" + filterstring(SuperVisorId);
                    sql = sql + ",@SUP_TYPE=" + filterstring(DdlSuperVisorType.Text);
                    sql = sql + ",@USER=" + filterstring(ReadSession().Emp_Id.ToString());

                    string msg = _clsDao.GetSingleresult(sql);
                    if (msg.Contains("SUCCESS!"))
                    {
                        lblmsg.Text = "Supervisor has been successfully assigned to the employee!!";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        SupervisorHistroy();
                    }
                    else
                    {
                        lblmsg.Text = msg;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
        } 

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Error in Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
               
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procGetSupervisorInfo] @flag='a',@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).ToString()) + "");
            int cols = dt.Columns.Count;
            DataTable dt1 = _clsDao.getTable("exec [procGetSupervisorInfo] @flag='b',@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).ToString()) + "");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\" colspan='" + cols + "'><b>Current Employee Status >> Branch : </b>" + dr["BRANCH_ID"].ToString() + ","
                + " <b>Dept :</b> " + dr["DEPARTMENT_ID"].ToString() + ", <b>Position:</b> " + dr["POSITION_ID"].ToString() + "</td>");
                str.Append("</tr>");
                
            }
           

            str.Append("<tr>");            
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    //str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"\"><span onclick = \"IsDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><i class=\"fa fa-times\"></i></span></a></td>");


                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("Delete from  SuperVisroAssignment where SV_ASSIGN_ID=" + hdnId.Value + "");

                SupervisorHistroy();
            }
            catch
            {
                lblmsg.Text = "Error In Deletion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void SupervisorHistroy()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procGetSupervisorInfo] @flag='a',@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).ToString()) + "");
            int cols = dt.Columns.Count;
            DataTable dt1 = _clsDao.getTable("exec [procGetSupervisorInfo] @flag='b',@emp_id=" + filterstring(getEmpIdfromInfo(lblEmpName.Text).ToString()) + "");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\" colspan='" + cols + "'><b>Current Employee Status >> Branch : </b>" + dr["BRANCH_ID"].ToString() + ","
                + " <b>Dept :</b> " + dr["DEPARTMENT_ID"].ToString() + dr["POSITION_ID"].ToString() + "</td>");
                str.Append("</tr>");

            }


            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    //str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"\"><span onclick = \"IsDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><i class=\"fa fa-times\"></i></span></a></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }
    }
}
