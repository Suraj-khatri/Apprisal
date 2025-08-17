using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.AssetManagement
{
    public partial class ManageApproval : BasePage
    {
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageApproval()
        {
            _clsDao = new ClsDAOInv();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 193) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    ShotDataById();
                }
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void ShotDataById()
        {
            DataTable dt = _clsDao.getTable("select rowId,CONVERT(VARCHAR,createdDate,107) AS createdDate,dbo.GetEmployeeFullNameOfId(createdBy) as createdBy,"
            +" description,upper(modType) modType,tableName,identifierField,dataid from changesApprovalQueue with(nolock) where rowId=" + GetId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                createdDate.Text = dr["createdDate"].ToString();
                createdBy.Text = dr["createdBy"].ToString();
                tableName.Text = dr["description"].ToString();
                modType.Text = "<span style = 'background-color:yellow'>New Record</span>";
                hdnTableName.Value = dr["tableName"].ToString();
                hdnId.Value = dr["dataid"].ToString();
                GetInsertData(dr["tableName"].ToString(), dr["identifierField"].ToString(), dr["dataid"].ToString(), dr["modType"].ToString());
            }            
        }


        private void GetInsertData(string table_name,string id_field,string id,string logType)
        {
            string data = _clsDao.GetSingleresult("EXEC [proc_GetColumnToRowFull] " + filterstring(table_name) + "," + filterstring(id_field) + ","+filterstring(id)+",NULL");
            StaticPage static_page = new StaticPage();
            var dt = _clsDao.GetStringToTable(data.ToString());
            if (dt.Rows.Count == 0)
            {
                rpt_grid.InnerHtml = "<center><b> No changes made.</b><center>";
                return;
            }
            var str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            str.Append("<th  width = \"200px\" align=\"left\">" + dt.Columns[0].ColumnName + "</th>");
            str.Append("<th align=\"left\">" + dt.Columns[1].ColumnName + "</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + dr[0].ToString() + "</td>");
                
                    if (logType.ToLower() == "insert")
                    {
                        str.Append("<td align=\"left\">" + dr[1] + "</td>");
                    }                  
                
                str.Append("</tr>");
            }

            str.Append("</table> </div>");
            rpt_grid.InnerHtml = str.ToString();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnTableName.Value == "ASSET_INVENTORY_TEMP")
                {
                    _clsDao.runSQL("EXEC [procAssetBookingApproval] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");                  
                }
                else if (hdnTableName.Value == "ASSET_WRITEOFF_TEMP")
                {
                    _clsDao.runSQL("EXEC [proc_Asset_writeoff] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");                 
                }
                else if (hdnTableName.Value == "ASSET_SALES_HISTORY_TEMP")
                {
                    _clsDao.runSQL("EXEC [procApprovaAssetSalesRequest] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");                  
                }
                else if (hdnTableName.Value == "ASSET_CAPITALIZATION_TEMP")
                {
                    _clsDao.runSQL("EXEC [procApprovalAssetCapitalizeRequest] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");
                }
                else if (hdnTableName.Value == "ASSET_MAINTENANCE_TEMP")
                {
                    _clsDao.runSQL("EXEC [procApproveAssetMaintenanceRequest] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");
                }
                else if (hdnTableName.Value == "ASSET_TRANSFER_TEMP")
                {
                    _clsDao.runSQL("EXEC [procManageApprovedAssetTransfer] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");
                }
                else if (hdnTableName.Value == "DEPRECIATION_BOOKING_REQUEST")
                {
                    string msg= _clsDao.GetSingleresult("EXEC [procApprovalDepreciationBooking] @flag='i',@table_id=" + filterstring(hdnId.Value) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@queue_id=" + filterstring(GetId().ToString()) + "");
                    if (msg.Contains("sucessfully"))
                    {
                        lblmsg.Text = msg;
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        btnApprove.Visible = false;
                        btnReject.Visible = false;
                        btnTerminate.Visible = false;
                        return;
                    }
                    else
                    {
                        lblmsg.Text = msg;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                Response.Redirect("ListApprovalRequest.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }                 
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("EXEC [procRejectTerminateApproval] @flag='r',@table_id=" + filterstring(hdnId.Value) + ",@queue_id=" + filterstring(GetId().ToString()) + ","
                                + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@rejection_reason=" + filterstring(reasonForRejection.Text) + "");
                Response.Redirect("ListApprovalRequest.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnTerminate_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("EXEC [procRejectTerminateApproval] @flag='t',@table_id=" + filterstring(hdnId.Value) + ",@queue_id=" + filterstring(GetId().ToString()) + ","
                                + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
                Response.Redirect("ListApprovalRequest.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}