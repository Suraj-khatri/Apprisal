<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Remarksreport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.Remarksreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top">
                                        <table border="0" cellspacing="3" width="100%" height="30" cellpadding="0" style="margin-left:-70px; margin-top:20px;" align="center">
                                            <tr>
                                                <td>
                                                    <div align="center">
                                                        <strong><font size="+1">
                                                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                                                        <br /></font></strong><font size="-1"><strong>
                                                        <asp:Label ID="lbldesc" runat="server"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="lblRpedesc" runat="server">Holiday Calander Report</asp:Label>
                                                        </strong></font>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <asp:Panel ID="Report_History" runat="server" Visible="false">
                                                    <td>
                                                        <div align="center">
                                                            <strong><span class="style10">Leave History Report : </span></strong><strong>From Date :</strong>
                                                            <asp:Label ID="From_Date"  Text="test it " runat="server"></asp:Label>
                                                            <strong>To :</strong>
                                                            <asp:Label ID="To_Date"  runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </asp:Panel>
                                                <asp:Panel ID="Report_Summary" runat="server" Visible="false">
                                                    <td>
                                                        <div align="center">
                                                            <strong><span class="style10">Leave Summary Report : </span></strong><strong>Report Till Date:</strong>
                                                            <asp:Label ID="AsDate"  Text="test it " runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </asp:Panel>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="center">
                                                        <table border="0">
                                                            <tr>
                                                                <td>
                                                                    <div id="rptDiv" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="rptDivRemarks" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
