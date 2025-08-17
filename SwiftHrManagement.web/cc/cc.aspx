<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cc.aspx.cs" Inherits="SwiftHrManagement.web.cc.cc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>cc</title>
    <link href="../css1/bootstrap.min.css" rel="stylesheet" />
    <link href="../ui/css/style.css" rel="stylesheet" />
    <script language="javascript">
        var tableID = "tblMain";
        function AddRow() {

            var data = document.getElementById("<% = name.ClientID %>").value.split("|");
            var hddId = data[1];
            var hddName = data[0];
            if (hddId != "" && hddId != null) {
                var table = document.getElementById(tableID);
                var rowCount = table.rows.length;
                var row = table.insertRow(rowCount);

                //Column - 1
                var cellHdd = row.insertCell(0);
                var hdd = document.createElement("input");
                hdd.type = "hidden";
                hdd.value = hddId;
                cellHdd.appendChild(hdd);
                var spanSN = document.createElement("span");
                cellHdd.appendChild(spanSN);

                //Column - 2
                var cellName = row.insertCell(1);
                cellName.innerHTML = hddName;
                //Column - 3
                var cellDeleteButton = row.insertCell(2);

                RenameRows();
                document.getElementById("<% = name.ClientID %>").value = "";
            }
        }

        function RenameRows() {
            var table = document.getElementById(tableID);
            var rowCount = table.rows.length;
            for (var i = 0; i < rowCount; i++) {
                var row = table.rows[i];
                row.id = "row_" + (i + 1);
                row.cells[0].childNodes[0].id = "hdd_" + (i + 1);
                row.cells[0].childNodes[1].innerHTML = i + 1;
                row.cells[2].innerHTML = '<img class = "showHand" src="../Images/delete.gif" onclick = "DeleteRow(' + (i + 1) + ');"/>';
            }
        }

        function DeleteRow(rowId) {
            var table = document.getElementById(tableID);
            var rowCount = table.rows.length;
            for (var i = 0; i < rowCount; i++) {
                var row = table.rows[i];
                if (row.id == "row_" + rowId) {
                    table.deleteRow(i);
                    break;
                }
            }
            RenameRows(tableID);
        }

        function GetIdListForNotification() {
            var table = document.getElementById(tableID);
            var rowCount = table.rows.length;
            var IdList = "";
            for (var i = 0; i < rowCount; i++) {
                var row = table.rows[i];
                var id = row.cells[0].childNodes[0].value;
                if (id != null && id != "") {
                    IdList = IdList == "" ? id : (IdList + "," + id);
                }
            }
            return IdList;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="cclist" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="row">
                    <div class="col-md-12 form-group autocomplete-form"><label>Email Recipient:</label>  
                <asp:TextBox ID="name" runat="server"
                    CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="email_AutoCompleteExtender" runat="server"
                    DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList" TargetControlID="name"
                    MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                </cc1:AutoCompleteExtender>
                    </div>
                    </div>

                <input type="button" value="Add" onclick="AddRow();" class="btn btn-primary" />
                <table id="tblMain" width="380px" border="0" class="TBL" cellpadding="5" cellspacing="5" align="center">
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
