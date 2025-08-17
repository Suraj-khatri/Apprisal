using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement
{
    public partial class ManageRecoSettlement : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        TravelOrderSettlementDao _TOSettleDao = new TravelOrderSettlementDao();
        TravelOrderDao _travelOrderDao = new TravelOrderDao();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetFlag().ToString() == "v")
                {
                    showcc.Visible = true;
                    divApprove.Visible = true;
                    ddlRecommend.Visible = false;
                    lblforward.Visible = false;
                }
                FindTravelOrderInfoById();
                fillDate();
                setDDL();
                createTable();

            }
            BtnSave.Attributes.Add("onclick", "GetId();");
            txtSettlementToDate.Attributes.Add("OnChange", "DateDifference();");
            txtRate.Attributes.Add("OnBlur", "TotalAllowance();");
            txtSettlementFromDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
            txtSettlementToDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"]) : "");
        }

        private void setDDL()
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 64";
            _clsDao.setDDL(ref ddlAllowance, sql, "ROWID", "DETAIL_TITLE", "", "Select");
            var sql1 = "SELECT SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[SUPERVISOR_NAME] FROM SuperVisroAssignment WHERE EMP =1005 and SUPERVISOR_TYPE ='i' and record_status = 'y'";
            _clsDao.setDDL(ref ddlRecommend, sql1, "SUPERVISOR", "SUPERVISOR_NAME", "", "Select");
        }

        private string GetTravelOrderId()
        {
            return (Request.QueryString["TravelOID"] != null ? (Request.QueryString["TravelOID"]) : "");
        }

        private string GetTravelOrdSetId()
        {
            return (Request.QueryString["TravelOSID"] != null ? (Request.QueryString["TravelOSID"]) : "");
        }


      

        private void FindTravelOrderInfoById()
        {
            DataTable dt = _TOSettleDao.FindTravelOrderInfoById(GetTravelOrderId().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            lblReqBy.Text = dr["reqBy"].ToString();
            LblPlaceOfVisit.Text = dr["placeOfVisit"].ToString();
            lblPurpose.Text = dr["purposeOfVisit"].ToString();
            lblModeOfTrnas.Text = dr["transportation"].ToString();
            lblReqDate.Text = dr["reqDate"].ToString();
            lblReqAdv.Text = dr["advance"].ToString();
            lblToDate.Text = dr["approveTo"].ToString();
            lblFromDate.Text = dr["approveFrom"].ToString();
            TimeSpan TS = (DateTime.Parse(lblToDate.Text) - DateTime.Parse(lblFromDate.Text));
            lblTotal.Text = TS.Days.ToString();
            LblRegion.Text = dr["region"].ToString();
            hdnregion.Value = dr["regionId"].ToString();
       
        }

        private void fillDate()
        {
            DataTable dt = _clsDao.getTable("select convert(varchar,settlementfromDate,101) settlementfromDate,"
                            +" convert(varchar,settlementtoDate,101)settlementtoDate from travelOrderSettlement "
                            +" where travelOrderId= " + GetTravelOrderId().ToString());
            DataRow dr = dt.Rows[0];

            txtSettlementFromDate.Text  =  dr["settlementfromDate"].ToString();
            txtSettlementToDate.Text    =  dr["settlementtoDate"].ToString();
            TimeSpan TS = (DateTime.Parse(dr["settlementtoDate"].ToString()) - DateTime.Parse(dr["settlementtoDate"].ToString()));
            txtDays.Text = TS.Days.ToString();
        }

        private void createTable()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _TOSettleDao.FindTravelSettlementById("",GetTravelOrderId().ToString());
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
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }


        private void OnAllowanceAdd()
        {
            string msg = _TOSettleDao.OnAllowanceAdd(ddlAllowance.Text, txtRate.Text, HdnTotal.Value, "", txtDays.Text, GetTravelOrderId().ToString(), txtCurrency.Text);
            lblDMsg.Text = msg;
            createTable();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAllowanceAdd();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _TOSettleDao.OnDelete(HdnTravelOrderId.Value);
            lblDMsg.Text = msg;
            createTable();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetFlag().ToString() == "r")
            {
                string sql = "Exec [proc_travelOrderSettlement] @flag='sr',@settlementfromDate=" + filterstring(txtSettlementFromDate.Text) + ","
                + " @settlementtoDate=" + filterstring(txtSettlementToDate.Text) + ",@approveToVerify=" + filterstring(ddlRecommend.Text) + ","
                + " @recommendedRemarks=" + filterstring(txtRemarks.Text) + ",@travelOrdSetId=" + GetTravelOrdSetId().ToString();
                _clsDao.GetSingleresult(sql);
                Response.Redirect("/EmployeeMovement/TravelOrder/Settlement/RecommendSettlement.aspx");
            }
            else if (GetFlag().ToString() == "v")
            {
                _clsDao.GetSingleresult("Exec [proc_travelOrderSettlement] @flag='sv',@settlementfromDate=" + filterstring(txtSettlementFromDate.Text) + ","
                +" @settlementtoDate=" + filterstring(txtSettlementToDate.Text) + ",@finalApproveBy=" + filterstring(hdnEmployeeId.Value) + ","
                + " @verifyRemarks=" + filterstring(txtRemarks.Text) + ",@ccList="+filterstring(HiddenFieldEmpEmail.Value)+","
                + " @approveToVerify="+ReadSession().Emp_Id+",@travelOrdSetId=" + GetTravelOrdSetId().ToString());
                Response.Redirect("/EmployeeMovement/TravelOrder/Settlement/VerifySettlement.aspx");
            }
            else if (GetFlag().ToString() == "a")
            {
                _clsDao.GetSingleresult("Exec [proc_travelOrderSettlement] @flag='su',@settlementfromDate=" + filterstring(txtSettlementFromDate.Text) + ","
                +" @settlementtoDate=" + filterstring(txtSettlementToDate.Text) + ",@finalRemarks=" + filterstring(txtRemarks.Text) + ","
                +" @travelOrdSetId=" + GetTravelOrdSetId().ToString());
                Response.Redirect("/EmployeeMovement/TravelOrder/Settlement/ApproveSettlement.aspx");
               
            }
        }

        protected void ddlAllowance_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arrayEmpId = lblReqBy.Text.Split('|');
            string empId = arrayEmpId[1];
            DataTable dt = _travelOrderDao.FindRateAllownce(ddlAllowance.Text, _travelOrderDao.GetPositionId(empId), hdnregion.Value);
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
