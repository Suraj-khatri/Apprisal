<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="LeaveInCashmentReportDisplay.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveInCashmentReportDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <div align="center">
                    <strong>
                        <font size="+1">
                            <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                        </font>
                        <font size="-1">
                            <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                        </font>
                    </strong>
                </div>
                <div align="center">				
                    <asp:Panel ID="Leave_TypeDetails" runat="server" Visible="true">  
                    <strong>
                        <asp:Label ID="lblSubDesc" runat="server"></asp:Label>
                    </strong>
                    </asp:Panel>
                </div> 
                <br />
            </td>
        </tr>

        <tr>
            <td>
            <div id="rptDiv" runat="server"></div>  
            </td>
        </tr>

    </table>

</asp:Content>

