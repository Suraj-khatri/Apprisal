using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.web.DAL.TravelOrder;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement
{
    public partial class ManageReqSettlement : BasePage
    {
        TravelOrderSettlementDao _travelSettlementDao = new TravelOrderSettlementDao();
        TravelOrderDao _travelOrderDao = new TravelOrderDao();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        clsDAO _clsDao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                FindTravelOrderInfoById();
                FindTravelAllowanceById();
                setDDL();
                DisplayTravelSettleMent();
            }
            txtSettlementToDate.Attributes.Add("OnChange", "DateDifference();");
            txtRate.Attributes.Add("OnBlur", "TotalAllowance();");
            lblAllMsg.Text = "";
            LblMsg.Text = "";
            txtSettlementFromDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
            txtSettlementToDate.Attributes.Add("OnBlur", "checkDateFormat(this);");

        }
        private string GetTravelOrderId()
        {
            return (Request.QueryString["TravelOID"] != null ? (Request.QueryString["TravelOID"]) : "");
        }
        private void setDDL()
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 64";
            var sql1 = "SELECT SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[SUPERVISOR_NAME] FROM SuperVisroAssignment WHERE EMP ="+ReadSession().Emp_Id+" and SUPERVISOR_TYPE ='i' and record_status = 'y'";
            _clsDao.setDDL(ref ddlAllowance, sql, "ROWID", "DETAIL_TITLE", "", "Select");
            _clsDao.setDDL(ref ddlRecommend, sql1, "SUPERVISOR", "SUPERVISOR_NAME", "", "Select");
            
        }
        private void  FindTravelAllowanceById()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelSettlementDao.FindAllowanceById(GetTravelOrderId().ToString());
            if (dt.Rows.Count <= 0)
            {
                rpt.InnerText = "Record does not Exist";
                return;
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
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
                    if (i == 3 || i == 4)
                    {
                        str.Append("<td align=\"right\"><div style=\"text-align:right\">" + dr[i].ToString() + "</div></td>");
                    }
                    else
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            travelAllow.InnerHtml = str.ToString();
        

        }
        private void FindTravelOrderInfoById()
        {
            DataTable dt = _travelSettlementDao.FindTravelOrderInfoById(GetTravelOrderId().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];

            LblPlaceOfVisit.Text         = dr["placeOfVisit"].ToString();

            lblPurposeOfVisit.Text       = dr["purposeOfVisit"].ToString();

            lblModeOfTrnas.Text          = dr["transportation"].ToString();
            LblRegion.Text               = dr["region"].ToString();
            lblReqDate.Text              = dr["reqDate"].ToString();

            lblFromDate.Text             = dr["approveFrom"].ToString();
            lblToDate.Text               = dr["approveTo"].ToString();
            lblReqAdv.Text               = dr["advance"].ToString();
            TimeSpan TS                  = (DateTime.Parse(lblToDate.Text) -DateTime.Parse(lblFromDate.Text));
            lblTotal.Text                = TS.Days.ToString();
            hdnRegion.Value              = dr["regionId"].ToString();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAllowanceAdd();
        }
        private void OnAllowanceAdd()
        {

            string msg = _travelSettlementDao.OnAllowanceAdd(ddlAllowance.Text, txtRate.Text, HdnTotal.Value, ReadSession().Sessionid, txtDays.Text, GetTravelOrderId(),txtCurrency.Text);
            lblAllMsg.Text = msg;
            lblAllMsg.ForeColor = System.Drawing.Color.Green;
            DisplayTravelSettleMent();

        }
        private void DisplayTravelSettleMent()
        { 
         StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
         DataTable dt = _travelSettlementDao.FindTravelSettlementById(ReadSession().Sessionid,GetTravelOrderId());
            if (dt.Rows.Count <= 0)
            {
                rpt.InnerText = "Record does not Exist";
                return;
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
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
                    if (i == 3 || i == 4)
                    {
                        str.Append("<td align=\"right\"><div style=\"text-align:right\">" + dr[i].ToString() + "</div></td>");

                    }
                    else
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
            
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnfinalSave();
        }

        private void OnfinalSave()
        {
            string msg = _travelSettlementDao.OnFinalSave(GetTravelOrderId().ToString(), ReadSession().Emp_Id.ToString(), txtSettlementFromDate.Text, txtSettlementToDate.Text, ddlRecommend.Text, txtRemarks.Text,ReadSession().Sessionid,_travelOrderDao.GetPositionId(ReadSession().Emp_Id.ToString()));
            LblMsg.Text = msg;
            lblAllMsg.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("/EmployeeMovement/TravelOrder/Settlement/List.aspx");

        }

     
        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            string msg = _travelSettlementDao.OnDelete(HdnTravelOrderId.Value);
            LblMsg.Text = msg;
            lblAllMsg.ForeColor = System.Drawing.Color.Green;
            DisplayTravelSettleMent();
        }

        protected void ddlAllowance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _travelOrderDao.FindRateAllownce(ddlAllowance.Text, _travelOrderDao.GetPositionId(ReadSession().Emp_Id.ToString()),hdnRegion.Value);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
            {
                txtRate.Text = "";
                txtCurrency.Text = "";
                return;
            }
            dr = dt.Rows[0];

            txtRate.Text = dr["rate"].ToString();
            txtCurrency.Text = dr["currency"].ToString();
        }
    }
}
