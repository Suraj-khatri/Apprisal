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


namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder
{
    public partial class RecommendTO : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        TravelOrderDao _travelDao = new TravelOrderDao();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected  int days;
      
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetFlag().ToString() == "a")
                {
                    BtnRecommend.Text = "Approve";
                   
                }
                else if (GetFlag().ToString() == "v")
                {
                    BtnRecommend.Text = "Forward";
                    forwardPanal.Visible = true;
                    showcc.Visible = true;

                }
                getData();
                PopulateGrid();
                setDDL();
            }
            DisablePopulate();
            
            BtnRecommend.Attributes.Add("onclick", "GetId();");
            txtApprovTo.Attributes.Add("OnChange", "DateDifference();");
            txtPerDay.Attributes.Add("OnBlur", "TotalAllowance();");
            lblAllowanceMsg.Text = "";
           
        }
        private void setDDL()
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 64";
            _clsDao.setDDL(ref ddlAllowance, sql, "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void DisablePopulate()
        {
                txtReqBy.Enabled = false;
                txtPlaceOfVisit.Enabled = false;
                txtPurposeOfVisit.Enabled = false;
                txtTransport.Enabled = false;
                txtReqDate.Enabled = false;
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                txtRegion.Enabled = false;
 }
        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ?(Request.QueryString["flag"]) : "");
        }

        private long GetTravelOID()
        {
            return (Request.QueryString["TravelOID"] != null ? long.Parse(Request.QueryString["TravelOID"]) : 0);
        }

        private void getData()
        {
            string TravelId = GetTravelOID().ToString();
            DataTable dt = _clsDao.getTable("select  e.FIRST_NAME +' '+e.MIDDLE_NAME +' '+e.LAST_NAME +'|'+ CAST(e.EMPLOYEE_ID AS VARCHAR) [reqBy], CONVERT(varchar,travelorderReqDate,101) travelorderReqDate, CONVERT(varchar,fromDate,101) fromDate,"
                            +" CONVERT(varchar,toDate,101) toDate, placeOfVisit, purposeOfVisit,convert(varchar,approveFrom,101)approveFrom,convert(varchar,approveTo,101) approveTo,"
                            +" s.DETAIL_TITLE transportation,s1.DETAIL_DESC region,region [regionId],placeOfVisit,dbo.ShowDecimal(advance)advance"
                            +" from travelOrder t"
                            +" inner join StaticDataDetail s"
                            +"  on t.transportation = s.ROWID"
                            +"  inner join StaticDataDetail s1"
                            +"  on t.region = s1.ROWID"
                            +" inner join employee e on e.EMPLOYEE_ID = t.reqBy"
                            +"  where t.travelOrderId ="+ GetTravelOID().ToString());
           

            foreach (DataRow dr in dt.Rows)
            {
                txtReqBy.Text           =       dr["reqBy"].ToString();
                txtPlaceOfVisit.Text    =       dr["placeOfVisit"].ToString();
                txtPurposeOfVisit.Text  =       dr["purposeOfVisit"].ToString();
                txtTransport.Text       =       dr["transportation"].ToString();
                txtRegion.Text          =       dr["region"].ToString();
                txtReqDate.Text         =       dr["travelorderReqDate"].ToString();
                txtFromDate.Text        =       dr["fromDate"].ToString();
                txtToDate.Text          =       dr["toDate"].ToString();
                txtReqAdv.Text          =       dr["advance"].ToString();
                txtApproveAdv.Text      =       dr["advance"].ToString();
                if (GetFlag().ToString() == "v" || GetFlag().ToString() == "a")
                {

                    txtApproveFrom.Text = dr["approveFrom"].ToString();
                    txtApprovTo.Text = dr["approveTo"].ToString();
                }
                else
                {
                    txtApproveFrom.Text = dr["fromDate"].ToString();
                    txtApprovTo.Text = dr["toDate"].ToString();
                    TimeSpan TS = (DateTime.Parse(txtApprovTo.Text) - DateTime.Parse(txtApproveFrom.Text));
                    txtDays.Text = (TS.Days +1).ToString();
                }
                hdnRegion.Value = dr["regionId"].ToString();
                

            }
        }

        private void PopulateGrid()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt1 = _travelDao.ShowAllowanceById(GetTravelOID().ToString());

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

        protected void BtnRecommend_Click(object sender, EventArgs e)
        {

            if (txtRemarks.Text == "")
            {
                LblMsg.Text = "Please enter remarks";
            }
            if (BtnRecommend.Text == "Approve")
            {
                _clsDao.runSQL("Exec [proc_travelOrder] @flag='fa',@finalRemarks=" + filterstring(txtRemarks.Text) + ","
                + "@approveFrom =" +filterstring(txtApproveFrom.Text) + ",@approveTo=" +filterstring(txtApprovTo.Text) + ",@travelOrderId=" + GetTravelOID().ToString() + "");
                Response.Redirect("/EmployeeMovement/TravelOrder/ApproveTO.aspx");
            }
            else if (BtnRecommend.Text == "Forward")
            {
                string [] splitEmpId   = txtFinalApprove.Text.Split('|');
                string empId  = splitEmpId[1];


                _clsDao.runSQL("Exec [proc_travelOrder] @flag='ha',@hrRemarks=" + filterstring(txtRemarks.Text) + ","
                + "@approveByHr =" + filterstring(ReadSession().Emp_Id.ToString()) + ",@finalApproveBy =" + filterstring(empId) + ","
                + " @approveFrom =" +filterstring(txtApproveFrom.Text) + ",@approveTo=" +filterstring(txtApprovTo.Text) + ",@travelOrderId=" + GetTravelOID().ToString() + ",@ccList=" + filterstring(HiddenFieldEmpEmail.Value));
                Response.Redirect("/EmployeeMovement/TravelOrder/ListHrApprove.aspx");
            }
            else
            {
                _clsDao.runSQL("Exec [proc_travelOrder] @flag='ra',@recommendedRemarks=" + filterstring(txtRemarks.Text) + ","
                +"@approveFrom ="+filterstring(txtApproveFrom.Text)+",@approveTo="+filterstring(txtApprovTo.Text)+" ,@travelOrderId=" + GetTravelOID().ToString() + "");
                Response.Redirect("/EmployeeMovement/TravelOrder/ListTO.aspx");
            }
           		 
            
        }

 

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAddAllowance();
        }
        private void OnAddAllowance()
        {
            string Msg = _travelDao.OnAddAllowance(ddlAllowance.Text, txtPerDay.Text,txtDays.Text,GetTravelOID().ToString(),"",txtCurrency.Text,hdnRateId.Value);
            PopulateGrid();
            lblAllowanceMsg.Text = Msg;
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _travelDao.OnDelete(HdnTravelOrderId.Value);
            lblAllowanceMsg.Text = msg;
            PopulateGrid();
        }

        protected void ddlAllowance_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arryEmpId = txtReqBy.Text.Split('|');
            string empId = arryEmpId[1];
            DataTable dt = _travelDao.FindRateAllownce(ddlAllowance.Text,_travelDao.GetPositionId(empId),hdnRegion.Value);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
            {
                txtPerDay.Text ="";

                txtCurrency.Text = "";
                return;
            
            }
            dr = dt.Rows[0];

            txtPerDay.Text = dr["rate"].ToString();
            txtCurrency.Text = dr["currency"].ToString();
            hdnRateId.Value = dr["travelRateId"].ToString();
        }

       

    }
}
