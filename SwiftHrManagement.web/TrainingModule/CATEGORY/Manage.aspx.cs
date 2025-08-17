using System;
using SwiftHrManagement.DAL.TrainingDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingModule.CATEGORY
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        trainingCategoryDao _trainingListdao = null;
        TrainingListCore _trainingListCore = null;
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _trainingListCore = new TrainingListCore();
            _trainingListdao = new trainingCategoryDao();

        }
        private long GetTrainingListId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void populateTransferDtls1()
        {
            this._trainingListCore = this._trainingListdao.FindById(GetTrainingListId());
            this.TxtTrnName.Text = this._trainingListCore.TrainingName;
            this.TxtTranCnt.Text = this._trainingListCore.CourseContents;
            this.TxtDsgFor.Text = this._trainingListCore.DesignedFor;
        }

        private void prepareTrainingList()
        {
            long id = this.GetTrainingListId();
            if (id > 0)
            {
                _trainingListCore.Id = id;
            }
            _trainingListCore.TrainingName = TxtTrnName.Text;
            _trainingListCore.CourseContents = TxtTranCnt.Text;
            _trainingListCore.DesignedFor = TxtDsgFor.Text;

        }
        private void manageTrainingList()
        {
            long id = this.GetTrainingListId();
            this.prepareTrainingList();
            if (id > 0)
            {
                try
                {
                    this._trainingListCore.ModifyBy = this.ReadSession().UserId;
                    this._trainingListdao.Update(this._trainingListCore);
                }
                catch
                {
                    this.LblMsg.Text = "Error In Insertion";
                    this.LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                try
                {
                    this._trainingListCore.CreatedBy = this.ReadSession().UserId;
                    this._trainingListdao.Save(this._trainingListCore);
                }
                catch
                {
                    this.LblMsg.Text = "Erro In Insertion";
                    this.LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 244) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (this.GetTrainingListId() > 0)
                {
                    populateTransferDtls1();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }
        private void Clear()
        {
            TxtTranCnt.Text = "";
            TxtTrnName.Text = "";
            TxtDsgFor.Text = "";
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                this.manageTrainingList();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                this.manageTrainingList();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this._trainingListdao.DeleteById(this.GetTrainingListId());
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

    }

}