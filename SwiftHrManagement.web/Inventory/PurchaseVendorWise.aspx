<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="PurchaseVendorWise.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.PurchaseVendorWise" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <div id="divCompany" class="ReportHeader" runat="server" align="center"></div>
                <div id="Div1" class="ReportSubHeader" align="center">Inventory Purchase Vendor Wise<br />
                    Vendor Name: <asp:Label ID="lblVendorName" runat="server"></asp:Label>,
                    Branch Name: <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                    </div>
                    <div align="right">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
        </header>
        <div class="panel-body">
            <div id="rpt" runat="server"></div>
        </div>
    </div>
        
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" >
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div1" class="ReportSubHeader">Inventory Purchase Vendor Wise<br />
                    Vendor Name: <asp:Label ID="lblVendorName" runat="server"></asp:Label>,
                    Branch Name: <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: right">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                    
                     </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
--%>