using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.StaticDataDetailsDAO;
using SwiftHrManagement.DAL;
namespace SwiftHrManagement.web
{
    public class StaticPage : BaseDAOInv
    {
        StaticDataDetailsDAO _staticDao = null;
        public StaticPage()
        {
            this._staticDao = new StaticDataDetailsDAO();
        }
        public static void SetTimeDDL(ref DropDownList ddl, string value2beSelected, string defValue, bool isHour)
        {
            ListItem item = null;

            ddl.Items.Clear();

            if (defValue != "")
            {
                item = new ListItem(defValue, "");
                ddl.Items.Add(item);
            }
            for (var i = 0; i < (isHour ? 24 : 60); i++)
            {
                item = new ListItem();
                item.Value = i.ToString();
                item.Text = i.ToString();

                if (i.ToString() == value2beSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }

        }
        public void setDDL(long id, ref DropDownList ddl, string sql, string valueField, string textField, string value2beSelected, string defValue)
        {
            //public String StaticDdlQuery = (");
            DataTable dt = SelectByQuery("select DETAIL_TITLE from StaticDataDetail where TYPE_ID = "+ id +" ORDER BY DETAIL_TITLE ASC");
            ListItem item = null;

            ddl.Items.Clear();

            if (defValue != "")
            {
                item = new ListItem(defValue, "0");
                ddl.Items.Add(item);
            }
            foreach (DataRow row in dt.Rows)
            {
                item = new ListItem();
                item.Value = row[valueField].ToString();
                item.Text = row[textField].ToString();

                if (row[valueField].ToString().ToUpper() == value2beSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }
        }
        public string getColorName(string colorCode)
        {
            return ConfigurationSettings.AppSettings[colorCode].ToString();

        }
        public DateTime getStartEndTime(string TimeType)
        {
            return Convert.ToDateTime(ConfigurationSettings.AppSettings[TimeType]);

        }
        public string getTolerateTime(string tolerateTime)
        {
            return ConfigurationSettings.AppSettings[tolerateTime].ToString();


        }
        public string GetTime(string timeType)
        {
            return ConfigurationSettings.AppSettings[timeType].ToString();

        }

        public DataTable GetEmpInfoById(string empId)
        {
            var sql = "SELECT FIRST_NAME +' '+MIDDLE_NAME +' '+ LAST_NAME + ' | '+ CAST(EMPLOYEE_ID as varchar) empName"
                      + ",dbo.GetBranchName(BRANCH_ID) branch"
                      + " ,dbo.GetDeptName(DEPARTMENT_ID) dept FROM Employee WHERE EMPLOYEE_ID = " + empId;

            return ExecuteDataset(sql).Tables[0];


        }

        #region 'Override Methods'
            public override void Save(object obj)
            {
                throw new NotImplementedException();
            }
            public override void Update(object obj)
            {
                throw new NotImplementedException();
            }
            public override object MapObject(DataRow dr)
            {
                throw new NotImplementedException();
            }
        #endregion

    }
}
