using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.web.DAL.PerformanceAppraisal.Matrix;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix
{
    public partial class ManageOther : BasePage
    {
        clsDAO _clsDao = null;
        AppriasalMatrixDao _matrixDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageOther()
        {
            _clsDao = new clsDAO();
            _matrixDao = new AppriasalMatrixDao();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }


                SetDDL();
                DisplayOtherSection();
                
            }
            lblTemplate.Text = _matrixDao.GetTemplateNameById(ReadNumericDataFromQueryString("templateId"));
        }



        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {

            DataTable dt = _matrixDao.OnSaveOther(ddlSection.Text, txtQuestion.Text, ReadNumericDataFromQueryString("templateId"), ReadSession().UserId,ddlAnsType.Text);
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
            DisplayOtherSection();
        }
        private void DisplayOtherSection()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _matrixDao.FindOtherSectionById(ReadNumericDataFromQueryString("templateId"));
            if (dt.Rows.Count == 0)
            {
                rpt.InnerHtml = "<center><b>No Result to Display</b></center>\n";
                return;
            }

            str.Append("<tr>\n");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.Append("</tr>\n");
             foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td width=\"50%\" align=\"left\">" + dr[i].ToString() + "</td>");

                    }
                    else if(i == 4)
                    {
                        str.Append("<td width=\"50%\" align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td>");

                }

                str.Append("</tr> \n");
              }

            str.Append("<tr></tr> \n");
            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();
        }

        private void SetDDL()
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 28 AND ROWID<>1900 AND ROWID<>1899 AND  ROWID NOT IN(294)";
            _clsDao.setDDL(ref ddlSection, sql, "ROWID", "DETAIL_TITLE", "", "select");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            DataTable dt = _matrixDao.OnDeleteOther(hdnDeleteId.Value);
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
            DisplayOtherSection();
        }
    }
}
