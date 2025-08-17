using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.SalarySet;

namespace SwiftHrManagement.web.SalarySetSetup
{
    public partial class ManageSalarySetDetails : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        private SalarySetDao _salarySetDao = null;
        public ManageSalarySetDetails()
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
                //lblPosition.Text = _clsdao.GetSingleresult("select ");
            }
            DivMsg.InnerText = "";

        }
        private long GetSalarySetId()
        {
            return ReadNumericDataFromQueryString("setId");

        }

        private void DisplaySalaryDetails()
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _salarySetDao.FindSalaryDeatilsById(GetSalarySetId());

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {

                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\"><img onclick = \"DeleteNotification('" + dr["setId"] + "')\" class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");

                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
            Response.Redirect("/SalarySetSetup/ListSalarySet.aspx");
        }
        private void OnSave()
        {

            DataTable dt = _salarySetDao.OnSaveUpdate(GetSalarySetId().ToString(), txtGradeFrom.Text,txtGradeTo.Text,txtGradeAmount.Text, ReadSession().Emp_Id.ToString());
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

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SalarySetSetup/ListSalarySet.aspx");
        }
    }
}