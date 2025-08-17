<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryStockExpenses.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.InventoryStockExpenses" %>
<%@ Import Namespace="SwiftHrManagement.web.Library" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%
    if (GetStatic.ReadQueryString("mode", "") == "")
    {
    %>
                <script src="../js/functions.js" type="text/javascript"> </script>
                <link href="../css/style.css" rel="stylesheet" type="text/css" />
     <% 
     }
    %>
</head>
<body>
<form id="form1" runat="server">
        <table align="center">
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div1" class="ReportSubHeader">Inventory Expenses Branch Wise<br />
       
                   <br /> From Date <asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label> &nbsp;To Date : <asp:Label ID="lblToDate" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>                   
                    <div style="text-align: right" class="ReportSubHeader">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                    
                     </td>
            </tr>
            <tr>
                <td>
                    <div runat = "server" id= "exportDiv" class = "noprint" style = "padding-top: 10px">
                    <div style = "float: left; margin-left: 10px; vertical-align: top">
                        <img alt = "Print" title = "Print" style = "cursor: pointer; width: 14px; height: 14px" onclick = " javascript:PrintWindow(); "  src="../images/printer.png" border="0" />
                    </div>
                    <div style = "float: left; margin-left: 10px; vertical-align: top" id = "export" runat = "server">
                        <img alt = "Export to Excel" title = "Export to Excel" style = "cursor: pointer" onclick = " javascript:downloadInNewWindow('<% =Request.Url.AbsoluteUri + "&mode=download"%>');"  src="../../images/excel.gif" border="0" />
                    </div>
                    </div>
                </td>            
            </tr>
            <tr>
                <td colspan="2" align="center"><div id="rpt" runat="server" align="center"></div>
                    &nbsp;</td>
            </tr>
        </table>
</form>
</body>
</html>
