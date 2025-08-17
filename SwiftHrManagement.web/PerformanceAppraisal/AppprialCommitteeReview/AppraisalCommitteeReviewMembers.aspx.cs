using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppprialCommitteeReview
{
    public partial class AppprialCommitteeReviewMembers : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = null;
        PerformanceAppraisalDAO _obj = new PerformanceAppraisalDAO();
        string maxPos ="";
        string minPos ="";
        public AppprialCommitteeReviewMembers()
        {
            _roleMenuDao = new RoleMenuDAOInv();    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (_roleMenuDao.hasAccess(ReadSession().AdminId, 0) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}

                PopulateLabel();
                PopulateDdl();
                SetYearStartEndDate();
                if (GetId() != "0" && GetEditId()!="0")
                PopulateData();
            }
        }

        private void PopulateData()
        {
           string id = GetEditId();
           var dt = _obj.GetEditData(id);
           if (dt.Rows.Count <= 0)
               return;
           else
           {               
               reviewType.Text = dt.Rows[0]["typ"].ToString();              
               lblEmpName.Text = dt.Rows[0]["name"].ToString();
               txtFromDate.Text = dt.Rows[0]["frmMem"].ToString();
               txtToDate.Text = dt.Rows[0]["ToMem"].ToString();
               ddlRater.SelectedValue = dt.Rows[0]["isFirstRater"].ToString();
               btnUpdate.Visible = true;
               btnAdd.Visible = false;
           }
        }


        private void SetYearStartEndDate()
        {
            PerformanceAppraisalDAO _performanceAppDao = new PerformanceAppraisalDAO();
            var dr = _performanceAppDao.getYearStartEndDate();
            if (dr == null)
                return;

            txtFromDate.Text = dr["en_year_start_date"].ToString();
            txtToDate.Text = dr["en_year_end_date"].ToString();
        }

        private void PopulateDdl()
        {          
            string id = GetId();           
            reviewType.Enabled = false;
            string sql = "EXEC proc_AppriasalReviewDetails @flag='sl',@type_id='4'";
            _clsDao.setDDL(ref reviewDdlType, sql, "ROWID", "DETAIL_TITLE", "", "select");            
        }
        private void PopulateLabel()
        {
            var dt1 = _clsDao.ExecuteDataset("select reviewType,maxPosition,minPosition from appriasalReviewCommittee with(nolock) where rowId='" + GetId() + "' ").Tables[0];
            if (dt1.Rows.Count <= 0)
                return;

            reviewType.Text = dt1.Rows[0][0].ToString();
            maxPos = dt1.Rows[0][1].ToString();
            minPos = dt1.Rows[0][2].ToString();
        }

        private string GetEditId()
        {
            string editQ = GetStatic.ReadQueryString("editId", "");
            return editQ;
        }

         private string GetId()
        {
            string query = GetStatic.ReadQueryString("Id", "");
            return query;
        }
        
        //protected void reviewDdlType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var Id = reviewDdlType.SelectedValue;
        //    getEmpName(Id);
        //}

        //private void getEmpName(string typeId)
        //{
           
        //    string sql = "EXEC proc_AppriasalReviewDetails @flag='sn',@type_id='" + typeId + "'";
        //    _clsDao.setDDL(ref memberNameDdl, sql, "EMPLOYEE_ID", "NAME", "", "select");     
        //}

      

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string reviewType = GetId();
            string memPosition = reviewDdlType.SelectedValue;
            string memName = "";
            if (String.IsNullOrEmpty(lblEmpName.Text))
            {
                GetStatic.AlertMessage(this, "Member is required !!!.");
                    return;
            }
            else
                memName = getEmpIdfromInfo(lblEmpName.Text);

            string frmDate = txtFromDate.Text;
            string toDate = txtToDate.Text;
            string user = ReadSession().Emp_Id.ToString();
            string isRater = ddlRater.SelectedValue;
            var dt = _obj.AddCommitteeMamber(reviewType, memPosition, memName, frmDate, toDate, user, isRater);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                Response.Redirect("MemberList.aspx?Id=" + GetId() + "");
                return;
            }
            else {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string rowId = GetEditId();            
            string memPosition = reviewDdlType.SelectedValue;
            string memName = getEmpIdfromInfo(lblEmpName.Text);
            string frmDate = txtFromDate.Text;
            string toDate = txtToDate.Text;
            string user = ReadSession().Emp_Id.ToString();
            string isRater = ddlRater.SelectedValue;
            var dt = _obj.UpdateCommitteeMamber(rowId, memPosition, memName, frmDate, toDate, user, isRater);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                Response.Redirect("MemberList.aspx?Id=" + GetId() + "");
                return;
            }
            else
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }
        }
        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
        }
        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }       
    }
}