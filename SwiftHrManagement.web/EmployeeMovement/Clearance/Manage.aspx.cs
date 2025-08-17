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

namespace SwiftHrManagement.web.EmployeeMovement.Clearance
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        string rowId = "";
        string selection = "";
        string remarks = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            selection = (Request.Form["ddlObjection"] ?? "").ToString();
            remarks = (Request.Form["txtremarks"] ?? "").ToString();
            rowId = (Request.Form["row_id"] ?? "").ToString();

            if (!IsPostBack)
            {
                OnLoadFrom();
                OnPopulateDetail();
            }
        }

        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void OnPopulateDetail()
        {
            _CompanyCore = _company.FindCompany();
            compInfo.Text = _CompanyCore.Name+" </br>"+_CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [proc_ClearingSheet] @flag='p',@discount_id=" + filterstring(GetId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                lblName.Text = dr["NAME"].ToString();
                lblPost.Text = dr["POST"].ToString();
                lblBranchDept.Text = dr["BRANCH_DEPT"].ToString();
                lblEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
            } 
        }

        private void OnLoadFrom()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("EXEC [proc_ClearingSheet] @flag='s',@discount_id="+ filterstring(GetId().ToString())+"");

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 1)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i==2)
                    {
                        str.Append("<td align=\"left\" width='200px'>" + dr[i].ToString() + "</td>");
                    }
                    
                }

                string selection = dr["Selection"].ToString();

                if (selection == "0")
                { 
                    str.Append("<td align=\"left\"><select ID=\"ddl_'" + dr[0].ToString() + "'\" name=\"ddlObjection\" class=\"FltCMBDesign\" width=\"50px\">"
                                + " <option value=\"\">Select</option>"
                               + " <option value=\"1\">Objection</option>"
                               + " <option value=\"0\" selected='selected'> No Objection</option></select>"
                    + "</td>");

                }
                if (selection == "1")
                {
                    str.Append("<td align=\"left\"><select ID=\"ddl_'" + dr[0].ToString() + "'\" name=\"ddlObjection\" class=\"FltCMBDesign\" width=\"50px\">"
                                + " <option value=\"\">Select</option>"
                               + " <option value=\"1\" selected='selected'>Objection</option>"
                               + " <option value=\"0\" > No Objection</option></select>"
                    + "</td>");

                }
                if (selection == "")
                {
                    str.Append("<td align=\"left\"><select ID=\"ddl_'" + dr[0].ToString() + "'\" name=\"ddlObjection\" class=\"FltCMBDesign\" width=\"50px\">"
                                + " <option value=\"\">Select</option>"
                               + " <option value=\"1\">Objection</option>"
                               + " <option value=\"0\"> No Objection</option></select>"
                    + "</td>");

                }

                str.Append("<td align=\"left\"><div style = \"margin-left:none\"><textarea ID=\"remarks_'" + dr[0].ToString() + "'\" name='txtremarks'"
                        + " class=\"inputTextBoxLP1\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:275px;text-align:top;text-mode:multiline\">"
                        + " " + dr[4].ToString() + "</textarea></div><input type=\"hidden\" name= \"row_id\"  id=\"rowId_ " + dr[0].ToString() + "\" value = \"" + dr[0].ToString() + "\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            clearanceForm.InnerHtml = str.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblMsg.Text = "Error in operation!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string msg = "";
            string[] sel_choice = Request.Form["ddlObjection"].Split(',');
            if (sel_choice.Contains(""))
            {
                lblMsg.Text = "Please Select Value for All Departments!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            msg = _clsDao.GetSingleresult("Exec [proc_ClearingSheet] @flag='i',@discount_id=" + filterstring(GetId().ToString()) + ",@rowId='"+rowId+"',"
                            + " @sel_choice='" + selection + "',@remarks='" + remarks + "',@user="+filterstring(ReadSession().Emp_Id.ToString())+"");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}