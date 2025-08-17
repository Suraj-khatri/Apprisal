using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LFAHistoryPost : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public LFAHistoryPost()
        {
            CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            
        }
        private string GetTax()
        {
            return (Request.QueryString["tax"] != null ? (Request.QueryString["tax"]) : "");
        }
        private string GetDate()
        {
            return (Request.QueryString["date"] != null ? (Request.QueryString["date"]) : "");
        }
        private string GetLFAId()
        {
            return (Request.QueryString["ID"] != null ? (Request.QueryString["ID"]) : "");
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string query="fromdate=" + Request.QueryString["fromdate"].ToString() + "&todate=" + Request.QueryString["todate"].ToString() + "&empid=" + Request.QueryString["empid"].ToString();
            //Response.Write("<br>" + "fromdate=" + Request.QueryString["fromdate"].ToString() + "&todate=" + Request.QueryString["todate"].ToString() + "&empid=" + Request.QueryString["empid"].ToString());
            //Response.Write("Exec procPayLFA @flag='u',@rowid=" + filterstring(GetLFAId()) + ",@tax=" + filterstring(GetTax()) + ",@pDate=" + filterstring(GetDate())+",@user="+ReadSession().AdminId.ToString());
            CLsDAo.runSQL("Exec procPayLFA @flag='u',@rowid=" + filterstring(GetLFAId())+",@tax="+ filterstring(GetTax())+",@pDate="+ filterstring(GetDate()));
            Response.Redirect("LFAHistoryReport.aspx?" + query);
           
        }
    }
}
