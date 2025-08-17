<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListCEAClaim.aspx.cs" Inherits="SwiftHrManagement.web.CEA.ListCEAClaim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<%--<table width="100%">
    <tr>
        <td align="left" class="wellcome" valign="bottom">
            <img src="../../Images/big_bullit.gif" />&nbsp;&nbsp;CEA Assignment
        </td>
    </tr>
    <tr>
        <td bgcolor="#999999" valign="top">
        </td>
    </tr>
    <tr>
        <td align="center">
                <div>
                <div id="rpt" runat="server"></div>
                <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>--%>
  <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-user"></i>
            CEA Assignment
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                             <div id="rpt" runat="server"></div>
                <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
