<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="QueryGenerateReport.aspx.cs" Inherits="SwiftHrManagement.web.QueryBuilder.QueryGenerateReport" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table align="center" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
<div align="center">

            <asp:HiddenField ID="Hdnflag" runat="server" />
            <strong><font size="+1">
            <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
            </font></strong>
            <font size="-1"><strong>
            <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font><br />
            
            <font size="-1"><strong>
            <asp:Label ID="lbldesc0"  Text="Query Builder Report" runat="server"></asp:Label></strong></font>

            
            
            
</div>
            
            
            
            
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div id="rptDiv" runat="server">
                </div>
            </td>
        </tr>
    </table>  
</asp:Content>
