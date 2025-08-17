<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"CodeBehind="RemarksList.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Calender.RemarksList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%">
        <tr>
            <td align="left" class="wellcome" valign="bottom">
                <img src="../../Images/big_bullit.gif" />&nbsp;Remarks Details
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" valign="top">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div>
                    <div id="rpt" runat="server">
                    </div>
                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                                &nbsp;</td>
        </tr>
    </table>
</asp:Content>