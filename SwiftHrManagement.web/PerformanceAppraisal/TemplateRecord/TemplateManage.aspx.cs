using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.PerformanceAppraisal.Template;

namespace SwiftHrManagement.web.PerformanceAppraisal.TemplateRecord
{
    public partial class TemplateManage : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        TemplateRecordDAO _trDao = new TemplateRecordDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if(gettemplateId() > 0)
                {
                    GetDetail();
                }

                populateDdl();
                getData();
                lblmsg.Text = "";
                txtPercentage.Enabled = false;
            }
        }

        private string getFlag()
        {
            return Request.QueryString["flag"] != null ? Request.QueryString["flag"] : "";
        }

        private long gettemplateId()
        {
            return Request.QueryString["templateId"] != null ? long.Parse(Request.QueryString["templateId"]) : 0;
        }

        private void populateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlMarkingBy, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=73", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (gettemplateId() > 0 )
                {
                    lblmsg.Text = _trDao.AddNewData(ddlMarkingBy.Text,ddlMarkingType.Text,txtPercentage.Text,txtTemplateName.Text,txtTdescription.Text,gettemplateId().ToString(),ReadSession().Emp_Id.ToString());
                    ddlMarkingBy.Text = "";
                    ddlMarkingType.Text = "";
                    txtPercentage.Text = "";
                    getData();
                }
            else
                {
                    string totalsum = _trDao.GetSingleresult("select  isnull(sum(percentage),0) from templateRecordMarking where sessionid='" + ReadSession().Sessionid + "'");
                    int sum = int.Parse(totalsum) + int.Parse(txtPercentage.Text);
                    if (sum > 100)
                    {
                        lblmsg.Text = "Percentage should not exceed 100";
                        return;

                    }
                    else
                    {
                        lblmsg.Text = _trDao.insertAddData(ddlMarkingBy.Text, ddlMarkingType.Text, txtPercentage.Text, ReadSession().Sessionid);
                        ddlMarkingBy.Text = "";
                        ddlMarkingType.Text = "";
                        txtPercentage.Text = "";
                        getData();
                    }
                }
        }

        private void getData()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = null;
            if(gettemplateId() > 0)
             dt = _trDao.getAddedData("",gettemplateId().ToString());
            else
            dt = _trDao.getAddedData(ReadSession().Sessionid, "");
            
            double total = 0;
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for(int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                total = total + double.Parse(dr["percentage"].ToString());
                str.Append("</tr>");
            }
            //if(total > 100)
            //{
            //    lblmsg.Text = "Percentage should not exceed 100";
            //    return;
            //}
            str.Append("</table></div>");
            rptTemplate.InnerHtml = str.ToString();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            lblmsg.Text = _trDao.deleteRecord(hdnRowid.Value);
            getData();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
          
            if(gettemplateId() > 0)
            {
                lblmsg.Text = _trDao.updateRecord(txtTemplateName.Text, txtTdescription.Text,
                                                  ReadSession().Emp_Id.ToString(), ReadSession().Sessionid, gettemplateId().ToString());
                setDefault();
            }
            else
            {
                lblmsg.Text = _trDao.saveRecord(txtTemplateName.Text, txtTdescription.Text, ReadSession().Emp_Id.ToString(),ReadSession().Sessionid);
                setDefault();
            }
        }

        private void setDefault()
        {
            txtTemplateName.Text = "";
            txtTdescription.Text = "";
            txtPercentage.Text = "";
            ddlMarkingBy.Text = "";
            ddlMarkingType.Text = "";
            rptTemplate.InnerText = "";

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateList.aspx");
        }

        private void GetDetail()
        {
            DataTable dt1 = _clsDao.getTable("select templateName, templateDescription from templateRecord where templateId=" + filterstring(gettemplateId().ToString()));
            foreach (DataRow dr in dt1.Rows)
            {
                txtTemplateName.Text = dr["templateName"].ToString();
                txtTdescription.Text = dr["templateDescription"].ToString();
            }
        }

        protected void ddlMarkingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMarkingType.SelectedValue == "n")
            {
                txtPercentage.Text = "0";
            }
            else
            {
                txtPercentage.Enabled = true;
                txtPercentage.Focus();
            }
        }

        protected void txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            txtTdescription.Focus();
        }

      
    }
}
