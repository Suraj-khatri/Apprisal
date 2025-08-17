<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ListPremiumDeduction.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListPremiumDeduction" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnempid" runat="server" />
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            List Premium Deduction 
            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server">	                              
                            </div>   
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <%--<table width="100%">
        <tr>
            <td align="left" class="wellcome" valign="bottom">
                <img src="../../Images/big_bullit.gif" />&nbsp;List Premium Deduction 
                <span class="subheading"><asp:Label ID="LblEmpName" runat="server"></asp:Label></span> 
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" valign="top">
            </td>
        </tr>
        <tr>
            <td align="center">  <asp:HiddenField ID="hdnempid" runat="server" />
                <div>
                    <div id="rpt" runat="server">
                    </div>
                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table> --%>
</asp:Content>
