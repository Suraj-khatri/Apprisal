<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DepMonthlyRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.DepMonthlyRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
             <div id="divCompany" class="ReportHeader" runat="server" align="center"></div>
            <div class="ReportSubHeader" align="center">                        
                        <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                        Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>
                        Group Name : <asp:Label ID="group_name" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>                
                    <div style="text-align: right" class="ReportSubHeader">
                        Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
        </header>
       
        <div class="panel-body">
            <div class="form-group">
                <span class="ReportSubHeader">Active Asset (Current) Report </span>
                <div id="rpt" runat="server"></div>
            </div>
             <div class="form-group">
                 <span class="ReportSubHeader">Asset IN (Transfered) Report</span>
                 <div id="rptIN" runat="server"></div>
            </div>
             <div class="form-group">
                 <span class="ReportSubHeader">Inactive Asset Report</span>
                 <div id="rptInactive" runat="server" align="left"></div>
            </div>
             <div class="form-group">
                 <span class="ReportSubHeader">Asset OUT (Transfered) Report</span>
                 <div id="rptOUT" runat="server" align="left"></div>
            </div>
             <div class="form-group">
                 <span class="ReportSubHeader">Asset SOLD Report</span>
                 <div id="rptSOLD" runat="server" align="left"></div
            </div>
             <div class="form-group">
                 <span class="ReportSubHeader">Asset WRITEOFF Report</span>
                 <div id="rptWriteOff" runat="server" align="left"></div>
            </div>
        </div>
    </div>

</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <link href="../../Css/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="center">
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                    <div class="ReportSubHeader">                        
                        <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                        Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>
                        Group Name : <asp:Label ID="group_name" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>                
                    <div style="text-align: right" class="ReportSubHeader">
                        Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                </td>                
            </tr>
            <tr>
                <td colspan="2"><span class="ReportSubHeader">Active Asset (Current) Report </span></td>
            </tr>
            <tr>
                <td colspan="2"> <div id="rpt" runat="server"></div></td>
            </tr>            
            <tr>
                <td colspan="2"><span class="ReportSubHeader">Asset IN (Transfered) Report</span></td>
            </tr>
            <tr>
                <td colspan="2">
                <div id="rptIN" runat="server"></div>
                </td>
            </tr>
             <tr>
                <td colspan="2"><span class="ReportSubHeader">Inactive Asset Report</span> </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptInactive" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><span class="ReportSubHeader">Asset OUT (Transfered) Report</span></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptOUT" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><span class="ReportSubHeader">Asset SOLD Report</span></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptSOLD" runat="server" align="left"></div></td>
            </tr>
            <tr>
                <td colspan="2"><span class="ReportSubHeader">Asset WRITEOFF Report</span></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptWriteOff" runat="server" align="left"></div></td>
            </tr>
        </table> 
    </form>
</body>
</html>
--%>