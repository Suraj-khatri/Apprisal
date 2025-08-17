using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.web.DAL.PerformanceAppraisal.Matrix;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix
{
    public partial class ManageSetUp : BasePage
    {
        decimal totalWeight = 0;
        long appraisalSubWeight = 0;
        clsDAO _clsDao = null;
        AppriasalMatrixDao _matrix = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageSetUp()
        {
            _clsDao = new clsDAO();
            _matrix = new AppriasalMatrixDao();
            _roleMenuDao = new RoleMenuDAOInv();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                SetDDL("","","");
                DisplayAddAppraisal();
                ddlAppraisalTopic.Enabled = false;
                GetTempName();
            }
            DivMsg.InnerHtml = "";
        }
       private void GetTempName()
        {
          string TempName =   _matrix.FindTemplateNameById(GetTempID());
          lblTemplate.Text = TempName;

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
           

            if ((HdnEditId.Value == "" ? 0 : long.Parse(HdnEditId.Value)) > 0)
            {
                DataTable dt = _matrix.OnUpdate(HdnEditId.Value,ddlAppraisalSubTopic.Text,ddlJobElement.Text,txtAppraisalSubTopicWeight.Text,txtWeightJobElement.Text);
                DataRow dr = null;
                if (dt == null || dt.Rows.Count < 0)
                    return;
                dr = dt.Rows[0];

                if (dr["error_code"].ToString() == "1")
                {
                    DivMsg.InnerHtml = dr["msg"].ToString();
                    DivMsg.Attributes.Add("class", "warning");

                }
                else
                {
                    DivMsg.InnerHtml = dr["msg"].ToString();
                    DivMsg.Attributes.Add("class", "success");
                }
                HdnEditId.Value = "";
            }
            else
            {
                OnSave();
            }
            DisplayAddAppraisal();
           
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = _matrix.OnDelete(hdnDeleteId.Value);
            DisplayAddAppraisal();
           
            DivMsg.InnerHtml = msg;
            DivMsg.Attributes.Add("class", "success");

                
        }
        protected long GetTempID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void SetDDL(string selectedValue,string selectedValue1,string selectedValue2)
        {
            var sql = " select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 28";
            var sql1 = " select ROWID,DETAIL_DESC from StaticDataDetail where TYPE_ID = 29";
            var sql2 = " select ROWID,DETAIL_DESC from StaticDataDetail where TYPE_ID = 30";

            _clsDao.setDDL(ref ddlAppraisalTopic, sql, "ROWID", "DETAIL_TITLE", selectedValue, "Section II");
            _clsDao.setDDL(ref ddlAppraisalSubTopic, sql1, "ROWID", "DETAIL_DESC", selectedValue1, "select");
            _clsDao.setDDL(ref ddlJobElement, sql2, "ROWID", "DETAIL_DESC", selectedValue2, "select");
        }

        private void OnSave()
        {
            string aa = HdnEditId.Value;
            DataTable dt =  _matrix.OnSave(GetTempID().ToString(), ddlAppraisalTopic.Text, ddlAppraisalSubTopic.Text
                , ddlJobElement.Text, txtAppraisalSubTopicWeight.Text, txtWeightJobElement.Text);
            DisplayAddAppraisal();
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];

            if(dr["error_code"].ToString() == "1")
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "warning");
            }
            else
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "success");
            }
             
        }
        private void FindAppraisalInfoById()
        {
            DataTable dt = _matrix.FindAppraisalInfoById(HdnEditId.Value);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];
            SetDDL("", dr["appraisalSubTopic"].ToString(), dr["jobElement"].ToString());
            txtAppraisalSubTopicWeight.Text = dr["appraisalSubTopicWeight"].ToString();
            txtWeightJobElement.Text = dr["jobElementWeight"].ToString();
       
        }
        private void DisplayAddAppraisal()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _matrix.FindMatrixSetupById(GetTempID().ToString());
            if (dt.Rows.Count == 0)
            {
                rpt.InnerHtml = "<center><b>No Result to Display</b></center>\n";
                return;
            }


            str.Append("<tr>\n");
            int cols = dt.Columns.Count;

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\" nowrap='nowrap'>" + dt.Columns[i].ColumnName + "</th> \n");
            }
            str.Append("</tr>\n");
            string lastSubTopic = "";
            string lastSubWeight = "";
            long count = 0;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    
                    if (i == 1)
                    {
                        if (count == 0 || (lastSubTopic.Trim().ToUpper() != dr["Appriasal Sub Topic"].ToString().Trim().ToUpper()))
                        {
                            str.Append("<td align=\"left\" >" + dr["Appriasal Sub Topic"].ToString() + "</td> \n");
                           

                        }
                        else
                        {
                            str.Append("<td align=\"left\"> </td> \n");
                        }
                   }
                   else if (i == 2)
                   {
                       if (count == 0 || (lastSubTopic.Trim().ToUpper() != dr["Appriasal Sub Topic"].ToString().Trim().ToUpper()))
                        {
                            str.Append("<td align=\"left\" >" + dr[i].ToString() + "</td> \n");
                            appraisalSubWeight = appraisalSubWeight + long.Parse(dr[2].ToString());
                        }
                        else
                        {
                            str.Append("<td align=\"left\"> </td> \n");
                        }
                   
                        
                    }
                    else if (i == 3)
                    {
                        str.Append("<td align=\"left\" width=\"50%\">" + dr[i].ToString() + "</td> \n");
                        
                    }
                    else if (i == 5)
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td> \n");
                        totalWeight = totalWeight + decimal.Parse(dr[5].ToString().Trim());
                    }
                    else if (i == 0)
                    {
                        count = count + 1;
                       str.Append("<td align=\"left\">" + count+ "</td> \n");
                    }
                    else if(i == 6)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td> \n");
                    }
                   
                    else
                        str.Append("<td width=\"\" align=\"left\">" + dr[i].ToString() + "</td> \n");
                    

                        
                }
               
                
                str.Append("</tr> \n");

                lastSubTopic = dr["Appriasal Sub Topic"].ToString();
                

                //count++;
            }
           

            str.Append("<tr></tr> \n");
            str.Append("<tr>");
            str.Append("<td width=\"\" align=\"right\" colspan =\"2\">Total SubTopic Weight</td> \n");
            str.Append("<td width=\"\" align=\"right\">" +ShowDecimal(appraisalSubWeight.ToString()) + "</td> \n");
            str.Append("<td width=\"\" align=\"right\" colspan =\"2\">Total Weight</td> \n");
            str.Append("<td width=\"\" align=\"right\">" + ShowDecimal(totalWeight.ToString()) + "</td> \n");
            str.Append("</tr>");
            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            FindAppraisalInfoById();
        }

       
    }
}
