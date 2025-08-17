<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApproveSalarysheet.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.ApproveSalarysheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<script language="javascript">
    function checkAll(me) 
    {
        var checkBoxes = document.forms[0].chkTran;
        var boolChecked = me.checked;
        for (i = 0; i < checkBoxes.length; i++)
        {             
            checkBoxes[i].checked = boolChecked ;               
        }
    }    
</script>
    <%
    string fy = "2003";
    string month = "Baishak";     
%>

    <table width="100%">
        <tr>
            <td valign="bottom" class="wellcome" align="left">
                <img src="/images/big_bullit.gif">&nbsp;Approve Salary :
                <asp:Label ID="LblMonth" runat="server"></asp:Label>
                <asp:Label ID="LblYear" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" bgcolor="#999999" height="1">
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField id = "hdnmonth" runat ="server" />
                <asp:HiddenField id = "hdnfy" runat ="server" />
                <div id="rpt" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" />
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="&lt;&lt;Back" />
            </td>
        </tr>
    </table>
</asp:Content>
