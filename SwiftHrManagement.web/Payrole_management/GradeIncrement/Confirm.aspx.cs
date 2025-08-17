using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Payrole_management.GradeIncrement
{
    public partial class Confirm : BasePage
    {
        clsDAO _clsDao=new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 256) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                OnLoadReport();
            }
        }

        private void OnLoadReport()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            DataTable dt = _clsDao.getTable("EXEC proc_gradeIncrement_test @flag='save',@fiscalYear="+filterstring(GetFiscalYear())+","
                        +"@appRating="+filterstring(GetAppraisalRating())+",@effectiveDate="+filterstring(GetEffectiveFrom())+","
                        +"@applyDate="+filterstring(GetApplyOnDate())+",@emp_ids='"+GetEmpIds()+"',@user="+filterstring(ReadSession().Emp_Id.ToString())+"");
            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
            			
        }

        private string GetFiscalYear()
        {
            return (Request.QueryString["fiscalYear"] != null ? (Request.QueryString["fiscalYear"]) : "");
        }

        private string GetAppraisalRating()
        {
            return (Request.QueryString["appRate"] != null ? (Request.QueryString["appRate"]) : "");
        }

        private string GetEffectiveFrom()
        {
            return (Request.QueryString["effectiveFrom"] != null ? (Request.QueryString["effectiveFrom"]) : "");
        }

        private string GetApplyOnDate()
        {
            return (Request.QueryString["applyOn"] != null ? (Request.QueryString["applyOn"]) : "");
        }

        private string GetEmpIds()
        {
            return (Request.QueryString["empIds"] != null ? (Request.QueryString["empIds"]) : "");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string sql = "EXEC proc_gradeIncrement @flag='save',@fiscalYear=" + filterstring(GetFiscalYear()) + ","
            + "@appRating=" + filterstring(GetAppraisalRating()) + ",@effectiveDate=" + filterstring(GetEffectiveFrom()) + ","
            + "@applyDate=" + filterstring(GetApplyOnDate()) + ",@emp_ids='" + (GetEmpIds()) + "',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";

            string msg = _clsDao.GetSingleresult(sql);

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblMsgDis.Text = msg;
                lblMsgDis.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }
}