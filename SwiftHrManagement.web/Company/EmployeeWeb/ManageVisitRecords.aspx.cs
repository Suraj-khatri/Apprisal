using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.VisitRecordDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageVisitRecords : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        VisitRecordDAO _visitRecordDao = null;
        VisitRecordCore _visitRecordCore = null;
        
        public ManageVisitRecords()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._visitRecordDao = new VisitRecordDAO();
            this._visitRecordCore = new VisitRecordCore();
        }

        private long GetVisitId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateVisitRecord()
        {
            this._visitRecordCore = this._visitRecordDao.FindById(this.GetVisitId());
            
            this.DdlVisitType.Text = this._visitRecordCore.VisitType.ToString();
            this.DdlCountry.Text = this._visitRecordCore.Country.ToString();
            
            this.TxtDateFrom.Text = this._visitRecordCore.DateFrom.ToString();
            this.TxtDateTo.Text = this._visitRecordCore.DateTo.ToString();
            this.TxtCity.Text = this._visitRecordCore.City.ToString();
            this.TxtReason.Text = this._visitRecordCore.Reason.ToString();

            this.hdnempid.Value = this._visitRecordCore.EmployeeId;

        }
        private void ManageVR()
        {
            VisitRecordCore _vrCore = new VisitRecordCore();
            long id = this.GetVisitId();
            long visId = this.GetVisitId();
            
            _visitRecordCore.Id = long.Parse(visId.ToString());

            _visitRecordCore.VisitType = DdlVisitType.Text;
            _visitRecordCore.Country = DdlCountry.Text;
            _visitRecordCore.DateFrom = DateTime.Parse(TxtDateFrom.Text);
            _visitRecordCore.DateTo = DateTime.Parse(TxtDateTo.Text);
            _visitRecordCore.City = TxtCity.Text;
            _visitRecordCore.Place = TxtPlace.Text;
            _visitRecordCore.Reason = TxtReason.Text;

            if (visId > 0)
            {
                _visitRecordCore.EmployeeId = this.hdnempid.Value;
                this._visitRecordDao.Update(this._visitRecordCore);
            }
            else
            {
                _visitRecordCore.EmployeeId = this.ReadSession().TempEmpId.ToString();
                this._visitRecordDao.Save(this._visitRecordCore);
            }
            this._visitRecordCore = _vrCore;
        }


        private void ResetVisitRecord()
        {
            BtnSave.Enabled = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false && _RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 104) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetVisitId();

                if (Id > 0)
                {
                    PopulateVisitRecord();
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageVR();
                LblMsg.Text = "Operation Completed Successfully";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                this.ResetVisitRecord();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}