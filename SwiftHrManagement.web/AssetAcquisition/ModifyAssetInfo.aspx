<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ModifyAssetInfo.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.ModifyAssetInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>    
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .style1
        {
            width: 173px;
        }
    </style>

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
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
        <td colspan="2">
            <span>Please enter valid data</span>&nbsp;
            <span class="required">(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
            <asp:HiddenField ID ="hdnMessageId" runat="server" />
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="right"> Asset Type:</div></td>
        <td class="style1">
            <asp:Label ID="lblAssetType" runat="server" Text="" CssClass="lblText"></asp:Label></td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="right">Requested Qty:</div></td>
        <td class="style1">
            <asp:Label ID="lblQty" runat="server" Text="" CssClass="lblText"></asp:Label></td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="right">
                Approved Qty:</div></td>  
         <td class="style1"><asp:TextBox ID="TxtAppQuantity" runat="server" CssClass="inputTextBox"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfv" runat="server" 
                 ControlToValidate="TxtAppQuantity" ErrorMessage="Required" SetFocusOnError="True" 
                 ValidationGroup="m"></asp:RequiredFieldValidator>
        </td>              
    </tr>      
    <tr>
        <td colspan="2">
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
            Text="Save" ValidationGroup="m" onclick="BtnSave_Click" Width="75px" />
            &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" Width="75px" 
                onclick="BtnCancel_Click"/>
        </td>

    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

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

