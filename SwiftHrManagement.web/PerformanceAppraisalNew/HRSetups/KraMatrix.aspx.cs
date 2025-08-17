using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class KraMatrix : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        AppraisalDAO _appraisal = null;
        clsDAO swift = null;
        public KraMatrix()
        {
            _Obj = new PerformanceAgreementDao();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            _appraisal = new AppraisalDAO();
            swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
            }

        }
        private void LoadGrid()
        {
            int i = 1;
            var dt = _appraisal.DepartMentTem();
            if (dt.Rows.Count == 0 || dt == null)
            {
                rptDiv.InnerHtml = "";
                return;
            }
            
            
            var sb = new System.Text.StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            sb.Append("<th >Sno</th>");
            sb.Append("<th> Department</th>");
            sb.Append("<th></th>");
            

            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + i + "</td>");
                sb.Append("<td>" + row["DETAIL_TITLE"] + "</td>");
              
                sb.Append("<td align='center'><a href='/PerformanceAppraisalNew/HRSetups/DepartMatrix.aspx?DepartId=" + row["ROWID"] + "' class='btn btn-info btn-xs'>Add Tamplet</a></td>");
                sb.Append("</tr>");
                i++;
               
            }
            sb.Append("</table></div>");
            rptDiv.InnerHtml = sb.ToString();
           
           
        }
    }
}