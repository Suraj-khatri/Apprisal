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

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class ManageReqTO : BasePage
    {
        string hdnEmpId = "";
        TravelOrderDao _travelOrder = null;
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        long days;
        string empTypeId = "0";
        public ManageReqTO()
        {
            this._travelOrder = new TravelOrderDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 171) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (_travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "18")
                {
                    showReqText1.Visible = true;
                }
                else
                {
                    ShowReqText.Visible = true;
                    txtReqestedBy.Text = _travelOrder.FindEmpByEmpId(ReadSession().Emp_Id.ToString());
                    string [] myArrayEmpId = txtReqestedBy.Text.Split('|');
                    hdnEmployeeId.Value = myArrayEmpId[1];
                    txtReqestedBy.Enabled = false;
                }
                
                setDDL();
                //DisplayAddAllowance();
                DisplayAddAllowance();

            }

         
                LblMsg.Text = "";
                txtToDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                txtToDate.Attributes.Add("OnChange", "DateDifference();");
                txtPerDay.Attributes.Add("OnBlur", "TotalAllowance();");
                txtReqAdv.Attributes.Add("OnBlur", "checknumber(this);");
                txtFromDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
                txtReqDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
               
                
                
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
            Reset();
        }
     
        private void OnSave()
        {
      
            string msg = _travelOrder.OnSave(ReadSession().Branch_Id.ToString(), ReadSession().Department
                        , _travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? txtHndEmpId.Text  :  filterstring(hdnEmployeeId.Value)
                        , txtReqDate.Text, txtPlaceOfVisit.Text, txtPurposeOfVisit.Text, ddlTransport.Text, txtFromDate.Text
                        ,txtToDate.Text,ddlRecommend.Text,ReadSession().Sessionid,txtRemarks.Text,txtReqAdv.Text,ddlRegion.Text);
           LblMsg.Text = msg;
           DisplayAddAllowance();
        }

        private string GetEmpTypeId()
        {
            if ((_travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? hdnEmpHrId.Value : filterstring(hdnEmployeeId.Value)) == "")
            {
                return empTypeId;
            }
            else
             return   empTypeId = _travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? hdnEmpHrId.Value : filterstring(hdnEmployeeId.Value);
        }

        private void setDDL()
        {


            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 64";
            _clsDao.setDDL(ref ddlAllowance, sql, "ROWID", "DETAIL_TITLE", "", "Select");

            var sql1 = "SELECT SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[SUPERVISOR_NAME] FROM SuperVisroAssignment WHERE EMP =" + GetEmpTypeId() + " and SUPERVISOR_TYPE ='i' and record_status = 'y'";
            _clsDao.setDDL(ref ddlRecommend, sql1, "SUPERVISOR", "SUPERVISOR_NAME", "", "Select");

            var sql2 = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 65";
            _clsDao.setDDL(ref ddlTransport, sql2, "ROWID", "DETAIL_TITLE", "", "Select");

            var sql3 = "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID = 72";
            _clsDao.setDDL(ref ddlRegion, sql3, "ROWID", "DETAIL_TITLE", "", "Select");

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAddAllowance();
        }

        private void OnAddAllowance()
        {
            string Msg = _travelOrder.OnAddAllowance(ddlAllowance.Text,txtPerDay.Text,txtDays.Text,"",ReadSession().Sessionid,txtCurrency.Text,hdnRateId.Value);
            DisplayAddAllowance();
            lblShowALlow.Text = Msg;
            lblShowALlow.ForeColor = System.Drawing.Color.Green;
        }

        private void DisplayAddAllowance()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            DataTable dt = _travelOrder.DisplayAllowanceInfo(ReadSession().Sessionid);
            if (dt.Rows.Count <= 0)
            {
                rpt.InnerText = "Record does not Exist";
                ddlRegion.Enabled = true;
                return;
            }
            ddlRegion.Enabled = false;
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
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }

    
        protected long CalculateDays()
        {            
            if (txtFromDate.Text != "" || txtToDate.Text != "")
            {
                TimeSpan ts = DateTime.Parse(txtToDate.Text) - DateTime.Parse(txtFromDate.Text);
                 days = ts.Days - 2;
                 
            }
            return days;
        }
        private void Reset()
        {           
            ddlRegion.Text              = "";
            txtPurposeOfVisit.Text      = "";
            ddlTransport.Text           = "";
            txtReqDate.Text             = "";
            txtFromDate.Text            = "";
            txtToDate.Text              = "";
            ddlAllowance.Text           = "";
            ddlRecommend.Text           = "";
            txtPerDay.Text              = "";
            txtTotal.Text               = "";
            txtReqAdv.Text              = "";
            ddlAllowance.Text           = "";
            txtDays.Text                = "";
            txtCurrency.Text            = ""; 
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
          string msg =   _travelOrder.OnDelete(HdnTravelOrderId.Value);
          LblMsg.Text = msg;
          DisplayAddAllowance();
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            DateTime from = DateTime.Parse(txtFromDate.Text);
            DateTime to = DateTime.Parse(txtToDate.Text);
            if (from > to)
            {
                lblToDate.Text  = "Enter valid date";
            }
        }        

        protected void ddlAllowance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegion.Text == "")
            {
                lblRegionMsg.Text = "Required!";
                return;
            }
            DataTable dt= _travelOrder.FindRateAllownce(ddlAllowance.Text, _travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM"  ? _travelOrder.GetPositionId(txtHndEmpId.Text) : ReadSession().Designation, ddlRegion.Text);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
            {
                txtPerDay.Text = "";

                txtCurrency.Text = "";
                return;
            }
            dr = dt.Rows[0]; 
           
            txtPerDay.Text       = dr["rate"].ToString();
            txtCurrency.Text     = dr["currency"].ToString();
            hdnRateId.Value      = dr["travelRateId"].ToString();
        }       

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _travelOrder.FindRateAllownce(ddlAllowance.Text == "" ? "0" : ddlAllowance.Text, _travelOrder.FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? txtHndEmpId.Text : ReadSession().Designation, ddlRegion.Text);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
            {
                txtPerDay.Text = "";

                txtCurrency.Text = "";
                return;
            }
            dr = dt.Rows[0];
            txtPerDay.Text = dr["rate"].ToString();
            txtCurrency.Text = dr["currency"].ToString();
        }

        protected void txtReqBy_TextChanged(object sender, EventArgs e)
        {
            var sql1 = "SELECT SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[SUPERVISOR_NAME] FROM SuperVisroAssignment WHERE EMP =" + txtHndEmpId.Text+ " and SUPERVISOR_TYPE ='i' and record_status = 'y'";
            _clsDao.setDDL(ref ddlRecommend, sql1, "SUPERVISOR", "SUPERVISOR_NAME", "", "Select");
        }

    }
}
