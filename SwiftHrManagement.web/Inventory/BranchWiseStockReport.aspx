<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="BranchWiseStockReport.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.BranchWiseStockReport" %>
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
     <% }%>
</head>
<body>
<form id="form1" runat="server">
        <table border="0" cellpadding="2" cellspacing="2" align="center" >
            <tr>
                <td colspan="2" ><div id="divCompany" class="ReportHeader" runat="server" style="text-align: center"></div>
                <div id="Div1" class="ReportSubHeader" runat="server" style="text-align: center">Inventory Stock Summary Report</div><br />
                
                 <div id="Div2" runat="server" style="text-align: center" class="ReportSubHeader">  
                 Branch Name : <asp:Label ID="lblbranchname" runat="server"></asp:Label><br />
                 Report from date <asp:Label ID="lblfromdate" runat="server"></asp:Label>&nbsp;
                    To  <asp:Label ID="lbltodate" runat="server"></asp:Label>
                    </div>
                    <div class="txtlbl" style="text-align:right">
                    Print Date: <asp:Label ID="lblprintdate" runat="server"></asp:Label></div>
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
                <td colspan="2" align="left"><div id="rpt" runat="server"></div></td>
            </tr>
        </table>
</form>
</body>
</html>
