<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AssetSummaryBranchWise.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.AssetSummaryBranchWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <div id="divCompany" class="ReportHeader" runat="server" align="center">NCC Bank Limited</div>
                <div id="Div1" class="ReportSubHeader" align="center">Asset Summary Report<br /></div>  
        </header>
        <div class="panel-body">
             <div id="div2">Branch Name : <asp:Label id="branchName" runat="server" CssClass="txtlbl"></asp:Label> </div>           
                    <div style="text-align: right" class="ReportSubHeader">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
            <div id="rpt" runat="server"></div>
        </div>
    </div>
    
</asp:Content>
