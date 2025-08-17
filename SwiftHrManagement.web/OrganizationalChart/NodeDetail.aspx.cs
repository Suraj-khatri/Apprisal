using System;
using System.Text;
using System.Data;


namespace SwiftHrManagement.web.OrganizationalChart
{
    public partial class NodeDetail : BasePage {
        ClsDAOInv _clsdao = null;

    public NodeDetail()
        {
            _clsdao = new ClsDAOInv();
        }

    private string GetNodeId()
    {
        return ReadQueryString("nodeId", "");
    }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                GetNodeDetail();
            }
        }
        private void GetNodeDetail()
        {
            var query = "Exec proc_manageOrgChart @flag='getNodeDetail'";
            query += ", @user=" + _clsdao.filterstring(ReadSession().Emp_Id.ToString());
            query += ", @NodeId=" + _clsdao.filterstring(GetNodeId());
            DataTable myData = _clsdao.getTable(query);
            var table = DataTableToHTML(ref myData, true);
            chart_div.InnerHtml = table;
        }
    }
}