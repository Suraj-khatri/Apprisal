using System;
using System.Data;
using System.Text;


namespace SwiftHrManagement.web.Company.PositionHierarchySetup
{
    public partial class Manage : BasePage
    {
        string postHier = "";
        string RowIDs = "";
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            postHier = (Request.Form["txtAmount"] ?? "").ToString();
            RowIDs = (Request.Form["rowId"] ?? "").ToString();
            postHier = postHier.Replace("\t", " ");
            postHier = postHier.Replace("\n", " ");
            postHier = postHier.Replace("\r", " ");

            if (!IsPostBack)
            {
                OnShowPositionLFA();
            }
            lblMsg.Text = GetMsg();
        }
        private string GetMsg()
        {
            return (Request.QueryString["msg"] != null ? (Request.QueryString["msg"].ToString()) : "");
        }
        private void OnShowPositionLFA()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _clsDao.getTable("Exec [proc_PositionHierarchySetup] @flag='s'");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th align=\"CENTER\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 2)
                        {
                            str.Append("<td align=\"right\"><input class='inputTextBoxSmall' type='text' name='txtAmount' id='txtAmount_" + dr["POSITION ID"] + "' value='" + (dr["POSITION HIERARCHY"].ToString()) + "'/></td>");
                        }
                        else
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }

                    }
                    str.Append("<input type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + dr["POSITION ID"].ToString() + "\" value = \"" + dr["POSITION ID"].ToString() + "\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rptDiv.InnerHtml = str.ToString();
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
                lblMsg.Text = "Error In Operation!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {

            string msg = _clsDao.GetSingleresult("Exec [proc_PositionHierarchySetup] @flag='i',@rowids='" + RowIDs + "',@Hierarchy='" + postHier + "',"
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("Manage.aspx?msg=" + msg + "");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}