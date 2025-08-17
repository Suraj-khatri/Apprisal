<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="individualAssetDetailRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.individualAssetDetailRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">             
    <table>
        <tr>
            <td>
                <div runat="server" id="rpt" style="width:100%"></div>
            </td>
        </tr>
        <tr>
            <td>
                <div runat="server" id="Div1" style="width:100%"></div>
            </td>
        </tr><tr>
            <td>
                <div runat="server" id="Div2" style="width:100%"></div>
            </td>
        </tr><tr>
            <td>
                <div runat="server" id="Div3" style="width:100%"></div>
            </td>
        </tr><tr>
            <td>
                <div runat="server" id="Div4" style="width:100%"></div>
            </td>
        </tr><tr>
            <td>
                <div runat="server" id="Div5" style="width:100%"></div>
            </td>
        </tr>

    </table>
</asp:Content>
