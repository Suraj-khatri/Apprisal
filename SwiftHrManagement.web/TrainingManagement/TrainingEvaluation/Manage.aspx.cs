using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.TrainingMangement;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingManagement.TrainingEvaluation
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO CLsDAo = null;
        TrainingEvaluationDAO _trainEvDAO = null;
        TrainingEvaluationCore _trainEvCore = null;
        TrainingProgramDAO _trainProgramDao = null;
        TrainingProgramCore _trainProgramCore = null;
        public Manage()
        {
            CLsDAo=new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
            _trainEvCore = new TrainingEvaluationCore();
            _trainEvDAO = new TrainingEvaluationDAO();
            _trainProgramCore = new TrainingProgramCore();
            _trainProgramDao = new TrainingProgramDAO();
        }
        private long GetEvaluationId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetProgramId()
        {
            return (Request.QueryString["ProgramId"] != null ? long.Parse(Request.QueryString["ProgramId"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 42) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                getProgramInfo();
                CLsDAo.CreateDynamicDDl(DdlEvalutionRate, "Exec ProcStaticDataView 's','48'", "ROWID", "DETAIL_TITLE", "", "Select");
                if (GetEvaluationId() > 0)
                {
                    populateEvaluationDetails();
                    Btn_Save.Visible = false;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }
        private void populateEvaluationDetails()
        {
            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("SELECT EVALUATION_RATE,EVALUATION FROM TrainingEvaluation WHERE ID="+filterstring(GetEvaluationId().ToString())+"").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                this.DdlEvalutionRate.Text = dr["EVALUATION_RATE"].ToString();
                this.TxtEvaluation.Text = dr["EVALUATION"].ToString();
            }
        }
        private void getProgramInfo()
        {
            this._trainProgramCore = this._trainProgramDao.FindByTrainProgramId(GetProgramId());
            this.txtProgramCategory.Text = _trainProgramCore.TrainingId;
            this.TxtTrainProgramTitle.Text = _trainProgramCore.TrainingProgramTitle;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("INSERT INTO TrainingEvaluation (TRAINING_PROGRAM_ID,EVALUATION_RATE,EVALUATION,CREATED_BY,CREATED_DATE)"
                 + " VALUES ("+filterstring(GetProgramId().ToString())+","+filterstring(DdlEvalutionRate.Text)+","+filterstring(TxtEvaluation.Text)+","
                +" "+filterstring(ReadSession().UserId)+","+filterstring(System.DateTime.Now.ToString())+")");

                Response.Redirect("/TrainingManagement/TrainingEvaluation/List.aspx?ID="+GetProgramId()+"");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TrainingManagement/TrainingEvaluation/List.aspx?ID=" + GetProgramId() + "");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("DELETE FROM TrainingEvaluation WHERE ID="+filterstring(GetEvaluationId().ToString())+"");
                Response.Redirect("/TrainingManagement/TrainingEvaluation/List.aspx?ID=" + GetProgramId() + "");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
