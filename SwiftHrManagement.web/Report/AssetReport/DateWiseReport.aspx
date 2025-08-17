<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DateWiseReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.DateWiseReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <table align="center">
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                    <div class="ReportSubHeader">
                        <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                        Report From <asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label>  To 
                        <asp:Label ID="lblToDate" runat="server"  CssClass="txtlbl"></asp:Label><br />
                        Branch Name : <asp:Label ID="lblBranchName" runat="server" CssClass="txtlbl"></asp:Label>, 
                        Group Name: <asp:Label ID="lblGroupName" runat="server" CssClass="txtlbl"></asp:Label>
                        
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
