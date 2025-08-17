using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SwiftHrManagement.web.TravelOrder.Matrix
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao=new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateDdl();
                MakeNumericTextbox(ref txtAmount);
                OnPopulateMatrix();
            }
        }

        private void populateDdl()
        {
            _clsdao.CreateDynamicDDl(ddlCategory, "Exec ProcStaticDataView @flag='s',@type_id='96'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            _clsdao.CreateDynamicDDl(ddlZone, "Exec ProcStaticDataView @flag='s',@type_id='97'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            _clsdao.CreateDynamicDDl(ddlHead, "Exec ProcStaticDataView @flag='s',@type_id='100'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            _clsdao.CreateDynamicDDl(ddlCurrency, "Exec ProcStaticDataView @flag='s',@type_id='72'", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSaveMatrix();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void OnSaveMatrix()
        {
            string msg = _clsdao.GetSingleresult("exec proc_tadaMatrix @flag='i',@categoryId="+filterstring(ddlCategory.Text)+","
                +" @zoneId="+filterstring(ddlZone.Text)+",@headId="+filterstring(ddlHead.Text)+",@currencyId="+filterstring(ddlCurrency.Text)+","
                +" @amount="+filterstring(txtAmount.Text)+",@user="+filterstring(ReadSession().Emp_Id.ToString())+"");

            if(msg.Contains("Success"))
            {
                OnPopulateMatrix();
                OnClearForm();
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void OnClearForm()
        {
            ddlCategory.Text = "";
            ddlZone.Text = "";
            ddlHead.Text = "";
            ddlCurrency.Text = "";
            txtAmount.Text = "";
        }

        private void  OnPopulateMatrix()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsdao.getTable("Exec [proc_tadaMatrix] @flag='view'");
            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"center\">Delete</th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    str.Append("<td align=\"center\"><div style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></div></td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("exec proc_tadaMatrix @flag='d',@id="+filterstring(hdnId.Value)+",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

                OnPopulateMatrix();
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}