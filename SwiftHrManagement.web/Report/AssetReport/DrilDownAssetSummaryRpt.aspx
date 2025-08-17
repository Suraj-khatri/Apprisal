<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DrilDownAssetSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.DrilDownAssetSummaryRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
        <table align="center">
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                    <div class="ReportSubHeader">
                        <b>Asset Summary Report Details</b><br />
                        <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                        Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>, 
                        Group Name: <asp:Label ID="group_name" runat="server" CssClass="txtlbl"></asp:Label>
                        
                    </div>                
                    <div style="text-align: right" class="ReportSubHeader">
                        Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div></td>
            </tr>
        </table> 
</asp:Content>
