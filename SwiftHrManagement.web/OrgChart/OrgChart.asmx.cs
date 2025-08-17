using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
namespace SwiftHrManagement.web.OrgChart
{
    /// <summary>
    /// Summary description for OrgChart
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrgChart : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string getOrgData()
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
            return json;
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
