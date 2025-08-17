using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.TADAReport
{
    public partial class DetailReport : BasePage
    {
        private clsDAO _clsDao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        string sql = "";

        public DetailReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao=new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _CompanyCore = _company.FindCompany();
                this.lblHeading.Text = _CompanyCore.Name;
                this.lbldesc.Text = _CompanyCore.Address;
                PopulateTravelAuthorisation();
                    Reimbursement();
                    Others();

            }
        }

        private int GetId()
        {
            return (Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void PopulateTravelAuthorisation()
        {
            DataTable dt = new DataTable();
            dt =_clsDao.getDataset("exec proc_travel @flag='a', @id="+filterstring(GetId().ToString()) ).Tables[0];
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
                //this.lblcurrency.Text = dr["currency"].ToString();
                //this.lblamount.Text = dr["amount"].ToString();
            }
            //this.lblauthorisedy.Text = dr["authorised_by"].ToString();
            
        }
        

        private void Others()
        {
            DataTable dt = _clsDao.getTable(@"select dbo.GetDetailTitle(headId) [Expenses Head]
                                            ,dbo.GetDetailTitle(currency) [Currency]
                                            ,isnull(perDayEntitle,0) [Per Day Entitlement]
                                            ,isnull(totalEntitle,0) [Total Entitlement]
                                            ,isnull(claimAmount,'') [Claim Amount]
                                            ,billsToBeclosed [Bills Enclosed]
                                            from tadaReimbersement where flag='o' and tadaId=" + filterstring(GetId().ToString()));
            DataRow dar = null;
           if (dt.Rows.Count > 0)
           {
               dar = dt.Rows[0];
           }
           
            if(dar==null)
            {
                this.rptDiv2.Visible = false;
                this.TblOthers.Visible=false;
                return;
            }
            
            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            double sum = 0.00;
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 4)
                    {
                        sum = sum + double.Parse(dr[i].ToString());
                    }
                    if (i > 1 && i <= 4)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>"); 
                    }
                    else 
                    {
                       
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                    }
                    
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"4\" align=\"left\"><b>Total</b></td>");
            str.Append("<td class=\"text-right\"><b>" + ShowDecimal(sum) + "</b></td>");
            str.Append("<td align=\"left\"></td>");
            str.Append("</tr>");
            str.Append("</table>");

            
            rptDiv2.InnerHtml = str.ToString();
        }
        private void Reimbursement()
        {
           DataTable dt = _clsDao.getTable(@"select dbo.GetDetailTitle(headId) [Expenses Head]
                                            ,dbo.GetDetailTitle(currency) [Currency]
                                            ,perDayEntitle [Per Day Entitlement]
                                            ,totalEntitle [Total Entitlement]
                                            ,isnull(claimAmount,'') [Claim Amount]
                                            ,billsToBeclosed [Bills Enclosed]
                                            from tadaReimbersement where flag='r' and tadaId="+GetId().ToString());
           DataRow dar = null;
           if (dt.Rows.Count > 0)
           {
               dar = dt.Rows[0];
           }
           
            if(dar==null)
            {
                this.rptDiv.Visible = false;
                this.TblReimburse.Visible=false;
                return;
            }

            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            double sum = 0.00;
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols-1; i++)
                {
                    if (i == 4)
                    {
                        sum = sum + double.Parse(dr[i].ToString());
                    }
                    if (i > 1 && i <= 4)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else
                     {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                     }

                }
           
                    if (dr[5].ToString() == "Yes")
                    {
                        str.Append("<td><a href=\"/Doc/menu_TADAID.txt" + "\">" + dr[5].ToString() + "</a></td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">"+dr[5].ToString()+"</td>");
                    }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"4\" align=\"left\"><b>Total</b></td>");
            str.Append("<td class=\"text-right\"><b>" + ShowDecimal(sum) + "</b></td>");
            str.Append("<td align=\"left\"></td>");
            str.Append("</tr>");
            str.Append("</table>");
            
            rptDiv.InnerHtml = str.ToString();
        }

    }
}
