using System;
using System.Data;
using System.Data.SqlClient;

namespace SwiftHrManagement.web.QueryBuilder
{
    public partial class ManageQueryBuilder : BasePage
    {
        clsDAO _clsDao = null;
        string firstFieldName = "";
        string secondFieldName = "";
        string sql = "";
        public ManageQueryBuilder()
        {
            _clsDao = new clsDAO();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDdl();
                txtField.Enabled = false;
                ReportNameList();
            }
            firstFieldName = Request.Form["ctl00$MainPlaceHolder$DdlFirstList"];
            secondFieldName = Request.Form["ctl00$MainPlaceHolder$DdlSecondList"];
            
            ddlsecondTableList.Enabled = false;
        }

        private void setDdl()
        {    string sql = "select id_qb,table_name from queryBuilder";
        _clsDao.setDDL(ref Ddltablelist, sql, "table_name", "table_name", "", "Select");

        }

        protected void Ddltablelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlFirstList.Items.Clear();
            if (Ddltablelist.Text != "")
            {
                string sql = "SELECT id,upper(name) as name FROM syscolumns WHERE id=(SELECT id FROM sysobjects WHERE name=" + filterstring(Ddltablelist.Text) + ")";

                _clsDao.setDDL(ref DdlFirstList, sql, "name", "name", "", "");
            }
        }
        private void ReportNameList()
        {
            string sql = "select Query_Name from QueryHistory where Report_Query is not null";
            _clsDao.setDDL(ref DdlReportName, sql, "Query_Name", "Query_Name", "", "Select");

        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
           
            //****Query for Report Generating***//
            try
            {
                //***** Inserting he data on QueryHistory Table****//
                if (txtReportName.Text != "")
                {
                    this.ReadSession().RptQuery = txtWriteSql.Text;
                    _clsDao.runSQL("INSERT INTO QueryHistory (Query_name,Report_Query,CREATED_BY,CREATED_DATE)VALUES(" + filterstring(txtReportName.Text) + ","
                  + "'" + (txtWriteSql.Text) + "'," + filterstring(ReadSession().UserId) + "," + filterstring(_clsDao.CreatedDate.ToString()) + ")");

                    Response.Redirect("QueryGenerateReport.aspx");
                }
                else
                {
                    try
                    {
                        if (txtField.Text == "" && Ddloperator.Text == "" && txtCondition.Text == "" && txtWriteSql.Text == "")
                        {
                            if (secondFieldName == null)
                                sql = "SELECT *  FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                            else
                                sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                        }
                        else if (txtWriteSql.Text != "")
                        {
                            sql = txtWriteSql.Text.ToUpper();
                            int d = sql.IndexOf("DELETE") + 1;
                            int u = sql.IndexOf("UPDATE") + 1;
                            int i = sql.IndexOf("INSERT") + 1;
                            int t = sql.IndexOf("TRUNCATE") + 1;
                            int p = sql.IndexOf("DROP") + 1;

                            if (d > 0 || u > 0 || i > 0 || t > 0 || p > 0)
                            {
                                lblSql.Text = "";
                                lblSql.Text = "Restricted  SQL Query";
                                lblSql.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                        }
                        else
                        {
                            if (txtField.Text == "" || Ddloperator.Text == "" || txtCondition.Text == "" || secondFieldName == null)
                            {
                                lblField.Text = "Required!";
                                lbloperator.Text = "Required!";
                                lblcondition.Text = "Required!";
                                LblSecondList.Text = "Required!";
                                return;
                            }
                            else
                            {
                                sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                                if (Ddloperator.Text == "like")

                                    sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring("%" + txtCondition.Text + "%");

                                else
                                    sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring(txtCondition.Text);
                            }
                        }
                        this.ReadSession().RptQuery = sql;
                        Response.Redirect("QueryGenerateReport.aspx");
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
            
        }
        
        protected void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtField.Text == "" && Ddloperator.Text == "" && txtCondition.Text == "" && txtWriteSql.Text == "")
                {
                    if (secondFieldName == null)
                        sql = "SELECT *  FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                    else
                        sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                }
                else if (txtWriteSql.Text != "")
                {
                    sql = txtWriteSql.Text.ToUpper();
                    int d = sql.IndexOf("DELETE") + 1;
                    int u = sql.IndexOf("UPDATE") + 1;
                    int i = sql.IndexOf("INSERT") + 1;
                    int t = sql.IndexOf("TRUNCATE") + 1;
                    int p = sql.IndexOf("DROP") + 1;

                    if (d > 0 || u > 0 || i > 0 || t > 0 || p > 0)
                    {
                        lblSql.Text = "";
                        lblSql.Text = "Restricted  SQL Query";
                        lblSql.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    if (txtField.Text == "" || Ddloperator.Text == "" || txtCondition.Text == "" || secondFieldName == null)
                    {
                        lblField.Text = "Required!";
                        lbloperator.Text = "Required!";
                        lblcondition.Text = "Required!";
                        LblSecondList.Text = "Required!";
                        return;
                    }
                    else
                    {
                        sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                        if (Ddloperator.Text == "like")

                            sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring("%" + txtCondition.Text + "%");

                        else
                            sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring(txtCondition.Text);
                    }
                }
                this.ReadSession().RptQuery = sql;
                Response.Redirect("ExportToExcel.aspx");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        protected void BtnGenerateQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtField.Text == "" && Ddloperator.Text == "" && txtCondition.Text == "" && txtWriteSql.Text == "")
                {
                    if (secondFieldName == null)
                        sql = "SELECT *  FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                    else
                        sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                }
                else if (txtWriteSql.Text != "")
                {

                    sql = txtWriteSql.Text.ToUpper();

                    int d = sql.IndexOf("DELETE") + 1;
                    int u = sql.IndexOf("UPDATE") + 1;
                    int i = sql.IndexOf("INSERT") + 1;
                    int t = sql.IndexOf("TRUNCATE") + 1;
                    int p = sql.IndexOf("DROP") + 1;

                    if (d > 0 || u > 0 || i > 0 || t > 0 || p > 0)
                    {
                        lblSql.Text = "";
                        lblSql.Text = "Restricted  SQL Query";
                        lblSql.ForeColor = System.Drawing.Color.Red;
                        return;

                    }

                }
                else
                {
                    if (txtField.Text == "" || Ddloperator.Text == "" || txtCondition.Text == "" || secondFieldName == null)
                    {
                        lblField.Text = "Required!";
                        lbloperator.Text = "Required!";
                        lblcondition.Text = "Required!";
                        LblSecondList.Text = "Required!";
                        return;
                    }
                    else
                    {
                        sql = "SELECT " + secondFieldName + " FROM " + Ddltablelist.Text + " WHERE 1=1 ";
                        if (Ddloperator.Text == "like")

                            sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring("%" + txtCondition.Text + "%");

                        else
                            sql = sql + "AND " + txtField.Text + " " + Ddloperator.Text + " " + filterstring(txtCondition.Text);
                    }
                }

                //**** condition for report Generate****//
                txtWriteSql.Text = sql;
            }

            catch (SqlException ex)
            {
                throw ex;

            }
        }

        protected void txtShowSql_Click(object sender, EventArgs e)
        {
            var sql = "select Report_Query from QueryHistory where Query_Name ='" + DdlReportName.Text+ "'";
            DataTable dt = _clsDao.getTable(sql);
            txtWriteSql.Text = dt.Rows[0][0].ToString();
        }      
    }
}
