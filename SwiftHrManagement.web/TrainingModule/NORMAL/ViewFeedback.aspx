<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.NORMAL.ViewFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table class="style1" align="center">
            <tr>
                <td colspan="2"><center> Training Feedback Report</center></td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2"><div id="rptSubjective" runat="server"></div></td>
            </tr>
        </table>
</asp:Content>
