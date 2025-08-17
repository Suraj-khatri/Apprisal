<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AttendanceReport.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.AttendanceReport" Title="Swift HR Management System 1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
    <tr>
        <td valign="bottom" class="wellcome" align="left">
        <img src="/images/big_bullit.gif">&nbsp;&nbsp;Attendance Reports</td>
    </tr>
    <tr>
        <td valign="top" bgcolor="#999999" height="1"></td>
    </tr>
    <tr>
        <td align="center">
                <asp:GridView ID="attendanceReportView" runat="server"
                AutoGenerateColumns="False"
                CssClass="GView" CellPadding="5" 
                GridLines="None" CellSpacing="1">                   
                <Columns>
                    <asp:BoundField DataField="" HeaderText="" />                    
                </Columns>                
              <EmptyDataTemplate>
                No Record Found !
                </EmptyDataTemplate>
                <HeaderStyle 
                HorizontalAlign="Left" CssClass="HeaderStyle" BorderStyle="None" />
                <AlternatingRowStyle BackColor="#F7F3F7" />
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

