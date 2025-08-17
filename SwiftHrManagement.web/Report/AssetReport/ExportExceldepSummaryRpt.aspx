<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportExceldepSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.ExportExceldepSummaryRpt" %>

<%      Response.ContentType = "application/vnd.ms-excel"; %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <table>
    <tr><td>Asset Group Wise Summary Report</td></tr>
    <tr>
        <td><div runat="server" id="rpt"> </div></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr><td>Depreciation Group Wise Summary Report</td></tr>
    <tr>
        <td><div runat="server" id="rpt1"> </div></td>
    </tr>
    </table>
</body>
</html>
