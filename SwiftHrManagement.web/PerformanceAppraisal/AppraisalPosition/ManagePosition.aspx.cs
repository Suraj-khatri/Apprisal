using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web.DAL.PerformanceAppraisal.Template;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalPosition
{
    public partial class ManagePosition : BasePage
    {
        clsDAO _clsDao = null;
        AppraisalPositionDAO _apDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManagePosition()
        {
            _clsDao = new clsDAO();
            _apDao = new AppraisalPositionDAO();
            _roleMenuDao = new RoleMenuDAOInv();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                getData();
                populateDdl();
                lblTemplateName.Text = _apDao.getTemplateName(gettemplateId());
            }
        }

        private string gettemplateId()
        {
            return Request.QueryString["templateId"] != null? Request.QueryString["templateId"] : "";
        }

        private void populateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlPosition, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 4", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PerformanceAppraisal/TemplateRecord/TemplateList.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblmsg.Text = _apDao.insertData(ddlPosition.Text, ReadSession().Sessionid);
            getData();
        }

        private void getData()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _apDao.getAddedData(ReadSession().Sessionid,gettemplateId());
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptPosition.InnerHtml = str.ToString();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            lblmsg.Text = _apDao.deleteRecord(hdnRowid.Value);
            getData();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            lblmsg.Text = _apDao.saveRecord(gettemplateId(),ReadSession().Sessionid);
            Response.Redirect("/PerformanceAppraisal/TemplateRecord/TemplateList.aspx");
        }
    }
}
