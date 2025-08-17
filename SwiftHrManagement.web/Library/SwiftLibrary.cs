using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using SwiftHrManagement.web.DAL;


namespace SwiftHrManagement.web.Library
{
    /// <summary>
    /// Summary description for SwiftDao
    /// </summary>
    public class SwiftLibrary : SwiftDao
    {
        public SwiftLibrary()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string CreateDynamicDropDownBox(string name, string sql, string valueField, string textField, string defaultValue)
        {
            var html = new StringBuilder("");
            var width = ""; //string.IsNullOrEmpty(width.Trim()) ? "" : " width = \"" + width + "\"";

            var dt = ExecuteDataset(sql).Tables[0];
            html.Append("<select " + width + " name=\"" + name + "\" id =\"" + name + "\" class = \"formText\">");

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<option value=\"" + row[valueField].ToString() + "\"" + AutoSelect(row[valueField].ToString(), defaultValue) + ">" + row[textField].ToString() + "</option>");
            }

            html.Append("</select>");

            return html.ToString();
        }

        public string CreateDynamicDropDownBox(string name, DataTable dt, string defaultValue)
        {
            var html = new StringBuilder("");
            var width = "";
            if (dt == null || dt.Columns.Count == 0)
                return "";

            var valueField = dt.Columns[0].ColumnName;
            var textField = valueField;
            if (dt.Columns.Count > 1)
            {
                textField = dt.Columns[1].ColumnName;
            }


            html.Append("<select " + width + " name=\"" + name + "\" id =\"" + name + "\" class = \"formText\">");

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<option value=\"" + row[valueField].ToString() + "\"" + AutoSelect(row[valueField].ToString(), defaultValue) + ">" + row[textField].ToString() + "</option>");
            }

            html.Append("</select>");

            return html.ToString();
        }

        public string CreateDynamicDropDownBox(string name, string sql, string defaultValue)
        {
            var dt = ExecuteDataTable(sql);
            return CreateDynamicDropDownBox(name, dt, defaultValue);
        }

        public void SetDefaultDdl(ref DropDownList ddl, string label, bool isClearItem)
        {
            if (isClearItem)
                ddl.Items.Clear();
            var item = new ListItem(label, "");
            ddl.Items.Add(item);
        }

        public void SetList(ref ListBox ddl, string sql, string valueField, string textField)
        {
            var dt = ExecuteDataset(sql).Tables[0];

            ddl.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Value = row[valueField].ToString();
                item.Text = row[textField].ToString();
                ddl.Items.Add(item);
            }

            dt.Dispose();
        }

        public void SetDDL(ref DropDownList ddl, string sql, string valueField, string textField, string valueToBeSelected, string label)
        {
            var ds = ExecuteDataset(sql);
            ListItem item = null;
            if (ds.Tables.Count == 0)
            {
                if (label != "")
                {
                    item = new ListItem(label, "");
                    ddl.Items.Add(item);
                }
                return;
            }
            var dt = ds.Tables[0];

            ddl.Items.Clear();

            if (label != "")
            {
                item = new ListItem(label, "");
                ddl.Items.Add(item);
            }
            foreach (DataRow row in dt.Rows)
            {
                item = new ListItem();
                item.Value = row[valueField].ToString();
                item.Text = row[textField].ToString();

                if (row[valueField].ToString().ToUpper() == valueToBeSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }
        }

        public void SetDDL2(ref DropDownList ddl, string sql, string textField, string valueToBeSelected, string label)
        {
            var dt = ExecuteDataset(sql).Tables[0];
            ListItem item = null;

            ddl.Items.Clear();

            if (label != "")
            {
                item = new ListItem(label, "");
                ddl.Items.Add(item);
            }
            foreach (DataRow row in dt.Rows)
            {
                item = new ListItem();
                item.Value = row[textField].ToString();
                item.Text = row[textField].ToString();

                if (row[textField].ToString().ToUpper() == valueToBeSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }
        }

        public string GetBranchEmail(string branchId, string user)
        {
            return GetSingleResult("SELECT DBO.FNAGetBranchEmail(" + FilterString(branchId) + "," + FilterString(user) + ")");
        }

        public void SetDDL3(ref DropDownList ddl, string sql, string valueField, string textField, string valueToBeSelected, string label)
        {
            var dt = ExecuteDataset(sql).Tables[0];
            ListItem item = null;

            ddl.Items.Clear();

            if (label != "")
            {
                item = new ListItem(label, "");
                ddl.Items.Add(item);
            }
            foreach (DataRow row in dt.Rows)
            {
                item = new ListItem();
                item.Value = row[valueField].ToString();
                item.Text = row[textField].ToString();

                if (row[textField].ToString().ToUpper() == valueToBeSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }
        }

        public void SetRadioButton(ref RadioButtonList ddl, string sql, string valueField, string textField, string valueToBeSelected, string label)
        {
            var dt = ExecuteDataset(sql).Tables[0];
            ListItem item = null;

            ddl.Items.Clear();

            if (label != "")
            {
                item = new ListItem(label, "");
                ddl.Items.Add(item);
            }
            foreach (DataRow row in dt.Rows)
            {
                item = new ListItem();
                item.Value = row[valueField].ToString();
                item.Text = row[textField].ToString();

                if (row[textField].ToString().ToUpper() == valueToBeSelected.ToUpper())
                    item.Selected = true;
                ddl.Items.Add(item);
            }
        }

   
        public void BeginForm(string formCaption)
        {
            var htmlCode = new StringBuilder("");

            htmlCode.AppendLine("<table class=\"container\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"40%\">");
            htmlCode.AppendLine("<tbody>");
            htmlCode.AppendLine("<tr>");
            htmlCode.AppendLine("<td width=\"1%\" class=\"container_tl\"><div></div></td>");
            htmlCode.AppendLine("<td width=\"91%\" class=\"container_tmid\"><div>" + formCaption + "</div></td>");
            htmlCode.AppendLine("<td width=\"8%\" class=\"container_tr\"><div></div></td>");
            htmlCode.AppendLine("</tr>");
            htmlCode.AppendLine("<tr>");
            htmlCode.AppendLine("<td class=\"container_l\"></td>");
            htmlCode.AppendLine("<td class=\"container_content\">");

            HttpContext.Current.Response.Write(htmlCode.ToString());
            htmlCode.Clear();
        }

        public void EndForm()
        {
            var htmlCode = new StringBuilder("");
            htmlCode.AppendLine("</td>");
            htmlCode.AppendLine("<td class=\"container_r\"></td>");
            htmlCode.AppendLine("</tr>");
            htmlCode.AppendLine("<tr>");
            htmlCode.AppendLine("<td class=\"container_bl\"></td>");
            htmlCode.AppendLine("<td class=\"container_bmid\"></td>");
            htmlCode.AppendLine("<td class=\"container_br\"></td>");
            htmlCode.AppendLine("</tr>");
            htmlCode.AppendLine("</tbody>");
            htmlCode.AppendLine("</table>");
            HttpContext.Current.Response.Write(htmlCode.ToString());

            htmlCode.Clear();

        }

        public void BeginHeaderForGrid(string headerCaption, string childAlign)
        {
            var htmlCode = new StringBuilder("");
            htmlCode.AppendLine("<table width=\"100%\" border=\"0\">");
            htmlCode.AppendLine("<tr>");
            htmlCode.AppendLine("<td valign=\"bottom\" class=\"\" valign=\"buttom\">");
            htmlCode.AppendLine("<div class=\"BredCurm\">" + headerCaption + "</div>");
            htmlCode.AppendLine("</td>");
            htmlCode.AppendLine("</tr>");
            htmlCode.AppendLine("<tr>");
            htmlCode.AppendLine("<td valign=\"top\" align=\"" + childAlign + "\">");

            HttpContext.Current.Response.Write(htmlCode.ToString());

            htmlCode.Clear();
        }

        public void BeginHeaderForGrid(string headerCaption)
        {
            BeginHeaderForGrid(headerCaption, "left");
        }

        public void EndHeaderForGrid()
        {
            var htmlCode = new StringBuilder("");
            htmlCode.AppendLine("</td>");
            htmlCode.AppendLine("</tr>");
            htmlCode.AppendLine("</table>");

            HttpContext.Current.Response.Write(htmlCode.ToString());

            htmlCode.Clear();
        }


       
        #region Grid
        public string CreateGrid(string gridName, string gridWidth, string sql, string rowIdField, bool showCheckBox, bool multiSelect, string columns, string cssClass, string callBackFunction)//, string editPage, bool allowEdit, bool allowDelete, bool allowApprove, string customLink, string customVariableList)
        {
            if (string.IsNullOrEmpty(cssClass))
                cssClass = "TBLReport";

            var html = new StringBuilder();

            var dt = ExecuteDataset(sql).Tables[0];
            var columnList = columns.Split(',');

            html.AppendLine(
                "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"left\" class=\"" + cssClass + "\" width = \"" +
                gridWidth + "px\" id =\"" + gridName + "_body\">");

            if (showCheckBox)
            {
                var headerFuntion = "SelectAll(this, '" + gridName + "'," + (multiSelect ? "true" : "false") + ");" + callBackFunction;
                html.AppendLine("<th Class=\"" + cssClass + "\" nowrap style = \"cursor:pointer;text-align: center\" onclick =\"" + headerFuntion + "\">" + (multiSelect ? "√" : "×") + "</th>");
            }

            var columnIndexArray = new ArrayList();

            foreach (var str in columnList)
            {
                columnIndexArray.Add(str);
            }

            var columnArray = new ArrayList();
            foreach (DataColumn col in dt.Columns)
            {
                columnArray.Add(col);
            }

            for (var i = 0; i < columnArray.Count; i++)
            {
                if (columns.Trim().Equals(""))
                {
                    html.AppendLine("<th align=\"left\" nowrap >" + columnArray[i] + "</th>");
                }
                else
                {
                    if (columnIndexArray.Contains(i.ToString()))
                    {
                        html.AppendLine("<th align=\"left\" nowrap >" + columnArray[i] + "</th>");
                    }
                }
            }

            html.AppendLine("</tr>");

            var checkBoxFunction = "";

            if (showCheckBox)
            {
                checkBoxFunction = "ManageSelection(this, '" + gridName + "'," + (multiSelect ? "true" : "false") + ");" +
                                   callBackFunction;
            }

            foreach (DataRow row in dt.Rows)
            {
                html.AppendLine("<tr>");
                if (showCheckBox)
                {
                    html.AppendLine("<td align=\"center\"><input type = \"checkbox\" value = \"" +
                                    row[rowIdField.ToLower()] + "\" name =\"" + gridName + "_rowId\" onclick = \"" +
                                    checkBoxFunction + "\"></td>");
                }

                for (var i = 0; i < dt.Columns.Count; i++)
                {

                    var data = row[i].ToString();
                    if (columns.Trim().Equals(""))
                    {
                        html.AppendLine("<td align=\"left\">" + GetStatic.FormatData(data, "") + "</td>");
                    }
                    else
                    {

                        if (columnIndexArray.Contains(i.ToString()))
                        {
                            html.AppendLine("<td align=\"left\">" + GetStatic.FormatData(data, "") + "</td>");
                        }
                    }
                }
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");

            return html.ToString();
        }

        #endregion


        public void SetYearDdl(ref DropDownList ddl, int low, int high, string label)
        {
            ListItem item = null;
            if (!string.IsNullOrWhiteSpace(label))
            {
                item = new ListItem { Value = "", Text = label };
                ddl.Items.Add(item);
            }
            for (int i = low; i <= high; i++)
            {
                item = new ListItem { Value = i.ToString(), Text = i.ToString() };
                ddl.Items.Add(item);
            }
        }

        public void SetMonthDdl(ref DropDownList ddl, string label)
        {
            ListItem item = null;
            if (!string.IsNullOrWhiteSpace(label))
            {
                item = new ListItem { Value = "", Text = label };
                ddl.Items.Add(item);
            }

            DateTime mnth = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {
                DateTime nextMnth = mnth.AddMonths(i);
                item = new ListItem { Text = nextMnth.ToString("MMMM"), Value = nextMnth.ToString("MMMM") };
                ddl.Items.Add(item);
            }
        }

       
    }
}