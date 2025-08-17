using System;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.LetterTemplate
{
    public partial class LetterSearch : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        private string empId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 166) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropDownList();
            }
            empId = Request.Form["ctl00$MainPlaceHolder$Ddlassigned"]; 
        }

        private void PopulateDropDownList()
        {
            _clsDao.CreateDynamicDDl(DdlDocType, "SELECT lt_id,letter_type FROM LetterTempleteDetails WHERE 1=1", "lt_id", "letter_type", "", "select");
            _clsDao.CreateDynamicDDl(DdlBranch, "Select BRANCH_ID,BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
            _clsDao.CreateDynamicDDl(DdlPosition, "Exec [ProcStaticDataView] @flag='b',@type_id='4'", "ROWID", "DETAIL_TITLE", "", "ALL");
        }
       
        protected void DdlBranch_SelectedIndexChanged1(object sender, EventArgs e)
        {
            _clsDao.CreateDynamicDDl(DdlUnassigned, "select Employee_id,first_name+isnull(' '+middle_name+' ',' ')+isnull(last_name,' ') Name from Employee where " +
                                                    "employee_id<>1000 AND position_id=isnull(" + filterstring(DdlPosition.Text) + ",position_id) AND " +
                                                    "branch_id=isnull(" + filterstring(DdlBranch.Text) + ",branch_id) order by Name", "Employee_id", "Name", "", "");
        }

        protected void DdlPosition_SelectedIndexChanged1(object sender, EventArgs e)
        {
            _clsDao.CreateDynamicDDl(DdlUnassigned, "select Employee_id,first_name+isnull(' '+middle_name+' ',' ')+isnull(last_name,' ') Name from Employee where " +
                                        "employee_id<>1000 AND position_id=isnull(" + filterstring(DdlPosition.Text) + ",position_id) AND " +
                                        "branch_id=isnull(" + filterstring(DdlBranch.Text) + ",branch_id) order by Name", "Employee_id", "Name", "", "");
        }

        protected void btnGenerate_Click1(object sender, EventArgs e)
        {
            if (DdlDocType.Text == "" || empId.Length==0)
            {
                DocType.Text = "Required";
                assigned.Text = "Required";

                DocType.ForeColor = System.Drawing.Color.Red;
                assigned.ForeColor = System.Drawing.Color.Red;
                return;

            }

            Response.Redirect("LetterReport.aspx?DocType=" + DdlDocType.Text + "&EmpId=" + empId + "");
        }
    }
}
