using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = null;
        public Manage()
        {
            _clsdao = new clsDAO();
        }

        private long GetPositioId()
        {
            return (Request.QueryString["PositionId"] != null ? long.Parse(Request.QueryString["PositionId"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               //DdlPosition.Enabled = false;
                if (GetAppraisalId() > 0)
                {
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                prepareddlposition();
                prepareddl();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                populatematrix();
            }
        }

        private void prepareddlposition()
        {
            _clsdao.CreateDynamicDDl(DdlPosition, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID='4'", "ROWID", "DETAIL_TITLE",GetPositioId().ToString(), "Select");

        }
        private void prepareddl()
        {
           // _clsdao.CreateDynamicDDl(DdlPosition, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID='4'", "ROWID","DETAIL_TITLE", "", "Select");
            _clsdao.CreateDynamicDDl(DdlTopic, "select Rowid,DETAIL_DESC from StaticDataDetail where TYPE_ID='28'", "Rowid", "DETAIL_DESC", "", "Select");
            _clsdao.CreateDynamicDDl(DdlSubtopic, "select Rowid,DETAIL_DESC from StaticDataDetail where TYPE_ID='29'", "Rowid", "DETAIL_DESC", "", "Select");
            _clsdao.CreateDynamicDDl(DdlJobElement, "select Rowid,DETAIL_DESC from StaticDataDetail where TYPE_ID='30'", "Rowid", "DETAIL_DESC", "", "Select");
        }

        private long GetAppraisalId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private int checkweightage()
        {
            int weightcount;
            weightcount = _clsdao.ReturnSqlStatement("select SUM(weightage)'weightage' from AppraisalMatrix where position_id = " + DdlPosition.Text + "");
            return weightcount;
        }
        private void populatematrix()
        {
            DataTable dt = new DataTable();
            long id = GetAppraisalId();
            if (id > 0)
            {
              dt =  _clsdao.getDataset("select POSITION_ID, TOPIC_ID, SUBTOPIC_ID, JOB_ELEMENT_ID , WEIGHTAGE, PRIORITY_ID from AppraisalMatrix "
                + " where ID="+ id +"").Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                DdlPosition.Text = dr["POSITION_ID"].ToString();
                DdlTopic.Text = dr["TOPIC_ID"].ToString();
                DdlSubtopic.Text = dr["SUBTOPIC_ID"].ToString();
                DdlJobElement.Text = dr["JOB_ELEMENT_ID"].ToString();
                TxtWeightage.Text = dr["WEIGHTAGE"].ToString();
                hdnField.Value = dr["WEIGHTAGE"].ToString();
                TxtDispOrder.Text = dr["PRIORITY_ID"].ToString();
            }
        }
        private void manageappraisalMatrix()
        {
            long id = 0;
            id = GetAppraisalId();
            string weight = TxtWeightage.Text;
            if (id > 0)
            {
                _clsdao.runSQL("exec ProcAppraisalMatrix 'u','" + id + "','" + DdlPosition.SelectedValue + "','" + DdlTopic.Text + "', "
                + " '" + DdlSubtopic.Text + "','" + DdlJobElement.Text + "','" + this.TxtWeightage.Text + "','" + this.TxtDispOrder.Text + "'");                
            }
            else
            {
                _clsdao.runSQL("exec ProcAppraisalMatrix 'i','" + id + "','" + DdlPosition.SelectedValue + "','" + DdlTopic.Text + "', "
                + " '" + DdlSubtopic.Text + "','" + DdlJobElement.Text + "','" + TxtWeightage.Text + "','" + TxtDispOrder.Text + "'");          
            }
        }
        private void resetMAtrix()
        {
            DdlJobElement.SelectedIndex = 0;

            TxtWeightage.Text = "";
            TxtDispOrder.Text = "";
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetAppraisalId() > 0)
                {                
                    string totWeightage =_clsdao.GetSingleresult("SELECT SUM(ISNULL(weightage,0)) AS WEIGHTAGE FROM AppraisalMatrix WHERE POSITION_ID=" + filterstring(DdlPosition.Text) + "");

                    if ((Double.Parse(totWeightage) -Double.Parse(hdnField.Value)+ Double.Parse(TxtWeightage.Text)) > 100)
                    {
                        LblMsg.Text = "Total weightage can not be greater than 100!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        manageappraisalMatrix();
                        Response.Redirect("AppraisalView.aspx?positionId=" + DdlPosition.Text + "");
                    }
                }
                else
                {
                    string totWeightage = _clsdao.GetSingleresult("exec ProcApprisalWeight @POSITION_ID=" + filterstring(DdlPosition.Text) + "");
                    
                        if ((Double.Parse(totWeightage) + Double.Parse(TxtWeightage.Text)) > 100)
                        {
                            LblMsg.Text = "Total weightage can not be greater than 100!";
                            LblMsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            manageappraisalMatrix();
                            Response.Redirect("AppraisalView.aspx?positionId=" + GetPositioId() + "&Id=" + GetAppraisalId() + "");
                        }
                    
                }                
            }
            catch
            {
                LblMsg.Text = "Error in operation ";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("exec procExecuteSQLString 'd' , 'delete from AppraisalMatrix' , ' and  ID=''" + GetAppraisalId() + "''', '" + ReadSession().UserId + "'");
                LblMsg.Text = "Delete Operation Completed Successfully!";
                LblMsg.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                LblMsg.Text = "Error In Delete Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }

        protected void DdlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlJobElement.SelectedValue != null)
            {
                _clsdao.CreateDynamicDDl(DdlJobElement, "select Rowid,DETAIL_DESC from StaticDataDetail where TYPE_ID='30'and ROWID not in (select JOB_ELEMENT_ID from AppraisalMatrix where POSITION_ID=" + DdlPosition.SelectedValue + ")", "Rowid", "DETAIL_DESC", "", "Select");
            }
        }

        
    }
}
