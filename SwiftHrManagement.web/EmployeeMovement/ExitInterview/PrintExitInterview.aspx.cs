using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.EmployeeMovement.ExitInterview
{
    public partial class PrintExitInterview : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnPopulateSheetHead();
                OnPopulateEmpProfile();
                OnPopulateCS();
            }
        }

        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void OnPopulateSheetHead()
        {
            _CompanyCore = _company.FindCompany();
            compInfo.Text = _CompanyCore.Name + " </br>" + _CompanyCore.Address;
        }

        private void OnPopulateEmpProfile()
        {
            DataTable dt = _clsDao.getTable("EXEC [proc_exitInterview] @flag='s',@discountID=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                lblName.Text = dr["empname"].ToString();
                lblPost.Text = dr["POST"].ToString();
                lblBranch.Text = dr["branch_name"].ToString();
                lblDept.Text = dr["dept"].ToString();
                lblReason.Text = dr["reason"].ToString();
                lblComments.Text = dr["comments"].ToString();
            }
        }

        private void OnPopulateCS()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("EXEC [proc_exitInterview] @flag='s1',@discountID=" + filterstring(GetId().ToString()) + "");

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<tD align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></tD>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            exitInterview.InnerHtml = str.ToString();
        }
    }
}