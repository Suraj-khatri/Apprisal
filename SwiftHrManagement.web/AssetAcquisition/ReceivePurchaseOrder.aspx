<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ReceivePurchaseOrder.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.ReceivePurchaseOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <script type="text/javascript">
        var GB_ROOT_DIR = "greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    
    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
    <title>IME Automotives</title>

    <style type="text/css">
        .style1
        {
            font-size: small;
            color: #008000;
        }
        .style2
        {
            height: 43px;
            width: 583px;
        }
        .style3
        {
            width: 583px;
        }
    </style>


<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>    
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td valign="bottom" class="wellcome">
			<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Receive Asset Purchase Order </td>
		</tr>
		<tr>
			<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
		</tr>
	</table>
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="5" cellspacing="5" class="container" align="center"> 
<tr>
    <td nowrap="nowrap" class="style3"><asp:Label ID="LblMsg" runat="server"></asp:Label>
        <asp:HiddenField ID="hdnVat" runat="server" />
    </td>
</tr>

<tr>
    <td class="style3"><div id="rpt" runat="server"></div></td>
</tr>
<tr>
    <td class="style3"><div align="right">
        <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="button" 
            onclick="BtnDelProduct_Click"/>
        <cc1:ConfirmButtonExtender ID="BtnDelProduct_ConfirmButtonExtender" 
            runat="server" ConfirmText="Confirm to delete?" Enabled="True" 
            TargetControlID="BtnDelProduct">
        </cc1:ConfirmButtonExtender>
        </div></td>
</tr>
    <caption>
        <br />
        <br />
        <tr>
            <td class="style3">
                <fieldset style="list-style:circle; list-style-type:circle; width:80%;">
                    <legend class="style1">Received Information:</legend>
                    <div>
                        <table border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    Message:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="receiveMessage" Display="Dynamic" ErrorMessage="Required!" 
                                        SetFocusOnError="True" ValidationGroup="receive"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="receiveMessage" runat="server" 
                                        CssClass="inputTextBoxMultiLine" Height="55px" Width="567px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Receive Order" ValidationGroup="receive" 
                    Width="85px" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confim To Receive?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Refresh" Width="100px" />
                &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" Width="75px" />
            </td>
        </tr>
    </caption>
</table>   
</ContentTemplate>
</asp:UpdatePanel>
</table>


<script language="javascript" type="text/javascript">
    function editAsset(str) 
    {
        var URL = "/AssetAcquisition/ReceiveOrderQty.aspx?Id=" + str;
        
("Edit Asset Information ", URL, 300, 700);
    }
</script>
</asp:Content>