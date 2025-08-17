<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="PrintCS.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.Clearance.PrintCS" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table border="0" cellspacing="3" width="60%" cellpadding="0" style="margin-top:20px;" align="center">

    <tr>
        <td  colspan="2" nowrap="nowrap"> <div align="center"><asp:Label ID="compInfo" runat="server" CssClass="rptHeader"></asp:Label></div></td>
    </tr>
    <tr>
        <td colspan="2"><br /></td>
    </tr>
    <tr>
        <td colspan="2"  nowrap="nowrap"><div align="left" class="rptHeader">Clearance Sheet</div></td>
    </tr>
    <tr>
        <td  style="border:1px solid #000000;">
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td  nowrap="nowrap"><div align="left" class="Head" width="200px">Name</div></td>
                    <td  nowrap="nowrap"><div align="left">:&nbsp;&nbsp;<asp:Label ID="lblName" runat="server" CssClass="Head"></asp:Label></div></td>
                </tr>
                <tr>
                    <td  nowrap="nowrap"><div align="left" class="Head">Designation</div></td>
                    <td  nowrap="nowrap"><div align="left">:&nbsp;&nbsp;<asp:Label ID="lblPost" runat="server" CssClass="Head"></asp:Label></div></td>
                </tr>
                <tr>
                    <td  nowrap="nowrap"><div align="left" class="Head">Branch / Department</div></td>
                    <td  nowrap="nowrap"><div align="left">:&nbsp;&nbsp;<asp:Label ID="lblBranchDept" runat="server" CssClass="Head"></asp:Label></div></td>
                </tr>
                <tr>
                    <td  nowrap="nowrap"><div align="left" class="Head">Resignation Effective Date </div></td>
                    <td  nowrap="nowrap"><div align="left">:&nbsp;&nbsp;<asp:Label ID="lblEffectiveDate" runat="server" CssClass="Head"></asp:Label></div></td>
                </tr>
            </table>
        </td>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <div id="clearanceForm" runat="server"></div>
        </td>
    </tr>
</table>
</asp:Content>
