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
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.PerformanceAppraisal
{
    public partial class AppraisalSearch : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        PerformanceAppraisalDAO _performanceAppDao = null;
        
        public AppraisalSearch()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
            _performanceAppDao = new PerformanceAppraisalDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if(GetFlag()=="notifyself")
                {
                    DisplayPendingApprisalList();
                }
                if (GetFlag() == "notifysupervisor")
                {
                    DisplayPendingApprisalListSupervisor();
                }
                if (GetFlag() == "notifyreviwer")
                {
                    DisplayPendingApprisalListReviwer();
                }
                if (GetFlag() == "notifyHR")
                {
                    DisplayPendingApprisalListHR();
                }
                SetYearStartEndDate();
                SetDDL();
            }
        }
        
        private string GetFlag()
        {
            return Request.QueryString["flag"] != null ? Request.QueryString["flag"] : "";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            FindAppraisalRatingByRole();
        }
        private void SetDDL()
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 73";
            _clsDao.setDDL(ref DdlRatingRoles, sql, "ROWID", "DETAIL_TITLE", "", "select");

        }   
        private void FindAppraisalRatingByRole()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">\n");
            var ds = _clsDao.ExecuteDataset("exec [proc_PerformanceAppraisal] @flag='su',@ratingRoles=" + filterstring(DdlRatingRoles.Text) + ","
            +" @ratingRolesId="+filterstring(ReadSession().Emp_Id.ToString())+",@fromDate="+filterstring(txtFromDate.Text)+",@toDate = "+filterstring(txtToDate.Text)+"");

            if (ds == null || ds.Tables.Count == 0)
            {
                rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                return;
            }
            int cols;
            DataTable dt;
            if (ds.Tables.Count == 2) {
                var dtt = ds.Tables[1];
                if (dtt.Rows[0]["errorCode"].ToString().Equals("1"))
                {
                    rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles.Modified ok  </b></center>\n";
                    return;
                }
                 dt = ds.Tables[0];
                 cols = dt.Columns.Count;
                 if (dt.Rows.Count > 0)
                 {

                     str.Append("<tr>\n");
                     // int cols = dt.Columns.Count;
                     for (int i = 3; i < cols; i++)
                     {
                         str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
                     }
                     str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
                     str.Append("</tr>\n");


                     foreach (DataRow dr in dt.Rows)
                     {
                         str.Append("<tr>");
                         for (int i = 3; i < cols; i++)
                         {
                             str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                         }
                         //str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "&ratingTypeId=" + DdlRatingRoles.Text + "\"" + ">View Appraisal </a> </td>");
                         str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View Appraisal\" href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "&ratingTypeId=" + DdlRatingRoles.Text + "\"" + "><i class=\"fa fa-eye\"></i></span></a></td>");
                     }

                     str.AppendLine("</tr>");
                     str.Append("</table>");
                     rptComments.InnerHtml = str.ToString();
                 }
                 else
                 {
                     rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                 }
            }
            else
            {
                dt = ds.Tables[0];
                cols = dt.Columns.Count;
                if (dt.Rows.Count > 0 && dt.Columns.Contains("errorCode"))
                {
                    if (dt.Rows[0]["errorCode"].ToString().Equals("1"))
                    {
                        rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                        return;
                    }
                }
                else
                {

                    if (dt.Rows.Count > 0)
                    {

                        str.Append("<tr>\n");
                        // int cols = dt.Columns.Count;
                        for (int i = 3; i < cols; i++)
                        {
                            str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
                        }
                        str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
                        str.Append("</tr>\n");


                        foreach (DataRow dr in dt.Rows)
                        {
                            str.Append("<tr>");
                            for (int i = 3; i < cols; i++)
                            {
                                str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                            }
                            //str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "&ratingTypeId=" + DdlRatingRoles.Text + "\"" + ">View Appraisal </a> </td>");
                            str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View Appraisal\" href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "&ratingTypeId=" + DdlRatingRoles.Text + "\"" + "><i class=\"fa fa-eye\"></i></span></a></td>");
                        }

                        str.AppendLine("</tr>");
                        str.Append("</table></div>");
                        rptComments.InnerHtml = str.ToString();
                    }
                    else {
                        rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                    }
                }
            }
        } 

        private void DisplayPendingApprisalList()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">\n");
            DataTable dt = _clsDao.getTable("exec [proc_PerformanceAppraisal] @flag='n',@ratingRolesId=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (dt.Rows.Count == 0)
            {
                rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                return;
            }
            str.Append("<tr>\n");
            int cols = dt.Columns.Count;
            for (int i = 3; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
            str.Append("</tr>\n");


            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 3; i < cols; i++)
                {
                    str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                }
                str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "\"" + ">Appraisal </a> </td>");
            }

            str.AppendLine("</tr>");
            str.Append("</table></div>");
            rptComments.InnerHtml = str.ToString();
        }

        private void DisplayPendingApprisalListSupervisor()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"3\" cellspacing=\"0\" align=\"left\">\n");
            DataTable dt = _clsDao.getTable("exec [proc_PerformanceAppraisal] @flag='nsup',@ratingRolesId=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (dt.Rows.Count == 0)
            {
                rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                return;
            }
            str.Append("<tr>\n");
            int cols = dt.Columns.Count;
            for (int i = 3; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
            str.Append("</tr>\n");


            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 3; i < cols; i++)
                {
                    str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                }
                str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "\"" + ">View Appraisal </a> </td>");
            }

            str.AppendLine("</tr>");
            str.Append("</table>");
            rptComments.InnerHtml = str.ToString();
        }
        private void DisplayPendingApprisalListReviwer()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">\n");
            DataTable dt = _clsDao.getTable("exec [proc_PerformanceAppraisal] @flag='nrev',@ratingRolesId=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (dt.Rows.Count == 0)
            {
                rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                return;
            }
            str.Append("<tr>\n");
            int cols = dt.Columns.Count;
            for (int i = 3; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
            str.Append("</tr>\n");


            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 3; i < cols; i++)
                {
                    str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                }
                str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "\"" + ">Appraisal </a> </td>");
            }

            str.AppendLine("</tr>");
            str.Append("</table></div>");
            rptComments.InnerHtml = str.ToString();
        }
        private void DisplayPendingApprisalListHR()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">\n");
            DataTable dt = _clsDao.getTable("exec [proc_PerformanceAppraisal] @flag='nhr',@ratingRolesId=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (dt.Rows.Count == 0)
            {
                rptComments.InnerHtml = "<center><b>No Record Found! Please Insert Valid Roles. </b></center>\n";
                return;
            }
            str.Append("<tr>\n");
            int cols = dt.Columns.Count;
            for (int i = 3; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.AppendLine("<th style=\"text-align:center\"><strong>Appraisal</strong></th>");
            str.Append("</tr>\n");


            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 3; i < cols; i++)
                {
                    str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                }
                str.Append("<td align=\"left\"><a href=\"AppraisalAllInfo.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + dr["EmpID"] + "&appraisalId=" + dr["appraisalId"] + "&positionId=" + dr["positionId"] + "\"" + ">Appraisal </a> </td>");
            }

            str.AppendLine("</tr>");
            str.Append("</table></div>");
            rptComments.InnerHtml = str.ToString();
        }

        private void SetYearStartEndDate()
        {
            var dr = _performanceAppDao.getYearStartEndDate();
            if (dr == null)
                return;

            txtFromDate.Text = dr["en_year_start_date"].ToString();
            txtToDate.Text = dr["en_year_end_date"].ToString();
        }

       
    }
}


