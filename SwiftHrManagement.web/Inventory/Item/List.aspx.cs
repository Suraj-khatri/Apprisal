using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Item
{
    public partial class List : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public List()
        {
            _clsdao = new ClsDAOInv();
        }
        private void PopulateRootLevel()
        {
            DataTable dt = _clsdao.getTable("exec [proc_In_Itemsetup] 'r'");
            PopulateNodes(dt, TvItem.Nodes);
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["item_name"].ToString();
                tn.Value = dr["id"].ToString();
                nodes.Add(tn);
                tn.PopulateOnDemand = ((int)(dr["childnodecount"]) > 0);
            }
        }
        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            DataTable dt = _clsdao.getTable("exec [proc_In_Itemsetup] 's',@parentid='" + parentid + "'");
            PopulateNodes(dt, parentNode.ChildNodes);
        }
        protected void TvItem_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 107) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateRootLevel();
            }
        }
     
        protected void TvItem_SelectedNodeChanged(object sender, EventArgs e)
        {

            string IsProduct = "";

            DataTable dt = _clsdao.getTable("exec proc_In_Itemsetup 'c',@id='" + TvItem.SelectedNode.Value + "'");
           
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                IsProduct = dr["is_product"].ToString();
                lblProductID.InnerText = dr["id"].ToString();
   
            }

            string TVStr = TvItem.SelectedNode.Text.Replace("<img style=\"border-width: 0pt;\" alt=\"\" src=\"../../Images/iconFolderClosed.gif\">","");
            TVStr = TVStr.Replace("<img style=\"border-width: 0pt;\" alt=\"\" src=\"../../Images/iconInfo.gif\">", "");


            lblProductName.InnerText = TVStr;
            lblProductCode.InnerText = TvItem.SelectedNode.Value;
            //lblProductID.InnerText = "";


            if (IsProduct == "True" )
            {
                lblIsProduct.InnerText = "Product";
            }
            else
            {
                lblIsProduct.InnerText = "Group";
            }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNodesRecursive(TvItem);
            SelectNodesRecursive(txtNodeSearch.Text, TvItem);
        } 

    }
}
