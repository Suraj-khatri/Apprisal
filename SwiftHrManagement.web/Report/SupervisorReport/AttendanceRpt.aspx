<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AttendanceRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.SupervisorReport.AttendanceRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" >
    <tr>
        <td>
            <div align="center">
                <strong>
                        <font size="+1">
                        <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                        <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                        </font>
                    <br />
                    <asp:Panel ID="summaryReport" runat="server">
                        <span>Attendance Report From: </span> 
                        <asp:Label ID="lblFromDate"  Text="test it " runat="server"></asp:Label> 
                        <span> To: </span>
                        <asp:Label ID="lblToDate"  Text="test" runat="server"></asp:Label>
                    </asp:Panel>
                </strong>
            </div>
            <br />

        </td>
    </tr>
    <tr>
        <td>
            <div id="rptDiv" runat="server" ></div>
        </td>
    </tr>
</table>
</asp:Content>
