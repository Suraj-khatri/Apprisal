using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace SwiftHrManagement.web.OrganizationalChart
{

    public partial class Manage : BasePage
    {
        ClsDAOInv _clsdao = null;

        public Manage()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqMethod = Request.Form["MethodName"];
            if (!Page.IsPostBack)
            {
                #region Ajax methods
                switch (reqMethod)
                {
                    case "data":
                        GetData();
                        break;
                    case "loadOrgDdl":
                        GetDdlData();
                        break;
                    case "ddlDrilDown":
                        GetDrillDownData();
                        break;
                    case "save":
                        SaveData();
                        break;
                }
                #endregion
            }
        }

        private void GetData()
        {
            var query = "Exec proc_manageOrgChart @flag='createChart'";
            query += ", @user=" + _clsdao.filterstring(ReadSession().Emp_Id.ToString());
            DataTable myData = _clsdao.getTable(query);
            List<OrganizationChart> g = new List<OrganizationChart>();

            foreach (DataRow row in myData.Rows)
            {
                g.Add(new OrganizationChart(
                         row["nodeId"].ToString()
                        , row["parentNodeId"].ToString()
                        , row["groupId"].ToString()
                        , row["nodeType"].ToString()
                        , row["nodeText"].ToString()
                        , row["nodeTooltip"].ToString() 
                        , row["isLeaf"].ToString()
                    ));
            }

            var t = new JavaScriptSerializer().Serialize(g);
            var json = new JavaScriptSerializer().Serialize(g);
            Response.Write(json);
            Response.End();
        }

        private void GetDdlData()
        {
            
            var query = "Exec proc_manageOrgChart @flag='loadDdl'";
            query += ", @param = " + filterstring(Request.Form["id"]);
            query += ", @user=" + filterstring(ReadSession().Emp_Id.ToString());
            query += ", @IsFristNode=" + filterstring(Request.Form["IsFristNode"]);
            query += ", @nodeId=" + filterstring(Request.Form["NodeId"]);

            DataTable myData = _clsdao.getTable(query);
            List<Options> g = new List<Options>();

            foreach (DataRow row in myData.Rows){
                g.Add(new Options(row["value"].ToString(), row["text"].ToString()));
            }

            var json = new JavaScriptSerializer().Serialize(g);
            Response.Write(json);
            Response.End();
        }

        private void GetDrillDownData()
        {
            string param = Request.Form["param"];
            var value = Request.Form["value"];

            var query = "Exec proc_manageOrgChart @flag='ddl'";
            query += ", @user=" + _clsdao.filterstring(ReadSession().Emp_Id.ToString());
            query += " , @param = " + _clsdao.filterstring(param);
            query += " , @value = " + _clsdao.filterstring(value);
            
            DataTable myData = _clsdao.getTable(query);
            List<Options> g = new List<Options>();

            foreach (DataRow row in myData.Rows)
            {
                g.Add(new Options(row["value"].ToString(), row["text"].ToString()));
            }

            var t = new JavaScriptSerializer().Serialize(g);
            var json = new JavaScriptSerializer().Serialize(g);
            Response.Write(json);
            Response.End();
        }

        private void SaveData()
        {
            var query = "Exec proc_manageOrgChart @flag='saveNode'";
            query += ", @user=" + filterstring(ReadSession().Emp_Id.ToString());
            query += ", @ParentNodeId = " + filterstring(Request.Form["ParentNodeId"]);
            query += ", @NodeId = " + filterstring(Request.Form["NodeId"]);
            query += ", @GroupId = " + filterstring(Request.Form["GroupId"]);
            query += ", @NodeType = " + filterstring(Request.Form["NodeType"]);          
            query += ", @ParentType = " + filterstring(Request.Form["ParentType"]);
            query += ", @Parent = " + filterstring(Request.Form["Parent"]);
            query += ", @ChildType = " + filterstring(Request.Form["ChildType"]);
            query += ", @Child = " + filterstring(Request.Form["Child"]);
            DataRow row = _clsdao.getTable(query).Rows[0];
            var res = new Result();
            res.SetResult(row[0].ToString(), row[1].ToString(), row[2].ToString());

            var json = new JavaScriptSerializer().Serialize(res);
            Response.Write(json);
            Response.End();
        }

       
    }

    public class OrganizationChart
    {
        public string NodeId { get; set; }
        public string ParentNodeId { get; set; }
        public string GroupId { get; set; }
        public string NodeType { get; set; }
        public string NodeText { get; set; }
        public string NodeTooltip { get; set; }
        public bool IsLeaf { get; set; }

        public OrganizationChart(string node, string parentNode, string groupId, string nodeType, string nodeText, string nodeToolTip, string isLeaf)
        {
            NodeId = node;
            ParentNodeId = parentNode;
            GroupId = groupId;
            NodeType = nodeType;
            NodeText = nodeText;
            NodeTooltip = nodeToolTip;
            IsLeaf = isLeaf.ToLower().Equals("true") ? true : false;
        }
    }

    public class Options
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public Options(string value, string text)
        {
            Value = value;
            Text = text;
        }
    }

    public class Result
    {
        public string ErrorCode { get; set; }
        public string Msg { get; set; }
        public string Id { get; set; }

        public void SetResult(string errorCode, string msg, string id)
        {
            ErrorCode = errorCode;
            Msg = msg;
            Id = id;
        }
    }
}