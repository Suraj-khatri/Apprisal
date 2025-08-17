<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="EditForOrder.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.MakeOrder" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>    
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .style1
        {
            height: 52px;
        }
    </style>

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Modify Asset Details</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Modify Asset Details</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="5" cellspacing="5" class="container">
    <tr>
        <td colspan="4">
            <span>Please enter valid data</span>&nbsp;
            <span class="required">(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
            <asp:HiddenField ID ="hdnReqId" runat="server" />
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="right"> Asset Type:</div></td>
        <td>
            <asp:Label ID="lblAssetType" runat="server" Text="" CssClass="lblText"></asp:Label></td>

    </tr>
    <tr>
            <td nowrap="nowrap"><div align="right">Approved Qty:</div></td>
        <td>
            <asp:Label ID="lblQty" runat="server" Text="" CssClass="lblText"></asp:Label></td>
    </tr>
    <tr>
        <td class="style1">
                Order Qty:<br /><asp:TextBox ID="qty" runat="server" CssClass="inputTextBox" 
                    AutoPostBack="True" ontextchanged="qty_TextChanged"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfv" runat="server" 
                 ControlToValidate="qty"  ErrorMessage="Required" SetFocusOnError="True" 
                 ValidationGroup="m" InitialValue="0"></asp:RequiredFieldValidator>
        </td>  
        <td class="style1">
                Rate:<br />
                <asp:TextBox ID="rate" runat="server" CssClass="inputTextBox" 
                    ontextchanged="rate_TextChanged" AutoPostBack="True"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfc4" runat="server" 
                 ControlToValidate="rate" ErrorMessage="Required" SetFocusOnError="True" 
                 ValidationGroup="m"></asp:RequiredFieldValidator></td>     
        <td class="style1">
                Amount:<br /><asp:TextBox ID="amount" runat="server" CssClass="inputTextBox"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfc5" runat="server" 
                 ControlToValidate="amount" ErrorMessage="Required" SetFocusOnError="True" 
                 ValidationGroup="m"></asp:RequiredFieldValidator></td> 
                
                 
    </tr>
    <tr>
        <td>
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
            Text="Save" ValidationGroup="m" onclick="BtnSave_Click"/>
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Are you sure to save?" Enabled="True" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" onclick="BtnCancel_Click"/>
        </td>

    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
<%--<table width="100%">
        <tr>
            <td align="center">
                 <div>
                    <div id="rpt" runat="server"></div>
                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                </div>
            </td>
        </tr>
</table>--%>


<!--################ START FORM STYLE-->
	    </td>
        <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						
	            </td>
					</tr>
			  </table>			
			  </td>
		  </tr>
	</table>	</td>
  </tr>
</table>    
</asp:Content>
