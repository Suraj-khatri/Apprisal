using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core;
using SwiftHrManagement.DAL.StaticDataDetailsDAO;
using SwiftHrManagement.DAL.StaticDataTypeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.StaticView
{
    public partial class ManageDataDetail : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        StaticDataDetailsDAO _dataDetailDao = null;
        StaticDataDetailCore _dataDetailCore = null;
        StaticDataTypeDAO _dataTypeDao = null;
        StaticDataTypeCore _dataTypeCore = null;
        clsDAO _clsdao = null;
        public ManageDataDetail()
        {
            _clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();  
            _dataDetailDao = new StaticDataDetailsDAO();
            _dataDetailCore = new StaticDataDetailCore();
            _dataTypeDao = new StaticDataTypeDAO();
            _dataTypeCore = new StaticDataTypeCore();
        }
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetTypeId()
        {
            return (Request.QueryString["TypeID"] != null ? long.Parse(Request.QueryString["TypeID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            divAppOT.Visible = false;
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 57) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (GetId() > 0)
                {
                    PopulateDataDetail();
                    if (TxtTypeId.Text == "41")
                    {
                        divAppOT.Visible = true;
                    }
                    else
                    {
                        divAppOT.Visible = false;
                        ddlOT.SelectedValue = "No";
                    }

                }
                else
                {
                    TxtTypeId.Text = GetTypeId().ToString();
                    if (TxtTypeId.Text == "41")
                    {
                        divAppOT.Visible = true;
                    }
                    else
                    {
                        divAppOT.Visible = false;
                        ddlOT.SelectedValue = "No";
                    }
                }
                this._dataTypeCore = this._dataTypeDao.FindByTypeId(long.Parse(TxtTypeId.Text));
                this.TxtDataType.Text = this._dataTypeCore.Type_title;                
            }

        }
        private void PopulateDataDetail()
        {
            this._dataDetailCore = this._dataDetailDao.FindById(GetId());
            this.TxtTypeId.Text = this._dataDetailCore.Type_id;
            this.TxtDetailTitle.Text = this._dataDetailCore.Detail_title;
            this.TxtDetailDesc.Text = this._dataDetailCore.Detail_desc;
            if (this._dataDetailCore.Apply_OT == "Y")
            {
                ddlOT.SelectedValue = "Y";
            }
            else
            {
                ddlOT.SelectedValue = "N";
            }
               
        }     

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetId() > 0)
                {
                    string check = _clsdao.GetSingleresult("select isnull(IS_DELETE,'Y') from StaticDataDetail where ROWID='" + GetId() + "'");
                    if (check == "N")
                    {
                        LblMsg.Text = "Sorry! System generated data can not be modified!";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        manageDataDetail();
                        Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                    }
                }
                else
                {
                    manageDataDetail();
                    Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                }
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void manageDataDetail()
        {
            long id = GetId();
            this.PrepareDataDetail();
            if (id > 0)
            {
                    _dataDetailCore.ModifyBy = this.ReadSession().UserId;
                    _dataDetailDao.Update(this._dataDetailCore);
                
            }
            else
            {
                _dataDetailCore.CreatedBy = this.ReadSession().UserId;
                _dataDetailDao.Save(this._dataDetailCore);
            }
        }
        private void PrepareDataDetail()
        {            
            StaticDataDetailCore _dataDetailCore = new StaticDataDetailCore();
            long Id = this.GetId();
            if (Id > 0)
            {
                _dataDetailCore.Id = Id;
            }           
            _dataDetailCore.Type_id = TxtTypeId.Text;
            _dataDetailCore.Detail_title = TxtDetailTitle.Text;
            _dataDetailCore.Detail_desc = TxtDetailDesc.Text;           
            this._dataDetailCore = _dataDetailCore;
            if (ddlOT.Text == "Select")
            {
                _dataDetailCore.Apply_OT = "";
            }
            else
            {
            _dataDetailCore.Apply_OT = ddlOT.Text;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string check = _clsdao.GetSingleresult("select isnull(IS_DELETE,'Y') from StaticDataDetail where ROWID='"+GetId()+"'");
                if (check == "N")
                {
                    LblMsg.Text = "Sorry! System generated data can not be deleted!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    this._dataDetailDao.DeleteById(this.GetId(), ReadSession().UserId);
                    Response.Redirect("StaticDataDetailView.aspx?ID=" + TxtTypeId.Text + "");
                }
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaticDataDetailView.aspx?ID="+TxtTypeId.Text+"");
        }

    }
}
