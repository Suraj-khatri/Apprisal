<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageApprove.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.ManageApprove" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>  
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: small;
            color: #008000;
        }
        .style2
        {
            width: 690px;
        }
    </style>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td valign="bottom" class="wellcome">
			<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Approve Asset Requisition ,
             <span class="subheading"><asp:Label ID="LblBranchDept" runat="server" Text="Label"></asp:Label></span></td>
		</tr>
		<tr>
			<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
		</tr>
	</table>

<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="5" cellspacing="5" class="container" align="center"> 
<tr>
    <td nowrap="nowrap" class="style2"><asp:Label ID="LblMsg" runat="server"></asp:Label>
    </td>
</tr>

<tr>
    <td class="style2"><div id="rpt" runat="server"></div></td>
</tr>

<br />
<br />
<tr>
    <td class="style2">  

    <fieldset style="list-style:circle; list-style-type:circle; width:80%;" >
        <legend class="style1">
            Approved Information:</legend>
        <div>    
            <table border="0" cellpadding="1" cellspacing="1">
                <tr>
                  <td>Message:<br />
                      <asp:TextBox ID="message" runat="server" 
                          CssClass="inputTextBoxMultiLine" Height="55px" Width="680px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </fieldset>

    </td> 
</tr>
<tr>
    <td class="style2">&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnSave" runat="server" Text="Approve " CssClass="button" 
            Width="85px" onclick="BtnSave_Click" ValidationGroup="order"/>
        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
            ConfirmText="Confim To Approve?" Enabled="True" TargetControlID="BtnSave">
        </cc1:ConfirmButtonExtender>
        &nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Refresh" 
            CssClass="button" Width="100px" onclick="BtnDelete_Click"/>&nbsp;<asp:Button 
            ID="BtnBack" runat="server" CssClass="button" onclick="BtnBack_Click" 
            Text="&lt;&lt; Back" Width="75px" />
    </td>
</tr>
    
</table>   
</ContentTemplate>
</asp:UpdatePanel>

</table>
</asp:Content>


