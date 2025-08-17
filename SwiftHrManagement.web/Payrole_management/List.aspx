<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.List" Title="Salary Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <%
    string fy = "2003";
    string month = "Baishak";     
%>

    <table width="100%">
        <tr>
            <td valign="bottom" class="wellcome" align="left">
            <img src="/images/big_bullit.gif">&nbsp;Payroll Calculation <asp:Label ID="lblMonth" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" bgcolor="#999999" height="1"></td>
        </tr>
        <tr>
            <td><asp:HiddenField id = "hdnmonth" runat ="server" />
            
                <asp:HiddenField id = "hdnfy" runat ="server" />
            
                    <div id="rpt" runat="server">
                    </div>
            </td>
        </tr>
        <tr>
            <td align=center>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
