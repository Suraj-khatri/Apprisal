using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.DomainInv;
using System.Data;
using System.Text;
using System.IO;

namespace SwiftHrManagement.web.TravelOrder.TicketPersonal
{
    public partial class ManageTicketPersonal : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        clsDAO _clsdao = new clsDAO();
        StaticDataTypeCore _dataTypeCore = new StaticDataTypeCore();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 286) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetId() > 0)
                {
                    populateData();
                }
                dt = new DataTable("TiEmpList");
                dt.Columns.Add("Employee Id");
                dt.Columns.Add("Employee Name");
                Session["ss"] = dt;
                TxtTypeId.Text = GetTypeId().ToString();
                TxtDataType.Text = "Ticket Personal List";

            }
        }
        
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private long GetTypeId()
        {
            return (Request.QueryString["TypeID"] != null ? long.Parse(Request.QueryString["TypeID"].ToString()) : 0);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string msg;
            if (GetId() > 0)
            {
                var sql = "EXEC proc_TicketList @flag='u'";
                sql += ",@user=" + filterstring(ReadSession().UserId);
                sql += ",@rowId=" + filterstring(GetId().ToString());
                sql += ",@detailTitle=" + filterstring(EmpInfo());
                sql += ",@detailDesc=" + getEmpIdfromInfo(txtEmpName.Text);
                msg = _clsdao.GetSingleresult(sql);
            }
            else
            {
                var sql = "EXEC proc_TicketList @flag='i'";
                sql += ",@typeId=" + filterstring(GetTypeId().ToString());
                sql += ",@user=" + filterstring(ReadSession().UserId);
                sql += ",@xmldata=" + filterstring(convertToXml());
                msg = _clsdao.GetSingleresult(sql);
            }
            
            if (msg.Contains("Success"))
            {
                Response.Redirect("ListTicketPersonal.aspx?id=206");
            }
            else
            {
                LblMsg.Text = "Error in operation";
            }
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           dt = (DataTable)Session["ss"];
           //int num = dt.Rows.Count;
           DataRow dr = dt.NewRow();
           //dr["Id"] = num+1;
           dr["Employee Id"] = getEmpIdfromInfo(txtEmpName.Text);
           dr["Employee Name"] = EmpInfo();
           dt.Rows.Add(dr);
           dispalyGrid(dt);
           

        }

        private string  EmpInfo()
        {
            string[] empName = txtEmpName.Text.Split('|');
            return empName[0];
        }

        private void dispalyGrid(DataTable dt)
        {

            if (dt==null || dt.Rows.Count == 0)
            {
                rptEmp.InnerHtml = "";
                return;
            }
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            str.Append("<tr>");
            str.Append("<th align=\"left\" >Id</th>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\" ><b>" + (row + 1) + "</b></td>");
                
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\" ><b>" + dt.Rows[row][i] + "</b></td>");
                }
                str.Append("<td align=\"left\"><img OnClick = 'DeleteEmp(" + (row+1) + ")' class = \"showHand\" border = \"0\" title = \"Delete Notification\" src=\"../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptEmp.InnerHtml = str.ToString();
        }

        protected void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            dt = (DataTable)Session["ss"];
            int a =Convert.ToInt32( hdnEmpId.Value);
            a = a - 1;
            dt.Rows.RemoveAt(a);
            dispalyGrid(dt);
        }

        private string convertToXml()
        {
            dt = (DataTable)Session["ss"];
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw);
                result = sw.ToString();
            }
            return result;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var sql = " Exec proc_TicketList @flag='d',@rowid=" + GetId();
            _clsdao.runSQL(sql);
            Response.Redirect("ListTicketPersonal.aspx?id=206");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListTicketPersonal.aspx?id=206");
        }

        private void populateData()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("EXEC proc_TicketList @flag='s', @rowId=" + filterstring(GetId().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            txtEmpName.Text = dr["DETAIL_TITLE"].ToString();
            btnAdd.Visible = false;
        }


    }
}

