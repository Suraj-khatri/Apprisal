<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SwiftHrManagement.web.Report.Report" %>
<%@ Import Namespace="SwiftHrManagement.web.Library" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Swift ERP System 1.0</title>

        <%
            if (GetStatic.ReadQueryString("mode", "") == "")
            {
        %>

        <link href="../css/style.css" rel="stylesheet" type="text/css" />
        <script src="../js/functions.js" type="text/javascript"> </script>

        <% }%>
</head>
<body>
<form id="form1" runat="server">
            <div style = "width: 100%">            
                <div runat = "server" id = "head" style = "width: 100%" class="reportHead"> </div>
                <hr style = "width: 100%" runat = "server" id = "hr1" />
                <div runat = "server" id = "filters" class="reportFilters"> </div>
                <div runat = "server" id = "paging" style = "width: 100%" class="reportFilters" Visible="false"> 

                </div>
                <hr style = "width: 100%" runat = "server" id = "hr3" />
                <hr style = "width: 100%" runat = "server" id = "hr2" />
                <div runat = "server" id= "exportDiv" class = "noprint" style = "padding-top: 10px">
                    <div style = "float: left; margin-left: 10px; vertical-align: top">
                        <img alt = "Print" title = "Print" style = "cursor: pointer; width: 14px; height: 14px" onclick = " javascript:PrintWindow(); "  src="/images/printer.png" border="0" />
                        <img alt = "Export to Excel" title = "Export to Excel" style = "cursor: pointer; width: 14px; height: 14px" onclick = " javascript:downloadInNewWindow('<% =Request.Url.AbsoluteUri + "&mode=download"%>');"  src="../images/excel.gif" border="0" />
                    </div>
                </div>
                <div style = "clear: both"></div>
                <div runat = "server" id = "rptDiv" style = "width: 100%"> </div>
            </div>
            <div runat = "server" id = "DivOthers" style = "width: 100%"> </div>
</form>
</body>
</html>
