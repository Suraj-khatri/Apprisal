<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListDiscussions.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.ListDiscussions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        #div2
        {
            width: 710px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table border="1">
    <tr>
        <th>Posted By</th>
        <th>Message Head</th>
    </tr>
    <tr>
        <td><div runat ="server"  id="div1">1</div></td>
        <td><div runat ="server"  id="div2">2</div></td>
    </tr>
    <tr>
        <td><div runat ="server"  id="div3"></div></td>
        <td><div runat ="server"  id="div4"></div></td>
    </tr>
</table>
</asp:Content>
