using System;
using System.Data;
using System.Text;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.TravelOrder.ApproveExtension
{
    public partial class ApproveExtensonManage : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        TravelOrderDao _travelOrderDao = new TravelOrderDao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateTADA();
                populateAuthorisedBy(GetTadaId().ToString());
                populateCurrencyAmount(GetTadaId().ToString());
                populateExtApproveBy();
            }
        }
        private long GetTadaId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void PopulateTADA()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec proc_travel @flag='a', @id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            this.LblEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();
            this.lblbranch.Text = dr["branch_name"].ToString();
            this.lbldepartment.Text = dr["department_name"].ToString();
            this.lblposition.Text = dr["detail_title"].ToString();
            this.lblcity.Text = dr["destination_city"].ToString();
            this.lblcountry.Text = dr["country"].ToString();
            this.lblreasontravel.Text = dr["reason_for_travel"].ToString();
            if (this.lblreasontravel.Text == "Transfer")
            {
                this.divtraveldate.Visible = false;
            }
            this.lblfromdate.Text = dr["duration_from"].ToString();
            this.lbltodate.Text = dr["duration_to"].ToString();
            this.lblextension.Text = dr["extension"].ToString();

            if (this.lblextension.Text == "Yes")
            {
                this.divIsExtVisit.Visible = true;
                this.lblextfrom.Text = dr["durex_from"].ToString();
                this.lblextto.Text = dr["durex_to"].ToString();
                this.lblextcity.Text = dr["durex_city"].ToString();
                this.Lblextcountry.Text = dr["extension_country"].ToString();
                this.lblleaveaaplied.Text = "Yes";
                this.lblremainingdays.Text = dr["dur_leave"].ToString();
            }

            this.lblmode.Text = dr["mode_of_travel"].ToString();
            this.lbltransportation.Text = dr["transportation"].ToString();
            this.lblaccomodation.Text = dr["accomodation"].ToString();
            this.lblfooding.Text = dr["fooding"].ToString();
            this.lblcashadvance.Text = dr["cashadvance"].ToString();

            if (this.lblcashadvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
            }

            if (lblmode.Text == "By Air" && lbltransportation.Text == "To be Paid By Bank")
            {
                divflightDetails.Visible = true;
                lblFlightDate.Text = dr["flightDate"].ToString();
                lblFromPlace.Text = dr["fromPlace"].ToString();
                lblToPlace.Text = dr["toPlace"].ToString();
                lblFlightTime.Text = dr["flightTime"].ToString();
                lblReturnFlightDate.Text = dr["returnFlightDate"].ToString();
                lblReturnFromPlace.Text = dr["ReturnFromPlace"].ToString();
                lblReturnToPlace.Text = dr["returnToPlace"].ToString();
                lblReturnFlightTime.Text = dr["returnFlightTime"].ToString();
            }

            else if (dr["flightDate"] == null)
            {
                divflightDetails.Visible = false;
            }
        }
        private void populateAuthorisedBy(String tadaId)
        {
            StringBuilder str1 = new StringBuilder("<table width=\"200\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            var dt = _clsdao.getDataset("EXEC Proc_Travel @flag='s',@Id=" + filterstring(tadaId) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            str1.Append("<tr>");
            str1.Append("<th>S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str1.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str1.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str1.Append("<tr>");
                str1.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str1.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rpt.InnerHtml = str1.ToString();
        }
        private void populateCurrencyAmount(String tadaId)
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<table width=\"200\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelOrderDao.FindCurrencyAndAmt(tadaId);

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            //str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + count++ + " </td>");
                for (int i = 1; i < cols; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                //str.Append("<td align=\"left\"><img onclick = 'DeleteCurrency(" + dr["Id"] + ")' class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt2.InnerHtml = str.ToString();
        }
        private void populateExtApproveBy()
        {
            StringBuilder str1 = new StringBuilder("<table width=\"200\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\">");

            var dt = _clsdao.getDataset("SELECT Id,dbo.GetEmployeeFullNameOfId(ExtApproveBy) [Approve By] FROM tada WHERE id =" + filterstring(GetTadaId().ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            int count = 1;
            str1.Append("<tr>");
            str1.Append("<th>S.N.</th>");
            for (int i = 1; i < cols; i++)
            {
                str1.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str1.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str1.Append("<tr>");
                str1.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str1.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            rptApprove.InnerHtml = str1.ToString();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveStatus();
        }
        private void ApproveStatus()
        {
            string sql = _clsdao.GetSingleresult("update tada set ExtStatus='Approved' where IsExtention='Y'and Id=" +
                                      filterstring(GetID().ToString()));
            Response.Redirect("ApproveExtensionList.aspx");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            RejectStatus();
        }
        private void RejectStatus()
        {
            string sql = _clsdao.GetSingleresult("update tada set ExtStatus='Rejected' where IsExtention='Y'and Id=" +
                                     filterstring(GetID().ToString()));
            Response.Redirect("ApproveExtensionList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveExtensionList.aspx");
        }

    }
}