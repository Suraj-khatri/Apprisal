using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class AddSupervisor : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnShow();
            }
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void OnShow()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("Exec [procGetSupervisorInfo] @flag='a',@emp_id=" + filterstring(GetEmpId().ToString()) + "");
            int cols = dt.Columns.Count;

            DataTable dt1 = _clsDao.getTable("exec [procGetSupervisorInfo] @flag='b',@emp_id=" + filterstring(GetEmpId().ToString()) + "");
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
                    //str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"\"><span onclick = \"IsDelete('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\"><i class=\"fa fa-times\"></i></span></a></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }
        private void OnSave()
        {
            string[] a = txtSuperVisor.Text.Split('|');
            string SuperVisorId = a[1];

            
            string sql = "Exec [proc_SuperVisroAssignment] @flag='i',@EMP_ID=" + filterstring(GetEmpId().ToString());
            sql = sql + ",@SUP_ID=" + filterstring(SuperVisorId);
            sql = sql + ",@SUP_TYPE=" + filterstring(DdlSuperVisorType.Text);
            sql = sql + ",@USER=" + filterstring(ReadSession().Emp_Id.ToString());

            string msg = _clsDao.GetSingleresult(sql);
            if (msg.Contains("SUCCESS"))
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Green;
                OnShow();
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            
        } 
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("update SuperVisroAssignment set record_status='n',MODIFY_BY=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                        + " MODIFY_DATE=" + filterstring(System.DateTime.Now.ToString()) + " where SV_ASSIGN_ID=" + hdnId.Value + "");

                OnShow();
            }
            catch
            {
                lblmsg.Text = "Error In Deletion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
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
    }
}