using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.LetterTemplate
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        clsDAO _clsDao = new clsDAO();
        string DetailContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 128) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (getltId() > 0)
                {

                    populateData(getltId().ToString());
                
                }
            }
            DisplayKeyWord();

        }
        protected DataSet populateData()
        {
            return _clsDao.getDataset("Exec proc_LetterTempleteDetails @flag='s',@lt_id=" + getltId() + "");
       

        }
        private string populateData(string ltId)
        {
            
             DataTable dt = new DataTable();
            dt =  _clsDao.getDataset("Exec proc_LetterTempleteDetails @flag='s',@lt_id=" + ltId + "").Tables[0];

            //if (dt == null)
            //    return;
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];

            }

            txtLetterType.Text = dr["letter_type"].ToString();

            return txtLetterType.Text;

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DetailContent = Request.Form["textarea2"] != null ? Request.Form["textarea2"].ToString() : "";
            ManageData();

        }
        protected long getltId()
        {
            return (Request.QueryString["lt_id"] != null ? long.Parse(Request.QueryString["lt_id"].ToString()) : 0);
        }
        private void ManageData()
        {
            
            _clsDao.runSQL("Exec [proc_LetterTempleteDetails] @flag="+ (getltId().ToString() =="0" ? "'i'" : "'u'")+",@letter_type="+filterstring(txtLetterType.Text)+",@letter_detail="+filterstring(DetailContent)+""
            + ",@created_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@lt_id="+getltId()+"");
            Response.Redirect("/LetterTemplate/List.aspx");

        }
        private void DisplayKeyWord()
        {

            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("exec [proc_LetterTempleteDetails] 'k'").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th nowrap=\"nowrap\" align=\"left\" style=\"font-size:15px; color:#993300;\">" + dt.Columns[i].ColumnName + "</th>");
            }
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                //str.Append("<td align=\"left\"><span style = \"cursor:pointer\" onclick = \"insertData('" + dr[0].ToString() + "')\">" + dr[0].ToString() + "</span></td>");
                str.Append("<td align=\"left\" nowrap='nowrap' style=\"font-size:11px; color:#993300;\">" + dr[0].ToString() + "</td>");
                str.Append("<td align=\"left\" nowrap='nowrap' style=\"font-size:11px; color:#993300;\">" + dr[1].ToString() + "</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            KeywordDiv.InnerHtml = str.ToString();

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/LetterTemplate/List.aspx");


        }
    }
}
