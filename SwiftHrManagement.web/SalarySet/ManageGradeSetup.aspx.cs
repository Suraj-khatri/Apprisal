using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.SalarySet;

namespace SwiftHrManagement.web.SalarySet
{
    public partial class ManageGradeSetup : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        private SalarySetDao _salarySetDao = null;
        public ManageGradeSetup()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._salarySetDao = new SalarySetDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 210) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                DisplaySalaryDetails();
                txtSalaryTitle.Text = Request.QueryString["SalaryTitle"].ToString();
                txtSalaryTitle.Enabled = false;
            }
            DivMsg.InnerText = "";
        }

        protected long GetSalarySetMasterId()
        {
            return ReadNumericDataFromQueryString("MasterId");
        }

        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
        private long GetGrade()
        {
            return (Request.QueryString["Grade"] != null ? long.Parse(Request.QueryString["Grade"].ToString()) : 0);
        }

        private void DisplaySalaryDetails()
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table  width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");
           DataTable dt = _salarySetDao.FindGradeDeatilsById(GetSalarySetMasterId()); 

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th class=\"text-center\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th class=\"text-center\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th class=\"text-center\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td class=\"text-left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td class=\"text-center\"><img onclick = \"DeleteNotification('" + dr["id"] + "')\" class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");

                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {
            DataTable dt = _salarySetDao.OnSaveUpdateGrade(GetSalarySetMasterId().ToString(), txtGradeFrom.Text, txtGradeTo.Text, txtAmount.Text, ReadSession().Emp_Id.ToString(), GetGrade());
 
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];
            if (dr["error_code"].ToString() == "1")
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "warning");
            }
            else
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "success");
            }
            DisplaySalaryDetails();
            txtGradeFrom.Text = "";
            txtGradeTo.Text = "";
            txtAmount.Text = "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _salarySetDao.OndeleteGrade(long.Parse(hdnDeleteId.Value));
                DivMsg.InnerHtml = "Data Delete Successfully";
                DivMsg.Attributes.Add("class", "success");
                DisplaySalaryDetails();
        }
    }
}