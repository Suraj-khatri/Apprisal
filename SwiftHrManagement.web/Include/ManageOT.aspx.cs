using System;
namespace SwiftHrManagement.web.Include
{
    public partial class ManageOT : BasePage
    {
        clsDAO CLsDAo = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = "";
            String period = Request.QueryString["txtReqPeriod"];
            string flag = Request.QueryString["flag"];
            string remark = Request.QueryString["Remark"];
            String OtRateId = Request.QueryString["OtRateId"];
            string rowid = Request.QueryString["Rowid"];
            string empId = Request.QueryString["empID"];           

            if (flag == "updateReqTime")
            {

                string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='t',@supervisor_approv_time=" + filterstring(period) 
                + ", @OtRequest_id=" + filterstring(rowid.ToString()) + " ");
                Response.Write("Update Successfully");
            }
            else if (flag == "approved")
            {
                string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='sp'," + " @approved_by=" + filterstring(ReadSession().Emp_Id.ToString()) 
                                                    + ", @OtRequest_id=" + filterstring(rowid) + ",@supervisor_approv_time = "+filterstring(period)
                                                    + ", @supervisor_approved_remark = " + filterstring(remark));
               msg="Approved:" + Request.QueryString["rowid"];
            }
            
            else if (flag == "reject")
            {
                string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='rr'," + " @approved_by=" + filterstring(ReadSession().Emp_Id.ToString()) 
                                                            + ", @OtRequest_id=" + filterstring(rowid) + ",@supervisor_approv_time = " + filterstring(period)
                                                            + ", @supervisor_approved_remark = " + filterstring(remark));
                msg = "Rejected:" + Request.QueryString["rowid"];
            }
                //done by bibhut for hardship
            #region
            else if (flag == "HDapproved")
            {
                string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='HdA'," + " @approved_by=" + filterstring(ReadSession().Emp_Id.ToString())
                                                    + ", @OtRequest_id=" + filterstring(rowid)
                                                    + ", @supervisor_approved_remark = " + filterstring(remark));
                msg = "Approved";
            }

            else if (flag == "HDreject")
            {
                string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='HdR'," + " @approved_by=" + filterstring(ReadSession().Emp_Id.ToString())
                                                   + ", @OtRequest_id=" + filterstring(rowid)
                                                   + ", @supervisor_approved_remark = " + filterstring(remark));
                msg = "Rejected";
            }
            #endregion

            else if (flag == "hrApproveTime")
            {
                  string SQL = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='h',@hr_approve_time=" + filterstring(period) + ","
                + "@ot_rate_id=" + filterstring(OtRateId) + ", @hr_paid_remark=" + filterstring(remark) + ","
                + "@OtRequest_id=" + filterstring(rowid.ToString()) + ",@EMPLOYEEID=" + empId + ",@paid_id=" + filterstring(ReadSession().Sessionid) + ",@user="+ filterstring(ReadSession().Emp_Id.ToString())+" ");

                  string result = "<input readonly = \"readonly\" type=\"text\" size=\"7\" name=\"amount\" id=\"amount_" + rowid + "\" value = \"" + SQL + "\">";
                  Response.Write(result);
  
            }
            else if (flag == "hrhs")
            {
                string amount = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='hs',@OtRequest_id=" + filterstring(rowid) + ",@EMPLOYEEID=" + empId + ",@paid_id=" + filterstring(ReadSession().Sessionid) 
                    + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + " ");
                
                string result = "<input readonly = \"readonly\" type=\"text\" size=\"7\" name=\"amount\" id=\"amount_" + rowid + "\" value = \"" + amount + "\">";
                Response.Write(result);
            }

            else if (flag == "hrhr")
            {
                string sql = CLsDAo.GetSingleresult("Exec [proc_OverTimeDetails] @Flag='Hr',@OtRequest_id=" + filterstring(rowid) + ",@EMPLOYEEID=" + empId + ",@paid_id=" + filterstring(ReadSession().Sessionid)
                    + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + " ");
                msg = "Rejected";
            }
            Response.Write(msg);
            Response.End();
        }
    }
}
