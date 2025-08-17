<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ExternalTrainingSummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.ExternalTrainingReport.ExternalTrainingSummaryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style10
        {
            height: 50px;
        }
        .style11
        {
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table border="0" width="100%" align="center">
    <tr>
        <td>
            <div align="center">
                <asp:Label ID="Lblcompany" Text= "Company" runat="server" CssClass="ReportHeading"></asp:Label><br />
                <asp:Label ID="LblDesc"  Text="Description" runat="server" CssClass="subheading"></asp:Label><br />                                                        
                <%--<asp:Label ID="Lblmonth"  Text="Month" runat="server" CssClass="subheading"></asp:Label><br />
                <asp:Label ID="lblDepartmentName" runat="server" CssClass="subheading"></asp:Label><br />   --%>                              
            </div>                             
        </td>   
    </tr>
    <tr>
        <td><div id="rptDiv" runat="server"></div></td>
    </tr>
</table>
</asp:Content>
