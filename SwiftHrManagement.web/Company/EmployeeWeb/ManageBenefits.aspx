<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageBenefits.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageBenefits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<br />
<br />
<table class="tdbackground">
    <tr class="color">            
        <td colspan="3" class="color">
               <span class="heading">&nbsp;&nbsp;&nbsp;Employee Benefits Details&nbsp;&nbsp; </span></td>
    </tr>
    <tr>
        <td class="style14"></td>
        <td class="style15" colspan="2">
            <br /><span class="required" >(* Required fields)</span><br />
                <br />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Benefit Group<br />
                <asp:DropDownList ID="ddlBenefitGroup" runat="server" CssClass="CMBDesign">
                    <asp:ListItem>Salary</asp:ListItem>
                    <asp:ListItem>Allowance</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Benefit Name<br />
                <asp:TextBox ID="TxtBenefitName" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Occurrence<br />
                <asp:DropDownList ID="ddlOccurrence" runat="server" CssClass="CMBDesign">
                    <asp:ListItem Selected="True">Monthly</asp:ListItem>
                    <asp:ListItem>Yearly</asp:ListItem>
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>Hourly</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                    <asp:ListItem>Quarterly</asp:ListItem>
                    <asp:ListItem>Half Yearly</asp:ListItem>
                    <asp:ListItem>Bi Monthly</asp:ListItem>
                    <asp:ListItem>Project Wise</asp:ListItem>
                    <asp:ListItem>Performance Wise</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Details<br />
                <asp:TextBox ID="TxtDetails" runat="server" Height="110px" TextMode="MultiLine" 
                    Width="372px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                GL Code<br />
                <asp:TextBox ID="TxtGlCode" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" />
                </td>
        </tr>
    </table>
</asp:Content>
