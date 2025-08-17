using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


namespace SwiftHrManagement.web.CEA
{
    public partial class CEASetup : BasePage
    {
        string CEAamount = "";
        string RowIDs = "";
        clsDAO _clsDao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            CEAamount = (Request.Form["txtAmount"] ?? "").ToString();
            RowIDs = (Request.Form["rowId"] ?? "").ToString();
            CEAamount = CEAamount.Replace("\t", " ");
            CEAamount = CEAamount.Replace("\n", " ");
            CEAamount = CEAamount.Replace("\r", " ");

            if (!IsPostBack)
            {
                OnShowPositionCEA();
            }
            lblMsg.Text = GetMsg();

        }
        private string GetMsg()
        {
            return (Request.QueryString["msg"] != null ? (Request.QueryString["msg"].ToString()) : "");
        }
        private void OnShowPositionCEA()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("Exec [procCEA_Setup] @flag='s'");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th align=\"left\" class=\"GridHeader\">" + dt.Columns[i].ColumnName + "</th>");

                }

                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 2)
                        {
                            str.Append("<td align=\"right\"><input class='form-control' type='text' name='txtAmount' id='txtAmount_" + dr["POSITION ID"] + "' value='" + (dr["CEA AMOUNT"].ToString()) + "'/></td>");
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
                str.Append("</div>");
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

            string msg = _clsDao.GetSingleresult("Exec [procCEA_Setup] @flag='i',@rowids='" + RowIDs + "',@CEAAmount='" + CEAamount + "',"
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("CEASetup.aspx?msg=" + msg + "");
            }
            else
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
    }
}