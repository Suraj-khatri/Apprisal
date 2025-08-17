<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"  CodeBehind="ViewReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ViewReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <div id="divCompany" class="ReportHeader" runat="server" align="center"></div>
                <div id="Div1" class="ReportSubHeader" align="center">Stock In Hand Report Group Wise<br />
                    Branch Name: <asp:Label ID="LblBranchName" runat="server"></asp:Label><br />
                    Product Group Name: <asp:Label ID="LblProductGroupWise" runat="server"></asp:Label>
                    
                    </div>
                    <div style="text-align: right" class="ReportSubHeader">                    
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
        </header>
        <div class="panel-body">
            <div id="rptDiv" runat="server"></div>
        </div>
    </div>

</asp:Content>