<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AssetSummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.AssetSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table class="style1" border="0" cellpadding="2" cellspacing="2" width="100%" >
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div3" class="ReportSubHeader">Asset Summary Report<br />
                    Branch Name: <asp:Label ID="lblBranchName" runat="server"></asp:Label></div>
                    <div style="text-align: right">
                      <b> Report Date :</b> <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                    
                     </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
