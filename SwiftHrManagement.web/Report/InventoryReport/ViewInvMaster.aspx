<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ViewInvMaster.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ViewInvMaster" %>

<%@ Import Namespace="SwiftHrManagement.web.Library" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%
        if (GetStatic.ReadQueryString("mode", "") == "")
        {
    %>
    <script src="../../js/functions.js" type="text/javascript"> </script>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <% }%>
</head>
<body>
    <form id="form1" runat="server">

<table width="700px" border="0" cellspacing="0" cellpadding="0" align="center">
  
  <tr>
    <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div1" class="ReportSubHeader">Inventory Master Report<br />
                    Branch Name: <asp:Label ID="LblBranchName" runat="server"></asp:Label>
                    
                    </div>
                    <div style="text-align: right" class="ReportSubHeader">                    
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                       
                    </div>
     </td>
    </tr>
    <tr>
        <td>
            <div id="exportDiv" runat="server" class="noprint" style="padding-top: 10px">
                <div style="float: left; margin-left: 10px; vertical-align: top">
                    <img alt="Print" border="0" onclick=" javascript:PrintWindow(); " src="../../images/printer.png"
                        style="cursor: pointer; width: 14px; height: 14px" title="Print" />
                </div>
                <div id="export" runat="server" style="float: left; margin-left: 10px; vertical-align: top">
                    <img alt="Export to Excel" border="0" onclick=" javascript:downloadInNewWindow('<% =Request.Url.AbsoluteUri + "&mode=download"%>');"
                        src="../../images/excel.gif" style="cursor: pointer" title="Export to Excel" />
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2"><div id="rptDiv" runat="server"></div></td>
    </tr>
    </table>
</form> </body> </html>
