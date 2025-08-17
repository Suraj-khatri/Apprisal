<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="BankDeposits.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.HeadWise.BankDeposits" %>
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
            <td style="text-align:left" >                               
                <strong><span class="style10"> Date:</span> <asp:Label ID="LblCurrentDate" runat="server"></asp:Label></strong>  <br /><br />                
                <span class="style10">&nbsp;The Manager</span><br />
                <span class="style10">&nbsp;<strong><asp:Label ID="LblBankName" runat="server"></asp:Label></strong></span><br />
                <span class="style10">&nbsp;<strong><asp:Label ID="LblBankAddress" runat="server"></asp:Label></strong></span><br />

                <span class="style10">&nbsp;Dear Sir,</span><br />
                <span class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We would like to request you that credit following staff salary for the month of 
                <strong>
                    <asp:Label ID="LblMonth" runat="server"></asp:Label>
                </strong>,
                <strong>
                    <asp:Label ID="LblFiscalyear" runat="server"></asp:Label>
                </strong>
                &nbsp;from our saving account no.&nbsp; 
                <strong>
                    <asp:Label ID="LblAccNo" runat="server"></asp:Label>
                </strong> 
                </span><br /><br />
            </td>
        </tr>

        <tr>
            <td>
                <div id="rptDiv" runat="server" style="text-align:center"></div>
            </td>
        </tr>
    </table>

</asp:Content>
