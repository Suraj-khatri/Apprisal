using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.web.Library;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppprialCommitteeReview
{
    public partial class AddMemberType : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = null;
        PerformanceAppraisalDAO _obj = new PerformanceAppraisalDAO();
        public AddMemberType()
        {
            _roleMenuDao = new RoleMenuDAOInv();    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetId() != "")
                {
                    addType.Visible = false;
                    addReviewPos.Visible = true;
                    PopulateDdl();
                }
                if (GetEditId() != "")
                {
                    PopulateData();
                }
            }          
        }

        private void PopulateData()
        {
           string id = GetEditId();
           var dt = _obj.GetMemberType(id);
           if (dt.Rows.Count <= 0)
               return;
           else
           {
               reviewType.Text = dt.Rows[0]["typ"].ToString();
               reviewDesc.Text = dt.Rows[0]["description"].ToString();
               ddlActive.SelectedValue = dt.Rows[0]["isActive"].ToString();
               ddlActive.Text = ddlActive.SelectedValue;
               btnAdd.Visible = false;
               btnUpdate.Visible = true;
           }
        }


        private void PopulateDdl()
        {           
            string sql = "EXEC proc_AppriasalReviewDetails @flag='sl',@type_id='4'";
            _clsDao.setDDL(ref ddlPosition, sql, "ROWID", "DETAIL_TITLE", "", "select");
            PopulateLabel();
            GetPositionTBL();
        }

        private void PopulateLabel()
        {
            txtReview.Text =  _clsDao.GetSingleresult("select reviewType from appriasalReviewCommittee with(nolock) where rowId='" + GetId() + "' ");
            txtReview.Enabled = false;
        }
        private string GetEditId()
        {
            string editQ = GetStatic.ReadQueryString("editId", "");
            return editQ;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            OnSave();
        }        
        private void OnSave()
        {
            string rewType = reviewType.Text;
            string revdesc = reviewDesc.Text;
            string active = ddlActive.SelectedValue;
            string user = ReadSession().Emp_Id.ToString();
            var dt = _obj.saveReviewType(rewType, revdesc, "", "", user,active);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                Response.Redirect("ReviewCommitteeList.aspx");
                return;
            }
            else
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }
        }

        private string GetId()
        {
            string query = GetStatic.ReadQueryString("Id", "");
            return query;
        }
        private void GetPositionTBL()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = null;
            dt = _obj.ExecuteDataset(@"SELECT ap.rowid,sdd.detail_title as Position FROM appriasalReviewPosition ap WITH(NOLOCK) inner join StaticDataDetail sdd on sdd.rowId=ap.position
                                             WHERE ap.memberType='" + GetId() + "' order by ap.rowId asc").Tables[0];            
         
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th align=\"left\">S.N</th>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            int a = 1;
            foreach (DataRow dr in dt.Rows)
            {                
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">"+a+"</td>");
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href =\"#\" onclick=\"deletePos('" + dr[0].ToString() + "')\" style=\"cursor:pointer;\"><i class=\"fa fa-times\"></i></span></a></td>");
                    //str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\"  href =\"#\" onclick=\"deletePos('" + dr[0].ToString() + "')\"><i class=\"fa fa-times\" aria-hidden=\"true\"></a></a></td>");
                }              
                str.Append("</tr>");
                a= a + 1;
            }
           
            str.Append("</table>");
            rptPosition.InnerHtml = str.ToString();
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var rev = GetId();
            var pos=ddlPosition.SelectedValue;
            var user = ReadSession().Emp_Id.ToString();
            var dt = _obj.saveReviewPos(rev,pos,user);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetPositionTBL();
                return;
            }
            else
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }           
        }        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var id = HiddenField2.Value;
            var dt = _obj.deletePos(id);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetPositionTBL();
                return;
            }
            else
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }    
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string rewType = reviewType.Text;
            string revdesc = reviewDesc.Text;
            string active = ddlActive.SelectedValue;
            string user = ReadSession().Emp_Id.ToString();
            var dt = _obj.updateReviewType(rewType, revdesc, GetEditId(), user, active);
            if (dt.Rows.Count <= 0)
                return;
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                Response.Redirect("ReviewCommitteeList.aspx");
                return;
            }
            else
            {
                GetStatic.AlertMessage(this, dt.Rows[0][1].ToString());
                return;
            }
        }
    }
}