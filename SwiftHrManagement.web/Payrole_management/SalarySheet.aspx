<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="SalarySheet.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.SalarySheet" Title="Salary Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div>
        <table border="1" cellspacing="0">
            <tr style="height:30px">
                <td colspan="4">Salary Sheet For the month:<b><asp:Label ID="lblMonth" runat="server" Text=""></asp:Label></b></td>                
            </tr>
            <br />
            <tr style="height:30px">
                <td colspan="4">Employee Name:<b><asp:Label ID="lblEmpName" runat="server" Text=""></asp:Label></b></td>                
            </tr>
            <tr style="height:30px">
                <td colspan="2" align="left"><b>Benefits</b></td>
                <td colspan="2" align="left"><b>Deduction</b></td>
            </tr>
            <tr>
                <td colspan="2" style="vertical-align:top;"><asp:Table ID="tblBenefit" runat="server"></asp:Table></td>
                <td colspan="2" style="vertical-align:top;"><asp:Table ID="tbldeduction" runat="server"></asp:Table></td>
            </tr>
            <tr style="height:30px">
                <td><b>Total Benefit</b></td> 
                <td align="right"><b><asp:Label ID="lblTotalBenefit" runat="server" Text=""></asp:Label></b></td>
                <td><b>Total Deduction</b></td> 
                <td align="right"><b><asp:Label ID="lblTotalDeduction" runat="server" Text=""></asp:Label></b></td>
            </tr>
            <tr style="height:30px">
                <td colspan="4" align="left"> <b><i>Net Payable</i></b> :   <b><u><asp:Label ID="lblnetPayable" runat="server" Text=""></asp:Label></u></b></td>
            </tr>
        </table>
        
    </div>
</asp:Content>
