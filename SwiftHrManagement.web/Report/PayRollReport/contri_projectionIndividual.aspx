<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="contri_projectionIndividual.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.contri_projectionIndividual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table border="0" align="center">
    <tr>
        <td>
            <div align="center">
                <asp:Label ID="Lblcompany" Text= "Company" runat="server" CssClass="ReportHeading"></asp:Label><br />
                <asp:Label ID="LblDesc"  Text="Description" runat="server" CssClass="subheading"></asp:Label><br />                                                        
                <asp:Label ID="Lblmonth"  Text="Month" runat="server" CssClass="subheading"></asp:Label><br />
                <asp:Label ID="lblempname" runat="server" CssClass="subheading"></asp:Label><br />                                 
            </div>                             
        </td>   
    </tr>
    <tr>
        <td>
        <div align="center">
        <div id="rptDiv" runat="server"></div>
        </div>
        </td>
        
    </tr>
</table>

</asp:Content>
