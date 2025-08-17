<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="AssetGroupWiseRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.AssetGroupWiseRpt" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
        <table class="style1" align="center">
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server">NCC Bank Limited</div>
                <div id="Div1" class="ReportSubHeader">Asset Group wise summary Report<br /></div>  
                    <div id="div2" class="ReportSubHeader">Asset Group Name : <asp:Label id="groupName" runat="server" CssClass="txtlbl"></asp:Label> </div>
                    <div id="div3" class="ReportSubHeader">Branch Name : <asp:Label id="branchName" runat="server" CssClass="txtlbl"></asp:Label> </div>           
                    <div style="text-align: right" class="ReportSubHeader">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                    
                     </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
