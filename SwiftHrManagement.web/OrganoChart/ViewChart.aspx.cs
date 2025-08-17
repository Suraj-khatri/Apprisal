using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.OrganoChart
{
    public partial class ViewChart : System.Web.UI.Page
    {
        clsDAO _clsdao = null;
        public ViewChart()
        {
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PopulateRootLevel();
        }
        private void PopulateRootLevel()
        {
            DataTable dt = _clsdao.getTable("exec ProcExecuteOrganizationChart 'r'");
            PopulateNodes(dt, TvItem.Nodes);
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
            DataTable dt = _clsdao.getTable("Exec ProcExecuteOrganizationChart 's','" + parentid + "'");
            PopulateNodes(dt, parentNode.ChildNodes);
        }
        protected void TvItem_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
        }

        protected void TvItem_SelectedNodeChanged(object sender, EventArgs e)
        {
            string TVStr = TvItem.SelectedNode.Text.Replace("<img style=\"border-width:0pt;\" src=\"../../Images/iconFolderClosed.gif\">", "");

            lblProductName.InnerText = TVStr;
            lblProductCode.InnerText = TvItem.SelectedNode.Value;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNodesRecursive(TvItem);
            SelectNodesRecursive(txtNodeSearch.Text, TvItem);
        }

        public static void SelectNodesRecursive(string searchValue, TreeView Tv)
        {
            foreach (TreeNode tn in Tv.Nodes)
            {

                int posText = tn.Text.ToLower().IndexOf(searchValue.ToLower(), 0);

                if (posText > 0)
                {
                    tn.Expand();
                    tn.Select();
                    break;
                }

                if (tn.ChildNodes.Count > 0)
                {
                    foreach (TreeNode cTn in tn.ChildNodes)
                    {
                        int a = SelectChildrenRecursive(cTn, searchValue);
                        if (a == 1)
                        {
                            tn.Expand();
                            tn.Select();
                        }

                    }
                }
            }
        }
        private static int SelectChildrenRecursive(TreeNode tn, string searchValue)
        {
            int posText = tn.Text.ToLower().IndexOf(searchValue.ToLower(), 0);

            if (posText > 0)
            {
                tn.Expand();
                tn.Select();
                return 1;
            }

            if (tn.ChildNodes.Count > 0)
            {
                foreach (TreeNode tnC in tn.ChildNodes)
                {
                    int a = SelectChildrenRecursive(tnC, searchValue);
                    if (a == 1)
                    {
                        tn.Expand();
                        return 1;
                    }
                }

            }
            return 0;
        }

        public void LoadNodesRecursive(TreeView Tv)
        {
            foreach (TreeNode tn in Tv.Nodes)
            {
                tn.Expand();
                tn.Select();
                tn.Collapse();

                if (tn.ChildNodes.Count > 0)
                {
                    foreach (TreeNode cTn in tn.ChildNodes)
                    {

                        LoadChildrenRecursive(cTn);

                        tn.Expand();
                        tn.Select();
                        tn.Collapse();

                    }
                }
            }
        }
        public void LoadChildrenRecursive(TreeNode tn)
        {

            tn.Expand();
            tn.Select();
            tn.Collapse();

            if (tn.ChildNodes.Count > 0)
            {
                foreach (TreeNode tnC in tn.ChildNodes)
                {
                    LoadChildrenRecursive(tnC);

                    tn.Expand();
                    tn.Select();
                    tn.Collapse();
                }
            }
        }



    }
}
