using System;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class AdvanceApproval : BasePage
    {
        private clsDAO _clsDao = null;
        private RoleMenuDAOInv _roleMenuDaoInv = null;

        public AdvanceApproval()
        {
            this._clsDao = new clsDAO();
            this._roleMenuDaoInv = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                if (GetID() > 0)
                {
                    PopulateTravelAuthorisation();
                }
                if (_roleMenuDaoInv.hasAccess(ReadSession().AdminId, 171) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        public long GetID()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        public void PopulateTravelAuthorisation()
        {

            //DataTable dt = new DataTable();
           var ds = _clsDao.getDataset("exec proc_travel @flag='ap', @id=" + filterstring(GetID().ToString()) + "");
            DataTable dt = null;
            DataRow dr = null;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>=1)
            {
                dt = ds.Tables[0];
                dr = dt.Rows[0];

                this.lblEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();
                this.lblLocation.Text = dr["branch_name"].ToString() + " / " + dr["department_name"].ToString();
                this.lblDesignation.Text = dr["detail_title"].ToString();
                this.lblVisitArea.Text = dr["destination_city"].ToString() + "/" + dr["country"].ToString();
                this.lblVisitPurpose.Text = dr["reason_for_travel"].ToString();
                this.lblDepartureDate.Text = dr["duration_from"].ToString();
                this.lblArrivalDate.Text = dr["duration_to"].ToString();
                this.lblModeofTravel.Text = dr["mode_of_travel"].ToString();
                this.lblCashAdvance.Text = dr["cashAdvance"].ToString();
                this.lblAirTicket.Text = dr["air_ticket"].ToString();
                this.lblVisitDuration.Text = dr["duration"].ToString();
            }

            
            
            
            var tbl="";
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                tbl += ds.Tables[1].Rows[i]["SNO"]+". ";
                tbl += ds.Tables[1].Rows[i]["authorised_by"] + "<br>";
            }
            authorised.InnerHtml = tbl;

            if (ds.Tables[2].Rows.Count >=1)
            {
                var varCurency = "";
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    varCurency += ds.Tables[2].Rows[i]["SNO"] + ". ";
                    varCurency += ds.Tables[2].Rows[i]["DETAIL_TITLE"] + "<br>";
                }
                currency.InnerHtml = varCurency;
            }

            //this.lblAuthorisedBy.Text = dr["authorised_by"].ToString();
        }
    }
}