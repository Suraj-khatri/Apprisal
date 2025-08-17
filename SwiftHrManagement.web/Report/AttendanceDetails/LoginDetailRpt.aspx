<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true"
    CodeBehind="LoginDetailRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.LoginDetailRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div align="center">
                <br />
                    <strong><font size="+1">
                        <asp:Label ID="lblHeading" Text="myHeading" runat="server"></asp:Label><br />
                        <asp:Label ID="lbldesc" Text="test it " runat="server"></asp:Label>
                    </font>
                        <br />
                        <span class="style10">Attendence Detail Of</span><br />
                        <asp:Label ID="empName" Text="" runat="server"></asp:Label><br />
                        <asp:Label ID="branchName" Text="" runat="server"></asp:Label><br />
                        For&nbsp;<asp:Label ID="forDate" Text="" runat="server"></asp:Label>
                    </strong>
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div id="rptDiv" runat="server">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

