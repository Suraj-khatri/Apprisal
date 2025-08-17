using System;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class rptForUploadGL_trial : BasePage
    {
        clsDAO _clsdao = null;
        public rptForUploadGL_trial()
        {
            this._clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();
        }
        void LoadHTML()
        {
            string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString(); ;
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            var sql = "exec [procPayrollUploadGL_Trial] 'a'," + filterstring(year) + "," + filterstring(month) + "";
         

            var sb = _clsdao.Table2Text(sql, "\n", ",", true);

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/Excel";
            Response.AddHeader("Content-Disposition", "inline; filename=batch_upload.csv");
            Response.Write(sb);
            return;

        }
    }
}
