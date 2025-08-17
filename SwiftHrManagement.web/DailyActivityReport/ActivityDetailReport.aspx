<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ActivityDetailReport.aspx.cs" Inherits="SwiftHrManagement.web.DailyActivityReport.ActivityDetailReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            height: 64px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="60%" cellpadding="2" cellspacing="2" border="0" align="center">
    <tr>
        <td colspan="3">
            <div align="center"><strong><font size="+1">
                <asp:Label ID="lblHeading" runat="server"></asp:Label><br />
                </font></strong>
                <font size="-1"><strong>
                <asp:Label ID="lbldesc" runat="server"></asp:Label></strong></font>
            </div> 
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td><div id="branch" runat="server" class="txtlbl" align="left">Branch :&nbsp;
                <asp:Label ID="lblBranch" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td><div id="dept" runat="server" class="txtlbl" align="left">Department :&nbsp;
                <asp:Label ID="lblDept" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td><div id="post" runat="server" class="txtlbl" align="left">Position :&nbsp;
                <asp:Label ID="lblPost" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td><div id="emp" runat="server" class="txtlbl" align="left">Employee :&nbsp;
            <asp:Label ID="lblEmployee" runat="server" CssClass="label"></asp:Label>
        </div>
        </td>
    </tr>
    <tr>
        <td><div id="date" runat="server" class="txtlbl" align="left">Date :&nbsp;
            <asp:Label ID="lblDate" runat="server" CssClass="label"></asp:Label>
        </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <div id="rpt" runat="server"></div>
        </td>
    </tr>
    <tr>
        <td class="style10">
            <div class="txtlbl">Comments :<br />
                <asp:TextBox ID="txtComment" runat="server" CssClass="inputTextBoxLP1" Width="500px" TextMode="MultiLine" Visible="false"></asp:TextBox>
                <asp:Label ID="lblComment" runat="server" CssClass="label" Visible="false" style="height:auto"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="VerifyBy" runat="server" visible="false">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td  width="310px">
                            <div id="Verify" runat="server" class="txtlbl" align="left">Verified By :
                            <asp:Label ID="lblVerify" runat="server" CssClass="label"></asp:Label>   
                            </div>
                        </td>
                        <td width="170px">
                            <div id="VDate" runat="server" class="txtlbl" align="left">Date :
                            <asp:Label ID="lblVDate" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div id="VPosition" runat="server" class="txtlbl" align="left">Position :
                            <asp:Label ID="lblVPosition" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnVerify" runat="server" Text="Verify" CssClass="button" 
                Visible="false" onclick="btnVerify_Click" />
        </td>
        <td>
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
