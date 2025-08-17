using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.ExternalTransferPlanDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.ExitInterview;
using SwiftHrManagement.web;

namespace SwiftHrManagement.web.EmployeeMovement.Exit_Interview
{
    public partial class Manage : BasePage
    {
        
        clsDAO CLsDAo = null;
        ExitInterViewDao _exitIntDao = null;
        ExternalTransferPlanCore _externalTransCore = null;
        ExternalTransferPlanDAO _externalTransDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._externalTransCore = new ExternalTransferPlanCore();
            this._externalTransDao = new ExternalTransferPlanDAO();
            this._exitIntDao = new ExitInterViewDao();
        }

        private long GetDiscID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"].ToString()) : "");
        }
        private long GetEmpID()
        {
            return long.Parse(CLsDAo.GetSingleresult("select STAFF_ID from EmployeeDiscontinuousPlan	where ID=" + GetDiscID() + ""));
        }
        private long GetID()
        {
            string msg = CLsDAo.GetSingleresult("select isnull(exitIntId,0) from exitInterview	where discountID=" + GetDiscID() + "");

            return (msg != "" ? long.Parse(msg) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 50) == false)
                {
                    Response.Redirect("/Error.aspx");
                };
                if (this.GetID() > 0)
                {                    
                    BtnDelete.Visible = true;
                    DisplayQueAnsRecordById("",GetID().ToString());
                    PopulateData(); 
                }
                else
                {                   
                    BtnDelete.Visible = false;
                    BtnSave.Visible = true;
                    DisplayQueAnsRecordById(GetEmpID().ToString(), "");
                }
                SetDDL();
                EmployeeInfo();
            }           
        }
        private void SetDDL()
        {
            CLsDAo.CreateDynamicDDl(DdlQuestionType, "Exec ProcStaticDataView 's','45'", "ROWID", "DETAIL_TITLE", "", "Select");             
        }

        private void EmployeeInfo()
        {
            StaticPage st = new StaticPage();
            DataTable dt = st.GetEmpInfoById(GetEmpID().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];

            lblEmpName.Text = dr["empName"].ToString();
            lblBranch.Text = dr["branch"].ToString();
            lblDept.Text = dr["dept"].ToString();
        }

        private void PopulateData()
        {
           DataTable dt =  _exitIntDao.PopulateData(GetID().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            
            txtComments.Text = dr["comments"].ToString();
            LoadCheckBoxList(dr["exitReason"].ToString());
        }
  

       private void LoadCheckBoxList(string reasonList) 
       {
           if (reasonList.Length == 0)
               return;

           var arrayExitReason = reasonList.ToString().Split(',');
          
           foreach (ListItem li in chk1.Items)
           {
               if (arrayExitReason.Contains(li.Value))
               {
                   li.Selected = true;
               }
               
           }

           foreach (ListItem li in chk2.Items)
           {
               if (arrayExitReason.Contains(li.Value))
               {
                   li.Selected = true;
               }
           }
       }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                clsDAO swift = new clsDAO();
                swift.runSQL("exec procExecuteSQLString 'd' , 'Delete from ExitInterview' , ' and  ID='" + filterstring(GetID().ToString()) + "'', " + filterstring(ReadSession().UserId) + "");
                if (GetFlag() == "a")
                {
                    Response.Redirect("ListAll.aspx");
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (GetFlag() == "a")
            {
                Response.Redirect("ListAll.aspx");
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }


        private string GetChkListValue(ref CheckBoxList chkLst)
        {
            string itemList = "";
            foreach (ListItem li in chkLst.Items)
            {
                if (li.Selected)
                {
                    itemList += (itemList.Length > 0 ? "," : "") + li.Value;                  
                }
            }

            return itemList;
        }

        protected void BtnFinalSubmit_Click(object sender, EventArgs e)
        {
            try
            {                
                string itemList = GetChkListValue(ref chk1);
                string itemList2 = GetChkListValue(ref chk2);
                string itemAll = itemList + (itemList.Length > 0 ? "," : "") + itemList2;

                string msg = _exitIntDao.OnFinalSave(GetID().ToString(),ReadSession().Branch_Id.ToString(),ReadSession().Department.ToString()
                            , GetEmpID().ToString(), itemAll, txtComments.Text
                            , ReadSession().UserId, ReadSession().Sessionid,GetDiscID().ToString());

                if (GetFlag() == "a")
                {
                    Response.Redirect("ListAll.aspx");
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private long ExitId()
        {

            if ((hdnExitEditId.Value.ToString() == ""))
            {
                return 0;
            }
            else
                return long.Parse(hdnExitEditId.Value);

        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        { 
            string msg ="";
            if(GetID() > 0)
            {
                
                    msg = _exitIntDao.EditQueAns(DdlQuestionType.Text, txtAnswer.Text, hdnExitEditId.Value, GetID().ToString());
                    DisplayQueAnsRecordById("", GetID().ToString());             
                
            }
            else
            { 
                    msg = _exitIntDao.OnGiveQuestinAns(DdlQuestionType.Text, txtAnswer.Text, ReadSession().Sessionid);
                    DisplayQueAnsRecordById(ReadSession().Sessionid, "");

            }
           
            lblQueMsg.Text = msg;
            lblQueMsg.ForeColor = System.Drawing.Color.Green;
           
        }
        private void DisplayQueAnsRecordById(string sessionIdOrExitId,string exitId)
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"2\" cellspacing=\"2\" align=\"center\">");
            DataTable dt = _exitIntDao.FindQusAnsById(sessionIdOrExitId,exitId);
            if (dt.Rows.Count <= 0)
            {
                rpt.InnerText = "Record does not Exist";
                return;
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                if (exitId == "")
                {
                    if (i == 0 || i== 1 || i == 3)
                    {
                        str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                    }

                }
                else
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (exitId == "")
                    {
                        if (i == 0 || i == 1 || i == 3)
                        {
                            if (i == 1)
                            {
                                str.Append("<td align=\"left\" width=\"30px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:40em; height:5em;font-size: 12px;\">" + dr[i].ToString() + " </textarea></td>");
                            }
                            else
                                str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    else
                    {
                        if (i == 1)
                        {
                            str.Append("<td align=\"left\" width=\"30px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:40em; height:5em;font-size: 12px;\">" + dr[i].ToString() + " </textarea></td>");
                        }
                        else
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();


        }

        protected void BtnDelete1_Click(object sender, EventArgs e)
        {
           string msg =  _exitIntDao.DeleteRecord(hdnExitId.Value);
           lblQueMsg.Text = msg;
           DisplayQueAnsRecordById(ReadSession().Sessionid,GetID().ToString());
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = _exitIntDao.OnPopulateQuesAns(hdnExitEditId.Value);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];

            CLsDAo.CreateDynamicDDl(DdlQuestionType, "Exec ProcStaticDataView 's','45'", "ROWID", "DETAIL_TITLE", dr["questionType"].ToString(), "Select");
            txtAnswer.Text = dr["questionAns"].ToString();   
        }
    }
}
