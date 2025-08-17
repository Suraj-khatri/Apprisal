using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.TravelOrder.Reimbursement
{
    public partial class ApprovalPage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public ApprovalPage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetID() > 0)
                {
                    PopulateTravelAuthorisation();
                    //PopulateReimbursement();
                    populateReimbersement();
                    PopulateOthers();
                }
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 242) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            this.lblreadsesion.Text = ReadSession().Emp_Id.ToString();
        }

        private void PopulateOthers()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = CLsDAo.getTable("Exec proc_tadaReimbersement @FLAG='por',"
                           + " @tadaId=" + filterstring(GetID().ToString()) +"");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                //str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");

                double[] sum = new double[cols];

                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i <= cols - 1; i++)
                    {
                        if (i == 2)
                        {
                            double currVal;
                            double.TryParse(dr[i].ToString(), out currVal);
                            sum[i] += currVal;
                        }
                        //if(i==9)
                        //{
                        //    str.Append("<td align=\"left\"><a  target='_blank' href='/doc/TADABILL" + "/" + dr["id"] + "." + dr["fileExt"].ToString() + "'><u>" + dr[i].ToString() + "</u></a></td>");
                        //}
                        //else
                        //{
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        //}
                    }
                    //str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("<tr>");
                str.Append("<td align=\"left\"> <b>Total Claim Amount</b></td>");
                for (int i = 2; i <= 2; i++)
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
                str.Append("</tr>");
                str.Append("</table>");
                str.Append("</div>");
                disOtherExp.InnerHtml = str.ToString();
            }
            //DataTable dt = new DataTable();
            //dt =CLsDAo.getDataset("EXEC proc_tadaReimbersement @flag='por',@id="+filterstring(GetID().ToString())).Tables[0];
            //DataRow dr = null;
            //if (dt.Rows.Count > 0)
            //{
            //    dr = dt.Rows[0];

            //}
            //if(dr==null)
            //{
            //    this.divothers.Visible = false;
            //    return;
            //}
            ////this.lblOtherexp.Text = dr["HeadExpenses"].ToString();
            ////this.lblotclaimamt.Text = ShowDecimal(dr["claimAmount"].ToString());
            ////this.lblothercurrency.Text = dr["currency"].ToString();
          
        }

        /*private void PopulateReimbursement()
        {
            DataTable dt = new DataTable();
            dt =
                CLsDAo.getDataset("EXEC proc_tadaReimbersement @flag='pr',@id="+filterstring(GetID().ToString())).Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if(dr==null)
            {
                this.divreimburse.Visible = false;
                return;
            }
            this.lblheadexpenses.Text = dr["HeadExpenses"].ToString();
            this.Lblcuurrency.Text = dr["Currency"].ToString();
            this.lblpdentilement.Text = ShowDecimal(dr["PerDayEntitle"].ToString());
            this.lbltotalentilement.Text = ShowDecimal(dr["TotalEntitle"].ToString());
            this.Lblbilssenclosed.Text = dr["billsToBeClosed"].ToString();
            this.LblClaimamt.Text = ShowDecimal(dr["claimAmount"].ToString());

            if (dr["status_tr"].ToString() == "Pending")
            {
                this.BtnVerify.Visible = false;
            }

            else if (dr["status_tr"].ToString() == "Approved")
            {

                if (dr["authorised_by"].ToString() == ReadSession().Emp_Id.ToString() || dr["emp_id"].ToString() == ReadSession().Emp_Id.ToString())
                {
                    this.BtnSave.Visible = false;
                    this.BtnVerify.Visible = false;
                    this.BtnReject.Visible = false;
                }

                else
                {
                    this.BtnVerify.Visible = true;
                    this.BtnSave.Visible = false;
                }
            }
            else
            {
                this.BtnVerify.Visible = false;
                this.BtnReject.Visible = false;
                this.BtnSave.Visible = false;
            }
        }
         */

        private void populateReimbersement()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = CLsDAo.getTable("Exec proc_tadaReimbersement @FLAG='ss',"
                           + " @tadaId=" + filterstring(GetID().ToString()) +"");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                for (int i = 2; i < cols; i++)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                //str.Append("<th align=\"left\">Delete</th>");
                str.Append("</tr>");

                double[] sum = new double[cols];

                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 2; i <= cols - 1; i++)
                    {
                        if (i == 8)
                        {
                            double currVal;
                            double.TryParse(dr[i].ToString(), out currVal);
                            sum[i] += currVal;
                        }
                        //if(i==9)
                        //{
                        //    str.Append("<td align=\"left\"><a  target='_blank' href='/doc/TADABILL" + "/" + dr["id"] + "." + dr["fileExt"].ToString() + "'><u>" + dr[i].ToString() + "</u></a></td>");
                        //}
                        //else
                        //{
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        //}
                    }
                    //str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["ID"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                    str.Append("</tr>");
                }
                str.Append("<tr>");
                str.Append("<td colspan=\"6\" align=\"left\"> <b>Total Claim Amount</b></td>");
                for (int i = 8; i <= 8; i++)
                {
                    str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
                }
                str.Append("</tr>");
                str.Append("</table>");
                str.Append("</div>");
                disReimbersement.InnerHtml = str.ToString();
            }
        }

        private void PopulateTravelAuthorisation()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("exec proc_travel @flag='a', @id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (dr == null)
                return;
            
            this.LblEmpName.Text = dr["empname"].ToString() + "|" + dr["employee_id"].ToString();
            this.lblbranch.Text = dr["branch_name"].ToString();
            this.lbldepartment.Text = dr["department_name"].ToString();
            this.lblposition.Text = dr["detail_title"].ToString();
            this.lblcity.Text = dr["destination_city"].ToString();
            this.lblcountry.Text = dr["country"].ToString();
            this.lblreasontravel.Text = dr["reason_for_travel"].ToString();
            this.lblfromdate.Text = dr["duration_from"].ToString();
            this.lbltodate.Text = dr["duration_to"].ToString();
            this.lblextension.Text = dr["extension"].ToString();

            if (this.lblextension.Text == "Yes")
            {
                this.divIsExtVisit.Visible = true;
                this.lblextfrom.Text = dr["durex_from"].ToString();
                this.lblextto.Text = dr["durex_to"].ToString();
                this.lblextcity.Text = dr["durex_city"].ToString();
                this.Lblextcountry.Text = dr["country"].ToString();
                this.lblleaveaaplied.Text = "Yes";
                this.lblremainingdays.Text = dr["dur_leave"].ToString();
                
            }
           
            this.lblmode.Text = dr["mode_of_travel"].ToString();
            this.lbltransportation.Text = dr["transportation"].ToString();
            this.lblaccomodation.Text = dr["accomodation"].ToString();
            this.lblfooding.Text = dr["fooding"].ToString();
            this.lblcashadvance.Text = dr["cashadvance"].ToString();

            if (this.lblcashadvance.Text == "Yes")
            {
                this.divIsAdvance.Visible = true;
            }
            //this.lblauthorisedy.Text = dr["authorised_by"].ToString();
            
        }

        private long  GetID()
        {
            return(Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }

        private  long  FlagId()
        {
            return (Request.QueryString["flagId"] != null ? long.Parse(Request.QueryString["flagId"].ToString()) : 0);
        }

        //private string GetFlag()
        //{
        //    return (Request.QueryString['flag'] != null ?(Request.QueryString['flag'].ToString()) : 0);
        //}

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            AcceptStatus();
            Response.Redirect("Approvelist.aspx");
        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            RejectStatus(); 
           if(FlagId()==1)
           {
               Response.Redirect("ApproveList.aspx");
           }
           else
           {
               Response.Redirect("VerifyList.aspx");
           }

        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            AcceptStatusByHr();
            Response.Redirect("VerifyList.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if(FlagId()==1)
            {
                Response.Redirect("ApproveList.aspx");
            }
            else
            {
                Response.Redirect("VerifyList.aspx");
            }
        }

        private void AcceptStatus()
        {
            string sql = CLsDAo.GetSingleresult("update tadaReimbersement set status_tr='Approved' where isDelete='N'and tadaId=" +
                                       filterstring(GetID().ToString()));
        }

        private void RejectStatus()
        {
            string sql = CLsDAo.GetSingleresult(("update tadaReimbersement set status_tr='Rejected' where isDelete='N'and tadaId=" +
                                                 filterstring(GetID().ToString())));
        }

        private void AcceptStatusByHr()
        {
            string sql = CLsDAo.GetSingleresult("update tadaReimbersement set status_tr='Verified' where isDelete='N'and tadaId=" +
                                       filterstring(GetID().ToString()));
        }
    }
}