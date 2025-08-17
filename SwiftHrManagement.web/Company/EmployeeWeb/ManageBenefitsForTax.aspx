<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageBenefitsForTax.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageBenefitsForTax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table class="style2">
        <tr>
            <td>
                <b>Add New Benefit For Tax<br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </b></td>
        </tr>
        <tr>
            <td>
                Benefit Name<br />
                <asp:TextBox ID="TxtBenefitName" runat="server" Height="17px" Width="206px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                GL Code<br />
                <asp:TextBox ID="TxtGlCode" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" />
                </td>
        </tr>
    </table>
</asp:Content>
