using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace SwiftHrManagement.web.OrgChart
{
    public partial class OrgChart1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqMethod = Request.Form["MethodName"];
            if (!Page.IsPostBack)
            {
                #region Ajax methods
                switch (reqMethod)
                {
                    case "data":
                        GetData();
                        break;
                }
                #endregion
            }
        }
        public void GetData()
        {
            List<Helper.Google_org_data> g = new List<Helper.Google_org_data>();
            DataTable myData = getDataTable();

            g.Add(new Helper.Google_org_data
            {
                Employee = "Rocky Balboa",
                Manager = "",
                mgrID = "",
                empID = "13",
                designation = "CEO"
            });

            foreach (DataRow row in myData.Rows)
            {
                string empName = row["EmpName"].ToString();
                var mgrName = row["MgrName"].ToString();
                var mgrID = row["mgrID"].ToString();
                var empID = row["empID"].ToString();
                var designation = row["designation"].ToString();

                g.Add(new Helper.Google_org_data
                {
                    Employee = empName,
                    Manager = mgrName,
                    mgrID = mgrID,
                    empID = empID,
                    designation = designation
                });
            }
            var json = new JavaScriptSerializer().Serialize(g);
            Response.Write(json);
            Response.End();
        }
        public DataTable getDataTable()
        {
            string query = @"select a.employee_name as EmpName,a.id_emp as empID,a.designation,b.employee_name as MgrName,b.id_emp as mgrID
            from OrganizationChart a inner join OrganizationChart b on a.manager_id=b.id_emp";
            clsDAO clsDao = new clsDAO();
            return clsDao.getTable(query);
        }
    }
}