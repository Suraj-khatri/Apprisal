<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SwiftHrManagement.web.Error"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table class="style4">
        <tr>
            <td style="text-align: center">
                <b>
               <font color="red" size="">Sorry! You are not authorized to view this page, please contact your administrator, Thank You.</font></b> </td>
        </tr>
    </table>
</asp:Content>
