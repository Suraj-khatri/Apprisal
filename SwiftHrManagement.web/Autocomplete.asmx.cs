using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Web.Services;
using SwiftHrManagement.web;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using SwiftHrManagement.web.Model;
using System.Web;
using SwiftHrManagement.DAL;
using System.Linq;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : BasePage
{
    BasePage BSPG = null;

    private string Crypto(string value, bool isEncrypt = true)
    {
        //Uri.EscapeDataString(Crypto(item["EMPLOYEE_ID"].ToString()))
        var forReturn = "";
        if (isEncrypt)
            forReturn = Cryptographer.Encrypt(value, Cryptographer.PrivateKey());
        else
            forReturn = Cryptographer.Decrypt(value, Cryptographer.PrivateKey());

        return forReturn;
    }
    public AutoComplete()
    {
        BSPG = new BasePage();
    }
    [WebMethod]
    public string[] GetEmployeeList(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("Exec proc_In_listemployeeName @fname=" + BSPG.filterstring(prefixText), con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EmployeeName"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetEmployeeListJD(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;
        string sql = "";
        sql = "Exec proc_In_listemployeeName @fname=" + BSPG.filterstring(prefixText) + ",@empId=" + BSPG.filterstring(contextKey) + ",@flag=J";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EmployeeName"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetSupervisorList(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;
        string sql = "";
        sql = "Exec proc_In_listemployeeName @fname=" + BSPG.filterstring(prefixText) + ",@empId=" + BSPG.filterstring(contextKey) + ",@flag=s";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EmployeeName"].ToString(), i);
            i++;
        }
        return items;
    }


    [WebMethod]
    public string[] GetEmployeeListAppraisal(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;
        string sql = "";
        if (string.IsNullOrEmpty(contextKey))
            sql = "Exec proc_In_listemployeeName @fname=" + BSPG.filterstring(prefixText) + "";
        else
            sql = "Exec proc_In_listemployeeName @fname=" + BSPG.filterstring(prefixText) + ",@empId=" + BSPG.filterstring(contextKey) + ",@flag=a";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EmployeeName"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetEmployeeListByNameORId(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("EXEC proc_GetLeaveData @jobflag = 'SE',@searchEmpBy = " + BSPG.filterstring(prefixText), con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EMPLOYEE_NAME"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetAccountList(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("SELECT top " + count + " acct_name +'|'+ acct_num as acct_name ,acct_num FROM ac_master  where acct_name like " + BSPG.filterstring(@prefixText + "%") + " order by acct_name", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["acct_name"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]

    public string[] GetCustomerListForWorkflow(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        //if (count == 0)

        SqlDataAdapter da = new SqlDataAdapter("SELECT ID,CUSTOMERNAME+'-'+CUSTOMERCODE+'|'+cast(ID as varchar) as CUSTOMERNAME FROM WF_CUSTOMER  where CUSTOMERNAME like '" + @prefixText + "' +'%'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CUSTOMERNAME"].ToString(), i);
            i++;
        }
        return items;
    }
    //****************Auto Complete For Asset Inventory Starts******************************
    [WebMethod]
    public string[] GetProductList(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter(" Exec prcDisplayProduct @branch='" + contextKey + "' ,@product='" + prefixText + "' ", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["PRODUCT"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetProductList1(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("Exec procDisplayProductAll @product=" + filterstring(prefixText) + "", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["PRODUCT"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetAssetType(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("SELECT top 20 porduct_code, porduct_code+' ('+product_desc +') |'+CAST(a.id AS VARCHAR) AS asset_type FROM ASSET_PRODUCT a inner join ASSET_BRANCH b on a.id=b.PRODUCT_ID WHERE porduct_code like '" + @prefixText + "' +'%' order by porduct_code ASC", con);
        //da.SelectCommand.Parameters.Add("@prefixText", prefixText);

        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["asset_type"].ToString(), i);
            i++;
        }
        return items;
    }


    [WebMethod]
    public string[] GetAssetTypeBranchWise(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("SELECT top 20 porduct_code, porduct_code+' ('+product_desc +') |'+CAST(a.id AS VARCHAR) AS asset_type" +
            " FROM ASSET_PRODUCT a inner join ASSET_BRANCH b on a.id=b.PRODUCT_ID " +
            "WHERE BRANCH_ID=" + BSPG.filterstring(contextKey) + " and porduct_code like " + BSPG.filterstring(@prefixText + "%") + " order by porduct_code ASC", con);

        //BRANCH_ID=" + filterstring(contextKey) + " and
        //da.SelectCommand.Parameters.Add("@prefixText", prefixText);

        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["asset_type"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetAssetNumber(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("select top 20 asset_number + '|' + CONVERT(varchar, id) as 'Assetnumber' from ASSET_INVENTORY "
        + " where  asset_number like  '" + @prefixText + "' +'%' order by product_id", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Assetnumber"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetAssetNumberForGatepass(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("select top 20 asset_number + '|' + CONVERT(varchar, id) as 'Assetnumber' from ASSET_INVENTORY where "
        + " isnull(in_out,'') <> 'o' and asset_number like  " + BSPG.filterstring(@prefixText + "%") + " and branch_id =" + filterstring(contextKey) + " order by product_id", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Assetnumber"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetAssetInventoryDetailyAssetNo(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("Exec proc_Get_AssetNumbers @PREFIX='" + prefixText + "' ", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["ASSET_NUMBER"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetInsuranceLinkage(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("SELECT A.ID,S.DETAIL_TITLE+'-'+CONVERT(VARCHAR,A.insured_date,107)+'|'+CAST(A.id AS VARCHAR) AS INSURANCE FROM ASSET_INSURENCE A INNER JOIN "
            + " StaticDataDetail S ON S.ROWID=A.insurer WHERE S.DETAIL_TITLE LIKE  " + BSPG.filterstring(@prefixText + "%") + " order by A.ID ASC", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["INSURANCE"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetBillLinkage(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("select a.id,cast(a.bill_no as varchar)+' - '+c.CustomerName+' ('+CONVERT(varchar,bill_date,107)+') |'+cast(a.id as varchar) as bill_info"
        + " from ASSET_BILL a inner join Customer c on c.ID=a.vendor_id where a.bill_no like " + BSPG.filterstring(@prefixText + "%") + " order by a.id ASC", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["bill_info"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetVendor(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("SELECT ID,CUSTOMERNAME + '-' + CUSTOMERCODE + '|' + convert(varchar,ID) as CUST_NAME FROM CUSTOMER  " +
            " where CUSTOMERNAME like " + BSPG.filterstring(@prefixText + "%") + " OR CUSTOMERCODE like " + BSPG.filterstring(@prefixText + "%") + " and IsActive='Y' order by ID ", con);

        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CUST_NAME"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetVendorProductList(string prefixText, int count, string contextKey)
    {
        string[] a = contextKey.Split('|');
        string vendor_id = a[0];
        string branch_id = a[1];

        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("Exec procDisplayProduct @branch='" + branch_id + "' ,@product='" + prefixText + "' ,@vendor='" + vendor_id + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["product"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetEmployeeExtensionList(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("select FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME + '|' +CONVERT(varchar, EXTENSION_NUMBER )'Empname', EXTENSION_NUMBER from Employee "
        + " where FIRST_NAME like " + BSPG.filterstring(prefixText + "%"), con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Empname"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetHODnBMList(string prefixText, int count)
    {
        string sql = "select FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME+'-'+EMP_CODE+' '+BRANCH_NAME+' '+DEPARTMENT_NAME+'('"
                        + " +DETAIL_DESC+')|'+cast(EMPLOYEE_ID as varchar(10))as employee "
                        + " from Employee E "
                        + " join StaticDataDetail S on E.POSITION_ID=S.ROWID "
                        + " join Branches B on E.BRANCH_ID=B.BRANCH_ID "
                        + " join Departments D on E.DEPARTMENT_ID=D.DEPARTMENT_ID "
                        + " where POSITION_ID in (650,651) and FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME like "
                        + BSPG.filterstring(prefixText + "%");
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["employee"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetApprovedBy(string prefixText, int count)
    {
        string sql = "select distinct EMPLOYEE_ID,a.EmpName+'-'+BRANCH_NAME+' '+DEPARTMENT_NAME+ "
                    + " +'|'+cast(EMPLOYEE_ID as varchar(10)) as EmpName from ( "
                    + " SELECT EMPLOYEE_ID,FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME  "
                    + " AS EmpName ,BRANCH_ID,DEPARTMENT_ID "
                    + " FROM Employee E  "
                    + " WHERE EMPLOYEE_ID<>'1000' and emp_status='458' ) a "
                    + " join Branches B on a.BRANCH_ID=B.BRANCH_ID "
                    + " join Departments D on a.DEPARTMENT_ID=D.DEPARTMENT_ID "
                    + " where EmpName like " + BSPG.filterstring(prefixText + "%")
                    + "  order by EmpName ";

        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["EmpName"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetOldNewAssetNumber(string prefixText, int count, string contextKey)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;
        string branch = contextKey.Split(',')[0];
        string dept = contextKey.Split(',')[1];
        string group = contextKey.Split(',')[2];
        string type = contextKey.Split(',')[3];
        string brand = contextKey.Split(',')[4];
        string sql = "select top 20 asset_number + '|' + old_asset_no as 'Assetnumber' from ASSET_INVENTORY "
        + " where  asset_number like  '" + @prefixText + "' +'%'";

        if (!string.IsNullOrEmpty(branch))
            sql = sql + " and branch_id='" + branch + "'";
        if (!string.IsNullOrEmpty(dept))
            sql = sql + "and dept_id='" + dept + "'";
        if (!string.IsNullOrEmpty(group))
            sql = sql + "and group_id='" + group + "'";
        if (!string.IsNullOrEmpty(type))
            sql = sql + "and branch_id='" + type + "'";
        if (!string.IsNullOrEmpty(brand))
            sql = sql + "and brand like '%" + brand + "%'";

        sql = sql + " order by product_id";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Assetnumber"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetBrandName(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        count = 20;

        SqlDataAdapter da = new SqlDataAdapter("select distinct top 20 brand as 'BrandName' from ASSET_INVENTORY "
        + " where  brand like  '" + @prefixText + "' +'%' order by brand", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["BrandName"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetVendor_test(string prefixText, int count)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("SELECT ID,CUSTOMERNAME + '-' + CUSTOMERCODE + '|' + convert(varchar,ID) as CUST_NAME FROM CUSTOMER  " +
            " where CUSTOMERNAME like " + BSPG.filterstring(@prefixText + "%") + " OR CUSTOMERCODE like " + BSPG.filterstring(@prefixText + "%") + " and IsActive='Y' order by ID ", con);

        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CUST_NAME"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    #region ApprisalApi
    public void FiscalList()
    {
        List<ListItem> Result = new List<ListItem>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("Select  FISCAL_YEAR_ID,FISCAL_YEAR_NEPALI from FiscalYear where flag IS NOT NULL order by FISCAL_YEAR_NEPALI", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            Result.Add(new ListItem { Text = dr["FISCAL_YEAR_NEPALI"].ToString(), Value = dr["FISCAL_YEAR_ID"].ToString() });

        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));

    }
    [WebMethod(EnableSession = true)]
    public void ApprisalStatusList(int id)
    {
        List<ApprisalStatus> Result = new List<ApprisalStatus>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT Id,Title,Description,Code  FROM ApprisalStatus WHERE StatusGroup=" + id, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i = i + 1;
            Result.Add(new ApprisalStatus
            {
                Sn = i,
                Text = dr["Title"].ToString(),
                Value = Convert.ToInt32(dr["Id"].ToString()),
                Description = dr["Description"].ToString(),

            });

        }
         if (id == 1)
            {
                Result.Add(new ApprisalStatus
                {
                    Sn = 999,
                    Text = "PA Complete",
                    Value = 999,
                    Description = "PA Complete ",

                });
            
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void PerformanceAgreement()
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        bool IsAdmin = CheckHrAdmin();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = "";

        if (IsAdmin)
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPA'";
        }
        else
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='PAforuser'";
        }



        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);


        int i = 1;


        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    statusCode = Convert.ToInt32(dr["Code"].ToString()),
                    Supervisor = dr["Supervisor"].ToString(),
                    Reviewer = dr["Reviewer"].ToString(),
                    flag = dr["FLAG"].ToString()
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result.Where(x => x.flag == "True").OrderByDescending(x => x.AppId)));

    }
    [WebMethod(EnableSession = true)]
    public void FilterAgreement(int Fiscal, int Emp, int Status)
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        bool IsAdmin = CheckHrAdmin();
        string sql = "";

        if (IsAdmin)
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPA'";
        }
        else
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='PAforuser'";
        }


        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    statusCode = Convert.ToInt32(dr["Code"].ToString()),
                    Supervisor = dr["Supervisor"].ToString(),
                    Reviewer = dr["Reviewer"].ToString(),
                    FiscalId = Convert.ToInt32(dr["Fiscal_Year_Id"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result.Where(x => x.statusCode == (Status == 0 ? x.statusCode : Status) && x.FiscalId == (Fiscal == 0 ? x.FiscalId : Fiscal)).OrderByDescending(x => x.AppId)));
    }
    [WebMethod(EnableSession = true)]
    public void PerformanceReview()
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        bool IsAdmin = CheckHrAdmin();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = "";

        if (IsAdmin)
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPR'";
        }
        else
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId= " + ReadSession().Emp_Id + ",@flag='PRforuser'";
        }



        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);


        int i = 1;


        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    Supervisor = dr["Supervisor"].ToString(),
                    Reviewer = dr["Reviewer"].ToString(),
                    flag = dr["FLAG"].ToString()
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result.Where(x => x.flag == "True").OrderByDescending(x => x.AppId)));
    }
    [WebMethod(EnableSession = true)]
    public void FilterReview(int Fiscal, int Emp, int Status)
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        bool IsAdmin = CheckHrAdmin();
        string sql = "";

        if (IsAdmin)
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPR'";
        }
        else
        {
            sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='PRforuser'";
        }


        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {
            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    statusCode = Convert.ToInt32(dr["Code"].ToString()),
                    Supervisor = dr["Supervisor"].ToString(),
                    Reviewer = dr["Reviewer"].ToString(),
                    FiscalId = Convert.ToInt32(dr["Fiscal_Year_Id"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result.Where(x => x.statusCode == (Status == 0 ? x.statusCode : Status) && x.FiscalId == (Fiscal == 0 ? x.FiscalId : Fiscal)).OrderByDescending(x => x.AppId)));
    }
    [WebMethod(EnableSession = true)]
    public void JobDescription(string ststus)
    {
        List<JobDescription> Result = new List<JobDescription>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        bool IsAdmin = CheckHrAdminJD(null);
        con.ConnectionString = connstring;
        con.Open();
        string sql;
        if (IsAdmin)
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(J.supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'A',
                                         'N',
                                         'D')  
                          AND f.FLAG=1 AND IsDeleted=0";
        }
        else if (ststus == "List")
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'A',
                                         'N',
                                         'D')  
                          AND f.FLAG=1 AND( IsDeleted=0 OR IsDeleted IS NULL)
                          AND j.EmpId=" + ReadSession().Emp_Id + "";


        }
        else
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                          'A',
                                         'N',
                                         'D')  
                          AND f.FLAG=1 AND IsDeleted=0
                          AND j.SupervisorId=" + ReadSession().Emp_Id + "";
        }

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new JobDescription
                {
                    Sn = i,
                    EmployeeName = dr["Employee"].ToString(),
                    EndDate = dr["endDate"].ToString(),
                    SupervisorName = dr["Supervisor"].ToString(),
                    StatrtDate = dr["startDate"].ToString(),
                    Sataus = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["rowId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["Status"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["rowId"].ToString()),
                    Branch = dr["Branch"].ToString(),
                    FiscalYear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    Position = dr["Position"].ToString(),
                    FiscalId = Convert.ToInt32(dr["FISCAL_YEAR_ID"].ToString()),
                }
                );

            i++;
        }
        
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void FilterJobDescription(string status, int fiscal, int EmpId)
    {
        List<JobDescription> Result = new List<JobDescription>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        bool IsAdmin = CheckHrAdminJD(null);
        string Emp = EmpId == 0 ? "NULL" : EmpId.ToString();
        con.ConnectionString = connstring;
        con.Open();
        string sql;
        if (IsAdmin)
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'A',
                                         'N',
                                         'D')  
                          AND f.FISCAL_YEAR_ID=" + fiscal + @"AND 
                           IsDeleted=0 ";
        }
        else if (status == "List")
        {
            sql = @"SELECT j.rowId,
                    E.EMPLOYEE_ID,
                    E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                    dbo.GetBranchName(branchId) Branch,
                    dbo.GetPosOfId(positionId) POSITION,
                    dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                    CONVERT(VARCHAR,j.startDate, 107) startDate,
                    CONVERT(VARCHAR,j.endDate, 107) endDate,
                    [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                    F.FISCAL_YEAR_ID,
                    F.FISCAL_YEAR_NEPALI
                    FROM jobDescription j
                    INNER JOIN dbo.Employee E 
                    ON j.empId = E.EMPLOYEE_ID
                    INNER JOIN FiscalYear F 
                    ON f.FISCAL_YEAR_ID=j.FiscalId
                    WHERE j.flag IN ('Y','A','N','D')  
                    AND f.FISCAL_YEAR_ID=" + fiscal + @"
                    AND IsDeleted=0 AND j.EmpId=" + ReadSession().Emp_Id;


        }
        else
        {
            sql = @"SELECT j.rowId,
                    E.EMPLOYEE_ID,
                    E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                    dbo.GetBranchName(branchId) Branch,
                    dbo.GetPosOfId(positionId) POSITION,
                    dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                    CONVERT(VARCHAR,j.startDate, 107) startDate,
                    CONVERT(VARCHAR,j.endDate, 107) endDate,
                   [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                    F.FISCAL_YEAR_ID,
                    F.FISCAL_YEAR_NEPALI
                    FROM jobDescription j
                    INNER JOIN dbo.Employee E 
                    ON j.empId = E.EMPLOYEE_ID
                    INNER JOIN FiscalYear F 
                    ON f.FISCAL_YEAR_ID=j.FiscalId
                    WHERE j.flag IN ('Y','A','N','D')
                    AND IsDeleted=0  
                    AND f.FISCAL_YEAR_ID=" + fiscal + @"
                    AND j.supervisorId=" + ReadSession().Emp_Id + @"
                    AND j.supervisorId =" + ReadSession().Emp_Id;
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new JobDescription
                {
                    Sn = i,
                    EmployeeName = dr["Employee"].ToString(),
                    EndDate = dr["endDate"].ToString(),
                    SupervisorName = dr["Supervisor"].ToString(),
                    StatrtDate = dr["startDate"].ToString(),
                    Sataus = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["rowId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["Status"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["rowId"].ToString()),
                    Branch = dr["Branch"].ToString(),
                    FiscalYear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    Position = dr["Position"].ToString(),
                    FiscalId = Convert.ToInt32(dr["FISCAL_YEAR_ID"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void ReviewInitiation()
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();


        string sql = @"SELECT * FROM (
                    SELECT AI.employeeid  AS EMPLOYEE_ID, 
                           dbo.Getemployeefullnameofid(AI.employeeid)   AS EMPNAME, 
                           AI.appraisalid, 
                           CONVERT(VARCHAR, AI.appraisalstartdate, 101) AS AppraisalStartDate, 
                           CONVERT(VARCHAR, AI.appraisalenddate, 101)   AS AppraisalEndDate, 
	                       AI.supervisorId,
                           fy.fiscal_year_nepali, 
                           at.title 'Status', 
                           ai.status 'Code', 
                           isdeleted 
                    FROM   appraisalinitation ai WITH ( NOLOCK )
                       JOIN employee E WITH ( NOLOCK )
                         ON ai.employeeid = e.employee_id 
                       JOIN fiscalyear Fy WITH ( NOLOCK )
                         ON Fy.fiscal_year_id = ai.fiscalyear 
                       JOIN apprisalstatus at WITH ( NOLOCK )
                         ON Ai.status = at.code 
                WHERE  status = 1 
                       AND (isdeleted IS NULL OR isdeleted = 0 )
                         AND (Fy.FLAG = 1)
                        )
                        
	                   X WHERE X.supervisorId =ISNULL(" + ReadSession().Emp_Id + @",x.supervisorId)
                        
		                OR ((SELECT DISTINCT 'A'
                                         FROM   dbo.user_role r
                                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                                         WHERE  s.TYPE_ID = '25'
                                                  AND s.DETAIL_TITLE = 'HR Admin'
                                                AND a.Name = " + ReadSession().Emp_Id + @") = 'A')   ";

        
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    AppId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void AdminJdList()
    {
        List<JobDescription> Result = new List<JobDescription>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();

        con.ConnectionString = connstring;
        con.Open();
        bool IsAdmin = CheckHrAdminJD(null);
        string sql="";
        if (IsAdmin)
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'A',
                                         'N',
                                         'D')  
                         AND IsDeleted=0 AND F.FLAG is not null";
        }else
        {
            sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'A',
                                         'N',
                                         'D')  
                         AND IsDeleted=0 AND F.FLAG is not null
                        AND  (j.supervisorId="+ ReadSession().Emp_Id +@" or j.empId=" + ReadSession().Emp_Id +@")
                        ";
        }
        
        
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new JobDescription
                {
                    Sn = i,
                   
                    EmployeeName = dr["Employee"].ToString(),
                    EndDate = dr["endDate"].ToString(),
                    SupervisorName = dr["Supervisor"].ToString(),
                    StatrtDate = dr["startDate"].ToString(),
                    Sataus = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["rowId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["Status"].ToString())),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["rowId"].ToString()),
                    Branch = dr["Branch"].ToString(),
                    FiscalYear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    Position = dr["Position"].ToString(),
                    FiscalId = Convert.ToInt32(dr["FISCAL_YEAR_ID"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void FilterReviewInitiation(int Fiscal, int Emp)
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();

        using (SqlConnection con = new SqlConnection(connstring))
        {
            con.Open();

            bool IsAdmin = CheckHrAdmin();
            string sql = "";

            if (IsAdmin)
            {
                sql = @"SELECT * FROM (
                        SELECT AI.employeeid  AS EMPLOYEE_ID, 
                               dbo.Getemployeefullnameofid(AI.employeeid)   AS EMPNAME, 
                               AI.appraisalid, 
                               CONVERT(VARCHAR, AI.appraisalstartdate, 101) AS AppraisalStartDate, 
                               CONVERT(VARCHAR, AI.appraisalenddate, 101)   AS AppraisalEndDate, 
                               AI.supervisorId,
                               FISCAL_YEAR_ID,						  
                               fy.fiscal_year_nepali, 
                               at.title 'Status', 
                               ai.status 'Code', 
                               isdeleted 
                        FROM   appraisalinitation ai WITH (NOLOCK)
                        JOIN employee E WITH (NOLOCK) ON ai.employeeid = e.employee_id 
                        JOIN fiscalyear Fy WITH (NOLOCK) ON Fy.fiscal_year_id = ai.fiscalyear 
                        JOIN apprisalstatus at WITH (NOLOCK) ON Ai.status = at.code 
                        WHERE status = 1 
                        AND (isdeleted IS NULL OR isdeleted = 0)) X 
                    WHERE X.Fiscal_Year_Id = ISNULL(@fiscal, X.Fiscal_Year_Id)";
            }
            else
            {
                sql = @"SELECT * FROM (
                        SELECT AI.employeeid  AS EMPLOYEE_ID, 
                               dbo.Getemployeefullnameofid(AI.employeeid)   AS EMPNAME, 
                               AI.appraisalid, 
                               CONVERT(VARCHAR, AI.appraisalstartdate, 101) AS AppraisalStartDate, 
                               CONVERT(VARCHAR, AI.appraisalenddate, 101)   AS AppraisalEndDate, 
                               AI.supervisorId,
                               FISCAL_YEAR_ID,						  
                               fy.fiscal_year_nepali, 
                               at.title 'Status', 
                               ai.status 'Code', 
                               isdeleted 
                        FROM   appraisalinitation ai WITH (NOLOCK)
                        JOIN employee E WITH (NOLOCK) ON ai.employeeid = e.employee_id 
                        JOIN fiscalyear Fy WITH (NOLOCK) ON Fy.fiscal_year_id = ai.fiscalyear 
                        JOIN apprisalstatus at WITH (NOLOCK) ON Ai.status = at.code 
                        WHERE status = 1 
                        AND (isdeleted IS NULL OR isdeleted = 0)) X 
                    WHERE X.supervisorId = ISNULL(" + +ReadSession().Emp_Id + @",x.supervisorId)
                    AND X.Fiscal_Year_Id = ISNULL(@fiscal, X.Fiscal_Year_Id)";
            }

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                // Add parameters for fiscal year and employee ID
                cmd.Parameters.AddWithValue("@fiscal", Fiscal == 0 ? (object)DBNull.Value : Fiscal);
                cmd.Parameters.AddWithValue("@empId", Emp == 0 ? (object)DBNull.Value : Fiscal);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new PerformanceAgreement
                        {
                            Sn = i,
                            AppriseeName = dr["EMPNAME"].ToString(),
                            EndDate = dr["AppraisalEndDate"].ToString(),
                            Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                            StartDate = dr["AppraisalStartDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                            EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                            EmpId = Convert.ToInt32(dr["appraisalId"].ToString()),
                            AppId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                        }
                    );
                    i++;
                }
            }
        }

        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }

    [WebMethod(EnableSession = true)]
    public bool CheckHrAdmin()
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND s.DETAIL_TITLE = 'HR Admin'
                                AND a.Name = " + ReadSession().Emp_Id;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int count = dt.Rows.Count;
        if (count > 0)
        {
           return true;
        }
        else
        {
          return false;
        }

    }

    [WebMethod(EnableSession = true)]
    public void ISHrAdmin()
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND s.DETAIL_TITLE = 'HR Admin'
                                AND a.Name = " + ReadSession().Emp_Id;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int count = dt.Rows.Count;
        if (count > 0)
        {
       
            JavaScriptSerializer Js = new JavaScriptSerializer();          
            Context.Response.Write(Js.Serialize(true));
        }
        else
        {
            JavaScriptSerializer Js = new JavaScriptSerializer();
            Context.Response.Write(Js.Serialize(false));
        }

    }
    [WebMethod]
    public void DiscardAppraisal(int appid, string flag)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = "";
        if (flag == "PA")
        {
            sql = @"UPDATE appraisalInitation set STATUS=5, Isdeleted=1 where appraisalId=" + BSPG.filterstring(appid.ToString());
        }
        else
        {
            sql = @"UPDATE appraisalInitation set STATUS=18,Isdeleted=1 where appraisalId=" + BSPG.filterstring(appid.ToString());
        }

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        try
        {
            Context.Response.Write("Successfully Discarded");
        }
        catch (Exception Ex)
        {

            Context.Response.Write(Ex.Message);
        }

    }
    public bool CheckHrAdminJD(int? empid)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND LOWER(s.value) ='admin'
                                AND a.Name = " + ReadSession().Emp_Id;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int count = dt.Rows.Count;
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    [WebMethod]
    public void ApprsaemplistEmpList(string flag)
    {
        List<ApprisalStatus> Result = new List<ApprisalStatus>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        DataTable dt = new DataTable();
        if (flag == "e")
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct employeeId Id, CONCAT(e.FIRST_NAME,' ',E.MIDDLE_NAME,' ',E.LAST_NAME,' (',b.BRANCH_NAME,')')EmpName from appraisalInitation I JOIN Employee E on I.employeeId=e.EMPLOYEE_ID JOIN Branches B on E.BRANCH_ID=b.BRANCH_ID where i.STATUS < 15", con);
            da.Fill(dt);
        }
        else if (flag == "s")
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct supervisorId Id, CONCAT(e.FIRST_NAME,' ',E.MIDDLE_NAME,' ',E.LAST_NAME,' (',[dbo].[GetBranchName](e.BRANCH_ID),')')EmpName from appraisalInitation I JOIN Employee E on I.supervisorId=e.EMPLOYEE_ID where i.STATUS < 15", con);
            da.Fill(dt);
        }
        else if (flag == "r")
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct reviewerId Id, CONCAT(e.FIRST_NAME,' ',E.MIDDLE_NAME,' ',E.LAST_NAME,' (',[dbo].[GetBranchName](e.BRANCH_ID),')')EmpName from appraisalInitation I JOIN Employee E on I.reviewerId=e.EMPLOYEE_ID where i.STATUS < 15", con);
            da.Fill(dt);
        }
        else if (flag == "all")
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT EMPloyee_Id Id, CONCAT(e.FIRST_NAME, ' ', e.MIDDLE_NAME, ' ', e.LAST_NAME, ' -', EMP_CODE, ' (' + b.BRANCH_NAME + ')')
                AS EMPName FROM Employee e WITH(NOLOCK)
                 INNER JOIN Branches b ON e.BRANCH_ID = b.BRANCH_ID
                 WHERE    e.EMP_STATUS = '458'", con);
            da.Fill(dt);

        }

        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i = i + 1;
            Result.Add(new ApprisalStatus
            {
                Sn = i,
                Text = dr["EmpName"].ToString(),
                Value = Convert.ToInt32(dr["Id"].ToString()),


            });
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod]
    public void AppraisalListTochange(int Id, int EmpId, int SuvId, int RevId)
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        string sql = @"SELECT  DISTINCT AI.employeeId AS EMPLOYEE_ID ,
                    dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EMPNAME,
                    AI.appraisalId ,
                   dbo.GetEmployeeFullNameOfId(AI.supervisorId) AS Supervisor,
                     dbo.GetEmployeeFullNameOfId(AI.reviewerId) AS Reviewer,
                     fy.Fiscal_Year_Id,
                     fy.FISCAL_YEAR_NEPALI,
                     st.Title 'Status',
					 St.Code,
					 Fy.FLAG,
					 Ai.supervisorId,
					ai.reviewerId
                    FROM    dbo.appraisalInitation AI WITH(NOLOCK)
                    INNER JOIN dbo.Employee E WITH(NOLOCK) ON AI.employeeId = E.EMPLOYEE_ID
                    Inner join FiscalYear Fy  on fy.FISCAL_YEAR_ID = AI.FiscalYear
                    Inner join ApprisalStatus st on st.Code = ai.STATUS

                    WHERE Ai.STATUS in (2,3,4,5,6,7,10,11,12,13,14,18,17) AND(AI.IsDeleted IS NULL OR Ai.IsDeleted = 0) and fy.FLAG = 1";

        if (Id != 0)
        {
            sql += "and ai.appraisalId=" + Id.ToString();
        }
        if (EmpId != 0)
        {
            sql+= "AND ai.employeeId=" + EmpId.ToString();
        }
        if (SuvId!=0)
        {
            sql += "AND ai.supervisorId =" + SuvId.ToString();
        }
        if (RevId != 0)
        {
            sql += "AND ai.reviewerId=" + RevId.ToString();
        }
        con.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(dt);

        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    Status = dr["Status"].ToString(),
                    EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                    AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    flag = dr["FLAG"].ToString(),
                    Supervisor = dr["Supervisor"].ToString(),
                    Reviewer = dr["Reviewer"].ToString(),
                    SupervisorId = Convert.ToInt32(dr["supervisorId"].ToString()),
                    ReviewerId = Convert.ToInt32(dr["reviewerId"].ToString())
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result.Where(x => x.flag == "True")));



    }
    [WebMethod]
    public void InfoToUPdate(int appid)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        con.ConnectionString = connstring;
        string sql = @"SELECT
                         a.appraisalId,
                          emp.employee_id EmpId,
                          CONCAT( emp.emp_code , ' | ', dbo.Getemployeefullnameofid(a.employeeid))EmpName,
                         [dbo].[GetBranchName](a.currBranchId) Branch,
                          [dbo].[GetDeptName](a.currDeptId)DeptName,
                          [dbo].[GetDetailTitle](a.currPosition) Position,
                          a.appraisalstartdate StartDate,
                          a.appraisalenddate EndDate,
                          dbo.Getemployeefullnameofid(a.supervisorid) Supervisor,
                          dbo.Getemployeefullnameofid(a.reviewerid) Reviewer,
                          a.reviewerid,
                          a.supervisorid
                        FROM appraisalinitation a (NOLOCK)
                        INNER JOIN dbo.employee emp (NOLOCK)
                          ON emp.employee_id = a.employeeid
                        WHERE a.appraisalId = @AppId";

        sql = sql.Replace("@AppId", appid.ToString());


        con.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(dt);
       
        foreach (DataRow dr in dt.Rows)
        {


            Result.Add(new PerformanceAgreement
            {
                AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                EmpId = Convert.ToInt32(dr["EmpId"].ToString()),
                AppriseeName = dr["EmpName"].ToString(),
                Supervisor = dr["Supervisor"].ToString(),
                Reviewer = dr["Reviewer"].ToString(),
                SupervisorId = Convert.ToInt32(dr["supervisorId"].ToString()),
                ReviewerId = Convert.ToInt32(dr["reviewerId"].ToString()),
                Branch = dr["Branch"].ToString(),
                Department = dr["DeptName"].ToString(),
                Position = dr["Position"].ToString(),
                StartDate = Convert.ToDateTime(dr["StartDate"].ToString()).ToString("MM/dd/yyyy"),
                EndDate = Convert.ToDateTime(dr["EndDate"].ToString()).ToString("MM/dd/yyyy"),

            });

        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod]
    public void UpdateSupervisor(int old, int newsuv, int appid, bool Ok, string flag)
    {
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = "";
        if (flag == "suv")
        {
            if (!Ok)
            {
                sql = @"UPDATE appraisalInitation set supervisorId =@NSID where appraisalId =@AppId;
                       UPDATE appraisalcomment  SET commentBy=@NSID where appraisalId=@AppId AND commentBy=@OSID";
            }
            else
            {
                sql = @"UPDATE appraisalInitation set supervisorId =@NSID where supervisorId =@OSID and STATUS in (2,3,4,5,6,7,10,11,12,13,14,18,17);
                       UPDATE ac set Ac.commentBy=@NSID from appraisalcomment ac join appraisalInitation ai on ac.appraisalId=ai.appraisalId where commentBy=@OSID and STATUS in (2,3,4,5,6,7,10,11,12,13,14)";
            }
        }
        else
        {
            if (!Ok)
            {
                sql = @"UPDATE appraisalInitation set reviewerId =@NSID where appraisalId =@AppId;
                        UPDATE appraisalcomment  SET commentBy=@NSID where appraisalId=@AppId AND commentBy=@OSID";
            }
            else
            {
                sql = @"UPDATE appraisalInitation set reviewerId =@NSID where reviewerId =@OSID and STATUS in (2,3,4,5,6,7,10,11,12,13,14,16,17);
                        UPDATE ac set Ac.commentBy=@NSID from appraisalcomment ac join appraisalInitation ai on ac.appraisalId=ai.appraisalId where commentBy=@OSID and STATUS in (2,3,4,5,6,7,10,11,12,13,14)";
            }
        }

        sql = sql.Replace("@NSID", newsuv.ToString());
        sql = sql.Replace("@OSID", old.ToString());
        sql = sql.Replace("@AppId", appid.ToString());
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        try
        {
            Context.Response.Write("Successfully updated");
        }
        catch (Exception Ex)
        {

            Context.Response.Write(Ex.Message);
        }

    }
    [WebMethod]
    public void BranchDeptPosList(string flag,int BranchId)
    {
        List<ApprisalStatus> Result = new List<ApprisalStatus>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        DataTable dt = new DataTable();
        if (flag == "B")
        {
            SqlDataAdapter da = new SqlDataAdapter("Select BRANCH_ID Id,BRANCH_NAME [Text] from Branches", con);
            da.Fill(dt);
        }
        else if (flag == "D")
        {
            SqlDataAdapter da = new SqlDataAdapter("Select DEPARTMENT_ID Id, DEPARTMENT_NAME[Text] from Departments where BRANCH_ID = "+BranchId, con);
            da.Fill(dt);
        }
        else if (flag == "P")
        {
            SqlDataAdapter da = new SqlDataAdapter("Select ROWID Id,CONCAT(DETAIL_DESC,'(',DETAIL_TITLE,')') [Text]from StaticDataDetail where TYPE_ID=4", con);
            da.Fill(dt);
        }
        

        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i = i + 1;
            Result.Add(new ApprisalStatus
            {
                Sn = i,
                Text = dr["Text"].ToString(),
                Value = Convert.ToInt32(dr["Id"].ToString()),


            });
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
   
    #endregion
    #region DashBoard
    [WebMethod(EnableSession = true)]
    public void JdToAssignList()
    {
        List<JobDescription> Result = new List<JobDescription>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = @"select Distinct CONCAT(E.FIRST_NAME,' ',E.MIDDLE_NAME,' ',E.LAST_NAME) 'EmployeeName',
                        (Select B.BRANCH_NAME from Branches B where b.BRANCH_ID=E.BRANCH_ID )Branch,
                        (Select B.DETAIL_TITLE from StaticDataDetail B where b.ROWID=E.POSITION_ID )Position
                        from SuperVisroAssignment S JOIN Employee E 
                        ON S.EMP=E.EMPLOYEE_ID
                        WHERE S.SUPERVISOR=" + ReadSession().Emp_Id +
                        @" AND E.EMPLOYEE_ID not in (Select empId from jobDescription where supervisorId ="
                        + ReadSession().Emp_Id + @" AND FiscalId=Dbo.ReturnFiscalYear(GetDate()) AND IsDeleted=0 OR (IsDeleted iS NULL OR IsDeleted=0)) 
                           AND S.SUPERVISOR_TYPE='i' AND E.EMP_STATUS='458'";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new JobDescription
                {
                    Sn = i,
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Branch = dr["Branch"].ToString(),
                    Position = dr["Position"].ToString(),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void PendingTaskReview(string status)
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();
        string sql = null;
        if (status == "PA")
        {
            sql = @"Select* from (SELECT  DISTINCT AI.employeeId AS EMPLOYEE_ID,
                    dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EmployeeName, 
                    AI.appraisalId,
                    (Select B.BRANCH_NAME from Branches B where b.BRANCH_ID=E.BRANCH_ID )Branch,
                    (Select B.DETAIL_TITLE from StaticDataDetail B where b.ROWID=E.POSITION_ID )Position,
                    CONVERT(varchar, AI.appraisalStartDate, 101) as AppraisalStartDate,
                     CONVERT(varchar, AI.appraisalEndDate, 101) as AppraisalEndDate,
                     fy.FISCAL_YEAR_NEPALI,
                    st.Title 'Status',
                    st.Code
                    FROM    dbo.appraisalInitation AI WITH(NOLOCK)
                    INNER JOIN dbo.Employee E WITH(NOLOCK) ON AI.employeeId = E.EMPLOYEE_ID
                    Inner join FiscalYear Fy  on fy.FISCAL_YEAR_ID = AI.FiscalYear
                    Inner join ApprisalStatus st on st.Code = ai.STATUS
                    where
                    AI.reviewerId = ISNULL(" + ReadSession().Emp_Id + @", AI.reviewerId)                   
                    AND AI.status in(3) 
                    AND fy.FLAG = '1' AND(IsDeleted IS NULL OR IsDeleted = 0)
                    )as X order by X.appraisalId";

        }
        if (status == "PR")
        {
            sql = @"Select* from (SELECT  DISTINCT AI.employeeId AS EMPLOYEE_ID,
                    dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EmployeeName, 
                    AI.appraisalId,
                    (Select B.BRANCH_NAME from Branches B where b.BRANCH_ID=E.BRANCH_ID )Branch,
                    (Select B.DETAIL_TITLE from StaticDataDetail B where b.ROWID=E.POSITION_ID )Position,
                    CONVERT(varchar, AI.appraisalStartDate, 101) as AppraisalStartDate,
                     CONVERT(varchar, AI.appraisalEndDate, 101) as AppraisalEndDate,
                     fy.FISCAL_YEAR_NEPALI,
                    st.Title 'Status',
                    st.Code
                    FROM    dbo.appraisalInitation AI WITH(NOLOCK)
                    INNER JOIN dbo.Employee E WITH(NOLOCK) ON AI.employeeId = E.EMPLOYEE_ID
                    Inner join FiscalYear Fy  on fy.FISCAL_YEAR_ID = AI.FiscalYear
                    Inner join ApprisalStatus st on st.Code = ai.STATUS
                    where
                     AI.reviewerId = ISNULL(" + ReadSession().Emp_Id + @", AI.reviewerId)                   
                    AND AI.status in(7) 
                    AND fy.FLAG = '1' AND(IsDeleted IS NULL OR IsDeleted = 0)
                    )as X  order by X.appraisalId";
        }

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EmployeeName"].ToString(),
                    Branch = dr["Branch"].ToString(),
                    Position = dr["Position"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["Employee_Id"].ToString())),
                    EmpId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    AppId = Convert.ToInt32(dr["Employee_Id"].ToString()),
                }
                );

            i++;
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    [WebMethod(EnableSession = true)]
    public void CommiteePendingTask()
    {
        List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
        string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstring;
        con.Open();

        
        string sql = @"Select DISTINCT * from(SELECT  DISTINCT AI.employeeId AS EMPLOYEE_ID,
                    dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EMPNAME, AI.appraisalId,
                    CONVERT(varchar, AI.appraisalStartDate, 101) as AppraisalStartDate,
                     CONVERT(varchar, AI.appraisalEndDate, 101) as AppraisalEndDate,
                    (Select DETAIL_DESC from StaticDataDetail where ROWID=AI.currPosition)Position,
                     fy.Fiscal_Year_Id,
                     fy.FISCAL_YEAR_NEPALI,
                     st.Title 'Status',
                     St.Code
                    FROM    dbo.appraisalInitation AI WITH(NOLOCK)
                    INNER JOIN dbo.AppraisalPosition AP WITH(NOLOCK) ON AI.currPosition = AP.PositionId
                    INNER JOIN dbo.Employee E WITH(NOLOCK) ON AI.employeeId = E.EMPLOYEE_ID
                    Inner join appReviewerList Rl ON rl.AppraisalLevelId = AP.AppraisalLevelId
                    Inner join FiscalYear Fy  on fy.FISCAL_YEAR_ID = AI.FiscalYear
                    Inner join ApprisalStatus st on st.Code = ai.STATUS				
                    where
                     rl.Active <> 'N'
                    AND  AI.status in (9, 8)
                   AND rl.EmployeeName =  " + ReadSession().Emp_Id.ToString() + @"
                  
					and e.EMP_TYPE IS NULL
                    AND fy.FLAG IS NOT NULL
                    AND e.EMP_TYPE <> '558'
                    and rl.EmployeeName not in (Select commentBy from appraisalcomment ac where ac.appraisalId=ai.appraisalId and ac.IsDelete=0)	
                    )as X Where 1 = 1
                    UNION 
                    Select DISTINCT * from (SELECT  DISTINCT AI.employeeId AS EMPLOYEE_ID,
                    dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EMPNAME, AI.appraisalId,
                    CONVERT(varchar, AI.appraisalStartDate, 101) as AppraisalStartDate,
                     CONVERT(varchar, AI.appraisalEndDate, 101) as AppraisalEndDate,
                  (Select DETAIL_DESC from StaticDataDetail where ROWID=AI.currPosition)Position,                    
                    fy.Fiscal_Year_Id,
                     fy.FISCAL_YEAR_NEPALI,
                     st.Title 'Status',
                     St.Code
                    FROM    dbo.appraisalInitation AI WITH(NOLOCK)
                    INNER JOIN dbo.AppraisalPosition AP WITH(NOLOCK) ON AI.currPosition = AP.PositionId
                    INNER JOIN dbo.Employee E WITH(NOLOCK) ON AI.employeeId = E.EMPLOYEE_ID
                    Inner join appReviewerList Rl ON rl.AppraisalLevelId = AP.AppraisalLevelId
                    Inner join FiscalYear Fy  on fy.FISCAL_YEAR_ID = AI.FiscalYear
                    Inner join ApprisalStatus st on st.Code = ai.STATUS
                    where
                     rl.Active <> 'N'
                    AND  AI.status in (9, 8)
					AND rl.EmployeeName =  " + ReadSession().Emp_Id.ToString() + @"                   
                    AND fy.FLAG IS NOT NULL
                    AND e.EMP_TYPE =e.EMP_TYPE
                    and e.EMP_TYPE IS NOT NULL
                 	and rl.EmployeeName not in (Select commentBy from appraisalcomment ac where ac.appraisalId=ai.appraisalId and ac.IsDelete=0)						
                    )as X Where 1 = 1  
					order by X.appraisalId ";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {

            if(Result.Where(x=>x.AppId== Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())).Count() == 0)
            {
                Result.Add(
                new PerformanceAgreement
                {
                    Sn = i,
                    AppriseeName = dr["EMPNAME"].ToString(),
                    EndDate = dr["AppraisalEndDate"].ToString(),
                    Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                    StartDate = dr["AppraisalStartDate"].ToString(),
                    Position = dr["Position"].ToString(),
                    Status = dr["Status"].ToString(),
                    AppIdEncrypt = Uri.EscapeDataString(Crypto(dr["appraisalId"].ToString())),
                    EmpIdEncrypt = Uri.EscapeDataString(Crypto(dr["EMPLOYEE_ID"].ToString())),
                    EmpId = Convert.ToInt32(dr["appraisalId"].ToString()),
                    AppId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                }
                );
                i++;
            }
            

           
        }
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Js.MaxJsonLength = Int32.MaxValue;
        Context.Response.Write(Js.Serialize(Result));
    }
    #endregion

}

