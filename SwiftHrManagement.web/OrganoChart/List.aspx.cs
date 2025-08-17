using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.OrganoChart
{
    public partial class List : BasePage
    {
        clsDAO _clsdao = null;
        public List()
        {
            _clsdao = new clsDAO();
        }
        private void PopulateRootLevel()
        {
            DataTable dt = _clsdao.getTable("select id,'<div class=unitNode onmouseover=\"javascript:this.className = ''unitNodeHover'';\" onmouseout=\"javascript:this.className = ''unitNode'';\">'+unit_name+'</div>' as unit_name, (select count(*) FROM OrgChart WHERE id = oc.id) 'childnodecount' from OrgChart oc where linked_id is null");
            PopulateNodes(dt, TVChart.Nodes);
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["unit_name"].ToString();
                tn.Value = dr["id"].ToString();                
                nodes.Add(tn);
                tn.PopulateOnDemand = ((int)(dr["childnodecount"]) > 0);
            }
        }
        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            DataTable dt = _clsdao.getTable("Exec ProcExecuteOrganizationChart 'i','" + parentid + "'");
            PopulateNodes(dt, parentNode.ChildNodes);
        }
        protected void TVChart_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);   
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PopulateRootLevel();
        }
        protected void TVChart_SelectedNodeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
