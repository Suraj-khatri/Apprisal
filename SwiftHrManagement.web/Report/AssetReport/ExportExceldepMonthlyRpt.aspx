<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportExceldepMonthlyRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.ExportExceldepMonthlyRpt" %>

<%      Response.ContentType = "application/vnd.ms-excel"; %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
   <table>
            <tr>
                <td colspan="2"><b> Active Asset (Current) Report </b></td>
            </tr>
            <tr>
                 <div runat="server" id="rpt"> </div>
            </tr>            
            <tr>
                <td colspan="2"><b>Asset IN (Transfered) Report</b></td>
            </tr>
            <tr>
                <td colspan="2">
                <div id="rptIN" runat="server"></div>
                </td>
            </tr>
             <tr>
                <td colspan="2"><b>Inactive Asset Report</b> </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptInactive" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><b>Asset OUT (Transfered) Report</b></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptOUT" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><b>Asset SOLD Report</b></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptSOLD" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><b>Asset WRITEOFF Report</b></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptWriteOff" runat="server" align="left"></div></td>
            </tr>
        </table> 
</body>
</html>
