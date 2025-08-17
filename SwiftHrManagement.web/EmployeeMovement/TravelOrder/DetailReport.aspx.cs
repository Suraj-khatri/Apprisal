using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder
{
    public partial class DetailReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        clsDAO _clsDao = new clsDAO();
        double advance = 0;
        double project = 0;
        double actual = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetFlag().ToString() == "rd")
                {
                    populateData();
                }
                else if (GetFlag().ToString() == "sd")
                {
                    PopulateSettle();
                }
            }
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"]) : "");
        }

        private void populateData()
        {
            string OId = Request.QueryString["OId"] == null ? "" : Request.QueryString["OId"].ToString();

            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataSet ds = _clsDao.getDataset("Exec [proc_travelOrderReport] @flag='d',@OrderId=" + filterstring(OId));
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            foreach (DataRow dr in dt.Rows)
            {
                lblBranch.Text = dr["Branch"].ToString();
                lblDept.Text = dr["dept"].ToString();
                lblEmp.Text = dr["Emp"].ToString();
                lblReqDate.Text = dr["travelorderReqDate"].ToString();
                lblfrom.Text = dr["fromDate"].ToString();
                lblTo.Text = dr["toDate"].ToString();
                lblTransport.Text = dr["transportation"].ToString();
                lblPlace.Text = dr["placeOfVisit"].ToString();
                lblPurpose.Text = dr["purposeOfVisit"].ToString();
                advance = double.Parse(ShowDecimal(dr["advance"].ToString()));
                lblRecommend.Text = dr["recommendedBy"].ToString();
                lblRDate.Text = dr["recommendedDate"].ToString();
                lblRRemarks.Text = dr["recommendedRemarks"].ToString();
                lblVerify.Text = dr["approveByHr"].ToString();
                lblVDate.Text = dr["approveByHrDate"].ToString();
                lblVRemarks.Text = dr["hrRemarks"].ToString();
                lblApprove.Text = dr["finalApproveBy"].ToString();
                lblADate.Text = dr["finalApproveByDate"].ToString();
                lblARemarks.Text = dr["finalRemarks"].ToString();
            }

            double total = 0;
            str.Append("<tr>");
            int cols = dt1.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                } 
                total = total + double.Parse(dr[3].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"right\">Total</td>");
            str.Append("<td align=\"right\">" + ShowDecimal(total.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"right\">Advance</td>");
            str.Append("<td align=\"right\">" + ShowDecimal(advance.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptAllowance.InnerHtml = str.ToString();
        }

        private void PopulateSettle()
        {
            string OId = Request.QueryString["OId"] == null ? "" : Request.QueryString["OId"].ToString();

            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataSet ds = _clsDao.getDataset("Exec [proc_travelOrderReport] @flag='sd',@OrderId=" + filterstring(OId));
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];

            foreach (DataRow dr in dt.Rows)
            {
                lblBranch.Text = dr["branch"].ToString();
                lblDept.Text = dr["dept"].ToString();
                lblEmp.Text = dr["ReqBy"].ToString();
                lblReqDate.Text = dr["ReqDate"].ToString();
                lblfrom.Text = dr["fromDate"].ToString();
                lblTo.Text = dr["toDate"].ToString();
                lblTransport.Text = dr["transportation"].ToString();
                lblPlace.Text = dr["placeOfVisit"].ToString();
                lblPurpose.Text = dr["purposeOfVisit"].ToString();
                advance = double.Parse(ShowDecimal(dr["advance"].ToString()));
                lblRecommend.Text = dr["RecoBy"].ToString();
                lblRDate.Text = dr["RecoDate"].ToString();
                lblRRemarks.Text = dr["recommendedRemarks"].ToString();
                lblVerify.Text = dr["VerifyBy"].ToString();
                lblVDate.Text = dr["VerifyDate"].ToString();
                lblVRemarks.Text = dr["verifyRemarks"].ToString();
                lblApprove.Text = dr["ApproveBy"].ToString();
                lblADate.Text = dr["ApproveDate"].ToString();
                lblARemarks.Text = dr["finalRemarks"].ToString();
            }

            foreach (DataRow dr in dt2.Rows)
            {
                 project = double.Parse(dr["Total"].ToString());
            }

            str.Append("<tr>");
            int cols = dt1.Columns.Count;
            double total = 0;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                total = total + double.Parse(dr[3].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"right\">Actual Cost</td>");
            str.Append("<td align=\"right\">" + ShowDecimal(total.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"right\">Projected</td>");
            str.Append("<td align=\"right\">" + ShowDecimal(project.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"3\" align=\"right\">Advance</td>");
            str.Append("<td align=\"right\">" + ShowDecimal(advance.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptAllowance.InnerHtml = str.ToString();
        }
    }
}

